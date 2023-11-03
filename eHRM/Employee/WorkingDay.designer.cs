namespace eHRM
{
    partial class WorkingDay
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem7 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkingDay));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.RadListDataItem radListDataItem8 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem9 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem10 = new Telerik.WinControls.UI.RadListDataItem();
            this.txtsearchemp = new Telerik.WinControls.UI.RadTextBox();
            this.btnsearch = new Telerik.WinControls.UI.RadButton();
            this.ddlemployee = new Telerik.WinControls.UI.RadDropDownList();
            this.ddlweekday = new Telerik.WinControls.UI.RadDropDownList();
            this.rdgrd = new Telerik.WinControls.UI.RadGridView();
            this.btnaddwd = new Telerik.WinControls.UI.RadButton();
            this.ddlvalue = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.txtsearchemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnsearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlemployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlweekday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgrd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgrd.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnaddwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlvalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtsearchemp
            // 
            this.txtsearchemp.Location = new System.Drawing.Point(12, 12);
            this.txtsearchemp.Name = "txtsearchemp";
            this.txtsearchemp.NullText = "Search Employee";
            this.txtsearchemp.Size = new System.Drawing.Size(185, 23);
            this.txtsearchemp.TabIndex = 0;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtsearchemp.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtsearchemp.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txtsearchemp.GetChildAt(0).GetChildAt(0))).NullText = "Search Employee";
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txtsearchemp.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(203, 12);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(43, 24);
            this.btnsearch.TabIndex = 1;
            this.btnsearch.Text = " >> ";
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // ddlemployee
            // 
            this.ddlemployee.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlemployee.Location = new System.Drawing.Point(252, 12);
            this.ddlemployee.Name = "ddlemployee";
            this.ddlemployee.NullText = "Select Employee";
            this.ddlemployee.Size = new System.Drawing.Size(219, 23);
            this.ddlemployee.TabIndex = 2;
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlemployee.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlemployee.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // ddlweekday
            // 
            this.ddlweekday.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem1.Text = "Monday";
            radListDataItem2.Text = "Tuesday";
            radListDataItem3.Text = "Wednesday";
            radListDataItem4.Text = "Thursday";
            radListDataItem5.Text = "Friday";
            radListDataItem6.Text = "Saturday";
            radListDataItem7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem7.Text = "Sunday";
            this.ddlweekday.Items.Add(radListDataItem1);
            this.ddlweekday.Items.Add(radListDataItem2);
            this.ddlweekday.Items.Add(radListDataItem3);
            this.ddlweekday.Items.Add(radListDataItem4);
            this.ddlweekday.Items.Add(radListDataItem5);
            this.ddlweekday.Items.Add(radListDataItem6);
            this.ddlweekday.Items.Add(radListDataItem7);
            this.ddlweekday.Location = new System.Drawing.Point(488, 12);
            this.ddlweekday.Name = "ddlweekday";
            this.ddlweekday.Size = new System.Drawing.Size(163, 23);
            this.ddlweekday.TabIndex = 3;
            this.ddlweekday.Text = "Select Week Day";
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlweekday.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlweekday.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // rdgrd
            // 
            this.rdgrd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rdgrd.Cursor = System.Windows.Forms.Cursors.Default;
            this.rdgrd.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdgrd.ForeColor = System.Drawing.Color.Black;
            this.rdgrd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdgrd.Location = new System.Drawing.Point(-2, 59);
            // 
            // 
            // 
            this.rdgrd.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "emp_code";
            gridViewTextBoxColumn1.HeaderText = "Code";
            gridViewTextBoxColumn1.Name = "emp_code";
            gridViewTextBoxColumn1.Width = 124;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "emp_name";
            gridViewTextBoxColumn2.HeaderText = "Name";
            gridViewTextBoxColumn2.Name = "emp_name";
            gridViewTextBoxColumn2.Width = 411;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "week_day";
            gridViewTextBoxColumn3.HeaderText = "Week Day";
            gridViewTextBoxColumn3.Name = "week_day";
            gridViewTextBoxColumn3.Width = 184;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "wd_value";
            gridViewTextBoxColumn4.HeaderText = "Value";
            gridViewTextBoxColumn4.Name = "wd_value";
            gridViewTextBoxColumn4.Width = 101;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn1.Name = "delete";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 25;
            this.rdgrd.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewCommandColumn1});
            this.rdgrd.MasterTemplate.EnableGrouping = false;
            this.rdgrd.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rdgrd.Name = "rdgrd";
            this.rdgrd.ReadOnly = true;
            this.rdgrd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdgrd.ShowGroupPanel = false;
            this.rdgrd.Size = new System.Drawing.Size(881, 460);
            this.rdgrd.TabIndex = 5;
            this.rdgrd.Text = "rdgrd";
            this.rdgrd.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rdgrd_CommandCellClick);
            // 
            // btnaddwd
            // 
            this.btnaddwd.Location = new System.Drawing.Point(809, 13);
            this.btnaddwd.Name = "btnaddwd";
            this.btnaddwd.Size = new System.Drawing.Size(47, 24);
            this.btnaddwd.TabIndex = 6;
            this.btnaddwd.Text = "Add";
            this.btnaddwd.Click += new System.EventHandler(this.btnaddwd_Click);
            // 
            // ddlvalue
            // 
            this.ddlvalue.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem8.Text = "0.5";
            radListDataItem9.Text = "0.25";
            radListDataItem10.Text = "0.75";
            this.ddlvalue.Items.Add(radListDataItem8);
            this.ddlvalue.Items.Add(radListDataItem9);
            this.ddlvalue.Items.Add(radListDataItem10);
            this.ddlvalue.Location = new System.Drawing.Point(667, 12);
            this.ddlvalue.Name = "ddlvalue";
            this.ddlvalue.Size = new System.Drawing.Size(96, 23);
            this.ddlvalue.TabIndex = 7;
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlvalue.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlvalue.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // WorkingDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 521);
            this.Controls.Add(this.ddlvalue);
            this.Controls.Add(this.btnaddwd);
            this.Controls.Add(this.rdgrd);
            this.Controls.Add(this.ddlweekday);
            this.Controls.Add(this.ddlemployee);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.txtsearchemp);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "WorkingDay";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Week Day Config";
            this.Load += new System.EventHandler(this.WorkingDay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtsearchemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnsearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlemployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlweekday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgrd.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgrd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnaddwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlvalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtsearchemp;
        private Telerik.WinControls.UI.RadButton btnsearch;
        private Telerik.WinControls.UI.RadDropDownList ddlemployee;
        private Telerik.WinControls.UI.RadDropDownList ddlweekday;
        private Telerik.WinControls.UI.RadGridView rdgrd;
        private Telerik.WinControls.UI.RadButton btnaddwd;
        private Telerik.WinControls.UI.RadDropDownList ddlvalue;

    }
}
