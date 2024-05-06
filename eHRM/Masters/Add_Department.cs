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
    public partial class Add_Department : Telerik.WinControls.UI.RadForm
    {
        public Add_Department()
        {
            InitializeComponent();
        }

        private void Add_Department_Load(object sender, EventArgs e)
        {
            Refresh_Grid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GlobalUsage.hr_proxy.QueryExecute("insert into m_department(departmentName) values('"+radTextBox1.Text+"')", "exhrd");
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
                DataSet ds = GlobalUsage.hr_proxy.GetQueryResult("select dept_id, departmentname, isactive from m_Department order by departmentname", "exhrd");
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
                if (e.Row.Cells["isactive"].Value.ToString() == "Y")
                    flag = "N";
                else
                    flag = "Y";

                GlobalUsage.hr_proxy.QueryExecute("update m_cdepartment set isActive='"+flag+"' where dept_id='"+ e.Row.Cells["auto_id"].Value.ToString() + "'", "exhrd");
                Refresh_Grid();
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }
    }
}
