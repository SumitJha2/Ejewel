using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EJewel.Controller.Common;
using EJewel.Model.Admin.Master.Setting;
using EJewel.Controller.Admin.Master.Setting;
namespace EJewel.AdminView.Master.Setting
{
    public partial class ListProductAttribute : System.Web.UI.Page
    {
        ProductAttributeController objProductAttributeController = new ProductAttributeController();
        List<ProductAttributeModel> objProductAttributeModel = new List<ProductAttributeModel>();
       
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

        protected void gvAttribute_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAttribute.PageIndex = e.NewPageIndex;
            gvAttribute.DataBind();
            BindGrid();            
        }
        protected void gvAttribute_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    Label lblStatus = (Label)e.Row.FindControl("lblStatus");

                    HiddenField hdnAttributeId = (HiddenField)e.Row.FindControl("hdnAttributeId");
                    HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
                    HyperLink hprEdit = (HyperLink)e.Row.FindControl("hprEdit");
                    hprEdit.Attributes.Add("onclick", "popupwindow('/Master/Setting/ManageProductAttribute.aspx?id=" + hdnAttributeId.Value + "',800,500)");
                  //  hprEdit.Attributes.Add("onclick", "go_to_proposalstorypage_page(" + hdnProposalId.Value + ")");                 
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
        public void BindGrid()
        {
            try
            {
                objProductAttributeModel = objProductAttributeController.GetProductAttribute(0, CommonModel.RecordStatus.Both);
                gvAttribute.DataSource = objProductAttributeModel;
                gvAttribute.DataBind();
                gvAttribute.HeaderRow.TableSection = TableRowSection.TableHeader;

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
                GridViewRow gv = (GridViewRow)objButton.NamingContainer;
                HiddenField hdnAttributeId = (HiddenField)gv.FindControl("hdnAttributeId");
               // objController.DeleteProposalStory(Convert.ToInt32(hdnId.Value.ToString()));
                objProductAttributeController.DeleteProductAttribute(Convert.ToInt32(hdnAttributeId.Value));
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


    }
}