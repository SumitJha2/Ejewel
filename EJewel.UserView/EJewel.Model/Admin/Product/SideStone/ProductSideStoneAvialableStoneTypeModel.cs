using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product
{
    /// <summary>
    /// Model for Side Stone Avialable Type
    /// </summary>
    public class ProductSideStoneAvialableStoneTypeModel
    {
        public long ProductSideStoneAvialableId { get; set; }
        public long ProductSideStoneId { get; set; }
        public long StoneId { get; set; }
        public bool Status { get; set; }
        //for display purpose @ 22-04-13 (partha)
        public string StoneType { get; set; }
        public int StoneTypeId { get; set; }
    }
}
