namespace eHRM.NABH
{
    partial class ucQualityIndicator
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn19 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn20 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn21 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor7 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition7 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn22 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn23 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn24 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor8 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition8 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdp_from = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rdp_to = new Telerik.WinControls.UI.RadDateTimePicker();
            this.btnSubmit = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.rgv_attritionRate = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.rgv_absenteeism = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdp_from)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdp_to)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_attritionRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_attritionRate.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_absenteeism)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_absenteeism.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            this.radGroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnSubmit);
            this.radGroupBox1.Controls.Add(this.rdp_to);
            this.radGroupBox1.Controls.Add(this.rdp_from);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(4, 4);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(681, 74);
            this.radGroupBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "To";
            // 
            // rdp_from
            // 
            this.rdp_from.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdp_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdp_from.Location = new System.Drawing.Point(62, 11);
            this.rdp_from.Name = "rdp_from";
            this.rdp_from.Size = new System.Drawing.Size(102, 25);
            this.rdp_from.TabIndex = 2;
            this.rdp_from.TabStop = false;
            this.rdp_from.Text = "10/06/2021";
            this.rdp_from.Value = new System.DateTime(2021, 6, 10, 16, 57, 29, 210);
            this.rdp_from.Leave += new System.EventHandler(this.rdp_from_Leave);
            // 
            // rdp_to
            // 
            this.rdp_to.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdp_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdp_to.Location = new System.Drawing.Point(61, 42);
            this.rdp_to.Name = "rdp_to";
            this.rdp_to.Size = new System.Drawing.Size(102, 25);
            this.rdp_to.TabIndex = 3;
            this.rdp_to.TabStop = false;
            this.rdp_to.Text = "10/06/2021";
            this.rdp_to.Value = new System.DateTime(2021, 6, 10, 16, 57, 29, 210);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(194, 16);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(73, 45);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.rgv_attritionRate);
            this.radGroupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox2.HeaderText = "Attrition Rate";
            this.radGroupBox2.Location = new System.Drawing.Point(4, 94);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(686, 202);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Attrition Rate";
            // 
            // rgv_attritionRate
            // 
            this.rgv_attritionRate.BackColor = System.Drawing.SystemColors.Control;
            this.rgv_attritionRate.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_attritionRate.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_attritionRate.ForeColor = System.Drawing.Color.Black;
            this.rgv_attritionRate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_attritionRate.Location = new System.Drawing.Point(6, 22);
            // 
            // 
            // 
            this.rgv_attritionRate.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "comp_code";
            gridViewTextBoxColumn13.HeaderText = "Code";
            gridViewTextBoxColumn13.Name = "comp_code";
            gridViewTextBoxColumn13.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn13.Width = 74;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.FieldName = "comp_name";
            gridViewTextBoxColumn14.HeaderText = "Name of Company";
            gridViewTextBoxColumn14.Name = "comp_name";
            gridViewTextBoxColumn14.Width = 303;
            gridViewDecimalColumn19.EnableExpressionEditor = false;
            gridViewDecimalColumn19.FieldName = "totalstaff";
            gridViewDecimalColumn19.HeaderText = "Total Staff";
            gridViewDecimalColumn19.Name = "totalstaff";
            gridViewDecimalColumn19.Width = 91;
            gridViewDecimalColumn20.EnableExpressionEditor = false;
            gridViewDecimalColumn20.FieldName = "resignno";
            gridViewDecimalColumn20.HeaderText = "Total Resign";
            gridViewDecimalColumn20.Name = "resignno";
            gridViewDecimalColumn20.Width = 97;
            gridViewDecimalColumn21.EnableExpressionEditor = false;
            gridViewDecimalColumn21.FieldName = "attrition";
            gridViewDecimalColumn21.HeaderText = "Attrition%";
            gridViewDecimalColumn21.Name = "attrition";
            gridViewDecimalColumn21.Width = 81;
            this.rgv_attritionRate.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewDecimalColumn19,
            gridViewDecimalColumn20,
            gridViewDecimalColumn21});
            this.rgv_attritionRate.MasterTemplate.EnableGrouping = false;
            sortDescriptor7.PropertyName = "comp_code";
            this.rgv_attritionRate.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor7});
            this.rgv_attritionRate.MasterTemplate.ViewDefinition = tableViewDefinition7;
            this.rgv_attritionRate.Name = "rgv_attritionRate";
            this.rgv_attritionRate.ReadOnly = true;
            this.rgv_attritionRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_attritionRate.Size = new System.Drawing.Size(675, 175);
            this.rgv_attritionRate.TabIndex = 0;
            this.rgv_attritionRate.Text = "radGridView1";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.rgv_absenteeism);
            this.radGroupBox3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox3.HeaderText = "Absenteesim Rate";
            this.radGroupBox3.Location = new System.Drawing.Point(3, 314);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(686, 209);
            this.radGroupBox3.TabIndex = 2;
            this.radGroupBox3.Text = "Absenteesim Rate";
            // 
            // rgv_absenteeism
            // 
            this.rgv_absenteeism.BackColor = System.Drawing.SystemColors.Control;
            this.rgv_absenteeism.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_absenteeism.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_absenteeism.ForeColor = System.Drawing.Color.Black;
            this.rgv_absenteeism.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_absenteeism.Location = new System.Drawing.Point(6, 22);
            // 
            // 
            // 
            this.rgv_absenteeism.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn15.EnableExpressionEditor = false;
            gridViewTextBoxColumn15.FieldName = "comp_code";
            gridViewTextBoxColumn15.HeaderText = "Code";
            gridViewTextBoxColumn15.Name = "comp_code";
            gridViewTextBoxColumn15.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn15.Width = 74;
            gridViewTextBoxColumn16.EnableExpressionEditor = false;
            gridViewTextBoxColumn16.FieldName = "comp_name";
            gridViewTextBoxColumn16.HeaderText = "Name of Company";
            gridViewTextBoxColumn16.Name = "comp_name";
            gridViewTextBoxColumn16.Width = 289;
            gridViewDecimalColumn22.EnableExpressionEditor = false;
            gridViewDecimalColumn22.FieldName = "noe";
            gridViewDecimalColumn22.HeaderText = "Total Staff";
            gridViewDecimalColumn22.Name = "noe";
            gridViewDecimalColumn22.Width = 87;
            gridViewDecimalColumn23.EnableExpressionEditor = false;
            gridViewDecimalColumn23.FieldName = "ual";
            gridViewDecimalColumn23.HeaderText = "Un-Authorise Leave";
            gridViewDecimalColumn23.Name = "ual";
            gridViewDecimalColumn23.Width = 104;
            gridViewDecimalColumn24.EnableExpressionEditor = false;
            gridViewDecimalColumn24.FieldName = "absenteeism";
            gridViewDecimalColumn24.HeaderText = "Absenteeism%";
            gridViewDecimalColumn24.Name = "absenteeism";
            gridViewDecimalColumn24.Width = 81;
            this.rgv_absenteeism.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewDecimalColumn22,
            gridViewDecimalColumn23,
            gridViewDecimalColumn24});
            this.rgv_absenteeism.MasterTemplate.EnableGrouping = false;
            sortDescriptor8.PropertyName = "comp_code";
            this.rgv_absenteeism.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor8});
            this.rgv_absenteeism.MasterTemplate.ViewDefinition = tableViewDefinition8;
            this.rgv_absenteeism.Name = "rgv_absenteeism";
            this.rgv_absenteeism.ReadOnly = true;
            this.rgv_absenteeism.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_absenteeism.Size = new System.Drawing.Size(675, 182);
            this.rgv_absenteeism.TabIndex = 0;
            this.rgv_absenteeism.Text = "radGridView1";
            // 
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.Controls.Add(this.label3);
            this.radGroupBox4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox4.HeaderText = "Staff Satisfaction Index";
            this.radGroupBox4.Location = new System.Drawing.Point(696, 4);
            this.radGroupBox4.Name = "radGroupBox4";
            this.radGroupBox4.Size = new System.Drawing.Size(463, 519);
            this.radGroupBox4.TabIndex = 3;
            this.radGroupBox4.Text = "Staff Satisfaction Index";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "In Process";
            // 
            // ucQualityIndicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radGroupBox4);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucQualityIndicator";
            this.Size = new System.Drawing.Size(1170, 530);
            this.Load += new System.EventHandler(this.ucQualityIndicator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdp_from)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdp_to)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgv_attritionRate.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_attritionRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgv_absenteeism.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_absenteeism)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            this.radGroupBox4.ResumeLayout(false);
            this.radGroupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnSubmit;
        private Telerik.WinControls.UI.RadDateTimePicker rdp_to;
        private Telerik.WinControls.UI.RadDateTimePicker rdp_from;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGridView rgv_attritionRate;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadGridView rgv_absenteeism;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private System.Windows.Forms.Label label3;
    }
}
