using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product.Extras
{
   public class ProductReviewModel
    {
       public long ReviewId { get; set; }
       public long ProductId { get; set; }
       public string Heading { get; set; }
       public string Review { get; set; }
       public string Name { get; set; }
       public string email { get; set; }
       public int Rating { get; set; }
       public DateTime date { get; set; }
       public bool Status { get; set; }

       public string sku { get; set; }

    }
}
