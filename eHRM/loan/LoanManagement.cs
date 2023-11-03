using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Export;

namespace eHRM.Employee
{
    public partial class LoanManagement : Telerik.WinControls.UI.RadForm
    {
        string _result = string.Empty;
        string _loanId = string.Empty;
        DataSet _ds = new DataSet();
        public LoanManagement()
        {
            InitializeComponent();
        }

        private void LoanManagement_Load(object sender, EventArgs e)
        {
            ddlReportType.SelectedIndex = 0;
        }

        private void dgLoanMaster_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _loanId = dgLoanMaster.CurrentRow.Cells["loan_id"].Value.ToString();
                btnCloseLoan.Enabled = false;
                if (dgLoanMaster.CurrentRow.Cells["close_flag"].Value.ToString() == "N")
                    btnCloseLoan.Enabled = true;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "", "LoanRepaymentInfo", dgLoanMaster.CurrentRow.Cells["loan_id"].Value.ToString(), "-", "-");
                dgLoanRepayInfo.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnGetDetail_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalUsage.hr_proxy = new HumanResource.Staff_ManagementSoapClient();
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "", "LoanMaster", ddlReportType.Text, "-", "-");
                dgLoanMaster.DataSource = ds.Tables[0];

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnCloseLoan_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do You Confirm To Close ?", "ExPro Help", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                string qry = "update loan_master set Close_flag='Y',close_date=getdate(),close_by='" + GlobalUsage.Login_id + "' where loan_id='" + _loanId + "' ";
                try
                {
                    _result = GlobalUsage.hr_proxy.QueryExecute(qry, "ExHrd");
                    if (_result.Contains("Success"))
                    {
                        MessageBox.Show("Successfully Closed");
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { Cursor.Current = Cursors.Default; }
            }
        }

        private void btnLoanRegister_Click(object sender, EventArgs e)
        {

            try
            {
                FolderBrowserDialog fdg = new FolderBrowserDialog();
                fdg.ShowDialog();
                string file_path = "LoanRegister_" + ddlReportType.Text + "_" + DateTime.Today.ToString("ddMMyyyy") + ".xlsx";
                string fileName = fdg.SelectedPath + "\\" + file_path;
                Cursor.Current = Cursors.WaitCursor;
                DataSet _ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "comp_id", "LoanRegister", ddlReportType.Text, "-", "-");
                ExcelGenerator exporter = new ExcelGenerator();
                byte[] data = exporter.GetExcelFile(_ds);
                System.IO.File.WriteAllBytes(file_path, data);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Cursor.Current = Cursors.Default;


        }

        private void btnGetRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;


                _ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "comp_id", "LoanRegister", radDropDownList1.Text, "p2", "p3");
                rgvReport.DataSource = _ds.Tables[0];
                foreach (var col in rgvReport.Columns)
                {
                    col.BestFit();
                }

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnXL_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ExcelGenerator exporter = new ExcelGenerator();
                byte[] data = exporter.GetExcelFile(_ds);
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowDialog();
                string file_path = fbd.SelectedPath + "\\ReportingRegister.xlsx";
                System.IO.File.WriteAllBytes(file_path, data);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Cursor.Current = Cursors.Default;
        }
    }
}
