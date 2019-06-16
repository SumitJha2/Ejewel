using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Product;
using EJewel.DAL.Admin.Product;

namespace EJewel.Controller.Admin.Product
{
   public class ProductChainController
    {
       ProductChainDAL objDAL = new ProductChainDAL();
       public ProductChainModel SaveUpdateProductChain(ProductChainModel objModel)
       {
           return objDAL.SaveUpdateProductChain(objModel);
       }
       public ProductChainModel GetProductChainDetail(long productId, CommonModel.RecordStatus rstatus)
       {
           return objDAL.GetProductChainDetail(productId, rstatus);
       }
       /*
       public bool IsExistProduct(long productId)
       {
           return objDAL.IsExistProduct(productId);
       }
        * */
    }
}
