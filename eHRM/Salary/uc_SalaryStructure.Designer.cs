namespace eHRM.Salary
{
    partial class uc_SalaryStructure
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rbtn_Submit = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.rbtn_SalarySheet = new Telerik.WinControls.UI.RadButton();
            this.lblFinYear = new System.Windows.Forms.Label();
            this.rgv_processChart = new Telerik.WinControls.UI.RadGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rbtn_Submit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtn_SalarySheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_processChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_processChart.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rbtn_Submit
            // 
            this.rbtn_Submit.Image = global::eHRM.Properties.Resources.click_32;
            this.rbtn_Submit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtn_Submit.Location = new System.Drawing.Point(982, 4);
            this.rbtn_Submit.Name = "rbtn_Submit";
            this.rbtn_Submit.Size = new System.Drawing.Size(49, 36);
            this.rbtn_Submit.TabIndex = 0;
            this.rbtn_Submit.Click += new System.EventHandler(this.rbtn_Submit_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Controls.Add(this.dtpTo);
            this.radGroupBox1.Controls.Add(this.cmbReportType);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.dtp_from);
            this.radGroupBox1.Controls.Add(this.rbtn_SalarySheet);
            this.radGroupBox1.Controls.Add(this.lblFinYear);
            this.radGroupBox1.Controls.Add(this.rbtn_Submit);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1200, 45);
            this.radGroupBox1.TabIndex = 1;
            // 
            // dtp_from
            // 
            this.dtp_from.CustomFormat = "MM-yyyy";
            this.dtp_from.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_from.Location = new System.Drawing.Point(673, 10);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(118, 27);
            this.dtp_from.TabIndex = 8;
            this.dtp_from.Leave += new System.EventHandler(this.dtp_from_Leave);
            // 
            // rbtn_SalarySheet
            // 
            this.rbtn_SalarySheet.Image = global::eHRM.Properties.Resources.export_excel;
            this.rbtn_SalarySheet.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtn_SalarySheet.Location = new System.Drawing.Point(1146, 4);
            this.rbtn_SalarySheet.Name = "rbtn_SalarySheet";
            this.rbtn_SalarySheet.Size = new System.Drawing.Size(49, 36);
            this.rbtn_SalarySheet.TabIndex = 7;
            this.rbtn_SalarySheet.Click += new System.EventHandler(this.rbtn_SalarySheet_Click);
            // 
            // lblFinYear
            // 
            this.lblFinYear.AutoSize = true;
            this.lblFinYear.Location = new System.Drawing.Point(629, 20);
            this.lblFinYear.Name = "lblFinYear";
            this.lblFinYear.Size = new System.Drawing.Size(38, 17);
            this.lblFinYear.TabIndex = 4;
            this.lblFinYear.Text = "From";
            // 
            // rgv_processChart
            // 
            this.rgv_processChart.BackColor = System.Drawing.SystemColors.Control;
            this.rgv_processChart.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_processChart.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this.rgv_processChart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgv_processChart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_processChart.Location = new System.Drawing.Point(6, 51);
            // 
            // 
            // 
            this.rgv_processChart.MasterTemplate.AllowAddNewRow = false;
            this.rgv_processChart.MasterTemplate.AllowColumnReorder = false;
            this.rgv_processChart.MasterTemplate.AllowDeleteRow = false;
            this.rgv_processChart.MasterTemplate.AllowEditRow = false;
            this.rgv_processChart.MasterTemplate.AutoExpandGroups = true;
            this.rgv_processChart.MasterTemplate.EnableFiltering = true;
            this.rgv_processChart.MasterTemplate.EnableGrouping = false;
            this.rgv_processChart.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgv_processChart.Name = "rgv_processChart";
            this.rgv_processChart.ReadOnly = true;
            this.rgv_processChart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_processChart.ShowGroupPanel = false;
            this.rgv_processChart.Size = new System.Drawing.Size(1189, 456);
            this.rgv_processChart.TabIndex = 2;
            this.rgv_processChart.Text = "rgv_processChart";
            this.rgv_processChart.Click += new System.EventHandler(this.rgv_processChart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(5, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Report Type";
            // 
            // cmbReportType
            // 
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(91, 12);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(514, 25);
            this.cmbReportType.TabIndex = 10;
            this.cmbReportType.Text = "Selecct Report Type";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "MM-yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(825, 10);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(118, 27);
            this.dtpTo.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(797, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "To";
            // 
            // uc_SalaryStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rgv_processChart);
            this.Controls.Add(this.radGroupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "uc_SalaryStructure";
            this.Size = new System.Drawing.Size(1200, 510);
            this.Load += new System.EventHandler(this.uc_SalaryStructure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rbtn_Submit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtn_SalarySheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_processChart.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_processChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton rbtn_Submit;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton rbtn_SalarySheet;
        private Telerik.WinControls.UI.RadGridView rgv_processChart;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Label lblFinYear;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
    }
}
