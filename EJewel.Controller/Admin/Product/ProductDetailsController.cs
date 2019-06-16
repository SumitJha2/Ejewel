using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Product;
//DAL
using EJewel.DAL.Admin.Product;
namespace EJewel.Controller.Admin.Product
{
    /*
     * Partha Ranjan
     * @ 19-01-2013
     * This class helps to manage the all the activity of the product
     */
    public class ProductDetailsController
    {
        ProductDetailsDAL objDAL = new ProductDetailsDAL();
        /*
        * Partha Ranjan
        * @ 19-01-2013
         * */

        public ProductDetailsModel SaveUpdateProductDetails(ProductDetailsModel model)
        {
            return objDAL.SaveUpdateProductDetails(model);
        }
       /*
       * Partha Ranjan
       * @ 19-01-2013
       * */
        public bool ExistProductSKU(string sku)
        {
            return objDAL.ExitProductSKU(sku);
        }
        /*
      * Partha Ranjan
      * @ 19-01-2013
      * */
        public bool ExistProductTitle(string title)
        {
            return objDAL.ExistProductTitle(title);
        }
        /*
         * Partha Ranjan
         * @ 21-01-2013
         * This function get the details of the product
         * */
        public ProductDetailsModel GetProductDetails(long productID)
        {
            return objDAL.GetProductList(productID).FirstOrDefault();
        }
        /* sumit jha
         * @ 28-01-2013
         * */
        public List<ProductDetailsModel> GetProductList(long productid)
        {
            return objDAL.GetProductList(productid);
        }

        public int TotalProduct
        {
            get
            {
                return objDAL.TotalProduct;
            }
        }
        /*
         * Partha Ranjan
         * @ 29-01-2013
         * This function check that the product is valid or not
         * */

        /* sumit jha
      * @ 25=03-2013
      * */
        public List<ProductDetailsModel> GetProductDetailsForListing(int primartCategoryId, int subCategoryId, string centerStoneshape, string sideStoneshape, string centerStoneSettingTypeName, string sideStoneSettingTypeName, double minPrice, double maxPrice, string gemstone_color, string gemstone_type, bool is_new_arrival,bool is_on_sales, int currentPage, int perPage)
        {
            return objDAL.GetProductDetailsForListing(primartCategoryId, subCategoryId, centerStoneshape, sideStoneshape, centerStoneSettingTypeName, sideStoneSettingTypeName, minPrice, maxPrice, gemstone_color, gemstone_type,is_new_arrival,is_on_sales, currentPage, perPage);
        }

        public int TotalFilterProduct
        {
            get
            {
                return objDAL.TotalFilterProduct;
            }
        }
        /* sumit jha
         * @ 25=03-2013
         * */
        public ProductPriceModel ProductPriceDetails(long productId,int metalTyeId,double metalWeight,bool isExtraOdinary)
        {
            return objDAL.ProductPriceDetails(productId, metalTyeId, metalWeight, isExtraOdinary);
        }
        public ProductDetailsModel GetProductFromSKU(string sku)
        {
            return objDAL.GetProductFromSKU(sku);
        }

        /* sumit jha
       * @ 09-05-2013
       * */
        public List<string> GetSkuByName(string name)
        {
            return objDAL.GetSkuByName(name);
        }
        /* sumit jha
  * @ 14-05-2013
  * */
        public bool UpdateProductSetting(ProductDetailsModel model)
        {
            return objDAL.UpdateProductSetting(model);
        }
        public long GetProductIDByProductSKU(string productSKU)
        {
            return objDAL.GetProductIDByProductSKU(productSKU);
        }
    }
}
