using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Product.Extras;
using EJewel.DAL.Admin.Product.Extras;


namespace EJewel.Controller.Admin.Product.Extras
{
   public class ProductReviewController
    {
       ProductReviewDAL objDAL = new ProductReviewDAL();
       public ProductReviewModel SaveUpdateProductReview(ProductReviewModel model)
       {
           return objDAL.SaveUpdateProductReview(model);
       }
       public List<ProductReviewModel> GetProductReviewList(long productreviewId,CommonModel.RecordStatus rstatus)
       {
           return objDAL.GetProductReviewList(productreviewId, rstatus);
       }
       public bool DeleteProductReview(long productreviewId)
       {
           return objDAL.DeleteProductReview(productreviewId);
       }
    }
}
