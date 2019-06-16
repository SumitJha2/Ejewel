using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Metal
{
    /*
     * Partha Ranjan
     * @ 02-02-13
     * This class used to disply the dat ain fork of list
     * */
    public class MetalTypeListModel
    {
        public int MetalTypeId { get; set; }
        public string MetalTypeName { get; set; }
        public string MetalTypeNamePrice { get; set; }
        public int MetalWeightId { get; set; }
        public int MetalNameId { get; set; }
        public string MetalWeight { get; set; }
        public string MetalName { get; set; }
        public double MetalPrice { get; set; }
        public bool Status { get; set; }
    }
}
