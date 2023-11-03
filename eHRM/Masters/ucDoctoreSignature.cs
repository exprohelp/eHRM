using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.Masters
{
    public partial class ucDoctorSignature : UserControl
    {
        DataSet _ds = new DataSet();
        string _result = string.Empty;string _empCode = string.Empty;System.IO.FileInfo _fileInfo;
        public ucDoctorSignature()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                _ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "-", "ProfList", "Yes", "1900-01-01", "-");
                rgv_info.DataSource = _ds.Tables[0];
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
            
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            //To where your opendialog box get starting location. My initial directory location is desktop.
            openFileDialog1.InitialDirectory = "C://Desktop";
            //Your opendialog box title name.
            openFileDialog1.Title = "Select file to be upload.";
            //which type file format you want to upload in database. just add them.
     
            openFileDialog1.Filter = "Select Valid Document(*.Jpeg; *.jpg; *.gif;)|*.Jpeg; *.jpg; *.gif;";

            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                      
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        txtUpFilename.Text = path;
                        _fileInfo = new System.IO.FileInfo(openFileDialog1.FileName);
                        btnUploadImage.Enabled = true;
                        
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload Image.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            Image img = Image.FromFile(txtUpFilename.Text);
            if (img.Width <= 150 && img.Height <= 90)
            {
                byte[] data = System.IO.File.ReadAllBytes(txtUpFilename.Text);
                GlobalUsage.hr_proxy.UploadEmployeeSignature(_empCode, GlobalUsage.Login_id, _fileInfo.Extension, data, out _result);
                if(_result.ToUpper().Contains("SUCC"))
                btnUploadImage.Enabled = true;
                RadMessageBox.Show(_result, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            else
                MessageBox.Show("Image Sige Should not be bigger than 125x90 ");
        }

        private void rgv_info_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            _empCode = e.Row.Cells["emp_code"].Value.ToString();
            radGroupBox1.Text = e.Row.Cells["emp_name"].Value.ToString() + ":" + e.Row.Cells["emp_code"].Value.ToString();
            if (e.Row.Cells["clr"].Value.ToString() == "Green") { 
            byte[] data=GlobalUsage.accounts_proxy.DownloadFile(e.Row.Cells["SignaturePath"].Value.ToString(), out _result);
            pictureBox1.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(data)).GetThumbnailImage(pictureBox1.Width,pictureBox1.Height,null,IntPtr.Zero);
            }
        }

        private void MasterTemplate_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Cells["clr"].Value.ToString() == "Red")
                e.RowElement.ForeColor = Color.Red;
            else
                e.RowElement.ForeColor = Color.DarkGreen;
        }
    }
}
