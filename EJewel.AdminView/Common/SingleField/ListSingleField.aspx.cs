using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//model
using EJewel.Model.Admin.Common.SingleField;
//controller
using EJewel.Controller.Admin.Common.SingleField;
namespace EJewel.AdminView.Common.SingleField
{
    public partial class ListSingleField : System.Web.UI.Page
    {
        SingleFieldController objController = new SingleFieldController();
        SingleFieldModel.PageName _pageName = SingleFieldModel.PageName.None;
        string _view = "";
       

        protected void Page_Load(object sender, EventArgs e)
        {
            string view = Request.QueryString["view"];
            string id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(view))
            {
                _view = view.Trim();
                //get the page name
                _pageName = objController.GetPageView(_view);
                ltrlHeading.Text = objController.HeadingName+" List";
                if (_pageName == SingleFieldModel.PageName.None)
                {
                    //redirect to the default page
                    Response.Redirect("/Default.aspx");
                }
            }
            else
            {
                //redirect to the default page
                Response.Redirect("/Default.aspx");
            }
        }
    }
}