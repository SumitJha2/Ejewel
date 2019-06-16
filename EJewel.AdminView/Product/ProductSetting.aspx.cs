using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.Admin.Product;
using EJewel.Controller.Admin.Product;

using EJewel.Controller.Common;

namespace EJewel.AdminView.Product
{
    public partial class ProductSetting : System.Web.UI.Page
    {
        ProductDetailsController objController = new ProductDetailsController();
        ProductDetailsModel objModel = new ProductDetailsModel();
        long productId = 0;

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
                    productId = Convert.ToInt32(Request.QueryString["id"]);
                    if(productId==0)
                    {
                        Response.Redirect("/Product/ProductList.aspx");
                    } 
                    

                    if (!IsPostBack)
                    {
                        if (productId > 0)
                        {
                            LoadProductDetails(productId);

                        }
                        else
                        {
                            Response.Redirect("/Product/ProductList.aspx");
                        }
                    }
                    

                }
            }

        }        
        public void LoadProductDetails(long productid)
        {
            objModel = objController.GetProductList(productid).FirstOrDefault();
            lblSKUDetails.Text = objModel.SKU;
            chkBestSelling.Checked = objModel.BestSelling;
            chkMenGift.Checked = objModel.MenGift;
            chkWomenGift.Checked = objModel.WomenGift;
            chkChildrenGift.Checked = objModel.ChildrenGift;
            chkOthersGift.Checked = objModel.OtherGift;           
            chkNewProduct.Checked = objModel.NewProduct;
            if (objModel.DiscountType !=0)
            {
                ddlDiscountType.SelectedValue = objModel.DiscountType.ToString();
            }
            chkSales.Checked = objModel.OnSale;
            txtDiscount.Text = Convert.ToString(objModel.Discount);
          //  txtDiscount.Visible = chkSales.Checked == true ? true : false;
            spnDiscount.Visible = chkSales.Checked == true ? true : false;
            //lblDiscount.Visible = chkSales.Checked == true ? true : false;         
            chkPublish.Checked = objModel.Publish;
            chkExtraOrdinary.Checked = objModel.IsExtraOrdinary;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                objModel.ProductID = productId;
                objModel.BestSelling = chkBestSelling.Checked == true ? true : false;
                objModel.MenGift = chkMenGift.Checked == true ? true : false;
                objModel.WomenGift = chkWomenGift.Checked == true ? true : false;
                objModel.ChildrenGift = chkChildrenGift.Checked == true ? true : false;
                objModel.OtherGift = chkOthersGift.Checked == true ? true : false;
                objModel.DiscountType = Convert.ToInt32(ddlDiscountType.SelectedValue);
                objModel.NewProduct = chkNewProduct.Checked == true ? true : false;
                objModel.OnSale = chkSales.Checked == true ? true : false;
                objModel.Publish = chkPublish.Checked == true ? true : false;
                objModel.IsExtraOrdinary = chkExtraOrdinary.Checked == true ? true : false;
                if (chkSales.Checked == true)
                {
                    objModel.Discount = (float)(Convert.ToDouble(txtDiscount.Text));
                }
                objController.UpdateProductSetting(objModel);
                spnMessage.InnerText = "Details saved successfully.";
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

        protected void chkSales_changed(object sender, EventArgs e)
        {
            if (chkSales.Checked == true)
            {
                spnDiscount.Visible = true;
               // lblDiscount.Visible = true;
                //txtDiscount.Visible = true;
               
            }
            else
            {
                spnDiscount.Visible = false;
               // txtDiscount.Visible = false;                
                txtDiscount.Text = "0";
                ddlDiscountType.SelectedValue = "1";
            }
        }
        
    }
}