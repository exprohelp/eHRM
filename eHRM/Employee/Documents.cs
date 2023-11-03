using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace eHRM.Employee
{
    public partial class Documents : Telerik.WinControls.UI.RadForm
    {
        string _result = string.Empty; string _empCode = string.Empty; Byte[] _imgByte = null; string szFileName = string.Empty;
        string _selectedFilePath = string.Empty; int _counter = 0;
        string _Extension = string.Empty;
        byte[] imageContent = null;
        OpenFileDialog dlg = new OpenFileDialog();

        public Documents()
        {
            InitializeComponent();
        }

        private void Documents_Load(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(Application.StartupPath + "\\tempImg"))
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + "\\tempImg");
                foreach (FileInfo file in di.EnumerateFiles())
                {
                    file.Delete();
                }
            }

            Rectangle rec = Screen.PrimaryScreen.WorkingArea;
            int size = (rec.Size.Width - this.Width) / 2;
            this.Location = new System.Drawing.Point(size, 155);
            DataSet ds = new DataSet();
            ds = GlobalUsage.hr_proxy.GetQueryResult("SELECT DOC_TYPE=dbo.ProperCase(DOC_TYPE) FROM staff_docType WHERE (act_flag = 'Y') order by doc_type", "exhrd");
            cmbDocType.Items.Clear();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cmbDocType.Items.Add(dr["doc_type"].ToString());
                }
            }

        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if (textSearch.Text.Length > 3)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    DataSet ds = GlobalUsage.accounts_proxy.GetQueryResult("exec pSearchEmp '" + textSearch.Text + "','ALL'", "exhrd");
                    rgv_staff.DataSource = ds.Tables[0];
                    ds.Dispose();
                }
                catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
                finally { Cursor.Current = Cursors.Default; }
            }
        }

        private void rgv_staff_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                btnSend.Enabled = false;

                Cursor.Current = Cursors.WaitCursor;
                document_Info.Image = null;
                _empCode = e.Row.Cells[0].Value.ToString();
                string qry = @"pGetDocumentInfo '" + _empCode + "','EmployeeInfo'   ";
                DataSet ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHrd");
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    rgb_info.Text = ds.Tables[0].Rows[0]["emp_name"].ToString() + " [" + _empCode + "]";
                    lblDesgnation.Text = ds.Tables[0].Rows[0]["designation"].ToString();
                    if (ds.Tables[0].Rows[0]["staff_photo"].ToString().Length > 0)
                    {
                        byte[] imageContent = (byte[])((ds.Tables[0].Rows[0]["staff_photo"]));
                        MemoryStream ms = new MemoryStream(imageContent);
                        pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                        if (ds.Tables[1].Rows.Count > 0)
                            rgv_Doc_Info.DataSource = ds.Tables[1];
                        else
                            rgv_Doc_Info.DataSource = new string[] { };
                    }
                    else if (ds.Tables[1].Rows.Count > 0)
                    {
                        pictureBox1.Image = null;

                        rgv_Doc_Info.DataSource = ds.Tables[1];
                    }
                    else
                    {
                        pictureBox1.Image = null;
                        rgv_Doc_Info.DataSource = new string[] { };

                    }
                    //File.WriteAllBytes(Server.MapPath("images/tempimage.jpg"),imageContent);
                    //Image1.ImageUrl = "~/hr/images/tempimage.jpg"; 
                }
               
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void MasterTemplate_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            //if (e.CellElement.ColumnInfo is GridViewImageColumn)
            //{
            //    if (e.CellElement.Image == null)
            //    {
            //        if (((GridViewImageColumn)e.CellElement.ColumnInfo).FieldName == "ImageBytes")
            //        {
            //            string strPath = ((GridImageCellElement)e.CellElement).Value.ToString();
            //            if (strPath != string.Empty)
            //            {
            //                e.CellElement.Image = new Bitmap(strPath);
            //                e.CellElement.ImageLayout = ImageLayout.Stretch;
            //            }
            //        }
            //    }
            //}
        }
        string _fileType = string.Empty;
        string _DOC_TYPE = string.Empty;
        private void MasterTemplate_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                //radpdfViewer.LoadDocument("notexist.pdf");
                Cursor.Current = Cursors.WaitCursor;
                _DOC_TYPE = e.Row.Cells["DOC_TYPE"].Value.ToString();
                imageContent = (byte[])(e.Row.Cells["ImageBytes"].Value);

                if (e.Row.Cells["FileType"].Value.ToString().ToUpper() == "PDF")
                {
                    btnSend.Enabled = true;
                    _fileType = ".PDF";
                    radPageView1.SelectedPage = radPageView1.Pages[1];
                    loadPDF(imageContent, _DOC_TYPE);
                }
                else
                {
                    btnSend.Enabled = true;
                    _fileType = ".jpeg";
                    radPageView1.SelectedPage = radPageView1.Pages[0];
                    btnPrint.Enabled = true;
                    _selectedFilePath = Application.StartupPath + "\\tempimg\\" + _empCode + "_" + _DOC_TYPE.Replace("/","_") + ".jpeg";
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
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string result = GlobalUsage.hr_proxy.InsertModifyStaff_Documents(rgv_staff.CurrentRow.Cells[0].Value.ToString(), cmbDocType.Text, _imgByte, _Extension, GlobalUsage.Login_id);
                lblFileSize.Text = "Result : " + result;
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; btnUpload.Enabled = false; }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            dlg.Filter = "Image files (*.jpg, *.jpeg,*.png) | *.jpg; *.jpeg;*.png;*.pdf;*.PDF";
            if (dlg.ShowDialog() == DialogResult.OK) // Test result.
            {
                FileInfo file = new FileInfo(dlg.FileName);
                txtFilePath.Text = file.ToString();
                lblFileSize.Text = "File Size: " + ((Convert.ToDecimal(file.Length) / 1048576)).ToString("##.00") + " MB";
                btnUpload.Enabled = true;
                try
                {
                    if (!file.Extension.ToUpper().Contains("PDF"))
                    {
                        document_Info.Image = null;
                        szFileName = Application.StartupPath + "\\uploadTemp" + file.Extension.ToString();
                        FileInfo check = new FileInfo(szFileName);
                        if (((Convert.ToDecimal(file.Length) / 1048576)) > 2)
                        {
                            SaveJPGWithCompressionSetting(Image.FromFile(dlg.FileName), szFileName, 50);
                        }
                        else
                            szFileName = dlg.FileName;
                        Image img = Image.FromFile(szFileName.ToString());
                        _imgByte = imgToByteArray(img);
                        //byte[] bArr = imgToByteConverter(img);
                        //Again convert byteArray to image and displayed in a picturebox
                        Image img1 = byteArrayToImage(_imgByte);
                        document_Info.Image = img1;
                        _Extension = "Image";
                    }
                    else
                    {
                        _imgByte = File.ReadAllBytes(dlg.FileName);
                        _Extension = "PDF";
                    }
                }
                catch (IOException)
                {
                }
            }
        }
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        private void SaveJPGWithCompressionSetting(Image image, string szFileName, long lCompression)
        {
            EncoderParameters eps = new EncoderParameters(1);
            eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, lCompression);
            ImageCodecInfo ici = GetEncoderInfo("image/jpeg");
            if (File.Exists(szFileName))
                File.Delete(szFileName);
            image.Save(szFileName, ici, eps);
        }

        //convert image to bytearray
        public byte[] imgToByteArray(Image img)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                img.Save(mStream, img.RawFormat);
                return mStream.ToArray();
            }
        }
        //convert bytearray to image
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(mStream);
            }
        }
        //another easy way to convert image to bytearray
        public static byte[] imgToByteConverter(Image inImg)
        {
            ImageConverter imgCon = new ImageConverter();
            return (byte[])imgCon.ConvertTo(inImg, typeof(byte[]));

        }

        private void cmbDocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            document_Info.Image = null;
        }

        private void rgv_staff_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PrintDocument(_selectedFilePath);
            Cursor.Current = Cursors.Default;
        }

        private static void PrintDocument(string filePath)
        {
            PrintDocument pd = new PrintDocument();
            //pd.DefaultPageSettings.PrinterSettings.PrinterName = "Printer Name";
            pd.DefaultPageSettings.Landscape = false;
            pd.PrintPage += (sender, args) =>
            {
                Image i = Image.FromFile(filePath);
                Rectangle m = args.MarginBounds;

                if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
                {
                    m.Height = ((int)((double)i.Height / (double)i.Width * (double)m.Width));
                }
                else
                {
                    m.Width = ((int)((double)i.Width / (double)i.Height * (double)m.Height));
                }
                args.Graphics.DrawImage(i, m);
            };
            pd.Print();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "", "SearchEmployee", txtSearch.Text, "", "");
                ddlEmployee.Items.Clear();
                ddlEmployee.Items.AddRange(Config.FillTelrikCombo(ds.Tables[0]));
                ddlEmployee.SelectedIndex = 0;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                string subject = "Find Document : " + _DOC_TYPE;
                string FileName = ddlEmployee.SelectedValue.ToString().Replace("-", "") + "_" + _DOC_TYPE + _fileType;
                string msg = GlobalUsage.hr_proxy.Insert_ConversationByDesktopApp("Post", GlobalUsage.Login_id, ddlEmployee.SelectedValue.ToString(), "", subject, "Kindly download  attachement.", 0, "Normal", imageContent, FileName);
                MessageBox.Show(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ExPro Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default; }
        }
    }
}

