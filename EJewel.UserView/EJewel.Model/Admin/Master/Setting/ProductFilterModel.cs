using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Setting
{
   public class ProductFilterModel
    {
        public int SubCategoryId { get; set; }
        public bool CenterStoneShape { get; set; }
        public bool SideStoneShape { get; set; }
        public bool CenterStoneSetting { get; set; }
        public bool SideStoneSetting { get; set; }
        public bool GemStoneColor { get; set; }
        public bool GemStoneType { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public double PriceDiff { get; set; }
        

    }
}
