using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product
{
   public class ProductChainModel
    {
       public long ProductChainId { get; set; }
       public long ProductId { get; set; }
       public int ChainLengthId { get; set; }
       public int ChainStyleId { get; set; }
       public int ChainClaspId { get; set; }
       public bool Status { get; set; }

       public string Clasp { get; set; }
       public double Length { get; set; }
       public string Style { get; set; }

    }
}
