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
    public partial class setReporting : Telerik.WinControls.UI.RadForm
    {
        DataSet _ds = new DataSet(); string _qry = string.Empty; string _result = string.Empty; int _count = 0; DataTable _dt = new DataTable();
        string _reportBy = string.Empty; string _reportTo = string.Empty; string _reportByCode = string.Empty; string _reportToCode = string.Empty; string _logic = string.Empty;
        public setReporting()
        {
            InitializeComponent();
        }

        private void chkSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSingle.Checked)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _logic = "S";
                    chkBulk.Checked = false;
                    _qry = "SELECT  EmpDetail.Emp_Name+'['+emp_code+']' emp_name,EmpDetail.Emp_Code,comp_code FROM EmpDetail where injob='YES' order by empdetail.Emp_Name";
                    _ds = GlobalUsage.hr_proxy.GetQueryResult(_qry, "exhrd");
                    rgv_S_reportTo.DataSource = _ds.Tables[0];
                    _dt = _ds.Tables[0];
                    rgv_S_ReportedBy.DataSource = _dt;
                    rgb_single.Enabled = true;
                }
                catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
                finally { Cursor.Current = Cursors.Default; }

            }

        }

        private void btnSingleSet_Click(object sender, EventArgs e)
        {

            try
            {
                _result = _reportBy + " will Report To " + _reportTo;
                DialogResult res = MessageBox.Show("Do You Confirm To Set " + _result + " ?", "ExPro Help", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _qry = "execute Ins_Reporting_Hierarchy '" + _reportByCode + "','" + _reportToCode + "','" + _logic + "','N/A'";
                    GlobalUsage.hr_proxy.QueryExecute(_qry, "exhrd");
                }
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void rgv_S_reportTo_Click(object sender, EventArgs e)
        {

        }

        private void rgv_S_ReportedBy_Click(object sender, EventArgs e)
        {

        }

        private void rgv_S_reportTo_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            _count = 0;
            _count = _count + 1;
            lblInfo.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            _reportTo = e.Row.Cells["emp_name"].Value.ToString();
            _reportToCode = e.Row.Cells["emp_code"].Value.ToString();

            lblInfo.Text = _reportTo;

            rgv_S_ReportedBy.Enabled = true;
        }

        private void rgv_S_ReportedBy_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            _count = _count + 1;
            _reportBy = e.Row.Cells["emp_name"].Value.ToString();
            _reportByCode = e.Row.Cells["emp_code"].Value.ToString();
            _result = _reportTo + " By " + _reportBy;
            lblInfo.Text = _result;
            btnSingleSet.Enabled = true;
            if (chkBulk.Checked)
            {
                rgvList.Enabled = true;
                _qry = "SELECT emp_code,rh.Report_To,emp_name=ed.emp_Name+'['+emp_code+']',comp_code from EmpDetail ed inner join Reporting_Hierarchy rh";
                _qry += " on ed.Emp_Code=rh.Report_by where ed.res_date is null and ed.injob = 'YES' and Report_to = '" + _reportByCode + "'";
                _qry += "group by emp_code,rh.Report_To,ed.emp_Name,comp_code order by ed.Emp_Name";
                _ds = GlobalUsage.hr_proxy.GetQueryResult(_qry, "exhrd");
                rgvList.DataSource = _ds.Tables[0];
            }
            else
                rgvList.DataSource = new string[] { };
        }

        private void chkBulk_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBulk.Checked)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    _logic = "R";
                    _qry = "SELECT Emp_Name=EmpDetail.Emp_Name+'['+emp_code+']',EmpDetail.Emp_Code,comp_code FROM EmpDetail where totalpay>6500 and injob='Yes' order by empdetail.Emp_Name";
                    _qry += " SELECT emp_code,rh.Report_To,emp_Name=ed.Emp_Name+'['+emp_code+']',comp_code from EmpDetail ed";
                    _qry += " inner join Reporting_Hierarchy rh on ed.Emp_Code=rh.Report_To";
                    _qry += " where   ed.res_date is null and ed.injob='YES' group by emp_code,rh.Report_To,ed.emp_Name,comp_code order by ed.Emp_Name";

                    _ds = GlobalUsage.hr_proxy.GetQueryResult(_qry, "exhrd");
                    rgv_S_reportTo.DataSource = _ds.Tables[0];
                    _dt = _ds.Tables[1];
                    rgv_S_ReportedBy.DataSource = _dt;
                    rgb_single.Enabled = true;
                }
                catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
                finally { Cursor.Current = Cursors.Default; }
            }
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

        private void btnGetRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                
                _ds = GlobalUsage.hr_proxy.HR_Queries(out _result,"comp_id", "HierarchyRegister","p1","p2","p3");
                rgvRegister.DataSource = _ds.Tables[0];
              
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void setReporting_Load(object sender, EventArgs e)
        {

        }
    }
}
