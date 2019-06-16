using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Setting;
using EJewel.DAL.Admin.Master.Setting;

namespace EJewel.Controller.Admin.Master.Setting
{
   public class ProductAttributeController
    {
       ProductAttributeDAL objDAL = new ProductAttributeDAL();
       public ProductAttributeModel SaveUpdateProductAttribute(ProductAttributeModel model)
       {
           return objDAL.SaveUpdateProductAttribute(model);
       }
       public List<ProductAttributeModel> GetProductAttribute(int attributeId, CommonModel.RecordStatus rstatus)
       {
           return objDAL.GetProductAttribute(attributeId, rstatus);
       }
       public bool DeleteProductAttribute(int attributeId)
       {
           return objDAL.DeleteProductAttribute(attributeId);
       }
    }
}
