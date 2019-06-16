using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Payment;

namespace EJewel.DAL.Admin.Master.Payment
{
   public class ShipmentMethodDAL
    {
       /* sumit jha
        * @26-12-2012
        * */
       EJewelEntities objEntity = new EJewelEntities();
       public ShipmentMethodModel SaveUpdateShipmentMethod(ShipmentMethodModel model)
       {
           if (model.ShipmentID > 0)
           {
               ej_ShippingMethod objShipment = objEntity.ej_ShippingMethod.Where(sm => sm.ShippingMethodId==model.ShipmentID).FirstOrDefault();
               objShipment.ShippingMethodName = model.ShipmentName;
               objShipment.Status = model.Status;
               objShipment.Price = model.Price;
               objEntity.SaveChanges();              
           }
           else
           {
               ej_ShippingMethod objShipment = this.mapping(model);
               objEntity.AddToej_ShippingMethod(objShipment);
               objEntity.SaveChanges();
               model.ShipmentID = objShipment.ShippingMethodId;
           }
           return model;
       }
       /* sumit jha
        * @26-12-2012
        * */
       public ej_ShippingMethod mapping(ShipmentMethodModel model)
       {
           ej_ShippingMethod objShipping = new ej_ShippingMethod();
           objShipping.ShippingMethodName = model.ShipmentName;
           objShipping.Price = model.Price;
           objShipping.Status = model.Status;
           return objShipping;
       }
       /* sumit jha
        * @26-12-2012
        * */
       public bool IsExistShipmentName(ShipmentMethodModel model)
       {
           if (model.ShipmentID > 0)
           {
               return objEntity.ej_ShippingMethod.Where(sm => sm.ShippingMethodId != model.ShipmentID && sm.ShippingMethodName == model.ShipmentName && sm.Status == true).Any();
           }
           else
           {
               return objEntity.ej_ShippingMethod.Where(sm => sm.Status == true).Any(sm => sm.ShippingMethodName==model.ShipmentName);
           }
       }
        /* sumit jha
        * @ 14-01-2013
        * */
       public List<ShipmentMethodModel> GetShipmentMethod(int shipmentid)
       {
           List<ShipmentMethodModel> lstshipment = new List<ShipmentMethodModel>();
           if (shipmentid > 0)
           {
               ej_ShippingMethod objShipment = objEntity.ej_ShippingMethod.Where(sm => sm.ShippingMethodId == shipmentid).FirstOrDefault();
               lstshipment.Add(this.Mapping(objShipment));
           }
           else
           {
               foreach (ej_ShippingMethod obj in objEntity.ej_ShippingMethod.Where(sm => sm.Status == true))
               {
                   lstshipment.Add(this.Mapping(obj));
               }
           }
           return lstshipment.OrderByDescending(sm => sm.ShipmentID).ToList();
       }
       /* sumit jha
        * @ 14-01-2013
        * */
       public ShipmentMethodModel Mapping(ej_ShippingMethod objShipment)
       {
           ShipmentMethodModel model = new ShipmentMethodModel();
           model.ShipmentID = objShipment.ShippingMethodId;
           model.ShipmentName = objShipment.ShippingMethodName;
           model.Status = objShipment.Status;
           model.Price = objShipment.Price;
           return model;
       }
       /* sumit jha
        * @ 14-01-2013
        * */
       public bool DeleteShipmentMethod(ShipmentMethodModel model)
       {
           ej_ShippingMethod objShipment = objEntity.ej_ShippingMethod.Where(sm=>sm.ShippingMethodId==model.ShipmentID).FirstOrDefault();                  objShipment.Status = model.Status;
           objEntity.SaveChanges();
           return true;
       }

    }
}
