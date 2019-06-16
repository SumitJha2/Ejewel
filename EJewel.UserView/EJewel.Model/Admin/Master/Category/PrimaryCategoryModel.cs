using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Category
{
    /*
     * Partha
     * @ 04-02-13
     * This class get the primary category
     **/
    public class PrimaryCategoryModel
    {
        //basic
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        //seo
        public string PageTitle { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        //info
        public bool Status { get; set; }
    }
}
