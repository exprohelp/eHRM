using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eHRM
{
    public partial class MasterForm : Telerik.WinControls.UI.RadForm
    {
        UserControl _ucView; string _FormHeading = string.Empty;
        public MasterForm(UserControl uc,string FormHeading)
        {
            _ucView = uc; _FormHeading = FormHeading;
            InitializeComponent();
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
            Rectangle rec = Screen.PrimaryScreen.WorkingArea;

            this.Size = new System.Drawing.Size(_ucView.Width + 15, _ucView.Height + 30);
            int size = (rec.Size.Width - this.Width) / 2;
            this.Location = new System.Drawing.Point(size, 155);
            
            this.Size =new System.Drawing.Size(_ucView.Width+15,_ucView.Height+30);
            this.Text = _FormHeading;
            dispPanel.Controls.Clear();
            Cursor.Current = Cursors.WaitCursor;
            dispPanel.Controls.Add(_ucView);
            Cursor.Current = Cursors.Default;

        }
    }
}
