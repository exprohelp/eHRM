namespace eHRM.Roster
{
    partial class ucRoasterOffManage
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rgvInfo = new Telerik.WinControls.UI.RadGridView();
            this.btnGenerate = new Telerik.WinControls.UI.RadButton();
            this.roundRectShape1 = new Telerik.WinControls.RoundRectShape(this.components);
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.dtpDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFillRecords = new Telerik.WinControls.UI.RadButton();
            this.btnTransfer = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.rgvInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvInfo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFillRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTransfer)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvInfo
            // 
            this.rgvInfo.BackColor = System.Drawing.SystemColors.Control;
            this.rgvInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgvInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvInfo.Location = new System.Drawing.Point(4, 39);
            // 
            // 
            // 
            this.rgvInfo.MasterTemplate.AllowAddNewRow = false;
            this.rgvInfo.MasterTemplate.AllowColumnReorder = false;
            gridViewTextBoxColumn1.AllowFiltering = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "emp_code";
            gridViewTextBoxColumn1.HeaderText = "emp_code";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "emp_code";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "emp_name";
            gridViewTextBoxColumn2.HeaderText = "Name of Staff";
            gridViewTextBoxColumn2.Name = "emp_name";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 278;
            gridViewTextBoxColumn3.AllowFiltering = false;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "status";
            gridViewTextBoxColumn3.HeaderText = "Status";
            gridViewTextBoxColumn3.Name = "status";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 155;
            gridViewTextBoxColumn4.AllowFiltering = false;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "designation";
            gridViewTextBoxColumn4.HeaderText = "Designation";
            gridViewTextBoxColumn4.Name = "designation";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 146;
            gridViewDateTimeColumn1.AllowFiltering = false;
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.FieldName = "d_o_j";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn1.HeaderText = "Joining Date";
            gridViewDateTimeColumn1.Name = "d_o_j";
            gridViewDateTimeColumn1.ReadOnly = true;
            gridViewDateTimeColumn1.Width = 102;
            gridViewDateTimeColumn2.AllowFiltering = false;
            gridViewDateTimeColumn2.EnableExpressionEditor = false;
            gridViewDateTimeColumn2.FieldName = "res_date";
            gridViewDateTimeColumn2.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn2.HeaderText = "Resign Date";
            gridViewDateTimeColumn2.Name = "res_date";
            gridViewDateTimeColumn2.ReadOnly = true;
            gridViewDateTimeColumn2.Width = 93;
            gridViewDecimalColumn1.AllowFiltering = false;
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "present";
            gridViewDecimalColumn1.HeaderText = "Present";
            gridViewDecimalColumn1.Name = "present";
            gridViewDecimalColumn1.ReadOnly = true;
            gridViewDecimalColumn2.AllowFiltering = false;
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.FieldName = "leaveTaken";
            gridViewDecimalColumn2.HeaderText = "Leave Taken";
            gridViewDecimalColumn2.Name = "leaveTaken";
            gridViewDecimalColumn2.ReadOnly = true;
            gridViewDecimalColumn2.Width = 84;
            gridViewDecimalColumn3.AllowFiltering = false;
            gridViewDecimalColumn3.EnableExpressionEditor = false;
            gridViewDecimalColumn3.FieldName = "weeklyoffTaken";
            gridViewDecimalColumn3.HeaderText = "Weekly Off Taken";
            gridViewDecimalColumn3.Name = "weeklyoffTaken";
            gridViewDecimalColumn3.ReadOnly = true;
            gridViewDecimalColumn3.Width = 98;
            gridViewDecimalColumn4.AllowFiltering = false;
            gridViewDecimalColumn4.EnableExpressionEditor = false;
            gridViewDecimalColumn4.FieldName = "CalculatedOff";
            gridViewDecimalColumn4.HeaderText = "Calculated Off";
            gridViewDecimalColumn4.Name = "CalculatedOff";
            gridViewDecimalColumn4.ReadOnly = true;
            gridViewDecimalColumn4.Width = 91;
            gridViewComboBoxColumn1.EnableExpressionEditor = false;
            gridViewComboBoxColumn1.FieldName = "isAllowed";
            gridViewComboBoxColumn1.HeaderText = "isAllowed";
            gridViewComboBoxColumn1.Name = "isAllowed";
            gridViewComboBoxColumn1.Width = 61;
            this.rgvInfo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewDateTimeColumn1,
            gridViewDateTimeColumn2,
            gridViewDecimalColumn1,
            gridViewDecimalColumn2,
            gridViewDecimalColumn3,
            gridViewDecimalColumn4,
            gridViewComboBoxColumn1});
            this.rgvInfo.MasterTemplate.EnableFiltering = true;
            this.rgvInfo.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgvInfo.Name = "rgvInfo";
            this.rgvInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvInfo.ShowGroupPanel = false;
            this.rgvInfo.Size = new System.Drawing.Size(1192, 493);
            this.rgvInfo.TabIndex = 0;
            this.rgvInfo.Text = "radGridView1";
            this.rgvInfo.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.rgvInfo_RowFormatting);
            this.rgvInfo.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.rgvInfo_CellBeginEdit);
            this.rgvInfo.CellEndEdit += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvInfo_CellEndEdit);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(211, 3);
            this.btnGenerate.Name = "btnGenerate";
            // 
            // 
            // 
            this.btnGenerate.RootElement.Shape = this.roundRectShape1;
            this.btnGenerate.Size = new System.Drawing.Size(85, 30);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnGenerate.GetChildAt(0))).Text = "Generate";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnGenerate.GetChildAt(0))).Shape = this.roundRectShape1;
            ((Telerik.WinControls.Layouts.ImageAndTextLayoutPanel)(this.btnGenerate.GetChildAt(0).GetChildAt(1))).Shape = this.roundRectShape1;
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(50, 6);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(107, 25);
            this.dtpDate.TabIndex = 2;
            this.dtpDate.TabStop = false;
            this.dtpDate.Text = "12-01-2023";
            this.dtpDate.Value = new System.DateTime(2023, 1, 12, 14, 33, 32, 711);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date";
            // 
            // btnFillRecords
            // 
            this.btnFillRecords.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFillRecords.Location = new System.Drawing.Point(336, 3);
            this.btnFillRecords.Name = "btnFillRecords";
            // 
            // 
            // 
            this.btnFillRecords.RootElement.Shape = this.roundRectShape1;
            this.btnFillRecords.Size = new System.Drawing.Size(106, 30);
            this.btnFillRecords.TabIndex = 4;
            this.btnFillRecords.Text = "Fill Records";
            this.btnFillRecords.Click += new System.EventHandler(this.btnFillRecords_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFillRecords.GetChildAt(0))).Text = "Fill Records";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFillRecords.GetChildAt(0))).Shape = this.roundRectShape1;
            ((Telerik.WinControls.Layouts.ImageAndTextLayoutPanel)(this.btnFillRecords.GetChildAt(0).GetChildAt(1))).Shape = this.roundRectShape1;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.Location = new System.Drawing.Point(579, 3);
            this.btnTransfer.Name = "btnTransfer";
            // 
            // 
            // 
            this.btnTransfer.RootElement.Shape = this.roundRectShape1;
            this.btnTransfer.Size = new System.Drawing.Size(160, 30);
            this.btnTransfer.TabIndex = 5;
            this.btnTransfer.Text = "Transfer For Process";
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnTransfer.GetChildAt(0))).Text = "Transfer For Process";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnTransfer.GetChildAt(0))).Shape = this.roundRectShape1;
            ((Telerik.WinControls.Layouts.ImageAndTextLayoutPanel)(this.btnTransfer.GetChildAt(0).GetChildAt(1))).Shape = this.roundRectShape1;
            // 
            // ucRoasterOffManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnFillRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.rgvInfo);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucRoasterOffManage";
            this.Size = new System.Drawing.Size(1200, 535);
            this.Load += new System.EventHandler(this.ucRoasterOffManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvInfo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFillRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTransfer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgvInfo;
        private Telerik.WinControls.UI.RadButton btnGenerate;
        private Telerik.WinControls.RoundRectShape roundRectShape1;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.UI.RadDateTimePicker dtpDate;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadButton btnFillRecords;
        private Telerik.WinControls.UI.RadButton btnTransfer;
    }
}
