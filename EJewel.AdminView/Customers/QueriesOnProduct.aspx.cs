using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EJewel.Controller.Common;
using EJewel.Model.Admin.Product.Extras;
using EJewel.Controller.Admin.Product.Extras;

namespace EJewel.AdminView.Customers
{
    public partial class QueriesOnProduct : System.Web.UI.Page
    {
        List<QueriesOnProductModel> lstProductQueries = new List<QueriesOnProductModel>();
        QueriesOnProductController objController = new QueriesOnProductController();
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
                    BindGrid();
                }
            }
        }     

        protected void imgDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ImageButton objButton = (ImageButton)sender;
                GridViewRow gv = (GridViewRow)objButton.NamingContainer;
                HiddenField hdnId = (HiddenField)gv.FindControl("hdnProductQueriesId");
                objController.DeleteQueriesOnProduct(Convert.ToInt32(hdnId.Value.ToString()));
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
                    lstProductQueries = objController.GetQueriesOnProduct(0);               
                    gvQueriesOnProduct.DataSource = lstProductQueries;
                    gvQueriesOnProduct.DataBind();                 
                    gvQueriesOnProduct.HeaderRow.TableSection = TableRowSection.TableHeader;                
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

        protected void gvQueriesOnProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvQueriesOnProduct.PageIndex = e.NewPageIndex;
            gvQueriesOnProduct.DataBind();
            BindGrid();
        }
       
    }
}