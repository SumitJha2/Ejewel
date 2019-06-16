using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Payment
{   
   public class OrderStatusModel
    {
    /* sumit jha
     * @ 26-12-2012
     * */
        public int OrderStatusID { get; set; }
        public string OrderStatusName { get; set; }
        public bool Status { get; set; }
    }
}
