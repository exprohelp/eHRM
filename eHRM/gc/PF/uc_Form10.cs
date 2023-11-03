using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Telerik.WinControls.UI;

namespace eHRM.gc.PF
{
    public partial class uc_Form10 : UserControl
    {
        string _Result = string.Empty;
        public uc_Form10()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                string qry = "execute  pGC_Pf_queries 'Form-10','"+rdp_date.Value.ToString("yyyy/MM/dd")+"','"+GlobalUsage.Login_id+"'";
                ds=GlobalUsage.accounts_proxy.GetQueryResult(qry, "exhrd");
                rgv_info.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ExPro Help",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnXL_Click(object sender, EventArgs e)
        {
            try
            {
               
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\HrReports";
                if (!System.IO.Directory.Exists(mydocpath))
                {
                    System.IO.Directory.CreateDirectory(mydocpath);
                }
                string fileName = mydocpath + "\\pf_Form10_" + rdp_date.Value.ToString("MMyyyy") + ".xls";
                Telerik.WinControls.UI.Export.ExportToExcelML exporter = new Telerik.WinControls.UI.Export.ExportToExcelML(this.rgv_info);
                exporter.ExportVisualSettings = true;
                exporter.RunExport(fileName);
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

        private void btnTextFile_Click(object sender, EventArgs e)
        {
            try
            {
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\HrReports";
                if (!System.IO.Directory.Exists(mydocpath))
                {
                    System.IO.Directory.CreateDirectory(mydocpath);
                }
                string fileName = mydocpath + "\\Pf_Form10_" + rdp_date.Value.ToString("MMyyyy") + ".txt";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                File.Create(fileName).Dispose();
                string line = string.Empty; string bind = string.Empty;
                using (TextWriter tw = new StreamWriter(fileName))
                {
                    foreach (GridViewRowInfo gvr in rgv_info.Rows)
                    {
                        line = string.Empty; 
                        if (bind.Length != 0)
                            bind += Environment.NewLine;
                        foreach (GridViewCellInfo gvc in gvr.Cells)
                        {
                            if (gvc.Value != null && gvc.Value.ToString().Length > 0)
                                if (gvc.ColumnInfo.Name.ToUpper().Contains("D O B") || gvc.ColumnInfo.Name.ToUpper().Contains("DOE"))
                                    line = line + Convert.ToDateTime(gvc.Value).ToString("dd/MM/yyyy") + "#~#";
                                else if (gvc.ColumnInfo.Name.ToString() == "Leave [M&Y]")
                                    line = line + Convert.ToDateTime(gvc.Value).ToString("MMyyyy") + "#~#";
                                else
                                    line = line + gvc.Value.ToString() + "#~#";
                            else
                                line = line + "#~#";
                        }
                        line = line.Substring(0, line.Length - 3);
                       
                        bind += line;
                    }

                    tw.WriteLine(line);
                    tw.Close();
                }
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

        private void rgv_info_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            //if (e.RowElement.RowInfo.Cells["New"].Value.ToString() == "New")
            //    e.RowElement.ForeColor = Color.Red;
            //else
            //    e.RowElement.ForeColor = Color.Green;

        }
    }
}
