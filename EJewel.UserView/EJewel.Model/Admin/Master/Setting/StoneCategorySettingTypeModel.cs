using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Setting
{
    public class StoneCategorySettingTypeModel
    {
        /* sumit jha
         * @ 08-03-2013
         * */
        public int StoneCategorySettingTypeId { get; set; }
        //stone category type
        public int StoneCategoryTypeId { get; set; }
        public string StoneCategoryTypeName { get; set; }
        //setting type
        public int SettingTypeId { get; set; }
        public string SettingTypeName { get; set; }
        //other details
        public double Price { get; set; }
        public bool Status { get; set; }
    }
}
