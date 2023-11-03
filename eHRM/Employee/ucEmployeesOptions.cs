using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.Employee
{
    public partial class ucEmployeesOptions : UserControl
    {
        string _result = string.Empty; string _qry = string.Empty; string _empCode = string.Empty;
        public ucEmployeesOptions()
        {
            InitializeComponent();
        }

        private void btnFillList_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "EmpListForDutyShift", "", "", "");
                dgEmpList.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void dgEmpList_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                _empCode = e.Row.Cells["emp_code"].Value.ToString();
                txtTrust.Text = e.Row.Cells["trust_percent"].Value.ToString();
                txttds.Text= e.Row.Cells["tax_ded"].Value.ToString();
                btnAdd_Modify.Enabled = true;

                if (e.Row.Cells["sp_flag"].Value.ToString().ToUpper() == "Y")
                { chkSinglePunching.Checked = true; chkSinglePunchBeforeTime.Checked = false; }
                else if (e.Row.Cells["sp_flag"].Value.ToString().ToUpper() == "B")
                { chkSinglePunching.Checked = false; chkSinglePunchBeforeTime.Checked = true; }
                else
                { chkSinglePunching.Checked = false; chkSinglePunchBeforeTime.Checked = false; }

                if (e.Row.Cells["cal_leave_flag"].Value.ToString().ToUpper() == "Y")
                { chkLeaveFlag.Checked = true;  }
                else
                { chkLeaveFlag.Checked = false; }



            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnAdd_Modify_Click(object sender, EventArgs e)
        {
            try
            {
                btnAdd_Modify.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;
                string spFlag = string.Empty; string calLeaveFlag = string.Empty;
               
                if (chkSinglePunching.Checked)
                    spFlag = "Y";
                else
                    spFlag = "N";

                if (chkSinglePunchBeforeTime.Checked)
                    spFlag = "B";
                if (chkLeaveFlag.Checked) calLeaveFlag = "Y"; else calLeaveFlag = "N";


                _qry = "execute pModifyPunchingPolicy '" + _empCode + "','" + spFlag + "','" + calLeaveFlag + "',"+txtTrust.Text+",'" + GlobalUsage.Login_id + "';";
                DataSet ds = GlobalUsage.hr_proxy.GetQueryResult(_qry, "exhrd");
                RadMessageBox.Show(ds.Tables[0].Rows[0]["result"].ToString(), "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnTDSSave_Click(object sender, EventArgs e)
        {
            try
            {
              
                Cursor.Current = Cursors.WaitCursor;
                _qry = "execute pTDS_Modify '" + _empCode + "'," + txttds.Text + ",'" + GlobalUsage.Login_id + "';";
                DataSet ds = GlobalUsage.hr_proxy.GetQueryResult(_qry, "exhrd");
                RadMessageBox.Show(ds.Tables[0].Rows[0]["result"].ToString(), "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }
    }
}
