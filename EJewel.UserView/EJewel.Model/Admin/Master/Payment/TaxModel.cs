using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Payment
{
   public class TaxModel
    {
       public int TaxID { get; set; }
       public string TaxClass { get; set; }
       public double TaxPercent { get; set; }
       public bool Status { get; set; }
    }
}
