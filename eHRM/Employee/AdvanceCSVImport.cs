using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using Telerik.WinControls;

namespace eHRM
{
    public partial class AdvanceCSVImport : Telerik.WinControls.UI.RadForm
    {

        DataSet ds_csv = new DataSet();
        public AdvanceCSVImport()
        {
            InitializeComponent();
        }

        private DataSet GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataSet csvData = new DataSet();
            csvData.Tables.Add(new DataTable());
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Tables[0].Columns.Add(datecolumn);
                        //csvData.Columns.Add(app_date);
                    }
                    //csvData.Columns.Add("Date");
                    csvData.Tables[0].Columns.Add("adjDate", typeof(System.String));
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Tables[0].Rows.Add(fieldData);
                        foreach (DataRow dr in csvData.Tables[0].Rows)
                        {
                            dr["adjDate"] = rd_app_date.Value.ToString("yyyy/MM/dd");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
            }
            return csvData;
        }
        private void GetData()
        {
            if (txtFileName.Text.Trim() != string.Empty)
            {
                try
                {
                    ds_csv = null;
                    ds_csv = GetDataTabletFromCSVFile(txtFileName.Text);
                    gvr_data.DataSource = ds_csv.Tables[0].DefaultView;

                    lbl_browsecount.Text = ds_csv.Tables[0].Rows.Count.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                OpenFileDialog fdlg = new OpenFileDialog();
                fdlg.Title = "Select file";
                fdlg.InitialDirectory = @"c:\";
                fdlg.FileName = txtFileName.Text;
                fdlg.Filter = "Text and CSV Files(*.txt, *.csv)|*.txt;*.csv|Text Files(*.txt)|*.txt|CSV Files(*.csv)|*.csv|All Files(*.*)|*.*";
                fdlg.FilterIndex = 1;
                fdlg.RestoreDirectory = true;
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    string ext = fdlg.FileName.Substring(fdlg.FileName.Length - 4);

                    txtFileName.Text = fdlg.FileName;
                    if (txtFileName.Text == "")
                    {
                        txtFileName.Focus();
                        MessageBox.Show("Select File.");
                    }
                    else
                    {
                        //app_date = rd_app_date.Value.ToString("yyyy/MM/dd");
                        GetData();
                    }
                    Application.DoEvents();

                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnprocess_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string bulk_id = DateTime.Now.ToString("ddMMyyyyhhmmss");
            Import(bulk_id);
            GetPrcessedData(bulk_id);
            Cursor.Current = Cursors.Default;
        }
        public void Import(string bulk_id)
        {
            try
            {
                //ds_csv.WriteXml("C:\\Users\\IT\\Desktop\\csv.txt");
                string result = GlobalUsage.accounts_proxy.InsAdvSalayInfo_Bulk(ds_csv, GlobalUsage.Login_id, bulk_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetPrcessedData(string bulk_id)
        {
            try
            {
                string qry = "select e.emp_code,e.emp_name,adv_amount from Staff_adv_info sd inner join empdetail e on e.emp_code=sd.emp_code where bulk_import_id='" + bulk_id + "' order by emp_name";
                DataSet ds = GlobalUsage.accounts_proxy.GetQueryResult(qry, "exhrd");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvr_procc_data.DataSource = ds.Tables[0];

                    lbl_processedcount.Text = ds.Tables[0].Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AdvanceCSVImport_Load(object sender, EventArgs e)
        {
            rd_app_date.Value = System.DateTime.Now;
            Rectangle rec = Screen.PrimaryScreen.WorkingArea;
            int size = (rec.Size.Width - this.Width) / 2;
            this.Location = new System.Drawing.Point(size, 165);
        }
    }
}
