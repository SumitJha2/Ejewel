using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Common.SingleField
{
    /*
     * Partha
     * @ 30-01-13
     * This class helps to manage the 3 field in a table
     * */
    public class SingleFieldModel
    {
        //this is the detail enum which conatins the action of the page 
        public enum PageName { None, MetalWeightMaster, MetalNameMaster, SettingType, UnitMaster };
        public int AutoID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string IsActive { get; set; }
    }
}
