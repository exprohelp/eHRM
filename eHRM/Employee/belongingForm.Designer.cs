namespace eHRM.Employee
{
    partial class belongingForm
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(belongingForm));
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor2 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.textSearch = new Telerik.WinControls.UI.RadTextBox();
            this.rgv_staff = new Telerik.WinControls.UI.RadGridView();
            this.cmbBelonging = new System.Windows.Forms.ComboBox();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.submitButton = new Telerik.WinControls.UI.RadButton();
            this.assetText = new Telerik.WinControls.UI.RadTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textDescription = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rgv_info = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.textSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.submitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // textSearch
            // 
            this.textSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearch.Location = new System.Drawing.Point(-1, 4);
            this.textSearch.Name = "textSearch";
            this.textSearch.NullText = "Search String";
            this.textSearch.Size = new System.Drawing.Size(275, 23);
            this.textSearch.TabIndex = 0;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            this.textSearch.Click += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // rgv_staff
            // 
            this.rgv_staff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgv_staff.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_staff.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_staff.ForeColor = System.Drawing.Color.Black;
            this.rgv_staff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_staff.Location = new System.Drawing.Point(-1, 29);
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
            gridViewTextBoxColumn2.Width = 220;
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
            this.rgv_staff.MasterTemplate.EnableGrouping = false;
            sortDescriptor1.PropertyName = "column1";
            this.rgv_staff.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.rgv_staff.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgv_staff.Name = "rgv_staff";
            this.rgv_staff.ReadOnly = true;
            this.rgv_staff.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_staff.Size = new System.Drawing.Size(275, 389);
            this.rgv_staff.TabIndex = 1;
            this.rgv_staff.Text = "radGridView1";
            this.rgv_staff.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rgv_staff_CommandCellClick);
            // 
            // cmbBelonging
            // 
            this.cmbBelonging.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBelonging.FormattingEnabled = true;
            this.cmbBelonging.Location = new System.Drawing.Point(122, 23);
            this.cmbBelonging.Name = "cmbBelonging";
            this.cmbBelonging.Size = new System.Drawing.Size(198, 28);
            this.cmbBelonging.TabIndex = 2;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.submitButton);
            this.radGroupBox1.Controls.Add(this.assetText);
            this.radGroupBox1.Controls.Add(this.label3);
            this.radGroupBox1.Controls.Add(this.textDescription);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.cmbBelonging);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "XXXXXXXXXXXXXXX";
            this.radGroupBox1.Location = new System.Drawing.Point(281, 6);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(698, 155);
            this.radGroupBox1.TabIndex = 3;
            this.radGroupBox1.Text = "XXXXXXXXXXXXXXX";
            // 
            // submitButton
            // 
            this.submitButton.Image = global::eHRM.Properties.Resources.click_32;
            this.submitButton.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.submitButton.Location = new System.Drawing.Point(611, 77);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 69);
            this.submitButton.TabIndex = 8;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // assetText
            // 
            this.assetText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assetText.Location = new System.Drawing.Point(537, 22);
            this.assetText.Name = "assetText";
            this.assetText.Size = new System.Drawing.Size(150, 23);
            this.assetText.TabIndex = 7;
            this.assetText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(469, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Asset No.";
            // 
            // textDescription
            // 
            this.textDescription.AutoSize = false;
            this.textDescription.Location = new System.Drawing.Point(10, 76);
            this.textDescription.Multiline = true;
            this.textDescription.Name = "textDescription";
            this.textDescription.NullText = "Type the detail of belonging";
            this.textDescription.Size = new System.Drawing.Size(440, 69);
            this.textDescription.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description of Belonging";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Belonging Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(516, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Belonging\'s Information";
            // 
            // rgv_info
            // 
            this.rgv_info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgv_info.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_info.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_info.ForeColor = System.Drawing.Color.Black;
            this.rgv_info.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_info.Location = new System.Drawing.Point(282, 189);
            // 
            // 
            // 
            this.rgv_info.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "autoid";
            gridViewTextBoxColumn3.HeaderText = "Auto_id";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "auto_id";
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.FieldName = "cr_date";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn1.HeaderText = "Date";
            gridViewDateTimeColumn1.Name = "cr_date";
            gridViewDateTimeColumn1.Width = 89;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "category";
            gridViewTextBoxColumn4.HeaderText = "Category";
            gridViewTextBoxColumn4.Name = "Category";
            gridViewTextBoxColumn4.Width = 154;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "description";
            gridViewTextBoxColumn5.HeaderText = "Description";
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "description";
            gridViewTextBoxColumn5.Width = 286;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "asset_no";
            gridViewTextBoxColumn6.HeaderText = "Asset No";
            gridViewTextBoxColumn6.Name = "asset_no";
            gridViewTextBoxColumn6.Width = 115;
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.HeaderText = "-";
            gridViewCommandColumn2.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn2.Image")));
            gridViewCommandColumn2.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn2.Name = "column1";
            gridViewCommandColumn2.Width = 25;
            this.rgv_info.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn3,
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewCommandColumn2});
            this.rgv_info.MasterTemplate.EnableGrouping = false;
            sortDescriptor2.PropertyName = "emp_name";
            this.rgv_info.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor2});
            this.rgv_info.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.rgv_info.Name = "rgv_info";
            this.rgv_info.ReadOnly = true;
            this.rgv_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_info.Size = new System.Drawing.Size(697, 227);
            this.rgv_info.TabIndex = 6;
            this.rgv_info.Text = "radGridView1";
            this.rgv_info.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.MasterTemplate_RowFormatting);
            this.rgv_info.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.MasterTemplate_CommandCellClick);
            // 
            // belongingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 418);
            this.Controls.Add(this.rgv_info);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.rgv_staff);
            this.Controls.Add(this.textSearch);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "belongingForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Belongings Entry Window";
            this.Load += new System.EventHandler(this.belongingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.submitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox textSearch;
        private Telerik.WinControls.UI.RadGridView rgv_staff;
        private System.Windows.Forms.ComboBox cmbBelonging;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadTextBox textDescription;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadTextBox assetText;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadGridView rgv_info;
        private Telerik.WinControls.UI.RadButton submitButton;
        private System.Windows.Forms.Label label4;
    }
}
