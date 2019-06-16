using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product
{
    /*
        * Partha Ranjan
        * @ 24-01-2013
        * */
    public class ProductSettingTypeModel
    {
        public long ProductSettingTypeId { get; set; }
        public long ProductId { get; set; }
        public int SettingTypeId { get; set; }
        public double Width { get; set; }
        public bool Status { get; set; }
    }
}
