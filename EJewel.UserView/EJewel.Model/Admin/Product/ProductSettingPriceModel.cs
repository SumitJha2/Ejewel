using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product
{
    /*
    * Partha Ranjan
    * @ 22-01-13
    * This class manage all the details of the product setting price
    * */
    public class ProductSettingPriceModel
    {
        public string MetalType { get; set; }
        public double MetalPrice { get; set; }
        public double MetalWeight { get; set; }
        public double SetterPrice { get; set; }
        public double TotalMetalSettingPrice { get; set; }
        public double TotalMetalPrice { get; set; }
        public double TotalPrice { get; set; }
    }
}
