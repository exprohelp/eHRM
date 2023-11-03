using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using Telerik.WinControls.UI;
using eHRM.Properties;
namespace eHRM.attendance
{
    public partial class AttCorrectionConfirmation : Telerik.WinControls.UI.RadForm
    {
        string _result = string.Empty;
        DataSet ds;
        public AttCorrectionConfirmation()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            try
            {
                string month = dtInputDate.Value.Year + "/" + Convert.ToDecimal(dtInputDate.Value.Month).ToString("00") + "/01"; 
                Cursor.Current = Cursors.WaitCursor;
                ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "AttCorrectionAppReport", "", month, "");
                gbBox.Enabled = true;
                var result = ds.Tables[0].AsEnumerable().Select(x => new 
                { 
                    emp_code=x.Field<string>("emp_code"),
                    emp_name = x.Field<string>("emp_name"),
                    status = x.Field<string>("status"),
                    remark = x.Field<string>("remark"),
                    proc_date = x.Field<string>("proc_date"),
                    proc_flag = x.Field<string>("proc_flag"),
                    Unit_Name = x.Field<string>("Unit_Name"),
               });
               dgGrid.DataSource =result.ToList();//To ds.Tables[0];
               int Total = ds.Tables[0].Rows.Count;
               int Pending = ds.Tables[0].AsEnumerable().Where(y => y.Field<string>("proc_date").Length < 2).Count();
               int Approved = Total - Pending;
               lblStatus.Text = " Total : " + Total.ToString() + "    Pending : " + Pending.ToString() + "    Approved : " + Approved.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void AttCorrectionConfirmation_Load(object sender, EventArgs e)
        {
            GlobalUsage.hr_proxy = new HumanResource.Staff_ManagementSoapClient();
            dtInputDate.Value = DateTime.Today;
            //dtInputDate.MinDate = System.DateTime.Today.AddMonths(-1);
        }

        private void rb_pending_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var result = ds.Tables[0].AsEnumerable().Select(x => new
            {
                emp_code = x.Field<string>("emp_code"),
                emp_name = x.Field<string>("emp_name"),
                status = x.Field<string>("status"),
                remark = x.Field<string>("remark"),
                proc_date = x.Field<string>("proc_date"),
                proc_flag = x.Field<string>("proc_flag"),
                Unit_Name = x.Field<string>("Unit_Name"),
            }).Where(y => y.proc_date.Length < 2);
            dgGrid.DataSource = result.ToList();
            Cursor.Current = Cursors.Default;
        }

        private void rb_approved_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var result = ds.Tables[0].AsEnumerable().Select(x => new
            {
                emp_code = x.Field<string>("emp_code"),
                emp_name = x.Field<string>("emp_name"),
                status = x.Field<string>("status"),
                remark = x.Field<string>("remark"),
                proc_date = x.Field<string>("proc_date"),
                proc_flag = x.Field<string>("proc_flag"),
                Unit_Name = x.Field<string>("Unit_Name"),
            }).Where(y => y.proc_date.Length > 2);
            dgGrid.DataSource = result.ToList();
            Cursor.Current = Cursors.Default;
        }

        private void btnXL_Click(object sender, EventArgs e)
        {
            try
            {

                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\HrReports";
                if(!System.IO.Directory.Exists(mydocpath))
                {
                    System.IO.Directory.CreateDirectory(mydocpath);
                }
                string fileName = mydocpath + "\\AttConfirmation.xls";
                Telerik.WinControls.UI.Export.ExportToExcelML exporter = new Telerik.WinControls.UI.Export.ExportToExcelML(this.dgGrid);
                exporter.ExportVisualSettings = true;
                exporter.RunExport(fileName);
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

        private void MasterTemplate_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Cells["proc_flag"].Value.ToString() == "Y")
                e.RowElement.ForeColor = Color.Green;
            else
                e.RowElement.ForeColor = Color.Black;
        }

        private void MasterTemplate_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string month = dtInputDate.Value.Year + "/" + Convert.ToDecimal(dtInputDate.Value.Month).ToString("00") + "/01"; 
                string str = "Insert_Modify_SalaryProcessStatus '" + dgGrid.CurrentRow.Cells["emp_code"].Value.ToString() + "','" + month + "','Done By HR Head','Y','" + GlobalUsage.Login_id + "','Insert','' ";
                GlobalUsage.hr_proxy.QueryExecute(str, "ExHrd");
                dgGrid.CurrentRow.Cells["proc_flag"].Value = "Y";
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void MasterTemplate_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.CellElement is GridCommandCellElement)
            {
                if(((GridCommandCellElement)e.CellElement).ColumnInfo.Name.ToString() == "cmd")
                {
                    ((GridCommandCellElement)e.CellElement).CommandButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
                    if (e.CellElement.RowInfo.Cells["proc_flag"].Value.ToString() == "N")
                    {
                        ((GridCommandCellElement)e.CellElement).CommandButton.Image = Resources.bullet_green_16;
                        ((GridCommandCellElement)e.CellElement).CommandButton.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                    }
                }
            }
        }
    }
}
