using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace eHRM.attendance
{
    public partial class Att_correction : Telerik.WinControls.UI.RadForm
    {
        string _result = string.Empty;
        string _emp_code = string.Empty;
        public Att_correction()
        {
            InitializeComponent();
        }
        private void DutyShiftManagement_Load(object sender, EventArgs e)
        {
            dtInputDate.MinDate=System.DateTime.Today.AddMonths(-1);
            dtInputDate.Value = System.DateTime.Today;
            GlobalUsage.hr_proxy = new HumanResource.Staff_ManagementSoapClient();
          
            Rectangle rec = Screen.PrimaryScreen.WorkingArea;
            int size = (rec.Size.Width - this.Width) / 2;
            this.Location = new System.Drawing.Point(size, 155);
         
            AttReqInfo("AttCorrReqForHR");
        }

        private void AttReqInfo(string logic)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", logic, "",dtInputDate.Value.ToString("yyyy/MM/dd"), "");
                dgAttReq.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void Salary_AttendanceDetail(string date)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "AttendanceDetail", _emp_code, date, "");
                dgAttInfo.DataSource = ds.Tables[0];
                GridViewTemplate childTemplate = dgAttInfo.Templates[0];
                childTemplate.HierarchyDataProvider = new GridViewEventDataProvider(childTemplate);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void dgAttInfo_RowSourceNeeded(object sender, Telerik.WinControls.UI.GridViewRowSourceNeededEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string date = Convert.ToDateTime(e.ParentRow.Cells["att_date"].Value).ToString("yyyy/MM/dd");
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "AttendanceLog", _emp_code,date, "");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    GridViewRowInfo row = e.Template.Rows.NewRow();
                    row.Cells["att_date"].Value = dr["att_date"].ToString();
                    row.Cells["inOut"].Value = dr["inOut"].ToString();
                    e.SourceCollection.Add(row);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void ShiftInformation()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "DutyShiftListofEmployee", _emp_code, "", "");
                dgShift.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void radPageView1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (radPageView1.SelectedPage.Text == "Duty Shift Information")
            {
                ShiftInformation();
            }
        }
        private void dgAttReq_Click(object sender, EventArgs e)
        {
            if (dgAttReq.CurrentRow != null && dgAttReq.CurrentRow.Cells["reason"].Value!=null)
            {
                txtEmpRemark.Text =dgAttReq.CurrentRow.Cells["reason"].Value.ToString();
                txtHRRemark.Text=dgAttReq.CurrentRow.Cells["hr_remark"].Value.ToString();
            }
        }
        private void dgAttReq_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Cells["hr_flag"].Value.ToString()=="Y")
                e.RowElement.ForeColor = Color.Green;
            else if (e.RowElement.RowInfo.Cells["hr_flag"].Value.ToString()== "X")
                e.RowElement.ForeColor = Color.Red;
            else
                e.RowElement.ForeColor = Color.Black;
        }
        private void rb_pending_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void GetData()
        {
            if (rb_pending.Checked)
            { AttReqInfo("AttCorrReqForHR"); }
            else
            { AttReqInfo("ReqForHRCancelledAndApp"); }
        }
        private void dgAttReq_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            GridCommandCellElement el = (GridCommandCellElement)sender;
            _emp_code = e.Row.Cells["emp_code"].Value.ToString();
            if (el.ColumnInfo.HeaderText == "A")
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (rb_pending.Checked)
                    {
                        string[] t = dgAttReq.CurrentRow.Cells["att_date"].Value.ToString().Split('-');
                        string date = t[2] + "-" + t[1] + "-" + t[0];
                       _result = GlobalUsage.hr_proxy.ApplyAttRequestOfEmployee(_emp_code, date, "Approve by HR ", GlobalUsage.Login_id, "HR");
                        if(_result.Contains("Success"))
                        {
                           dgAttReq.CurrentRow.Cells["hr_flag"].Value = "Y";
                        }
                        else
                        {
                            MessageBox.Show(_result, "ExPro Help", MessageBoxButtons.OK);
                        }
                    }
                    else
                    { MessageBox.Show("Correction possible from pending option only.", "ExPro Help", MessageBoxButtons.OK); }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { Cursor.Current = Cursors.Default; }
            }
            else
            {
               // _emp_code = dgAttReq.CurrentRow.Cells["emp_code"].Value.ToString();
                string[] t = dgAttReq.CurrentRow.Cells["att_date"].Value.ToString().Split('-');
                Salary_AttendanceDetail(t[2] + "/" + t[1] + "/" + t[0]);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(txtHRRemark.Text.Trim().ToString().Length > 1)
            {
               string qry = "update AttCorrectionReq set hr_flag='X',hr_remark='"+txtHRRemark.Text+"',hr_login='" + GlobalUsage.Login_id + "' where auto_id=" + dgAttReq.CurrentRow.Cells["auto_id"].Value + "  and hr_flag='N' ";
               _result = GlobalUsage.hr_proxy.QueryExecute(qry, "ExHrd");
               if (_result.Contains("Success"))
               {
                   dgAttReq.CurrentRow.Delete();
                   MessageBox.Show("Request is Cancelled ", "ExPro Help", MessageBoxButtons.OK);
               }
               else
               { MessageBox.Show("Either Approved or cancelled", "ExPro Help", MessageBoxButtons.OK); }
            }
            else
            { MessageBox.Show("HR Remark is mandatory", "ExPro Help", MessageBoxButtons.OK); } 
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            GetData();
        }

    }
}
