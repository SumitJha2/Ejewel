using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Payment
{
   public class PaymentViaModel
    {
       /* sumit jha
     * @ 26-12-2012
     * */
        public int PaymentID { get; set; }
        public string PaymentOption { get; set; }
        public bool Status { get; set; }
    }
}
