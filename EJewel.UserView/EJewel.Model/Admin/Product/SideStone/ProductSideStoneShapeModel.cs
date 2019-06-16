using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product
{
    /// <summary>
    /// For Product Side Stone Shape Model
    /// </summary>
    public class ProductSideStoneShapeModel
    {
        public long ProductSideStoneShapeId { get; set; }
        public long ProductSideStoneRangeId { get; set; }
        public int StoneShapeId { get; set; }
        public bool Status { get; set; }

        // added by sumit on 03-06-2013 for Productview

        public string ShapeName { get; set; }
    }
}
