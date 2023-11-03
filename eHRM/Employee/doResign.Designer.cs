namespace eHRM.Employee
{
    partial class doResign
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(doResign));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rgv_info = new Telerik.WinControls.UI.RadGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new Telerik.WinControls.UI.RadButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rdp_date = new Telerik.WinControls.UI.RadDateTimePicker();
            this.btnSet = new Telerik.WinControls.UI.RadButton();
            this.chkInjob = new System.Windows.Forms.CheckBox();
            this.rgb_group = new Telerik.WinControls.UI.RadGroupBox();
            this.rtbResignRemaks = new System.Windows.Forms.RichTextBox();
            this.chkNoticeServed = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdp_date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgb_group)).BeginInit();
            this.rgb_group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rgv_info
            // 
            this.rgv_info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgv_info.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_info.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_info.ForeColor = System.Drawing.Color.Black;
            this.rgv_info.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_info.Location = new System.Drawing.Point(2, 41);
            // 
            // 
            // 
            this.rgv_info.MasterTemplate.AllowAddNewRow = false;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.HeaderText = "-";
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.Name = "column1";
            gridViewCommandColumn1.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewCommandColumn1.Width = 25;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "emp_code";
            gridViewTextBoxColumn1.HeaderText = "Code";
            gridViewTextBoxColumn1.Name = "emp_code";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "emp_name";
            gridViewTextBoxColumn2.HeaderText = "Name of Staff";
            gridViewTextBoxColumn2.Name = "emp_name";
            gridViewTextBoxColumn2.Width = 300;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "f_name";
            gridViewTextBoxColumn3.HeaderText = "Name of Father";
            gridViewTextBoxColumn3.Name = "f_name";
            gridViewTextBoxColumn3.Width = 197;
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.FieldName = "d_o_j";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn1.HeaderText = "Joining";
            gridViewDateTimeColumn1.Name = "d_o_j";
            gridViewDateTimeColumn1.Width = 96;
            gridViewDateTimeColumn2.EnableExpressionEditor = false;
            gridViewDateTimeColumn2.FieldName = "res_date";
            gridViewDateTimeColumn2.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn2.HeaderText = "res_date";
            gridViewDateTimeColumn2.Name = "res_date";
            gridViewDateTimeColumn2.Width = 89;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "ResignRemarks";
            gridViewTextBoxColumn4.HeaderText = "column2";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "ResignRemarks";
            this.rgv_info.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCommandColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewDateTimeColumn1,
            gridViewDateTimeColumn2,
            gridViewTextBoxColumn4});
            this.rgv_info.MasterTemplate.EnableFiltering = true;
            this.rgv_info.MasterTemplate.EnableGrouping = false;
            sortDescriptor1.PropertyName = "column1";
            this.rgv_info.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.rgv_info.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgv_info.Name = "rgv_info";
            this.rgv_info.ReadOnly = true;
            this.rgv_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_info.Size = new System.Drawing.Size(789, 445);
            this.rgv_info.TabIndex = 0;
            this.rgv_info.Text = "radGridView1";
            this.rgv_info.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rgv_info_CommandCellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Company";
            // 
            // cmbCompany
            // 
            this.cmbCompany.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Items.AddRange(new object[] {
            "CHL",
            "CHCL",
            "IDC",
            "CPL",
            "CSF",
            "CIMS",
            "CEN"});
            this.cmbCompany.Location = new System.Drawing.Point(81, 3);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(121, 29);
            this.cmbCompany.TabIndex = 2;
            this.cmbCompany.Text = "CHCL";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(340, 7);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(56, 27);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date of Resign";
            // 
            // rdp_date
            // 
            this.rdp_date.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdp_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdp_date.Location = new System.Drawing.Point(201, 56);
            this.rdp_date.Name = "rdp_date";
            this.rdp_date.Size = new System.Drawing.Size(103, 25);
            this.rdp_date.TabIndex = 5;
            this.rdp_date.TabStop = false;
            this.rdp_date.Text = "01/01/2019";
            this.rdp_date.Value = new System.DateTime(2019, 1, 1, 15, 50, 27, 748);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(5, 457);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(56, 27);
            this.btnSet.TabIndex = 4;
            this.btnSet.Text = "Submit";
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // chkInjob
            // 
            this.chkInjob.AutoSize = true;
            this.chkInjob.Checked = true;
            this.chkInjob.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInjob.Location = new System.Drawing.Point(246, 13);
            this.chkInjob.Name = "chkInjob";
            this.chkInjob.Size = new System.Drawing.Size(67, 24);
            this.chkInjob.TabIndex = 6;
            this.chkInjob.Text = "In Job";
            this.chkInjob.UseVisualStyleBackColor = true;
            // 
            // rgb_group
            // 
            this.rgb_group.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rgb_group.Controls.Add(this.rtbResignRemaks);
            this.rgb_group.Controls.Add(this.chkNoticeServed);
            this.rgb_group.Controls.Add(this.btnSet);
            this.rgb_group.Controls.Add(this.label2);
            this.rgb_group.Controls.Add(this.rdp_date);
            this.rgb_group.Enabled = false;
            this.rgb_group.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgb_group.HeaderText = "";
            this.rgb_group.Location = new System.Drawing.Point(797, 15);
            this.rgb_group.Name = "rgb_group";
            this.rgb_group.Size = new System.Drawing.Size(316, 493);
            this.rgb_group.TabIndex = 7;
            // 
            // rtbResignRemaks
            // 
            this.rtbResignRemaks.Location = new System.Drawing.Point(5, 87);
            this.rtbResignRemaks.MaxLength = 1000;
            this.rtbResignRemaks.Name = "rtbResignRemaks";
            this.rtbResignRemaks.Size = new System.Drawing.Size(306, 364);
            this.rtbResignRemaks.TabIndex = 7;
            this.rtbResignRemaks.Text = "";
            // 
            // chkNoticeServed
            // 
            this.chkNoticeServed.AutoSize = true;
            this.chkNoticeServed.Location = new System.Drawing.Point(5, 29);
            this.chkNoticeServed.Name = "chkNoticeServed";
            this.chkNoticeServed.Size = new System.Drawing.Size(121, 24);
            this.chkNoticeServed.TabIndex = 6;
            this.chkNoticeServed.Text = "Notice Served";
            this.chkNoticeServed.UseVisualStyleBackColor = true;
            this.chkNoticeServed.CheckedChanged += new System.EventHandler(this.chkNoticeServed_CheckedChanged);
            // 
            // doResign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 513);
            this.Controls.Add(this.rgb_group);
            this.Controls.Add(this.chkInjob);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rgv_info);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "doResign";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Resignation of Employee";
            this.Load += new System.EventHandler(this.doResign_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdp_date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgb_group)).EndInit();
            this.rgb_group.ResumeLayout(false);
            this.rgb_group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgv_info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCompany;
        private Telerik.WinControls.UI.RadButton btnSubmit;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadDateTimePicker rdp_date;
        private Telerik.WinControls.UI.RadButton btnSet;
        private System.Windows.Forms.CheckBox chkInjob;
        private Telerik.WinControls.UI.RadGroupBox rgb_group;
        private System.Windows.Forms.CheckBox chkNoticeServed;
        private System.Windows.Forms.RichTextBox rtbResignRemaks;
    }
}
