namespace eHRM.Employee
{
    partial class uc_SetCategory
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_SetCategory));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rgv_employee = new Telerik.WinControls.UI.RadGridView();
            this.btnSubmit = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_employee.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).BeginInit();
            this.SuspendLayout();
            // 
            // rgv_employee
            // 
            this.rgv_employee.BackColor = System.Drawing.SystemColors.Control;
            this.rgv_employee.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_employee.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_employee.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgv_employee.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_employee.Location = new System.Drawing.Point(4, 33);
            // 
            // 
            // 
            this.rgv_employee.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "emp_code";
            gridViewTextBoxColumn1.HeaderText = "emp_code";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "emp_code";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "emp_name";
            gridViewTextBoxColumn2.HeaderText = "Name of Staff";
            gridViewTextBoxColumn2.Name = "emp_name";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 302;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "status";
            gridViewTextBoxColumn3.HeaderText = "Status";
            gridViewTextBoxColumn3.Name = "status";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 181;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "designation";
            gridViewTextBoxColumn4.HeaderText = "Designation";
            gridViewTextBoxColumn4.Name = "designation";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 215;
            gridViewComboBoxColumn1.EnableExpressionEditor = false;
            gridViewComboBoxColumn1.FieldName = "category";
            gridViewComboBoxColumn1.HeaderText = "Category";
            gridViewComboBoxColumn1.Name = "category";
            gridViewComboBoxColumn1.Width = 168;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.HeaderImage = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.HeaderImage")));
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.Name = "column3";
            gridViewCommandColumn1.Width = 25;
            this.rgv_employee.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewComboBoxColumn1,
            gridViewCommandColumn1});
            this.rgv_employee.MasterTemplate.EnableFiltering = true;
            this.rgv_employee.MasterTemplate.EnableGrouping = false;
            this.rgv_employee.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgv_employee.Name = "rgv_employee";
            this.rgv_employee.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_employee.Size = new System.Drawing.Size(922, 529);
            this.rgv_employee.TabIndex = 0;
            this.rgv_employee.Text = "radGridView1";
            this.rgv_employee.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rgv_employee_CommandCellClick);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSubmit.Location = new System.Drawing.Point(7, 3);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(130, 25);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Load Staff List";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // uc_SetCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rgv_employee);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uc_SetCategory";
            this.Size = new System.Drawing.Size(930, 562);
            ((System.ComponentModel.ISupportInitialize)(this.rgv_employee.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgv_employee;
        private Telerik.WinControls.UI.RadButton btnSubmit;
    }
}
