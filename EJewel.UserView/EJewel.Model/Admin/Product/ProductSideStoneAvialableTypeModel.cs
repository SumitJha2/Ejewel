using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product
{
    /// <summary>
    /// Model for Side Stone Avialable Type
    /// </summary>
   public class ProductSideStoneAvialableTypeModel
    {
        public long AutoID { get; set; }
        public long ProductSideStoneId { get; set; }
        public int StoneTypeId { get; set; }
        public bool Status { get; set; }
    }
}
