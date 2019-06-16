using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Setting;
using EJewel.DAL.Admin.Master.Setting;

namespace EJewel.Controller.Admin.Master.Setting
{
    
   public class ProductFilterController
    {
       ProductFilterDAL objDAL = new ProductFilterDAL();
       public ProductFilterModel GetProductFilter(int subcategoryId)
       {
           return objDAL.GetProductFilter(subcategoryId);
       }
       public ProductFilterModel SaveUpdateProductFilter(ProductFilterModel model)
       {
           return objDAL.SaveUpdateProductFilter(model);
       }

    }
}
