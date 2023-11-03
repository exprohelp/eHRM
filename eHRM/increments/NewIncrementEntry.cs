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
    public partial class NewIncrementEntry : Telerik.WinControls.UI.RadForm
    {
        string _result = string.Empty;string _empCode = string.Empty;DateTime _dt;
        DataSet _ds = new DataSet();
        public NewIncrementEntry()
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
                _empCode = e.Row.Cells["emp_code"].Value.ToString();
                ddlEmpStatus.Text = e.Row.Cells["status"].Value.ToString();
                ddlDesignation.Text = e.Row.Cells["designation"].Value.ToString();
                txtSalary.Text = "0";
                txtHRA.Text = "0";
                txtWashAllow.Text = "0";
                txtReimb.Text = "0";
                txtPerfBonus.Text = "0";
                txtGross.Text = "0";
                txtRemarks.Text = "";
                chkPF_Flag.Checked = false;
                chk_ESI_Applied.Checked = false;
                FillIncrementList(_empCode);
                //foreach(DataRow dr in ds.Tables[0].Rows)
                //{
                //    this.rmcc_data.EditorControl.Rows.Add(dr.ItemArray);
                //}
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally {  }
        }
        public void FillIncrementList(string emp_code)
        {
            Cursor.Current = Cursors.WaitCursor;
            string qry = "pIncrementQueries '','" + emp_code + "','1900/01/01','1900/01/01','-','-','IncrementLog','" + GlobalUsage.Login_id + "' ";
            DataSet ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "exhrd");
            dgRequests.DataSource = ds.Tables[0];
            dgIncreaments.DataSource = ds.Tables[1];
            Cursor.Current = Cursors.Default;
        }

        private void uc_NewIncrementEntry_Load(object sender, EventArgs e)
        {
            dtIncrDate.Value = DateTime.Today;
            dtIncrDate.MinDate = DateTime.Today.AddDays(-15);
            //dtIncrDate.Culture.DateTimeFormat.ShortDatePattern = "MM-yyyy";
            GlobalUsage.hr_proxy = new HumanResource.Staff_ManagementSoapClient();
            ddlType.SelectedIndex = 0;
            FillList();
        }
        public void FillList()
        {
            Cursor.Current = Cursors.WaitCursor;
            string qry = "pIncrementQueries '','-','1900/01/01','1900/01/01','-','-','StatusandDesignationList','" + GlobalUsage.Login_id + "' ";
            DataSet ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "exhrd");
            ddlEmpStatus.Items.AddRange(Config.FillTelrikCombo(ds.Tables[0]));
            ddlEmpStatus.SelectedIndex = 0;
            ddlDesignation.Items.AddRange(Config.FillTelrikCombo(ds.Tables[1]));
            ddlDesignation.SelectedIndex = 0;
            Cursor.Current = Cursors.Default;

        }
         private void txtSalary_Leave(object sender, EventArgs e)
        {
            gross();
        }
        private void gross() {
            Int32 gross = 0;
            gross = Convert.ToInt32(txtSalary.Text) + Convert.ToInt32(txtHRA.Text) + Convert.ToInt32(txtSpAllow.Text) + Convert.ToInt32(txtReimb.Text);
            gross += Convert.ToInt32(txtWashAllow.Text) + Convert.ToInt32(txtBonus.Text);
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
                    string esi_flag = string.Empty;
                    string pf_flag = string.Empty;
                    esi_flag = "N";pf_flag = "N";
                    if (chkPF_Flag.Checked)
                        pf_flag = "Y";
                    if (chk_ESI_Applied.Checked)
                        esi_flag = "Y";
                    _result = GlobalUsage.hr_proxy.Increment_InsertRequest(_empCode, "-", ddlEmpStatus.Text, ddlDesignation.Text,
                     Convert.ToDecimal(txtSalary.Text), Convert.ToDecimal(txtHRA.Text), 0, Convert.ToDecimal(txtReimb.Text), Convert.ToDecimal(txtSpAllow.Text),
                     Convert.ToDecimal(txtWashAllow.Text), Convert.ToDecimal(txtPerfBonus.Text), Convert.ToDecimal(txtBonus.Text), dtIncrDate.Value.ToString("yyyy/MM") + "/01", esi_flag, pf_flag, GlobalUsage.Login_id,ddlType.Text, txtRemarks.Text);
                    RadMessageBox.Show(_result, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info);
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
                    string qry = "pIncrementQueries '','-','1900/01/01','1900/01/01','" + e.Row.Cells["autoid"].Value.ToString() + "','-','DeleteIncreament','" + GlobalUsage.Login_id + "' ";
                    GlobalUsage.hr_proxy.QueryExecute(qry,"exhrd");
                    FillIncrementList(_empCode);
                }

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void dgRequests_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Cells["IsApproved"].Value.ToString() == "X")
                e.RowElement.ForeColor = Color.Red;
            if (e.RowElement.RowInfo.Cells["IsApproved"].Value.ToString() == "N")
                e.RowElement.ForeColor = Color.Black;
            if (e.RowElement.RowInfo.Cells["IsApproved"].Value.ToString() == "Y")
                e.RowElement.ForeColor = Color.Green;

        }

        private void MasterTemplate_RowsChanging(object sender, GridViewCollectionChangingEventArgs e)
        {
          
        }

        private void MasterTemplate_SelectionChanged(object sender, EventArgs e)
        {
            txtApproverRemark.Text = dgRequests.CurrentRow.Cells["ApproverRemark"].Value.ToString();
        }
    }
}
