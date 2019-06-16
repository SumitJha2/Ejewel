using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Setting
{
    /// <summary>
    /// Ring Size Model
    /// </summary>
    public class RingSizeModel
    {
        public int RingSizeId { get; set; }
        public double RingSize { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategory { get; set; }
        public bool Status { get; set; }
    }
}
