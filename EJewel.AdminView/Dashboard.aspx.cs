using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EJewel.AdminView
{
    public partial class Dashboard : System.Web.UI.Page
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
                    if (Session["UType"].ToString() == "1")
                    {

                        /* LoginUser.Visible = true;
                         loggeduserDetails.Visible = true;
                         a1.Visible = true;
                         a2.Visible = true;*/
                    }
                    else if (Session["UType"].ToString() == "2")
                    {


                        /*LoginUser.Visible = false;
                        loggeduserDetails.Visible = false;
                        a1.Visible = false;
                        a2.Visible = false;*/
                    }

                }
                if (!IsPostBack)
                {
                    /* lblDate.Text = DateTime.Now.ToLongDateString();
                     lblLoginIP.Text = Session["IP"].ToString();
                     lblusername.Text = Convert.ToString(Session["Name"]);*/
                }
            }
        }
    }
}