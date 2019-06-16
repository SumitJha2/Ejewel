using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.User
{
   public class CustomerAccountDetailsModel
    {
        public long CustomerDetailsID { get; set; }
        public long CustomerID { get; set; }
        public string CustomerEmailID { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerMiddleName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerFaxNumber { get; set; }
        public Int32 CityId { get; set; }
        public string CityName { get; set; }
        public Int32 StateId { get; set; }
        public string StateName { get; set; }
        public Int32 CountryId { get; set; }
        public string CountryName { get; set; }
        public Int32 ZipCodeID { get; set; }
        public string ZipCode { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public bool IsDefaultAddress { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
