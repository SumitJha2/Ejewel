using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.User
{
   public class RegisterCustomerModel
    {
        public long CustomerID { get; set; }
        public string CustomerEmailID { get; set; }
        public string CustomerPassword { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public bool CustomerStatus { get; set; }
    }
}
