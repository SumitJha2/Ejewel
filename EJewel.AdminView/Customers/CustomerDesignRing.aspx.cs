using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Controller.Admin.Extras;
using EJewel.Model.Admin.Extras;

using EJewel.Controller.Common;

namespace EJewel.AdminView.Customers
{
    public partial class CustomerDesignRing : System.Web.UI.Page
    {
        CustomDesignRingController objController = new CustomDesignRingController();
        List<CustomDesignRingModel> objModel = new List<CustomDesignRingModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        protected void imgDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ImageButton objButton = (ImageButton)sender;
                GridViewRow gv = (GridViewRow)objButton.NamingContainer;
                HiddenField hdnCustomDesignRequestID = (HiddenField)gv.FindControl("hdnCustomDesignRequestID");
                objController.DeleteCustomDesignRingModel(Convert.ToInt32(hdnCustomDesignRequestID.Value.ToString()));
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
                objModel = objController.GetCustomDesignRing();
                if (objModel != null && objModel.Count > 0)
                {
                    gvCustomerDesign.DataSource = objModel;
                    gvCustomerDesign.DataBind();
                    gvCustomerDesign.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void gvProposdalStories_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCustomerDesign.PageIndex = e.NewPageIndex;
            gvCustomerDesign.DataBind();
            BindGrid();
        }

        protected void gvCustomerDesign_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                   
                    Label lblImage = (Label)e.Row.FindControl("lblImage");
                    HiddenField hdnCustomDesignRequestID = (HiddenField)e.Row.FindControl("hdnCustomDesignRequestID");
                    HiddenField hdnImagePath = (HiddenField)e.Row.FindControl("hdnImagePath");
                 
                  

                 
                   
                
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
}