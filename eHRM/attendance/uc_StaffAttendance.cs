using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eHRM.attendance
{
    public partial class uc_StaffAttendance : UserControl
    {
        string _result = string.Empty; string _division = string.Empty;
        public uc_StaffAttendance(string division)
        {
            _division = division;
            InitializeComponent();
        }

        private void btn_ExSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = new DataSet();
              
                string qry="execute pMIS_AttendanceInfo  'HR','Attendance','"+dtpFrom.Value.ToString("yyyy/MM/dd")+"','"+dtpTo.Value.ToString("yyyy/MM/dd")+"','"+GlobalUsage.Login_id+"'";
                ds = GlobalUsage.accounts_proxy.GetQueryResult(qry, "exhrd");
                
                var att = ds.Tables[0].AsEnumerable().Select(o => new { 
                    unit_code=o.Field<string>("unit_code"),
                    emp_code=o.Field<string>("emp_code"),
                    att_date = o.Field<DateTime>("att_date") ,
                    InTime = o.Field<DateTime?>("InTime"),
                    OutTime = o.Field<DateTime?>("OutTime"),
                    WorkHrs=o.Field<decimal>("workhrs"),
                    wd = o.Field<decimal>("wd"),
                    status = o.Field<string>("status")

                });
                var emp = ds.Tables[1].AsEnumerable().Select(o => new
                {
                    emp_code = o.Field<string>("emp_code"),
                    emp_name = o.Field<string>("emp_name")
                });
                var unit = ds.Tables[2].AsEnumerable().Select(o => new
                {
                    unit_code = o.Field<string>("unit_code"),
                    unit_name = o.Field<string>("unit_name")
                });
//var query = product.Join(productcategory, p => p.Id, pc => pc.ProdID, (p, pc) => new {product = p, productcategory = pc})
//                   .Join(category, ppc => ppc.productcategory.CatId, c => c.Id, (ppc, c) => new { productproductcategory = ppc, category = c})

                //var query = emp.Join(att, em => em.emp_code, at => at.emp_code, (em, at) => new { emp = em, att = at })
                //                   .Join(unit, at => at.att.unit_code, u => u.unit_code, (at, u) => new { att = at, unit = u }).
                //                   Select(o => new
                //                   {
                //                       unit_id = o.unit.unit_code,
                //                       unit_name = o.unit.unit_name,
                //                       emp_code = o.att.att.emp_code,
                //                       emp_name = o.att.emp.emp_name,
                //                       att_date = o.att.att.att_date,
                //                       InTime = o.att.att.InTime,
                //                       OutTime = o.att.att.OutTime,
                //                       workhours = o.att.att.WorkHrs
                //                   }).ToList().OrderBy(o=>o.att_date);

                var d = from em in emp
    join at in att on em.emp_code equals at.emp_code
    join u in unit on  at.unit_code equals u.unit_code
    select new
    {
        unit_id = at.unit_code,
        unit_name = u.unit_name,
        emp_code = em.emp_code,
        emp_name = em.emp_name,
        att_date = at.att_date,
        InTime = at.InTime,
        OutTime = at.OutTime,
        workhours = at.WorkHrs,
        wd=at.wd,
        status=at.status
    };
                rgv_info.DataSource = d.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void uc_StaffAttendance_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
        }

        private void radGridView1_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (Convert.ToInt16(e.RowElement.RowInfo.Cells["Hours"].Value) == 0)
                e.RowElement.ForeColor = Color.Red;
            else
                e.RowElement.ForeColor = Color.Green;
        }

        private void btnXL_Click(object sender, EventArgs e)
        {
            try
            {

                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\HrReports";
                if (!System.IO.Directory.Exists(mydocpath))
                {
                    System.IO.Directory.CreateDirectory(mydocpath);
                }
                string fileName = mydocpath + "\\attendenceRegister.xls";
                Telerik.WinControls.UI.Export.ExportToExcelML exporter = new Telerik.WinControls.UI.Export.ExportToExcelML(this.rgv_info);
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
    }
}
