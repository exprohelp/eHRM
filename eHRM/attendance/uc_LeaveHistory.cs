using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.attendance
{
    public partial class uc_LeaveHistory : UserControl
    {
        string _empCode = string.Empty; string _empName = string.Empty; string _result = string.Empty;
        public uc_LeaveHistory()
        {
            InitializeComponent();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void rgv_staff_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _empCode = e.Row.Cells[0].Value.ToString();
                _empName = e.Row.Cells[1].Value.ToString();
                gbInfo.Text = e.Row.Cells[1].Value.ToString();
                gb_biometric.Text = e.Row.Cells[1].Value.ToString();
                gbRecordChanges.Text = e.Row.Cells[1].Value.ToString();

                Fill_Info(_empCode);
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        protected void Fill_Info(string empCode)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.accounts_proxy.GetQueryResult("execute pGetAttSummary '" + empCode + "','1991','-','Summary'", "exhrd");
                rgv_info.DataSource = ds.Tables[0];

                //Auto Size Column
                foreach (var col in rgv_info.Columns)
                {
                    col.BestFit();
                }
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btn_XL_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (!System.IO.Directory.Exists(mydocpath))
                {
                    System.IO.Directory.CreateDirectory(mydocpath);
                }
                string fileName = mydocpath + "\\LeaveInfo.xlsx";
                Telerik.WinControls.Export.GridViewSpreadExport spreadExporter;

                spreadExporter = new Telerik.WinControls.Export.GridViewSpreadExport(rgv_info);
                spreadExporter.ExportVisualSettings = true;
                spreadExporter.ExportHierarchy = true;
                spreadExporter.ExportFormat = Telerik.WinControls.Export.SpreadExportFormat.Xlsx;

                spreadExporter.RunExport(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void uc_LeaveHistory_Load(object sender, EventArgs e)
        {
            rdp_from.Value = DateTime.Today;
            rdp_to.Value = DateTime.Today;
        }

        private void rdp_from_Leave(object sender, EventArgs e)
        {
            rdp_to.MinDate = rdp_from.Value;
        }

        private void rdp_go_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.accounts_proxy.GetQueryResult("execute pSelectQueries '" + _empCode + "','Biometric_Data','" + rdp_from.Value.ToString("yyyyMMdd") + "','" + rdp_to.Value.ToString("yyyyMMdd") + "'", "exhrd");
                rgv_bio_info.DataSource = ds.Tables[0];

                //Auto Size Column
                foreach (var col in rgv_bio_info.Columns)
                {
                    col.BestFit();
                }
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.accounts_proxy.GetQueryResult("exec pSearchEmp '" + textSearch.Text + "','ALL'", "exhrd");
                rgv_staff.DataSource = ds.Tables[0];
                ds.Dispose();
            }
            catch (Exception ex) { Telerik.WinControls.RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fdg = new FolderBrowserDialog();
                fdg.ShowDialog();
                string t = "attstatus_"+rdp_from.Value.ToString("ddMMyyyy") + "_" + rdp_to.Value.ToString("ddMMyyyy") + ".xls";
                string fileName = fdg.SelectedPath+"\\"+t;

                Telerik.WinControls.UI.Export.ExportToExcelML exporter = new Telerik.WinControls.UI.Export.ExportToExcelML(this.rgv_bio_info);
                exporter.ExportVisualSettings = true;
                exporter.RunExport(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DataSet ds = GlobalUsage.accounts_proxy.HR_Queries(out _result,"-", "BioAttendanceLogSingle", rdp_from.Value.ToString("yyyy/MM/dd"), rdp_to.Value.ToString("yyyy/MM/dd"),_empCode);
                rgv_bio_info.DataSource = ds.Tables[0];
                //Auto Size Column
                foreach (var col in rgv_bio_info.Columns)
                {
                    col.BestFit();
                }
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnFillList_Click(object sender, EventArgs e)
        {
            DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "EmployeeList", "All Staff List", "", "");
            rgv_staff.DataSource = ds.Tables[0];
            foreach (var col in rgv_staff.Columns)
            {
                col.BestFit();
            }
        }

        private void btnGetHistory_Click(object sender, EventArgs e)
        {
            DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "ChangeHistory", _empCode, "", "");
            rgvHistory.DataSource = ds.Tables[0];
            foreach (var col in rgvHistory.Columns)
            {
                col.BestFit();
            }
        }
    }
}
