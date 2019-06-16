using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Metal
{
    /*
     * Partha Ranjan
     * @ 01-02-2013
     * This class manage the metal type
     * */
    public class MetalTypeModel
    {
        public int MetalTypeId { get; set; }
        public int MetalWeightId { get; set; }
        public int MetalNameId { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
    }
}

