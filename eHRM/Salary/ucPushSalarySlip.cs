using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Telerik.WinControls.UI;
namespace eHRM.Salary
{
    public partial class ucPushSalarySlip : Telerik.WinControls.UI.RadForm
    {
        string _result = string.Empty; string _qry = string.Empty; DataSet _ds = new DataSet();
        string _empcode = string.Empty;
        string fin_year = string.Empty;
        string _SAL_DATE = string.Empty;
        string _sal_slip_flag = string.Empty;
        accounts_library.ucPrintSalary obj = new accounts_library.ucPrintSalary("", "", GlobalUsage.Login_id);


        public ucPushSalarySlip()
        {
            InitializeComponent();
        }

        private void uc_Letters_Load(object sender, EventArgs e)
        {
            GlobalUsage.accounts_proxy = new rmAccounts.Accounts_WebServiceSoapClient();
            GlobalUsage.hr_proxy = new HumanResource.Staff_ManagementSoapClient();
            dtp_Date.Value = DateTime.Today;

        }
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                _Index = 0;
                totalcount = 0;
                sentcount = 0;
                if (chk_sent.Checked)
                    _qry = " execute pHR_Queries 'CHCL','SalarySlipTrfList','" + dtp_Date.Value.ToString("yyyy/MM/dd") + "','Y','N/A' ";
                else
                    _qry = " execute pHR_Queries 'CHCL','SalarySlipTrfList','" + dtp_Date.Value.ToString("yyyy/MM/dd") + "','N','N/A' ";
                Cursor.Current = Cursors.WaitCursor;
                _ds = GlobalUsage.accounts_proxy.GetQueryResult(_qry, "exhrd");
                rgv_info.DataSource = _ds.Tables[0];
                if (rgv_info.Rows.Count > 0 && chk_sent.Checked == false)
                    btnSendAll.Enabled = true;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void rgv_info_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataSet ds = new DataSet();
            try
            {
                _empcode = rgv_info.CurrentRow.Cells["emp_code"].Value.ToString();
                ds = GlobalUsage.hr_proxy.GetSalarySlipInfo("N/A", "N/A", dtp_Date.Value.ToString("yyyy/MM/dd"), rgv_info.CurrentRow.Cells["emp_code"].Value.ToString());
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Status"].ToString().Contains("Prof"))
                    {

                    }
                    else if (ds.Tables[0].Rows[0]["Status"].ToString().Contains("Train"))
                    {

                    }
                    else
                    {
                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            radPdfViewer1.UnloadDocument();
                            ReportDocument rptSalary = obj.NonProfessionalLaserSalarySlip(ds, _empcode, dtp_Date.Value.ToString("yyyy/MM/dd"), GlobalUsage.Login_id);
                            rptSalary.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + "\\sal_slip.pdf");

                            radPdfViewer1.LoadDocument(Application.StartupPath + "\\sal_slip.pdf");
                            Cursor.Current = Cursors.Default;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "ExPro Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        private void rgv_info_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Cells["sal_slip_flag"].Value.ToString() == "Y")
                e.RowElement.ForeColor = Color.Green;
            else
                e.RowElement.ForeColor = Color.Black;
        }
        int _Index = 0;
        int totalcount = 0;
        int sentcount = 0;
        DateTime dt;
        private void btnSendAll_Click(object sender, EventArgs e)
        {
            _Index = 0;
            //totalcount = rgv_info.Rows.Count;
            btnSendAll.Enabled = false;
            var rows = rgv_info.Rows.AsEnumerable().Where(x => x.Cells["sal_slip_flag"].Value.ToString() == "N");
            totalcount = rows.Count();
            _empcode = rgv_info.Rows[_Index].Cells["emp_code"].Value.ToString();
            _sal_slip_flag = rgv_info.Rows[_Index].Cells["sal_slip_flag"].Value.ToString();
            _SAL_DATE = dtp_Date.Value.ToString("yyyy/MM/dd");
            dt = dtp_Date.Value;
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_sal_slip_flag == "N")
            {
                try
                {
                    DataSet ds = GlobalUsage.hr_proxy.GetSalarySlipInfo("N/A", "N/A", _SAL_DATE, _empcode);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            //System.Threading.Thread.Sleep(2000);
                            ReportDocument rptSalary = obj.NonProfessionalLaserSalarySlip(ds, _empcode, dtp_Date.Value.ToString("yyyy/MM/dd"), GlobalUsage.Login_id);
                            rptSalary.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + "\\Salaryslip.pdf");
                            rptSalary.Close();
                            rptSalary.Dispose();
                            string subject = "Salary Slip " + fin_year;
                            string FileName = "SalarySlip" + _empcode.Replace("-", "") + "_" + dt.ToString("MM-yyyy") + ".pdf";
                            byte[] data = System.IO.File.ReadAllBytes(Application.StartupPath + "\\Salaryslip.pdf");
                            string msg = GlobalUsage.hr_proxy.Insert_ConversationByDesktopApp("Post", GlobalUsage.Login_id, _empcode, "", subject, "Kindly download salary Slip of the month " + dt.ToString("MM-yyyy") + ".", 0, "Normal", data, FileName);
                            if (msg.Contains("Success"))
                            {
                                string qry = "update trfdsalaryinfo set sal_slip_flag='Y' where emp_code='" + _empcode + "' and  month(trf_date)=" + dt.Month.ToString() + " and year(trf_date)=" + dt.Year.ToString() + "";
                                msg = GlobalUsage.accounts_proxy.QueryExecute(qry, "ExHrd");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "ExPro Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (sentcount < totalcount - 1)
            {
                _Index++;
                sentcount++;
                _empcode = rgv_info.Rows[_Index].Cells["emp_code"].Value.ToString();
                _sal_slip_flag = rgv_info.Rows[_Index].Cells["sal_slip_flag"].Value.ToString();
                rgv_info.Rows[_Index - 1].Cells["sal_slip_flag"].Value = "Y";
                txtsAtatus.Text = totalcount + " / " + (sentcount + 1) + " [" + ((sentcount + 1) * 100 / totalcount) + " % ]";

                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("Successfully Sent");

            }
        }

        private void chk_sent_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_sent.Checked)
                btnSendAll.Enabled = false;

        }

