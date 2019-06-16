using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product
{
    /*
     * Partha Ranjan
     * @ 24-01-2013
      * details of the product center stone
     * */
    public class ProductCenterStoneModel
    {
        public long ProductCenterStoneId { get; set; }
        public long ProductId { get; set; }
        //other details
        public int StoneCategoryId { get; set; }
        public int StoneCategorySettingTypeId { get; set; }
        //size
        public double StoneMinCarat { get; set; }
        public double StoneMaxCarat { get; set; }
        public bool Status { get; set; }
    }
}
