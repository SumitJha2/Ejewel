using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Controller.Admin.SiteSetting;
using EJewel.Model.Admin.SiteSetting;

namespace EJewel.AdminView.SiteSetting
{
    public partial class LoggedUserDetails : System.Web.UI.Page
    {
        LoginDetailsController objController=new LoginDetailsController();
        List<LoginDetailsModel> objModel = new List<LoginDetailsModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] != null)
            {
                if (!IsPostBack)
                {
                    BindGrid();
                }
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }


         
        }
        public void BindGrid()
        {
            objModel = objController.GetUserDetails();
            if(objModel!=null && objModel.Count>0)
            {
                gvLoggedUserDetails.DataSource = objModel;
                gvLoggedUserDetails.DataBind();
                gvLoggedUserDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
           
        }
        protected void imgDelete_Click(object sender, EventArgs e)
        {
            ImageButton obj = (ImageButton)sender;
            GridViewRow gvRow = (GridViewRow)obj.NamingContainer;
            HiddenField hdnLoggedUserID = (HiddenField)gvRow.FindControl("hdnLoggedUserID");
            objController.DeleteLoggedUser(Convert.ToInt32(hdnLoggedUserID.Value));
            BindGrid();
        }
        protected void gvUserDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLoggedUserDetails.PageIndex = e.NewPageIndex;
            gvLoggedUserDetails.DataBind();
            BindGrid();


        }
    }
}