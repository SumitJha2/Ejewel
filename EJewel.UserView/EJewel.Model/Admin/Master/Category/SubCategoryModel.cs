using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Category
{
    /* Partha Ranjan
       * 04-02-13
        * This class manage the subcategory
       * */
    public class SubCategoryModel
    {
        //basic
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        //seo
        public string PageTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        //info
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Status { get; set; }
        public bool HasRing { get; set; }
        public bool HasEngraving { get; set; }
        //Category
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        

    }
}
