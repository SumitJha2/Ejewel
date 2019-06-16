using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EJewel.Controller.Common;
using EJewel.Controller.Admin.Product.Extras;
using EJewel.Model.Admin.Product.Extras;

namespace EJewel.AdminView.Customers
{
    public partial class ProductReviewStatus : System.Web.UI.Page
    {
        ProductReviewController objController = new ProductReviewController();
        List<ProductReviewModel> objModel = new List<ProductReviewModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            long productreviewId = 0;

            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    
                    BindData();
                }
            }
        }

        protected void gvProductReview_RowdataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    Label lblStatus = (Label)e.Row.FindControl("lblStatus");                  
                    HiddenField hdnReviewId = (HiddenField)e.Row.FindControl("hdnReviewId");                 
                    HyperLink hprEdit = (HyperLink)e.Row.FindControl("hprEdit");
                    hprEdit.Attributes.Add("onclick", "popupwindow('/Customers/ManageProductReview.aspx?id=" + hdnReviewId.Value + "',800,500)");                  
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
        public void BindData()
        {
            objModel = objController.GetProductReviewList(0, CommonModel.RecordStatus.Both);
            if (objModel != null && objModel.Count > 0)
            {
                gvProductReview.DataSource = objModel;
                gvProductReview.DataBind();
                gvProductReview.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        protected void imgDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ImageButton objButton = (ImageButton)sender;
                GridViewRow gv = (GridViewRow)objButton.NamingContainer;
                HiddenField hdnReviewId = (HiddenField)gv.FindControl("hdnReviewId");
                objController.DeleteProductReview(Convert.ToInt32(hdnReviewId.Value.ToString()));
                BindData();
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

        protected void gvProductReview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductReview.PageIndex = e.NewPageIndex;
            gvProductReview.DataBind();
        }
       
            
    
    }
}