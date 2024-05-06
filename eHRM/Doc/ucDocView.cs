using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eHRM.Doc
{
    public partial class ucDocView : Telerik.WinControls.UI.RadForm
    {
        DataSet _ds = new DataSet();string _result = string.Empty;
        int _counter = 0;string _docID = string.Empty; byte[] fileContent = null;
        public ucDocView()
        {
            InitializeComponent();
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
            _docID = e.Row.Cells["autoid"].Value.ToString();
            fileContent =GlobalUsage.accounts_proxy.DownloadFile(e.Row.Cells["DocPath"].Value.ToString(), out _result);
            loadPDF(fileContent, "1");

        }

        private void ucDocView_Load(object sender, EventArgs e)
        {
            string qry = "select autoId, doc_type, docname, DocPath, DocVirtualPath, isActive from doc_master order by DocName; ";
            _ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "exhrd");
            rgv_search.DataSource = _ds.Tables[0];
        }
    }
}
