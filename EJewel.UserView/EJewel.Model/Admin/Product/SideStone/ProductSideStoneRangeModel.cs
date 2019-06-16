using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product
{
    /// <summary>
    /// For Product Side Stone Range Model
    /// 18-03-12
    /// Partha Ranjan
    /// </summary>
  public  class ProductSideStoneRangeModel
    {
        public long ProductSideStoneRangeId { get; set; }
        public long ProductId { get; set; }
        public int StoneCategoryId { get; set; }
        public double StoneMinCarat { get; set; }
        public double StoneMaxCarat { get; set; }
    }
}
