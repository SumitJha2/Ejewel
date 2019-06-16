using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.Admin.Extras;
using EJewel.Controller.Admin.Extras;

using EJewel.Controller.Common;

namespace EJewel.AdminView.Extras
{
    public partial class ListProposalStory : System.Web.UI.Page
    {
        List<ProposalStoriesModel> lstProposalStory = new List<ProposalStoriesModel>();
        ProposalStoryController objController = new ProposalStoryController();
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
        protected void gvProposdalStories_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                    Label lblImage = (Label)e.Row.FindControl("lblImage");
                    HiddenField hdnProposalId = (HiddenField)e.Row.FindControl("hdnProposalId");
                    HiddenField hdnImagePath = (HiddenField)e.Row.FindControl("hdnImagePath");
                    HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
                    HyperLink hprEdit = (HyperLink)e.Row.FindControl("hprEdit");
                   // hprEdit.Attributes.Add("onclick", "popupwindow('/Extras/ManageProposalStories.aspx?id=" + hdnProposalId.Value + "',800,500)");

                    hprEdit.Attributes.Add("onclick", "go_to_proposalstorypage_page("+hdnProposalId.Value + ")");
                    lblImage.Text = "<img src='" + "/upload/images/proposalstory/" + hdnImagePath.Value + "' alt='Photo' style='width:50px;height:50px;' />";
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
                HiddenField hdnId = (HiddenField)gv.FindControl("hdnProposalId");
                objController.DeleteProposalStory(Convert.ToInt32(hdnId.Value.ToString()));
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
                lstProposalStory = objController.GetProposalStoryList(0, CommonModel.RecordStatus.Both);
                if (lstProposalStory != null && lstProposalStory.Count > 0)
                {
                    gvProposdalStories.DataSource = lstProposalStory;
                    gvProposdalStories.DataBind();
                    gvProposdalStories.HeaderRow.TableSection = TableRowSection.TableHeader;
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
            gvProposdalStories.PageIndex = e.NewPageIndex;
            gvProposdalStories.DataBind();
            BindGrid();
        }
       

    }
}