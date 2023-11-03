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

namespace eHRM.Employee
{
    public partial class StaffOrgDocs : UserControl
    {
        string _qry = string.Empty;
        string _result = string.Empty; string _empCode = string.Empty; Byte[] _imgByte = null; string szFileName = string.Empty;
        string _selectedFilePath = string.Empty; int _counter = 0;
        string _Extension = string.Empty; string _fileType = string.Empty;
        string _DOC_TYPE = string.Empty;
        byte[] imageContent = null;
        public StaffOrgDocs()
        {
            InitializeComponent();
        }

        private void StaffOrgDocs_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _qry = "select  eod.emp_code,docNme,emp_name,RP_Flag=isnull(rp_flag,'N'),staff_photo,FileType from empOrgDocs eod ";
                _qry += "left join EmpDetail e on eod.emp_code=e.emp_code ";
                _qry += " outer apply(select RP_Flag = 'Y',staff_photo,FileType from Staff_photograph sp where doc_type = 'Registration paper' ";
                _qry+="and sp.emp_code= eod.emp_code) x";
                DataSet ds = GlobalUsage.accounts_proxy.GetQueryResult(_qry, "exhrd");
                rgv_staff.DataSource = ds.Tables[0];
                ds.Dispose();
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

       

        private void rgv_staff_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Row.Cells["rpflag"].Value.ToString() == "Y") { 
            try
            {
                //radpdfViewer.LoadDocument("notexist.pdf");
                Cursor.Current = Cursors.WaitCursor;
                _DOC_TYPE = e.Row.Cells["FileType"].Value.ToString();
                imageContent = (byte[])(e.Row.Cells["staff_photo"].Value);
                txtDoc.Text= e.Row.Cells["docnme"].Value.ToString();
                if (e.Row.Cells["FileType"].Value.ToString().ToUpper() == "PDF")
                {
                  
                    _fileType = ".PDF";
                    radPageView1.SelectedPage = radPageView1.Pages[1];
                    loadPDF(imageContent, _DOC_TYPE);
                }
                else
                {
               
                    _fileType = ".jpeg";
                    radPageView1.SelectedPage = radPageView1.Pages[0];
                  
                    _selectedFilePath = Application.StartupPath + "\\tempimg\\" + _empCode + "_" + _DOC_TYPE.Replace("/", "_") + ".jpeg";
                    if (!File.Exists(_selectedFilePath))
                    {
                        File.WriteAllBytes(_selectedFilePath, imageContent);
                    }
                    MemoryStream ms = new MemoryStream(imageContent);
                    document_Info.Image = System.Drawing.Image.FromStream(ms);
                }
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
            }
        }
        private void loadPDF(byte[] data, string DocType)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (data.Length > 0)
                {
                    _counter++;

                    string path = Application.StartupPath + "\\tempimg\\" + _empCode + "_" + DocType + ".pdf";
                    if (!File.Exists(path))
                    {
                        File.WriteAllBytes(path, data);
                    }
                    radpdfViewer.LoadDocument(path);
                }
                else
                { MessageBox.Show("Report not uploaded"); }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void MasterTemplate_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Cells["rpflag"].Value.ToString()== "Y")
                e.RowElement.ForeColor = Color.Green;
            else
                e.RowElement.ForeColor = Color.Black;
        }
    }
}
