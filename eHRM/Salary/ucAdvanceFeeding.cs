using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eHRM.Salary
{
    public partial class ucAdvanceFeeding : UserControl
    {
        string _empCode = "", _ledgerCode = string.Empty, _result = string.Empty;
        string _empName = "", _DrLedgerCode = string.Empty, _CrLedgerCode = string.Empty;
        string _EmployeeStatus = "";
        decimal _OTALLOW = 0;
        public ucAdvanceFeeding()
        {
            InitializeComponent();
        }

        private void ucAdvanceFeeding_Load(object sender, EventArgs e)
        {
            this.Text = "Advance Payment To Staff {Press Enter Key on Employee To Get Information}";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet _ds = GlobalUsage.accounts_proxy.AccountsSmallQueries(out _result, GlobalUsage.Login_id, GlobalUsage.Unit_id, "Salary Ledger", "HR", "N/A");
                rgv_info.DataSource = _ds.Tables[0];
                rdp_adjdate.MinDate = DateTime.Now.AddDays(-30);
                rdp_adjdate.MaxDate = DateTime.Now;
                //if (_ds.Tables[0].Rows.Count > 0)
                //{
                //    foreach (DataRow dr in _ds.Tables[0].Rows)
                //    {
                //        lv_employee.Items.Add(dr["emp_code"].ToString());
                //        lv_employee.Items[lv_employee.Items.Count - 1].SubItems.Add(dr["ld_name"].ToString());
                //        lv_employee.Items[lv_employee.Items.Count - 1].SubItems.Add(dr["ld_code"].ToString());
                //    }
                //}
                //Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                #region Proces Block
                if (Convert.ToDecimal(txtAdvAmt.Text) <= Convert.ToDecimal(lblAdvLimit.Text))
                {
                    DialogResult res = MessageBox.Show("Do You Confirm To Give Advance Salary (Y/N)", "Advance Salary", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        btnAdd.Enabled = false;
                        #region Insert Advance Salary
                        string result = GlobalUsage.accounts_proxy.InsAdvanceSalayInfo_withAdjustment("EXHRD", _empCode, Convert.ToDecimal(txtAdvAmt.Text), rdp_adjdate.Value.ToString("yyyy/MM/dd"), GlobalUsage.Login_id, cmbReason.Text);
                        if (result == "Successfully Inserted.")
                        {
                            txtAdvAmt.Text = "";
                        }
                        else
                        {
                            MessageBox.Show(result, "Advance Salary");
                        }
                        // FillRecord("Particular");
                        #endregion
                    }
                }
                else
                {
                    MessageBox.Show("Enter valid amount");
                }
                #endregion

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Advance To Staff"); }
        }

        private void rgv_info_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            lvAdvamt.Items.Clear();
            try
            {
                lblSalary.Text = " ";
                lblHRA.Text = " ";
                lblCCA.Text = " ";
                lblConv.Text = " ";
                lblWash.Text = " ";
                lblSpAllow.Text = " ";
                lblGross.Text = " ";
                lblAdvLimit.Text = " ";
                btnAdd.Enabled = false;
                _empCode = rgv_info.CurrentRow.Cells[0].Value.ToString();
                _empName = rgv_info.CurrentRow.Cells[1].Value.ToString();
                _ledgerCode = rgv_info.CurrentRow.Cells[2].Value.ToString();
                gb_info.Text = _empName;
                DataSet _ds = new DataSet();
                _ds = GlobalUsage.accounts_proxy.AdvSalayInfo(out _result, GlobalUsage.Login_id, _empCode, "SalaryInfo");
                if (_ds.Tables.Count > 0)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = _ds.Tables[0].Rows[0];
                        #region Fill Grid
                        btnAdd.Enabled = true;
                        lblSalary.Text = Convert.ToDecimal(dr["salary_pf"]).ToString("###");
                        lblHRA.Text = Convert.ToDecimal(dr["hra"]).ToString("###");
                        lblCCA.Text = Convert.ToDecimal(dr["cca"]).ToString("###");
                        lblConv.Text = Convert.ToDecimal(dr["fixed_conv"]).ToString("###");
                        lblWash.Text = Convert.ToDecimal(dr["wash_allow"]).ToString("###");
                        lblSpAllow.Text = Convert.ToDecimal(dr["sp_allow"]).ToString("###");
                        lblBonus.Text = Convert.ToDecimal(dr["bonus"]).ToString("###");
                        lblGross.Text = Convert.ToDecimal(dr["gross"]).ToString("###");
                        lblAdvLimit.Text = (Convert.ToDecimal(dr["gross"]) - Convert.ToDecimal(dr["advTaken"])).ToString("####");
                        #endregion
                    }
                }
                if (_ds.Tables.Count > 0)
                {
                    #region History of Advances
                    if (_ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dr in _ds.Tables[1].Rows)
                        {
                            lvAdvamt.Items.Add(Convert.ToDateTime(dr["cr_date"]).ToString("dd-MMM-yyyy"));
                            lvAdvamt.Items[lvAdvamt.Items.Count - 1].SubItems.Add(Convert.ToDateTime(dr["adj_date"]).ToString("dd-MMM-yyyy"));
                            lvAdvamt.Items[lvAdvamt.Items.Count - 1].SubItems.Add(Convert.ToDecimal(dr["adv_amount"]).ToString("##"));
                            lvAdvamt.Items[lvAdvamt.Items.Count - 1].SubItems.Add(Convert.ToDecimal(dr["app_amount"]).ToString("##"));
                            lvAdvamt.Items[lvAdvamt.Items.Count - 1].SubItems.Add(dr["reason"].ToString());
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex) { MessageBox.Show("Check Internet Connection whether it is slow or disconnected try again"); }
            Cursor.Current = Cursors.Default;

        }


    }
}
