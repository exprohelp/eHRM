namespace eHRM.Doc
{
    partial class uc_DocUpload
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn3 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn4 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApplicantName = new Telerik.WinControls.UI.RadTextBox();
            this.rdtFrom = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rdtTo = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rgv_info = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnGo = new Telerik.WinControls.UI.RadButton();
            this.btnGet = new Telerik.WinControls.UI.RadButton();
            this.btnUpload = new Telerik.WinControls.UI.RadButton();
            this.roundRectShape1 = new Telerik.WinControls.RoundRectShape(this.components);
            this.txtFilePath = new Telerik.WinControls.UI.RadTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.richTextRemarks = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAddType = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtApplicantName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddType)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbType
            // 
            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(10, 28);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(427, 29);
            this.cmbType.TabIndex = 4;
            this.cmbType.Text = "Select";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Document Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name of Document";
            // 
            // txtApplicantName
            // 
            this.txtApplicantName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplicantName.Location = new System.Drawing.Point(10, 33);
            this.txtApplicantName.MaxLength = 100;
            this.txtApplicantName.Name = "txtApplicantName";
            this.txtApplicantName.Size = new System.Drawing.Size(435, 25);
            this.txtApplicantName.TabIndex = 7;
            // 
            // rdtFrom
            // 
            this.rdtFrom.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdtFrom.Location = new System.Drawing.Point(60, 25);
            this.rdtFrom.Name = "rdtFrom";
            this.rdtFrom.Size = new System.Drawing.Size(104, 25);
            this.rdtFrom.TabIndex = 10;
            this.rdtFrom.TabStop = false;
            this.rdtFrom.Text = "28-04-2023";
            this.rdtFrom.Value = new System.DateTime(2023, 4, 28, 12, 46, 47, 843);
            // 
            // rdtTo
            // 
            this.rdtTo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdtTo.Location = new System.Drawing.Point(206, 25);
            this.rdtTo.Name = "rdtTo";
            this.rdtTo.Size = new System.Drawing.Size(104, 25);
            this.rdtTo.TabIndex = 11;
            this.rdtTo.TabStop = false;
            this.rdtTo.Text = "28-04-2023";
            this.rdtTo.Value = new System.DateTime(2023, 4, 28, 12, 46, 47, 843);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "To";
            // 
            // rgv_info
            // 
            this.rgv_info.BackColor = System.Drawing.SystemColors.Control;
            this.rgv_info.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_info.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rgv_info.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_info.ForeColor = System.Drawing.Color.Black;
            this.rgv_info.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_info.Location = new System.Drawing.Point(2, 56);
            // 
            // 
            // 
            this.rgv_info.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "autoid";
            gridViewTextBoxColumn9.HeaderText = "autoid";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "autoid";
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "doc_type";
            gridViewTextBoxColumn10.HeaderText = "Doc Type";
            gridViewTextBoxColumn10.Name = "doc_type";
            gridViewTextBoxColumn10.Width = 94;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "docname";
            gridViewTextBoxColumn11.HeaderText = "Name of Document";
            gridViewTextBoxColumn11.Name = "docname";
            gridViewTextBoxColumn11.Width = 175;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "DocPath";
            gridViewTextBoxColumn12.HeaderText = "DocPath";
            gridViewTextBoxColumn12.IsVisible = false;
            gridViewTextBoxColumn12.Name = "DocPath";
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "DocVirtualPath";
            gridViewTextBoxColumn13.HeaderText = "DocVirtualPath";
            gridViewTextBoxColumn13.IsVisible = false;
            gridViewTextBoxColumn13.Name = "DocVirtualPath";
            gridViewDateTimeColumn3.EnableExpressionEditor = false;
            gridViewDateTimeColumn3.FieldName = "cr_date";
            gridViewDateTimeColumn3.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn3.HeaderText = "Cr. Date";
            gridViewDateTimeColumn3.Name = "cr_date";
            gridViewDateTimeColumn3.Width = 187;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.FieldName = "createdBy";
            gridViewTextBoxColumn14.HeaderText = "Created By";
            gridViewTextBoxColumn14.Name = "createdBy";
            gridViewTextBoxColumn14.Width = 243;
            gridViewDateTimeColumn4.EnableExpressionEditor = false;
            gridViewDateTimeColumn4.FieldName = "updateDate";
            gridViewDateTimeColumn4.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn4.HeaderText = "Update Date";
            gridViewDateTimeColumn4.IsVisible = false;
            gridViewDateTimeColumn4.Name = "updateDate";
            gridViewDateTimeColumn4.Width = 88;
            gridViewTextBoxColumn15.EnableExpressionEditor = false;
            gridViewTextBoxColumn15.FieldName = "updateBy";
            gridViewTextBoxColumn15.HeaderText = "updateBy";
            gridViewTextBoxColumn15.IsVisible = false;
            gridViewTextBoxColumn15.Name = "updateBy";
            gridViewTextBoxColumn16.EnableExpressionEditor = false;
            gridViewTextBoxColumn16.FieldName = "isActive";
            gridViewTextBoxColumn16.HeaderText = "isActive";
            gridViewTextBoxColumn16.Name = "isActive";
            this.rgv_info.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewDateTimeColumn3,
            gridViewTextBoxColumn14,
            gridViewDateTimeColumn4,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16});
            this.rgv_info.MasterTemplate.EnableGrouping = false;
            this.rgv_info.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.rgv_info.Name = "rgv_info";
            this.rgv_info.ReadOnly = true;
            this.rgv_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_info.Size = new System.Drawing.Size(916, 265);
            this.rgv_info.TabIndex = 14;
            this.rgv_info.Text = "radGridView1";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnGo);
            this.radGroupBox1.Controls.Add(this.rgv_info);
            this.radGroupBox1.Controls.Add(this.label5);
            this.radGroupBox1.Controls.Add(this.rdtFrom);
            this.radGroupBox1.Controls.Add(this.rdtTo);
            this.radGroupBox1.Controls.Add(this.label4);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "Uploaded Information";
            this.radGroupBox1.Location = new System.Drawing.Point(3, 238);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(920, 323);
            this.radGroupBox1.TabIndex = 15;
            this.radGroupBox1.Text = "Uploaded Information";
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(316, 26);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(30, 24);
            this.btnGo.TabIndex = 20;
            this.btnGo.Text = ">>";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(344, 186);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(26, 24);
            this.btnGet.TabIndex = 19;
            this.btnGet.Text = "...";
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Enabled = false;
            this.btnUpload.Image = global::eHRM.Properties.Resources.upload_Doc_16;
            this.btnUpload.Location = new System.Drawing.Point(377, 186);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(62, 24);
            this.btnUpload.TabIndex = 20;
            this.btnUpload.Text = "Upload";
            this.btnUpload.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnUpload.GetChildAt(0))).Image = global::eHRM.Properties.Resources.upload_Doc_16;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnUpload.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnUpload.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnUpload.GetChildAt(0))).Text = "Upload";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnUpload.GetChildAt(0))).Shape = this.roundRectShape1;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilePath.Location = new System.Drawing.Point(10, 185);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(328, 23);
            this.txtFilePath.TabIndex = 18;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtFilePath.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtFilePath.GetChildAt(0))).Shape = this.roundRectShape1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Choose File To Upload";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileSize.Location = new System.Drawing.Point(8, 211);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(91, 17);
            this.lblFileSize.TabIndex = 21;
            this.lblFileSize.Text = "File Size: xxxxx";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.richTextRemarks);
            this.radGroupBox2.Controls.Add(this.label3);
            this.radGroupBox2.Controls.Add(this.label9);
            this.radGroupBox2.Controls.Add(this.txtApplicantName);
            this.radGroupBox2.Controls.Add(this.lblFileSize);
            this.radGroupBox2.Controls.Add(this.btnGet);
            this.radGroupBox2.Controls.Add(this.label6);
            this.radGroupBox2.Controls.Add(this.btnUpload);
            this.radGroupBox2.Controls.Add(this.txtFilePath);
            this.radGroupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(463, 5);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(455, 236);
            this.radGroupBox2.TabIndex = 24;
            // 
            // richTextRemarks
            // 
            this.richTextRemarks.Location = new System.Drawing.Point(11, 84);
            this.richTextRemarks.MaxLength = 500;
            this.richTextRemarks.Name = "richTextRemarks";
            this.richTextRemarks.Size = new System.Drawing.Size(427, 79);
            this.richTextRemarks.TabIndex = 29;
            this.richTextRemarks.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 20);
            this.label9.TabIndex = 28;
            this.label9.Text = "Description";
            // 
            // btnAddType
            // 
            this.btnAddType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddType.Location = new System.Drawing.Point(407, 3);
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Size = new System.Drawing.Size(30, 24);
            this.btnAddType.TabIndex = 25;
            this.btnAddType.Text = "+";
            this.btnAddType.Click += new System.EventHandler(this.btnAddType_Click);
            // 
            // uc_DocUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddType);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "uc_DocUpload";
            this.Size = new System.Drawing.Size(926, 567);
            this.Load += new System.EventHandler(this.uc_DocUpload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtApplicantName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadTextBox txtApplicantName;
        private Telerik.WinControls.UI.RadDateTimePicker rdtFrom;
        private Telerik.WinControls.UI.RadDateTimePicker rdtTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadGridView rgv_info;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnGet;
        private Telerik.WinControls.UI.RadButton btnUpload;
        private Telerik.WinControls.RoundRectShape roundRectShape1;
        private Telerik.WinControls.UI.RadTextBox txtFilePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Telerik.WinControls.UI.RadButton btnGo;
        private System.Windows.Forms.Label lblFileSize;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadButton btnAddType;
        private System.Windows.Forms.RichTextBox richTextRemarks;
        private System.Windows.Forms.Label label9;
    }
}
