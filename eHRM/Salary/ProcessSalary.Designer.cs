namespace eHRM.Salary
{
    partial class ProcessSalary
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.btnProcess = new Telerik.WinControls.UI.RadButton();
            this.btnProcessAtt = new Telerik.WinControls.UI.RadButton();
            this.btnProcessSalary = new Telerik.WinControls.UI.RadButton();
            this.rgbProces = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.rgvSalary = new Telerik.WinControls.UI.RadGridView();
            this.rdpDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.btnSubmit = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.rgvProcessInfo = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcessAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcessSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgbProces)).BeginInit();
            this.rgbProces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSalary.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdpDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvProcessInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvProcessInfo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(5, 21);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(208, 34);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Tag = "N";
            this.btnProcess.Text = "Step 1: Probation Process";
            this.btnProcess.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnProcessAtt
            // 
            this.btnProcessAtt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessAtt.Location = new System.Drawing.Point(5, 61);
            this.btnProcessAtt.Name = "btnProcessAtt";
            this.btnProcessAtt.Size = new System.Drawing.Size(208, 34);
            this.btnProcessAtt.TabIndex = 1;
            this.btnProcessAtt.Tag = "N";
            this.btnProcessAtt.Text = "Step 2: Process Attendance ";
            this.btnProcessAtt.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcessAtt.Click += new System.EventHandler(this.btnProcessAtt_Click);
            // 
            // btnProcessSalary
            // 
            this.btnProcessSalary.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessSalary.Location = new System.Drawing.Point(5, 101);
            this.btnProcessSalary.Name = "btnProcessSalary";
            this.btnProcessSalary.Size = new System.Drawing.Size(208, 34);
            this.btnProcessSalary.TabIndex = 2;
            this.btnProcessSalary.Tag = "N";
            this.btnProcessSalary.Text = "Step 3: Process Payouts";
            this.btnProcessSalary.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcessSalary.Click += new System.EventHandler(this.btnProcessSalary_Click);
            // 
            // rgbProces
            // 
            this.rgbProces.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rgbProces.Controls.Add(this.btnProcess);
            this.rgbProces.Controls.Add(this.btnProcessSalary);
            this.rgbProces.Controls.Add(this.btnProcessAtt);
            this.rgbProces.Enabled = false;
            this.rgbProces.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgbProces.HeaderText = "Process Steps";
            this.rgbProces.Location = new System.Drawing.Point(1, 53);
            this.rgbProces.Name = "rgbProces";
            this.rgbProces.Size = new System.Drawing.Size(219, 468);
            this.rgbProces.TabIndex = 3;
            this.rgbProces.Text = "Process Steps";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.rgvSalary);
            this.radGroupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox2.HeaderText = "Salary Info";
            this.radGroupBox2.Location = new System.Drawing.Point(227, 2);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(955, 378);
            this.radGroupBox2.TabIndex = 4;
            this.radGroupBox2.Text = "Salary Info";
            // 
            // rgvSalary
            // 
            this.rgvSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgvSalary.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvSalary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rgvSalary.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgvSalary.ForeColor = System.Drawing.Color.Black;
            this.rgvSalary.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvSalary.Location = new System.Drawing.Point(2, 24);
            // 
            // 
            // 
            this.rgvSalary.MasterTemplate.AllowAddNewRow = false;
            this.rgvSalary.MasterTemplate.EnableFiltering = true;
            this.rgvSalary.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgvSalary.Name = "rgvSalary";
            this.rgvSalary.ReadOnly = true;
            this.rgvSalary.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvSalary.ShowGroupPanel = false;
            this.rgvSalary.Size = new System.Drawing.Size(951, 352);
            this.rgvSalary.TabIndex = 0;
            this.rgvSalary.Text = "radGridView1";
            // 
            // rdpDate
            // 
            this.rdpDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdpDate.Location = new System.Drawing.Point(12, 13);
            this.rdpDate.Name = "rdpDate";
            this.rdpDate.Size = new System.Drawing.Size(113, 25);
            this.rdpDate.TabIndex = 6;
            this.rdpDate.TabStop = false;
            this.rdpDate.Text = "30/09/2021";
            this.rdpDate.Value = new System.DateTime(2021, 9, 30, 16, 58, 45, 277);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(143, 13);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(39, 24);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = ">>";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.rgvProcessInfo);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "Salary Process Info";
            this.radGroupBox1.Location = new System.Drawing.Point(229, 385);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(942, 136);
            this.radGroupBox1.TabIndex = 8;
            this.radGroupBox1.Text = "Salary Process Info";
            // 
            // rgvProcessInfo
            // 
            this.rgvProcessInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgvProcessInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvProcessInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgvProcessInfo.ForeColor = System.Drawing.Color.Black;
            this.rgvProcessInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvProcessInfo.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.rgvProcessInfo.MasterTemplate.AllowAddNewRow = false;
            this.rgvProcessInfo.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.rgvProcessInfo.Name = "rgvProcessInfo";
            this.rgvProcessInfo.ReadOnly = true;
            this.rgvProcessInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvProcessInfo.ShowGroupPanel = false;
            this.rgvProcessInfo.Size = new System.Drawing.Size(932, 105);
            this.rgvProcessInfo.TabIndex = 0;
            this.rgvProcessInfo.Text = "radGridView1";
            // 
            // ProcessSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 523);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rdpDate);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.rgbProces);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "ProcessSalary";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Process: Monthly Salary payout";
            this.Load += new System.EventHandler(this.ProcessSalary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcessAtt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcessSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgbProces)).EndInit();
            this.rgbProces.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgvSalary.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdpDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgvProcessInfo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvProcessInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnProcess;
        private Telerik.WinControls.UI.RadButton btnProcessAtt;
        private Telerik.WinControls.UI.RadButton btnProcessSalary;
        private Telerik.WinControls.UI.RadGroupBox rgbProces;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadDateTimePicker rdpDate;
        private Telerik.WinControls.UI.RadGridView rgvSalary;
        private Telerik.WinControls.UI.RadButton btnSubmit;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView rgvProcessInfo;
    }
}