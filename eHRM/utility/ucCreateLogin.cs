using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.utility
{
    public partial class ucCreateLogin : UserControl
    {
        public ucCreateLogin()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.GetQueryResult("execute pSearchEmp '" + txtLookFor.Text + "','Search'", "exhrd");
                rgv_employee.DataSource = ds.Tables[0];


            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }

        }

        private void rgv_employee_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string qry = "execute pCreateAppLogin '"+cmbModule.Text+"','N/A','"+e.Row.Cells[0].Value.ToString()+"','Operator','"+GlobalUsage.Login_id+"','N/A'";
                string result = GlobalUsage.hr_proxy.QueryExecute(qry, "exhrd");
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }
    }
}
