using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Order;
using EJewel.DAL.Admin.Order;


namespace EJewel.Controller.Admin.Order
{
   public class ShippingController
    {
       ShippingDAL objDAL = new ShippingDAL();
       public ShippingModel SaveUpdateShipment(ShippingModel model)
       {
           return objDAL.SaveUpdateShipping(model);
       }
       public List<ShippingModel> GetShippingList(int shippingnameId, int shippingTypeId)
       {
           return objDAL.GetShippingList(shippingnameId, shippingTypeId);
       }
       public bool DeleteShippingDetails(int shippingnameId, int shippingTypeId)
       {
           return objDAL.DeleteShippingDetails(shippingnameId, shippingTypeId);
       }
    }
}
