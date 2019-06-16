using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL.Admin.Master.Payment;
using EJewel.Model.Admin.Master.Payment;

namespace EJewel.Controller.Admin.Master.Payment
{
   public class ShipmentMethodController
    {
       /*sumit jha
        * 26-12-2012
        * */
       ShipmentMethodDAL objShipmentMethodDAL = new ShipmentMethodDAL();
        /*sumit jha
         * 26-12-2012
         * */
       public ShipmentMethodModel SaveUpdateShipment(ShipmentMethodModel objShipment)
       {
           return objShipmentMethodDAL.SaveUpdateShipmentMethod(objShipment);
       }
        /*sumit jha
        * 26-12-2012
        * */
       public bool ExistShipmentMethod(ShipmentMethodModel model)
       {
           return objShipmentMethodDAL.IsExistShipmentName(model);
       }
       /* sumit jha
        * @ 14-01-2013
        * */
       public List<ShipmentMethodModel> GetShipmentMethod(int shipmentid)
       {
           return objShipmentMethodDAL.GetShipmentMethod(shipmentid);
       }
       /* sumit jha
        * @ 14-01-2013
        * */
       public bool DeleteShipmentMethod(ShipmentMethodModel model)
       {
           return objShipmentMethodDAL.DeleteShipmentMethod(model);
       }

    }
}
