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
using System.IO;

namespace eHRM.increments
{
    public partial class IncrementEntryNew : Telerik.WinControls.UI.RadForm
    {
        string _result = string.Empty;string _empCode = string.Empty;DateTime _dt;string _autoid=string.Empty;
        DataSet _ds = new DataSet();string esiFlag = string.Empty; string pfFlag = string.Empty;string eliteFlag = string.Empty;


        public IncrementEntryNew()
        {
            InitializeComponent();

        }

        private void btnFillList_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds;
                if(chkNewJoinSalary.Checked)
                    ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "EmployeeList", "Pending For Salary", "", "");
                else
                    ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "EmployeeList", "All Staff List", "", "");

                dgEmpList.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void dgEmpList_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            txtApproverRemark.Text = "";
            _empCode = e.Row.Cells["emp_code"].Value.ToString();
            ddlEmpStatus.Text = e.Row.Cells["status"].Value.ToString();
            ddlDesignation.Text = e.Row.Cells["designation"].Value.ToString();
            txtAmount.Text= e.Row.Cells["totalpay"].Value.ToString();
            if (Convert.ToDecimal(e.Row.Cells["totalpay"].Value) ==0)
            { 
                ddlType.Text = "New Joining";
                ddlType.Enabled = false;
                dtIncrDate.Value = Convert.ToDateTime(e.Row.Cells["doj"].Value);
                dtIncrDate.Enabled = false;
            }
            else
            { 
                ddlType.Enabled = true;
                dtIncrDate.Enabled = true;
            }
            if (e.Row.Cells["pf_flag"].Value.ToString() == "Y")
            { chkPF_Flag.Checked = true; chkPF_Flag.Enabled = false; }
            else
            { chkPF_Flag.Checked = false; chkPF_Flag.Enabled = true; }

                if (e.Row.Cells["esi_flag"].Value.ToString() == "Y")
                chk_ESI_Applied.Checked = true;
            else
                chk_ESI_Applied.Checked = false;

            if (e.Row.Cells["elite_flag"].Value.ToString() == "Y")
                ddlClub.Text = "Elite";
            else if (e.Row.Cells["elite_flag"].Value.ToString().ToUpper() == "ELITE")
                ddlClub.Text = "Elite";
            else if (e.Row.Cells["elite_flag"].Value.ToString().ToUpper() == "PRIME")
                ddlClub.Text = "Prime";
            else
                ddlClub.Text = "N/A";

            FillDetails(_empCode);
            btnApplyPolicy.PerformClick();
        }

        private void FillDetails(string empcode)
        {
            try
            {
               
                //esiFlag = "N"; pfFlag = "N"; eliteFlag = "N";
                //txtAmount.Text = "0";
                //txtBasicPart.Text = "0";
                //txtBonus.Text = "0";
                //txtElite.Text = "0";
                //txtHRa.Text = "0";
                //txtPerBonus.Text = "0";
                //txtTotal.Text = "0";
                //txtRemarks.Text = "";
                
                //chkPF_Flag.Checked = false;
                //chk_ESI_Applied.Checked = false;
                //cbEliteClub.Checked = false;
                FillIncrementList(_empCode);

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message.ToString(), "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { }
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
      
        private void gross() {
            Int32 gross = 0;
            gross = Convert.ToInt32(txtHRa.Text) + Convert.ToInt32(txtElite.Text) + Convert.ToInt32(txtPerBonus.Text) + 
                Convert.ToInt32(txtBasicPart.Text);
            gross += Convert.ToInt32(txtBonus.Text)+ Convert.ToInt32(txtReimb.Text);
            txtTotal.Text = gross.ToString();
        }

      


       

     
     
        private void rgvInfo_Click(object sender, EventArgs e)
        {
            gross();
        }

        private void btnAdd_Modify_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtBasicPart.Text)==0)
            {
                RadMessageBox.Show("Basic part Can Not be  Zero.", "ExPro Help", MessageBoxButtons.OK);
                txtBasicPart.Focus();
            }
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                DialogResult res = RadMessageBox.Show("Do You Confirm ? ", "ExPro Help", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    string dt = string.Empty;dt = dtIncrDate.Value.ToString("yyyy-MM") + "-01";
                    string esi_flag = string.Empty;
                    string pf_flag = string.Empty;
                    string elite_flag = string.Empty;
                    esi_flag = "N";pf_flag = "N"; elite_flag = "N";
                    if (chkPF_Flag.Checked)
                        pf_flag = "Y";
                    if (chk_ESI_Applied.Checked)
                        esi_flag = "Y";
                    //if (cbEliteClub.Checked)
                    //    elite_flag = "Y";

                    elite_flag = ddlClub.Text;

                    _result = GlobalUsage.hr_proxy.Increment_DataEntry(out _result, _empCode, "-", ddlEmpStatus.Text, ddlDesignation.Text,
                     Convert.ToDecimal(txtBasicPart.Text), Convert.ToDecimal(txtHRa.Text), Convert.ToDecimal(txtPerBonus.Text), Convert.ToDecimal(txtElite.Text),
                     Convert.ToDecimal(txtBonus.Text), Convert.ToDecimal(txtCA.Text), dt, esi_flag, pf_flag,elite_flag, GlobalUsage.Login_id,txtRemarks.Text, 
                     ddlType.Text, Convert.ToDecimal(txtReimb.Text));
                    FillDetails(_empCode);
                }

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default;
                txtReimb.Text = "0";
            }
        }
        private void MasterTemplate_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            _empCode = e.Row.Cells["emp_code"].Value.ToString();
            _autoid = e.Row.Cells["autoid"].Value.ToString();
            if (e.Column.Name == "delete")
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    DialogResult res = MessageBox.Show("Do You Confirm ? ", "ExPro Help", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        string qry = "pIncrementQueries '','-','1900/01/01','1900/01/01','" + _autoid + "','-','DeleteIncreament','" + GlobalUsage.Login_id + "' ";
                        GlobalUsage.hr_proxy.QueryExecute(qry, "exhrd");
                        FillIncrementList(_empCode);
                    }
                    rgbFileUpload.Text = _empCode;
                }
                catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
                finally { Cursor.Current = Cursors.Default; }
            }
            else if (e.Column.Name == "file")
            {
                rgbFileUpload.Enabled = true;
            }
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

        private void btnApplyPolicy_Click(object sender, EventArgs e)
        {
            if (ddlDesignation.Text.ToUpper() == "SELECT")
            {
                ddlDesignation.Focus();return;
            }
            if (ddlEmpStatus.Text.ToUpper() == "SELECT")
            { ddlEmpStatus.Focus(); return; }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                esiFlag = "N"; pfFlag = "N"; eliteFlag = "N";
                if (chkPF_Flag.Checked) pfFlag = "Y"; else pfFlag = "N";
                if (chk_ESI_Applied.Checked) esiFlag = "Y"; else esiFlag = "N";
                //if (cbEliteClub.Checked) eliteFlag = "Y"; else eliteFlag = "N";
               
                if (ddlClub.Text.ToString().ToUpper() == "ELITE")
                    eliteFlag = "Elite";
                else if (ddlClub.Text.ToString().ToUpper() == "PRIME")
                    eliteFlag = "Prime";
                else
                    eliteFlag = "N";

                string qry = "execute [pPayStructureCalculator] '"+_empCode+"','" + esiFlag + "','" + pfFlag + "','" + eliteFlag + "','" + ddlEmpStatus.Text + "','-'," + txtAmount.Text + ",'Y'";
            
                _ds = GlobalUsage.hr_proxy.GetQueryResult(qry,"exhrd");
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = _ds.Tables[0].Rows[0];
                    txtBasicPart.Text = Convert.ToInt32(dr["Basicpart"]).ToString("0");
                    txtElite.Text = Convert.ToInt32(dr["eliteClubBonus"]).ToString("0");
                    txtCA.Text = Convert.ToInt32(dr["CA"]).ToString("0");
                    txtHRa.Text = Convert.ToInt32(dr["houseRent"]).ToString("0");
                    txtBonus.Text = Convert.ToInt32(dr["BonusPart"]).ToString("0");
                    txtPerBonus.Text = Convert.ToInt32(dr["performanceBonus"]).ToString("0");
                    txtTotal.Text = Convert.ToInt32(dr["Total"]).ToString("0");
                    txtesi.Text = Convert.ToInt32(dr["esiByComp"]).ToString("0");
                    txtpf.Text = Convert.ToInt32(dr["pfByComp"]).ToString("0");
                    txtCtoC.Text = Convert.ToInt32(dr["CTC"]).ToString("0");
                    if (Convert.ToInt32(dr["esiByComp"]) > 0)
                        chk_ESI_Applied.Checked = true;
                    else
                        chk_ESI_Applied.Checked = false;

                    if (Convert.ToInt32(dr["pfByComp"]) > 0)
                        chkPF_Flag.Checked = true;
                    else
                        chkPF_Flag.Checked = false;


                }
                else
                {
                    RadMessageBox.Show("Error In Structure Policy. Kindly Inform IT.", "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                if (Convert.ToDecimal(txtAmount.Text) == Convert.ToDecimal(txtTotal.Text))
                    btnAdd_Modify.Enabled = true;
                else
                    btnAdd_Modify.Enabled = false;


            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        
        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty; byte[] fileBytes= { };string fileType = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                fileType =  System.IO.Path.GetExtension(filePath).Replace(".",""); 

                fileBytes = File.ReadAllBytes(filePath);

                using (MemoryStream memory = new MemoryStream(fileBytes))
                {
                    using (BinaryReader reader = new BinaryReader(memory))
                    {
                        for (int i = 0; i < fileBytes.Length; i++)
                        {
                            byte result = reader.ReadByte();
                            
                        }
                    }
                }
            }
            _result=GlobalUsage.hr_proxy.UploadSalaryApprovalDocument(_empCode,_autoid, fileBytes, fileType);
            RadMessageBox.Show(_result, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info);
        }

        private void dgEmpList_Click(object sender, EventArgs e)
        {

        }

        private void chkNewJoinSalary_CheckedChanged(object sender, EventArgs e)
        {
           

        }

        private void chkPF_Flag_CheckedChanged(object sender, EventArgs e)
        {
            btnApplyPolicy.PerformClick();
        }

        private void ddlClub_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            btnApplyPolicy.PerformClick();
        }
    }
}
