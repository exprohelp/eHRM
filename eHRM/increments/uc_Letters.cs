using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
namespace eHRM.increments
{
    public partial class uc_Letters : UserControl
    {
        string _result = string.Empty; string _qry = string.Empty; DataSet _ds = new DataSet();
        HRPrintingLibrary.Reports.CrtIncrPrintOut_HR rpt = new HRPrintingLibrary.Reports.CrtIncrPrintOut_HR();
        HRPrintingLibrary.Reports.CrForProfessional_HR rptP = new HRPrintingLibrary.Reports.CrForProfessional_HR();
        public uc_Letters()
        {
            InitializeComponent();
        }

        private void uc_Letters_Load(object sender, EventArgs e)
        {

            dtp_Date.Value = DateTime.Today;
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _qry = "select emp_id=e.emp_code,emp_name=rtrim(e.emp_name)+'/'+e.emp_f_name,id.status from Incr_Detail id inner join empdetail e on id.emp_code=e.emp_code ";
                _qry += "where month(app_date)=" + dtp_Date.Value.Month.ToString() + " and year(app_date)=" + dtp_Date.Value.Year.ToString() + " order by rtrim(e.emp_name)+'/'+e.emp_f_name";
                _ds = GlobalUsage.accounts_proxy.GetQueryResult(_qry, "exhrd");
                rgv_info.DataSource = _ds.Tables[0];
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void rgv_emp_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                radPdfViewer1.UnloadDocument();
                _qry = "execute pIncreatmentLetter '" + e.Row.Cells["Emp Id"].Value.ToString() + "','" + dtp_Date.Value.ToString("yyyy/MM/dd") + "'";
                //_ds=GlobalUsage.accounts_proxy.GetQueryResult(_qry,"exhrd");
                //if (e.Row.Cells["status"].Value.ToString().ToUpper() != "PROFESSIONAL")
                //{
                //    Reports.CrtIncrPrintOut rpt = new Reports.CrtIncrPrintOut();
                //    rpt.Database.Tables["SalaryChart"].SetDataSource(_ds.Tables[0]);
                //    rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + "\\temp.pdf");
                //}
                //else
                //{
                //    Reports.CrtIncrPrintForProfessional rptP = new Reports.CrtIncrPrintForProfessional();
                //    rptP.Database.Tables["SalaryChart"].SetDataSource(_ds.Tables[0]);
                //    rptP.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + "\\temp.pdf");
                //}

                string mgmt_signature = string.Empty;
                _ds = GlobalUsage.accounts_proxy.GetQueryResult(_qry, "exhrd");
                if (_ds.Tables[1].Rows[0]["comp_code"].ToString().ToUpper() == "CHL")
                    mgmt_signature = "K P Singh (Director Administration)";
                else if (_ds.Tables[1].Rows[0]["comp_code"].ToString().ToUpper() == "CHCL")
                    mgmt_signature = "Asmita Singh (Joint Managing Director)";
                else
                    mgmt_signature = "Asmita Singh (Joint Managing Director)";


                if (_ds.Tables[1].Rows[0]["comp_code"].ToString() == "CSF")
                {

                    HRPrintingLibrary.Reports.CrtCSF rpt = new HRPrintingLibrary.Reports.CrtCSF();
                    rpt.Database.Tables["SalaryChart"].SetDataSource(_ds.Tables[0]);
                    rpt.SetParameterValue("CompanyName", _ds.Tables[1].Rows[0]["comp_name"].ToString());
                    rpt.SetParameterValue("jmd", Application.StartupPath + "\\jmd.jpeg");
                    rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + "\\temp.pdf");
                }
                else
                {
                    if (_ds.Tables[0].Rows[0]["status"].ToString().ToUpper() != "PROFESSIONAL")
                    {
                        rpt.Database.Tables["SalaryChart"].SetDataSource(_ds.Tables[0]);
                        rpt.SetParameterValue("CompanyName", _ds.Tables[1].Rows[0]["comp_name"].ToString());
                        rpt.SetParameterValue("corp_office", _ds.Tables[1].Rows[0]["corp_office_add"].ToString());
                        rpt.SetParameterValue("reg_office", _ds.Tables[1].Rows[0]["reg_office_add"].ToString());
                        rpt.SetParameterValue("CIN", _ds.Tables[1].Rows[0]["CIN_no"].ToString());
                        rpt.SetParameterValue("phone", _ds.Tables[1].Rows[0]["Phone_No"].ToString());
                        rpt.SetParameterValue("pai_insurance", _ds.Tables[0].Rows[0]["pai_insurance"].ToString());
                        rpt.SetParameterValue("mgmt_signature", mgmt_signature);
                        rpt.SetParameterValue("jmd", Application.StartupPath + "\\jmd.jpeg");
                        rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + "\\temp.pdf");
                    }
                    else
                    {
                        rptP.Database.Tables["SalaryChart"].SetDataSource(_ds.Tables[0]);
                        rptP.SetParameterValue("CompanyName", _ds.Tables[1].Rows[0]["comp_name"].ToString());
                        rptP.SetParameterValue("corp_office", _ds.Tables[1].Rows[0]["corp_office_add"].ToString());
                        rptP.SetParameterValue("reg_office", _ds.Tables[1].Rows[0]["reg_office_add"].ToString());
                        rptP.SetParameterValue("CIN", _ds.Tables[1].Rows[0]["CIN_no"].ToString());
                        rptP.SetParameterValue("phone", _ds.Tables[1].Rows[0]["Phone_No"].ToString());
                        rpt.SetParameterValue("mgmt_signature", mgmt_signature);
                        rptP.SetParameterValue("jmd", Application.StartupPath + "\\jmd.jpeg");
                        rptP.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + "\\temp.pdf");
                    }
                }
                radPdfViewer1.LoadDocument(Application.StartupPath + "\\temp.pdf");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            finally { Cursor.Current = Cursors.Default; }

        }

    }
}
