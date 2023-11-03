namespace eHRM.attendance
{
    partial class uc_LeaveHistory
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_LeaveHistory));
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rgv_staff = new Telerik.WinControls.UI.RadGridView();
            this.textSearch = new Telerik.WinControls.UI.RadTextBox();
            this.rgv_info = new Telerik.WinControls.UI.RadGridView();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.btn_XL = new Telerik.WinControls.UI.RadButton();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.rpvp_attSummary = new Telerik.WinControls.UI.RadPageViewPage();
            this.rpvp_BioRawData = new Telerik.WinControls.UI.RadPageViewPage();
            this.gb_biometric = new System.Windows.Forms.GroupBox();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.btn_excel = new Telerik.WinControls.UI.RadButton();
            this.rdp_go = new Telerik.WinControls.UI.RadButton();
            this.rdp_to = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rdp_from = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rgv_bio_info = new Telerik.WinControls.UI.RadGridView();
            this.rpvpChangeHistory = new Telerik.WinControls.UI.RadPageViewPage();
            this.gbRecordChanges = new System.Windows.Forms.GroupBox();
            this.rgvHistory = new Telerik.WinControls.UI.RadGridView();
            this.btnGetHistory = new Telerik.WinControls.UI.RadButton();
            this.btnXLRecordChange = new Telerik.WinControls.UI.RadButton();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info.MasterTemplate)).BeginInit();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_XL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.rpvp_attSummary.SuspendLayout();
            this.rpvp_BioRawData.SuspendLayout();
            this.gb_biometric.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_excel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdp_go)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdp_to)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdp_from)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_bio_info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_bio_info.MasterTemplate)).BeginInit();
            this.rpvpChangeHistory.SuspendLayout();
            this.gbRecordChanges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvHistory.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGetHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXLRecordChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // rgv_staff
            // 
            this.rgv_staff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgv_staff.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_staff.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_staff.ForeColor = System.Drawing.Color.Black;
            this.rgv_staff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_staff.Location = new System.Drawing.Point(3, 28);
            // 
            // 
            // 
            this.rgv_staff.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "emp_code";
            gridViewTextBoxColumn1.HeaderText = "Code";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "emp_code";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "emp_name";
            gridViewTextBoxColumn2.HeaderText = "Name of Employee";
            gridViewTextBoxColumn2.Name = "emp_name";
            gridViewTextBoxColumn2.Width = 241;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.HeaderText = "-";
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn1.Name = "column1";
            gridViewCommandColumn1.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewCommandColumn1.Width = 25;
            this.rgv_staff.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1});
            this.rgv_staff.MasterTemplate.EnableFiltering = true;
            this.rgv_staff.MasterTemplate.EnableGrouping = false;
            sortDescriptor1.PropertyName = "column1";
            this.rgv_staff.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.rgv_staff.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgv_staff.Name = "rgv_staff";
            this.rgv_staff.ReadOnly = true;
            this.rgv_staff.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_staff.Size = new System.Drawing.Size(307, 485);
            this.rgv_staff.TabIndex = 5;
            this.rgv_staff.Text = "radGridView1";
            this.rgv_staff.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rgv_staff_CommandCellClick);
            // 
            // textSearch
            // 
            this.textSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearch.Location = new System.Drawing.Point(3, 3);
            this.textSearch.Name = "textSearch";
            this.textSearch.NullText = "Search String";
            this.textSearch.Size = new System.Drawing.Size(141, 23);
            this.textSearch.TabIndex = 4;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // rgv_info
            // 
            this.rgv_info.BackColor = System.Drawing.SystemColors.Control;
            this.rgv_info.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_info.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_info.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgv_info.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_info.Location = new System.Drawing.Point(6, 56);
            // 
            // 
            // 
            this.rgv_info.MasterTemplate.AllowAddNewRow = false;
            this.rgv_info.MasterTemplate.EnableSorting = false;
            this.rgv_info.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.rgv_info.Name = "rgv_info";
            this.rgv_info.ReadOnly = true;
            this.rgv_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_info.ShowGroupPanel = false;
            this.rgv_info.Size = new System.Drawing.Size(840, 393);
            this.rgv_info.TabIndex = 6;
            this.rgv_info.Text = "radGridView1";
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.rgv_info);
            this.gbInfo.Controls.Add(this.btn_XL);
            this.gbInfo.Location = new System.Drawing.Point(3, 3);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(846, 452);
            this.gbInfo.TabIndex = 7;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "XXXXXXXXXXXXXX";
            // 
            // btn_XL
            // 
            this.btn_XL.Image = global::eHRM.Properties.Resources.export_excel;
            this.btn_XL.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_XL.Location = new System.Drawing.Point(797, 14);
            this.btn_XL.Name = "btn_XL";
            this.btn_XL.Size = new System.Drawing.Size(43, 36);
            this.btn_XL.TabIndex = 8;
            this.btn_XL.Click += new System.EventHandler(this.btn_XL_Click);
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.rpvp_attSummary);
            this.radPageView1.Controls.Add(this.rpvp_BioRawData);
            this.radPageView1.Controls.Add(this.rpvpChangeHistory);
            this.radPageView1.DefaultPage = this.rpvp_attSummary;
            this.radPageView1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPageView1.Location = new System.Drawing.Point(316, 28);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.rpvpChangeHistory;
            this.radPageView1.Size = new System.Drawing.Size(868, 485);
            this.radPageView1.TabIndex = 9;
            this.radPageView1.Text = "radPageView1";
            // 
            // rpvp_attSummary
            // 
            this.rpvp_attSummary.Controls.Add(this.gbInfo);
            this.rpvp_attSummary.ItemSize = new System.Drawing.SizeF(164F, 34F);
            this.rpvp_attSummary.Location = new System.Drawing.Point(10, 43);
            this.rpvp_attSummary.Name = "rpvp_attSummary";
            this.rpvp_attSummary.Size = new System.Drawing.Size(847, 431);
            this.rpvp_attSummary.Text = "Attendance Summary";
            // 
            // rpvp_BioRawData
            // 
            this.rpvp_BioRawData.Controls.Add(this.gb_biometric);
            this.rpvp_BioRawData.ItemSize = new System.Drawing.SizeF(151F, 34F);
            this.rpvp_BioRawData.Location = new System.Drawing.Point(10, 43);
            this.rpvp_BioRawData.Name = "rpvp_BioRawData";
            this.rpvp_BioRawData.Size = new System.Drawing.Size(847, 431);
            this.rpvp_BioRawData.Text = "Biometric Raw Data";
            // 
            // gb_biometric
            // 
            this.gb_biometric.Controls.Add(this.radButton2);
            this.gb_biometric.Controls.Add(this.btn_excel);
            this.gb_biometric.Controls.Add(this.rdp_go);
            this.gb_biometric.Controls.Add(this.rdp_to);
            this.gb_biometric.Controls.Add(this.rdp_from);
            this.gb_biometric.Controls.Add(this.label2);
            this.gb_biometric.Controls.Add(this.label1);
            this.gb_biometric.Controls.Add(this.rgv_bio_info);
            this.gb_biometric.Location = new System.Drawing.Point(0, 1);
            this.gb_biometric.Name = "gb_biometric";
            this.gb_biometric.Size = new System.Drawing.Size(846, 452);
            this.gb_biometric.TabIndex = 8;
            this.gb_biometric.TabStop = false;
            this.gb_biometric.Text = "XXXXXXXXXXXXXX";
            // 
            // radButton2
            // 
            this.radButton2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton2.Location = new System.Drawing.Point(482, 22);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(134, 24);
            this.radButton2.TabIndex = 23;
            this.radButton2.Text = "Attendance Status";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // btn_excel
            // 
            this.btn_excel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_excel.Image = global::eHRM.Properties.Resources.export_excel;
            this.btn_excel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_excel.Location = new System.Drawing.Point(783, 18);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(47, 37);
            this.btn_excel.TabIndex = 12;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // rdp_go
            // 
            this.rdp_go.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdp_go.Location = new System.Drawing.Point(307, 23);
            this.rdp_go.Name = "rdp_go";
            this.rdp_go.Size = new System.Drawing.Size(83, 24);
            this.rdp_go.TabIndex = 11;
            this.rdp_go.Text = "Raw Data";
            this.rdp_go.Click += new System.EventHandler(this.rdp_go_Click);
            // 
            // rdp_to
            // 
            this.rdp_to.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdp_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdp_to.Location = new System.Drawing.Point(198, 24);
            this.rdp_to.Name = "rdp_to";
            this.rdp_to.Size = new System.Drawing.Size(99, 23);
            this.rdp_to.TabIndex = 10;
            this.rdp_to.TabStop = false;
            this.rdp_to.Text = "15/08/2017";
            this.rdp_to.Value = new System.DateTime(2017, 8, 15, 15, 35, 59, 198);
            // 
            // rdp_from
            // 
            this.rdp_from.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdp_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdp_from.Location = new System.Drawing.Point(57, 25);
            this.rdp_from.Name = "rdp_from";
            this.rdp_from.Size = new System.Drawing.Size(99, 23);
            this.rdp_from.TabIndex = 9;
            this.rdp_from.TabStop = false;
            this.rdp_from.Text = "15/08/2017";
            this.rdp_from.Value = new System.DateTime(2017, 8, 15, 15, 35, 59, 198);
            this.rdp_from.Leave += new System.EventHandler(this.rdp_from_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "From";
            // 
            // rgv_bio_info
            // 
            this.rgv_bio_info.BackColor = System.Drawing.SystemColors.Control;
            this.rgv_bio_info.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_bio_info.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_bio_info.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgv_bio_info.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_bio_info.Location = new System.Drawing.Point(6, 65);
            // 
            // 
            // 
            this.rgv_bio_info.MasterTemplate.AllowAddNewRow = false;
            this.rgv_bio_info.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rgv_bio_info.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.rgv_bio_info.Name = "rgv_bio_info";
            this.rgv_bio_info.ReadOnly = true;
            this.rgv_bio_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_bio_info.ShowGroupPanel = false;
            this.rgv_bio_info.Size = new System.Drawing.Size(840, 384);
            this.rgv_bio_info.TabIndex = 6;
            this.rgv_bio_info.Text = "radGridView1";
            // 
            // rpvpChangeHistory
            // 
            this.rpvpChangeHistory.Controls.Add(this.gbRecordChanges);
            this.rpvpChangeHistory.ItemSize = new System.Drawing.SizeF(181F, 34F);
            this.rpvpChangeHistory.Location = new System.Drawing.Point(10, 43);
            this.rpvpChangeHistory.Name = "rpvpChangeHistory";
            this.rpvpChangeHistory.Size = new System.Drawing.Size(847, 431);
            this.rpvpChangeHistory.Text = "Record Changes History";
            // 
            // gbRecordChanges
            // 
            this.gbRecordChanges.Controls.Add(this.rgvHistory);
            this.gbRecordChanges.Controls.Add(this.btnGetHistory);
            this.gbRecordChanges.Controls.Add(this.btnXLRecordChange);
            this.gbRecordChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRecordChanges.Location = new System.Drawing.Point(0, 0);
            this.gbRecordChanges.Name = "gbRecordChanges";
            this.gbRecordChanges.Size = new System.Drawing.Size(847, 431);
            this.gbRecordChanges.TabIndex = 8;
            this.gbRecordChanges.TabStop = false;
            this.gbRecordChanges.Text = "XXXXXXXXXXXXXX";
            // 
            // rgvHistory
            // 
            this.rgvHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rgvHistory.Location = new System.Drawing.Point(3, 56);
            // 
            // 
            // 
            this.rgvHistory.MasterTemplate.AllowAddNewRow = false;
            this.rgvHistory.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.rgvHistory.Name = "rgvHistory";
            this.rgvHistory.ReadOnly = true;
            this.rgvHistory.Size = new System.Drawing.Size(841, 372);
            this.rgvHistory.TabIndex = 13;
            this.rgvHistory.Text = "radGridView1";
            // 
            // btnGetHistory
            // 
            this.btnGetHistory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetHistory.Location = new System.Drawing.Point(6, 26);
            this.btnGetHistory.Name = "btnGetHistory";
            this.btnGetHistory.Size = new System.Drawing.Size(146, 24);
            this.btnGetHistory.TabIndex = 12;
            this.btnGetHistory.Text = "Get Change History";
            this.btnGetHistory.Click += new System.EventHandler(this.btnGetHistory_Click);
            // 
            // btnXLRecordChange
            // 
            this.btnXLRecordChange.Image = global::eHRM.Properties.Resources.export_excel;
            this.btnXLRecordChange.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnXLRecordChange.Location = new System.Drawing.Point(797, 14);
            this.btnXLRecordChange.Name = "btnXLRecordChange";
            this.btnXLRecordChange.Size = new System.Drawing.Size(43, 36);
            this.btnXLRecordChange.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(150, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(37, 20);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = ">>";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // uc_LeaveHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.radPageView1);
            this.Controls.Add(this.rgv_staff);
            this.Controls.Add(this.textSearch);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uc_LeaveHistory";
            this.Size = new System.Drawing.Size(1192, 516);
            this.Load += new System.EventHandler(this.uc_LeaveHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info)).EndInit();
            this.gbInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_XL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.rpvp_attSummary.ResumeLayout(false);
            this.rpvp_BioRawData.ResumeLayout(false);
            this.gb_biometric.ResumeLayout(false);
            this.gb_biometric.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_excel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdp_go)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdp_to)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdp_from)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_bio_info.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_bio_info)).EndInit();
            this.rpvpChangeHistory.ResumeLayout(false);
            this.gbRecordChanges.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgvHistory.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGetHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXLRecordChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgv_staff;
        private Telerik.WinControls.UI.RadTextBox textSearch;
        private Telerik.WinControls.UI.RadGridView rgv_info;
        private System.Windows.Forms.GroupBox gbInfo;
        private Telerik.WinControls.UI.RadButton btn_XL;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage rpvp_attSummary;
        private Telerik.WinControls.UI.RadPageViewPage rpvp_BioRawData;
        private System.Windows.Forms.GroupBox gb_biometric;
        private Telerik.WinControls.UI.RadGridView rgv_bio_info;
        private Telerik.WinControls.UI.RadButton rdp_go;
        private Telerik.WinControls.UI.RadDateTimePicker rdp_to;
        private Telerik.WinControls.UI.RadDateTimePicker rdp_from;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private Telerik.WinControls.UI.RadButton btn_excel;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadPageViewPage rpvpChangeHistory;
        private System.Windows.Forms.GroupBox gbRecordChanges;
        private Telerik.WinControls.UI.RadButton btnXLRecordChange;
        private Telerik.WinControls.UI.RadButton btnGetHistory;
        private Telerik.WinControls.UI.RadGridView rgvHistory;
    }
}
