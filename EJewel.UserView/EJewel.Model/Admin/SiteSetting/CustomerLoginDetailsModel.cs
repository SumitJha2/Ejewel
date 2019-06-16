using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.SiteSetting
{
   public class CustomerLoginDetailsModel
    {

        public int LoggedCustomerID
        {
            get;
            set;
        }
        public DateTime LoggedDatetime
        {
            get;
            set;
        }
        public string LoggedCustomerIP
        {
            get;
            set;
        }
        public string CustomerID
        {
            get;
            set;
        }
      
    }
}
