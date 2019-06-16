using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//model
using EJewel.Model.Admin.Master.Stone;
//controller
using EJewel.Controller.Admin.Master.Stone;

namespace EJewel.AdminView.Master.Stone
{
    public partial class ListStoneSpecification : System.Web.UI.Page
    {
        StoneSpecificationController objController = new StoneSpecificationController();
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
                _view = Request.QueryString["view"];
                if (!string.IsNullOrEmpty(_view))
                {
                    _view = _view.Trim();
                    StoneSpecificationModel.PageName pgname = objController.GetPageName(_view);
                    if (pgname != StoneSpecificationModel.PageName.None)
                    {
                        ltrlHeading.Text = objController.Heading;
                        _totalRecord = objController.TotalRecord(pgname);
                    }
                    else
                    {
                        Response.Redirect("/Default.aspx");
                    }
                }
                //else
                //{
                //    Response.Redirect("/Default.aspx");
                //}
                else
                {
                    Response.Redirect("Pagenotfound.aspx");
                }
            }
        }
    }
}