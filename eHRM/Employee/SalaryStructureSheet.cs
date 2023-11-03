using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Export;

namespace eHRM.Employee
{
    public partial class SalaryStructureSheet : Telerik.WinControls.UI.RadForm
    {
        public DataSet ds = new DataSet();

        public SalaryStructureSheet()
        {
            InitializeComponent();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void SalaryStructureSheet_Load(object sender, EventArgs e)
        {
        }

        public void BindUnits()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string qry = "execute pMeetingReport '','Units'";
                DataSet ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHrd");
                ddlunits.Items.AddRange(GlobalUsage.FillTelrikCombo(ds.Tables[0]));
                ddlunits.SelectedIndex = 0;
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        public void GetData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string qry = "execute pMeetingReport '" + ddlunits.SelectedValue.ToString() + "','SalaryStructure'";
                ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHrd");
                grddata.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {


            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\HrReports";
                if (!System.IO.Directory.Exists(mydocpath))
                {
                    System.IO.Directory.CreateDirectory(mydocpath);
                }
                if (!System.IO.Directory.Exists(mydocpath))
                {
                    System.IO.Directory.CreateDirectory(mydocpath);
                }
                string exportFile = mydocpath + "\\MeetingReport.xlsx";


                GridViewSpreadExport spreadExporter = new GridViewSpreadExport(this.grddata);
                SpreadExportRenderer exportRenderer = new SpreadExportRenderer();
                spreadExporter.RunExport(exportFile, exportRenderer);


            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            BindUnits();
        }
    }
}
