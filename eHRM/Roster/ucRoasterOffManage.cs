using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.Roster
{
    public partial class ucRoasterOffManage : UserControl
    {
        string[] StatusList = { "Y", "N"};
        string _oldValue = string.Empty;
        string _newValue = string.Empty;
        public ucRoasterOffManage()
        {
            InitializeComponent();
        }
        private void PopulateStatusList()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("isAllowed", typeof(string));
                foreach (string s in StatusList)
                {
                    DataRow dr = dt.NewRow();
                    dr["isAllowed"] = s;
                    dt.Rows.Add(dr);
                }
                Cursor.Current = Cursors.WaitCursor;
                Telerik.WinControls.UI.GridViewComboBoxColumn reportsColumn = ((Telerik.WinControls.UI.GridViewComboBoxColumn)rgvInfo.Columns[10]);
                reportsColumn.Width = 65;
                reportsColumn.AllowFiltering = false;
                reportsColumn.ValueMember = "isAllowed";
                reportsColumn.DisplayMember = "isAllowed";
                reportsColumn.DataSource = dt; ;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void ucRoasterOffManage_Load(object sender, EventArgs e)
        {
            dtpDate.MinDate = DateTime.Now.AddDays(-30);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                string qry = "execute pRosterOffManagement '" + dtpDate.Value.ToString("yyyy-MM-dd") + "','GetData','-','-','-','" + GlobalUsage.Login_id + "';";
                
                ds=GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHRD");
                if(ds.Tables[0].Rows.Count>0)
                {
                    DialogResult res = MessageBox.Show("Do You want to Regenerate", "ExPro Help", MessageBoxButtons.YesNo);
                    if(res==DialogResult.Yes)
                    {
                        qry = "execute pRosterOffManagement '" + dtpDate.Value.ToString("yyyy-MM-dd") + "','Generate','-','-','-','" + GlobalUsage.Login_id + "';";
                        GlobalUsage.hr_proxy.QueryExecute(qry, "ExHRD");
                    }
                }
                else
                {
                    ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHRD");
                   
                }
                rgvInfo.DataSource = ds.Tables[0];
                PopulateStatusList();
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnFillRecords_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                string qry = "execute pRosterOffManagement '" + dtpDate.Value.ToString("yyyy-MM-dd") + "','GetData','-','-','-','" + GlobalUsage.Login_id + "';";

                ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHRD");
                PopulateStatusList();
                rgvInfo.DataSource = ds.Tables[0];
               
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void rgvInfo_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Cells[10].Value.ToString() == "Y")
                e.RowElement.ForeColor = Color.Green;
            else
                e.RowElement.ForeColor = Color.Black;
        }

        private void rgvInfo_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.ColumnIndex==10)
            {
                string empcode = e.Row.Cells[0].Value.ToString();
                if (e.Row.Cells[e.ColumnIndex].Value.ToString()!=_oldValue)
                {
                    string qry = "execute pRosterOffManagement '" + dtpDate.Value.ToString("yyyy-MM-dd") + "','isAllowed','" + empcode+"','"+ e.Row.Cells[e.ColumnIndex].Value.ToString() + "','-','" + GlobalUsage.Login_id + "';";
                    GlobalUsage.hr_proxy.QueryExecute(qry, "ExHRD");
                }
            }
        }

        private void rgvInfo_CellBeginEdit(object sender, Telerik.WinControls.UI.GridViewCellCancelEventArgs e)
        {
            _oldValue = e.Row.Cells[e.ColumnIndex].Value.ToString();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DataSet ds = new DataSet();
                string qry = "execute pRosterOffManagement '" + dtpDate.Value.ToString("yyyy-MM-dd") + "','TransferList','-','-','-','" + GlobalUsage.Login_id + "';";

                ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "ExHRD");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DialogResult res = MessageBox.Show("Do You want to Re-Transfer", "ExPro Help", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        qry = "execute pRosterOffManagement '" + dtpDate.Value.ToString("yyyy-MM-dd") + "','Transfer','-','-','-','" + GlobalUsage.Login_id + "';";
                        GlobalUsage.hr_proxy.QueryExecute(qry, "ExHRD");
                    }
                }
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }
    }
}

