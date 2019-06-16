using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product
{
    /// <summary>
    /// Product Price Model
    /// Author: Partha @ 27-02-13
    /// </summary>
    public class ProductPriceModel
    {
        //basic price
        public double MetalPrice { get; set; }
        public double CenterStonePrice { get; set; }
        public double SideStonePrice { get; set; }
        public double MatchingBandPrice { get; set; }
        //setting price
        public double CenterStoneSettingPrice { get; set; }
        public double SideStoneSettingPrice { get; set; }
        public double MatchingBandSettingPrice { get; set; }
        public double TotalSettingPrice { get; set; }
        //extra
        public double ChainPrice { get; set; }
        public double ExtraPrice { get; set; }
        public double TotalPrice { get; set; }
    }
}
