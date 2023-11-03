using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eHRM
{
    public partial class ucNewLoan : UserControl
    {
        string _result = string.Empty;string _empCode = string.Empty;
        public ucNewLoan()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime d = System.DateTime.Now;
                Cursor.Current = Cursors.WaitCursor;
                string logic = string.Empty;
                logic = "NR";
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "EmpListForDutyShift2", logic, txtSearch.Text, "");
                dgEmpList.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnLoanAdd_Click(object sender, EventArgs e)
        {
            try
            {
                btnLoad.Enabled = false;
                DateTime d = System.DateTime.Now;
                Cursor.Current = Cursors.WaitCursor;
                if (Convert.ToInt32(txtEMI.Text) == 0)
                {
                    MessageBox.Show("EMI Should be > 0");
                    return;
                }
                _result = GlobalUsage.hr_proxy.InsLoanMaster(_empCode, Convert.ToDecimal(txtLoanAmt.Text),
                    Convert.ToDecimal(txtROI.Text), Convert.ToInt32(txtEMI.Text),
                    rdpSanDate.Value.ToString("yyyy/MM/dd"), rdpSanDate.Value.ToString("yyyy/MM/01"), cmbMethod.Text
                    );
                if (_result.Contains("Success")) {
                    string[] r = _result.Split('|');
                    DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "", "LoanRepaymentInfo", r[1], rdpSanDate.Value.ToString("yyyy/MM/01"), "-");
                    dgLoanRepayInfo.DataSource = ds.Tables[0];
                }
                else
                {
                    dgLoanRepayInfo.DataSource = new string[] { };
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void ucNewLoan_Load(object sender, EventArgs e)
        {
            rdpSanDate.Value = DateTime.Today;
            rdpDedDate.Value = DateTime.Today;

        }

        private void rdpSanDate_Leave(object sender, EventArgs e)
        {
            rdpDedDate.MinDate = rdpSanDate.Value;
        }

        private void dgEmpList_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            btnLoad.Enabled = false;
            _empCode = e.Row.Cells["emp_code"].Value.ToString();
        }

        private void cmbMethod_Leave(object sender, EventArgs e)
        {
            if (cmbMethod.Text.ToUpper() == "SELECT") { 
                MessageBox.Show("Select Method:Flat or Diminising");
                return;
            }
            else if(txtLoanAmt.Text.Length>0)
            btnLoad.Enabled = true;
        }
    }
}
