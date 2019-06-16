using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using EJewel.Controller.Admin.Master.Category;
using EJewel.Model.Admin.Master.Category;
using EJewel.Model.Admin.Common;
//controller
using EJewel.Controller.Common;
using EJewel.Controller.Admin.Common.Sfm;


namespace EJewel.AdminView.Master.Category
{
    public partial class AddCategory1 : System.Web.UI.Page
    {
        CategoryController objController = new CategoryController();
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
                    //load primary category
                    ListHelper.BindList(ddlParentCategory, objController.GetPrimaryCategoryList(0, CommonModel.RecordStatus.Enabled), "CategoryId", "CategoryName", ListHelper.DefaultList);
                    //lod status
                    ListHelper.BindList(ddlStatus, ListHelper.GetStatusSource(), "Value", "Text", null);
                    if (Request.QueryString["id"] != null)
                    {
                        int subcatid = Convert.ToInt32(Request.QueryString["id"]);
                        loadEditCategory(subcatid);
                    }                 
                }
            }
        }

        public void loadEditCategory(int subcategoryid)
        {
            try
            {
                SubCategoryModel model = objController.GetSubCategoryList(subcategoryid, CommonModel.RecordStatus.Both).FirstOrDefault();
                if (model != null)
                {
                    txtCategoryName.Text = model.SubCategoryName;
                    hdnID.Value = model.SubCategoryId.ToString();
                    ddlParentCategory.Items.FindByValue(model.CategoryId.ToString()).Selected = true;                 
                    txtPageTitle.Text = model.PageTitle;
                    txtMetaKeywords.Text = model.MetaKeywords;
                    txtMetaDescription.Text = model.MetaDescription;
                    ddlStatus.SelectedIndex = model.Status ? 0 : 1;
                   // spnProgress.Text = "<img src='/upload/images/category/" + model.ImagePath + "' alt='Photo' style='width:50px;height:50px;' />";
                }
                else
                {
                    Response.Redirect("/Master/Category/ListCategory.aspx");
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