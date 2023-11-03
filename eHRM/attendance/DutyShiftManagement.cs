using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace eHRM.attendance
{
    public partial class DutyShiftManagement : Telerik.WinControls.UI.RadForm
    {
        string _result = string.Empty;
        string _emp_code = string.Empty;
        public DutyShiftManagement()
        {
            InitializeComponent();
        }
        #region Shift CREATION
        private string InShift()
        {
            return ddlInHH.Text + ":" + ddlInMM.Text + " " + ddlInAP.Text;
        }
        private string OutShift()
        {
            return ddlOutHH.Text + ":" + ddlOutMM.Text + " " + ddlOutAP.Text;
        }
        private void ddlInHH_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            txtInshift.Text = InShift();
        }
        private void ddlInMM_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            txtInshift.Text = InShift();
        }
        private void ddlInAP_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            txtInshift.Text = InShift();
        }
        private void ddlOutHH_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            txtOutShift.Text = OutShift();
        }
        private void ddlOutMM_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            txtOutShift.Text = OutShift();
        }
        private void ddlOutAP_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            txtOutShift.Text = OutShift();
        }
        #endregion
        private void DutyShiftManagement_Load(object sender, EventArgs e)
        {

            try
            {
                dtShiftDate.Value = System.DateTime.Now;
                GlobalUsage.hr_proxy = new HumanResource.Staff_ManagementSoapClient();
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "EmpListForDutyShift", "", "", "");
                dgEmpList.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }


        private void ShiftInformation()
        {
            try
            {
                _emp_code = dgEmpList.CurrentRow.Cells["emp_code"].Value.ToString();
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = GlobalUsage.hr_proxy.HR_Queries(out _result, "CHCL", "DutyShiftListofEmployee", _emp_code, "", "");
                dgShift.DataSource = ds.Tables[0];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtInshift.Text.Length == 8 && txtOutShift.Text.Length == 8)
                {
                    _result = GlobalUsage.hr_proxy.Insert_Modify_dutyShift_Info(0, _emp_code, dtShiftDate.Value.ToString("yyyy/MM/dd"), txtInshift.Text, txtOutShift.Text, txtdutybreack.Text, GlobalUsage.Login_id, "Insert");
                    if (_result.Contains("Success"))
                    { ShiftInformation(); }
                    else
                    { MessageBox.Show(_result); }
                }
                else
                { MessageBox.Show("In shift or out shift is not in correct formate "); }
            }
            catch (Exception ex) { }
            finally { Cursor.Current = Cursors.Default; }
        }



        private void radButton2_Click(object sender, EventArgs e)
        {
            _result = GlobalUsage.hr_proxy.QueryExecute("update empdetail set netpassword='123' where emp_code='" + _emp_code + "'  ", "ExHrd");
            MessageBox.Show(_result);
        }

        private void dgEmpList_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            ShiftInformation();
        }

        private void dgShift_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.CellElement is GridCommandCellElement)
            {
                if (((GridCommandCellElement)e.CellElement).ColumnInfo.Name == "column2")
                {
                    ((GridCommandCellElement)e.CellElement).CommandButton.Alignment = ContentAlignment.MiddleCenter;

                    //((GridCommandCellElement)e.CellElement).CommandButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
                    if (e.CellElement.RowInfo.Cells["act_flag"].Value.ToString() == "Y")
                    {
                        //((GridCommandCellElement)e.CellElement).CommandButton.Image = Resources.attachment;
                        //((GridCommandCellElement)e.CellElement).CommandButton.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                        ((GridCommandCellElement)e.CellElement).CommandButton.Text = "A";

                    }
                    else
                        ((GridCommandCellElement)e.CellElement).CommandButton.Text = "D";

                }
            }
        }

        private void dgShift_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string actLogic = dgShift.CurrentRow.Cells["act_flag"].Value.ToString();
                string autoID = dgShift.CurrentRow.Cells["auto_id"].Value.ToString();
                if (((sender as Telerik.WinControls.UI.GridCommandCellElement)).ColumnInfo.Name.ToString() == "column1")
                {
                    if (txtInshift.Text.Length == 8 && txtOutShift.Text.Length == 8)
                    {
                        _result = GlobalUsage.hr_proxy.Insert_Modify_dutyShift_Info(Convert.ToInt32(dgShift.CurrentRow.Cells["auto_id"].Value), _emp_code, dtShiftDate.Value.ToString("yyyy/MM/dd"), txtInshift.Text, txtOutShift.Text, txtdutybreack.Text, GlobalUsage.Login_id, "Delete");
                        if (_result.Contains("Success"))
                        { ShiftInformation(); }
                        else
                        { MessageBox.Show(_result); }
                    }
                    else
                    { MessageBox.Show("In shift or out shift is not in correct formate "); }
                }
                else
                {
                    if (actLogic == "Y")
                    {
                        GlobalUsage.accounts_proxy.QueryExecute("update dutyshift_info set act_flag='N' where auto_id=" + autoID, "exhrd");
                        dgShift.CurrentRow.Cells["act_flag"].Value = "N";
                    }
                    else
                    {
                        GlobalUsage.accounts_proxy.QueryExecute("update dutyshift_info set act_flag='Y' where auto_id=" + autoID, "exhrd");
                        dgShift.CurrentRow.Cells["act_flag"].Value = "Y";
                    }

                }
            }
            catch (Exception ex) { }
            finally { Cursor.Current = Cursors.Default; }
        }
    }
}
