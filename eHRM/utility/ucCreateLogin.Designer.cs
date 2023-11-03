namespace eHRM.utility
{
    partial class ucCreateLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCreateLogin));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbModule = new System.Windows.Forms.ComboBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.ellipseShape1 = new Telerik.WinControls.EllipseShape();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLookFor = new System.Windows.Forms.TextBox();
            this.rgv_employee = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_employee.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Select Application :";
            // 
            // cmbModule
            // 
            this.cmbModule.FormattingEnabled = true;
            this.cmbModule.Items.AddRange(new object[] {
            "eHRM",
            "eInventory",
            "eAccounts",
            "eHealthcard"});
            this.cmbModule.Location = new System.Drawing.Point(134, 5);
            this.cmbModule.Name = "cmbModule";
            this.cmbModule.Size = new System.Drawing.Size(229, 28);
            this.cmbModule.TabIndex = 23;
            this.cmbModule.Text = "Select";
            // 
            // radButton1
            // 
            this.radButton1.Image = global::eHRM.Properties.Resources.search_16;
            this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton1.Location = new System.Drawing.Point(232, 63);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(25, 25);
            this.radButton1.TabIndex = 26;
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Image = global::eHRM.Properties.Resources.search_16;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Shape = this.ellipseShape1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Search Staff :";
            // 
            // txtLookFor
            // 
            this.txtLookFor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLookFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLookFor.Location = new System.Drawing.Point(134, 66);
            this.txtLookFor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLookFor.Name = "txtLookFor";
            this.txtLookFor.Size = new System.Drawing.Size(91, 22);
            this.txtLookFor.TabIndex = 24;
            // 
            // rgv_employee
            // 
            this.rgv_employee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgv_employee.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_employee.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_employee.ForeColor = System.Drawing.Color.Black;
            this.rgv_employee.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_employee.Location = new System.Drawing.Point(6, 99);
            // 
            // 
            // 
            this.rgv_employee.MasterTemplate.AllowAddNewRow = false;
            this.rgv_employee.MasterTemplate.AllowSearchRow = true;
            this.rgv_employee.MasterTemplate.AutoExpandGroups = true;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "emp_code";
            gridViewTextBoxColumn1.HeaderText = "emp_code";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "emp_code";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "emp_name";
            gridViewTextBoxColumn2.HeaderText = "Name of Employee";
            gridViewTextBoxColumn2.Name = "emp_name";
            gridViewTextBoxColumn2.Width = 297;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.HeaderText = "-";
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.Name = "column1";
            gridViewCommandColumn1.Width = 25;
            this.rgv_employee.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1});
            this.rgv_employee.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgv_employee.Name = "rgv_employee";
            this.rgv_employee.ReadOnly = true;
            this.rgv_employee.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_employee.ShowGroupPanel = false;
            this.rgv_employee.Size = new System.Drawing.Size(368, 240);
            this.rgv_employee.TabIndex = 27;
            this.rgv_employee.Text = "radGridView1";
            this.rgv_employee.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rgv_employee_CommandCellClick);
            // 
            // ucCreateLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rgv_employee);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLookFor);
            this.Controls.Add(this.cmbModule);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucCreateLogin";
            this.Size = new System.Drawing.Size(381, 344);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_employee.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_employee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbModule;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.EllipseShape ellipseShape1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLookFor;
        private Telerik.WinControls.UI.RadGridView rgv_employee;
    }
}
