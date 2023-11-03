using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.Employee
{
    public partial class ucEmployeesCheckups : UserControl
    {
        string _result = string.Empty; string _qry = string.Empty; string _empCode = string.Empty;
        string _vaccineId = string.Empty; string _freqDays = string.Empty;
        public ucEmployeesCheckups()
        {
            InitializeComponent();
        }

        private void btnFillList_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "EmpListForDutyShift", "", "", "");
                dgEmpList.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void dgEmpList_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                _empCode = e.Row.Cells["emp_code"].Value.ToString();
                getEmployeeVaccineInfo();

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                string[] v = ((AddValue)cmbSelectProcess.SelectedItem).NewValue.ToString().Split('|');
                _vaccineId = v[0]; _freqDays = v[2];
                string qry ="execute Insert_Modify_CheckupsVaccines_Info '"+ _empCode+"',"+_vaccineId+",'"+rdpExeDate.Value.ToString("yyyy-MM-dd")+"',"+_freqDays+",'"+GlobalUsage.Login_id+"','Merge','out'";
                GlobalUsage.hr_proxy.QueryExecute(qry,"exhrd");
                getEmployeeVaccineInfo();
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }


        private void getEmployeeVaccineInfo()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "VaccinationInfo", _empCode, "", "");
                cmbSelectProcess.Items.Clear();
                cmbSelectProcess.Items.AddRange(Config.FillWinCombo(ds.Tables[0]));

                rgv_VacInfo.DataSource = ds.Tables[1];
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void rbtn_excel_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\HrReports";
                if (!System.IO.Directory.Exists(mydocpath))
                {
                    System.IO.Directory.CreateDirectory(mydocpath);
                }
                string fileName = mydocpath + "\\immunisationAndTraining.xlsx";
                Telerik.WinControls.Export.GridViewSpreadExport spreadExporter;

                spreadExporter = new Telerik.WinControls.Export.GridViewSpreadExport(rgvRegister);
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

        private void rgv_VacInfo_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                
                string qry = "update CheckupsVaccines_Info set isActive='N',disableBy='" + GlobalUsage.Login_id + "',disableDate=getdate() where autoid='" + e.Row.Cells["autoid"].Value.ToString() + "';";
                GlobalUsage.hr_proxy.QueryExecute(qry, "exhrd");
                getEmployeeVaccineInfo();
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "VaccinationRegister", "", "", "");
                rgvRegister.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }
    }
}
