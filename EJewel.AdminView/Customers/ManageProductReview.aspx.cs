using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.Admin.Product.Extras;
using EJewel.Controller.Admin.Product.Extras;
using EJewel.Controller.Admin.Product;
using EJewel.Model.Admin.Product;
using EJewel.Controller.Common;

namespace EJewel.AdminView.Customers
{
    public partial class ManageProductReview : System.Web.UI.Page
    {
        long productreviewId = 0;
        ProductReviewController objController = new ProductReviewController();
        ProductReviewModel objProductReviewModel = new ProductReviewModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                productreviewId = Convert.ToInt64(Request.QueryString["id"]);
            }
            if (!IsPostBack)
            {
                ListHelper.BindList(ddlStatus, ListHelper.GetStatusSource(), "Value", "Text", null);
                LoadData();
                if (Request.QueryString["status"] == "success")
                {
                    spnMessage.Attributes.Add("style", "color:green");
                    spnMessage.InnerText = "Details saved successfully";
                }
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            long productid=0;
            ProductDetailsModel objModel=new ProductDetailsModel();
            bool flag=new ProductDetailsController().ExistProductSKU(txtSKU.Text.Trim());
            if(flag==true)
            {
                productid=new ProductDetailsController().GetProductIDByProductSKU(txtSKU.Text.Trim());
            }
            else
            {
                spnMessage.InnerText = "This sku does not exist.";
                return;
                //msg product does not exist.
            }
            if (productreviewId > 0)
            {
                objProductReviewModel.ReviewId = productreviewId;
            }

            objProductReviewModel.ProductId = productid;
            objProductReviewModel.Heading = txtHeading.Text;
            objProductReviewModel.Review = txtDescription.Text;
            objProductReviewModel.Name = txtName.Text;
            objProductReviewModel.Rating = Convert.ToInt16(ddlRating.SelectedItem.Text);
            objProductReviewModel.email = txtEmail.Text;
            objProductReviewModel.Status = ddlStatus.SelectedValue == "1" ? true : false;

            objController.SaveUpdateProductReview(objProductReviewModel);
            Response.Redirect("/Customers/ManageProductReview.aspx?id=" + productid + "&status=success");

        }
        public void LoadData()
        {
            if(productreviewId>0)
            {
                objProductReviewModel = objController.GetProductReviewList(productreviewId, CommonModel.RecordStatus.Both).FirstOrDefault();
                if (objProductReviewModel != null)
                {
                    txtSKU.Text = objProductReviewModel.sku;
                    txtHeading.Text = objProductReviewModel.Heading;
                    txtEmail.Text = objProductReviewModel.email;
                    txtDescription.Text = objProductReviewModel.Review;
                    txtName.Text = objProductReviewModel.Name;
                    ddlRating.SelectedItem.Text = objProductReviewModel.Rating.ToString();                   
                    ddlStatus.SelectedIndex = objProductReviewModel.Status == true ? 0 : 1;

                }
            }
           
        }
    }
}