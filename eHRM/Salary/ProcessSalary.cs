using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.Salary
{
    public partial class ProcessSalary : Telerik.WinControls.UI.RadForm
    {
        DataSet _ds = new DataSet();string _result = string.Empty;string _qry = string.Empty;
        public ProcessSalary()
        {
            InitializeComponent();
          
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "SalaryData", rdpDate.Value.ToString("yyyy-MM-dd"), "", "");
                rgvSalary.DataSource = _ds.Tables[0];
                foreach(DataRow dr in _ds.Tables[0].Rows)
                {
                    if (dr["PayStatus"].ToString().ToUpper() == "Y")
                        rgbProces.Enabled = false;
                }

                foreach (var col in rgvSalary.Columns)
                {
                    col.BestFit();
                }
                rgvProcessInfo.DataSource = _ds.Tables[1];
                foreach (DataRow dr in _ds.Tables[1].Rows)
                {
                    if (dr["ProcType"].ToString() == "Proc:Confirmation")
                        btnProcess.Tag = "Y";
                    else if (dr["ProcType"].ToString() == "Proc:Attendance")
                        btnProcessAtt.Tag = "Y";
                    else if (dr["ProcType"].ToString() == "Proc:Payouts")
                        btnProcessAtt.Tag = "Y";
                }
                foreach (var col in rgvProcessInfo.Columns)
                {
                    col.BestFit();
                }
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
            rgbProces.Enabled = true;
          
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if(btnProcess.Tag.ToString()=="Y")
                {
                    DialogResult res = MessageBox.Show("Do You want to Reporcess Confirmation (Y/N)", "ExPro Help", MessageBoxButtons.YesNo);
                    if (res == DialogResult.No)
                        return;
                }
                Cursor.Current = Cursors.WaitCursor;
                string startTime = DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss");
                _qry = "execute dbo.Insert_Modify_SalaryProcessLog '"+rdpDate.Value.ToString("yyyy-MM-dd")+"','Proc:Confirmation','" + GlobalUsage.Login_id + "','" + startTime + "',";
                _qry += "null,'Merge';";
                GlobalUsage.hr_proxy.QueryExecute(_qry, "exhrd");
                GlobalUsage.hr_proxy.QueryExecute("execute pConfirmationProcess", "exhrd");
                _qry = "execute dbo.Insert_Modify_SalaryProcessLog '" + rdpDate.Value.ToString("yyyy-MM-dd") + "','Proc:Confirmation','" + GlobalUsage.Login_id + "','" + startTime + "',";
                _qry += "'"+ DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "','Merge';";
                GlobalUsage.hr_proxy.QueryExecute(_qry, "exhrd");
                btnProcess.Tag = "Y";

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }

        }

        private void btnProcessAtt_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnProcessAtt.Tag.ToString() == "Y")
                {
                    DialogResult res = MessageBox.Show("Do You want to Reporcess Attendance (Y/N)", "ExPro Help", MessageBoxButtons.YesNo);
                    if (res == DialogResult.No)
                        return;
                }
                Cursor.Current = Cursors.WaitCursor;
                string startTime = DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss");
                _qry = "execute dbo.Insert_Modify_SalaryProcessLog '" + rdpDate.Value.ToString("yyyy-MM-dd") + "','Proc:Attendance','" + GlobalUsage.Login_id + "','" + startTime + "',";
                _qry += "null,'Merge';";
                GlobalUsage.hr_proxy.QueryExecute(_qry, "exhrd");
                //_qry = "execute pTransferAttendanceInSummry '"+ rdpDate.Value.ToString("yyyy-MM-dd") + "' ,'-','"+GlobalUsage.Login_id+"','All';";
                _qry = "execute pTransfer_LeaveSummary '" + rdpDate.Value.ToString("yyyy-MM-dd")+ "','All';";
                GlobalUsage.hr_proxy.QueryExecute(_qry, "exhrd");
                _qry = "execute dbo.Insert_Modify_SalaryProcessLog '" + rdpDate.Value.ToString("yyyy-MM-dd") + "','Proc:Attendance','" + GlobalUsage.Login_id + "','" + startTime + "',";
                _qry += "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "','Merge';";
                GlobalUsage.hr_proxy.QueryExecute(_qry, "exhrd");
                btnProcessAtt.Tag = "Y";
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnProcessSalary_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnProcessSalary.Tag.ToString() == "Y")
                {
                    DialogResult res = MessageBox.Show("Do You want to Reporcess Salary (Y/N)", "ExPro Help", MessageBoxButtons.YesNo);
                    if (res == DialogResult.No)
                        return;
                }
                Cursor.Current = Cursors.WaitCursor;
                string startTime = DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss");
                _qry = "execute dbo.Insert_Modify_SalaryProcessLog '" + rdpDate.Value.ToString("yyyy-MM-dd") + "','Proc:Payouts','" + GlobalUsage.Login_id + "','" + startTime + "',";
                _qry += "null,'Merge';";
                GlobalUsage.hr_proxy.QueryExecute(_qry, "exhrd");
                //_qry = "execute AllSalaryTransfer '" + rdpDate.Value.ToString("yyyy-MM-dd") + "','" + GlobalUsage.Login_id + "','ProcessSalary';";
                _qry = "execute pTransfer_SalaryForMonth '" + rdpDate.Value.ToString("yyyy-MM-dd") + "','ALL','"+GlobalUsage.Login_id+"';";
                GlobalUsage.hr_proxy.QueryExecute(_qry, "exhrd");
                _qry = "execute dbo.Insert_Modify_SalaryProcessLog '" + rdpDate.Value.ToString("yyyy-MM-dd") + "','Proc:Payouts','" + GlobalUsage.Login_id + "','" + startTime + "',";
                _qry += "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "','Merge';";
                GlobalUsage.hr_proxy.QueryExecute(_qry, "exhrd");
                btnProcessSalary.Tag = "Y";
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void ProcessSalary_Load(object sender, EventArgs e)
        {
            rdpDate.Value = DateTime.Today;
        }
    }
}
