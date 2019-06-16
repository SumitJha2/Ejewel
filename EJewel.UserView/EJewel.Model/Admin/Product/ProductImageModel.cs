using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product
{
    /// <summary>
    /// Manage the Image data
    /// </summary>

    public class ProductImageMetalModel
    {
        //metal Type
        public int MetalTyeID { get; set; }
        public string MetalName { get; set; }
        public string MetalWeight { get; set; }
    }

    public class ProductImageCenterStoneModel
    {
        //center stone
        public int CenterStoneShapeID { get; set; }
        public string CenterStoneShape { get; set; }
    }

    public class ProductImageSideStoneModel
    {
        //side stone
        public int SideStoneShapeId { get; set; }
        public string SideStoneShape { get; set; }
        public long ProductSideStoneId { get; set; }
    }

    public class ProductImageSideStoneTypeModel
    {
        //side stone type
        public int SideStoneTypeId { get; set; }
        public string SideStoneType { get; set; }
    }

    public class ProductImageMatchingBandModel
    {
        //matching band stone
        public int MatchingBandShapeId { get; set; }
        public string MatchingBandShape { get; set; }
    }

    public class ProductImageMatchingBandStoneTypeModel
    {
        //matching band stone type
        public int MatchingBandStoneTypeId { get; set; }
        public string MatchingBandStoneType { get; set; }
    }

    public class ProductSideStoneImageModel
    {
        public string Shape { get; set; }
        public int ShapeId { get; set; }
        public long ProductSideStoneId { get; set; }
        public bool IsCustomize { get; set; }
    }
}

