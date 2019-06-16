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
    public class ProductSideStoneModel
    {
        public enum PageView { Default, MatchingBand };
        public long ProductSideStoneId { get; set; }
        public long ProductId { get; set; }
        public int StoneCategoryId { get; set; }
        public int NoSideStone { get; set; }
        public long StoneId { get; set; }
        public bool Status { get; set; }
    }
}
