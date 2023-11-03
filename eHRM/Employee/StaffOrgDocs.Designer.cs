namespace eHRM.Employee
{
    partial class StaffOrgDocs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffOrgDocs));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rgv_staff = new Telerik.WinControls.UI.RadGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDoc = new Telerik.WinControls.UI.RadTextBox();
            this.rdpDOD = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rdp_DOR = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.document_Info = new System.Windows.Forms.PictureBox();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radpdfViewer = new Telerik.WinControls.UI.RadPdfViewer();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdpDOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdp_DOR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.document_Info)).BeginInit();
            this.radPageViewPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radpdfViewer)).BeginInit();
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
            gridViewTextBoxColumn2.Width = 256;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.HeaderText = "-";
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn1.Name = "column1";
            gridViewCommandColumn1.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewCommandColumn1.Width = 26;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "FileType";
            gridViewTextBoxColumn3.HeaderText = "FileType";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "FileType";
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "staff_photo";
            gridViewTextBoxColumn4.HeaderText = "staff_photo";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "staff_photo";
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "rp_flag";
            gridViewTextBoxColumn5.HeaderText = "Flag";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "rpflag";
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "docnme";
            gridViewTextBoxColumn6.HeaderText = "Document Name";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "docnme";
            this.rgv_staff.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.rgv_staff.MasterTemplate.EnableGrouping = false;
            sortDescriptor1.PropertyName = "column1";
            this.rgv_staff.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.rgv_staff.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgv_staff.Name = "rgv_staff";
            this.rgv_staff.ReadOnly = true;
            this.rgv_staff.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_staff.Size = new System.Drawing.Size(315, 511);
            this.rgv_staff.TabIndex = 5;
            this.rgv_staff.Text = "radGridView1";
            this.rgv_staff.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.MasterTemplate_RowFormatting);
            this.rgv_staff.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rgv_staff_CommandCellClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(324, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 20);
            this.label9.TabIndex = 35;
            this.label9.Text = "Document Name ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(762, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Date of Deposit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(911, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Date of Release";
            // 
            // txtDoc
            // 
            this.txtDoc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoc.Location = new System.Drawing.Point(328, 28);
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.ReadOnly = true;
            this.txtDoc.Size = new System.Drawing.Size(408, 23);
            this.txtDoc.TabIndex = 38;
            // 
            // rdpDOD
            // 
            this.rdpDOD.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdpDOD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdpDOD.Location = new System.Drawing.Point(766, 27);
            this.rdpDOD.Name = "rdpDOD";
            this.rdpDOD.ReadOnly = true;
            this.rdpDOD.Size = new System.Drawing.Size(111, 25);
            this.rdpDOD.TabIndex = 39;
            this.rdpDOD.TabStop = false;
            this.rdpDOD.Text = "30-10-2023";
            this.rdpDOD.Value = new System.DateTime(2023, 10, 30, 13, 22, 49, 102);
            // 
            // rdp_DOR
            // 
            this.rdp_DOR.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdp_DOR.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdp_DOR.Location = new System.Drawing.Point(914, 26);
            this.rdp_DOR.Name = "rdp_DOR";
            this.rdp_DOR.ReadOnly = true;
            this.rdp_DOR.Size = new System.Drawing.Size(111, 25);
            this.rdp_DOR.TabIndex = 40;
            this.rdp_DOR.TabStop = false;
            this.rdp_DOR.Text = "30-10-2023";
            this.rdp_DOR.Value = new System.DateTime(2023, 10, 30, 13, 22, 49, 102);
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Controls.Add(this.radPageViewPage2);
            this.radPageView1.DefaultPage = this.radPageViewPage1;
            this.radPageView1.Location = new System.Drawing.Point(328, 58);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage1;
            this.radPageView1.Size = new System.Drawing.Size(715, 481);
            this.radPageView1.TabIndex = 41;
            this.radPageView1.Text = "radPageView1";
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.document_Info);
            this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(74F, 28F);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(694, 433);
            this.radPageViewPage1.Text = "Image View";
            // 
            // document_Info
            // 
            this.document_Info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.document_Info.Location = new System.Drawing.Point(0, 3);
            this.document_Info.Name = "document_Info";
            this.document_Info.Size = new System.Drawing.Size(694, 427);
            this.document_Info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.document_Info.TabIndex = 6;
            this.document_Info.TabStop = false;
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.radpdfViewer);
            this.radPageViewPage2.ItemSize = new System.Drawing.SizeF(63F, 28F);
            this.radPageViewPage2.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(694, 433);
            this.radPageViewPage2.Text = "PDF View";
            // 
            // radpdfViewer
            // 
            this.radpdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radpdfViewer.Location = new System.Drawing.Point(0, 0);
            this.radpdfViewer.Name = "radpdfViewer";
            this.radpdfViewer.Size = new System.Drawing.Size(694, 433);
            this.radpdfViewer.TabIndex = 109;
            this.radpdfViewer.Text = "radPdfViewer1";
            this.radpdfViewer.ThumbnailsScaleFactor = 0.15F;
            // 
            // StaffOrgDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radPageView1);
            this.Controls.Add(this.rdp_DOR);
            this.Controls.Add(this.rdpDOD);
            this.Controls.Add(this.txtDoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.rgv_staff);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "StaffOrgDocs";
            this.Size = new System.Drawing.Size(1046, 544);
            this.Load += new System.EventHandler(this.StaffOrgDocs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdpDOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdp_DOR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.document_Info)).EndInit();
            this.radPageViewPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radpdfViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgv_staff;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadTextBox txtDoc;
        private Telerik.WinControls.UI.RadDateTimePicker rdpDOD;
        private Telerik.WinControls.UI.RadDateTimePicker rdp_DOR;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private System.Windows.Forms.PictureBox document_Info;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private Telerik.WinControls.UI.RadPdfViewer radpdfViewer;
    }
}
