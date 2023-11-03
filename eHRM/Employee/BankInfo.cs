using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.Employee
{
    public partial class BankInfo : Telerik.WinControls.UI.RadForm
    {
        byte[] data = null; string _empCode = string.Empty;
        System.IO.MemoryStream ms = null;int imgCounter = 0;
        Bitmap bmpPrint; int scrool_amt = 0;
        private ALV.ALVCS03CONTROLS.ALVImageViewer alvImageViewer1;
        DataSet _ds = new DataSet(); string _result = string.Empty;
        public BankInfo()
        {
            InitializeComponent();
            this.alvImageViewer1 = new ALV.ALVCS03CONTROLS.ALVImageViewer();

        }

        private void rbtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string injob = string.Empty;
                if (cbInJob.Checked)
                    injob = "Yes";
                else
                    injob = "No";
                _ds = GlobalUsage.accounts_proxy.HR_Queries(out _result, "N/A", "BankInfoReport", injob, "N/A", "N/A");
                rgv_data.DataSource = _ds.Tables[0];
                foreach (var col in rgv_data.Columns)
                {
                    col.BestFit();
                }
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }
        private void renderImageControl(byte[] data)
        {
            alvImageViewer1.Dispose();
            imgPanel.Controls.Clear();
          
            this.alvImageViewer1 = new ALV.ALVCS03CONTROLS.ALVImageViewer();
            this.alvImageViewer1.AutoFitToHeight = false;
            this.alvImageViewer1.AutoFitToScreen = false;
            this.alvImageViewer1.AutoFitToWidth = true;
            this.alvImageViewer1.BackColor = System.Drawing.SystemColors.Control;
            this.alvImageViewer1.ForeColor = System.Drawing.Color.White;
            this.alvImageViewer1.Location = new System.Drawing.Point(35, 3);
            this.alvImageViewer1.Name = "alvImageViewer1";
            this.alvImageViewer1.Size = new System.Drawing.Size(178, 205);
            this.alvImageViewer1.TabIndex = 154;
            this.alvImageViewer1.Dock = DockStyle.Fill;
            this.alvImageViewer1.ZoomRatio = 1D;
            imgCounter++;
            if (!System.IO.Directory.Exists(Application.StartupPath + "\\tempImg"))
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\tempImg");

            string filepathname = Application.StartupPath + "\\tempImg\\"+ _empCode+ imgCounter.ToString() + ".jpeg";
            System.IO.File.WriteAllBytes(filepathname, data);
            trackBar1.Value = 25;
            alvImageViewer1.ImageFromFile(filepathname);
            alvImageViewer1.AutoFitToScreen = false;
            alvImageViewer1.AutoFitToHeight = false;
            alvImageViewer1.AutoFitToWidth = false;

            imgPanel.Controls.Add(this.alvImageViewer1);
        }

        private void rbtn_excel_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\HrReports";
                if (!System.IO.Directory.Exists(mydocpath))
                {
                    System.IO.Directory.CreateDirectory(mydocpath);
                }
                string fileName = mydocpath + "\\BankInfoReport.xlsx";
                Telerik.WinControls.Export.GridViewSpreadExport spreadExporter;

                spreadExporter = new Telerik.WinControls.Export.GridViewSpreadExport(rgv_data);
                spreadExporter.ExportVisualSettings = true;
                spreadExporter.ExportHierarchy = true;
                spreadExporter.ExportFormat = Telerik.WinControls.Export.SpreadExportFormat.Xlsx;

                spreadExporter.RunExport(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void rgv_data_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            _empCode = e.Row.Cells["Code"].Value.ToString();
            this.chkStatus.CheckedChanged -= new System.EventHandler(this.chkStatus_CheckedChanged);

            if (e.Row.Cells["IsHold"].Value.ToString() == "Y")
            { chkStatus.Checked = false; chkStatus.Text = "Absconding"; }
            else
            { chkStatus.Checked = true; chkStatus.Text = "Working"; }

            if (e.Row.Cells["lock_flag"].Value.ToString() == "Y")
            { btnApprove.Enabled = false; /*btnCancel.Enabled = true; */}
            else
            { btnApprove.Enabled = true; /*btnCancel.Enabled = false; */}

            if (e.Row.Cells["file_path"].Value.ToString().Length > 10)
                FileDownload(e.Row.Cells["file_path"].Value.ToString());
           
            else
                RadMessageBox.Show("Bank Detail Not Uploaded.", "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info);
            this.chkStatus.CheckedChanged += new System.EventHandler(this.chkStatus_CheckedChanged);

        }

        private void FileDownload(string path)
        {
            Cursor.Current = Cursors.WaitCursor;
            string filepathname = string.Empty;
            System.IO.FileInfo fi = new System.IO.FileInfo(path);
            if (path != "N/A")
                data = GlobalUsage.accounts_proxy.DownloadFile(path, out _result);
            else
                alvImageViewer1.ClearImage();

            if (fi.Extension == ".pdf" || fi.Extension == ".doc" || fi.Extension == ".docx" || fi.Extension == ".doc" || fi.Extension == ".xlsx" || fi.Extension == ".txt")
            {
                if (data != null)
                {
                    string[] t = path.Split('\\');
                    FolderBrowserDialog fd = new FolderBrowserDialog();
                    fd.ShowDialog();
                    string stored_at = fd.SelectedPath + "\\" + t[t.Length - 1];
                    System.IO.File.WriteAllBytes(stored_at, data);

                }
            }
            else
            {
                if (data != null)
                {
                    renderImageControl(data);
                }

            }
            Cursor.Current = Cursors.Default;
        }

        private void BankInfo_Load(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(Application.StartupPath + "\\tempImg"))
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + "\\tempImg");
                foreach (FileInfo file in di.EnumerateFiles())
                {
                    file.Delete();
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value == 25)
                alvImageViewer1.ZoomRatio = 1;
            if (trackBar1.Value > scrool_amt)
            {
                if (alvImageViewer1.ZoomRatio < 10)
                {
                    alvImageViewer1.ZoomRatio = ((alvImageViewer1.ZoomRatio * 10) + 1) / 10;
                }
            }
            else
            {
                if (alvImageViewer1.ZoomRatio > 0.1)
                {
                    alvImageViewer1.ZoomRatio = ((alvImageViewer1.ZoomRatio * 10) - 1) / 10;
                }
            }
            scrool_amt = trackBar1.Value;

        }


        private void btnApprove_Click(object sender, EventArgs e)
        {
            string qry = string.Empty;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                qry = "execute Insert_Modify_emp_bank_info '" + _empCode + "','bn','ifsc','actype','000','Lock','-','N','-','N','" + GlobalUsage.Login_id + "','-'";
                GlobalUsage.hr_proxy.QueryExecute(qry, "exhrd");

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string qry = string.Empty;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                qry = "execute Insert_Modify_emp_bank_info '" + _empCode + "','bn','ifsc','actype','000','ReSend','-','N','-','N','" + GlobalUsage.Login_id + "','-'";
                GlobalUsage.hr_proxy.QueryExecute(qry, "exhrd");

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void rgv_data_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {

        }

        private void rgv_data_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Cells["file_path"].Value.ToString().Length > 10 && e.RowElement.RowInfo.Cells["lock_flag"].Value.ToString().ToUpper() == "Y")
                e.RowElement.ForeColor = Color.Green;
            else
                e.RowElement.ForeColor = Color.Black;

        }



        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStatus.Checked)
                chkStatus.Text = "Working";
            else
                chkStatus.Text = "Absconding";

            try
            {
                string qry = string.Empty;
                Cursor.Current = Cursors.WaitCursor;
                DialogResult res = MessageBox.Show("Do You want to Confirm ?", "ExPro Help", MessageBoxButtons.YesNo);
                if (chkStatus.Checked)
                    qry = "execute pEmployeeOnHoldMarking '" + _empCode + "','UN-Hold','" + GlobalUsage.Login_id + "'";
                else
                    qry = "execute pEmployeeOnHoldMarking '" + _empCode + "','Hold','" + GlobalUsage.Login_id + "'";

                GlobalUsage.hr_proxy.QueryExecute(qry, "exhrd");

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }


        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            alvImageViewer1.Rotate90Right();
        }
    }
}
