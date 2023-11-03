using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Data;
using System.ComponentModel;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Data.SqlClient;
using System.Reflection;
namespace eHRM
{
    class Config
    {

        public static SqlConnection GetConnection(string dbName)
        {
            return ExPro.Server.DBConnection.GetConnection(true, dbName);
        }


             public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
            {
                DataTable dtReturn = new DataTable();
                 // column names 
                PropertyInfo[] oProps = null;

     if (varlist == null) return dtReturn;

     foreach (T rec in varlist)
     {
          // Use reflection to get property names, to create table, Only first time, others 
          
          if (oProps == null)
          {
               oProps = ((Type)rec.GetType()).GetProperties();
               foreach (PropertyInfo pi in oProps)
               {
                    Type colType = pi.PropertyType;

                    if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()==typeof(Nullable<>)))
                     {
                         colType = colType.GetGenericArguments()[0];
                     }

                    dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
               }
          }

          DataRow dr = dtReturn.NewRow();

          foreach (PropertyInfo pi in oProps)
          {
               dr[pi.Name] = pi.GetValue(rec, null) == null ?DBNull.Value :pi.GetValue
               (rec,null);
          }

          dtReturn.Rows.Add(dr);
     }
     return dtReturn;
}
      
        public static object[] FillWinOldCombo(DataTable dt)
        {
            System.Windows.Forms.ComboBox cb = new System.Windows.Forms.ComboBox();
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
        public static object[] FillWinCombo(DataTable dt)
        {
            System.Windows.Forms.ComboBox cb = new System.Windows.Forms.ComboBox();
            cb.Items.Add(new AddValue("Select", "Select"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cb.Items.Add(new AddValue(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString()));
            }
            cb.SelectedIndex = 0;
            object[] obj = new object[cb.Items.Count];
            cb.Items.CopyTo(obj, 0);

            return obj;
        }
        public static List<GridViewRowInfo> GetCheckedRows(RadGridView grid,int CheckBoxCellIndex)
        {
            List<GridViewRowInfo> checkedRows = new List<GridViewRowInfo>();
            foreach (GridViewRowInfo row in grid.Rows)
            {
                if (row.Cells[CheckBoxCellIndex].Value != null & row.Cells[CheckBoxCellIndex].Value != DBNull.Value)
                {
                    if (Convert.ToBoolean(row.Cells[CheckBoxCellIndex].Value))
                    {
                        checkedRows.Add(row);
                    }
                }

            }
            return checkedRows;
        }
        public static List<RadListDataItem> FillTelrikCombo(DataTable dt)
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

    }//Second Last
}

public class CustomAutoCompleteSuggestHelper : AutoCompleteSuggestHelper
{
    public CustomAutoCompleteSuggestHelper(RadDropDownListElement owner) : base(owner)
    {
    }

    public override void ApplyFilterToDropDown(string filter)
    {
        base.ApplyFilterToDropDown(filter);
        this.DropDownList.ListElement.DataLayer.DataView.Comparer = new CustomComparer();
    }
}
public class CustomComparer : IComparer<RadListDataItem>
{
    public int Compare(RadListDataItem x, RadListDataItem y)
    {
        return x.Text.Length.CompareTo(y.Text.Length);
    }
}