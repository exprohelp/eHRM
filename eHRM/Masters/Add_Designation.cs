using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.Masters
{
    public partial class Add_Designation : Telerik.WinControls.UI.RadForm
    {
        public Add_Designation()
        {
            InitializeComponent();
        }

        private void Add_Designation_Load(object sender, EventArgs e)
        {
            Refresh_Grid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GlobalUsage.hr_proxy.QueryExecute("insert into designation(desig_name) values('"+radTextBox1.Text+"')", "exhrd");
                Refresh_Grid();
                radTextBox1.Text = "";
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void Refresh_Grid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.GetQueryResult("select autoid,desig_Name,active_flag from designation order by desig_Name", "exhrd");
                rgv_info.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void rgv_info_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string flag = "N";
                if (e.Row.Cells["active_flag"].Value.ToString() == "Y")
                    flag = "N";
                else
                    flag = "Y";

                GlobalUsage.hr_proxy.QueryExecute("update designation set active_flag='"+flag+"' where autoid='"+ e.Row.Cells["auto_id"].Value.ToString() + "'", "exhrd");
                Refresh_Grid();
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }
    }
}
