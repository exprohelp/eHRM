using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM.Masters
{
    public partial class Add_Vaccine : Telerik.WinControls.UI.RadForm
    {
        string _result = string.Empty;
        public Add_Vaccine()
        {
            InitializeComponent();
        }

        private void Add_Vaccine_Load(object sender, EventArgs e)
        {
            Refresh_Grid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbType.Text.ToUpper() == "SELECT" || rtbFreq.Text.Length==0)
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //string qry = "execute dbo.Insert_Modify_m_CheckupsVaccines @cv_Name,@cv_type,@cv_freqDays,@isActive,@Logic,@login_id,@result)";
                string qry = "execute dbo.Insert_Modify_m_CheckupsVaccines '"+txtName.Text+"','"+cmbType.Text+"',"+rtbFreq.Text+",'Y','Merge','"+GlobalUsage.Login_id+"','-';";
                GlobalUsage.hr_proxy.QueryExecute(qry, "exhrd");
                Refresh_Grid();
                txtName.Text = "";
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void Refresh_Grid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "=", "VaccineList", "-", "-", "p3");
                rgv_info.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void rgv_info_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string flag = "N";
                if (e.Row.Cells["isactive"].Value.ToString() == "Y")
                    flag = "N";
                else
                    flag = "Y";

                GlobalUsage.hr_proxy.QueryExecute("update m_CheckupsVaccines set isActive='" + flag+ "' , updatedBy='"+GlobalUsage.Login_id+ "',updationDate=getdate() where coverageId='" + e.Row.Cells["coverageId"].Value.ToString() + "'", "exhrd");
                Refresh_Grid();
            }
            catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
            finally { Cursor.Current = Cursors.Default; }
        }
    }
}
