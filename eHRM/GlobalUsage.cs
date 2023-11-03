using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Telerik.WinControls.UI;

    public delegate void UpdateMainPageTitleEventHandler(object sender, UpdateMainPageTitleEventArgs e);
    public static class GlobalUsage
    {
        public static eHRM.rmAccounts.Accounts_WebServiceSoapClient accounts_proxy = null;
        public static eHRM.HumanResource.Staff_ManagementSoapClient hr_proxy = null;
        public static string UniqueMachineId = string.Empty;
        public static string Login_id = string.Empty;
        public static string Division = "Diagnostic";
        public static string ViewStatus="No";
        public static string UnitName = string.Empty;
        public static string Unit_id = string.Empty;
        public static string UnitType = string.Empty;
        public static string UnitAddress = "Sector G, Jankipuram, Kursi Road, Lucknow.";
        public static string AccessRights = string.Empty;

        public static object[] FillCombo(DataTable dt)
        {
            ComboBox cb = new ComboBox();
            cb.Items.Add(new AddValue("Select", "Select"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cb.Items.Add(new AddValue(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString()));
            }
            cb.SelectedIndex = 0;
            object[] obj = new object[cb.Items.Count];
            cb.Items.CopyTo(obj, 0);

            return obj;
        }
        public static void SetAlternatingRowColors(ListView lst, System.Drawing.Color color1, System.Drawing.Color color2)
        {
            //loop through each ListViewItem in the ListView control
            foreach (ListViewItem item in lst.Items)
            {
                if ((item.Index % 2) == 0)
                    item.BackColor = color1;
                else
                    item.BackColor = color2;
            }
        }
        public static List<Telerik.WinControls.UI.RadListDataItem> FillTelrikCombo(DataTable dt)
        {
            List<RadListDataItem> list = new List<RadListDataItem>();
            RadListDataItem li = new Telerik.WinControls.UI.RadListDataItem();
            System.Windows.Forms.ComboBox cb = new System.Windows.Forms.ComboBox();
            li.Value = "Select";
            li.Text = "Select";
            list.Add(li);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(new Telerik.WinControls.UI.RadListDataItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString()));
            }
            return list;
        }
        public static void ManageButton(Control container, Control target)
        {
            foreach (Control c in container.Controls)
            {
                if (c.HasChildren)
                {
                    foreach (Control c1 in c.Controls)
                    {
                        if (c1.GetType() == typeof(Button))
                        {
                            if (c1.Name != target.Name)
                            {
                                c1.Enabled = true;
                            }
                            else { c1.Enabled = false; }
                        }
                    }
                }
                else
                {
                    if (c.GetType() == typeof(Button))
                    {
                        if (c.Name != target.Name)
                        {
                            c.Enabled = true;
                        }
                        else { c.Enabled = false; }
                    }
                }
            }
        }
        public static string GetStringBetweenString(string s, string start, string end)
        {
            int startIndex = s.IndexOf(start) + start.Length;
            int endIndex = s.IndexOf(end, startIndex);
            if (s.Contains(start) && s.Contains(end))
                return s.Substring(startIndex, endIndex - startIndex);
            else
                return s;
        }
    }

    public class AddValue
    {
        private String strValue;
        private String strDescription;
        public AddValue(String NewValue, String NewDescription)
        {
            strValue = NewValue;
            strDescription = NewDescription;
        }
        public string NewValue
        {
            get { return strValue; }
        }
        public string NewDescription
        {
            get { return strDescription; }
        }
        public override string ToString()
        {
            return strDescription;
        }
    }
    public class UpdateMainPageTitleEventArgs : System.EventArgs
    {
        private string newTitle;
        public  UpdateMainPageTitleEventArgs(string newTitle)
        {
            this.newTitle = newTitle;
        }
        public string NewTitle { get { return this.newTitle; } }
    }
