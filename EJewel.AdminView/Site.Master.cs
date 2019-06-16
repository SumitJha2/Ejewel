using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EJewel.AdminView
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["loginID"] == null)
                {
                    Session.Abandon();
                    Response.Redirect("/Default.aspx");
                }
                else
                {

                    
                }
               // if (!IsPostBack)
               // {
                    /* lblDate.Text = DateTime.Now.ToLongDateString();
                     lblLoginIP.Text = Session["IP"].ToString();
                     lblusername.Text = Convert.ToString(Session["Name"]);*/
               // }
            }
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/Default.aspx");
        }
    }
}
