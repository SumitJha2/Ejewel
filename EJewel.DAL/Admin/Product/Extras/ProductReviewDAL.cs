using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Product.Extras;

namespace EJewel.DAL.Admin.Product.Extras
{
   public class ProductReviewDAL
    {
       EJewelEntities objEntity = new EJewelEntities();
       public ProductReviewModel SaveUpdateProductReview(ProductReviewModel model)
       {
           try
           {
               if (model.ReviewId > 0)
               {
                   ej_ProductReview objProductReview = objEntity.ej_ProductReview.Where(tbl => tbl.ReviewId == model.ReviewId).FirstOrDefault();
                   objProductReview.Review = model.Review;
                   objProductReview.Rating = model.Rating;
                   objProductReview.Name = model.Name;
                   objProductReview.Heading = model.Heading;
                   objProductReview.ProductId = model.ProductId;
                   objProductReview.Email = model.email;
                   objProductReview.Status = model.Status;
                   objEntity.SaveChanges();
               }
               else
               {
                   ej_ProductReview objProduct = new ej_ProductReview()
                   {
                       Review = model.Review,
                       Rating = model.Rating,
                       Name = model.Name,
                       Heading = model.Heading,
                       ProductId = model.ProductId,
                       Email = model.email,
                       Status = model.Status,
                       Date = System.DateTime.Now

                   };
                   objEntity.AddToej_ProductReview(objProduct);
                   objEntity.SaveChanges();
                   model.ReviewId = objProduct.ReviewId;
               }
           }
           catch (Exception ex)
           {
               ErrorLogDAL obj = new ErrorLogDAL();
               obj.SetErrorLog(new ErrorLogModel()
               {
                   ErrorMessage = ex.Message,
                   ErrorSource = ex.Source,
                   InnerException = Convert.ToString(ex.InnerException),
                   LogTime = DateTime.Now,
                   StackTrace = ex.StackTrace,
                   UserID = "DAL"
               });
           }
           return model;
       }

       public List<ProductReviewModel> GetProductReviewList(long productreviewId,CommonModel.RecordStatus rstatus)
       {
           List<ej_ProductReview> lstproductreview = new List<ej_ProductReview>();
           List<ProductReviewModel> objProductReview = new List<ProductReviewModel>();

           try
           {
               if (productreviewId > 0)
               {
                   lstproductreview = objEntity.ej_ProductReview.Where(tbl => tbl.ReviewId == productreviewId).ToList();
               }
               else
               {
                   lstproductreview = objEntity.ej_ProductReview.Select(tbl => tbl).ToList();
               }
               if (rstatus == CommonModel.RecordStatus.Enabled)
               {
                   lstproductreview = lstproductreview.Where(tbl => tbl.Status == true).ToList();
               }
               objProductReview = (from review in lstproductreview
                                   join product in objEntity.ej_Product
                                   on review.ProductId equals product.ProductId
                                   where product.Status == true
                                   select new ProductReviewModel
                                   {
                                       ReviewId = review.ReviewId,
                                       Review = review.Review,
                                       email = review.Email,
                                       Name = review.Name,
                                       Rating = Convert.ToInt16(review.Rating),
                                       date = review.Date,
                                       ProductId = review.ProductId,
                                       Status = review.Status,
                                       Heading = review.Heading,
                                       sku = product.SKU
                                   }).OrderByDescending(tbl => tbl.ReviewId).ToList();
           }
           catch (Exception ex)
           {
               ErrorLogDAL obj = new ErrorLogDAL();
               obj.SetErrorLog(new ErrorLogModel()
               {
                   ErrorMessage = ex.Message,
                   ErrorSource = ex.Source,
                   InnerException = Convert.ToString(ex.InnerException),
                   LogTime = DateTime.Now,
                   StackTrace = ex.StackTrace,
                   UserID = "DAL"
               });
           }

           return objProductReview;

       }

       public bool DeleteProductReview(long productreviewId)
       {
           bool flag = false;
           try
           {
               if (productreviewId > 0)
               {
                   ej_ProductReview obj = objEntity.ej_ProductReview.Where(tbl => tbl.ReviewId == productreviewId).FirstOrDefault();
                   if (obj != null)
                   {
                       objEntity.DeleteObject(obj);
                       objEntity.SaveChanges();
                       flag = true;
                   }
               }
           }
           catch (Exception ex)
           {
               ErrorLogDAL obj = new ErrorLogDAL();
               obj.SetErrorLog(new ErrorLogModel()
               {
                   ErrorMessage = ex.Message,
                   ErrorSource = ex.Source,
                   InnerException = Convert.ToString(ex.InnerException),
                   LogTime = DateTime.Now,
                   StackTrace = ex.StackTrace,
                   UserID = "DAL"
               });
           }
           return flag;

       }
    }
}
