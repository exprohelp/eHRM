namespace eHRM.Employee
{
    partial class SalaryStructureSheet
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ddlunits = new Telerik.WinControls.UI.RadDropDownList();
            this.btnshow = new Telerik.WinControls.UI.RadButton();
            this.btnexcel = new Telerik.WinControls.UI.RadButton();
            this.grddata = new Telerik.WinControls.UI.RadGridView();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlunits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnshow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnexcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grddata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grddata.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(103, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(81, 19);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Select Unit ";
            // 
            // ddlunits
            // 
            this.ddlunits.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlunits.Location = new System.Drawing.Point(190, 6);
            this.ddlunits.Name = "ddlunits";
            this.ddlunits.Size = new System.Drawing.Size(538, 25);
            this.ddlunits.TabIndex = 0;
            ((Telerik.WinControls.UI.RadDropDownTextBoxElement)(this.ddlunits.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).Text = "";
            // 
            // btnshow
            // 
            this.btnshow.Location = new System.Drawing.Point(734, 7);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(34, 24);
            this.btnshow.TabIndex = 1;
            this.btnshow.Text = ">>";
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // btnexcel
            // 
            this.btnexcel.Image = global::eHRM.Properties.Resources.export_excel;
            this.btnexcel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnexcel.Location = new System.Drawing.Point(1069, 7);
            this.btnexcel.Name = "btnexcel";
            this.btnexcel.Size = new System.Drawing.Size(40, 37);
            this.btnexcel.TabIndex = 2;
            this.btnexcel.Click += new System.EventHandler(this.btnexcel_Click);
            // 
            // grddata
            // 
            this.grddata.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grddata.Cursor = System.Windows.Forms.Cursors.Default;
            this.grddata.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grddata.ForeColor = System.Drawing.Color.Black;
            this.grddata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grddata.Location = new System.Drawing.Point(1, 50);
            // 
            // 
            // 
            this.grddata.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Code";
            gridViewTextBoxColumn1.HeaderText = "Code";
            gridViewTextBoxColumn1.Name = "Code";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Name of Worker";
            gridViewTextBoxColumn2.HeaderText = "Name of Worker";
            gridViewTextBoxColumn2.Name = "workername";
            gridViewTextBoxColumn2.Width = 160;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Apr. Point";
            gridViewTextBoxColumn3.HeaderText = "Apr. Point";
            gridViewTextBoxColumn3.Name = "apr_point";
            gridViewTextBoxColumn3.Width = 76;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Designation";
            gridViewTextBoxColumn4.HeaderText = "Designation";
            gridViewTextBoxColumn4.Name = "Designation";
            gridViewTextBoxColumn4.Width = 119;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Status";
            gridViewTextBoxColumn5.HeaderText = "Status";
            gridViewTextBoxColumn5.Name = "Status";
            gridViewTextBoxColumn5.Width = 59;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Joining Date";
            gridViewTextBoxColumn6.HeaderText = "Joining Date";
            gridViewTextBoxColumn6.Name = "joininddate";
            gridViewTextBoxColumn6.Width = 77;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "Current Payout";
            gridViewTextBoxColumn7.HeaderText = "Current Payout";
            gridViewTextBoxColumn7.Name = "currentpayout";
            gridViewTextBoxColumn7.Width = 89;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Duty Shift";
            gridViewTextBoxColumn8.HeaderText = "Duty Shift";
            gridViewTextBoxColumn8.Name = "dutyshift";
            gridViewTextBoxColumn8.Width = 110;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "Incriment Information";
            gridViewTextBoxColumn9.HeaderText = "Incriment Information";
            gridViewTextBoxColumn9.Name = "incr_info";
            gridViewTextBoxColumn9.Width = 125;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "qualification";
            gridViewTextBoxColumn10.HeaderText = "Qualification";
            gridViewTextBoxColumn10.Name = "qualification";
            gridViewTextBoxColumn10.Width = 150;
            this.grddata.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.grddata.MasterTemplate.EnableGrouping = false;
            this.grddata.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grddata.Name = "grddata";
            this.grddata.ReadOnly = true;
            this.grddata.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grddata.Size = new System.Drawing.Size(1119, 461);
            this.grddata.TabIndex = 3;
            this.grddata.Text = "radGridView1";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(1, 7);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(72, 24);
            this.radButton1.TabIndex = 4;
            this.radButton1.Text = "Load Units";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // SalaryStructureSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 512);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.grddata);
            this.Controls.Add(this.btnexcel);
            this.Controls.Add(this.btnshow);
            this.Controls.Add(this.ddlunits);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SalaryStructureSheet";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salary Information Sheet For Meeting";
            this.Load += new System.EventHandler(this.SalaryStructureSheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlunits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnshow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnexcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grddata.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grddata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList ddlunits;
        private Telerik.WinControls.UI.RadButton btnshow;
        private Telerik.WinControls.UI.RadButton btnexcel;
        private Telerik.WinControls.UI.RadGridView grddata;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}
