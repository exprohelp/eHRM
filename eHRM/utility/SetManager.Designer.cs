namespace eHRM.utility
{
    partial class SetManager
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetManager));
            Telerik.WinControls.Data.SortDescriptor sortDescriptor3 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.GroupDescriptor groupDescriptor2 = new Telerik.WinControls.Data.GroupDescriptor();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor4 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rgv_staff = new Telerik.WinControls.UI.RadGridView();
            this.textSearch = new Telerik.WinControls.UI.RadTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rgv_Units = new Telerik.WinControls.UI.RadGridView();
            this.cmbDivision = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSearch)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_Units)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_Units.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rgv_staff
            // 
            this.rgv_staff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgv_staff.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_staff.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_staff.ForeColor = System.Drawing.Color.Black;
            this.rgv_staff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_staff.Location = new System.Drawing.Point(0, 29);
            // 
            // 
            // 
            this.rgv_staff.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "emp_code";
            gridViewTextBoxColumn6.HeaderText = "Code";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "emp_code";
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "emp_name";
            gridViewTextBoxColumn7.HeaderText = "Name of Employee";
            gridViewTextBoxColumn7.Name = "emp_name";
            gridViewTextBoxColumn7.Width = 220;
            gridViewCommandColumn3.EnableExpressionEditor = false;
            gridViewCommandColumn3.HeaderText = "-";
            gridViewCommandColumn3.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn3.Image")));
            gridViewCommandColumn3.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn3.Name = "column1";
            gridViewCommandColumn3.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewCommandColumn3.Width = 25;
            this.rgv_staff.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewCommandColumn3});
            this.rgv_staff.MasterTemplate.EnableGrouping = false;
            sortDescriptor3.PropertyName = "column1";
            this.rgv_staff.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor3});
            this.rgv_staff.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.rgv_staff.Name = "rgv_staff";
            this.rgv_staff.ReadOnly = true;
            this.rgv_staff.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_staff.Size = new System.Drawing.Size(278, 408);
            this.rgv_staff.TabIndex = 3;
            this.rgv_staff.Text = "radGridView1";
            this.rgv_staff.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rgv_staff_CommandCellClick);
            // 
            // textSearch
            // 
            this.textSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearch.Location = new System.Drawing.Point(0, 4);
            this.textSearch.Name = "textSearch";
            this.textSearch.NullText = "Search String";
            this.textSearch.Size = new System.Drawing.Size(277, 23);
            this.textSearch.TabIndex = 2;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rgv_Units);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.cmbDivision);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(284, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 433);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Divisions";
            // 
            // rgv_Units
            // 
            this.rgv_Units.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgv_Units.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_Units.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_Units.ForeColor = System.Drawing.Color.Black;
            this.rgv_Units.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_Units.Location = new System.Drawing.Point(0, 60);
            // 
            // 
            // 
            this.rgv_Units.MasterTemplate.AllowAddNewRow = false;
            this.rgv_Units.MasterTemplate.AutoExpandGroups = true;
            gridViewTextBoxColumn8.AllowFiltering = false;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "unit_id";
            gridViewTextBoxColumn8.HeaderText = "unit_id";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "unit_id";
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "unit_name";
            gridViewTextBoxColumn9.HeaderText = "Name of Unit";
            gridViewTextBoxColumn9.Name = "unit_name";
            gridViewTextBoxColumn9.Width = 234;
            gridViewCommandColumn4.EnableExpressionEditor = false;
            gridViewCommandColumn4.HeaderText = "-";
            gridViewCommandColumn4.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn4.Image")));
            gridViewCommandColumn4.Name = "column1";
            gridViewCommandColumn4.Width = 25;
            gridViewTextBoxColumn10.AllowFiltering = false;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "manager";
            gridViewTextBoxColumn10.HeaderText = "Manager";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "manager";
            this.rgv_Units.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewCommandColumn4,
            gridViewTextBoxColumn10});
            this.rgv_Units.MasterTemplate.EnableFiltering = true;
            sortDescriptor4.PropertyName = "manager";
            groupDescriptor2.GroupNames.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor4});
            this.rgv_Units.MasterTemplate.GroupDescriptors.AddRange(new Telerik.WinControls.Data.GroupDescriptor[] {
            groupDescriptor2});
            this.rgv_Units.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.rgv_Units.Name = "rgv_Units";
            this.rgv_Units.ReadOnly = true;
            this.rgv_Units.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_Units.ShowGroupPanel = false;
            this.rgv_Units.Size = new System.Drawing.Size(318, 367);
            this.rgv_Units.TabIndex = 25;
            this.rgv_Units.Text = "radGridView1";
            this.rgv_Units.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rgv_Units_CommandCellClick);
            // 
            // cmbDivision
            // 
            this.cmbDivision.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDivision.FormattingEnabled = true;
            this.cmbDivision.Items.AddRange(new object[] {
            "Diagnostic",
            "Pharmacy",
            "Hospital"});
            this.cmbDivision.Location = new System.Drawing.Point(6, 25);
            this.cmbDivision.Name = "cmbDivision";
            this.cmbDivision.Size = new System.Drawing.Size(178, 29);
            this.cmbDivision.TabIndex = 0;
            this.cmbDivision.Text = "DIAGNOSTIC";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(191, 25);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(42, 28);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = ">>>";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // SetManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 436);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rgv_staff);
            this.Controls.Add(this.textSearch);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SetManager";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "Set Manager Against Unit";
            this.Load += new System.EventHandler(this.SetManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSearch)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgv_Units.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_Units)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgv_staff;
        private Telerik.WinControls.UI.RadTextBox textSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadGridView rgv_Units;
        private System.Windows.Forms.ComboBox cmbDivision;
        private Telerik.WinControls.UI.RadButton btnSubmit;
    }
}
