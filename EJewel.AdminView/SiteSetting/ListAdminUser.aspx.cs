using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Controller.Common;
using EJewel.Controller.Admin.SiteSetting;
using EJewel.Model.Admin.SiteSetting;

namespace EJewel.AdminView.SiteSetting
{
    public partial class ListAdminUser : System.Web.UI.Page
    {
        UserDetailsController objController = new UserDetailsController();
        List<UserDetailsModel> objModel = new List<UserDetailsModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        public void BindGrid()
        {
            objModel = objController.GetUserDetails(0, CommonModel.RecordStatus.Both).ToList();
            if (objModel != null && objModel.Count > 0)
            {
                gvUserDetails.DataSource = objModel;
                gvUserDetails.DataBind();
                gvUserDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
          
        }
        protected void imgDelete_Click(object sender, EventArgs e)
        {
            ImageButton obj = (ImageButton)sender;
            GridViewRow gvRow = (GridViewRow)obj.NamingContainer;
            HiddenField hdnUid = (HiddenField)gvRow.FindControl("hdnUid");
            objController.DeleteUserDetails(Convert.ToInt32(hdnUid.Value));
            BindGrid();
        }

        protected void gvUserDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HiddenField hdnUid = (HiddenField)e.Row.FindControl("hdnUid");
                HyperLink hprEdit = (HyperLink)e.Row.FindControl("hprEdit");
                hprEdit.Attributes.Add("onclick", "popupwindow('/SiteSetting/ManageAdminUsers.aspx?id=" + hdnUid.Value + "',800,500)");             
              
            }

        }

        protected void gvUserDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUserDetails.PageIndex = e.NewPageIndex;
            gvUserDetails.DataBind();
            BindGrid();


        }

    }
}