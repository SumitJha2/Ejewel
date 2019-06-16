using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Stone
{
   public class GetStoneModel
    {
       /* sumit 
        * @ 19-01-2013
        * */
        public long StoneID { get; set; }
        public int CategoryID { get; set; }
        public int CategoryTypeID { get; set; }
        public int TypeID { get; set; }
        public string SKU { get; set; }
        public int CutID { get; set; }
        public int ColorID { get; set; }
        public int ClarityID { get; set; }
        public int ShapeID { get; set; }
        public double Carte { get; set; }
        public double Price { get; set; }
        public bool Certificate { get; set; }
        public bool Status { get; set; }
        public string StoneCategoryName { get; set; }
        public string StoneTypeName { get; set; }
        public string StonecolorName { get; set; }
        public string StoneshapeName { get; set; }
        public string StoneClarityName { get; set; }
        public string StoneCutName { get; set; }
        public long certificateid { get; set; }
       

    }
}
