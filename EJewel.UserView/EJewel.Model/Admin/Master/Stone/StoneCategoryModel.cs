using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Stone
{
    public enum StoneCategory : int
    {
        DIAMONDS = 1,
        GEMSTONE = 2
    }
    public enum StoneCategoryType : int
    {
        CENTERSTONE = 1,
        SIDESTONE = 2
    }
    public class StoneCategoryModel
    { /*
      * * Author: Sumit jha 
    * 11-12-2012 
      * */
        public int StoneCategoryID { get; set; }
        public string StoneCategoryName { get; set; }
        public bool Status { get; set; }
    }
}
