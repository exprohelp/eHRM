using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.Employee
{
    public partial class TransferForm : Telerik.WinControls.UI.RadForm
    {
        string _result = string.Empty; string _empCode = string.Empty; string _trfFrom = string.Empty; string _trfTo = string.Empty;
        DataSet _ds = new DataSet();
        public TransferForm()
        {
            InitializeComponent();
        }

        private void TransferForm_Load(object sender, EventArgs e)
        {
            Rectangle rec = Screen.PrimaryScreen.WorkingArea;
            int size = (rec.Size.Width - this.Width) / 2;
            this.Location = new System.Drawing.Point(size, 155);
            _ds=GlobalUsage.hr_proxy.HR_Queries(out _result, "", "PrimaryInfo", "-", "-", "-");
            dgPostedAt.DataSource = _ds.Tables[0];
        }
        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.accounts_proxy.GetQueryResult("exec pSearchEmp '" + textSearch.Text + "','InJob'", "exhrd");
                rgv_staff.DataSource = ds.Tables[0];
                ds.Dispose();
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void rgv_staff_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                dgPostedAt.Enabled = true;
                Cursor.Current = Cursors.WaitCursor;
                _empCode = e.Row.Cells[0].Value.ToString();
                gbInfo.Text=e.Row.Cells[1].Value.ToString()+" ["+_empCode+"]";
                Fill_Info(_empCode);
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void Fill_Info(string empCode)
        {
            _ds = GlobalUsage.accounts_proxy.GetQueryResult("execute pTransfer_Queries 'EmployeeInfo','"+empCode+"','N/A','N/A','"+GlobalUsage.Login_id+"'", "exhrd");
            if (_ds.Tables.Count > 0)
            {
                txtFatherName.Text = _ds.Tables[0].Rows[0]["emp_f_name"].ToString();
                txtDesignation.Text = _ds.Tables[0].Rows[0]["designation"].ToString();
                txtStatus.Text = _ds.Tables[0].Rows[0]["status"].ToString();
                txtPostedAt.Text = _ds.Tables[0].Rows[0]["unit_name"].ToString();
               _trfFrom = _ds.Tables[0].Rows[0]["unit_code"].ToString();
            }
        }

        private void dgPostedAt_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            _trfTo = e.Row.Cells["unit_code"].Value.ToString();
            GBTrfTo.Text = e.Row.Cells["unit_name"].Value.ToString();
            btnTransfer.Enabled = true;
            dgPostedAt.Enabled = false;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
               _result= GlobalUsage.hr_proxy.TransferStaff(_empCode, _trfTo, ddlTrfType.Text, _trfFrom, _trfTo, "N",GlobalUsage.Login_id);
               MessageBox.Show(_result,"ExPro Help",MessageBoxButtons.OK);
            }
            catch (Exception ex) { }
        }
     
    }
}
