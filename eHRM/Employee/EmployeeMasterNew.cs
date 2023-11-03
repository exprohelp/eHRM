using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.Employee
{
    public partial class EmployeeMasterNew : Telerik.WinControls.UI.RadForm
    {
        string _result = "";
        string _emp_code = string.Empty;
        string _unit_code = string.Empty;
        string _comp_code = string.Empty; string _esiFlag = string.Empty; string _pfFlag = string.Empty;
        string _eliteFlag = string.Empty;
        public EmployeeMasterNew()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            Rectangle rec = Screen.PrimaryScreen.WorkingArea;
            int size = (rec.Size.Width - this.Width) / 2;
            this.Location = new System.Drawing.Point(size, 155);
            _emp_code = "New";
            dtDOJ.Value = DateTime.Today;
            // dtDOJ.MinDate = DateTime.Today.AddDays(-15);

            ddlEmpType.SelectedIndex = 0;
            GlobalUsage.hr_proxy = new HumanResource.Staff_ManagementSoapClient();
            FillPrimaryInfo();
        }
        private void FillPrimaryInfo()
        {
            try
            {
                ddlEmpType.SelectedIndex = 0;
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "", "PrimaryInfo", "-", "-", "-");
                dgPostedAt.DataSource = ds.Tables[0];
                ddlDesignation.Items.AddRange(Config.FillTelrikCombo(ds.Tables[1]));
                ddlDesignation.SelectedIndex = 0;
                ddlEmpStatus.Items.AddRange(Config.FillTelrikCombo(ds.Tables[2]));
                ddlEmpStatus.SelectedIndex = 0;
                ddlSection.Items.AddRange(Config.FillTelrikCombo(ds.Tables[3]));
                ddlSection.SelectedIndex = 0;
                ddlDivision.Items.AddRange(Config.FillTelrikCombo(ds.Tables[5]));
                ddlDivision.SelectedIndex = 0;

                ddlLocAdd_State.SelectedIndexChanged -= new Telerik.WinControls.UI.Data.PositionChangedEventHandler(ddlLocAdd_State_SelectedIndexChanged);
                ddlLocAdd_State.Items.AddRange(Config.FillTelrikCombo(ds.Tables[4]));
                ddlLocAdd_State.SelectedIndex = 0;
                ddlLocAdd_State.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(ddlLocAdd_State_SelectedIndexChanged);
                ddlPerma_State.SelectedIndexChanged -= new Telerik.WinControls.UI.Data.PositionChangedEventHandler(ddlPerma_State_SelectedIndexChanged);
                ddlPerma_State.Items.AddRange(Config.FillTelrikCombo(ds.Tables[4]));
                ddlPerma_State.SelectedIndex = 0;
                ddlPerma_State.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(ddlPerma_State_SelectedIndexChanged);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void FillDistInfo(string stateCode, string cn_name)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string qry = "select Distt_name,D=Distt_name from  Disttinfo where state_code=" + stateCode + " order by distt_name;";
                DataSet ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHrd");
                if (cn_name == "Local")
                {
                    ddlLocAdd_District.Items.Clear();
                    ddlLocAdd_District.Items.AddRange(Config.FillTelrikCombo(ds.Tables[0]));
                    ddlLocAdd_District.SelectedIndex = 0;
                }
                else
                {
                    ddlPerma_Dist.Items.Clear();
                    ddlPerma_Dist.Items.AddRange(Config.FillTelrikCombo(ds.Tables[0]));
                    ddlPerma_Dist.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void ddlLocAdd_State_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            FillDistInfo(ddlLocAdd_State.SelectedValue.ToString(), "Local");
        }

        private void ddlPerma_State_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            FillDistInfo(ddlPerma_State.SelectedValue.ToString(), "Permanent");
        }

        private void btnSameAsLocal_Click(object sender, EventArgs e)
        {
            ddlPerma_State.Text = ddlLocAdd_State.Text;
            ddlPerma_Dist.Text = ddlLocAdd_District.Text;
            txtPerma_Add1.Text = txtLocAdd1.Text;
            txtPerma_Add2.Text = txtLocAdd2.Text;
        }
        private void ddlEmpType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (ddlEmpType.Text == "SPCA")
            {

                txtTax.Enabled = true;
                grpESI.Enabled = false;
                grpPF.Enabled = false;
                chkESIApplied.Enabled = false;
                chkPfApplied.Enabled = false;

                rbServ_No.Enabled = false;
                rbServ_Yes.Enabled = false;

                txtBonus.Enabled = false;

            }
            else
            {
                grpESI.Enabled = true;
                rbServ_No.Enabled = true;
                rbServ_Yes.Enabled = true;
                chkESIApplied.Enabled = true;
                chkPfApplied.Enabled = true;



                txtBonus.Enabled = true;

                txtTax.Enabled = true;
            }
        }
        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            InsertOrEdit("Insert");
        }
        private void InsertOrEdit(string logic)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //First Page Variables
                string EmpType = ddlEmpType.Text;
                string EmpName = txtemp_name.Text;
                string Father_Name = txtEmp_FName.Text;
                string dob = txtDOB.Text.Split('-')[2] + "/" + txtDOB.Text.Split('-')[1] + "/" + txtDOB.Text.Split('-')[0];
                string MartialStatus = ddlMStatus.Text;
                string sex = ddlSex.Text.Substring(0, 1);
                string BloodGroup = ddlBloodGroup.Text;
                string ContactNo = txtContactNumber.Text;
                string EmailId = txtEmailId.Text;
                string loc_State = ddlLocAdd_State.Text;
                string loc_dist = ddlLocAdd_District.Text;
                string loc_add1 = txtLocAdd1.Text;
                string loc_add2 = txtLocAdd2.Text;
                string per_State = ddlPerma_State.Text;
                string per_dist = ddlPerma_Dist.Text;
                string per_add1 = txtPerma_Add1.Text;
                string per_add2 = txtPerma_Add2.Text;
                string qualification = txtQualification.Text;
                string Experience = txtExperience.Text;
                string pan_no = txtPAN.Text;

                //Second Page Variables
                string interviewMode = ddlMode.Text;
                string doj = dtDOJ.Value.ToString("yyyy/MM/dd");
                string status = ddlEmpStatus.Text;
                string designation = ddlDesignation.Text;
                string weeklyoff = ddlweeklyOff.Text;
                string hrRemark = txtHRemark.Text;
                string section = ddlSection.Text;
                //Third Page Variables
                decimal bp = Convert.ToDecimal(txtBasicPart.Text);
                decimal hr = Convert.ToDecimal(txtHRa.Text);
                decimal pb = Convert.ToDecimal(txtPerBonus.Text);
                decimal ecb = Convert.ToDecimal(txtElite.Text);
                decimal bo = Convert.ToDecimal(txtBonus.Text);
                decimal TaxDed = Convert.ToDecimal(txtTax.Text);
                string serv_charge_flag = "N";
                if (rbServ_Yes.Checked)
                    serv_charge_flag = "Y";
                _esiFlag = "N";
                //Fourth Page Variables
                if (chkESIApplied.Checked)
                    _esiFlag = "N";
                if (chkPfApplied.Checked)
                    _pfFlag = "Y";
                string cashpay_flag = "N";
                if (rbCashYes.Checked)
                    cashpay_flag = "Y";
                #region VALIDATION BLOCKS
                if (ddlDivision.Text.Length <= 6)
                { MessageBox.Show("Select Division Name"); return; }
                if (EmpName.Trim().Length <= 2)
                { MessageBox.Show("Employee Name should be proper"); return; }
                if (ContactNo.Trim().Length <= 2)
                { MessageBox.Show("Contact Number should be proper"); return; }
                if (loc_State == "Select")
                { MessageBox.Show("Please select state in local address"); return; }
                if (loc_dist == "Select")
                { MessageBox.Show("Please select district in local address"); return; }
                if (loc_add1.Trim().Length <= 5)
                { MessageBox.Show("Input proper local address Line 1"); return; }
                if (qualification.Trim().Length <= 1)
                { MessageBox.Show("write proper qualification"); return; }
                if (status == "Select")
                { MessageBox.Show("Please select Status "); return; }
                if (designation == "Select")
                { MessageBox.Show("Please select designation "); return; }
                if (_unit_code.Length <= 2)
                { MessageBox.Show("Please Lock Unit Name  "); return; }
                if (bp == 0)
                { MessageBox.Show("Please input salary  "); return; }
                #endregion
                string sp_flag = string.Empty; string leaveCalFlag = string.Empty; string elite_flag = string.Empty;
                sp_flag = "N"; leaveCalFlag = "N"; elite_flag = "N";
                if (chkSinglePunching.Checked)
                    sp_flag = "Y";
                else if (chkSinglePunchBeforeTime.Checked)
                    sp_flag = "B";
                //if (chkEliteClub.Checked)
                //    elite_flag = "Y";
                //else
                //    elite_flag = "N";


                if (chkAttBaseSalary.Checked)
                    leaveCalFlag = "Y";

                _result = GlobalUsage.hr_proxy.Insert_Modify_EmpDetailNew(out _result, EmpType, _emp_code, _comp_code, _unit_code, status, "N", txtESI_no.Text,
                    _pfFlag, txtpfidno.Text, EmpName, sex, MartialStatus, Father_Name, dob, qualification, Experience, designation, loc_State, loc_dist, loc_add1, loc_add2,
                    per_State, per_dist, per_add1, per_add2, interviewMode, doj, bp, hr, pb, ecb, bo, TaxDed, hrRemark, "chandan", serv_charge_flag, EmailId,
                    logic, ContactNo, BloodGroup, weeklyoff, ddlDivision.Text, ddlSection.SelectedValue.ToString(), cashpay_flag, "Y", txtPAN.Text, GlobalUsage.Login_id,
                txtpfUnNo.Text, rtb_perNumber.Text, elite_flag, sp_flag, txtAcCode.Text, leaveCalFlag, txtAAdhar_no.Text, rtbHusbandName.Text);
                if (_result.Contains("Success"))
                { btnNewEmployee.Enabled = false; ClearFields(); }
                MessageBox.Show(_result);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void GetDetail()
        {
            try
            {
                DateTime d = System.DateTime.Now;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "", "EmpInfoWithAddress", _emp_code, "-", "-");
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    btnEditDetail.Enabled = true;
                    btnNewEmployee.Enabled = false;
                    DataRow dr = ds.Tables[0].Rows[0];
                    _comp_code = dr["comp_code"].ToString();
                    _unit_code = dr["unit_code"].ToString();
                    txtemp_name.Text = dr["emp_name"].ToString();
                    ddlEmpStatus.Text = dr["Status"].ToString();
                    //if (dr["Esi_Applied"].ToString().ToUpper() == "Y")
                    //    chkESIApplied.Checked = true;
                    //else
                    //    chkESIApplied.Checked = false;
                    if (dr["Pf_Applied"].ToString().ToUpper() == "Y")
                        chkPfApplied.Checked = true;
                    else
                        chkPfApplied.Checked = false;
                    if (dr["cashpay_flag"].ToString().ToUpper() == "Y")
                        rbCashYes.Checked = true;
                    else
                        rbCashYes.Checked = false;

                    if (dr["cal_leave_flag"].ToString().ToUpper() == "Y")
                        chkAttBaseSalary.Checked = true;
                    else
                        chkAttBaseSalary.Checked = false;

                    if (dr["sp_flag"].ToString().ToUpper() == "Y")
                        chkSinglePunching.Checked = true;
                    else
                        chkSinglePunching.Checked = false;


                    txtAcCode.Text = dr["ac_code"].ToString();
                    rtb_perNumber.Text = dr["pvtMobileNo"].ToString();
                    ddlSex.Text = dr["Sex"].ToString();
                    ddlMStatus.Text = dr["Marital_Status"].ToString();
                    txtEmp_FName.Text = dr["Emp_F_Name"].ToString();
                    txtDOB.Text = Convert.ToDateTime(dr["D_O_B"]).ToString("dd-MM-yyyy");
                    if (Convert.ToDateTime(dr["res_date"]).Year == 1900)
                        txtResignDate.Text = "N/A";
                    else
                        txtResignDate.Text = Convert.ToDateTime(dr["res_date"]).ToString("dd-MM-yyyy");

                    txtpfidno.Text = dr["pf_id_no"].ToString();
                    txtpfUnNo.Text = dr["un_no"].ToString();
                    //txtESI_no.Text = dr["esi_no"].ToString();
                    txtDOB.Text = Convert.ToDateTime(dr["D_O_B"]).ToString("dd-MM-yyyy");
                    txtQualification.Text = dr["Qualification"].ToString();
                    txtExperience.Text = dr["Experience"].ToString();
                    ddlDesignation.Text = dr["Designation"].ToString();
                    ddlMode.Text = dr["Selection_Mode"].ToString();
                    ddlDivision.Text = dr["division"].ToString();
                    txtPAN.Text = dr["pan_no"].ToString();
                    dtDOJ.Value = Convert.ToDateTime(dr["D_O_J"]);
                    rg_PostedAt.Text = dr["unit_name"].ToString();
                    rtbHusbandName.Text = dr["husband_name"].ToString();
                    if (dr["loc_state"].ToString() != "")
                        ddlLocAdd_State.Text = dr["loc_state"].ToString();
                    else
                        ddlLocAdd_State.Text = "Select";
                    if (dr["loc_district"].ToString() != "")
                        ddlLocAdd_District.Text = dr["loc_district"].ToString();
                    else
                        ddlLocAdd_District.Text = "Select";
                    txtLocAdd1.Text = dr["loc_add1"].ToString();
                    txtLocAdd2.Text = dr["loc_add2"].ToString();
                    if (dr["per_state"].ToString() != "")
                        ddlPerma_State.Text = dr["per_state"].ToString();
                    else
                        ddlPerma_State.Text = "Select";
                    if (dr["per_district"].ToString() != "")
                        ddlPerma_Dist.Text = dr["per_district"].ToString();
                    else
                        ddlPerma_Dist.Text = "Select";
                    txtPerma_Add1.Text = dr["per_add1"].ToString();
                    txtPerma_Add2.Text = dr["per_add2"].ToString();
                    txtHRemark.Text = dr["Ch_Remark"].ToString();

                    if (dr["servicetax_flag"].ToString() == "Y")
                        rbServ_Yes.Checked = true;
                    else
                        rbServ_Yes.Checked = false;
                    if (dr["cal_leave_flag"].ToString() == "Y")
                        lbl_cal_leave_flag.Text = "Salary calculation  by Attendance";
                    else
                        lbl_cal_leave_flag.Text = "Salary calculation without Attendance";
                    //if (dr["elite_flag"].ToString() == "Y")
                    //    chkEliteClub.Checked=true;
                    //else
                    //    chkEliteClub.Checked = false;

                    txtContactNumber.Text = dr["mobile_no"].ToString();
                    ddlBloodGroup.Text = dr["bloodgroup"].ToString();
                    ddlweeklyOff.Text = dr["WeeklyOff"].ToString();
                    ddlSection.SelectedValue = dr["sect_id"].ToString();
                    txtEmailId.Text = dr["eMail"].ToString();
                    txtBasicPart.Text = Convert.ToInt32(dr["bp"]).ToString("0");
                    txtHRa.Text = Convert.ToInt32(dr["Hr"]).ToString("0");
                    txtPerBonus.Text = Convert.ToInt32(dr["pb"]).ToString("0");
                    txtBonus.Text = Convert.ToInt32(dr["bo"]).ToString("0");
                    txtElite.Text = Convert.ToInt32(dr["ecb"]).ToString("0");
                    txtTax.Text = Convert.ToInt32(dr["tax_ded"]).ToString("0");
                    lblLedgerName.Text = dr["ledger_name"].ToString();
                    txtAAdhar_no.Text = dr["aadhar_no"].ToString();
                    txtAmount.Text = Convert.ToInt32(dr["totalpay"]).ToString("0");
                    //btnApplyPolicy.PerformClick();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void ClearFields()
        {
            btnEditDetail.Enabled = false;
            btnNewEmployee.Enabled = true;
            _comp_code = string.Empty;
            _unit_code = string.Empty;
            _emp_code = "New";
            txtemp_name.Text = string.Empty;
            ddlEmpStatus.Text = "Select";
            chkPfApplied.Checked = false;
            //chkESIApplied.Checked = false;
            ddlSex.Text = "Male";
            ddlMStatus.Text = "Married";
            txtEmp_FName.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtQualification.Text = string.Empty;
            txtExperience.Text = string.Empty;
            ddlDesignation.Text = "Select";
            ddlMode.Text = "Interview";
            dtDOJ.Value = Convert.ToDateTime(System.DateTime.Now);
            ddlSection.Text = "Select"; ;
            ddlLocAdd_State.Text = "Select";
            ddlLocAdd_District.Text = "Select";
            txtLocAdd1.Text = string.Empty;
            txtLocAdd2.Text = string.Empty;
            ddlPerma_State.Text = "Select";
            ddlPerma_Dist.Text = "Select";
            txtPerma_Add1.Text = string.Empty;
            txtPerma_Add2.Text = string.Empty;
            txtHRemark.Text = string.Empty;
            rbServ_Yes.Checked = false;
            lbl_cal_leave_flag.Text = string.Empty;
            txtContactNumber.Text = string.Empty;
            txtEmailId.Text = string.Empty;
            ddlBloodGroup.Text = "N/A";
            ddlweeklyOff.Text = "Sunday";
            ddlSection.Text = "Select";
            txtAcCode.Text = "";
            txtBasicPart.Text = "0";
            txtHRa.Text = "0";
            txtPerBonus.Text = "0";
            txtBonus.Text = "0";
            txtElite.Text = "0";
            txtTax.Text = "0";
            txtAAdhar_no.Text = "-";
            rtbHusbandName.Text = "";
            rg_PostedAt.Text = string.Empty;
            txtPAN.Text = string.Empty; rtb_perNumber.Text = ""; chkAttBaseSalary.Checked = false; chkSinglePunching.Checked = false;
        }
        private void btnEditDetail_Click(object sender, EventArgs e)
        {
            if (chkESIApplied.Checked == true && _esiFlag == "N")
            {
                RadMessageBox.Show("ESI Zone Issue. Check before Proceed.", "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }

            //if (!_emp_code.Contains(_comp_code) && !_emp_code.Contains("SPCA"))
            //{
            //    RadMessageBox.Show("Inter Company Issue. Check before Proceed.", "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info);
            //    return;
            //}

            InsertOrEdit("Update");
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime d = System.DateTime.Now;
                Cursor.Current = Cursors.WaitCursor;
                string logic = string.Empty;
                if (chkResign.Checked)
                    logic = "IR";
                else
                    logic = "NR";
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "EmpListForDutyShift2", logic, txtSearch.Text, "");
                dgEmpList.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void dgEmpList_CommandCellClick(object sender, EventArgs e)
        {


            ClearFields();
            _emp_code = dgEmpList.CurrentRow.Cells["emp_code"].Value.ToString();
            GetDetail();
            if (dgEmpList.CurrentRow.Cells["InJob"].Value.ToString().ToUpper() == "NO")
            {
                btnEditDetail.Enabled = false;
                btnApplyPolicy.Enabled = false;
            }
        }

        private void dgEmpList_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Cells["InJob"].Value.ToString().ToUpper() == "NO")
                e.RowElement.ForeColor = Color.Red;
            else
                e.RowElement.ForeColor = Color.DarkGreen;
        }


        private void dgPostedAt_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            _unit_code = dgPostedAt.CurrentRow.Cells["unit_code"].Value.ToString();
            _comp_code = dgPostedAt.CurrentRow.Cells["comp_code"].Value.ToString();
            rg_PostedAt.Text = dgPostedAt.CurrentRow.Cells["unit_name"].Value.ToString();
            //_esiFlag = dgPostedAt.CurrentRow.Cells["esi_flag"].Value.ToString();
            //if (_esiFlag == "Y")
            //    chkESIApplied.Checked = true;
            //else
            //    chkESIApplied.Checked = false;

        }

        private void MasterTemplate_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Cells["esi_flag"].Value.ToString() == "Y")
                e.RowElement.ForeColor = Color.Blue;
            else
                e.RowElement.ForeColor = Color.Red;

        }

        private void chkSinglePunching_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSinglePunching.Checked)
                chkSinglePunchBeforeTime.Checked = false;

        }

        private void chkSinglePunchBeforeTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSinglePunchBeforeTime.Checked)
                chkSinglePunching.Checked = false;

        }

        private void btnApplyPolicy_Click(object sender, EventArgs e)
        {
            if (ddlDesignation.Text.ToUpper() == "SELECT")
            {
                ddlDesignation.Focus(); return;
            }
            if (ddlEmpStatus.Text.ToUpper() == "SELECT")
            { ddlEmpStatus.Focus(); return; }
            if (ddlEmpType.Text.ToUpper() == "SELECT")
            {
                ddlEmpType.Focus(); return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _esiFlag = "N"; _pfFlag = "N"; _eliteFlag = "N";
                if (chkPfApplied.Checked) _pfFlag = "Y"; else _pfFlag = "N";
                //if (chkESIApplied.Checked) _esiFlag = "Y"; else _esiFlag = "N";
                //if (chkEliteClub.Checked) _eliteFlag = "Y"; else _eliteFlag = "N";
                string qry = string.Empty;
                if (_emp_code == "New")
                    qry = "execute [pPayStructureCalculator] '" + ddlEmpType.Text + "','" + _esiFlag + "','" + _pfFlag + "','" + _eliteFlag + "','" + ddlEmpStatus.Text + "','-'," + txtAmount.Text + ",'Y'";
                else
                    qry = "execute [pPayStructureCalculator] '" + _emp_code + "','" + _esiFlag + "','" + _pfFlag + "','" + _eliteFlag + "','" + ddlEmpStatus.Text + "','-'," + txtAmount.Text + ",'Y'";

                DataSet ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "exhrd");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    txtBasicPart.Text = Convert.ToInt32(dr["Basicpart"]).ToString("0");
                    txtElite.Text = Convert.ToInt32(dr["eliteClubBonus"]).ToString("0");
                    txtHRa.Text = Convert.ToInt32(dr["houseRent"]).ToString("0");
                    txtBonus.Text = Convert.ToInt32(dr["BonusPart"]).ToString("0");
                    txtPerBonus.Text = Convert.ToInt32(dr["performanceBonus"]).ToString("0");
                    txtAmount.Text = Convert.ToInt32(dr["Total"]).ToString("0");
                    txtesi.Text = Convert.ToInt32(dr["esiByComp"]).ToString("0");
                    txtpf.Text = Convert.ToInt32(dr["pfByComp"]).ToString("0");
                    txtCtoC.Text = Convert.ToInt32(dr["CTC"]).ToString("0");
                }
                else
                {
                    RadMessageBox.Show("Error In Structure Policy. Kindly Inform IT.", "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }




        private void btnCollapse_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

            if (btnCollapse.ToggleState.ToString() == "Off")
            {
                radSplitContainer1.SplitPanels[0].Collapsed = true;
            }
            else
            {
                radSplitContainer1.SplitPanels[0].Collapsed = false;
            }
            btnCollapse.Text = "Left Panel " + args.ToggleState.ToString();

        }

        private void chkPfApplied_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPfApplied.Checked)
                grpPF.Enabled = true;
            else
                grpPF.Enabled = false;

        }

        private void chkESIApplied_CheckedChanged(object sender, EventArgs e)
        {
            if (chkESIApplied.Checked)
            {
                grpESI.Enabled = true;
                txtESI_no.Enabled = true;
            }
            else
                grpESI.Enabled = false;
        }
    }
}
