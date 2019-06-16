using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Order;

namespace EJewel.DAL.Admin.Order
{
   public class PromotionalcodeManagementDAL
    {

       EJewelEntities objejewelentity = new EJewelEntities();



       public PromotionalcodeManagementModel SaveUpdatePromotionalcodeManagement(PromotionalcodeManagementModel model)
       {
           try
           {
               if (model.PromotionalcodeManagementID > 0)
               {
                   ej_PromotionalcodeManagement objPromotionalcodeManagement = objejewelentity.ej_PromotionalcodeManagement.Where(tbl => tbl.PromotionalCodeId == model.PromotionalcodeManagementID).FirstOrDefault();
                   if (objPromotionalcodeManagement != null)
                   {

                       // objPromotionalcodeManagement.PromotionalCodeId = model.PromotionalcodeManagementID;
                       objPromotionalcodeManagement.PromotionalcodeTypeID = model.PromotionalcodeTypeID;
                       objPromotionalcodeManagement.PromotionalCode = model.Promotionalcode;
                       objPromotionalcodeManagement.CategoryID = model.CategoryID;
                       objPromotionalcodeManagement.SubCategoryID = model.SubcategoryID;
                       objPromotionalcodeManagement.ProductDiscountValue = model.ProductDiscountValue;
                       objPromotionalcodeManagement.ProductValidFrom = model.ProductValidFrom;
                       objPromotionalcodeManagement.ProductValidTo = model.ProductValidTo;
                       objPromotionalcodeManagement.Status = model.Status;
                       objPromotionalcodeManagement.ProductID = model.ProductID;
                       objPromotionalcodeManagement.ProductDiscountType = model.ProductDiscountType;
                       objejewelentity.SaveChanges();
                   }

               }
               else
               {
                   ej_PromotionalcodeManagement objPromotionalcodeManagement = new ej_PromotionalcodeManagement();

                   objPromotionalcodeManagement.PromotionalcodeTypeID = model.PromotionalcodeTypeID;
                   // PromotionalCodeId = model.PromotionalcodeManagementID,
                   objPromotionalcodeManagement.PromotionalCode = model.Promotionalcode;
                   objPromotionalcodeManagement.CategoryID = model.CategoryID;
                   objPromotionalcodeManagement.SubCategoryID = model.SubcategoryID;
                   objPromotionalcodeManagement.ProductDiscountValue = model.ProductDiscountValue;
                   objPromotionalcodeManagement.ProductValidFrom = model.ProductValidFrom;
                   objPromotionalcodeManagement.ProductValidTo = model.ProductValidTo;
                   objPromotionalcodeManagement.Status = model.Status;
                   objPromotionalcodeManagement.ProductID = model.ProductID;
                   objPromotionalcodeManagement.ProductDiscountType = model.ProductDiscountType;

                   objejewelentity.AddToej_PromotionalcodeManagement(objPromotionalcodeManagement);
                   objejewelentity.SaveChanges();
                   model.PromotionalcodeManagementID = objPromotionalcodeManagement.PromotionalCodeId;
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



       public List<PromotionalcodeManagementModel> GetPromotionalcodeManagement(int promotionalcodeManagementId, CommonModel.RecordStatus Status)
       {
           List<PromotionalcodeManagementModel> objPromotionalcodeManagementList = new List<PromotionalcodeManagementModel>();
           try
           {
               List<ej_PromotionalcodeManagement> objPromotionalcodeManagement;
               if (promotionalcodeManagementId > 0)
               {
                   objPromotionalcodeManagement = objejewelentity.ej_PromotionalcodeManagement.Where(tbl => tbl.PromotionalCodeId == promotionalcodeManagementId).ToList(); ;
               }
               else
               {
                   objPromotionalcodeManagement = objejewelentity.ej_PromotionalcodeManagement.Select(tbl => tbl).ToList();
               }
               if (Status == CommonModel.RecordStatus.Enabled)
               {

                   objPromotionalcodeManagement = objPromotionalcodeManagement.Where(tbl => tbl.Status == true).ToList();
               }
               if (objPromotionalcodeManagement != null)
               {
                   objPromotionalcodeManagementList = (from promotionalcodemanagement in objPromotionalcodeManagement
                                                       join product in objejewelentity.ej_Product
                                                       on promotionalcodemanagement.ProductID equals product.ProductId into group1
                                                       from g1 in group1.DefaultIfEmpty()
                                                       join category in objejewelentity.ej_PrimaryCategory on promotionalcodemanagement.CategoryID equals category.CategoryId into group2
                                                       from g2 in group2.DefaultIfEmpty()
                                                       join subcategory in objejewelentity.ej_SubCategoryMaster
                                                       on promotionalcodemanagement.SubCategoryID equals subcategory.SubCategoryId
                                                       into group3
                                                       from g3 in group3.DefaultIfEmpty()

                                                       where g1.Status == true && g2.Status == true && g3.Status == true

                                                       select new PromotionalcodeManagementModel
                                                       {

                                                           CategoryID = promotionalcodemanagement.CategoryID != 0 ? promotionalcodemanagement.CategoryID : 0,
                                                           ProductDiscountType = promotionalcodemanagement.ProductDiscountType != "0" ? promotionalcodemanagement.ProductDiscountType : "0",
                                                           ProductDiscountValue = promotionalcodemanagement.ProductDiscountValue != 0.0 ? (float)(promotionalcodemanagement.ProductDiscountValue) : 0,

                                                           ProductSKU = g1 == null ? "" : g1.SKU,
                                                           CategoryName = g2 != null ? g2.CategoryName : "",
                                                           SubCategoryName = g3 != null ? g3.SubCategoryName : "",
                                                           ProductValidFrom = promotionalcodemanagement.ProductValidFrom,
                                                           ProductValidTo = promotionalcodemanagement.ProductValidTo,
                                                           Promotionalcode = promotionalcodemanagement.PromotionalCode,
                                                           PromotionalcodeManagementID = promotionalcodemanagement.PromotionalCodeId,
                                                           PromotionalcodeTypeID = promotionalcodemanagement.PromotionalcodeTypeID,
                                                           Status = promotionalcodemanagement.Status,
                                                           SubcategoryID = promotionalcodemanagement.SubCategoryID





                                                           //CategoryID = promotionalcodemanagement.CategoryID,
                                                           //ProductDiscountType=promotionalcodemanagement.ProductDiscountType,
                                                           //ProductDiscountValue=(float)System.Convert.ToSingle(promotionalcodemanagement.ProductDiscountValue),
                                                           //ProductSKU = ge.SKU,
                                                           ////CategoryName=g2.CategoryName,
                                                           ////SubCategoryName=g3.SubCategoryName,

                                                           // ProductValidFrom=promotionalcodemanagement.ProductValidFrom,
                                                           // ProductValidTo=promotionalcodemanagement.ProductValidTo,
                                                           // Promotionalcode=promotionalcodemanagement.PromotionalCode,
                                                           //  PromotionalcodeManagementID=promotionalcodemanagement.PromotionalCodeId,
                                                           //   PromotionalcodeTypeID=promotionalcodemanagement.PromotionalcodeTypeID,
                                                           //    Status=promotionalcodemanagement.Status,
                                                           //     SubcategoryID=promotionalcodemanagement.SubCategoryID

                                                       }).ToList();
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
           return objPromotionalcodeManagementList;

       }

      public bool DeletePromotionCode(int promotioncodeId)
       {
           bool lFlag = false;
           ej_PromotionalcodeManagement objPromotionCode = objejewelentity.ej_PromotionalcodeManagement.Where(tbl => tbl.PromotionalCodeId == promotioncodeId).FirstOrDefault();
          if(objPromotionCode!=null)
          {
              objejewelentity.DeleteObject(objPromotionCode);
              objejewelentity.SaveChanges();
              lFlag = true;
          }
          return lFlag;

          
       }
      public bool IsExistPromotionCode(int promotioncodeId,string promotioncode)
        {
            if (promotioncodeId > 0)
            {
                return objejewelentity.ej_PromotionalcodeManagement.Where(tbl => tbl.PromotionalCodeId != promotioncodeId && tbl.PromotionalCode == promotioncode.Trim()).Any();
            }
            else
            {
                return objejewelentity.ej_PromotionalcodeManagement.Where(tbl => tbl.PromotionalCode == promotioncode.Trim()).Any();
            }
           
        }
       



    }
}
