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
    public partial class RosterMaster : Telerik.WinControls.UI.RadForm
    {
        string _result = string.Empty;
        string _emp_code = string.Empty;
        string[] StatusList = {"Present", "Absent", "Leave","Off","Half Day"};
        public RosterMaster()
        {
            InitializeComponent();
        }
        private void DutyShiftManagement_Load(object sender, EventArgs e)
        {
            try
            {
                btnEnableRoster.Enabled = false;
                btnDisableRoster.Enabled = false;
                GlobalUsage.hr_proxy = new HumanResource.Staff_ManagementSoapClient();
                Rectangle rec = Screen.PrimaryScreen.WorkingArea;
                int size = (rec.Size.Width - this.Width) / 2;
                this.Location = new System.Drawing.Point(size, 155);
                dtInputDate.Value = DateTime.Today;  
                dtShiftDate.Value = System.DateTime.Now;
                DateTime d = System.DateTime.Now; ;
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "EmpListForRoster", "", "", "");
                dgEmpList.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void btnReprocessAtt_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GlobalUsage.hr_proxy.QueryExecute("execute [dbo].[p_Ins_Att_ProcessALL_OFMonth] " + dtInputDate.Value.Month + "," + dtInputDate.Value.Year + ",'" + _emp_code + "' ", "ExHrd");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void ShiftInformation(string empcode)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "DutyShiftListofEmployee", empcode, "", "");
                dgShift.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            _result = GlobalUsage.hr_proxy.QueryExecute("update empdetail set netpassword='123' where emp_code='" + _emp_code + "'  ", "ExHrd");
            MessageBox.Show(_result);     
        }

        private void dgEmpList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if(dgEmpList.CurrentRow.Cells["roster_flag"].Value.ToString() == "Y")
            { btnDisableRoster.Enabled = true;  btnEnableRoster.Enabled = false; }
            else
            { btnDisableRoster.Enabled = false; btnEnableRoster.Enabled = true; }
            FillRoster();
        }

        private void FillRoster()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _emp_code = dgEmpList.CurrentRow.Cells["emp_code"].Value.ToString();
                string qry = "execute pRoster_Queries '" + _emp_code + "'," + dtInputDate.Value.Month + "," + dtInputDate.Value.Year + ",'SingleEmployeeRosterForHR' ";
                DataSet ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHrd");
                dgRoster.DataSource = ds.Tables[0];
                ShiftInformation(_emp_code);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnEnableRoster_Click(object sender, EventArgs e)
        {   
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _result=GlobalUsage.hr_proxy.Roster_InsertUpdate(_emp_code, dtInputDate.Value.ToString("yyyy/MM/dd"), "", "", GlobalUsage.Login_id, "MarkEmployeeInRoster");
                Cursor.Current = Cursors.Default;
                MessageBox.Show(_result);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _result = GlobalUsage.hr_proxy.Roster_InsertUpdate(_emp_code, dtInputDate.Value.ToString("yyyy/MM/dd"), "", "", GlobalUsage.Login_id, "Single_Process");
                if(_result.Contains("Success"))
                {
                   FillRoster();
                }
                Cursor.Current = Cursors.Default;
                MessageBox.Show(_result);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDisableRoster_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _result = GlobalUsage.hr_proxy.Roster_InsertUpdate(_emp_code, dtInputDate.Value.ToString("yyyy/MM/dd"), "", "", GlobalUsage.Login_id, "DisableEmployeeFromRoster");
                Cursor.Current = Cursors.Default;
                MessageBox.Show(_result);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
      
    }
}
