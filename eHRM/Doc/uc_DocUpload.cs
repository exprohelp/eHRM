using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.Doc
{
    public partial class uc_DocUpload : UserControl
    {
        DataSet _ds = new DataSet();
        string _result = string.Empty; string _empCode = string.Empty; Byte[] _imgByte = null; string szFileName = string.Empty;
        string _selectedFilePath = string.Empty; int _counter = 0;
        string _Extension = string.Empty;
        byte[] imageContent = null;
        OpenFileDialog dlg = new OpenFileDialog();
        public uc_DocUpload()
        {
            InitializeComponent();
        }

        private void uc_DocUpload_Load(object sender, EventArgs e)
        {
            rdtFrom.Value = DateTime.Today;
            rdtTo.Value = DateTime.Today;
            loadTypeMaster();
            FillDocGrid();
        }

        private void loadTypeMaster()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                cmbType.Items.Clear();
                string qry = "SELECT DocType=doc_type,doc_type FROM [ExHrd].[dbo].[DOC_TypeMaster] order by doc_type;;";

                _ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHRD");
                cmbType.Items.AddRange(Config.FillWinCombo(_ds.Tables[0]));
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            dlg.Filter = "Image files *.pdf|*.PDF";
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


        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;


                string qry = "if not exists(select * from DOC_TypeMaster where doc_type='" + cmbType.Text.ToUpper() + "') ";
                qry += "INSERT INTO [dbo].[DOC_TypeMaster]([doc_type],[login_id]) VALUES(dbo.ProperCase('" + cmbType.Text.ToUpper() + "'),'" + GlobalUsage.Login_id + "')";
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

                ipDocument doc = new ipDocument();
                doc.DocumentId = "";
                doc.DocType = cmbType.Text;
                doc.DocName = txtApplicantName.Text;
                doc.DocVirtualPath = "";
                doc.DocPhysicalpath = "";
                doc.loginId = GlobalUsage.Login_id;
                doc.Logic = "Insert";

                var myContent = JsonConvert.SerializeObject(doc);
                form.Add(new StringContent(myContent));
                form.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length));

                string response = MISProxy.UploadDocumentByMultipart("Hrm/TrainingDocumentUpload", form);

                if (response.Contains("Success"))
                {
                    NewEntry();
                    FillDocGrid();
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
        }
        private void FillDocGrid()
        {
            string qry = "select autoId,doc_type,docname,DocPath,DocVirtualPath,cr_date,createdBy,updateDate,updateBy,isActive "; 
                    qry+="from doc_master where cast(cr_date as date) = cast(getdate() as date);";

            _ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHRD");
            rgv_info.DataSource = _ds.Tables[0];
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string qry = "select autoId,doc_type,docname,DocPath,DocVirtualPath,cr_date,createdBy,updateDate,updateBy,isActive ";
            qry += "from doc_master where cast(cr_date as date) between '"+rdtFrom.Value.ToString("yyyy-MM-dd")+"' and '"+ rdtTo.Value.ToString("yyyy-MM-dd") + "';";
            _ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHRD");
            rgv_info.DataSource = _ds.Tables[0];
        }
    }
}
