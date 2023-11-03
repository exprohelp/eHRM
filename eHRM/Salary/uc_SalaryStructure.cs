using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace eHRM.Salary
{
    public partial class uc_SalaryStructure : UserControl
    {
        string _result = string.Empty; DataSet _ds = new DataSet();string _reportOption = string.Empty;
        public uc_SalaryStructure()
        {
            InitializeComponent();

        }

        private void rbtn_Submit_Click(object sender, EventArgs e)
        {
            string qry = string.Empty;
            rgv_processChart.Columns.Clear();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _reportOption = ((AddValue)cmbReportType.SelectedItem).NewValue.ToString();
                qry = "execute pMiscellaneousReport '-','" + _reportOption + "','" + dtp_from.Value.ToString("yyyy/MM/dd") + "','" + dtpTo.Value.ToString("yyyy/MM/dd") + "','-','" + GlobalUsage.Login_id + "'";

                _ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "exhrd");
                rgv_processChart.DataSource = _ds.Tables[0];
                foreach (GridViewColumn column in rgv_processChart.Columns)
                {
                    column.BestFit();
                }


            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            finally { Cursor.Current = Cursors.Default; }
        }



        private void uc_SalaryStructure_Load(object sender, EventArgs e)
        {
            dtp_from.Value = DateTime.Today;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string qry = "select ReportName,Description from MiscellaneousReport";
                _ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "exhrd");
                cmbReportType.Items.AddRange(Config.FillWinCombo(_ds.Tables[0]));

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void rbtn_SalarySheet_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fdg = new FolderBrowserDialog();
                fdg.ShowDialog();
               
                string mydocpath = fdg.SelectedPath;
                if (!System.IO.Directory.Exists(mydocpath))
                {
                    System.IO.Directory.CreateDirectory(mydocpath);
                }
                string fileName = mydocpath + "\\"+ _reportOption + ".xlsx";
                Telerik.WinControls.Export.GridViewSpreadExport spreadExporter;

                spreadExporter = new Telerik.WinControls.Export.GridViewSpreadExport(rgv_processChart);
                spreadExporter.ExportVisualSettings = true;
                spreadExporter.ExportHierarchy = true;
                spreadExporter.ExportFormat = Telerik.WinControls.Export.SpreadExportFormat.Xlsx;
                spreadExporter.RunExport(fileName);

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

        private void rgv_processChart_Click(object sender, EventArgs e)
        {

        }

        private void dtp_from_Leave(object sender, EventArgs e)
        {
            dtpTo.Value = dtp_from.Value;
        }
    }
}
