using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product
{
   public class ProductSideStoneForViewModel
    {
        /* sumit jha
         * @ 06-03-2013
         * */
        public Int64 ProductID { get; set; }
        public int StoneCategoryID { get; set; }
        public Int64 StoneID { get; set; }
        public int noofsidestone { get; set; }
        public string StoneCategoryName { get; set; }
        public string StoneCategoryTypeName { get; set; }
        public string StoneShapeName { get; set; }
        public string Cut { get; set; }
        public string Color { get; set; }
        public string Clarity { get; set; }
        public float Caret { get; set; }
        public float Price { get; set; }

    }
}
