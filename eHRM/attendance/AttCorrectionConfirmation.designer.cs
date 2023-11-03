namespace eHRM.attendance
{
    partial class AttCorrectionConfirmation
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.btnSubmit = new Telerik.WinControls.UI.RadButton();
            this.rb_approved = new System.Windows.Forms.RadioButton();
            this.rb_pending = new System.Windows.Forms.RadioButton();
            this.label30 = new System.Windows.Forms.Label();
            this.dtInputDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dgGrid = new Telerik.WinControls.UI.RadGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gbBox = new Telerik.WinControls.UI.RadGroupBox();
            this.btnXL = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInputDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgGrid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbBox)).BeginInit();
            this.gbBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnXL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(201, 6);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(40, 24);
            this.btnSubmit.TabIndex = 107;
            this.btnSubmit.Text = ">>>";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // rb_approved
            // 
            this.rb_approved.AutoSize = true;
            this.rb_approved.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_approved.Location = new System.Drawing.Point(86, 6);
            this.rb_approved.Name = "rb_approved";
            this.rb_approved.Size = new System.Drawing.Size(77, 19);
            this.rb_approved.TabIndex = 106;
            this.rb_approved.Text = "Approved";
            this.rb_approved.UseVisualStyleBackColor = true;
            this.rb_approved.CheckedChanged += new System.EventHandler(this.rb_approved_CheckedChanged);
            // 
            // rb_pending
            // 
            this.rb_pending.AutoSize = true;
            this.rb_pending.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_pending.Location = new System.Drawing.Point(8, 6);
            this.rb_pending.Name = "rb_pending";
            this.rb_pending.Size = new System.Drawing.Size(69, 19);
            this.rb_pending.TabIndex = 105;
            this.rb_pending.Text = "Pending";
            this.rb_pending.UseVisualStyleBackColor = true;
            this.rb_pending.CheckedChanged += new System.EventHandler(this.rb_pending_CheckedChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(8, 9);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(88, 17);
            this.label30.TabIndex = 104;
            this.label30.Text = "Select Month";
            // 
            // dtInputDate
            // 
            this.dtInputDate.CustomFormat = "MM/yyyy";
            this.dtInputDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtInputDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInputDate.Location = new System.Drawing.Point(100, 7);
            this.dtInputDate.Name = "dtInputDate";
            this.dtInputDate.Size = new System.Drawing.Size(95, 21);
            this.dtInputDate.TabIndex = 103;
            this.dtInputDate.TabStop = false;
            this.dtInputDate.Text = "08/2015";
            this.dtInputDate.Value = new System.DateTime(2015, 8, 10, 11, 58, 20, 109);
            // 
            // dgGrid
            // 
            this.dgGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dgGrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgGrid.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgGrid.ForeColor = System.Drawing.Color.Black;
            this.dgGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgGrid.Location = new System.Drawing.Point(4, 36);
            // 
            // 
            // 
            this.dgGrid.MasterTemplate.AllowAddNewRow = false;
            this.dgGrid.MasterTemplate.AllowDeleteRow = false;
            this.dgGrid.MasterTemplate.AllowEditRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "emp_code";
            gridViewTextBoxColumn1.HeaderText = "emp_code";
            gridViewTextBoxColumn1.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn1.Name = "emp_code";
            gridViewTextBoxColumn1.Width = 71;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "emp_name";
            gridViewTextBoxColumn2.HeaderText = "EmployeeName";
            gridViewTextBoxColumn2.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn2.Name = "emp_name";
            gridViewTextBoxColumn2.Width = 157;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "status";
            gridViewTextBoxColumn3.HeaderText = "status";
            gridViewTextBoxColumn3.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn3.Name = "status";
            gridViewTextBoxColumn3.Width = 106;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "remark";
            gridViewTextBoxColumn4.HeaderText = "Remark";
            gridViewTextBoxColumn4.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn4.Name = "remark";
            gridViewTextBoxColumn4.Width = 230;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "proc_date";
            gridViewTextBoxColumn5.HeaderText = "ApproveDate";
            gridViewTextBoxColumn5.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn5.Name = "proc_date";
            gridViewTextBoxColumn5.Width = 106;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "unit_name";
            gridViewTextBoxColumn6.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn6.Name = "unit_name";
            gridViewTextBoxColumn6.Width = 358;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "proc_flag";
            gridViewTextBoxColumn7.HeaderText = "proc_flag";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "proc_flag";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "cmd";
            gridViewCommandColumn1.Name = "cmd";
            gridViewCommandColumn1.Width = 28;
            this.dgGrid.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewCommandColumn1});
            this.dgGrid.MasterTemplate.EnableFiltering = true;
            this.dgGrid.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgGrid.Name = "dgGrid";
            this.dgGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgGrid.Size = new System.Drawing.Size(1092, 481);
            this.dgGrid.TabIndex = 108;
            this.dgGrid.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.MasterTemplate_RowFormatting);
            this.dgGrid.ViewCellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.MasterTemplate_ViewCellFormatting);
            this.dgGrid.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.MasterTemplate_CommandCellClick);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(428, 11);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(31, 15);
            this.lblStatus.TabIndex = 109;
            this.lblStatus.Text = "XXX";
            // 
            // gbBox
            // 
            this.gbBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbBox.Controls.Add(this.rb_pending);
            this.gbBox.Controls.Add(this.rb_approved);
            this.gbBox.Enabled = false;
            this.gbBox.HeaderText = "";
            this.gbBox.Location = new System.Drawing.Point(247, 3);
            this.gbBox.Name = "gbBox";
            this.gbBox.Size = new System.Drawing.Size(169, 30);
            this.gbBox.TabIndex = 110;
            // 
            // btnXL
            // 
            this.btnXL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXL.Image = global::eHRM.Properties.Resources.export_excel;
            this.btnXL.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnXL.Location = new System.Drawing.Point(1024, 5);
            this.btnXL.Name = "btnXL";
            this.btnXL.Size = new System.Drawing.Size(44, 27);
            this.btnXL.TabIndex = 111;
            this.btnXL.Click += new System.EventHandler(this.btnXL_Click);
            // 
            // AttCorrectionConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 520);
            this.Controls.Add(this.btnXL);
            this.Controls.Add(this.gbBox);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dgGrid);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.dtInputDate);
            this.Name = "AttCorrectionConfirmation";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "";
            this.Load += new System.EventHandler(this.AttCorrectionConfirmation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInputDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgGrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbBox)).EndInit();
            this.gbBox.ResumeLayout(false);
            this.gbBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnXL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnSubmit;
        private System.Windows.Forms.RadioButton rb_approved;
        private System.Windows.Forms.RadioButton rb_pending;
        private System.Windows.Forms.Label label30;
        private Telerik.WinControls.UI.RadDateTimePicker dtInputDate;
        private Telerik.WinControls.UI.RadGridView dgGrid;
        private System.Windows.Forms.Label lblStatus;
        private Telerik.WinControls.UI.RadGroupBox gbBox;
        private Telerik.WinControls.UI.RadButton btnXL;
    }
}
