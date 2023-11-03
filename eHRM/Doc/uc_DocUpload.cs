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
            dlg.Filter = "Image files *.pdf;*.PDF";
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


                string qry = "if not exists(select * from DOC_TypeMaster where doc_type='" + cmbType.Text.ToUpper()+"') ";
                qry += "INSERT INTO [dbo].[DOC_TypeMaster]([doc_type],[login_id]) VALUES(dbo.ProperCase('" + cmbType.Text.ToUpper() + "'),'"+GlobalUsage.Login_id+"')";
                GlobalUsage.hr_proxy.QueryExecute(qry, "ExHRD");
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
            loadTypeMaster();
        }
    }
}
