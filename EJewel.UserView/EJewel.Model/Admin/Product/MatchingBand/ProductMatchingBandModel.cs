using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product.MatchingBand
{
    /*
     * Partha Ranjan
     * @ 29-01-13
     * this class for matching band of product
     * */
    public class ProductMatchingBandModel
    {
        public long ProductMatchingId { get; set; }
        public long ProductId { get; set; }
        public long MatchingProductId { get; set; }
        public bool Status { get; set; }
    }
}
