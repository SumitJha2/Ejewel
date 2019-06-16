using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Controller.Admin.Extras;
using EJewel.Model.Admin.Extras;
using EJewel.Controller.Common;
using EJewel.Model.Admin.Common;



namespace EJewel.AdminView.Extras
{
    public partial class ManageProposalStories : System.Web.UI.Page
    {
        ProposalStoriesModel objmodel = new ProposalStoriesModel();
        ProposalStoryController objController = new ProposalStoryController();
        ErrorLogController objErrorController = new ErrorLogController();
        int proposalstoryId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                if (Request.QueryString["id"] != null)
                {
                    proposalstoryId = Convert.ToInt32(Request.QueryString["id"]);
                }
                if (!IsPostBack)
                {
                    ListHelper.BindList(ddlStatus, ListHelper.GetStatusSource(), "Value", "Text", null);
                    if (proposalstoryId > 0)
                    {
                        BindData();
                    }
                }
            }
            
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (proposalstoryId>0)
                {
                    objmodel.ProposalStoryID = proposalstoryId;
                }
                objmodel.StoryHeader = txtStoryHeader.Text;
                objmodel.StoryDescription = txtDescription.Content;
                if (ddlStatus.SelectedIndex == 0)
                {
                    objmodel.Status = true;
                }
                else
                {
                    objmodel.Status = false;
                }
             
                objmodel.ImagePath = hdnFile.Value;
                objController.SaveUpdateProposalStory(objmodel);
                Response.Redirect("/Extras/ManageProposalStories.aspx?id=" + proposalstoryId+"&save='success'");
            }
            catch(Exception ex)
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
        public void BindData()
        {
            try
            {
                if (proposalstoryId > 0)
                {
                    objmodel = objController.GetProposalStoryList(proposalstoryId, CommonModel.RecordStatus.Both).FirstOrDefault();
                    if (objmodel != null)
                    {
                        txtStoryHeader.Text = objmodel.StoryHeader;
                        txtDescription.Content = objmodel.StoryDescription;
                        hdnFile.Value = objmodel.ImagePath;
                        if (objmodel.Status == true)
                        {
                            ddlStatus.SelectedValue = Convert.ToString(1);
                        }
                        else
                        {
                            ddlStatus.SelectedValue = Convert.ToString(0);
                        }
                        // ddlStatus.SelectedIndex = objmodel.Status == true ? 0 : 1;
                        spnProgress.InnerHtml = "<img src='" + "/upload/images/proposalstory/" + objmodel.ImagePath + "' alt='Photo' style='width:50px;height:50px;' />";


                    }
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
       
    }
}