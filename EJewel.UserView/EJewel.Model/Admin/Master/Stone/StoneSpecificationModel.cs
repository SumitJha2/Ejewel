using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Stone
{
    /*
    * Partha Ranjan
    * @ 09-02-13
    * This class manage the cut, clarity and type of the diamonds and gem stone
    * */
    public class StoneSpecificationModel
    {
        public enum PageName { Cut, Clarity, Color,Type,None };
        public int AutoID { get; set; }
        public int StoneCategoryId { get; set; }
        public string StoneCategory { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        // added by sumit on 06-06-2013

        public string ShortDescription { get; set; }
        
    }
}
