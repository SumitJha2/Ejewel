using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Controller.Admin.Extras;
using EJewel.Model.Admin.Extras;

using EJewel.Controller.Common;

namespace EJewel.AdminView.Extras
{
    public partial class ListContactDetails : System.Web.UI.Page
    {
        ContactDetailsController objController = new ContactDetailsController();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    BindContactDetails();
                }
            }

        }

        protected void gvContactDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvContactDetails.PageIndex = e.NewPageIndex;
            gvContactDetails.DataBind();
            BindContactDetails();
        }
        public void BindContactDetails()
        {
            try
            {
                List<ContactDetailsModel> objContactDetails = objController.GetContactDetails().ToList();
                if (objContactDetails != null && objContactDetails.Count > 0)
                {
                    gvContactDetails.DataSource = objContactDetails;
                    gvContactDetails.DataBind();

                }
                gvContactDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        protected void imgDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ImageButton objButton = (ImageButton)sender;
                GridViewRow gvRow = (GridViewRow)objButton.NamingContainer;
                HiddenField hdnId = (HiddenField)gvRow.FindControl("hdnContctDetailsId");
                objController.DeleteContactDetails(Convert.ToInt32(hdnId.Value));
                BindContactDetails();
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
}