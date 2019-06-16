using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Master.Category;
using EJewel.Model.Admin.Common;
//DAL
using EJewel.DAL.Admin.Master.Category;
namespace EJewel.DAL.User.Product
{
    /// <summary>
    /// Manage Product page
    /// Partha Ranjan
    /// @ 03-04-13
    /// </summary>
    public class ProductPageDAL
    {
        EJewelEntities objEntity = new EJewelEntities();

        public SubCategoryModel GetProductSubCategoryFromName(string sub_category, CommonModel.RecordStatus rStatus)
        {
            //convert the sub category string to normal form
            sub_category = sub_category.Replace('-', ' ');
            return new CategoryDAL().GetSubCategoryFromName(sub_category, rStatus);
        }

        public PrimaryCategoryModel GetProductPrimaryCategoryFromName(string primary_category, CommonModel.RecordStatus rStatus)
        {
            //convert the sub category string to normal form
            primary_category = primary_category.Replace('-', ' ');
            return new CategoryDAL().GetPrimaryCategoryFromName(primary_category, rStatus);
        }
    }
}
