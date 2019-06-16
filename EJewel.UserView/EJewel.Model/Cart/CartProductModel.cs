using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
/// 
namespace EJewel.Model.Cart
{
    public class CartProductModel
    {
        public int CartId { get; set; }
        public int MetalTypeId { get; set; }
        public long ProductId { get; set; }
        public int Quanity { get; set; }
        public string CenterStoneSKU { get; set; }
        public long SideStoneId { get; set; }
        public string ImageGUID { get; set; }
        public int ProductTypeId { get; set; }
        public double Price { get; set; }
        //For Ring Size and engraving
        public int RingSize { get; set; }
        public string Engraving { get; set; }
        //
    }
}