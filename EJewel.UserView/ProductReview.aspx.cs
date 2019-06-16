using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Product.Extras;
using EJewel.Controller.Admin.Product.Extras;


namespace EJewel.UserView
{
    public partial class ProductReview : System.Web.UI.Page
    {
         long productid = 0;
         ProductReviewModel objProductReviewModel = new ProductReviewModel();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Request.QueryString["id"] != null)
            {
                productid = Convert.ToInt64(Request.QueryString["id"]);
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
           if(productid>0)
            {

                objProductReviewModel.ProductId = productid;
            }          
           
            objProductReviewModel.Heading = txtHeading.Text;
            objProductReviewModel.Review = txtDescription.Text;
            objProductReviewModel.Name = txtName.Text;
            if (txtRating.Text != "")
            {
                objProductReviewModel.Rating = Convert.ToInt32(txtRating.Text);
            }
            else
            {
                objProductReviewModel.Rating = 0;
            }
            objProductReviewModel.email = txtEmail.Text;
            objProductReviewModel.Status = false;
            new ProductReviewController().SaveUpdateProductReview(objProductReviewModel);

        }
    }
}