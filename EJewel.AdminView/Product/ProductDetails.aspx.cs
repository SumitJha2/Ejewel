using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//controller
using EJewel.Controller.Admin.Master.Category;
using EJewel.Controller.Admin.Product;
using EJewel.Controller.Common;
//model
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Master.Category;

namespace EJewel.AdminView.Product
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        ProductDetailsController objController = new ProductDetailsController();

        long _productID = 0;

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
                    ListHelper.BindList(ddlCategory, new CategoryController().GetProductCategoryList(), "CategoryID", "CategoryName", ListHelper.DefaultList);
                }
                //
                string pID = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(pID))
                {
                    _productID = Convert.ToInt32(pID);
                    if (_productID > 0)
                    {
                        if (!IsPostBack)
                        {
                            this.LoadEditData(_productID);
                            lnkMetal.Text = "Metal Setting »";
                            lnkMetal.CssClass = "btn btn-info";
                            lnkMetal.NavigateUrl = "/Product/ProductMetal.aspx?id=" + _productID + "&ref=self";
                        }
                    }
                    else
                    {
                        //redirect to the product details pages
                        Response.Redirect("/Product/ProductList.aspx?status=invalid&ref=product");
                    }
                }
                //for status
                string q_status = Request.QueryString["status"];
                if (!string.IsNullOrEmpty(q_status))
                {
                    if (q_status == "success")
                    {
                        lblMessage.Text = "Product Details Save Successfully.";
                        lblMessage.CssClass = "small_success";
                    }
                }
            }
        }

        /*
         * Partha Ranjan
         * @ 06-02-13
         * This function load the edit value
         * */
        private void LoadEditData(long productID)
        {
            try
            {
                ProductDetailsModel model = objController.GetProductDetails(productID);
                if (model != null)
                {
                    //set the value in the controls
                    //details
                    ddlCategory.Items.FindByValue(model.SubCategoryID.ToString()).Selected = true;
                    txtSKU.Text = model.SKU;
                    txtTitle.Text = model.ProductTitle;
                    txtDesc.Text = model.ProductDescripation;
                    //seo
                    txtPageTitle.Text = model.PageTitle;
                    txtMetaKeyword.Text = model.MetaKeyword;
                    txtMetaDesc.Text = model.MetaDescripation;
                }
                else
                {
                    //redirect to the details with invalid
                    Response.Redirect("/Product/ProductList.aspx?status=invalid&ref=product");
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

        protected void btnAction_Click(object sender, EventArgs e)
        {
            #region Save Mode
            try
            {
                //get the value from the controls
                int categoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                string sku = txtSKU.Text.Trim().ToUpper();
                string title = txtTitle.Text.Trim();
                string desc = txtDesc.Text.Trim();
                string pageTitle = txtPageTitle.Text.Trim();
                string metaKeyword = txtMetaKeyword.Text.Trim();
                string metaDesc = txtMetaDesc.Text.Trim();
                //now save the item details
                //check that the sku is present or not
                if (_productID == 0)
                {
                    if (sku.Length > 0 && !objController.ExistProductSKU(sku))
                    {
                        //check for product name

                        var model = new ProductDetailsModel { ProductID = _productID, SubCategoryID = categoryID, SKU = sku, ProductTitle = title, ProductDescripation = desc, PageTitle = pageTitle, MetaKeyword = metaKeyword, MetaDescripation = metaDesc, Status = true, Publish = false };
                        //assign the
                        model = objController.SaveUpdateProductDetails(model);
                        if (model.ProductID > 0)
                        {
                            //redirect to the metal page
                            Response.Redirect("/Product/ProductDetails.aspx?id=" + model.ProductID + "&status=success");
                        }
                        else
                        {
                            //throw error that the item not save
                            lblMessage.Text = "Error In Save";
                        }
                    }
                    else
                    {
                        //throw errow sku present
                        lblMessage.Text = "Product SKU Present";
                    }
                }
                else
                {
                    //for update
                    var model = new ProductDetailsModel { ProductID = _productID, SubCategoryID = categoryID, SKU = sku, ProductTitle = title, ProductDescripation = desc, PageTitle = pageTitle, MetaKeyword = metaKeyword, MetaDescripation = metaDesc };
                    objController.SaveUpdateProductDetails(model);
                    Response.Redirect("/Product/ProductDetails.aspx?id=" + model.ProductID + "&ref=self&status=success");
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
            #endregion
        }
    }
}