using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
namespace eHRM.mobile
{
    public partial class mobileBillChecking : Telerik.WinControls.UI.RadForm
    {
        string _qry = string.Empty; DataSet _ds = new DataSet();
        public mobileBillChecking()
        {
            InitializeComponent();
        }

        private void mobileBillChecking_Load(object sender, EventArgs e)
        {
            radDateTimePicker1.Value = DateTime.Today;
            _qry = "select mobile_no,worker_name,Branch,Status,Total,Payable from vodafone";
            _ds=GlobalUsage.accounts_proxy.GetQueryResult(_qry,"exhrd");
            rgv_info.DataSource = _ds.Tables[0];
            if (_ds.Tables[0].Rows.Count > 0)
                btnDel.Enabled = true;
            else
                btnDel.Enabled = false;

        }

        private void rbtn_excel_Click(object sender, EventArgs e)
        {
            try
            {
                #region Indent Import Process
              
                    Cursor.Current = Cursors.WaitCursor;
                    System.IO.StreamReader sr = new System.IO.StreamReader(rt_filename.Text);
                    string strline = string.Empty; string qry = string.Empty; string temp = string.Empty;
                    string[] _values = null;
                    int x = 0;
                   
                        #region Import Indent
                        while (!sr.EndOfStream)
                        {
                            if (x > 1)
                            {
                                strline = sr.ReadLine(); strline = strline.Replace("�", ""); _values = strline.Split(',');
                                _qry = "execute Insert_Modify_Vodafone '" + _values[0] + "','" + _values[1] + "','" + _values[2] + "','" + _values[3] + "'," + _values[4] + "," + _values[5] + "," + _values[6] + ",'Insert','N/A'";
                                GlobalUsage.accounts_proxy.QueryExecute(_qry, "exhrd");
                            } x++;
                        }
                        #endregion
                 
                    
                    sr.Close();
             
                #endregion

         
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            finally { Cursor.Current = Cursors.Default; }
          
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                #region Indent Import Process
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Comma Delimated CSV Files|*.csv";
                openFileDialog1.Title = "Select a CSV File";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    rt_filename.Text = openFileDialog1.FileName.ToString();
                }
                #endregion
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void rgv_info_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            radPdfViewer1.LoadDocument("d:\\vodapdf\\"+e.Row.Cells[0].Value.ToString()+"-"+radDateTimePicker1.Value.ToString("yyyyMM01")+".pdf");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                
                DialogResult res = MessageBox.Show("Do You Confirm To Delete ?", "ExPro Help", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor; 
                    _qry = "delete from vodafone;";
                    GlobalUsage.accounts_proxy.QueryExecute(_qry, "exhrd");
                    btnDel.Enabled = false;
                }
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }
    }
}
