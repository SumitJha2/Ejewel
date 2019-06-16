using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product
{
    public class ProductVideoModel
    {
        public long ProductVideoId { get; set; }
        public long ProductId { get; set; }
        public int CenterStoneShapeId { get; set; }
        public string VideoPathURL { get; set; }
        public string VideoPhotoURL { get; set; }
        public bool Status { get; set; }
    }
}
