using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.Admin.Order;

using EJewel.Controller.Common;
using EJewel.Controller.Admin.Order;

namespace EJewel.AdminView.Order
{
    public partial class ListPromotionalcodeManagement : System.Web.UI.Page
    {

        List<PromotionalcodeManagementModel> lstPromotionalcodeManagementList = new List<PromotionalcodeManagementModel>();
        PromotionalcodeManagementController objController = new PromotionalcodeManagementController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    BindGrid();
                }
            }
        }
        protected void gvPromotionalCodeManagement_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                    Label lblImage = (Label)e.Row.FindControl("lblImage");
                    HiddenField hdnPromotionalCodeManagementId = (HiddenField)e.Row.FindControl("hdnPromotionalCodeManagementId");
                
                    HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
                    HyperLink hprEdit = (HyperLink)e.Row.FindControl("hprEdit");
                    hprEdit.Attributes.Add("onclick", "popupwindow('/Order/PromotionalcodeManagement.aspx?id=" + hdnPromotionalCodeManagementId.Value + "',800,500)");
                    lblStatus.Text = Convert.ToBoolean(hdnStatus.Value) == true ? "Enabled" : "Disabled";
                }
                catch (Exception ex)
                {
                    ErrorLogModel objLogError = new ErrorLogModel();
                    objLogError.ErrorMessage = ex.Message;
                    objLogError.ErrorSource = ex.Source;
                    objLogError.StackTrace = ex.StackTrace;
                    objLogError.InnerException = Convert.ToString(ex.InnerException);
                    objLogError.LogTime = DateTime.Now;
                    objLogError.UserID = Session["loginID"].ToString();
                    new ErrorLogController().SetErrorLog(objLogError);

                }
            }
        }

        protected void imgDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ImageButton objButton = (ImageButton)sender;
                GridViewRow gv = (GridViewRow)objButton.NamingContainer;
                HiddenField hdnId = (HiddenField)gv.FindControl("hdnPromotionalCodeManagementId");
                objController.DeletePromotionCode(Convert.ToInt32(hdnId.Value));               
                BindGrid();
            }
            catch (Exception ex)
            {
                ErrorLogModel objLogError = new ErrorLogModel();
                objLogError.ErrorMessage = ex.Message;
                objLogError.ErrorSource = ex.Source;
                objLogError.StackTrace = ex.StackTrace;
                objLogError.InnerException = Convert.ToString(ex.InnerException);
                objLogError.LogTime = DateTime.Now;
                objLogError.UserID = Session["loginID"].ToString();
                new ErrorLogController().SetErrorLog(objLogError);

            }
        }
        public void BindGrid()
        {
            try
            {
                lstPromotionalcodeManagementList = objController.GetPromotionalcodeManagement(0,CommonModel.RecordStatus.Both);
                if (lstPromotionalcodeManagementList != null && lstPromotionalcodeManagementList.Count > 0)
                {
                    gvPromotionalCodeManagement.DataSource = lstPromotionalcodeManagementList;
                    gvPromotionalCodeManagement.DataBind();
                    gvPromotionalCodeManagement.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                ErrorLogModel objLogError = new ErrorLogModel();
                objLogError.ErrorMessage = ex.Message;
                objLogError.ErrorSource = ex.Source;
                objLogError.StackTrace = ex.StackTrace;
                objLogError.InnerException = Convert.ToString(ex.InnerException);
                objLogError.LogTime = DateTime.Now;
                objLogError.UserID = Session["loginID"].ToString();
                new ErrorLogController().SetErrorLog(objLogError);

            }
        }

        protected void gvPromotionalCodeManagement_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPromotionalCodeManagement.PageIndex = e.NewPageIndex;
            gvPromotionalCodeManagement.DataBind();
            BindGrid();
        }
    }
}