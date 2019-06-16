using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.Admin.Common;
//controller
using EJewel.Controller.Common;
//controller
using EJewel.Controller.Admin.Product;
using EJewel.Controller.Admin.Master.Category;
using EJewel.Model.Admin.Master.Category;

namespace EJewel.AdminView.Product
{
    public partial class ProductList : System.Web.UI.Page
    {
        ProductDetailsController objController = new ProductDetailsController();
        public int _totalRecord = 0;
        CategoryController objCategoryController = new CategoryController();
        List<SubCategoryModel> objSubCategory = new List<SubCategoryModel>();
        List<PrimaryCategoryModel> objPrimeryCategory = new List<PrimaryCategoryModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                _totalRecord = objController.TotalProduct;
                // added by sumit on 09-05-2013
                BindCategory();
            }
           // BindSubCategory();          

        }
        public void BindCategory()
        {

            try
            {
                objPrimeryCategory = objCategoryController.GetPrimaryCategoryList(0, CommonModel.RecordStatus.Enabled).OrderBy(tbl => tbl.CategoryName).ToList();
                if (objPrimeryCategory != null && objPrimeryCategory.Count > 0)
                {
                    ddlCategory.DataSource = objPrimeryCategory;
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "CategoryId";
                    ddlCategory.DataBind();
                }

                ddlCategory.Items.Insert(0, new ListItem("--Primary Category--", "0"));
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
       public void BindSubCategory()
        {
            try
            {
                objSubCategory = objCategoryController.GetSubCategoryList(0, CommonModel.RecordStatus.Enabled).OrderBy(tbl => tbl.SubCategoryName).ToList();
                if (objSubCategory != null && objSubCategory.Count > 0)
                {
                    ddlSubCategory.DataSource = objSubCategory;
                    ddlSubCategory.DataTextField = "SubCategoryName";
                    ddlSubCategory.DataValueField = "SubCategoryId";
                    ddlSubCategory.DataBind();
                }
                ddlSubCategory.Items.Insert(0, new ListItem("--Sub Category--", "0"));
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