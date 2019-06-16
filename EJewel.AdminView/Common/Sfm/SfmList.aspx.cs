using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//model
using EJewel.Model.Admin.Common.Sfm;
//controller
using EJewel.Controller.Admin.Common.Sfm;
namespace EJewel.AdminView.Common.Sfm
{
    public partial class SfmList : System.Web.UI.Page
    {
        SfmController objController = new SfmController();
        SfmModel.PageName _pageName = SfmModel.PageName.None;
        public string _view = "";
        public int _totalRecord = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                string view = Request.QueryString["view"];
                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(view))
                {
                    _view = view.Trim();
                    //get the page name
                    _pageName = objController.GetPageView(_view);
                    ltrlHeading.Text = objController.HeadingName;
                    if (_pageName == SfmModel.PageName.None)
                    {
                        //redirect to the default page
                        Response.Redirect("/Default.aspx");
                    }
                    else
                    {
                        _totalRecord = objController.GetTotalSfm(_pageName);
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
}