using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product
{
    public class ProductImageManagerModel
    {
        public long ImageId { get; set; }
        public long ProductId { get; set; }
        public string GUID { get; set; }
        public string ImagePath { get; set; }
        public string ImageAlt { get; set; }
        public string Angle { get; set; }
        public bool Status { get; set; }
    }
}
