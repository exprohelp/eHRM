using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace eHRM
{
    public partial class ucAttendanceProcess : UserControl
    {
        public ucAttendanceProcess()
        {
            InitializeComponent();
            rdtp_date.Value = DateTime.Today.AddDays(-30);
        }

        private void rb_Go_Click(object sender, EventArgs e)
        {
            try
            {
                 Cursor.Current = Cursors.WaitCursor;
                DataSet _ds = GlobalUsage.accounts_proxy.GetQueryResult("select  comp_code,emp_code,emp_name,designation,status,col2='N' from empdetail where injob='Yes'", "exhrd");
                rgv_info.DataSource = _ds.Tables[0];
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                foreach(GridViewRowInfo r in rgv_info.Rows) {
                    GlobalUsage.accounts_proxy.QueryExecute("execute pTransferAttendanceInSummry '"+ rdtp_date.Value.ToString("yyyy/MM/dd") +"' ,'" + r.Cells["emp_code"].Value.ToString() + "','"+GlobalUsage.Login_id+"','Single';'", "exhrd");
                    r.Cells["column2"].Value = "Y";
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void rgv_info_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Cells["column2"].Value.ToString() == "Y")
                e.RowElement.ForeColor = Color.Green;
        }

        private void rgv_info_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GlobalUsage.accounts_proxy.QueryExecute("execute pTransferAttendanceInSummry '" + rdtp_date.Value.ToString("yyyy/MM/dd") + "' ,'" + e.Row.Cells["emp_code"].Value.ToString() + "','" + GlobalUsage.Login_id + "','Single';'", "exhrd");
                e.Row.Cells["column2"].Value = "Y";
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
