using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.utility
{
    public partial class SetManager : Telerik.WinControls.UI.RadForm
    {
        string _result = string.Empty; string _empCode = string.Empty;
        DataSet _ds = new DataSet();
        public SetManager()
        {
            InitializeComponent();
          
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
                Cursor.Current = Cursors.WaitCursor;
                _empCode = e.Row.Cells[0].Value.ToString();
                groupBox1.Text=e.Row.Cells[1].Value.ToString()+" ["+_empCode+"]";
                groupBox1.Enabled = true;
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void SetManager_Load(object sender, EventArgs e)
        {
            Rectangle rec = Screen.PrimaryScreen.WorkingArea;
            int size = (rec.Size.Width - this.Width) / 2;
            this.Location = new System.Drawing.Point(size, 155);
        }

        private void dgPostedAt_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
               
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string qry=string.Empty;
                if (cmbDivision.Text.ToUpper() == "DIAGNOSTIC")
                    qry = "select unit_id=unitid,unit_name=branch,Manager=isnull(exhrd.dbo.fnempname(manager),'N/A') from exdiagnostic.dbo.unit_master";
                else if (cmbDivision.Text.ToUpper() == "PHARMACY")
                    qry = "select unit_id=sh_code,unit_name=sh_name,Manager=isnull(exhrd.dbo.fnempname(manager_code),'N/A') from eMediCentral.dbo.shop_info where unitact='Open'";

                _ds = GlobalUsage.accounts_proxy.GetQueryResult(qry, "eAccounts");
                rgv_Units.DataSource = _ds.Tables[0];

                }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void rgv_Units_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string qry = string.Empty;
                if (cmbDivision.Text.ToUpper() == "DIAGNOSTIC")
                    qry = "update exdiagnostic..unit_master set manager='"+_empCode+"' where unitid='"+e.Row.Cells["unit_id"].Value.ToString()+"'";
                else if (cmbDivision.Text.ToUpper() == "PHARMACY")
                    qry = "update eMediCentral..shop_info set manager_code='" + _empCode + "' where sh_code='" + e.Row.Cells["unit_id"].Value.ToString() + "'";

                GlobalUsage.accounts_proxy.QueryExecute(qry, "eAccounts");

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }
    }
}
