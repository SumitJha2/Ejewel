using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace EJewel.Model.Admin.Product
{
    /// <summary>
    /// Get Product Center Stone Shape Model
    /// </summary>
    public class ProductCenterStoneShapeModel
    {
        public long ProductCenterStoneShapeId { get; set; }
        public long ProductCenterStoneId { get; set; }
        public int StoneShapeId { get; set; }
        public string StoneShape { get; set; }
        public bool DefaultShape { get; set; }
        public long StoneId { get; set; }
        public bool Status { get; set; }
    }
}
