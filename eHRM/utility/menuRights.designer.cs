namespace eHRM.utility
{
    partial class menuRights
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.GroupDescriptor groupDescriptor1 = new Telerik.WinControls.Data.GroupDescriptor();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.Data.GroupDescriptor groupDescriptor2 = new Telerik.WinControls.Data.GroupDescriptor();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor2 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menuRights));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rgv_info = new Telerik.WinControls.UI.RadGridView();
            this.rgv_employee = new Telerik.WinControls.UI.RadGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_options = new System.Windows.Forms.ComboBox();
            this.btn_mark = new Telerik.WinControls.UI.RadButton();
            this.ellipseShape1 = new Telerik.WinControls.EllipseShape();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLookFor = new System.Windows.Forms.TextBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_employee.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_mark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rgv_info
            // 
            this.rgv_info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgv_info.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_info.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.rgv_info.ForeColor = System.Drawing.Color.Black;
            this.rgv_info.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_info.Location = new System.Drawing.Point(355, 39);
            // 
            // 
            // 
            this.rgv_info.MasterTemplate.AllowAddNewRow = false;
            this.rgv_info.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "element_name";
            gridViewTextBoxColumn1.HeaderText = "elementName";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "element_name";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "cmt_text";
            gridViewTextBoxColumn2.HeaderText = "Tab";
            gridViewTextBoxColumn2.Name = "cmd_tab";
            gridViewTextBoxColumn2.Width = 165;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "grp_text";
            gridViewTextBoxColumn3.HeaderText = "Group";
            gridViewTextBoxColumn3.Name = "grp_text";
            gridViewTextBoxColumn3.Width = 126;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "element_text";
            gridViewTextBoxColumn4.HeaderText = "Menu Name";
            gridViewTextBoxColumn4.Name = "element_text";
            gridViewTextBoxColumn4.Width = 319;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "allow";
            gridViewTextBoxColumn5.HeaderText = "Flag";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "allow";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.HeaderText = "Action";
            gridViewCommandColumn1.Name = "A";
            gridViewCommandColumn1.Width = 64;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "options";
            gridViewTextBoxColumn6.HeaderText = "options";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "options";
            this.rgv_info.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewCommandColumn1,
            gridViewTextBoxColumn6});
            sortDescriptor1.PropertyName = "cmd_tab";
            groupDescriptor1.GroupNames.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            sortDescriptor2.PropertyName = "grp_text";
            groupDescriptor2.GroupNames.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor2});
            this.rgv_info.MasterTemplate.GroupDescriptors.AddRange(new Telerik.WinControls.Data.GroupDescriptor[] {
            groupDescriptor1,
            groupDescriptor2});
            this.rgv_info.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgv_info.Name = "rgv_info";
            this.rgv_info.ReadOnly = true;
            this.rgv_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_info.ShowGroupPanel = false;
            this.rgv_info.Size = new System.Drawing.Size(473, 459);
            this.rgv_info.TabIndex = 0;
            this.rgv_info.Text = "radGridView1";
            this.rgv_info.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.rgv_info_RowFormatting);
            this.rgv_info.ViewCellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.rgv_info_ViewCellFormatting);
            this.rgv_info.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rgv_info_CommandCellClick);
            // 
            // rgv_employee
            // 
            this.rgv_employee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgv_employee.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_employee.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_employee.ForeColor = System.Drawing.Color.Black;
            this.rgv_employee.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_employee.Location = new System.Drawing.Point(1, 34);
            // 
            // 
            // 
            this.rgv_employee.MasterTemplate.AllowAddNewRow = false;
            this.rgv_employee.MasterTemplate.AllowSearchRow = true;
            this.rgv_employee.MasterTemplate.AutoExpandGroups = true;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "emp_code";
            gridViewTextBoxColumn7.HeaderText = "emp_code";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "emp_code";
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "emp_name";
            gridViewTextBoxColumn8.HeaderText = "Name of Employee";
            gridViewTextBoxColumn8.Name = "emp_name";
            gridViewTextBoxColumn8.Width = 270;
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.HeaderText = "-";
            gridViewCommandColumn2.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn2.Image")));
            gridViewCommandColumn2.Name = "column1";
            gridViewCommandColumn2.Width = 25;
            this.rgv_employee.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewCommandColumn2});
            this.rgv_employee.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.rgv_employee.Name = "rgv_employee";
            this.rgv_employee.ReadOnly = true;
            this.rgv_employee.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_employee.ShowGroupPanel = false;
            this.rgv_employee.Size = new System.Drawing.Size(349, 463);
            this.rgv_employee.TabIndex = 2;
            this.rgv_employee.Text = "radGridView1";
            this.rgv_employee.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.MasterTemplate_CommandCellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Right Options";
            // 
            // cmb_options
            // 
            this.cmb_options.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_options.FormattingEnabled = true;
            this.cmb_options.Items.AddRange(new object[] {
            "Admin",
            "Operator"});
            this.cmb_options.Location = new System.Drawing.Point(464, 5);
            this.cmb_options.Name = "cmb_options";
            this.cmb_options.Size = new System.Drawing.Size(165, 28);
            this.cmb_options.TabIndex = 4;
            this.cmb_options.Text = "Admin";
            // 
            // btn_mark
            // 
            this.btn_mark.Image = global::eHRM.Properties.Resources.click16;
            this.btn_mark.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_mark.Location = new System.Drawing.Point(635, 3);
            this.btn_mark.Name = "btn_mark";
            this.btn_mark.Size = new System.Drawing.Size(30, 30);
            this.btn_mark.TabIndex = 5;
            this.btn_mark.Click += new System.EventHandler(this.btn_mark_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btn_mark.GetChildAt(0))).Image = global::eHRM.Properties.Resources.click16;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btn_mark.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btn_mark.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btn_mark.GetChildAt(0))).Shape = this.ellipseShape1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Search :";
            // 
            // txtLookFor
            // 
            this.txtLookFor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLookFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLookFor.Location = new System.Drawing.Point(72, 6);
            this.txtLookFor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLookFor.Name = "txtLookFor";
            this.txtLookFor.Size = new System.Drawing.Size(91, 22);
            this.txtLookFor.TabIndex = 18;
            // 
            // radButton1
            // 
            this.radButton1.Image = global::eHRM.Properties.Resources.search_16;
            this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton1.Location = new System.Drawing.Point(170, 3);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(25, 25);
            this.radButton1.TabIndex = 20;
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Image = global::eHRM.Properties.Resources.search_16;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Shape = this.ellipseShape1;
            // 
            // menuRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 498);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLookFor);
            this.Controls.Add(this.btn_mark);
            this.Controls.Add(this.cmb_options);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rgv_employee);
            this.Controls.Add(this.rgv_info);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "menuRights";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "Assign Menu Rights To User";
            this.Load += new System.EventHandler(this.menuRights_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_employee.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_mark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgv_info;
        private Telerik.WinControls.UI.RadGridView rgv_employee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_options;
        private Telerik.WinControls.UI.RadButton btn_mark;
        private Telerik.WinControls.EllipseShape ellipseShape1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLookFor;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}
