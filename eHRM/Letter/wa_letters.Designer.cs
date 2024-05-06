namespace eHRM.Letter
{
    partial class wa_letters
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
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wa_letters));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rgv_info = new Telerik.WinControls.UI.RadGridView();
            this.rgbInfo = new Telerik.WinControls.UI.RadGroupBox();
            this.btnFiled = new Telerik.WinControls.UI.RadButton();
            this.lblAppriciationLetter = new System.Windows.Forms.Label();
            this.lblWarningLetter = new System.Windows.Forms.Label();
            this.ddl_letters = new Telerik.WinControls.UI.RadDropDownList();
            this.label2 = new System.Windows.Forms.Label();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.rpv_LetterInfo = new Telerik.WinControls.UI.RadPageViewPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.rpv_summary = new Telerik.WinControls.UI.RadPageViewPage();
            this.btnXL = new Telerik.WinControls.UI.RadButton();
            this.btnGet = new Telerik.WinControls.UI.RadButton();
            this.rg_detail = new Telerik.WinControls.UI.RadGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.rdTo = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.rdp_from = new Telerik.WinControls.UI.RadDateTimePicker();
            this.cmbCompId = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgbInfo)).BeginInit();
            this.rgbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFiled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddl_letters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.rpv_LetterInfo.SuspendLayout();
            this.rpv_summary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnXL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rg_detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rg_detail.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdp_from)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).BeginInit();
            this.SuspendLayout();
            // 
            // rgv_info
            // 
            this.rgv_info.BackColor = System.Drawing.SystemColors.Control;
            this.rgv_info.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_info.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_info.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgv_info.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_info.Location = new System.Drawing.Point(4, 47);
            // 
            // 
            // 
            this.rgv_info.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "emp_code";
            gridViewTextBoxColumn1.HeaderText = "Code";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "emp_code";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "emp_name";
            gridViewTextBoxColumn2.HeaderText = "Name of Staff";
            gridViewTextBoxColumn2.Name = "emp_name";
            gridViewTextBoxColumn2.Width = 345;
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.FieldName = "date";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            gridViewDateTimeColumn1.FormatString = "{0:dd-MM-yyyy}";
            gridViewDateTimeColumn1.HeaderText = "-";
            gridViewDateTimeColumn1.Name = "date";
            gridViewDateTimeColumn1.Width = 79;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.HeaderImage = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.HeaderImage")));
            gridViewCommandColumn1.HeaderText = "-";
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.Name = "column1";
            gridViewCommandColumn1.Width = 25;
            this.rgv_info.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewDateTimeColumn1,
            gridViewCommandColumn1});
            this.rgv_info.MasterTemplate.EnableFiltering = true;
            this.rgv_info.MasterTemplate.EnableGrouping = false;
            this.rgv_info.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgv_info.Name = "rgv_info";
            this.rgv_info.ReadOnly = true;
            this.rgv_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_info.Size = new System.Drawing.Size(495, 471);
            this.rgv_info.TabIndex = 0;
            this.rgv_info.Text = "radGridView1";
            this.rgv_info.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.MasterTemplate_CommandCellClick);
            // 
            // rgbInfo
            // 
            this.rgbInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rgbInfo.Controls.Add(this.btnFiled);
            this.rgbInfo.Controls.Add(this.lblAppriciationLetter);
            this.rgbInfo.Controls.Add(this.lblWarningLetter);
            this.rgbInfo.Controls.Add(this.ddl_letters);
            this.rgbInfo.Controls.Add(this.label2);
            this.rgbInfo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgbInfo.HeaderText = "XXXXXXXXXXXXXXXXX";
            this.rgbInfo.Location = new System.Drawing.Point(0, 3);
            this.rgbInfo.Name = "rgbInfo";
            this.rgbInfo.Size = new System.Drawing.Size(689, 100);
            this.rgbInfo.TabIndex = 1;
            this.rgbInfo.Text = "XXXXXXXXXXXXXXXXX";
            // 
            // btnFiled
            // 
            this.btnFiled.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiled.Location = new System.Drawing.Point(628, 65);
            this.btnFiled.Name = "btnFiled";
            this.btnFiled.Size = new System.Drawing.Size(56, 24);
            this.btnFiled.TabIndex = 114;
            this.btnFiled.Text = "Filed";
            this.btnFiled.Visible = false;
            this.btnFiled.Click += new System.EventHandler(this.btnFiled_Click);
            // 
            // lblAppriciationLetter
            // 
            this.lblAppriciationLetter.AutoSize = true;
            this.lblAppriciationLetter.Location = new System.Drawing.Point(463, 18);
            this.lblAppriciationLetter.Name = "lblAppriciationLetter";
            this.lblAppriciationLetter.Size = new System.Drawing.Size(155, 20);
            this.lblAppriciationLetter.TabIndex = 113;
            this.lblAppriciationLetter.Text = "Appriciation Letter XX";
            // 
            // lblWarningLetter
            // 
            this.lblWarningLetter.AutoSize = true;
            this.lblWarningLetter.Location = new System.Drawing.Point(261, 18);
            this.lblWarningLetter.Name = "lblWarningLetter";
            this.lblWarningLetter.Size = new System.Drawing.Size(128, 20);
            this.lblWarningLetter.TabIndex = 112;
            this.lblWarningLetter.Text = "Warning Letter XX";
            // 
            // ddl_letters
            // 
            this.ddl_letters.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_letters.Location = new System.Drawing.Point(17, 67);
            this.ddl_letters.Name = "ddl_letters";
            this.ddl_letters.Size = new System.Drawing.Size(588, 25);
            this.ddl_letters.TabIndex = 111;
            this.ddl_letters.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddl_letters_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Issued Letters";
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.rpv_LetterInfo);
            this.radPageView1.Controls.Add(this.rpv_summary);
            this.radPageView1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPageView1.Location = new System.Drawing.Point(504, 4);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.rpv_summary;
            this.radPageView1.Size = new System.Drawing.Size(713, 514);
            this.radPageView1.TabIndex = 2;
            this.radPageView1.Text = "radPageView1";
            // 
            // rpv_LetterInfo
            // 
            this.rpv_LetterInfo.Controls.Add(this.webBrowser1);
            this.rpv_LetterInfo.Controls.Add(this.rgbInfo);
            this.rpv_LetterInfo.ItemSize = new System.Drawing.SizeF(94F, 34F);
            this.rpv_LetterInfo.Location = new System.Drawing.Point(10, 43);
            this.rpv_LetterInfo.Name = "rpv_LetterInfo";
            this.rpv_LetterInfo.Size = new System.Drawing.Size(692, 460);
            this.rpv_LetterInfo.Text = "Letter View";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(4, 110);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(685, 353);
            this.webBrowser1.TabIndex = 2;
            // 
            // rpv_summary
            // 
            this.rpv_summary.Controls.Add(this.btnXL);
            this.rpv_summary.Controls.Add(this.btnGet);
            this.rpv_summary.Controls.Add(this.rg_detail);
            this.rpv_summary.Controls.Add(this.label4);
            this.rpv_summary.Controls.Add(this.rdTo);
            this.rpv_summary.Controls.Add(this.label3);
            this.rpv_summary.Controls.Add(this.rdp_from);
            this.rpv_summary.ItemSize = new System.Drawing.SizeF(132F, 34F);
            this.rpv_summary.Location = new System.Drawing.Point(10, 43);
            this.rpv_summary.Name = "rpv_summary";
            this.rpv_summary.Size = new System.Drawing.Size(692, 460);
            this.rpv_summary.Text = "Summary Report";
            // 
            // btnXL
            // 
            this.btnXL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXL.Image = global::eHRM.Properties.Resources.export_excel;
            this.btnXL.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnXL.Location = new System.Drawing.Point(635, 12);
            this.btnXL.Name = "btnXL";
            this.btnXL.Size = new System.Drawing.Size(42, 47);
            this.btnXL.TabIndex = 10;
            this.btnXL.Text = ">>";
            this.btnXL.Click += new System.EventHandler(this.btnXL_Click);
            // 
            // btnGet
            // 
            this.btnGet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGet.Location = new System.Drawing.Point(260, 35);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(35, 24);
            this.btnGet.TabIndex = 9;
            this.btnGet.Text = ">>";
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // rg_detail
            // 
            this.rg_detail.Location = new System.Drawing.Point(4, 67);
            // 
            // 
            // 
            this.rg_detail.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.rg_detail.Name = "rg_detail";
            this.rg_detail.Size = new System.Drawing.Size(688, 393);
            this.rg_detail.TabIndex = 8;
            this.rg_detail.Text = "radGridView1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "To";
            // 
            // rdTo
            // 
            this.rdTo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdTo.Location = new System.Drawing.Point(144, 35);
            this.rdTo.Name = "rdTo";
            this.rdTo.Size = new System.Drawing.Size(106, 25);
            this.rdTo.TabIndex = 6;
            this.rdTo.TabStop = false;
            this.rdTo.Text = "23-11-2021";
            this.rdTo.Value = new System.DateTime(2021, 11, 23, 16, 58, 51, 594);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "From";
            // 
            // rdp_from
            // 
            this.rdp_from.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdp_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdp_from.Location = new System.Drawing.Point(16, 35);
            this.rdp_from.Name = "rdp_from";
            this.rdp_from.Size = new System.Drawing.Size(106, 25);
            this.rdp_from.TabIndex = 0;
            this.rdp_from.TabStop = false;
            this.rdp_from.Text = "23-11-2021";
            this.rdp_from.Value = new System.DateTime(2021, 11, 23, 16, 58, 51, 594);
            this.rdp_from.Leave += new System.EventHandler(this.rdp_from_Leave);
            // 
            // cmbCompId
            // 
            this.cmbCompId.FormattingEnabled = true;
            this.cmbCompId.Items.AddRange(new object[] {
            "CHCL",
            "CHL",
            "CIMS",
            "CDL",
            "CPL",
            "IDC"});
            this.cmbCompId.Location = new System.Drawing.Point(81, 15);
            this.cmbCompId.Name = "cmbCompId";
            this.cmbCompId.Size = new System.Drawing.Size(145, 26);
            this.cmbCompId.TabIndex = 3;
            this.cmbCompId.Text = "Select";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Company";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(247, 15);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(35, 24);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = ">>";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // wa_letters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCompId);
            this.Controls.Add(this.radPageView1);
            this.Controls.Add(this.rgv_info);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "wa_letters";
            this.Size = new System.Drawing.Size(1225, 525);
            this.Load += new System.EventHandler(this.wa_letters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgbInfo)).EndInit();
            this.rgbInfo.ResumeLayout(false);
            this.rgbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFiled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddl_letters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.rpv_LetterInfo.ResumeLayout(false);
            this.rpv_summary.ResumeLayout(false);
            this.rpv_summary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnXL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rg_detail.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rg_detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdp_from)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgv_info;
        private Telerik.WinControls.UI.RadGroupBox rgbInfo;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage rpv_LetterInfo;
        private Telerik.WinControls.UI.RadPageViewPage rpv_summary;
        private System.Windows.Forms.ComboBox cmbCompId;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadButton btnSubmit;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadDropDownList ddl_letters;
        private System.Windows.Forms.Label lblAppriciationLetter;
        private System.Windows.Forms.Label lblWarningLetter;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private Telerik.WinControls.UI.RadButton btnXL;
        private Telerik.WinControls.UI.RadButton btnGet;
        private Telerik.WinControls.UI.RadGridView rg_detail;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadDateTimePicker rdTo;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadDateTimePicker rdp_from;
        private Telerik.WinControls.UI.RadButton btnFiled;
    }
}
