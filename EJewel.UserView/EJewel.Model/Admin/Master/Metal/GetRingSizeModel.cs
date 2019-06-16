using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Metal
{
   public class GetRingSizeModel
    {
       /* sumit jha
        * @ 09-01-2013
        * */
        public int RingSizeID { get; set; }
        public int CategoryID { get; set; }
        public int MetalTypeID { get; set; }
        public float Size { get; set; }
        public double Price { get; set; }
        public bool RingDefault { get; set; }
        public bool Status { get; set; }
        public string CategoryName { get; set; }
        public string MetalName { get; set; }
    }
}
