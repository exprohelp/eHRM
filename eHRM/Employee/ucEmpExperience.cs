using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eHRM.Employee
{
    public partial class ucEmpExperience : UserControl
    {
        string _result = string.Empty; string _empCode = string.Empty;
        public ucEmpExperience()
        {
            InitializeComponent();
        }

        private void ucEmpExperience_Load(object sender, EventArgs e)
        {

        }

        private void rdpFrom_Leave(object sender, EventArgs e)
        {
            rdpTo.MinDate = rdpFrom.Value;
            rdpTo.Value = rdpFrom.Value;
        }

        private void btnLoadList_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime d = System.DateTime.Now;
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "EmpListForDutyShift", "", "", "");
                rgv_staff.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void rgv_staff_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                _empCode = e.Row.Cells["emp_code"].Value.ToString();
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "experienceInfo", e.Row.Cells["emp_code"].Value.ToString(), "", "");
                rgvExperience.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void rgvExperience_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                DateTime d = System.DateTime.Now;
                Cursor.Current = Cursors.WaitCursor;
                _result = "Update experience_Info set isActive='X',modifyby='"+GlobalUsage.Login_id+"',modifyDate=getdate() where auto_id="+e.Row.Cells["autoid"].Value.ToString();
                GlobalUsage.hr_proxy.QueryExecute(_result, "exhrd");
                rgvExperience.CurrentRow.Delete();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime d = System.DateTime.Now;
                Cursor.Current = Cursors.WaitCursor;
                _result = "execute Insert_Modify_experience_Info 0,'"+ _empCode + "','"+rdpFrom.Value.ToString("yyyy-MM-dd")+"','"+rdpTo.Value.ToString("yyyy-MM-dd")+"',";
                _result = _result + "'" + txtCompany.Text + "','" + textDescription.Text + "','Insert','" + GlobalUsage.Login_id + "','N/A'";
                GlobalUsage.hr_proxy.QueryExecute(_result, "exhrd");
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "experienceInfo", _empCode, "", "");
                rgvExperience.DataSource = ds.Tables[0];

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnGetRegister_Click(object sender, EventArgs e)
        {
            try
            {
               
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "experienceRegister", "-", "", "");
                rgvRegister.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnExPortXL_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\HrReports";
                if (!System.IO.Directory.Exists(mydocpath))
                {
                    System.IO.Directory.CreateDirectory(mydocpath);
                }
                string fileName = mydocpath + "\\ExperienceRegister.xlsx";
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
    }
}
