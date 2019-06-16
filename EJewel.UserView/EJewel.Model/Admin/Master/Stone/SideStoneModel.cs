using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Stone
{
    /// <summary>
    /// Show the Side Stone
    /// Partha Ranjan Nayak
    /// @ 01-04-13
    /// </summary>
    public class SideStoneModel
    {
        public long SideStoneId { get; set; }
        //
        public int StoneCategoryId { get; set; }
        public string StoneCategory { get; set; }
        //
        public int StoneCutId { get; set; }
        public string StoneCut { get; set; }
        //
        public int StoneColorId { get; set; }
        public string StoneColor { get; set; }
        //
        public int StoneClarityId { get; set; }
        public string StoneClarity { get; set; }
        //
        public int StoneShapeId { get; set; }
        public string StoneShape { get; set; }
        //
        public int StoneTypeId { get; set; }
        public string StoneType { get; set; }
        //
        public double StoneCarate { get; set; }
        public double StonePrice { get; set; }
        //
        public bool Status { get; set; }
    }
}
