﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EJewel.AdminView
{
    public partial class Pagenotfound : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
            }

        }
    }
}