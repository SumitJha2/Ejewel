using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//dal
using EJewel.DAL.User.Product;
//model
using EJewel.Model.Admin.Master.Category;
using EJewel.Model.Admin.Common;

namespace EJewel.Controller.User.Product
{
    public class ProductPageController
    {
        ProductPageDAL objDAL = new ProductPageDAL();

        public SubCategoryModel GetProductSubCategoryFromName(string sub_category, CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetProductSubCategoryFromName(sub_category, rStatus);
        }

        public PrimaryCategoryModel GetProductPrimaryCategoryFromName(string primary_category, CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetProductPrimaryCategoryFromName(primary_category, rStatus);
        }
    }
}
