using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eHRM.cv
{
    public partial class ucCV_Search : Telerik.WinControls.UI.RadForm
    {
        DataSet _ds = new DataSet();string _result = string.Empty;
        int _counter = 0;string _docID = string.Empty; byte[] fileContent = null;
        public ucCV_Search()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string qry = "SELECT [cv_id], [cv_name], [cv_type], mobileNo,cvFilePath ";
            qry += "FROM[ExHrd].[dbo].[cv_master] where "+rlFields.SelectedValue.ToString()+" "+cmbOperator.Text+" '"+txtValue.Text+"' and isActive = 'Y'";

            _ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "exhrd");
            rgv_search.DataSource = _ds.Tables[0];
        }

        private void loadPDF(byte[] data, string DocType)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (data.Length > 0)
                {
                    _counter++;

                    string path = Application.StartupPath + "\\tempimg\\" + _docID + "_" + DocType + ".pdf";
                    if (!System.IO.File.Exists(path))
                    {
                        System.IO.File.WriteAllBytes(path, data);
                    }
                    radpdfViewer.LoadDocument(path);
                }
                else
                { MessageBox.Show("Report not uploaded"); }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void rgv_search_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            _docID = e.Row.Cells["cv_id"].Value.ToString();
            fileContent =GlobalUsage.accounts_proxy.DownloadFile(e.Row.Cells["cvFilePath"].Value.ToString(), out _result);
            loadPDF(fileContent, "1");

        }

        private void ucCV_Search_Load(object sender, EventArgs e)
        {
            //select Column_name from Information_schema.columns where Table_name like 'v_empdetail'

            string qry = "select Column_name from Information_schema.columns where Table_name='CV_Master' ";
            _ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "exhrd");
         

            rlFields.DataSource = _ds.Tables[0];
            rlFields.ValueMember = "Column_name";
            rlFields.DisplayMember = "Column_name";
        }
    }
}
