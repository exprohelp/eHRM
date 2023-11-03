using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eHRM.Employee
{
    public partial class uc_resumeWorker : UserControl
    {
        string _result = string.Empty;string _empcode = string.Empty;
        public uc_resumeWorker()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime d = System.DateTime.Now;
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "All_Resign", "", "", "");
                dgEmpList.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btn_resume_Click(object sender, EventArgs e)
        {
            try
            {
                btn_resume.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;
                GlobalUsage.hr_proxy.QueryExecute("update empdetail set res_date=null , injob='Yes',updatedBy='"+GlobalUsage.Login_id+"',updatedFrom='Resume Resignation' where emp_code='"+_empcode+"'","exhrd");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void dgEmpList_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            _empcode = e.Row.Cells["emp_code"].Value.ToString();
            btn_resume.Enabled = true;
        }
    }
    }

