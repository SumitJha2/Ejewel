using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL.Admin.Master.Payment;
using EJewel.Model.Admin.Master.Payment;

namespace EJewel.Controller.Admin.Master.Payment
{
   public class OrderStatusController
    {
        /*
       * sumit jha
       * @26-12-2012
       * */
       OrderStatusDAL objOrderStatusDAL = new OrderStatusDAL();
       public bool OrderStatusExist(OrderStatusModel model)
       {
           return objOrderStatusDAL.IsExistOrderStatus(model);
       }
        /*
        * sumit jha
        * @26-12-2012
        * */
       public OrderStatusModel SaveUpdateOrderStatus(OrderStatusModel model)
       {
           return objOrderStatusDAL.SaveUpdateOrderStatus(model);
       }
       /*
        * sumit jha
        * @ 11-01-2013
        * */
       public bool DeleteOrderStatus(OrderStatusModel model)
       {
           return objOrderStatusDAL.DeleteOrderStatus(model);
       }
       /*
        * sumit jha
        * @ 11-01-2013
        * */
       public List<OrderStatusModel> GetOrderStatus(int orderStatusid)
       {
           return objOrderStatusDAL.GetOrderStatus(orderStatusid);
       }
    }
}
