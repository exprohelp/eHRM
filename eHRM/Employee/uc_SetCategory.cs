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
    public partial class uc_SetCategory : UserControl
    {
        DataSet _ds = new DataSet();string _result = string.Empty;
        public uc_SetCategory()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
               
                _ds = GlobalUsage.hr_proxy.HR_Queries(out _result,"-", "CategorySetting","-","-","-");
                rgv_employee.DataSource = _ds.Tables[0];
                PopulateStatusList();

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void PopulateStatusList()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                dt.Columns.Add("category", typeof(string));
                foreach (DataRow dr1 in _ds.Tables[1].Rows)
                {
                    DataRow dr = dt.NewRow();
                    dr["category"] = dr1["category"].ToString();
                    dt.Rows.Add(dr);
                }

                Telerik.WinControls.UI.GridViewComboBoxColumn categoryColumn = ((Telerik.WinControls.UI.GridViewComboBoxColumn)rgv_employee.Columns[4]);
                categoryColumn.Width = 150;
                categoryColumn.AllowFiltering = false;
                categoryColumn.ValueMember = "category";
                categoryColumn.DisplayMember = "category";
                categoryColumn.DataSource = dt; ;
               
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }

        }

        private void rgv_employee_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string qry = "update empdetail set category='"+e.Row.Cells["category"].Value.ToString()+"' where emp_code='"+e.Row.Cells["emp_code"].Value.ToString()+"'";
                _result = GlobalUsage.hr_proxy.QueryExecute(qry, "exhrd");
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }

        }
    }
}
