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
    public partial class doResign : Telerik.WinControls.UI.RadForm
    {
        DataSet _ds = new DataSet();string _empCode = string.Empty;string _result = string.Empty;
        public doResign()
        {
            InitializeComponent();
        }

        private void doResign_Load(object sender, EventArgs e)
        {
            rdp_date.Value = DateTime.Now;

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if(chkInjob.Checked)
                _ds = GlobalUsage.hr_proxy.GetQueryResult("select emp_code,emp_name,f_name=emp_f_name,d_o_j,res_date,ResignRemarks from empdetail where injob='Yes' and comp_code='" + cmbCompany.Text+"'","exhrd");
                else
                _ds = GlobalUsage.hr_proxy.GetQueryResult("select emp_code,emp_name,f_name=emp_f_name,d_o_j,res_date,ResignRemarks  from empdetail  where injob='No' and comp_code='" + cmbCompany.Text+"'", "exhrd");
                rgv_info.DataSource = _ds.Tables[0];

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }

        }

        private void rgv_info_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                rgb_group.Text=e.Row.Cells["emp_name"].Value.ToString()+"["+ e.Row.Cells["emp_code"].Value.ToString() + "]";
                _empCode = e.Row.Cells["emp_code"].Value.ToString();
                rtbResignRemaks.Text = e.Row.Cells["ResignRemarks"].Value.ToString();
                if (!chkInjob.Checked)
                    rdp_date.Value = Convert.ToDateTime(e.Row.Cells["res_date"].Value);

                rgb_group.Enabled = true;
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string noticeServed = "N";
                if (chkNoticeServed.Checked)
                    noticeServed = "Y";
                string qry = "execute pDoResign 'Resign','" + noticeServed + "','" + _empCode + "','" + rdp_date.Value.ToString("yyyy/MM/dd") + "','" + GlobalUsage.Login_id + "','"+rtbResignRemaks.Text+"';";
                DataSet ds = GlobalUsage.hr_proxy.GetQueryResult(qry,"exhrd");
                _result=ds.Tables[0].Rows[0]["result"].ToString();
                if (_result.Contains("Success"))
                {
                    itdoseBridge.ITDoseDataServiceBridgeClient obj = new itdoseBridge.ITDoseDataServiceBridgeClient();
                    string msg = obj.NoDuseEmployee(_empCode);
                    rgb_group.Enabled = false;
                }
                RadMessageBox.Show(_result, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info);

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void chkNoticeServed_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
