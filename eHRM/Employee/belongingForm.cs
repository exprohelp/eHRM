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
    public partial class belongingForm : Telerik.WinControls.UI.RadForm
    {
        string _result = string.Empty; string _empCode = string.Empty;
        public belongingForm()
        {
            InitializeComponent();
        }

        private void belongingForm_Load(object sender, EventArgs e)
        {
            Rectangle rec = Screen.PrimaryScreen.WorkingArea;
            int size = (rec.Size.Width - this.Width) / 2;
            this.Location = new System.Drawing.Point(size, 155);

            //belonging_types
            DataSet ds = GlobalUsage.accounts_proxy.GetQueryResult("execute pBelonging_Queries 'Category','CHCL-00009','N/A','chcl-00009'", "exhrd");
            cmbBelonging.Items.AddRange(Config.FillWinCombo(ds.Tables[0]));
            ds.Dispose();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.accounts_proxy.GetQueryResult("exec pSearchEmp '" + textSearch.Text+"','ALL'" ,"exhrd");
                rgv_staff.DataSource = ds.Tables[0];
                ds.Dispose();
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string cat=((AddValue)cmbBelonging.SelectedItem).NewDescription.ToString();
                string qry = "execute pInsEmp_AssetInfo '"+_empCode+"','"+assetText.Text+"','"+cat+"','"+textDescription.Text+"','"+GlobalUsage.Login_id+"','N/A'";
                DataSet ds = GlobalUsage.accounts_proxy.GetQueryResult(qry, "exhrd");
                ds.Dispose();
                Fill_Info(_empCode);
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void rgv_staff_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _empCode = e.Row.Cells[0].Value.ToString();
                Fill_Info(_empCode);

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void Fill_Info(string emp_code)
        {
            DataSet ds = GlobalUsage.accounts_proxy.GetQueryResult("execute pBelonging_Queries 'Belongings','" + emp_code+ "','N/A','" + GlobalUsage.Login_id + "'", "exhrd");
            rgv_info.DataSource = ds.Tables[0];
            ds.Dispose();
        }

        private void MasterTemplate_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.accounts_proxy.GetQueryResult("execute pBelonging_Queries 'DelBelonging','N/A','" + e.Row.Cells[0].Value.ToString() + "','" + GlobalUsage.Login_id + "'", "exhrd");
                ds.Dispose();
                
                Fill_Info(_empCode);

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void MasterTemplate_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            e.RowElement.RowInfo.Height = 50;
        }
    }
}
