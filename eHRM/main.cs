using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace eHRM
{
    public partial class main : Telerik.WinControls.UI.RadRibbonForm
    {
        string _result = string.Empty; Size size = new Size();
        DataSet _dsNotification = new DataSet();
        int flags = 0;
        public main()
        {
            InitializeComponent();
        }

        private void rbe_calculator_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void rbe_software_Click(object sender, EventArgs e)
        {
            openForm(new AutoUpdater());
        }


        private void openForm(Form UseForm)
        {
            Cursor.Current = Cursors.WaitCursor;
            UseForm.Owner = this;
            UseForm.Show();
            Cursor.Current = Cursors.Default;
        }
        private void OpenControl(System.Windows.Forms.UserControl obj, string Title)
        {
            Cursor.Current = Cursors.WaitCursor;
            MasterForm useForm = new MasterForm(obj, Title);
            useForm.Owner = this;
            useForm.Show();
            Cursor.Current = Cursors.Default;
        }

        private void att_bio_analysis_Click(object sender, EventArgs e)
        {
            OpenControl(new attendance.uc_StaffAttendance("HR"), "Bio-Metric Attendance Analysis");
        }

        private void emp_incr__letters_Click(object sender, EventArgs e)
        {
            openForm(new increments.ucIncreamentMaster());
            //OpenControl(new increments.uc_Letters(), "Generate Increment Letters");
        }

        private void main_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            GlobalUsage.UniqueMachineId = accounts_library.UniqueMachineId.GetMACAddress();
            this.Text = "eHRM Ver. " + Application.ProductVersion.ToString();
            GlobalUsage.accounts_proxy = new rmAccounts.Accounts_WebServiceSoapClient();
            GlobalUsage.hr_proxy = new HumanResource.Staff_ManagementSoapClient();
            GlobalUsage.Division = "Diagnostic";
            Rectangle rec = Screen.PrimaryScreen.WorkingArea;
            size = rec.Size;
            int x, y = 0;
            x = this.Width - (GbLoginBox.Width + 30);
            y = this.Height - (GbLoginBox.Height + radStatusStrip1.Height + 180);
            GbLoginBox.Location = new Point(x, y);
            rrb_menu.Enabled = false;
            txtLogin_Id.Focus();
        }
        private void TransferInfoTo_ITS()
        {
            try
            {
                string macAddress = accounts_library.UniqueMachineId.Value();
                string MachineName = Environment.MachineName.ToString();
                string appVersion = Application.ProductVersion.ToString();
                string appName = Application.ProductName.ToString();

                GlobalUsage.accounts_proxy.Insert_Modify_MacInfo("Biotech", macAddress, GlobalUsage.Login_id, appName, MachineName, appVersion, "N", "Startup");
            }
            catch (Exception ex) { }
        }
        private void rbtn_Login_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            rbtn_Login.Enabled = false;

            string result = GlobalUsage.accounts_proxy.AuthenticateLogin("N/A", txtLogin_Id.Text, txtPassword.Text, "eHRM", "N/A", "N/A");
            string[] r = result.Split('#');
            if (r[0] == "1")
            {
                GlobalUsage.Login_id = txtLogin_Id.Text;
                if (GlobalUsage.Login_id == "CHL-02809")
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        DialogResult res = MessageBox.Show("Do You want to Rebuild Menu Options? ", "ExPro Help", MessageBoxButtons.YesNo);
                        if(res==DialogResult.Yes)
                        ControlLog();

                    }
                    catch (Exception ex) { RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.OK, RadMessageIcon.Info); }
                    finally { Cursor.Current = Cursors.Default; }


                }
                else
                    EnableAccordingToRights();


                TransferInfoTo_ITS();
                rrb_menu.Enabled = true;
                GbLoginBox.Visible = false;
            }
            else
            {
                txtLogin_Id.Text = "";
                txtPassword.Text = "";
                txtLogin_Id.Focus();
                rbtn_Login.Enabled = true;
            }
            Cursor.Current = Cursors.Default;

        }
        public void ControlLog()
        {
            #region Command Tab Menu
            for (int i = 0; i < this.rrb_menu.CommandTabs.Count; i++)
            {
                RibbonTab ribbonTab = this.rrb_menu.CommandTabs[i] as RibbonTab;
                for (int j = 0; j < ribbonTab.Items.Count; j++)
                {
                    RadRibbonBarGroup ribbonBarGroup = ribbonTab.Items[j] as RadRibbonBarGroup;
                    for (int k = 0; k < ribbonBarGroup.Items.Count; k++)
                    {
                        RadItem currentItem = ribbonBarGroup.Items[k];
                        if (currentItem.GetType().ToString() == "Telerik.WinControls.UI.RadButtonElement")
                        {
                            string qry = "execute Insert_Modify_menu_master '" + Application.ProductName + "','" + ribbonTab.Name.ToString() + "','" + ribbonTab.Text + "','" + ribbonBarGroup.Name.ToString() + "','" + ribbonBarGroup.Text + "','" + currentItem.Name.ToString() + "','" + currentItem.Text + "','-','Y','Insert','' ";
                            string RESULT = GlobalUsage.hr_proxy.QueryExecute(qry, "eManagement");
                        }
                        else if (currentItem.GetType().ToString() == "Telerik.WinControls.UI.RadRibbonBarButtonGroup")
                        {
                            RadRibbonBarButtonGroup ribbonBarButtonGroup = ribbonBarGroup.Items[k] as RadRibbonBarButtonGroup;
                            for (int l = 0; l < ribbonBarButtonGroup.Items.Count; l++)
                            {
                                RadItem currentItem2 = ribbonBarButtonGroup.Items[l];
                                if (currentItem2.GetType().ToString() == "Telerik.WinControls.UI.RadButtonElement")
                                {
                                    string qry = "execute Insert_Modify_menu_master '" + Application.ProductName + "','" + ribbonTab.Name.ToString() + "','" + ribbonTab.Text + "','" + ribbonBarGroup.Name.ToString() + "','" + ribbonBarGroup.Text + "','" + currentItem2.Name.ToString() + "','" + currentItem2.Text + "','-','Y','Insert','' ";
                                    GlobalUsage.hr_proxy.QueryExecute(qry, "eManagement");
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }
        private void EnableAccordingToRights()
        {
            try
            {
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                var menu = GlobalUsage.hr_proxy.GetQueryResult("select element_name,Allow=isActive from AppMenu_rights where appName='eHRM' and emp_code='" + GlobalUsage.Login_id + "'", "eManagement")
                .Tables[0].AsEnumerable()
                .Select(o => new
                {
                    menuName = o.Field<string>("element_name"),
                    allow_flag = o.Field<string>("allow")
                }).ToList();

                foreach (RadElement el in rrb_menu.RootElement.ChildrenHierarchy)
                {
                    if (el.GetType().ToString() == "Telerik.WinControls.UI.RadButtonElement")
                    {
                        string d = el.GetType().ToString();
                        var T = menu.Where(X => X.menuName == el.Name && X.allow_flag == "Y");
                        if (T.Count() > 0)
                        {
                            rrb_menu.Enabled = true;
                            el.Enabled = true;
                        }
                        else
                            el.Enabled = false;
                    }
                }

                #region quick Access Tool Bar
                for (int i = 0; i < this.rrb_menu.QuickAccessToolBar.Items.Count; i++)
                {
                    RadItem currentItem = rrb_menu.QuickAccessToolBar.Items[i];
                    currentItem.Enabled = true;
                }
                #endregion
            }
            catch (Exception ex) { Telerik.WinControls.RadMessageBox.Show(ex.Message, "ExPro Help", MessageBoxButtons.YesNo, RadMessageIcon.Info); }
            finally { System.Windows.Forms.Cursor.Current = Cursors.Default; }
        }


        private void Sal_sal_Basic_Click(object sender, EventArgs e)
        {
            OpenControl(new Salary.uc_SalaryStructure(), "Basic Salary Sheet");
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                rbtn_Login.PerformClick();
        }

        private void Sal_Sal_Slip_Click(object sender, EventArgs e)
        {
            OpenControl(new accounts_library.ucSalarySlip(GlobalUsage.Login_id), "Salary Slip");
        }

        private void gc_pf_ecr_Click(object sender, EventArgs e)
        {
            OpenControl(new eHRM.gc.PF.uc_pf_ecr(), "PF: Electronic Challan Cum Return (ECR)");
        }

        private void gc_pf_form5_Click(object sender, EventArgs e)
        {
            OpenControl(new eHRM.gc.PF.uc_Form5(), "PF: New Member Joining Form");
        }

        private void gc_pf_form10_Click(object sender, EventArgs e)
        {
            OpenControl(new eHRM.gc.PF.uc_Form10(), "PF: Member Leaving The Service");
        }

        private void rbe_emp_dutyTime_Click(object sender, EventArgs e)
        {
            openForm(new attendance.DutyShiftManagement());
        }

        private void rbe_SalaryAtt_Info_Click(object sender, EventArgs e)
        {
            openForm(new attendance.Att_SalaryDetail());
        }

        private void rbe_EmpNewEdit_Click(object sender, EventArgs e)
        {
            openForm(new Employee.EmployeeMasterNew2("Operator"));
        }

        private void rbe_StaffCareer_Click(object sender, EventArgs e)
        {
            openForm(new Employee.careerMap());
        }

        private void rbe_RawData_Click(object sender, EventArgs e)
        {
            openForm(new Employee.rawdata());
        }


        private void rbe_voda_checking_Click(object sender, EventArgs e)
        {
            openForm(new mobile.mobileBillChecking());
        }

        private void rbe_Ins_JInfo_Click(object sender, EventArgs e)
        {
            openForm(new Insurance.InsuranceReport("AddInfo", "New Addition of Employee"));
        }

        private void rbe_Ins_DInfo_Click(object sender, EventArgs e)
        {
            openForm(new Insurance.InsuranceReport("ResInfo", "Deletion of Employee"));
        }

        private void rbe_utl_ediagnostic_Click(object sender, EventArgs e)
        {
            openForm(new utility.menuRights("eDiagnostic"));
        }

        private void rbe_att_correction_Click(object sender, EventArgs e)
        {
            openForm(new attendance.Att_correction());
        }

        private void radButtonElement6_Click(object sender, EventArgs e)
        {
            openForm(new Employee.belongingForm());
        }

        private void radButtonElement7_Click(object sender, EventArgs e)
        {
            openForm(new Employee.belongingRegister());
        }

        private void rbe_emp_transfer_Click(object sender, EventArgs e)
        {
            openForm(new Employee.TransferForm());
        }

        private void rbe_setManager_Click(object sender, EventArgs e)
        {
            openForm(new utility.SetManager());
        }

        private void rbe_Emp_Documents_Click(object sender, EventArgs e)
        {
            openForm(new Employee.Documents());
        }

        private void rbe_utl_eMediShop_Click(object sender, EventArgs e)
        {
            openForm(new utility.menuRights("eMediShop"));
        }

        private void rbe_leave_history_Click(object sender, EventArgs e)
        {
            OpenControl(new eHRM.attendance.uc_LeaveHistory(), "Leave Information of Individual Employee");
        }

        private void rbe_sal_adv_entry_Click(object sender, EventArgs e)
        {
            OpenControl(new eHRM.Salary.ucAdvanceFeeding(), "Advance Entry");
        }

        private void rbe_emis_Click(object sender, EventArgs e)
        {
            openForm(new utility.menuRights("eMIS"));
        }

        private void rbe_sal_adv_register_Click(object sender, EventArgs e)
        {

        }

        private void rbe_pushSlip_Click(object sender, EventArgs e)
        {
            openForm(new Salary.ucPushSalarySlip());
        }

        private void rbe_Form11_Click(object sender, EventArgs e)
        {
            openForm(new gc.PF.pfForm11());
        }

        private void rbe_ForMeeting_Click(object sender, EventArgs e)
        {
            openForm(new Employee.SalaryStructureSheet());
        }

        private void rbe_newjoining_Click(object sender, EventArgs e)
        {
            openForm(new Employee.NewJoingReport());
        }

        private void rbe_adv_blk_upload_Click(object sender, EventArgs e)
        {
            openForm(new AdvanceCSVImport());
        }

        private void rbe_BankInfo_Click(object sender, EventArgs e)
        {
            openForm(new Employee.BankInfo());
        }

        private void rbe_e_Click(object sender, EventArgs e)
        {
            openForm(new utility.menuRights("eHRM"));
        }

        private void rbe_eMediCentral_Click(object sender, EventArgs e)
        {
            openForm(new utility.menuRights("eMediCentral"));
        }

        private void radButtonElement4_Click(object sender, EventArgs e)
        {
            openForm(new WorkingDay());
        }

        private void rbeIncrregister_Click(object sender, EventArgs e)
        {
            openForm(new increments.incrementInfo());
        }

        private void radButtonElement8_Click(object sender, EventArgs e)
        {
            //OpenControl(new eHRM.increments.uc_NewIncrementEntry(), "Increments Add/Modify");
            //openForm(new increments.NewIncrementEntry());
            openForm(new increments.IncrementEntryNew());
        }

        private void rbe_eAccounts_Click(object sender, EventArgs e)
        {
            openForm(new utility.menuRights("eAccounts"));
        }

        private void rbe_att_summarization_Click(object sender, EventArgs e)
        {
            OpenControl(new eHRM.ucAttendanceProcess(), "Generate Summary of Attendance");
        }

        private void rbe_resume_Click(object sender, EventArgs e)
        {
            OpenControl(new eHRM.Employee.uc_resumeWorker(), "Resume Resigned Worker");
        }

        private void rbe_resign_Click(object sender, EventArgs e)
        {
            openForm(new Employee.doResign());
        }

        private void setReporting_Click(object sender, EventArgs e)
        {
            openForm(new Employee.setReporting());
        }

        private void rbe_Letters_Click(object sender, EventArgs e)
        {
            openForm(new Letter.LetterMaster());
        }

        private void rbeAttConfirmation_Click(object sender, EventArgs e)
        {
            openForm(new attendance.AttCorrectionConfirmation());
        }

        private void rbeRosterMaster_Click(object sender, EventArgs e)
        {
            openForm(new attendance.RosterMaster());
        }

        private void rbe_designation_Click(object sender, EventArgs e)
        {
            openForm(new Masters.Add_Designation());
        }
        
        private void rbe_LoanInfo_Click(object sender, EventArgs e)
        {
            openForm(new Employee.LoanManagement());
        }

        private void rbe_confirmation_Click(object sender, EventArgs e)
        {
            openForm(new attendance.AttCorrectionConfirmation());
        }

        private void rbe_weekdayOff_Click(object sender, EventArgs e)
        {
            openForm(new WorkingDay());
        }

        private void rbe_QI_Click(object sender, EventArgs e)
        {
            OpenControl(new NABH.ucQualityIndicator(), "Quality Indicator");
        }

        private void rbe_MapCategory_Click(object sender, EventArgs e)
        {
            OpenControl(new Employee.uc_SetCategory(), "Mapping of Category Against Staff");
        }

        private void rbeCategory_Click(object sender, EventArgs e)
        {
            openForm(new Masters.Add_Category());
        }
        private void rbeCreateLogin_Click(object sender, EventArgs e)
        {
            OpenControl(new utility.ucCreateLogin(), "Allot Application To Staff");
        }

        private void rbeApproveJoining_Click(object sender, EventArgs e)
        {
            openForm(new Employee.EmployeeMasterNew2("Manager"));
        }

        private void rbeForAccount_Click(object sender, EventArgs e)
        {
            OpenControl(new Employee.ucEmployeesOptions(), "Punching,TDS,Trust Donation Options");
        }

        private void rbeNewLoan_Click(object sender, EventArgs e)
        {
            OpenControl(new ucNewLoan(), "New Loan Process");
        }

        private void rbeSalaryProcess_Click(object sender, EventArgs e)
        {
            openForm(new Salary.ProcessSalary());
        }

        private void rbeProfBill_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Salary.ProfessionlSlip obj = new Salary.ProfessionlSlip();
            MasterForm useForm = new MasterForm(obj, "Professional Slip");
            useForm.Owner = this;
            useForm.Show();
            Cursor.Current = Cursors.Default;
        }

        private void rbeWA_Letters_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Letter.wa_letters obj = new Letter.wa_letters();
            MasterForm useForm = new MasterForm(obj, "Warning/Appriciation Letters");
            useForm.Owner = this;
            useForm.Show();
            Cursor.Current = Cursors.Default;
        }

        private void rbe_VaccineCheckups_Click(object sender, EventArgs e)
        {
            openForm(new Masters.Add_Vaccine());
        }

        private void rbe_imu_training_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Employee.ucEmployeesCheckups obj = new Employee.ucEmployeesCheckups();
            MasterForm useForm = new MasterForm(obj, "Immunisation And Training Records");
            useForm.Owner = this;
            useForm.Show();
            Cursor.Current = Cursors.Default;
        }

        private void rbeExperence_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Employee.ucEmpExperience obj = new Employee.ucEmpExperience();
            MasterForm useForm = new MasterForm(obj, "Experience Information");
            useForm.Owner = this;
            useForm.Show();
            Cursor.Current = Cursors.Default;
        }

        private void rbe_DrSignature_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Masters.ucDoctorSignature obj = new Masters.ucDoctorSignature();
            MasterForm useForm = new MasterForm(obj, "Doctor Signature Uploading");
            useForm.Owner = this;
            useForm.Show();
            Cursor.Current = Cursors.Default;
        }

        private void radButtonElement3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Roster.ucRoasterOffManage obj = new Roster.ucRoasterOffManage();
            MasterForm useForm = new MasterForm(obj, "Off Verification");
            useForm.Owner = this;
            useForm.Show();
            Cursor.Current = Cursors.Default;
        }

        private void rbeCV_upload_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            cv.uc_CvUpload obj = new cv.uc_CvUpload();
            MasterForm useForm = new MasterForm(obj, "CV Upload");
            useForm.Owner = this;
            useForm.Show();
            Cursor.Current = Cursors.Default;
        }

        private void rbe_jd_documents_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Doc.uc_DocUpload obj = new Doc.uc_DocUpload();
            MasterForm useForm = new MasterForm(obj, "Knowledger Documents Upload");
            useForm.Owner = this;
            useForm.Show();
            Cursor.Current = Cursors.Default;
        }

        private void rbeCvSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            openForm(new cv.ucCV_Search());
            Cursor.Current = Cursors.Default;
        }

        private void rbePostingArea_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            openForm(new Masters.Add_PostingArea());
            Cursor.Current = Cursors.Default;
        }

        private void radButtonElement9_Click(object sender, EventArgs e)
        {
            OpenControl(new Employee.StaffOrgDocsCreation(), "Orignal Document Information Creation");
        }

        private void radButtonElement5_Click(object sender, EventArgs e)
        {
            OpenControl(new Employee.StaffOrgDocs(), "Orignal Document Information View");
        }

        private void rbeDepartment_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            openForm(new Masters.Add_Department());
            Cursor.Current = Cursors.Default;
        }

        private void rbeDocView_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            openForm(new Doc.ucDocView());
            Cursor.Current = Cursors.Default;
        }
    }
}
