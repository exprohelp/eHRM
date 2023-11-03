namespace eHRM.Employee
{
    partial class LoanManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoanManagement));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            this.dgLoanMaster = new Telerik.WinControls.UI.RadGridView();
            this.dgLoanRepayInfo = new Telerik.WinControls.UI.RadGridView();
            this.btnCloseLoan = new Telerik.WinControls.UI.RadButton();
            this.ddlReportType = new Telerik.WinControls.UI.RadDropDownList();
            this.btnGetDetail = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoanMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoanMaster.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoanRepayInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoanRepayInfo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseLoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlReportType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGetDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dgLoanMaster
            // 
            this.dgLoanMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dgLoanMaster.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgLoanMaster.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgLoanMaster.ForeColor = System.Drawing.Color.Black;
            this.dgLoanMaster.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgLoanMaster.Location = new System.Drawing.Point(0, 31);
            // 
            // 
            // 
            this.dgLoanMaster.MasterTemplate.AllowAddNewRow = false;
            this.dgLoanMaster.MasterTemplate.AllowDeleteRow = false;
            this.dgLoanMaster.MasterTemplate.AllowEditRow = false;
            this.dgLoanMaster.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "emp_code";
            gridViewTextBoxColumn1.HeaderText = "emp_code";
            gridViewTextBoxColumn1.Name = "emp_code";
            gridViewTextBoxColumn1.Width = 93;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "emp_name";
            gridViewTextBoxColumn2.HeaderText = "Employee Name";
            gridViewTextBoxColumn2.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn2.Name = "emp_name";
            gridViewTextBoxColumn2.Width = 156;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "loan_id";
            gridViewTextBoxColumn3.HeaderText = "Loan Id";
            gridViewTextBoxColumn3.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn3.Name = "loan_id";
            gridViewTextBoxColumn3.Width = 104;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "No_EMI";
            gridViewTextBoxColumn4.HeaderText = "Emi No";
            gridViewTextBoxColumn4.Name = "No_EMI";
            gridViewTextBoxColumn4.Width = 43;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "LoanAmt";
            gridViewTextBoxColumn5.HeaderText = "LoanAmt";
            gridViewTextBoxColumn5.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn5.Name = "LoanAmt";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn5.Width = 67;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "sanction_date";
            gridViewTextBoxColumn6.HeaderText = "Sanction Date";
            gridViewTextBoxColumn6.Name = "sanction_date";
            gridViewTextBoxColumn6.Width = 89;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "cr_date";
            gridViewTextBoxColumn7.HeaderText = "CreationDate";
            gridViewTextBoxColumn7.Name = "cr_date";
            gridViewTextBoxColumn7.Width = 79;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.HeaderText = "column1";
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.Name = "column1";
            gridViewCommandColumn1.Width = 25;
            gridViewTextBoxColumn8.FieldName = "Close_flag";
            gridViewTextBoxColumn8.HeaderText = "column2";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "Close_flag";
            this.dgLoanMaster.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewCommandColumn1,
            gridViewTextBoxColumn8});
            this.dgLoanMaster.MasterTemplate.EnableGrouping = false;
            this.dgLoanMaster.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgLoanMaster.Name = "dgLoanMaster";
            this.dgLoanMaster.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgLoanMaster.Size = new System.Drawing.Size(693, 521);
            this.dgLoanMaster.TabIndex = 0;
            this.dgLoanMaster.Text = "radGridView1";
            this.dgLoanMaster.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.dgLoanMaster_CommandCellClick);
            // 
            // dgLoanRepayInfo
            // 
            this.dgLoanRepayInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dgLoanRepayInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgLoanRepayInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgLoanRepayInfo.ForeColor = System.Drawing.Color.Black;
            this.dgLoanRepayInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgLoanRepayInfo.Location = new System.Drawing.Point(699, 1);
            // 
            // 
            // 
            this.dgLoanRepayInfo.MasterTemplate.AllowAddNewRow = false;
            this.dgLoanRepayInfo.MasterTemplate.AllowDeleteRow = false;
            this.dgLoanRepayInfo.MasterTemplate.AllowEditRow = false;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "principal_amt";
            gridViewTextBoxColumn9.HeaderText = "Principal Amount";
            gridViewTextBoxColumn9.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn9.Name = "principal_amt";
            gridViewTextBoxColumn9.Width = 94;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "intrest";
            gridViewTextBoxColumn10.HeaderText = "Interest";
            gridViewTextBoxColumn10.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn10.Name = "intrest";
            gridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn10.Width = 66;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "EMI";
            gridViewTextBoxColumn11.HeaderText = "EMI";
            gridViewTextBoxColumn11.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn11.Name = "EMI";
            gridViewTextBoxColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn11.Width = 58;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "dues_date";
            gridViewTextBoxColumn12.HeaderText = "Due Date";
            gridViewTextBoxColumn12.Name = "dues_date";
            gridViewTextBoxColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn12.Width = 89;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "pay_date";
            gridViewTextBoxColumn13.HeaderText = "Pay Date";
            gridViewTextBoxColumn13.Name = "pay_date";
            gridViewTextBoxColumn13.Width = 79;
            this.dgLoanRepayInfo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13});
            this.dgLoanRepayInfo.MasterTemplate.EnableGrouping = false;
            this.dgLoanRepayInfo.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.dgLoanRepayInfo.Name = "dgLoanRepayInfo";
            this.dgLoanRepayInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgLoanRepayInfo.Size = new System.Drawing.Size(422, 550);
            this.dgLoanRepayInfo.TabIndex = 1;
            this.dgLoanRepayInfo.Text = "radGridView1";
            // 
            // btnCloseLoan
            // 
            this.btnCloseLoan.Enabled = false;
            this.btnCloseLoan.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCloseLoan.Location = new System.Drawing.Point(609, 2);
            this.btnCloseLoan.Name = "btnCloseLoan";
            this.btnCloseLoan.Size = new System.Drawing.Size(81, 25);
            this.btnCloseLoan.TabIndex = 2;
            this.btnCloseLoan.Text = "Close Loan";
            this.btnCloseLoan.Click += new System.EventHandler(this.btnCloseLoan_Click);
            // 
            // ddlReportType
            // 
            this.ddlReportType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlReportType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem1.Text = "ALL";
            radListDataItem2.Text = "Active Loan";
            radListDataItem3.Text = "Closed Loan";
            this.ddlReportType.Items.Add(radListDataItem1);
            this.ddlReportType.Items.Add(radListDataItem2);
            this.ddlReportType.Items.Add(radListDataItem3);
            this.ddlReportType.Location = new System.Drawing.Point(1, 3);
            this.ddlReportType.Name = "ddlReportType";
            this.ddlReportType.NullText = "Select Report Type";
            this.ddlReportType.Size = new System.Drawing.Size(152, 23);
            this.ddlReportType.TabIndex = 3;
            // 
            // btnGetDetail
            // 
            this.btnGetDetail.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGetDetail.Location = new System.Drawing.Point(159, 2);
            this.btnGetDetail.Name = "btnGetDetail";
            this.btnGetDetail.Size = new System.Drawing.Size(76, 25);
            this.btnGetDetail.TabIndex = 4;
            this.btnGetDetail.Text = "Get Detail";
            this.btnGetDetail.Click += new System.EventHandler(this.btnGetDetail_Click);
            // 
            // LoanManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 554);
            this.Controls.Add(this.btnGetDetail);
            this.Controls.Add(this.ddlReportType);
            this.Controls.Add(this.btnCloseLoan);
            this.Controls.Add(this.dgLoanRepayInfo);
            this.Controls.Add(this.dgLoanMaster);
            this.Name = "LoanManagement";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "Loan Management";
            this.Load += new System.EventHandler(this.LoanManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLoanMaster.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoanMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoanRepayInfo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoanRepayInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseLoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlReportType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGetDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView dgLoanMaster;
        private Telerik.WinControls.UI.RadGridView dgLoanRepayInfo;
        private Telerik.WinControls.UI.RadButton btnCloseLoan;
        private Telerik.WinControls.UI.RadDropDownList ddlReportType;
        private Telerik.WinControls.UI.RadButton btnGetDetail;
    }
}