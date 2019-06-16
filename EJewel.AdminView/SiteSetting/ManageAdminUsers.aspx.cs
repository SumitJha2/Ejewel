using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.Admin.SiteSetting;
using EJewel.Controller.Admin.SiteSetting;
using EJewel.Controller.Common;


namespace EJewel.AdminView.SiteSetting
{
    public partial class ManageAdminUsers : System.Web.UI.Page
    {
        UserDetailsController objController = new UserDetailsController();
        UserDetailsModel objModel = new UserDetailsModel();
        int uid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("Default.aspx");
            }
            else
            {
                if (Request.QueryString["id"] != null)
                {
                    uid = Convert.ToInt32(Request.QueryString["id"]);
                   
                }

                if (!IsPostBack)
                {
                    ListHelper.BindList(ddlStatus, ListHelper.GetStatusSource(), "Value", "Text", null);
                    BindUserType();
                    if (uid > 0)
                    {
                        BindData();
                    }

                }
                if (Request.QueryString["save"] == "success")
                {
                    spnMessage.InnerText = "Details saved successfully.";
                }
            }
            
        }
        public void BindUserType()
        {
            try
            {
                List<UserTypeModel> objUserType = new UserTypeController().GetUserType();
                if (objUserType != null)
                {
                    ddlUserType.DataSource = objUserType;
                    ddlUserType.DataTextField = "UserTypeName";
                    ddlUserType.DataValueField = "UserTypeId";
                    ddlUserType.DataBind();
                }
                ddlUserType.Items.Insert(0, new ListItem("Please Select", "0"));
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserPassWord.Text.Trim().Length < 6)
                {
                    lblMsg.Text = "Password should be min of six character";
                    return;
                }
                objModel.UserId = txtUserID.Text.Trim().ToLower();
                objModel.UserTypeId = Convert.ToInt32(ddlUserType.SelectedValue);
                objModel.UserTypeName = txtUserName.Text;
                objModel.UserEmail = txtUserEmail.Text;
                objModel.UserMobNo = txtMob.Text;
                objModel.UserName = txtUserName.Text;
                objModel.UserPassword = txtUserPassWord.Text.ToLower();
                if (ddlStatus.SelectedValue == "1")
                {
                    objModel.Status = true;
                }
                else
                {
                    objModel.Status = false;
                }

                if (uid > 0)
                {
                    objModel.UId = uid;

                }
                if (!objController.IsExistUserID(uid, txtUserID.Text.Trim().ToLower()))
                {

                    objController.SaveUpdateUserDetails(objModel);
                    Response.Redirect("/SiteSetting/ManageAdminUsers.aspx?id=" + uid + "&save=success");

                }
                else
                {
                    spnMessage.InnerText = "UserID already exist.";
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

        public void BindData()
        {
            try
            {
                objModel = objController.GetUserDetails(uid, CommonModel.RecordStatus.Both).FirstOrDefault();
                if (objModel != null)
                {
                    txtMob.Text = objModel.UserMobNo;
                    txtUserEmail.Text = objModel.UserEmail;
                    txtUserID.Text = objModel.UserId;
                    txtUserName.Text = objModel.UserName;
                    txtUserPassWord.Text = objModel.UserPassword;
                    if (objModel.Status == true)
                    {
                        ddlStatus.SelectedValue = Convert.ToString(1);
                    }
                    else
                    {
                        ddlStatus.SelectedValue = Convert.ToString(0);
                    }
                    // ddlStatus.SelectedIndex = objModel.Status == true ? 1 : 0;
                    ddlUserType.SelectedValue = objModel.UserTypeId.ToString();
                    txtUserPassWord.Text = objModel.UserPassword;
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