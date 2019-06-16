using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product
{
    /*
   * Partha Ranjan
   * @ 24-01-2013
    * details of the product side stone
   * */
    public class ProductSideStoneRangeModel
    {
        public long ProductSideStoneRangeId { get; set; }
        public long ProductId { get; set; }
        public int StoneCategoryId { get; set; }
        public double StoneMinCarat { get; set; }
        public double StoneMaxCarat { get; set; }

    }
}