        private void singlePushButton_Click(object sender, EventArgs e)
        {

            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                _SAL_DATE = dtp_Date.Value.ToString("yyyy/MM/dd");
                DataSet ds = GlobalUsage.hr_proxy.GetSalarySlipInfo("N/A", "N/A", _SAL_DATE, _empcode);
                dt = dtp_Date.Value;
                ReportDocument rptSalary = obj.NonProfessionalLaserSalarySlip(ds, _empcode, dtp_Date.Value.ToString("yyyy/MM/dd"), GlobalUsage.Login_id);
                rptSalary.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + "\\Salaryslip.pdf");
                rptSalary.Close();
                rptSalary.Dispose();
                string subject = "Salary Slip " + fin_year;
                string FileName = "SalarySlip" + _empcode.Replace("-", "") + "_" + dt.ToString("MM-yyyy") + ".pdf";
                byte[] data = System.IO.File.ReadAllBytes(Application.StartupPath + "\\Salaryslip.pdf");
                string msg = GlobalUsage.hr_proxy.Insert_ConversationByDesktopApp("Post", GlobalUsage.Login_id, _empcode, "", subject, "Kindly download salary Slip of the month " + dt.ToString("MM-yyyy") + ".", 0, "Normal", data, FileName);
                if (msg.Contains("Success"))
                {
                    string qry = "update trfdsalaryinfo set sal_slip_flag='Y' where emp_code='" + _empcode + "' and  month(trf_date)=" + dt.Month.ToString() + " and year(trf_date)=" + dt.Year.ToString() + "";
                    msg = GlobalUsage.accounts_proxy.QueryExecute(qry, "ExHrd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ExPro Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default; }
        }
    }
}
