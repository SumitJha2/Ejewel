using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Payment
{
   public class ShipmentMethodModel
    {
       /* sumit jha
        * @26-12-2012
        * */
       public int ShipmentID { get; set; }
       public string ShipmentName { get; set; }
       public double Price { get; set; }
       public bool Status { get; set; }
   }
}
