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
    public partial class Att_SalaryDetail : Telerik.WinControls.UI.RadForm
    {
        string _result = string.Empty;
        string _emp_code = string.Empty;
        string[] StatusList = {"Present", "Absent", "Leave","Off","Half Day"};
        public Att_SalaryDetail()
        {
            InitializeComponent();
        }
        private void PopulateStatusList()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Status",typeof(string));
                foreach (string s in StatusList)
                {
                    DataRow dr = dt.NewRow();
                    dr["Status"] = s;
                    dt.Rows.Add(dr);
                }
                Cursor.Current = Cursors.WaitCursor;
                Telerik.WinControls.UI.GridViewComboBoxColumn reportsColumn = ((Telerik.WinControls.UI.GridViewComboBoxColumn)dgAttInfo.Columns[2]);
                reportsColumn.Width = 65;
                reportsColumn.AllowFiltering = false;
                reportsColumn.ValueMember = "Status";
                reportsColumn.DisplayMember = "Status";
                reportsColumn.DataSource = dt; ;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void DutyShiftManagement_Load(object sender, EventArgs e)
        {
            try
            {

                ddlStatus.SelectedIndex = 0;
                Rectangle rec = Screen.PrimaryScreen.WorkingArea;
                int size = (rec.Size.Width - this.Width) / 2;
                this.Location = new System.Drawing.Point(size, 155);
                dtInputDate.Value = DateTime.Today;  
                dtShiftDate.Value = System.DateTime.Now;
                DateTime d = System.DateTime.Now; ;
                dtFrom.Value = d;
                dtTo.Value = d;
                //dtInputDate.Value = new DateTime(d.Year, d.Month, 1).AddDays(-1);
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "EmpListForDutyShift", "", GlobalUsage.Login_id, GlobalUsage.Login_id);
                dgEmpList.DataSource = ds.Tables[0];
                if (ds.Tables[1].Rows[0]["AlterRight"].ToString()=="Yes")
                {
                    pnlAtt.Enabled = true;
                    btnGetResignEmp.Visible = true;
                }

                PopulateStatusList();


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void dgEmpList_CommandCellClick(object sender, EventArgs e)
        {
           _emp_code = dgEmpList.CurrentRow.Cells["emp_code"].Value.ToString();
            Salary_AttendanceDetail();
        }
        private void Salary_AttendanceDetail()
        {
            DataRow dr;
            try
            {
                btnReprocessSalary.Enabled = false;
                GlobalUsage.hr_proxy = new HumanResource.Staff_ManagementSoapClient();
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "AttendanceDetail", _emp_code, dtInputDate.Value.ToString("yyyy/MM/dd"), "");
                dgAttInfo.DataSource = ds.Tables[0];
                GridViewTemplate childTemplate = dgAttInfo.Templates[0];
                childTemplate.HierarchyDataProvider = new GridViewEventDataProvider(childTemplate);
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    btnReprocessSalary.Enabled = true;
                
                    dr = ds.Tables[1].Rows[0];
                    #region Salary Display
                    if (dr["isRoster"].ToString().ToUpper() == "Y")
                        chkRoaster.Checked = true;
                    else
                        chkRoaster.Checked = false;

                    gb_info.Text = dgEmpList.CurrentRow.Cells["emp_name"].Value.ToString() + " [" + dgEmpList.CurrentRow.Cells["emp_code"].Value.ToString() + " ]" + "," + dr["designation"].ToString();
                    lblSalary.Text = Convert.ToDecimal(dr["bp"]).ToString("####");
                    lblHRA.Text = Convert.ToDecimal(dr["hr"]).ToString("####");
                    lbleLiteClub.Text = Convert.ToDecimal(dr["ecb"]).ToString("####");
                    lblPer_Bonus.Text = Convert.ToDecimal(dr["pb"]).ToString("####");
                    lblBonus.Text = Convert.ToDecimal(dr["bonus"]).ToString("####");
                    lblGross.Text = Convert.ToDecimal(dr["gross_salary"]).ToString("####");
                    lblESI.Text = Convert.ToDecimal(dr["esi"]).ToString("####");
                    lblPF.Text = Convert.ToDecimal(dr["pf"]).ToString("####");
                    lblTax.Text = Convert.ToDecimal(dr["tds"]).ToString("####");
                    lblLoanAdv.Text = (Convert.ToDecimal(dr["loan_adv"])).ToString("####");
                    lblConvAllow.Text = (Convert.ToDecimal(dr["ca"])).ToString("####");
                    lbltrusAmt.Text = Convert.ToDecimal(dr["csf_amt"]).ToString("####");
                    //lblInfo.Text = dr["pay_info"].ToString();
                    decimal deduct = Convert.ToDecimal(dr["deduction"]);// +Convert.ToDecimal(dr["pf"]) + Convert.ToDecimal(dr["tax_ded"]) + Convert.ToDecimal(dr["loan_adv"]) + Convert.ToDecimal(dr["advance"]);
                    lblDeduct.Text = deduct.ToString("####");
                    lblPayable.Text = Convert.ToDecimal(dr["payable"]).ToString("#####");
                    #endregion
                    #region Attendance Information
                    lblDays.Text = Convert.ToDecimal(dr["days"]).ToString("##.00");
                    lblOff.Text = Convert.ToDecimal(dr["offinmonth"]).ToString("##.00");
                    lblPayDays.Text = Convert.ToDecimal(dr["dayspayable"]).ToString("##.00");
                    lblOffTaken.Text = Convert.ToDecimal(dr["offtaken"]).ToString("##.00");
                    lbloffadj.Text = Convert.ToDecimal(dr["offadj"]).ToString("##.00");
                    lblLeave.Text = Convert.ToDecimal(dr["cl"]).ToString("##.00");
                    lblSpLeave.Text = Convert.ToDecimal(dr["el"]).ToString("##.00");
                    lblabsent.Text = Convert.ToDecimal(dr["absent"]).ToString("##.00");
                    lbllwp.Text = Convert.ToDecimal(dr["lwp"]).ToString("##.00");

                    #endregion
                }
                else
                {
                    #region Clear
                    lblDays.Text = " ";
                    lblOff.Text = " ";
                    lblPayDays.Text = " ";
                    lblSalary.Text = " ";
                    lblHRA.Text = " ";
                    lbleLiteClub.Text = " ";
                    lblGross.Text = " ";
                    lblESI.Text = " ";
                    lblPF.Text = " ";
                    lblTax.Text = " ";
                    lblLoanAdv.Text = " ";
                    lblDeduct.Text = " ";
                    lblPayable.Text = " ";
                    //lblInfo.Text = " ";
                    #endregion
                }
                dgAttSummary.DataSource = ds.Tables[2];
                dr = ds.Tables[3].Rows[0];
                if (dr["cal_leave_flag"].ToString().ToUpper() == "Y")
                    chkAttBaseSalary.Checked = true;
                else
                    chkAttBaseSalary.Checked = false;

                if (dr["sp_flag"].ToString().ToUpper() == "Y")
                    chkSinglePunching.Checked = true;
                else
                    chkSinglePunching.Checked = false;

                if (dr["sp_flag"].ToString().ToUpper() == "B")
                    chkSinglePunchBeforeTime.Checked = true;
                else
                    chkSinglePunchBeforeTime.Checked = false;

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

        private void btnReprocessSalary_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string qry = "execute pTransfer_SalaryForMonth '" + dtInputDate.Value.ToString("yyyy-MM-dd") + "','" + _emp_code + "','" + GlobalUsage.Login_id + "';";
                GlobalUsage.hr_proxy.QueryExecute(qry, "ExHrd");
                Salary_AttendanceDetail();
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
                Salary_AttendanceDetail();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
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

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtInshift.Text.Length == 8 && txtOutShift.Text.Length == 8)
                {
                    _result = GlobalUsage.hr_proxy.Insert_Modify_dutyShift_Info(0, _emp_code, dtShiftDate.Value.ToString("yyyy/MM/dd"), txtInshift.Text, txtOutShift.Text, txtdutybreack.Text, GlobalUsage.Login_id, "Insert");
                    if (_result.Contains("Success"))
                    { ShiftInformation(); }
                    else
                    { MessageBox.Show(_result); }
                }
                else
                { MessageBox.Show("In shift or out shift is not in correct formate "); }
            }
            catch (Exception ex) { }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void dgShift_CommandCellClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtInshift.Text.Length == 8 && txtOutShift.Text.Length == 8)
                {
                    _result = GlobalUsage.hr_proxy.Insert_Modify_dutyShift_Info(Convert.ToInt32(dgShift.CurrentRow.Cells["auto_id"].Value), _emp_code, dtShiftDate.Value.ToString("yyyy/MM/dd"), txtInshift.Text, txtOutShift.Text, txtdutybreack.Text, GlobalUsage.Login_id, "Delete");
                    if (_result.Contains("Success"))
                    { ShiftInformation(); }
                    else
                    { MessageBox.Show(_result); }
                }
                else
                { MessageBox.Show("In shift or out shift is not in correct formate "); }
            }
            catch (Exception ex) { }
            finally { Cursor.Current = Cursors.Default; }
        }
        #region Shift CREATION
        private string InShift()
        {
            return ddlInHH.Text + ":" + ddlInMM.Text + " " + ddlInAP.Text;
        }
        private string OutShift()
        {
            return ddlOutHH.Text + ":" + ddlOutMM.Text + " " + ddlOutAP.Text;
        }
        private void ddlInHH_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            txtInshift.Text = InShift();
        }
        private void ddlInMM_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            txtInshift.Text = InShift();
        }
        private void ddlInAP_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            txtInshift.Text = InShift();
        }
        private void ddlOutHH_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            txtOutShift.Text = OutShift();
        }
        private void ddlOutMM_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            txtOutShift.Text = OutShift();
        }
        private void ddlOutAP_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            txtOutShift.Text = OutShift();
        }
        #endregion

        private void radPageView1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (radPageView1.SelectedPage.Text == "Duty Shift Information")
            {
                ShiftInformation();
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            _result = GlobalUsage.hr_proxy.QueryExecute("update empdetail set netpassword= concat(left(replace(upper(emp_name),' ',''),4),format(d_o_b,'MMyy'))  where emp_code='" + _emp_code + "'  ", "ExHrd");
            MessageBox.Show(_result);     
        }
        private void dgAttInfo_CommandCellClick(object sender, EventArgs e)
        {
            try
            {
               string date=Convert.ToDateTime( dgAttInfo.CurrentRow.Cells["att_date"].Value).ToString("yyyy-MM-dd");
               string paremeter = _emp_code + "$" + dgAttInfo.CurrentRow.Cells["Status"].Value.ToString() + "$" + date;
               MessageBox.Show(GlobalUsage.hr_proxy.AttendanceMarkingByDate(paremeter, GlobalUsage.Login_id));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

      
        private void dgEmpList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            _emp_code = dgEmpList.CurrentRow.Cells["emp_code"].Value.ToString();
            Salary_AttendanceDetail();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtRemark.Text.Trim().Length >2)
                {
                    _result = GlobalUsage.hr_proxy.HRAttendanceMarking(GlobalUsage.Unit_id, _emp_code, dtFrom.Value.ToString("yyyy/MM/dd"), dtTo.Value.ToString("yyyy/MM/dd"), ddlStatus.Text, txtRemark.Text, GlobalUsage.Login_id, "Y", "", "Insert");
                    if (_result.Contains("Success"))
                    {
                        Salary_AttendanceDetail();
                    }
                    else
                    {
                        MessageBox.Show(_result);
                    }
                }
                else
                { MessageBox.Show("Remark is mandatory"); }
            }
            catch (Exception ex){MessageBox.Show(ex.Message);}
            finally{Cursor.Current = Cursors.Default;}
        }

        private void btnGetResignEmp_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "ResignedList", "", "", "");
            dgEmpList.DataSource = ds.Tables[0];
            Cursor.Current = Cursors.Default;
        }

        private void dtFrom_Leave(object sender, EventArgs e)
        {
            dtTo.MinDate = dtFrom.Value;
        }

        private void btnSetOff_Click(object sender, EventArgs e)
        {
            if(ddlweeklyOff.Text.Length==0)
            {
                MessageBox.Show("Select Weekly Off Day");
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GlobalUsage.hr_proxy.QueryExecute("update empdetail set weeklyoff='"+ddlweeklyOff.Text+"',updatedby='"+GlobalUsage.Login_id+"',updatedFrom='WeeklyOffsetting' where emp_code='"+_emp_code+"'", "exhrd");
            }
            catch (Exception ex) { }
            finally { Cursor.Current = Cursors.Default; }
        }

    }
}
