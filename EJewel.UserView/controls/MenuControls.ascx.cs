using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Controller.Cart;

namespace EJewel.UserView.controls
{
    public partial class MenuControls : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RegisterUser"] == null)
            {
                lblUserType.Text = "Welcome Guest ";
                //lnkbtnloginStatus.Text = "Login";
            }
            else if (Session["RegisterUser"] != null)
            {
                lblUserType.Text = "Welcome Your Account ";
                //lnkbtnloginStatus.Text = "Logout";

            }

            if(CartController.Instance!=null)
            {
                ltrlTotalItem.Text = "(" + CartController.Instance.ProductItems.Count + ")";
            }
        }
    }
}