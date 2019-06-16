using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Setting;

namespace EJewel.DAL.Admin.Master.Setting
{
   public class ProductAttributeDAL
    {
       EJewelEntities objEntity = new EJewelEntities();
       public ProductAttributeModel SaveUpdateProductAttribute(ProductAttributeModel model)
       {
           try
           {
               if (model.AttributeId > 0)
               {
                   ej_ProductAttribute objProductAttribute = objEntity.ej_ProductAttribute.Where(tbl => tbl.AttributeId == model.AttributeId).FirstOrDefault();
                   objProductAttribute.AttributeName = model.AttributeName;
                   objProductAttribute.AttributePrice = Math.Round(model.AttributePrice, 2);
                   objProductAttribute.SubCategoryId = model.SubCategoryId;
                   objProductAttribute.Status = model.Status;
                   objProductAttribute.IsDefault = model.IsDefault;
                   objProductAttribute.AttributeTitleId = model.AttributeTitleId;
                   objEntity.SaveChanges();
               }
               else
               {
                   ej_ProductAttribute objProduct = new ej_ProductAttribute()
                   {
                       AttributeName = model.AttributeName,
                       AttributePrice = Math.Round(model.AttributePrice, 2),
                       SubCategoryId = model.SubCategoryId,
                       AttributeTitleId = model.AttributeTitleId,
                       IsDefault = model.IsDefault,
                       Status = model.Status
                   };
                   objEntity.AddToej_ProductAttribute(objProduct);
                   objEntity.SaveChanges();
                   model.AttributeId = objProduct.AttributeId;
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
       public List<ProductAttributeModel> GetProductAttribute(int attributeId,CommonModel.RecordStatus rstatus)
       {
           List<ProductAttributeModel> lstProductAttributeModel = new List<ProductAttributeModel>();

           try
           {
               List<ej_ProductAttribute> objAttribute = new List<ej_ProductAttribute>();
               if (attributeId > 0)
               {
                   objAttribute = objEntity.ej_ProductAttribute.Where(tbl => tbl.AttributeId == attributeId).ToList();
               }
               else
               {
                   objAttribute = objEntity.ej_ProductAttribute.Select(tbl => tbl).ToList();
               }
               if (rstatus == CommonModel.RecordStatus.Enabled)
               {
                   objAttribute = objAttribute.Where(tbl => tbl.Status == true).ToList();
               }
               if (objAttribute != null)
               {
                   lstProductAttributeModel = (from lst in objAttribute
                                               join subcategory in objEntity.ej_SubCategoryMaster
                                               on lst.SubCategoryId equals subcategory.SubCategoryId
                                               join primerycategory in objEntity.ej_PrimaryCategory
                                                on subcategory.CategoryId equals primerycategory.CategoryId
                                               join title in objEntity.ej_AttributeTitle
                                               on lst.AttributeTitleId equals title.AttributeTitleId
                                               where subcategory.Status == true && primerycategory.Status == true
                                               && title.Status == true
                                               select new ProductAttributeModel
                                               {
                                                   AttributeId = lst.AttributeId,
                                                   AttributePrice = (float)lst.AttributePrice,
                                                   AttributeName = lst.AttributeName,
                                                   SubCategoryId = lst.SubCategoryId,
                                                   PrimeryCategoryId = primerycategory.CategoryId,
                                                   PrimeryCategory = primerycategory.CategoryName,
                                                   SubCategory = subcategory.SubCategoryName,
                                                   Status = lst.Status,
                                                   AttributeTitleId = lst.AttributeTitleId,
                                                   AttributeTitle = title.AttributeTitle,
                                                   IsDefault = lst.IsDefault
                                               }).OrderByDescending(tbl => tbl.AttributeId).ToList();

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
           return lstProductAttributeModel;
           
       }
       public bool DeleteProductAttribute(int attributeId)
       {
          bool flag = false;
          try
          {
              ej_ProductAttribute objProduct = objEntity.ej_ProductAttribute.Where(tbl => tbl.AttributeId == attributeId).FirstOrDefault();
              if (objProduct != null)
              {
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
