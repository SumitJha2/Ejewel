using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product
{
    /*
     * Partha Ranjan
     * @ 19-01-2013
     * This class hold the basic detAILS OF The product
     * */
    public class ProductDetailsModel
    {
        public long ProductID { get; set; }
        public int SubCategoryID { get; set; }
        public string SKU { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescripation { get; set; }
        public string PageTitle { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescripation { get; set; }
        //sumit 28-01-13
        public string PrimaryCategoryName { get; set; }
        public int PrimaryCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        //partha 28-01-13
        public bool Status { get; set; }
        public bool Publish { get; set; }
        //partha 06-02-13
        public double ProductWeight { get; set; }
        //partha 19-03-13
        public double ProductWidth { get; set; }
        //added
        public double ProductDefaultPrice { get; set; }

        // added by sumit on 09-05-2013
        //public int CategoryId { get; set; }
        //added by sumit on 14-05-2013 
        public bool BestSelling { get; set; }
        public bool NewProduct { get; set; }
        public bool OtherGift { get; set; }
        public bool MenGift { get; set; }
        public bool WomenGift { get; set; }
        public bool ChildrenGift { get; set; }


        public bool OnSale { get; set; }
        public double Discount { get; set; }
        public int DiscountType { get; set; }

        public bool IsExtraOrdinary { get; set; }

    }
}
