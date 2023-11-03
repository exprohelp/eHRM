using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.increments
{
    public partial class incrementInfo : Telerik.WinControls.UI.RadForm
    {
        string _result = string.Empty;
        public incrementInfo()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string _qry = "[dbo].[pGetEmpIncrement] 'ALL','Accounts','" + dtp_Date.Value.ToString("yyyy/MM/dd") + "','"+cmbCompany.Text+"' ";
                DataSet ds = GlobalUsage.accounts_proxy.GetQueryResult(_qry, "exhrd");
                //dgIncrList.DataSource = new string[] { };
                dgIncrList.AutoGenerateColumns = false;
                dgIncrList.DataSource = ds.Tables[0];

                for (int i = 0; i < dgIncrList.ColumnCount; i++)
                {
                    dgIncrList.Columns[i].BestFit();
                }


            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }

        }

        private void dgIncrList_KeyUp(object sender, KeyEventArgs e)
        {
          
        }

        private void incrementInfo_Load(object sender, EventArgs e)
        {
            dtp_Date.Value = DateTime.Today;
        }

        private void btnExPortToXL_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\HrReports";
                if (!System.IO.Directory.Exists(mydocpath))
                {
                    System.IO.Directory.CreateDirectory(mydocpath);
                }
                string fileName = mydocpath + "\\IncrementRegister.xlsx";
                Telerik.WinControls.Export.GridViewSpreadExport spreadExporter;

                spreadExporter = new Telerik.WinControls.Export.GridViewSpreadExport(dgIncrList);
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
