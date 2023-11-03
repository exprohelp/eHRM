using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

namespace eHRM.cv
{
    public partial class uc_CvUpload : UserControl
    {
        DataSet _ds = new DataSet();
        string _result = string.Empty; string _empCode = string.Empty; Byte[] _imgByte = null; string szFileName = string.Empty;
        string _selectedFilePath = string.Empty; int _counter = 0;
        string _Extension = string.Empty;
        byte[] imageContent = null;string _qry = string.Empty;
        OpenFileDialog dlg = new OpenFileDialog();
        public uc_CvUpload()
        {
            InitializeComponent();
        }

        private void uc_CvUpload_Load(object sender, EventArgs e)
        {
            rdtFrom.Value = DateTime.Today;
            rdtTo.Value = DateTime.Today;
            rdpDOB.Value = DateTime.Today.AddYears(-18);
            loadTypeMaster();
            FillCvGrid();
        }

        private void loadTypeMaster()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                cmbType.Items.Clear();
                string qry = "select cvType = cv_type, cv_type from cv_TypeMaster order by cv_type;";

                _ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHRD");
                cmbType.Items.AddRange(Config.FillWinCombo(_ds.Tables[0]));
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            //dlg.Filter = "Image files *.pdf;*.PDF";
            if (dlg.ShowDialog() == DialogResult.OK) // Test result.
            {
                FileInfo file = new FileInfo(dlg.FileName);
                txtFilePath.Text = file.ToString();
                lblFileSize.Text = "File Size: " + ((Convert.ToDecimal(file.Length) / 1048576)).ToString("##.00") + " MB";
                btnUpload.Enabled = true;
                try
                {
                    _imgByte = File.ReadAllBytes(dlg.FileName);
                    _Extension = "PDF";
                }
                catch (IOException)
                {
                }
            }
        }

        private void chkExperienced_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkExperienced.Checked)
                txtExprMth.Enabled = true;
            else
                txtExprMth.Enabled = false;

        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;


                string qry = "if not exists(select * from cv_TypeMaster where cv_type='" + cmbType.Text.ToUpper() + "') ";
                qry += "INSERT INTO [dbo].[cv_TypeMaster]([cv_type],[createdBy]) VALUES(dbo.ProperCase('" + cmbType.Text.ToUpper() + "'),'" + GlobalUsage.Login_id + "')";
                GlobalUsage.hr_proxy.QueryExecute(qry, "ExHRD");

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
            loadTypeMaster();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            UploadDocument();
        }

        public void UploadDocument()
        {
            try
            {
                byte[] file_bytes = System.IO.File.ReadAllBytes(txtFilePath.Text);
                HttpClient httpClient = new HttpClient();
                MultipartFormDataContent form = new MultipartFormDataContent();

                ipCV icv = new ipCV();
                icv.cv_id = "New";
                icv.cv_name = txtApplicantName.Text;
                icv.cv_type = cmbType.Text;
                icv.dob = rdpDOB.Value.ToString("yyyy-MM-dd");

                icv.entryBy = GlobalUsage.Login_id;
                if (chkExperienced.Checked)
                    icv.IsExperienced = "Y";
                else
                    icv.IsExperienced = "N";

                if (rbMale.Checked)
                    icv.Gender = "M";
                else if(rbFemale.Checked)
                    icv.Gender = "F";
                icv.MobileNo = txtMobileNo.Text;
                icv.exprYears = Convert.ToDecimal(txtExprMth.Text);
                icv.remarks = richTextRemarks.Text;
                icv.eMail = txteMail.Text;
                icv.Logic = "Insert";
                icv.DocumentName = txtApplicantName.Text;
                icv.DocType = ".pdf";
                icv.cvFilePath = "-";
                var myContent = JsonConvert.SerializeObject(icv);
                form.Add(new StringContent(myContent));
                form.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length));

                string response = MISProxy.UploadDocumentByMultipart("Hrm/ApplicantDocumentUpload", form);

                if (response.Contains("Success"))
                {
                    NewEntry();
                    FillCvGrid();
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info);
            }


        }

        private void NewEntry()
        {
            txtApplicantName.Text = "";
            richTextRemarks.Text = "";

        }

        private void chkExperienced_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chkExperienced.Checked)
                txtExprMth.Enabled = true;
            else
                txtExprMth.Enabled = false;
        }

        private void FillCvGrid()
        {
            string qry = "SELECT [cv_id], [cv_name], [cv_type], [mobileNo], [isExperienced], [exprYears], [remarks],";
            qry += "[isActive], [entryBy], [cr_date], [cvFilePath], [update_date], [updateBy],email ";
            qry += "FROM[ExHrd].[dbo].[cv_master] where cast(cr_date as date) between '" + rdtFrom.Value.ToString("yyyy-MM-dd") + "' and '" + rdtTo.Value.ToString("yyyy-MM-dd") + "' and isActive = 'Y'";

            _ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "exhrd");
            rgv_info.DataSource = _ds.Tables[0];
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            FillCvGrid();
        }

        private void rgv_info_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DialogResult res = MessageBox.Show("Do You Confirm to Delete", "ExPro Help", MessageBoxButtons.YesNo);
                if(res==DialogResult.Yes)
                {
                    _qry = "delete from cv_master where cv_id='"+e.Row.Cells["cv_id"].Value.ToString()+"';";
                    GlobalUsage.hr_proxy.QueryExecute(_qry, "exhrd");
                    rgv_info.CurrentRow.Delete();
                }


            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }


            string qry = "SELECT [cv_id], [cv_name], [cv_type], [mobileNo], [isExperienced], [exprMonths], [remarks],";
            qry += "[isActive], [entryBy], [cr_date], [cvFilePath], [update_date], [updateBy] ";
            qry += "FROM[ExHrd].[dbo].[cv_master] where cast(cr_date as date) between '" + rdtFrom.Value.ToString("yyyy-MM-dd") + "' and '" + rdtTo.Value.ToString("yyyy-MM-dd") + "' and isActive = 'Y'";

            _ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "exhrd");
            rgv_info.DataSource = _ds.Tables[0];
        }
    }
}
