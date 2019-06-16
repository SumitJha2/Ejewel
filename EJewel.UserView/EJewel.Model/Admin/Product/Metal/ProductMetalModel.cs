using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product
{
    /*
         * Partha Ranjan
         * @ 19-01-2013
         * */
    public class ProductMetalModel
    {
        public long ProductMetalID { get; set; }
        public long ProductID { get; set; }
        public int MetalTypeID { get; set; }
        public bool DefaultMetal { get; set; }
        public bool Status { get; set; }
    }
}
