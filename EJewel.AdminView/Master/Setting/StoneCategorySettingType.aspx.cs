using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//controller
using EJewel.Controller.Admin.Master.Category;
//using EJewel.Controller.Admin.Product;
using EJewel.Controller.Common;
using EJewel.Controller.Admin.Master.Setting;
using EJewel.Controller.Admin.Common.Sfm;
//model
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Master.Category;
using EJewel.Model.Admin.Master.Setting;
using EJewel.Controller.Admin.Master.Stone;
using EJewel.Model.Admin.Common.Sfm;

namespace EJewel.AdminView.Master.Setting
{
    public partial class CategorySettingType : System.Web.UI.Page
    {
        int _editID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    _editID = Convert.ToInt32(id);
                }
              /*  else
                {
                    Response.Redirect("Pagenotfound.aspx");
                }*/
                //load the default data
                if (!IsPostBack)
                {
                    //load the category 
                    ListHelper.BindList(ddlStoneCategoryType, new StoneCategoryTypeController().GetStoneCategoryType(), "StoneCategoryTypeID", "StoneCategoryTypeName", ListHelper.DefaultList);
                    //load setting type
                    ListHelper.BindList(ddlSettingType, new SfmController().GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.SettingType), "AutoID", "Name", ListHelper.DefaultList);
                    //load status
                    ListHelper.BindList(ddlStatus, ListHelper.GetStatusSource(), "Value", "Text", null);
                    if (_editID > 0)
                    {
                        LoadEditValue(_editID);
                    }
                }
            }
        }
        /*
         * Partha Ranjan
         * @ 07-02-13
         * Thhsi function set the value of the edit
         * */
        private void LoadEditValue(int editID)
        {
            try
            {

                StoneCategorySettingTypeModel model = new StoneCategorySettingTypeController().StoneSettingTypeList(editID, CommonModel.RecordStatus.Both).FirstOrDefault();
                if (model != null)
                {
                    hdnID.Value = model.StoneCategorySettingTypeId.ToString();
                    ddlStoneCategoryType.SelectedValue = model.StoneCategoryTypeId.ToString();
                    ddlSettingType.SelectedValue = model.SettingTypeId.ToString();
                    txtPrice.Text = model.Price.ToString();
                    ddlStatus.SelectedIndex = model.Status ? 0 : 1;
                }
                else
                {
                    //Redirect to the list page
                    Response.Redirect("/Master/Setting/ListCategorySettingType.aspx?status=invalid");
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