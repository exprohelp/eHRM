using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.Salary
{
    public partial class ProfessionlSlip : UserControl
    {
        string _empCode = string.Empty;string _result = string.Empty;DataSet _ds = new DataSet();
        string _unitname = string.Empty;string _district = string.Empty;string _panno = string.Empty;string _empname = string.Empty;
        string _localAddress = string.Empty;string _bill_no = string.Empty;
        public ProfessionlSlip()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Professional_Bill(_empCode, _unitname, _district, _panno, _empname, _localAddress);
        }
        public void Professional_Bill(string empcode,string unit_name,string district,string pan_no,string emp_name,string localAddress)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string Company = string.Empty, Adress = string.Empty;
                _ds = GlobalUsage.accounts_proxy.GetQueryResult("execute pGetProfBillNo '" + empcode + "'", "exhrd");
                _bill_no = _ds.Tables[0].Rows[0]["bill_no"].ToString();
                if (_empCode.Substring(0, 3) == "CHC")
                {
                    Company = "Chandan Healthcare Ltd.";
                    Adress = "Sec. G, Jankipuram, Biotech Park,Lucknow";
                }
                else if (_empCode.Substring(0, 3) == "CHL")
                {
                    Company = "Chandan Hospital Ltd.";
                    Adress = "Sec. G, Jankipuram, Biotech Park,Lucknow";
                }
                else if (_empCode.Substring(0, 3) == "IDC")
                {
                    Company = "Indira Diagnostic Centre & Blood Bank Ltd.";
                    Adress = "Sec. G, Jankipuram, Biotech Park,Lucknow";
                }
                else if (_empCode.Substring(0, 3) == "CDL")
                {
                    Company = "Chandan Diagnostic Ltd.";
                    Adress = "Sec. G, Jankipuram, Biotech Park,Lucknow";
                }

                string unitname = unit_name + ", " + district;
                string salaryfor = "Professional Fee Slip For :" + Convert.ToDateTime(rdpDate.Value).ToString("MMM-yyyy");
                accounts_library.Reports.CrProfessionalSlip rptSalary = new accounts_library.Reports.CrProfessionalSlip();
                ExPro.Client.CurrencyTowords conv = new ExPro.Client.CurrencyTowords();
                rptSalary.SetParameterValue("Company", Company);
                rptSalary.SetParameterValue("Address", Adress);
                rptSalary.SetParameterValue("PAN", pan_no);
                rptSalary.SetParameterValue("ref_name", emp_name);
                rptSalary.SetParameterValue("prof_address", localAddress);
                rptSalary.SetParameterValue("billno", _bill_no);
                rptSalary.SetParameterValue("bill_date", rdpDate.Value);
                rptSalary.SetParameterValue("TextNetPay", conv.changeCurrencyToWords(Convert.ToDouble(rtbAmount.Text)));
                rptSalary.SetParameterValue("Amount", Convert.ToDecimal(rtbAmount.Text).ToString("###.00"));

                //rptSalary.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + "\\bill"+_empCode+".pdf");
                rptSalary.PrintToPrinter(1, false, 1, 1);
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default;}
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string qry = string.Empty;
            if (chkInjob.Checked)
            {
                _ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "-", "Prof:BillsRecords", "Yes",rdpDate.Value.ToString("MMyyyy"),"-");
            }
            else
            {
                _ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "-", "Prof:BillsRecords", "No", rdpDate.Value.ToString("MMyyyy"), "-");
            }

            rgv_info.DataSource = _ds.Tables[0];
        }

        private void ProfessionlSlip_Load(object sender, EventArgs e)
        {
            rdpDate.Value = DateTime.Today;
        }

        private void rgv_info_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            _empCode = e.Row.Cells["emp_code"].Value.ToString();
            _unitname = e.Row.Cells["unit_name"].Value.ToString();
            _district =e.Row.Cells["district"].Value.ToString();
            _panno = e.Row.Cells["pan_no"].Value.ToString();
            _empname = e.Row.Cells["emp_name"].Value.ToString();
            _localAddress = e.Row.Cells["localaddress"].Value.ToString();
            rtbAmount.Text = e.Row.Cells["amount"].Value.ToString();
            radGroupBox1.Text = _empname;
        }
    }
}
