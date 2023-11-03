namespace eHRM
{
    partial class ucNewLoan
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucNewLoan));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.GroupDescriptor groupDescriptor1 = new Telerik.WinControls.Data.GroupDescriptor();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.txtSearch = new Telerik.WinControls.UI.RadTextBox();
            this.btnLoad = new Telerik.WinControls.UI.RadButton();
            this.dgEmpList = new Telerik.WinControls.UI.RadGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLoanAmt = new Telerik.WinControls.UI.RadTextBox();
            this.roundRectShape1 = new Telerik.WinControls.RoundRectShape(this.components);
            this.txtROI = new Telerik.WinControls.UI.RadTextBox();
            this.txtEMI = new Telerik.WinControls.UI.RadTextBox();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.btnLoanAdd = new Telerik.WinControls.UI.RadButton();
            this.rdpSanDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rdpDedDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgLoanRepayInfo = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtROI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoanAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdpSanDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdpDedDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoanRepayInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoanRepayInfo.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(123, 9);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.NullText = "Search Name";
            this.txtSearch.Size = new System.Drawing.Size(110, 23);
            this.txtSearch.TabIndex = 60;
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Image = global::eHRM.Properties.Resources.Refresh;
            this.btnLoad.Location = new System.Drawing.Point(247, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(71, 28);
            this.btnLoad.TabIndex = 58;
            this.btnLoad.Text = "Submit";
            this.btnLoad.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dgEmpList
            // 
            this.dgEmpList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dgEmpList.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgEmpList.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgEmpList.ForeColor = System.Drawing.Color.Black;
            this.dgEmpList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgEmpList.Location = new System.Drawing.Point(3, 34);
            // 
            // 
            // 
            this.dgEmpList.MasterTemplate.AllowAddNewRow = false;
            this.dgEmpList.MasterTemplate.AllowDeleteRow = false;
            this.dgEmpList.MasterTemplate.AllowEditRow = false;
            this.dgEmpList.MasterTemplate.AutoExpandGroups = true;
            this.dgEmpList.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "emp_code";
            gridViewTextBoxColumn1.HeaderText = "Code";
            gridViewTextBoxColumn1.Name = "emp_code";
            gridViewTextBoxColumn1.Width = 72;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "emp_name";
            gridViewTextBoxColumn2.HeaderText = "Name";
            gridViewTextBoxColumn2.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn2.Name = "emp_name";
            gridViewTextBoxColumn2.Width = 161;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "unit_name";
            gridViewTextBoxColumn3.HeaderText = "Unit";
            gridViewTextBoxColumn3.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn3.Name = "unit_name";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.Name = "column1";
            gridViewCommandColumn1.Width = 22;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "InJob";
            gridViewTextBoxColumn4.HeaderText = "InJob";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "InJob";
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "app_flag";
            gridViewTextBoxColumn5.HeaderText = "app_flag";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "app_flag";
            this.dgEmpList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewCommandColumn1,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.dgEmpList.MasterTemplate.EnableFiltering = true;
            sortDescriptor1.PropertyName = "unit_name";
            groupDescriptor1.GroupNames.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.dgEmpList.MasterTemplate.GroupDescriptors.AddRange(new Telerik.WinControls.Data.GroupDescriptor[] {
            groupDescriptor1});
            this.dgEmpList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgEmpList.Name = "dgEmpList";
            this.dgEmpList.ReadOnly = true;
            this.dgEmpList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgEmpList.ShowGroupPanel = false;
            this.dgEmpList.Size = new System.Drawing.Size(315, 461);
            this.dgEmpList.TabIndex = 59;
            this.dgEmpList.Text = "radGridView1";
            this.dgEmpList.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.dgEmpList_CommandCellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 61;
            this.label4.Text = "Loan Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(359, 109);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 62;
            this.label1.Text = "Rate of Interest";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 141);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 63;
            this.label2.Text = "No. of EMI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 173);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 64;
            this.label3.Text = "Method";
            // 
            // txtLoanAmt
            // 
            this.txtLoanAmt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoanAmt.Location = new System.Drawing.Point(523, 73);
            this.txtLoanAmt.MaxLength = 7;
            this.txtLoanAmt.Name = "txtLoanAmt";
            this.txtLoanAmt.Size = new System.Drawing.Size(106, 25);
            this.txtLoanAmt.TabIndex = 65;
            this.txtLoanAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtLoanAmt.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtLoanAmt.GetChildAt(0))).Shape = this.roundRectShape1;
            // 
            // txtROI
            // 
            this.txtROI.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtROI.Location = new System.Drawing.Point(523, 104);
            this.txtROI.MaxLength = 7;
            this.txtROI.Name = "txtROI";
            this.txtROI.Size = new System.Drawing.Size(106, 25);
            this.txtROI.TabIndex = 66;
            this.txtROI.Text = "0";
            this.txtROI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtROI.GetChildAt(0))).Text = "0";
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtROI.GetChildAt(0))).Shape = this.roundRectShape1;
            // 
            // txtEMI
            // 
            this.txtEMI.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEMI.Location = new System.Drawing.Point(523, 136);
            this.txtEMI.MaxLength = 7;
            this.txtEMI.Name = "txtEMI";
            this.txtEMI.Size = new System.Drawing.Size(106, 25);
            this.txtEMI.TabIndex = 66;
            this.txtEMI.Text = "0";
            this.txtEMI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtEMI.GetChildAt(0))).Text = "0";
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtEMI.GetChildAt(0))).Shape = this.roundRectShape1;
            // 
            // cmbMethod
            // 
            this.cmbMethod.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMethod.FormattingEnabled = true;
            this.cmbMethod.Items.AddRange(new object[] {
            "Flat",
            "Diminising",
            "Select"});
            this.cmbMethod.Location = new System.Drawing.Point(523, 172);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(106, 25);
            this.cmbMethod.TabIndex = 67;
            this.cmbMethod.Text = "Select";
            this.cmbMethod.Leave += new System.EventHandler(this.cmbMethod_Leave);
            // 
            // btnLoanAdd
            // 
            this.btnLoanAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoanAdd.Image = global::eHRM.Properties.Resources.Refresh;
            this.btnLoanAdd.Location = new System.Drawing.Point(558, 259);
            this.btnLoanAdd.Name = "btnLoanAdd";
            this.btnLoanAdd.Size = new System.Drawing.Size(71, 28);
            this.btnLoanAdd.TabIndex = 68;
            this.btnLoanAdd.Text = "Submit";
            this.btnLoanAdd.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoanAdd.Click += new System.EventHandler(this.btnLoanAdd_Click);
            // 
            // rdpSanDate
            // 
            this.rdpSanDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdpSanDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdpSanDate.Location = new System.Drawing.Point(375, 34);
            this.rdpSanDate.Name = "rdpSanDate";
            this.rdpSanDate.Size = new System.Drawing.Size(110, 25);
            this.rdpSanDate.TabIndex = 69;
            this.rdpSanDate.TabStop = false;
            this.rdpSanDate.Text = "30/08/2021";
            this.rdpSanDate.Value = new System.DateTime(2021, 8, 30, 18, 18, 50, 906);
            this.rdpSanDate.Leave += new System.EventHandler(this.rdpSanDate_Leave);
            // 
            // rdpDedDate
            // 
            this.rdpDedDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdpDedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdpDedDate.Location = new System.Drawing.Point(520, 34);
            this.rdpDedDate.Name = "rdpDedDate";
            this.rdpDedDate.Size = new System.Drawing.Size(110, 25);
            this.rdpDedDate.TabIndex = 70;
            this.rdpDedDate.TabStop = false;
            this.rdpDedDate.Text = "30/08/2021";
            this.rdpDedDate.Value = new System.DateTime(2021, 8, 30, 18, 18, 50, 906);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 71;
            this.label5.Text = "Sanction Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(516, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 72;
            this.label6.Text = "Deduction Date";
            // 
            // dgLoanRepayInfo
            // 
            this.dgLoanRepayInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dgLoanRepayInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgLoanRepayInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgLoanRepayInfo.ForeColor = System.Drawing.Color.Black;
            this.dgLoanRepayInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgLoanRepayInfo.Location = new System.Drawing.Point(646, 12);
            // 
            // 
            // 
            this.dgLoanRepayInfo.MasterTemplate.AllowAddNewRow = false;
            this.dgLoanRepayInfo.MasterTemplate.AllowDeleteRow = false;
            this.dgLoanRepayInfo.MasterTemplate.AllowEditRow = false;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "principal_amt";
            gridViewTextBoxColumn6.HeaderText = "Principal Amount";
            gridViewTextBoxColumn6.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn6.Name = "principal_amt";
            gridViewTextBoxColumn6.Width = 94;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "intrest";
            gridViewTextBoxColumn7.HeaderText = "Interest";
            gridViewTextBoxColumn7.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn7.Name = "intrest";
            gridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn7.Width = 66;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "EMI";
            gridViewTextBoxColumn8.HeaderText = "EMI";
            gridViewTextBoxColumn8.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn8.Name = "EMI";
            gridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn8.Width = 58;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "dues_date";
            gridViewTextBoxColumn9.FormatString = "{0:dd-MM-yyyy}";
            gridViewTextBoxColumn9.HeaderText = "Due Date";
            gridViewTextBoxColumn9.Name = "dues_date";
            gridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn9.Width = 89;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "pay_date";
            gridViewTextBoxColumn10.FormatString = "{0:dd-MM-yyyy}";
            gridViewTextBoxColumn10.HeaderText = "Pay Date";
            gridViewTextBoxColumn10.Name = "pay_date";
            gridViewTextBoxColumn10.Width = 79;
            this.dgLoanRepayInfo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.dgLoanRepayInfo.MasterTemplate.EnableGrouping = false;
            this.dgLoanRepayInfo.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.dgLoanRepayInfo.Name = "dgLoanRepayInfo";
            this.dgLoanRepayInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgLoanRepayInfo.Size = new System.Drawing.Size(422, 483);
            this.dgLoanRepayInfo.TabIndex = 73;
            this.dgLoanRepayInfo.Text = "radGridView1";
            // 
            // ucNewLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgLoanRepayInfo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rdpDedDate);
            this.Controls.Add(this.rdpSanDate);
            this.Controls.Add(this.btnLoanAdd);
            this.Controls.Add(this.cmbMethod);
            this.Controls.Add(this.txtEMI);
            this.Controls.Add(this.txtROI);
            this.Controls.Add(this.txtLoanAmt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dgEmpList);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucNewLoan";
            this.Size = new System.Drawing.Size(1072, 500);
            this.Load += new System.EventHandler(this.ucNewLoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtROI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoanAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdpSanDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdpDedDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoanRepayInfo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoanRepayInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtSearch;
        private Telerik.WinControls.UI.RadButton btnLoad;
        private Telerik.WinControls.UI.RadGridView dgEmpList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadTextBox txtLoanAmt;
        private Telerik.WinControls.RoundRectShape roundRectShape1;
        private Telerik.WinControls.UI.RadTextBox txtROI;
        private Telerik.WinControls.UI.RadTextBox txtEMI;
        private System.Windows.Forms.ComboBox cmbMethod;
        private Telerik.WinControls.UI.RadButton btnLoanAdd;
        private Telerik.WinControls.UI.RadDateTimePicker rdpSanDate;
        private Telerik.WinControls.UI.RadDateTimePicker rdpDedDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadGridView dgLoanRepayInfo;
    }
}
