using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.Employee
{
    public partial class StaffOrgDocsCreation : UserControl
    {
        string _empCode = string.Empty;
        public StaffOrgDocsCreation()
        {
            InitializeComponent();
        

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

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            orgDocuments o = new orgDocuments();
            o.emp_code = _empCode;o.DoD = rdpDOD.Value.ToString("yyyy-MM-dd");
            o.docNme = txtDoc.Text;o.depositedBy = GlobalUsage.Login_id;o.DoR = "1900-01-01";
            o.Logic = "Insert";o.Remarks = txtRemarks.Text;
            resultSetMIS dwr = MISProxy.CallMISWebApiMethod("Hrm/Insert_Modify_EmpOrgDocs", o);
            Refresh_Grid();
        }

        private void StaffOrgDocsCreation_Load(object sender, EventArgs e)
        {
            rdpDOD.Value = DateTime.Today;
            Refresh_Grid();
     

        }
        private void Refresh_Grid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.GetQueryResult("select autoid,emp_code,docNme,Dod=format(dod,'dd-MM-yyyy'),depositedBy,remarks from empOrgDocs", "exhrd");
                rgvDocs.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void rgv_staff_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            _empCode = e.Row.Cells["emp_code"].Value.ToString();
            radGroupBox1.Text= e.Row.Cells["emp_name"].Value.ToString();
        }

        private void rgvDocs_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string qry = "delete from empOrgDocs where autoID='" + e.Row.Cells["autoid"].Value.ToString() + "' and cast(getdate() as date)=cast(dod as date)";
                DataSet ds = GlobalUsage.hr_proxy.GetQueryResult(qry, "exhrd");
                Refresh_Grid();
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }
    }
}
