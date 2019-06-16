using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Order;
using EJewel.DAL.Admin.Order;

namespace EJewel.Controller.Admin.Order
{
   public class PromocodeTypeController
    {

       PromocodeTypeDAL objPromocodeType = new PromocodeTypeDAL();


       public List<PromocodeTypeModel> GetPromocodeType(CommonModel.RecordStatus status)
       {
           return objPromocodeType.GetPromocodeType(status);
       }
    }
}
