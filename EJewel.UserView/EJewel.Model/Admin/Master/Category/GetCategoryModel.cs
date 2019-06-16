using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Category
{
   public class GetCategoryModel
    {
       /* sumit jha
        * @ 10-01-2012
        * */
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CategoryOrder { get; set; }
        public string Description { get; set; }
        public string PageTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool ShowOnTop { get; set; }
        public string ImagePath { get; set; }
        public bool Status { get; set; }      
        public int SubCategoryID { get; set; }
        public int CategoryParentID { get; set; }
        public int CategoryChildID { get; set; }
        public string ParentCategoryName { get; set; }

    }
}
