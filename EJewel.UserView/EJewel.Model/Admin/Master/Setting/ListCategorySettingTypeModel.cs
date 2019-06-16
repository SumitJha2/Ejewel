using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Setting
{
    /*
     * Partha Ranjan
     * @ 07-02-13
     * This class used to getthe list category setting model
     * */
    public class ListCategorySettingTypeModel
    {
        public int SubCategorySettingTypeId { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategory { get; set; }
        public int SettingTypeId { get; set; }
        public string SettingType { get; set; }
        public bool Status { get; set; }
    }
}
