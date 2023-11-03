namespace eHRM.Employee
{
    partial class ucEmployeesOptions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn21 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEmployeesOptions));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn22 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn23 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn24 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn25 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn26 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn27 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.GroupDescriptor groupDescriptor3 = new Telerik.WinControls.Data.GroupDescriptor();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor3 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.btnFillList = new Telerik.WinControls.UI.RadButton();
            this.dgEmpList = new Telerik.WinControls.UI.RadGridView();
            this.chkSinglePunchBeforeTime = new System.Windows.Forms.CheckBox();
            this.chkSinglePunching = new System.Windows.Forms.CheckBox();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtTrust = new Telerik.WinControls.UI.RadTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLeaveFlag = new System.Windows.Forms.CheckBox();
            this.btnAdd_Modify = new Telerik.WinControls.UI.RadButton();
            this.rpPanel = new Telerik.WinControls.UI.RadPanel();
            this.lblName = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txttds = new Telerik.WinControls.UI.RadTextBox();
            this.btnTDSSave = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnFillList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrust)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd_Modify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpPanel)).BeginInit();
            this.rpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTDSSave)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFillList
            // 
            this.btnFillList.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFillList.Location = new System.Drawing.Point(3, 3);
            this.btnFillList.Name = "btnFillList";
            this.btnFillList.Size = new System.Drawing.Size(110, 24);
            this.btnFillList.TabIndex = 90;
            this.btnFillList.Text = "Fill List";
            this.btnFillList.Click += new System.EventHandler(this.btnFillList_Click);
            // 
            // dgEmpList
            // 
            this.dgEmpList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgEmpList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dgEmpList.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgEmpList.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgEmpList.ForeColor = System.Drawing.Color.Black;
            this.dgEmpList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgEmpList.Location = new System.Drawing.Point(3, 33);
            // 
            // 
            // 
            this.dgEmpList.MasterTemplate.AllowAddNewRow = false;
            this.dgEmpList.MasterTemplate.AllowDeleteRow = false;
            this.dgEmpList.MasterTemplate.AllowEditRow = false;
            this.dgEmpList.MasterTemplate.AutoExpandGroups = true;
            this.dgEmpList.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn19.EnableExpressionEditor = false;
            gridViewTextBoxColumn19.FieldName = "emp_code";
            gridViewTextBoxColumn19.HeaderText = "Code";
            gridViewTextBoxColumn19.Name = "emp_code";
            gridViewTextBoxColumn19.Width = 72;
            gridViewTextBoxColumn20.EnableExpressionEditor = false;
            gridViewTextBoxColumn20.FieldName = "emp_name";
            gridViewTextBoxColumn20.HeaderText = "Name";
            gridViewTextBoxColumn20.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn20.Name = "emp_name";
            gridViewTextBoxColumn20.Width = 204;
            gridViewTextBoxColumn21.EnableExpressionEditor = false;
            gridViewTextBoxColumn21.FieldName = "unit_name";
            gridViewTextBoxColumn21.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn21.Name = "unit_name";
            gridViewCommandColumn3.EnableExpressionEditor = false;
            gridViewCommandColumn3.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn3.Image")));
            gridViewCommandColumn3.Name = "column1";
            gridViewCommandColumn3.Width = 22;
            gridViewTextBoxColumn22.EnableExpressionEditor = false;
            gridViewTextBoxColumn22.FieldName = "status";
            gridViewTextBoxColumn22.IsVisible = false;
            gridViewTextBoxColumn22.Name = "status";
            gridViewTextBoxColumn23.EnableExpressionEditor = false;
            gridViewTextBoxColumn23.FieldName = "designation";
            gridViewTextBoxColumn23.HeaderText = "designation";
            gridViewTextBoxColumn23.IsVisible = false;
            gridViewTextBoxColumn23.Name = "designation";
            gridViewTextBoxColumn24.EnableExpressionEditor = false;
            gridViewTextBoxColumn24.FieldName = "sp_flag";
            gridViewTextBoxColumn24.HeaderText = "sp_flag";
            gridViewTextBoxColumn24.IsVisible = false;
            gridViewTextBoxColumn24.Name = "sp_flag";
            gridViewTextBoxColumn25.EnableExpressionEditor = false;
            gridViewTextBoxColumn25.FieldName = "cal_leave_flag";
            gridViewTextBoxColumn25.HeaderText = "cal_leave_flag";
            gridViewTextBoxColumn25.IsVisible = false;
            gridViewTextBoxColumn25.Name = "cal_leave_flag";
            gridViewTextBoxColumn26.EnableExpressionEditor = false;
            gridViewTextBoxColumn26.FieldName = "tax_ded";
            gridViewTextBoxColumn26.HeaderText = "tax_ded";
            gridViewTextBoxColumn26.IsVisible = false;
            gridViewTextBoxColumn26.Name = "tax_ded";
            gridViewTextBoxColumn27.EnableExpressionEditor = false;
            gridViewTextBoxColumn27.FieldName = "trust_percent";
            gridViewTextBoxColumn27.HeaderText = "trust_percent";
            gridViewTextBoxColumn27.IsVisible = false;
            gridViewTextBoxColumn27.Name = "trust_percent";
            this.dgEmpList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20,
            gridViewTextBoxColumn21,
            gridViewCommandColumn3,
            gridViewTextBoxColumn22,
            gridViewTextBoxColumn23,
            gridViewTextBoxColumn24,
            gridViewTextBoxColumn25,
            gridViewTextBoxColumn26,
            gridViewTextBoxColumn27});
            this.dgEmpList.MasterTemplate.EnableFiltering = true;
            sortDescriptor3.PropertyName = "unit_name";
            groupDescriptor3.GroupNames.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor3});
            this.dgEmpList.MasterTemplate.GroupDescriptors.AddRange(new Telerik.WinControls.Data.GroupDescriptor[] {
            groupDescriptor3});
            this.dgEmpList.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.dgEmpList.Name = "dgEmpList";
            this.dgEmpList.ReadOnly = true;
            this.dgEmpList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgEmpList.Size = new System.Drawing.Size(359, 493);
            this.dgEmpList.TabIndex = 89;
            this.dgEmpList.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.dgEmpList_CommandCellClick);
            // 
            // chkSinglePunchBeforeTime
            // 
            this.chkSinglePunchBeforeTime.AutoSize = true;
            this.chkSinglePunchBeforeTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSinglePunchBeforeTime.Location = new System.Drawing.Point(6, 40);
            this.chkSinglePunchBeforeTime.Name = "chkSinglePunchBeforeTime";
            this.chkSinglePunchBeforeTime.Size = new System.Drawing.Size(231, 24);
            this.chkSinglePunchBeforeTime.TabIndex = 187;
            this.chkSinglePunchBeforeTime.Text = "Single Punch Before Shift Time";
            this.chkSinglePunchBeforeTime.UseVisualStyleBackColor = true;
            // 
            // chkSinglePunching
            // 
            this.chkSinglePunching.AutoSize = true;
            this.chkSinglePunching.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSinglePunching.Location = new System.Drawing.Point(6, 17);
            this.chkSinglePunching.Name = "chkSinglePunching";
            this.chkSinglePunching.Size = new System.Drawing.Size(133, 24);
            this.chkSinglePunching.TabIndex = 186;
            this.chkSinglePunching.Text = "Single Punching";
            this.chkSinglePunching.UseVisualStyleBackColor = true;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.txtTrust);
            this.radGroupBox1.Controls.Add(this.groupBox1);
            this.radGroupBox1.Controls.Add(this.chkLeaveFlag);
            this.radGroupBox1.Controls.Add(this.btnAdd_Modify);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "Punching, Leave Calculation & Trust ";
            this.radGroupBox1.Location = new System.Drawing.Point(9, 25);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(513, 134);
            this.radGroupBox1.TabIndex = 188;
            this.radGroupBox1.Text = "Punching, Leave Calculation & Trust ";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(327, 76);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(112, 21);
            this.radLabel1.TabIndex = 187;
            this.radLabel1.Text = "Trust Deduction%";
            // 
            // txtTrust
            // 
            this.txtTrust.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrust.Location = new System.Drawing.Point(327, 103);
            this.txtTrust.MaxLength = 30;
            this.txtTrust.Name = "txtTrust";
            this.txtTrust.Size = new System.Drawing.Size(88, 23);
            this.txtTrust.TabIndex = 186;
            this.txtTrust.Text = "0";
            this.txtTrust.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSinglePunching);
            this.groupBox1.Controls.Add(this.chkSinglePunchBeforeTime);
            this.groupBox1.Location = new System.Drawing.Point(14, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 68);
            this.groupBox1.TabIndex = 190;
            this.groupBox1.TabStop = false;
            // 
            // chkLeaveFlag
            // 
            this.chkLeaveFlag.AutoSize = true;
            this.chkLeaveFlag.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLeaveFlag.Location = new System.Drawing.Point(20, 100);
            this.chkLeaveFlag.Name = "chkLeaveFlag";
            this.chkLeaveFlag.Size = new System.Drawing.Size(144, 24);
            this.chkLeaveFlag.TabIndex = 189;
            this.chkLeaveFlag.Text = "Leave Calculation";
            this.chkLeaveFlag.UseVisualStyleBackColor = true;
            // 
            // btnAdd_Modify
            // 
            this.btnAdd_Modify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd_Modify.Enabled = false;
            this.btnAdd_Modify.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd_Modify.Image = global::eHRM.Properties.Resources.Save_32;
            this.btnAdd_Modify.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd_Modify.Location = new System.Drawing.Point(475, 41);
            this.btnAdd_Modify.Name = "btnAdd_Modify";
            this.btnAdd_Modify.Size = new System.Drawing.Size(33, 44);
            this.btnAdd_Modify.TabIndex = 188;
            this.btnAdd_Modify.TextWrap = true;
            this.btnAdd_Modify.Click += new System.EventHandler(this.btnAdd_Modify_Click);
            // 
            // rpPanel
            // 
            this.rpPanel.Controls.Add(this.radGroupBox2);
            this.rpPanel.Controls.Add(this.radGroupBox1);
            this.rpPanel.Location = new System.Drawing.Point(368, 33);
            this.rpPanel.Name = "rpPanel";
            this.rpPanel.Size = new System.Drawing.Size(530, 493);
            this.rpPanel.TabIndex = 190;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(368, 6);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(183, 21);
            this.lblName.TabIndex = 191;
            this.lblName.Text = "Name: XXXXXXXXXXXXXXXXX";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.radLabel2);
            this.radGroupBox2.Controls.Add(this.txttds);
            this.radGroupBox2.Controls.Add(this.btnTDSSave);
            this.radGroupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox2.HeaderText = "TDS Feeding";
            this.radGroupBox2.Location = new System.Drawing.Point(9, 179);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(513, 80);
            this.radGroupBox2.TabIndex = 189;
            this.radGroupBox2.Text = "TDS Feeding";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(14, 41);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(151, 21);
            this.radLabel2.TabIndex = 187;
            this.radLabel2.Text = "Tax Deduction at Source";
            // 
            // txttds
            // 
            this.txttds.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttds.Location = new System.Drawing.Point(194, 39);
            this.txttds.MaxLength = 30;
            this.txttds.Name = "txttds";
            this.txttds.Size = new System.Drawing.Size(88, 23);
            this.txttds.TabIndex = 186;
            this.txttds.Text = "0";
            this.txttds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnTDSSave
            // 
            this.btnTDSSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTDSSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTDSSave.Image = global::eHRM.Properties.Resources.Save_32;
            this.btnTDSSave.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTDSSave.Location = new System.Drawing.Point(462, 21);
            this.btnTDSSave.Name = "btnTDSSave";
            this.btnTDSSave.Size = new System.Drawing.Size(33, 44);
            this.btnTDSSave.TabIndex = 188;
            this.btnTDSSave.TextWrap = true;
            this.btnTDSSave.Click += new System.EventHandler(this.btnTDSSave_Click);
            // 
            // ucEmployeesOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.rpPanel);
            this.Controls.Add(this.btnFillList);
            this.Controls.Add(this.dgEmpList);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucEmployeesOptions";
            this.Size = new System.Drawing.Size(901, 539);
            ((System.ComponentModel.ISupportInitialize)(this.btnFillList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrust)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd_Modify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpPanel)).EndInit();
            this.rpPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTDSSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnFillList;
        private Telerik.WinControls.UI.RadGridView dgEmpList;
        private System.Windows.Forms.CheckBox chkSinglePunchBeforeTime;
        private System.Windows.Forms.CheckBox chkSinglePunching;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnAdd_Modify;
        private Telerik.WinControls.UI.RadPanel rpPanel;
        private System.Windows.Forms.CheckBox chkLeaveFlag;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtTrust;
        private Telerik.WinControls.UI.RadLabel lblName;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txttds;
        private Telerik.WinControls.UI.RadButton btnTDSSave;
    }
}
