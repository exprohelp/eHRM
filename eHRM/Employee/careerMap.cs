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
    public partial class careerMap : Telerik.WinControls.UI.RadForm
    {
        string _result = "";
        string _emp_code = string.Empty;
        string _unit_code = string.Empty;
        string _comp_code = string.Empty;
        public careerMap()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime d = System.DateTime.Now;
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "EmpListForDutyShift", "", "", "");
                dgEmpList.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void dgEmpList_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            _emp_code = dgEmpList.CurrentRow.Cells["emp_code"].Value.ToString();
            GetDetail();
        }
        private void GetDetail()
        {
            try
            {
                DateTime d = System.DateTime.Now;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "", "EmpInfoWithAddress", _emp_code, "-", "-");
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                   
                    DataRow dr = ds.Tables[0].Rows[0];
                    _comp_code = dr["comp_code"].ToString();
                    _unit_code = dr["unit_code"].ToString();
                    txtemp_name.Text = dr["emp_name"].ToString();
                    ddlEmpStatus.Text = dr["Status"].ToString();
                    if (dr["Esi_Applied"].ToString() == "Y")
                        rbESI_Yes.Checked = true;
                    else
                        rbESI_Yes.Checked = false;
                    if (dr["Pf_Applied"].ToString() == "Y")
                        rbPF_Yes.Checked = true;
                    else
                        rbPF_Yes.Checked = false;
                    if (dr["cashpay_flag"].ToString() == "Y")
                        rbCashYes.Checked = true;
                    else
                        rbCashYes.Checked = false;
                    ddlSex.Text = dr["Sex"].ToString();
                    ddlMStatus.Text = dr["Marital_Status"].ToString();
                    txtEmp_FName.Text = dr["Emp_F_Name"].ToString();
                    txtDOB.Text = Convert.ToDateTime(dr["D_O_B"]).ToString("dd-MM-yyyy");
                    txtQualification.Text = dr["Qualification"].ToString();
                    txtExperience.Text = dr["Experience"].ToString();
                    ddlDesignation.Text = dr["Designation"].ToString();
                    ddlMode.Text = dr["Selection_Mode"].ToString();
                    txtPAN.Text = dr["pan_no"].ToString();
                    dtDOJ.Value = Convert.ToDateTime(dr["D_O_J"]);
                    rg_PostedAt.Text = dr["unit_name"].ToString();
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
                    txtContactNumber.Text = dr["mobile_no"].ToString();
                    ddlBloodGroup.Text = dr["bloodgroup"].ToString();
                    ddlweeklyOff.Text = dr["WeeklyOff"].ToString();
                    ddlSection.SelectedValue = dr["sect_id"].ToString();

                    txtSalary.Text = Convert.ToDecimal(dr["Salary_Pf"]).ToString("0");
                    txtHRA.Text = Convert.ToDecimal(dr["Hra"]).ToString("0");
                    txtConv.Text = Convert.ToDecimal(dr["fixed_conv"]).ToString("0");
                    txtTelephone.Text = Convert.ToDecimal(dr["Tele_Allow"]).ToString("0");
                    txtTrvLimit.Text = Convert.ToDecimal(dr["trv_Limit"]).ToString("0");
                    txtTelLimit.Text = Convert.ToDecimal(dr["telephone_limit"]).ToString("0");
                    txtBonus.Text = Convert.ToDecimal(dr["Bonus"]).ToString("0");
                    txtSpAllow.Text = Convert.ToDecimal(dr["Sp_Allow"]).ToString("0");
                    txtWashAllow.Text = Convert.ToDecimal(dr["Wash_Allow"]).ToString("0");
                    txtOtAllow.Text = Convert.ToDecimal(dr["ot_allow"]).ToString("0");
                    txtVehAllow.Text = Convert.ToDecimal(dr["Veh_Allow"]).ToString("0");
                    txtMed_Allow.Text = Convert.ToDecimal(dr["Med_Allow"]).ToString("0");
                    txtccaAllow.Text = Convert.ToDecimal(dr["cca"]).ToString("0");
                    txtReimb.Text = Convert.ToDecimal(dr["reimb_amt"]).ToString("0");
                    txtTax.Text = Convert.ToDecimal(dr["tax_ded"]).ToString("0");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }
     
        private void careerMap_Load(object sender, EventArgs e)
        {

        }

        private void radPageView1_SelectedPageChanged(object sender, EventArgs e)
        {

        }

        private void dgEmpList_Click(object sender, EventArgs e)
        {

        }
    }
}
