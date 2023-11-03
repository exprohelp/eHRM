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
    public partial class ucVerifyAndEmailIncreament : UserControl
    {
        string _result = string.Empty; string _qry = string.Empty; DataSet _ds = new DataSet();
        string _empcode = string.Empty;
        string fin_year = string.Empty; string _staffType = string.Empty;
        HRPrintingLibrary.Reports.CrtIncrPrintOut rpt = new HRPrintingLibrary.Reports.CrtIncrPrintOut();
        HRPrintingLibrary.Reports.CrForProfessional rptP = new HRPrintingLibrary.Reports.CrForProfessional();
        public ucVerifyAndEmailIncreament()
        {
            InitializeComponent();
        }

        private void uc_Letters_Load(object sender, EventArgs e)
        {
            btnMail.Enabled = false; 
            rpt = new HRPrintingLibrary.Reports.CrtIncrPrintOut();
            rptP = new HRPrintingLibrary.Reports.CrForProfessional();
            dtp_Date.Value = DateTime.Today.AddMonths(1);
            dtp_Date.MinDate = DateTime.Today.AddMonths(-2);
            FillPrimaryInfo();
        }
        private void FillPrimaryInfo()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string qry = "execute pHR_Queries '-','PrimaryInfo','-','2016/03/26','N/A'";
                DataSet ds = GlobalUsage.accounts_proxy.GetQueryResult(qry, "ExHrd");
                ddlDesignation.Items.AddRange(Config.FillTelrikCombo(ds.Tables[1]));
                ddlDesignation.SelectedIndex = 0;
                ddlEmpStatus.Items.AddRange(Config.FillTelrikCombo(ds.Tables[2]));
                ddlEmpStatus.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _qry = "execute pSelectQueries '" + GlobalUsage.Login_id + "','IncrLetter'," + dtp_Date.Value.Month.ToString() + "," + dtp_Date.Value.Year.ToString() + ";";
                _ds = GlobalUsage.accounts_proxy.GetQueryResult(_qry, "exhrd");
                rgv_info.DataSource = _ds.Tables[0];
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void rgv_emp_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

        }
        private void btnEmail_Click(object sender, EventArgs e)
        {
            string qry = "update incr_detail set email_flag='Y',email_by='" + GlobalUsage.Login_id + "' where emp_code='" + _empcode + "' and  month(app_date)=" + dtp_Date.Value.Month.ToString() + " and year(app_date)=" + dtp_Date.Value.Year.ToString() + "";
            string msg = GlobalUsage.accounts_proxy.QueryExecute(qry, "ExHrd");
            btnMail.Enabled = false; 
            if (msg.Contains("Success"))
            {
                rgv_info.CurrentRow.Cells["email_flag"].Value = "Y";
                btnMail.Enabled = true; 
            }

            //try
            //{
            //    if (_empcode.Length > 0)
            //    {
            //        Cursor.Current = Cursors.WaitCursor;
            //        string subject = string.Empty;
            //        if(_staffType == "Professional")
            //           subject = "Contarct Doc " + fin_year;
            //        else
            //           subject = "Salary Structure " + fin_year;

            //        string FileName = "SS_" + _empcode.Replace("-", "") + "" + dtp_Date.Value.ToString("MMyyyy") + ".pdf";
            //        try
            //        {
            //            byte[] data = System.IO.File.ReadAllBytes(Application.StartupPath + "\\temp.pdf");
            //            string msg = GlobalUsage.accounts_proxy.Insert_ConversationByDesktopApp("Post", GlobalUsage.Login_id, _empcode, "", subject, "Kindly download salary structure.", 0, "Normal", data, FileName);
            //            if (msg.Contains("Success"))
            //            {
                        
            //            }
            //        }
            //        catch (Exception ex) { MessageBox.Show(ex.Message); }
            //        Cursor.Current = Cursors.Default;
            //    }
            //    else
            //    { MessageBox.Show("Please select employee"); }
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void rgv_info_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            _qry = "execute pIncreatmentLetter '" + e.Row.Cells["Emp Id"].Value.ToString() + "','" + dtp_Date.Value.ToString("yyyy/MM/dd") + "'";
            _empcode = e.Row.Cells["Emp Id"].Value.ToString();
            btnMail.Enabled = false; 
            if(rgv_info.CurrentRow.Cells["email_flag"].Value.ToString()=="Y")
            btnMail.Enabled = true; 

            GenPdf(_empcode, dtp_Date.Value.ToString("yyyy/MM/dd"), e.Row.Cells["status"].Value.ToString().ToUpper());
            GetDetail(dtp_Date.Value.ToString("yyyy/MM/dd"));
            FillDates();
        }
        private void GenPdf(string emp_code, string date, string status)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                radPdfViewer1.UnloadDocument();
                _qry = "execute pIncreatmentLetter '" + emp_code + "','" + date + "'";
                _ds = GlobalUsage.accounts_proxy.GetQueryResult(_qry, "exhrd");
                fin_year = _ds.Tables[1].Rows[0]["fin_year"].ToString();
                if (_ds.Tables[1].Rows[0]["comp_code"].ToString() == "CSF")
                {
                    _staffType = "employees";
                    HRPrintingLibrary.Reports.CrtCSF rpt = new HRPrintingLibrary.Reports.CrtCSF();
                    rpt.Database.Tables["SalaryChart"].SetDataSource(_ds.Tables[0]);
                    rpt.SetParameterValue("CompanyName", _ds.Tables[1].Rows[0]["comp_name"].ToString());
                    rpt.SetParameterValue("jmd", Application.StartupPath + "\\jmd.jpeg");
                    rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + "\\temp.pdf");
                }
                else
                {
                    if (status != "PROFESSIONAL")
                    {
                        _staffType = "employee";
                        rpt.Database.Tables["SalaryChart"].SetDataSource(_ds.Tables[0]);
                        rpt.SetParameterValue("CompanyName", _ds.Tables[1].Rows[0]["comp_name"].ToString());
                        rpt.SetParameterValue("corp_office", _ds.Tables[1].Rows[0]["corp_office_add"].ToString());
                        rpt.SetParameterValue("reg_office", _ds.Tables[1].Rows[0]["reg_office_add"].ToString());
                        rpt.SetParameterValue("CIN", _ds.Tables[1].Rows[0]["CIN_no"].ToString());
                        rpt.SetParameterValue("phone", _ds.Tables[1].Rows[0]["Phone_No"].ToString());
                        rpt.SetParameterValue("pai_insurance", _ds.Tables[0].Rows[0]["pai_insurance"].ToString());
                        if (_ds.Tables[1].Rows[0]["comp_code"].ToString() == "CHL")
                        {
                            rpt.SetParameterValue("signatureName2", "K P Singh (Director-Administration)");
                            rpt.SetParameterValue("website", "www.chandanhospital.in");
                        }
                        else
                        {
                            rpt.SetParameterValue("signatureName2", "Asmita Singh (Managing Director)");
                            rpt.SetParameterValue("website", "chandan.co.in");
                        }
                        //rpt.SetParameterValue("jmd", Application.StartupPath + "\\jmd.jpeg");
                        rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + "\\temp.pdf");
                    }
                    else
                    {
                        _staffType = "Professional";
                        rptP.Database.Tables["SalaryChart"].SetDataSource(_ds.Tables[0]);
                        rptP.SetParameterValue("CompanyName", _ds.Tables[1].Rows[0]["comp_name"].ToString());
                        rptP.SetParameterValue("corp_office", _ds.Tables[1].Rows[0]["corp_office_add"].ToString());
                        rptP.SetParameterValue("reg_office", _ds.Tables[1].Rows[0]["reg_office_add"].ToString());
                        rptP.SetParameterValue("CIN", _ds.Tables[1].Rows[0]["CIN_no"].ToString());
                        rptP.SetParameterValue("phone", _ds.Tables[1].Rows[0]["Phone_No"].ToString());
                        if (_ds.Tables[1].Rows[0]["comp_code"].ToString() == "CHL")
                        {
                            rpt.SetParameterValue("website", _ds.Tables[1].Rows[0]["website"].ToString());
                        }
                        else
                        {
                            rpt.SetParameterValue("website", _ds.Tables[1].Rows[0]["website"].ToString());
                        }

                        //rptP.SetParameterValue("jmd", Application.StartupPath + "\\jmd.jpeg");
                        rptP.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + "\\temp.pdf");
                    }
                }
                radPdfViewer1.LoadDocument(Application.StartupPath + "\\temp.pdf");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            finally { Cursor.Current = Cursors.Default; }
        }
        public void FillDates()
        {
            ddlIncrList.Items.Clear();
            string qry = "select CONVERT(VARCHAR(10),app_date,111) app_date  from incr_detail where  emp_code='" + _empcode + "' ";
            qry += "union select 'New' app_date  from incr_detail  order by app_date desc ";
            DataSet ds = GlobalUsage.accounts_proxy.GetQueryResult(qry, "ExHrd");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlIncrList.Items.Add(dr["app_date"].ToString());
            }
            ddlIncrList.SelectedIndex = 0;
        }
        private void GetDetail(string date)
        {
            try
            {
                DateTime d = System.DateTime.Now;
                string qry = "exec pGetEmpInfo1 '" + _empcode + "','" + date + "' ";
                DataSet ds = GlobalUsage.accounts_proxy.GetQueryResult(qry, "ExHrd");
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    ddlEmpStatus.Text = dr["Status"].ToString();
                    ddlDesignation.Text = dr["Designation"].ToString();
                    txtSalary.Text = Convert.ToDecimal(dr["Salary_Pf"]).ToString("0");
                    txtHRA.Text = Convert.ToDecimal(dr["Hra"]).ToString("0");
                    txtConv.Text = Convert.ToDecimal(dr["fixed_conv"]).ToString("0");
                    txtTrvLimit.Text = Convert.ToDecimal(dr["trv_Limit"]).ToString("0");
                    txtTelLimit.Text = Convert.ToDecimal(dr["telephone_limit"]).ToString("0");
                    txtBonus.Text = Convert.ToDecimal(dr["Bonus"]).ToString("0");
                    txtSpAllow.Text = Convert.ToDecimal(dr["Sp_Allow"]).ToString("0");
                    txtWashAllow.Text = Convert.ToDecimal(dr["Wash_Allow"]).ToString("0");
                    txtOtAllow.Text = Convert.ToDecimal(dr["ot_allow"]).ToString("0");
                    txtVehAllow.Text = Convert.ToDecimal(dr["Veh_Allow"]).ToString("0");
                    txtMed_Allow.Text = Convert.ToDecimal(dr["Med_Allow"]).ToString("0");
                    txtccaAllow.Text = Convert.ToDecimal(dr["cca"]).ToString("0");
                    txtReimb.Text = Convert.ToDecimal(dr["reimb_amt"]).ToString("0");
                    txtGross.Text = Convert.ToDecimal(dr["gross_salary"]).ToString("0");
                    txtRemark.Text = dr["remark"].ToString();

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void rgv_info_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Cells["email_flag"].Value.ToString() == "Y")
                e.RowElement.ForeColor = Color.Green;
            else
                e.RowElement.ForeColor = Color.Black;
        }
        private void btnFillOld_Click(object sender, EventArgs e)
        {
            GenPdf(_empcode, ddlIncrList.Text, "Employee");
            GetDetail(ddlIncrList.Text);
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Empty;
                Cursor.Current = Cursors.WaitCursor;
                string qry = "update incr_detail set email_flag='N',email_by='" + GlobalUsage.Login_id + "' where emp_code='" + _empcode + "' and  month(app_date)=" + dtp_Date.Value.Month.ToString() + " and year(app_date)=" + dtp_Date.Value.Year.ToString() + "";
                msg = GlobalUsage.accounts_proxy.QueryExecute(qry, "ExHrd");
                if (msg.Contains("Success"))
                {
                    rgv_info.CurrentRow.Cells["email_flag"].Value = "N";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Cursor.Current = Cursors.Default;
        }

        private void radPdfViewer1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string qry = string.Empty;
            btnMail.Enabled = true;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                qry = @"select emp_code,emp_name=emp_name+' ['+designation+' ]' from empdetail where injob='Yes' and emp_name like '" + txtsearch.Text + "%' order by emp_name";
                DataSet ds = GlobalUsage.accounts_proxy.GetQueryResult(qry, "ExHrd");
                ddlPerson.Items.AddRange(GlobalUsage.FillTelrikCombo(ds.Tables[0]));
                ddlPerson.SelectedIndex = 0;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            try
            {
                if (_empcode.Length > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string subject = string.Empty;
                    if(_staffType == "Professional")
                       subject = "Contarct Doc " + fin_year;
                    else
                       subject = "Salary Structure " + fin_year;

                    string FileName = "SS_" + _empcode.Replace("-", "") + "" + dtp_Date.Value.ToString("MMyyyy") + ".pdf";
                    try
                    {
                        byte[] data = System.IO.File.ReadAllBytes(Application.StartupPath + "\\temp.pdf");
                        string msg = GlobalUsage.accounts_proxy.Insert_ConversationByDesktopApp("Post", GlobalUsage.Login_id, ddlPerson.SelectedValue.ToString(), "", subject, "Kindly download salary structure.", 0, "Normal", data, FileName);
                        MessageBox.Show(msg);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    Cursor.Current = Cursors.Default;
                }
                else
                { MessageBox.Show("Please select employee"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }


    }
}
