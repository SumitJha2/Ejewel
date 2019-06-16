using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Setting;

namespace EJewel.DAL.Admin.Master.Setting
{
   public class ProductFilterDAL
    {
       EJewelEntities objEntity = new EJewelEntities();

       public ProductFilterModel GetProductFilter(int subcategoryId)
       {
           ProductFilterModel objModel = new ProductFilterModel();
           try
           {
               ej_ProductFilter objProductFilter = objEntity.ej_ProductFilter.Where(tbl => tbl.SubCategoryId == subcategoryId).FirstOrDefault();
               if (objProductFilter != null)
               {
                   objModel = new ProductFilterModel()
                   {
                       SubCategoryId = objProductFilter.SubCategoryId,
                       CenterStoneShape = objProductFilter.CenterStoneShape,
                       CenterStoneSetting = objProductFilter.CenterStoneSetting,
                       SideStoneShape = objProductFilter.SideStoneShape,
                       SideStoneSetting = objProductFilter.SideStoneSetting,
                       GemStoneColor = objProductFilter.GemStoneColor,
                       GemStoneType = objProductFilter.GemStoneType,
                       MinPrice = objProductFilter.MinPrice,
                       MaxPrice = objProductFilter.MaxPrice,
                       PriceDiff = objProductFilter.PriceDiff
                   };
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
           return objModel;
       }

       public ProductFilterModel SaveUpdateProductFilter(ProductFilterModel model)
       {
           try
           {
               ej_ProductFilter objProductFilter = objEntity.ej_ProductFilter.Where(tbl => tbl.SubCategoryId == model.SubCategoryId).FirstOrDefault();
               if (objProductFilter != null)
               {
                   objProductFilter.SubCategoryId = model.SubCategoryId;
                   objProductFilter.SideStoneSetting = model.SideStoneSetting;
                   objProductFilter.SideStoneShape = model.SideStoneShape;
                   objProductFilter.CenterStoneSetting = model.CenterStoneSetting;
                   objProductFilter.CenterStoneShape = model.CenterStoneShape;
                   objProductFilter.GemStoneType = model.GemStoneType;
                   objProductFilter.GemStoneColor = model.GemStoneColor;
                   objProductFilter.MaxPrice = model.MaxPrice;
                   objProductFilter.MinPrice = model.MinPrice;
                   objProductFilter.PriceDiff = model.PriceDiff;
                   objEntity.SaveChanges();
                   model.SubCategoryId = objProductFilter.SubCategoryId;


               }
               else
               {
                   ej_ProductFilter objFilter = new ej_ProductFilter()
                   {
                       SubCategoryId = model.SubCategoryId,
                       CenterStoneShape = model.CenterStoneShape,
                       CenterStoneSetting = model.CenterStoneSetting,
                       SideStoneSetting = model.SideStoneSetting,
                       SideStoneShape = model.SideStoneShape,
                       GemStoneColor = model.GemStoneColor,
                       GemStoneType = model.GemStoneType,
                       MaxPrice=model.MaxPrice,
                       MinPrice=model.MinPrice,
                       PriceDiff=model.PriceDiff
                   };
                   objEntity.AddToej_ProductFilter(objFilter);
                   objEntity.SaveChanges();
                   model.SubCategoryId = objFilter.SubCategoryId;
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
    }
}
