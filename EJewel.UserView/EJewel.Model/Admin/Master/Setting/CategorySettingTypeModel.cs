using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Setting
{
    /*
     * Partha Ranjan
     * @ 22-01-13
     * This class manage all the details of the setting category
     * */
    public class CategorySettingTypeModel
    {
        public int SubCategorySettingTypeId { get; set; }
        public int SubCategoryId { get; set; }
        public int SettingTypeId { get; set; }
        public bool Status { get; set; }
    }
}
