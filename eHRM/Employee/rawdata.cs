using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace eHRM.Employee
{
    public partial class rawdata : Telerik.WinControls.UI.RadForm
    {
        string _result = string.Empty;
        string _emp_code = string.Empty; DataSet _ds = new DataSet();
        public rawdata()
        {
            InitializeComponent();
        }

        private void rawdata_Load(object sender, EventArgs e)
        {
            Rectangle rec = Screen.PrimaryScreen.WorkingArea;
            int size = (rec.Size.Width - this.Width) / 2;
            this.Location = new System.Drawing.Point(size, 155);
            string qry = "select Column_name from Information_schema.columns where Table_name like 'v_empdetail'";
            _ds = new DataSet();
            _ds = GlobalUsage.accounts_proxy.GetQueryResult(qry, "exhrd");
            rclb_data.DataSource = _ds.Tables[0];
            rclb_data.DisplayMember = "Column_Name";
            rclb_data.ValueMember = "Column_Name";
        }

        private void rbtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string columns = string.Empty;
                foreach (ListViewDataItem item in this.rclb_data.CheckedItems)
                {
                    if (item.CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
                    {
                        columns += "["+item.Value.ToString()+"]"  + ",";
                    }
                }
                columns = columns.Substring(0, columns.Length - 1);
                string qry = string.Empty;
                if (cbInJob.Checked)
                    qry = "select " + columns + " from v_empdetail where injob='Yes'";
                else
                    qry = "select " + columns + " from v_empdetail where injob='No'";

                _ds = GlobalUsage.accounts_proxy.GetQueryResult(qry, "exhrd");
                rgv_data.DataSource = _ds.Tables[0];
                foreach (var col in rgv_data.Columns)
                {
                    col.BestFit();
                }
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void cbInJob_CheckedChanged(object sender, EventArgs e)
        {
            if (cbInJob.Checked)
                cbInJob.Text = "In Job";
            else
                cbInJob.Text = "Resign";
        }

        private void rbtn_excel_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                FolderBrowserDialog fdg = new FolderBrowserDialog();
                fdg.ShowDialog();
                //string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\HrReports";
                string mydocpath = fdg.SelectedPath;
                if (!System.IO.Directory.Exists(mydocpath))
                {
                    System.IO.Directory.CreateDirectory(mydocpath);
                }
                string fileName = mydocpath + "\\RawDataofStaff.xlsx";
                Telerik.WinControls.Export.GridViewSpreadExport spreadExporter;

                spreadExporter = new Telerik.WinControls.Export.GridViewSpreadExport(rgv_data);
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
