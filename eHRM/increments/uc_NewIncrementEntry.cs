using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace eHRM.increments
{
    public partial class uc_NewIncrementEntry : UserControl
    {
        string _result = string.Empty;string _empCode = string.Empty;DateTime _dt;
        DataSet _ds = new DataSet();
        public uc_NewIncrementEntry()
        {
            InitializeComponent();
        }

        private void btnFillList_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "EmpListForDutyShift", "", "", "");
                dgEmpList.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void dgEmpList_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            
         try
            {
                Cursor.Current = Cursors.WaitCursor;
                _empCode = e.Row.Cells["emp_code"].Value.ToString();
                DataSet ds = GlobalUsage.hr_proxy.GetQueryResult("execute pSearchEmp '"+e.Row.Cells["emp_code"].Value.ToString() +"','IncrDates'", "exhrd");
                rmcc_data.DataSource = ds.Tables[0];
                rgvInfo.DataSource = ds.Tables[0];
                //foreach(DataRow dr in ds.Tables[0].Rows)
                //{
                //    this.rmcc_data.EditorControl.Rows.Add(dr.ItemArray);
                //}
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void uc_NewIncrementEntry_Load(object sender, EventArgs e)
        {
            d_o_i.Value = DateTime.Today;
            d_o_i.MinDate = DateTime.Today.AddDays(-15);

            this.rmcc_data.DisplayMember = "Apply On";
            this.rmcc_data.ValueMember = "Emp Code";

        }

        private void rmcc_data_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var r = ((RadGridView)this.rmcc_data.EditorControl).CurrentRow;
              
                string dt = string.Empty;
                if (r.Cells["Apply On"].Value.ToString() == "New")
                {
                    dt = "New";
                }
                else
                {
                    _dt = Convert.ToDateTime(r.Cells["Apply On"].Value);
                    dt = Convert.ToDateTime(r.Cells["Apply On"].Value).ToString("yyyy/MM/dd");
                }
                _ds = GlobalUsage.hr_proxy.GetQueryResult("execute pGetEmpInfo1 '" + _empCode + "','"+dt+"'", "exhrd");

                ddlDesignation.DataSource = _ds.Tables[1];
                ddlDesignation.DisplayMember = "designation";
                ddlDesignation.ValueMember = "designation";

                ddlEmpStatus.DataSource = _ds.Tables[2];
                ddlEmpStatus.DisplayMember = "Status";
                ddlEmpStatus.ValueMember = "Status";
                ddlDivision.DataSource = _ds.Tables[3];
                ddlDivision.DisplayMember="designation";
                ddlDivision.ValueMember = "c_division";
                DataRow dr = _ds.Tables[0].Rows[0];
                if (_empCode!="New")
                { 
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                       
                        ddlEmpStatus.Text = dr["status"].ToString();
                        ddlDesignation.Text = dr["designation"].ToString();
                        txtSalary.Text = Convert.ToInt32(dr["salary_pf"]).ToString();
                        txtHRA.Text = Convert.ToInt32(dr["hra"]).ToString();
                        txtReimb.Text = Convert.ToInt32(dr["Reimb_Amt"]).ToString();
                        txtSpAllow.Text = Convert.ToInt32(dr["Sp_Allow"]).ToString();
                        txtccaAllow.Text = Convert.ToInt32(dr["cca"]).ToString();
                        txtTelephone.Text = Convert.ToInt32(dr["Tele_Allow"]).ToString();
                        txtMed_Allow.Text = Convert.ToInt32(dr["Med_Allow"]).ToString();
                        txtVehAllow.Text = Convert.ToInt32(dr["Veh_Allow"]).ToString();
                        txtWashAllow.Text = Convert.ToInt32(dr["wash_allow"]).ToString();
                        txtBonus.Text = Convert.ToInt32(dr["bonus"]).ToString();
                        d_o_i.Value = Convert.ToDateTime(dr["app_date"]);
                        txtGross.Text = Convert.ToInt32(dr["gross_salary"]).ToString();
                        txtRemarks.Text = dr["remark"].ToString();
                        if (dr["esi_flag"].ToString().ToUpper() == "Y")
                            chk_ESI_Applied.Checked = true;
                        else
                            chk_ESI_Applied.Checked = false;
                        if (dr["pf_flag"].ToString().ToUpper() == "Y")
                            chkPF_Flag.Checked = true;
                        else
                            chkPF_Flag.Checked = false;


                    }
                }
                ddlEmpStatus.Text = dr["status"].ToString();
                ddlDesignation.Text = dr["designation"].ToString();
                ddlDivision.Text = dr["division"].ToString();


            }
            catch (Exception ex) { }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void txtSalary_Leave(object sender, EventArgs e)
        {
            gross();
        }
        private void gross() {
            Int32 gross = 0;
            gross = Convert.ToInt32(txtSalary.Text) + Convert.ToInt32(txtHRA.Text) + Convert.ToInt32(txtReimb.Text) + Convert.ToInt32(txtSpAllow.Text);
            gross += Convert.ToInt32(txtccaAllow.Text) + Convert.ToInt32(txtTelephone.Text) + Convert.ToInt32(txtMed_Allow.Text);
            gross += Convert.ToInt32(txtVehAllow.Text) + Convert.ToInt32(txtWashAllow.Text) + Convert.ToInt32(txtBonus.Text);
            txtGross.Text = gross.ToString();
        }

        private void txtHRA_Leave(object sender, EventArgs e)
        {
            gross();
        }

        private void txtConv_Leave(object sender, EventArgs e)
        {
            gross();
        }

        private void txtTelephone_Leave(object sender, EventArgs e)
        {
            gross();
        }

        private void txtTrvLimit_Leave(object sender, EventArgs e)
        {
            gross();
        }

        private void txtTelLimit_Leave(object sender, EventArgs e)
        {
            gross();
        }

        private void txtBonus_Leave(object sender, EventArgs e)
        {
            gross();
        }

        private void txtSpAllow_Leave(object sender, EventArgs e)
        {
            gross();
        }

        private void txtWashAllow_Leave(object sender, EventArgs e)
        {
            gross();
        }

        private void txtVehAllow_Leave(object sender, EventArgs e)
        {
            gross();
        }

        private void txtMed_Allow_Leave(object sender, EventArgs e)
        {
            gross();
        }

        private void txtccaAllow_Leave(object sender, EventArgs e)
        {
            gross();
        }

        private void txtReimb_Leave(object sender, EventArgs e)
        {
            gross();
        }

        private void txtOtAllow_Leave(object sender, EventArgs e)
        {
            gross();
        }

        private void rgvInfo_Click(object sender, EventArgs e)
        {
            gross();
            if(rgvInfo.CurrentRow.Cells["Apply On"].Value.ToString()!="New")
            d_o_i.Value = Convert.ToDateTime(rgvInfo.CurrentRow.Cells["Apply On"].Value);
        }

        private void btnAdd_Modify_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DialogResult res = MessageBox.Show("Do You Confirm ? ", "ExPro Help", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    string dt = string.Empty;
                    if (rmcc_data.SelectedValue.ToString() == "New")
                        dt = "1900/01/01";
                    else
                        dt = Convert.ToDateTime(rmcc_data.Text).ToString("yyyy/MM/dd");
                    string esi_flag = string.Empty;
                    string pf_flag = string.Empty;
                    esi_flag = "N";pf_flag = "N";
                    if (chkPF_Flag.Checked)
                        pf_flag = "Y";
                    if (chk_ESI_Applied.Checked)
                        esi_flag = "Y";
                    _result = GlobalUsage.hr_proxy.InsIncrementDet(dt, _empCode,ddlDivision.Text, ddlEmpStatus.Text, ddlDesignation.Text,
                        Convert.ToDecimal(txtSalary.Text), Convert.ToDecimal(txtHRA.Text), Convert.ToDecimal(txtConv.Text), Convert.ToDecimal(txtReimb.Text),
                        Convert.ToDecimal(txtBonus.Text), Convert.ToDecimal(txtSpAllow.Text), Convert.ToDecimal(txtWashAllow.Text),
                        Convert.ToDecimal(txtccaAllow.Text), Convert.ToDecimal(txtTelephone.Text), Convert.ToDecimal(txtOtAllow.Text), Convert.ToDecimal(txtMed_Allow.Text),
                        Convert.ToDecimal(txtTrvLimit.Text), Convert.ToDecimal(txtTrvLimit.Text), Convert.ToDecimal(txtTelLimit.Text), d_o_i.Value.ToString("yyyy/MM/dd"), "N",
                        GlobalUsage.Login_id, txtRemarks.Text,esi_flag, pf_flag);
                }

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }


        }

        private void MasterTemplate_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DialogResult res = MessageBox.Show("Do You Confirm ? ", "ExPro Help", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    GlobalUsage.hr_proxy.QueryExecute("execute pDeleteIncreament '"+e.Row.Cells["autoid"].Value.ToString()+"','"+GlobalUsage.Login_id+"'", "exhrd");
                }

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }
    }
}
