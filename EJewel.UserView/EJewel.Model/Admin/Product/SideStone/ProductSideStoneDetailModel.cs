using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product
{
   public class ProductSideStoneDetailModel
    {
       /* sumit jha
        * @04-04-2013
        * */

        public long ProductSideStoneId { get; set; }
        public long ProductId { get; set; }
        public int StoneCategoryId { get; set; }
        public int NoOfStone { get; set; }
        public int StoneCategorySettingTypeId { get; set; }
        public long StoneId { get; set; }    

        public string cut { get; set; }
        public string color { get; set; }
        public string clarity { get; set; }
        public string shape { get; set; }
        public string settingType { get; set; }
        public double Price { get; set; }
        public double StoneCarate { get; set; }

        public int DesignTypeId { get; set; }
        public bool IsCustomize { get; set; }

       
    }
}
