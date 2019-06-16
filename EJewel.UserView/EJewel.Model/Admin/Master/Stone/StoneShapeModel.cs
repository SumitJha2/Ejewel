using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Stone
{
    /// <summary>
    /// Stone Shape for all type of stone
    /// Partha @ 04-05-13
    /// </summary>
    public class StoneShapeModel
    {
        public enum ShapeVisibility { BOTH, CENTERSTONE, SIDESTONE };
        public int StoneShapeId { get; set; }
        public int ShapeId { get; set; }
        public string Shape { get; set; }
        public int StoneCategoryId { get; set; }
        public string StoneCategoryName { get; set; }
        public bool CenterStoneVisible { get; set; }
        public bool SideStoneVisible { get; set; }
        //added by sumit on 05-06-2013
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public bool Status { get; set; }
    }
}
