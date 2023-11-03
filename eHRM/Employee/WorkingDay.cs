using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM
{
    public partial class WorkingDay : Telerik.WinControls.UI.RadForm
    {
        string _result = string.Empty;DataSet _ds = new DataSet();
        public WorkingDay()
        {
            InitializeComponent();
        }

        private void WorkingDay_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ddlemployee.Items.Clear();
                _ds = GlobalUsage.accounts_proxy.HR_Queries(out _result, "", "SearchEmployee", txtsearchemp.Text.Trim(), "", "");
                ddlemployee.Items.AddRange(GlobalUsage.FillTelrikCombo(_ds.Tables[0]));
                ddlemployee.SelectedIndex = 0;
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnaddwd_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string result = GlobalUsage.hr_proxy.Insert_Modify_WeekDayConfig(ddlemployee.SelectedValue.ToString(), ddlweekday.SelectedItem.Text, Convert.ToDecimal(ddlvalue.SelectedItem.Text), "", "Insert");
                RadMessageBox.Show(result, "Expro Help", MessageBoxButtons.OK, RadMessageIcon.Info);
                BindData();
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }

        }
        public void BindData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                rdgrd.DataSource = null;
                _ds = GlobalUsage.accounts_proxy.HR_Queries(out _result, "", "WeekDay", "", "", "");
                rdgrd.DataSource = _ds.Tables[0];
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void rdgrd_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string emp_code = rdgrd.CurrentRow.Cells["emp_code"].Value.ToString();

            Disable(emp_code);
            BindData();

        }
        public void Disable(string empcode)
        {
            try
            {
                rdgrd.DataSource = null;
                string result = GlobalUsage.hr_proxy.Insert_Modify_WeekDayConfig(empcode, "", Convert.ToDecimal(0), "", "Disable");
                RadMessageBox.Show(result, "Expro Help", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }
    }
}
