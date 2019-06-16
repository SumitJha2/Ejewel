using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Order
{
   public class ShippingModel
    {
       public int ShippingId { get; set; }
       public int ShippingNameId { get; set; }
       public string ShippingName {get; set; }
       public int ShippingTypeId { get; set; }
       public string ShippingTypeName { get; set; }
       public int CountryId { get; set; }
       public string CountryName { get; set; }
       public double Price { get; set; }
       public bool Status { get; set; }
    }
}
