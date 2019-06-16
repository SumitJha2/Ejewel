using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
//web
using System.Web.UI.WebControls;
namespace EJewel.Controller.Common
{
    public class ListHelper
    {
        public static ListItem DefaultList = new ListItem("--Select--", "");
        public static DataTable GetStatusSource()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Value", typeof(int));
            tbl.Columns.Add("Text");
            //for enabled
            DataRow row = tbl.NewRow();
            row["Text"] = "Enabled";
            row["Value"] = 1;
            tbl.Rows.Add(row);
            //for disabled
            row = tbl.NewRow();
            row["Text"] = "Disabled";
            row["Value"] = 0;
            tbl.Rows.Add(row);
            return tbl;
        }
        /*
         * Partha Ranjan
         * @ 02-02-13
         * This class helps maneg the list source
         * */
        public static void BindList(ListControl lstControl, object dataSource, string value, string text, ListItem def)
        {
            if (lstControl is DropDownList)
            {
                DropDownList ddl = (DropDownList)lstControl;
                if (ddl != null)
                {
                    ddl.DataSource = dataSource;
                    ddl.DataTextField = text;
                    ddl.DataValueField = value;
                    ddl.DataBind();
                    if (def != null)
                    {
                        ddl.Items.Insert(0, def);
                    }
                }
            }
        }

        public static void BindList(ListControl lstControl, object dataSource, string value, string text)
        {
            if (lstControl is DropDownList)
            {
                DropDownList ddl = (DropDownList)lstControl;
                if (ddl != null)
                {
                    ddl.DataSource = dataSource;
                    ddl.DataTextField = text;
                    ddl.DataValueField = value;
                    ddl.DataBind();

                }
            }
        }
    }
}
