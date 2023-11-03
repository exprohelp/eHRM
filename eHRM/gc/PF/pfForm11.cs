using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Export;

namespace eHRM.gc.PF
{
    public partial class pfForm11 : Telerik.WinControls.UI.RadForm
    {
        DataSet _ds = new DataSet(); string _result = string.Empty;
        public pfForm11()
        {
            InitializeComponent();
            radDateTimePicker1.Value = DateTime.Today;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _ds = GlobalUsage.hr_proxy.GetQueryResult("execute [dbo].[pPF_From11] '" + cmbCompany.Text + "','ALL','" + radDateTimePicker1.Value.ToString("yyyy/MM/dd") + "','" + GlobalUsage.Login_id + "';", "exhrd");
                rgv_info.DataSource = _ds.Tables[0];

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }


        }

        private void btnXL_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (!System.IO.Directory.Exists(mydocpath))
                {
                    System.IO.Directory.CreateDirectory(mydocpath);
                }
                string exportFile = mydocpath + "\\pfForm11.xlsx";


                GridViewSpreadExport spreadExporter = new GridViewSpreadExport(this.rgv_info);
                SpreadExportRenderer exportRenderer = new SpreadExportRenderer();
                spreadExporter.RunExport(exportFile, exportRenderer);

                //using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                //{
                //    Telerik.WinControls.Export.GridViewSpreadExport exporter = new Telerik.WinControls.Export.GridViewSpreadExport(this.radGridView1);
                //    Telerik.WinControls.Export.SpreadExportRenderer renderer = new Telerik.WinControls.Export.SpreadExportRenderer();
                //    exporter.RunExport(ms, renderer);

                //    using (System.IO.FileStream fileStream = new System.IO.FileStream(exportFile, FileMode.Create, FileAccess.Write))
                //    {
                //        ms.WriteTo(fileStream);
                //    }
                //}

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
