using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Setting
{
    /// <summary>
    /// Manage the price model
    /// </summary>
    public class PriceModel
    {
        public enum PageName { SettingPrice, SetterPrice,None };
        public int AutoID { get; set; }
        public double Price { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategory { get; set; }
        public bool Status { get; set; }
    }
}
