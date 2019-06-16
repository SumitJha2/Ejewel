using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Product.Extras;

namespace EJewel.DAL.Admin.Product.Extras
{
   public class QueriesOnProductDAL
    {
       EJewelEntities objEntity = new EJewelEntities();
       public QueriesOnProductModel SaveUpdateProductDAL(QueriesOnProductModel model)
       {
           try
           {
               if (model.ProductQueriesId > 0)
               {
                   ej_QueriesOnProduct objProduct = objEntity.ej_QueriesOnProduct.Where(tbl => tbl.ProductQueriesId == model.ProductQueriesId).FirstOrDefault();
                   if (objProduct != null)
                   {
                       objProduct.ProductId = model.ProductId;
                       objProduct.FirstName = model.FirstName;
                       objProduct.LastName = model.LastName;
                       objProduct.Email = model.Email;
                       objProduct.TelePhone = model.Telephone;
                       objProduct.Message = model.Message;
                       objProduct.Status = model.Status;
                       objEntity.SaveChanges();
                   }
               }
               else
               {
                   ej_QueriesOnProduct objProduct = new ej_QueriesOnProduct()
                   {
                       ProductId = model.ProductId,
                       FirstName = model.FirstName,
                       LastName = model.LastName,
                       Email = model.Email,
                       TelePhone = model.Telephone,
                       Message = model.Message,
                       Status = model.Status,
                       Date = System.DateTime.Now

                   };
                   objEntity.AddToej_QueriesOnProduct(objProduct);
                   objEntity.SaveChanges();
                   model.ProductQueriesId = objProduct.ProductQueriesId;
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

       public List<QueriesOnProductModel> GetQueriesOnProduct(long productqueriesId)
       {
           List<ej_QueriesOnProduct> objQueriesOnProduct = new List<ej_QueriesOnProduct>();
           List<QueriesOnProductModel> lstProductQueryModel = new List<QueriesOnProductModel>();
           try
           {
               if (productqueriesId > 0)
               {
                   objQueriesOnProduct = objEntity.ej_QueriesOnProduct.Where(tbl => tbl.ProductQueriesId == productqueriesId).ToList();
               }
               else
               {
                   objQueriesOnProduct = objEntity.ej_QueriesOnProduct.Select(tbl => tbl).ToList();
               }
               lstProductQueryModel = (from lst in objQueriesOnProduct
                                       join product in objEntity.ej_Product
                                       on lst.ProductId equals product.ProductId
                                       where product.Status == true
                                       select new QueriesOnProductModel
                                       {
                                           ProductQueriesId = lst.ProductQueriesId,
                                           ProductId = lst.ProductId,
                                           sku = product.SKU,
                                           FirstName = lst.FirstName,
                                           LastName = lst.LastName,
                                           Email = lst.Email,
                                           Telephone = lst.TelePhone,
                                           Message = lst.Message,
                                           Status = lst.Status,
                                           Date = lst.Date
                                       }).OrderByDescending(tbl => tbl.ProductQueriesId).ToList();
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

           return lstProductQueryModel;
       }

       public bool DeleteQueriesOnProduct(long queriesonproductId)
       {
           bool flag=false;
           try
           {
               if (queriesonproductId > 0)
               {
                   ej_QueriesOnProduct objProduct = objEntity.ej_QueriesOnProduct.Where(tbl => tbl.ProductQueriesId == queriesonproductId).FirstOrDefault();
                   objEntity.DeleteObject(objProduct);
                   objEntity.SaveChanges();
                   flag = true;
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
