using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.Letter
{
    public partial class wa_letters : UserControl
    {
        DataSet _ds = new DataSet(); string _result = string.Empty; string _empCode = string.Empty;string _messageID = string.Empty;
        public wa_letters()
        {
            InitializeComponent();
        }

        private void wa_letters_Load(object sender, EventArgs e)
        {
            rdp_from.Value = DateTime.Today;
            rdTo.Value = DateTime.Today;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;


                _ds = GlobalUsage.hr_proxy.HR_Queries(out _result, cmbCompId.Text, "WA_LettersStaffList", "p1", "p2", "p3");
                rgv_info.DataSource = _ds.Tables[0];

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void MasterTemplate_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                rgbInfo.Text = e.Row.Cells["emp_name"].Value.ToString();
                _empCode = e.Row.Cells["emp_code"].Value.ToString();
                _ds = GlobalUsage.hr_proxy.HR_Queries(out _result, cmbCompId.Text, "WA_LettersList", _empCode, "p2", "p3");
                ddl_letters.Items.Clear();
                this.ddl_letters.SelectedIndexChanged -= new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddl_letters_SelectedIndexChanged);
                ddl_letters.Items.AddRange(GlobalUsage.FillTelrikCombo(_ds.Tables[0]));
                ddl_letters.SelectedIndex = 0;
                this.ddl_letters.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddl_letters_SelectedIndexChanged);

                foreach (DataRow dr in _ds.Tables[1].Rows)
                {
                    if (dr["letterType"].ToString() == "Warning-Letter")
                        lblWarningLetter.Text = "Warning Letter [" + dr["NoS"].ToString() + "]";
                    else
                        lblWarningLetter.Text = "Appriciation Letter [" + dr["NoS"].ToString() + "]";
                }

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void ddl_letters_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (ddl_letters.SelectedText.ToString().ToUpper() == "SELECT")
            {
                btnFiled.Visible = false;
                return;
            }
            try
            {
                _messageID = ddl_letters.SelectedValue.ToString();
                _ds = GlobalUsage.hr_proxy.HR_Queries(out _result, cmbCompId.Text, "WA_LettersInfo", _empCode, _messageID, "p3");
                StringBuilder sb = new StringBuilder();
                sb.Append("<html><body>");
                sb.Append("<Table>");
                sb.Append("<tr><td style='text-align:left'> Letter No:" + _ds.Tables[0].Rows[0]["LetterNo"].ToString() + " Letter Type : " + _ds.Tables[0].Rows[0]["letterType"].ToString() + " </td></tr>");
                sb.Append("<tr><td  style='text-align:left'> From:" + _ds.Tables[0].Rows[0]["LetterBy"].ToString() + " To : " + _ds.Tables[0].Rows[0]["LetterTo"].ToString() + " </td></tr>");
                sb.Append("<tr><td  style='text-align:left'>  [" + _ds.Tables[0].Rows[0]["subject"].ToString() + "] Dated : " + _ds.Tables[0].Rows[0]["Co_Date"].ToString() + " </td></tr>");
                sb.Append("</Table>");

                sb.Append("<table style='width:100%'>");
                foreach (DataRow dr in _ds.Tables[0].Rows)
                {
                    if(_ds.Tables[0].Rows[0]["Filed_Flag"].ToString()=="N")
                    btnFiled.Visible = true;

                    sb.Append("<tr>");
                    sb.Append("<td style='width:100%;font-size:15px'><B>Letter Content</B></td></br>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td style='width:100%;font-size:15px'>" + dr["Conversation"].ToString() + "</td>");
                    sb.Append("</tr>");

                }
                sb.Append("</table>");
                sb.Append("</body></html>");
                webBrowser1.DocumentText = sb.ToString();

            }
            catch (Exception ex) { }


        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
              
                _ds = GlobalUsage.hr_proxy.HR_Queries(out _result, cmbCompId.Text, "WA_LettersSummary", rdp_from.Value.ToString("yyyyMMdd"), rdTo.Value.ToString("yyyyMMdd"), "p3");
                rg_detail.DataSource = _ds.Tables[0];

                foreach (var col in rg_detail.Columns)
                {
                    col.BestFit();
                }

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void rdp_from_Leave(object sender, EventArgs e)
        {
            rdTo.MinDate = rdp_from.Value;
        }

        private void btnXL_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\HrReports";
                if (!System.IO.Directory.Exists(mydocpath))
                {
                    System.IO.Directory.CreateDirectory(mydocpath);
                }
                string fileName = mydocpath + "\\WA_LetterReport.xlsx";
                ExcelGenerator exlobj = new ExcelGenerator();
                byte[] data = exlobj.GetExcelFile(_ds);
                System.IO.File.WriteAllBytes(fileName, data);
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

        private void btnFiled_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                _ds = GlobalUsage.hr_proxy.HR_Queries(out _result, cmbCompId.Text, "WA_Filed", _messageID, GlobalUsage.Login_id, "p3");
                btnFiled.Visible = false;

            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }
    }
}
