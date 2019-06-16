using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EJewel.AdminView
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] color_1 = { "Red", "Green", "Blue", "Yellow" };
            string[] color_2 = { "Red", "Green", "Blue", "Yellow" };
            string[] color_3 = { "Red", "Green", "Blue", "Yellow" };
            string[] color_4 = { "Red", "Green", "Blue", "Yellow" };
            //do the permu taion combination
            int counter = 0;
            for (int i = 0; i < color_1.Length; i++)
            {
                for (int j = 0; j < color_2.Length; j++)
                {
                    for (int k = 0; k < color_3.Length; k++)
                    {
                        for (int l = 0; l < color_4.Length; l++)
                        {
                            counter++;
                            //create combination
                            string combination = counter + " " + color_1[i] + " -> " + color_2[j] + " -> " + color_3[k] + " -> " + color_4[l];
                            combination = GetColor(color_1[i]) + " " + GetColor(color_2[j]) + " " + GetColor(color_3[k]) + " " + GetColor(color_4[l]);
                            Response.Write(combination+" <br/>");
                        }
                    }
                }
            }
        }
        string GetColor(string col)
        {
            return "<span style=\"color:" + col + "\">" + col + "</span>";
        }
    }
}