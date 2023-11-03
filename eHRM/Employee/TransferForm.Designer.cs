namespace eHRM.Employee
{
    partial class TransferForm
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferForm));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rpv_main = new Telerik.WinControls.UI.RadPageView();
            this.rpvp_transfer = new Telerik.WinControls.UI.RadPageViewPage();
            this.GBTrfTo = new System.Windows.Forms.GroupBox();
            this.dgPostedAt = new Telerik.WinControls.UI.RadGridView();
            this.btnTransfer = new Telerik.WinControls.UI.RadButton();
            this.ddlTrfType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.txtPostedAt = new Telerik.WinControls.UI.RadTextBox();
            this.roundRectShape1 = new Telerik.WinControls.RoundRectShape(this.components);
            this.txtDesignation = new Telerik.WinControls.UI.RadTextBox();
            this.txtStatus = new Telerik.WinControls.UI.RadTextBox();
            this.txtFatherName = new Telerik.WinControls.UI.RadTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rgv_staff = new Telerik.WinControls.UI.RadGridView();
            this.textSearch = new Telerik.WinControls.UI.RadTextBox();
            this.rpvp_temporary = new Telerik.WinControls.UI.RadPageViewPage();
            ((System.ComponentModel.ISupportInitialize)(this.rpv_main)).BeginInit();
            this.rpv_main.SuspendLayout();
            this.rpvp_transfer.SuspendLayout();
            this.GBTrfTo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPostedAt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPostedAt.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTransfer)).BeginInit();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostedAt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesignation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFatherName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rpv_main
            // 
            this.rpv_main.Controls.Add(this.rpvp_transfer);
            this.rpv_main.Controls.Add(this.rpvp_temporary);
            this.rpv_main.DefaultPage = this.rpvp_transfer;
            this.rpv_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpv_main.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rpv_main.Location = new System.Drawing.Point(0, 0);
            this.rpv_main.Name = "rpv_main";
            this.rpv_main.SelectedPage = this.rpvp_transfer;
            this.rpv_main.Size = new System.Drawing.Size(967, 464);
            this.rpv_main.TabIndex = 0;
            this.rpv_main.Text = "radPageView1";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.rpv_main.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            // 
            // rpvp_transfer
            // 
            this.rpvp_transfer.Controls.Add(this.GBTrfTo);
            this.rpvp_transfer.Controls.Add(this.ddlTrfType);
            this.rpvp_transfer.Controls.Add(this.label4);
            this.rpvp_transfer.Controls.Add(this.gbInfo);
            this.rpvp_transfer.Controls.Add(this.rgv_staff);
            this.rpvp_transfer.Controls.Add(this.textSearch);
            this.rpvp_transfer.ItemSize = new System.Drawing.SizeF(35F, 121F);
            this.rpvp_transfer.Location = new System.Drawing.Point(44, 10);
            this.rpvp_transfer.Name = "rpvp_transfer";
            this.rpvp_transfer.Size = new System.Drawing.Size(912, 443);
            this.rpvp_transfer.Text = "Make Transfer";
            // 
            // GBTrfTo
            // 
            this.GBTrfTo.Controls.Add(this.dgPostedAt);
            this.GBTrfTo.Controls.Add(this.btnTransfer);
            this.GBTrfTo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBTrfTo.Location = new System.Drawing.Point(285, 191);
            this.GBTrfTo.Name = "GBTrfTo";
            this.GBTrfTo.Size = new System.Drawing.Size(627, 251);
            this.GBTrfTo.TabIndex = 7;
            this.GBTrfTo.TabStop = false;
            this.GBTrfTo.Text = "Transfer To Unit";
            // 
            // dgPostedAt
            // 
            this.dgPostedAt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.dgPostedAt.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgPostedAt.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.dgPostedAt.ForeColor = System.Drawing.Color.Black;
            this.dgPostedAt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgPostedAt.Location = new System.Drawing.Point(6, 36);
            // 
            // 
            // 
            this.dgPostedAt.MasterTemplate.AllowAddNewRow = false;
            this.dgPostedAt.MasterTemplate.AllowDeleteRow = false;
            this.dgPostedAt.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "unit_code";
            gridViewTextBoxColumn1.HeaderText = "unit_code";
            gridViewTextBoxColumn1.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "unit_code";
            gridViewTextBoxColumn1.Width = 204;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "unit_name";
            gridViewTextBoxColumn2.HeaderText = "unit_name";
            gridViewTextBoxColumn2.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewTextBoxColumn2.Name = "unit_name";
            gridViewTextBoxColumn2.Width = 553;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "Lock";
            gridViewCommandColumn1.HeaderText = "L";
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.Name = "Lock";
            gridViewCommandColumn1.Width = 23;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "comp_code";
            gridViewTextBoxColumn3.HeaderText = "comp_code";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "comp_code";
            this.dgPostedAt.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1,
            gridViewTextBoxColumn3});
            this.dgPostedAt.MasterTemplate.EnableFiltering = true;
            this.dgPostedAt.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgPostedAt.Name = "dgPostedAt";
            this.dgPostedAt.ReadOnly = true;
            this.dgPostedAt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgPostedAt.ShowGroupPanel = false;
            this.dgPostedAt.Size = new System.Drawing.Size(618, 182);
            this.dgPostedAt.TabIndex = 22;
            this.dgPostedAt.Text = "radGridView2";
            this.dgPostedAt.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.dgPostedAt_CommandCellClick);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Enabled = false;
            this.btnTransfer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.Location = new System.Drawing.Point(550, 222);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(71, 24);
            this.btnTransfer.TabIndex = 25;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // ddlTrfType
            // 
            this.ddlTrfType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTrfType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlTrfType.FormattingEnabled = true;
            this.ddlTrfType.Items.AddRange(new object[] {
            "Permanent",
            "Temporary"});
            this.ddlTrfType.Location = new System.Drawing.Point(415, 161);
            this.ddlTrfType.Name = "ddlTrfType";
            this.ddlTrfType.Size = new System.Drawing.Size(126, 25);
            this.ddlTrfType.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(304, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 21);
            this.label4.TabIndex = 23;
            this.label4.Text = "Transfer Type";
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.txtPostedAt);
            this.gbInfo.Controls.Add(this.txtDesignation);
            this.gbInfo.Controls.Add(this.txtStatus);
            this.gbInfo.Controls.Add(this.txtFatherName);
            this.gbInfo.Controls.Add(this.label5);
            this.gbInfo.Controls.Add(this.label3);
            this.gbInfo.Controls.Add(this.label2);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.Location = new System.Drawing.Point(285, -4);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(624, 162);
            this.gbInfo.TabIndex = 4;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "XXXXXXXXXXXXXXXXXX";
            // 
            // txtPostedAt
            // 
            this.txtPostedAt.AutoSize = false;
            this.txtPostedAt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPostedAt.Location = new System.Drawing.Point(129, 111);
            this.txtPostedAt.Multiline = true;
            this.txtPostedAt.Name = "txtPostedAt";
            this.txtPostedAt.ReadOnly = true;
            this.txtPostedAt.Size = new System.Drawing.Size(489, 42);
            this.txtPostedAt.TabIndex = 6;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtPostedAt.GetChildAt(0))).Shape = this.roundRectShape1;
            // 
            // txtDesignation
            // 
            this.txtDesignation.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesignation.Location = new System.Drawing.Point(129, 81);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.ReadOnly = true;
            this.txtDesignation.Size = new System.Drawing.Size(489, 25);
            this.txtDesignation.TabIndex = 6;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtDesignation.GetChildAt(0))).Shape = this.roundRectShape1;
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(129, 51);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(233, 25);
            this.txtStatus.TabIndex = 6;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtStatus.GetChildAt(0))).Shape = this.roundRectShape1;
            // 
            // txtFatherName
            // 
            this.txtFatherName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatherName.Location = new System.Drawing.Point(129, 23);
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.ReadOnly = true;
            this.txtFatherName.Size = new System.Drawing.Size(380, 25);
            this.txtFatherName.TabIndex = 5;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtFatherName.GetChildAt(0))).Shape = this.roundRectShape1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Posted At :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Designation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Father\'s Name";
            // 
            // rgv_staff
            // 
            this.rgv_staff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgv_staff.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv_staff.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgv_staff.ForeColor = System.Drawing.Color.Black;
            this.rgv_staff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv_staff.Location = new System.Drawing.Point(3, 28);
            // 
            // 
            // 
            this.rgv_staff.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "emp_code";
            gridViewTextBoxColumn4.HeaderText = "Code";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "emp_code";
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "emp_name";
            gridViewTextBoxColumn5.HeaderText = "Name of Employee";
            gridViewTextBoxColumn5.Name = "emp_name";
            gridViewTextBoxColumn5.Width = 220;
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.HeaderText = "-";
            gridViewCommandColumn2.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn2.Image")));
            gridViewCommandColumn2.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn2.Name = "column1";
            gridViewCommandColumn2.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewCommandColumn2.Width = 25;
            this.rgv_staff.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewCommandColumn2});
            this.rgv_staff.MasterTemplate.EnableGrouping = false;
            sortDescriptor1.PropertyName = "column1";
            this.rgv_staff.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.rgv_staff.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.rgv_staff.Name = "rgv_staff";
            this.rgv_staff.ReadOnly = true;
            this.rgv_staff.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv_staff.Size = new System.Drawing.Size(275, 412);
            this.rgv_staff.TabIndex = 3;
            this.rgv_staff.Text = "radGridView1";
            this.rgv_staff.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rgv_staff_CommandCellClick);
            this.rgv_staff.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // textSearch
            // 
            this.textSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearch.Location = new System.Drawing.Point(3, 3);
            this.textSearch.Name = "textSearch";
            this.textSearch.NullText = "Search String";
            this.textSearch.Size = new System.Drawing.Size(275, 23);
            this.textSearch.TabIndex = 2;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // rpvp_temporary
            // 
            this.rpvp_temporary.ItemSize = new System.Drawing.SizeF(35F, 167F);
            this.rpvp_temporary.Location = new System.Drawing.Point(44, 10);
            this.rpvp_temporary.Name = "rpvp_temporary";
            this.rpvp_temporary.Size = new System.Drawing.Size(912, 443);
            this.rpvp_temporary.Text = "Temporary Transfers";
            // 
            // TransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 464);
            this.Controls.Add(this.rpv_main);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TransferForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "Staff Transfer";
            this.Load += new System.EventHandler(this.TransferForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rpv_main)).EndInit();
            this.rpv_main.ResumeLayout(false);
            this.rpvp_transfer.ResumeLayout(false);
            this.rpvp_transfer.PerformLayout();
            this.GBTrfTo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPostedAt.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPostedAt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTransfer)).EndInit();
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostedAt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesignation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFatherName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv_staff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView rpv_main;
        private Telerik.WinControls.UI.RadPageViewPage rpvp_transfer;
        private Telerik.WinControls.UI.RadPageViewPage rpvp_temporary;
        private Telerik.WinControls.UI.RadGridView rgv_staff;
        private Telerik.WinControls.UI.RadTextBox textSearch;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadTextBox txtPostedAt;
        private Telerik.WinControls.RoundRectShape roundRectShape1;
        private Telerik.WinControls.UI.RadTextBox txtDesignation;
        private Telerik.WinControls.UI.RadTextBox txtStatus;
        private Telerik.WinControls.UI.RadTextBox txtFatherName;
        private Telerik.WinControls.UI.RadGridView dgPostedAt;
        private System.Windows.Forms.ComboBox ddlTrfType;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadButton btnTransfer;
        private System.Windows.Forms.GroupBox GBTrfTo;
    }
}
