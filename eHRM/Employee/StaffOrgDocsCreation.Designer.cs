namespace eHRM.Employee
{
    partial class StaffOrgDocsCreation
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffOrgDocsCreation));
            Telerik.WinControls.Data.SortDescriptor sortDescriptor2 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rgv_staff = new Telerik.WinControls.UI.RadGridView();
            this.textSearch = new Telerik.WinControls.UI.RadTextBox();
            this.rdpDOD = new Telerik.WinControls.UI.RadDateTimePicker();
            this.txtDoc = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDeposit = new Telerik.WinControls.UI.RadButton();
            this.rgvDocs = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemarks = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdpDOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDocs.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks)).BeginInit();
            this.SuspendLayout();
            // 
            // rgv_staff
            // 
            this.rgv_staff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgv_staff.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_staff.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_staff.ForeColor = System.Drawing.Color.Black;
            this.rgv_staff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_staff.Location = new System.Drawing.Point(5, 30);
            // 
            // 
            // 
            this.rgv_staff.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "emp_code";
            gridViewTextBoxColumn8.HeaderText = "Code";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "emp_code";
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "emp_name";
            gridViewTextBoxColumn9.HeaderText = "Name of Employee";
            gridViewTextBoxColumn9.Name = "emp_name";
            gridViewTextBoxColumn9.Width = 256;
            gridViewCommandColumn3.EnableExpressionEditor = false;
            gridViewCommandColumn3.HeaderText = "-";
            gridViewCommandColumn3.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn3.Image")));
            gridViewCommandColumn3.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn3.Name = "column1";
            gridViewCommandColumn3.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewCommandColumn3.Width = 26;
            this.rgv_staff.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewCommandColumn3});
            this.rgv_staff.MasterTemplate.EnableGrouping = false;
            sortDescriptor2.PropertyName = "column1";
            this.rgv_staff.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor2});
            this.rgv_staff.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.rgv_staff.Name = "rgv_staff";
            this.rgv_staff.ReadOnly = true;
            this.rgv_staff.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_staff.Size = new System.Drawing.Size(321, 470);
            this.rgv_staff.TabIndex = 7;
            this.rgv_staff.Text = "radGridView1";
            this.rgv_staff.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rgv_staff_CommandCellClick);
            // 
            // textSearch
            // 
            this.textSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearch.Location = new System.Drawing.Point(5, 5);
            this.textSearch.Name = "textSearch";
            this.textSearch.NullText = "Search String";
            this.textSearch.Size = new System.Drawing.Size(319, 23);
            this.textSearch.TabIndex = 6;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // rdpDOD
            // 
            this.rdpDOD.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdpDOD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdpDOD.Location = new System.Drawing.Point(543, 138);
            this.rdpDOD.Name = "rdpDOD";
            this.rdpDOD.Size = new System.Drawing.Size(111, 25);
            this.rdpDOD.TabIndex = 45;
            this.rdpDOD.TabStop = false;
            this.rdpDOD.Text = "30-10-2023";
            this.rdpDOD.Value = new System.DateTime(2023, 10, 30, 13, 22, 49, 102);
            // 
            // txtDoc
            // 
            this.txtDoc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoc.Location = new System.Drawing.Point(9, 48);
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.Size = new System.Drawing.Size(483, 23);
            this.txtDoc.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(539, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "Date of Deposit";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 20);
            this.label9.TabIndex = 41;
            this.label9.Text = "Document Name ";
            // 
            // btnDeposit
            // 
            this.btnDeposit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeposit.Location = new System.Drawing.Point(676, 138);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(78, 24);
            this.btnDeposit.TabIndex = 47;
            this.btnDeposit.Text = "Deposit";
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // rgvDocs
            // 
            this.rgvDocs.BackColor = System.Drawing.SystemColors.Control;
            this.rgvDocs.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDocs.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgvDocs.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDocs.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDocs.Location = new System.Drawing.Point(338, 192);
            // 
            // 
            // 
            this.rgvDocs.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "autoid";
            gridViewTextBoxColumn10.HeaderText = "autoid";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "autoid";
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "emp_code";
            gridViewTextBoxColumn11.HeaderText = "Emp Code";
            gridViewTextBoxColumn11.Name = "emp_code";
            gridViewTextBoxColumn11.Width = 97;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "docNme";
            gridViewTextBoxColumn12.HeaderText = "Name of Documents";
            gridViewTextBoxColumn12.Name = "docNme";
            gridViewTextBoxColumn12.Width = 327;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "Dod";
            gridViewTextBoxColumn13.HeaderText = "DoD";
            gridViewTextBoxColumn13.Name = "Dod";
            gridViewTextBoxColumn13.Width = 99;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.FieldName = "depositedBy";
            gridViewTextBoxColumn14.HeaderText = "Deposited By";
            gridViewTextBoxColumn14.Name = "depositedBy";
            gridViewTextBoxColumn14.Width = 114;
            gridViewCommandColumn4.EnableExpressionEditor = false;
            gridViewCommandColumn4.HeaderText = "-";
            gridViewCommandColumn4.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn4.Image")));
            gridViewCommandColumn4.Name = "column1";
            gridViewCommandColumn4.Width = 25;
            this.rgvDocs.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewCommandColumn4});
            this.rgvDocs.MasterTemplate.EnableGrouping = false;
            this.rgvDocs.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.rgvDocs.Name = "rgvDocs";
            this.rgvDocs.ReadOnly = true;
            this.rgvDocs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDocs.Size = new System.Drawing.Size(758, 308);
            this.rgvDocs.TabIndex = 49;
            this.rgvDocs.Text = "radGridView1";
            this.rgvDocs.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rgvDocs_CommandCellClick);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.txtRemarks);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Controls.Add(this.label9);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.btnDeposit);
            this.radGroupBox1.Controls.Add(this.txtDoc);
            this.radGroupBox1.Controls.Add(this.rdpDOD);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "XXXXXXXXXXXXXXXXXXXX";
            this.radGroupBox1.Location = new System.Drawing.Point(337, 8);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(759, 178);
            this.radGroupBox1.TabIndex = 50;
            this.radGroupBox1.Text = "XXXXXXXXXXXXXXXXXXXX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 48;
            this.label2.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.AutoSize = false;
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(9, 108);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(483, 63);
            this.txtRemarks.TabIndex = 49;
            // 
            // StaffOrgDocsCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.rgvDocs);
            this.Controls.Add(this.rgv_staff);
            this.Controls.Add(this.textSearch);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StaffOrgDocsCreation";
            this.Size = new System.Drawing.Size(1109, 503);
            this.Load += new System.EventHandler(this.StaffOrgDocsCreation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdpDOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDocs.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgv_staff;
        private Telerik.WinControls.UI.RadTextBox textSearch;
        private Telerik.WinControls.UI.RadDateTimePicker rdpDOD;
        private Telerik.WinControls.UI.RadTextBox txtDoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private Telerik.WinControls.UI.RadButton btnDeposit;
        private Telerik.WinControls.UI.RadGridView rgvDocs;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadTextBox txtRemarks;
        private System.Windows.Forms.Label label2;
    }
}
