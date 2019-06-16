using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Order
{
   public class PromotionalcodeManagementModel
    {
       public int PromotionalcodeManagementID
       {
           get;
           set;
       }
       public string Promotionalcode
       {
           get;
           set;
       }
       public int PromotionalcodeTypeID
       {
           get;
           set;
       }
       public int CategoryID
       {
           get;
           set;
       }
       public string CategoryName
       {
           get;
           set;
       }
       public int SubcategoryID
       {
           get;
           set;
       }
       public string SubCategoryName
       {
           get;
           set;
       }
       public DateTime ProductValidFrom
       {
           get;
           set;
       }
       public DateTime ProductValidTo
       {
           get;
           set;
       }
       public long ProductID
       {
           get;
           set;
       }
       public string ProductSKU
       {
           get;
           set;
       }
       public bool Status
       {
           get;
           set;
       }
       public float ProductDiscountValue
       {
           get;
           set;
       }
       public string ProductDiscountType
       {
           get;
           set;
       }
      
    }
}
