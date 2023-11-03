using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.Masters
{
    public partial class Add_PostingArea : Telerik.WinControls.UI.RadForm
    {
        public Add_PostingArea()
        {
            InitializeComponent();
        }

        private void Add_PostingArea_Load(object sender, EventArgs e)
        {
            Refresh_Grid();

        }
        private void Refresh_Grid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.GetQueryResult("select autoId,PostingArea,isActive from m_PostingArea order by PostingArea", "exhrd");
                rgv_info.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GlobalUsage.hr_proxy.QueryExecute("insert into m_PostingArea(PostingArea) values('" + txtArea.Text + "')", "exhrd");
                Refresh_Grid();
                txtArea.Text = "";
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void MasterTemplate_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string flag = "N";
                if (e.Row.Cells["isActive"].Value.ToString() == "Y")
                    flag = "N";
                else
                    flag = "Y";

                GlobalUsage.hr_proxy.QueryExecute("update m_PostingArea set isActive='" + flag + "' where autoid='" + e.Row.Cells["autoid"].Value.ToString() + "'", "exhrd");
                Refresh_Grid();
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }
    }
}
