using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Product;
//dal
using EJewel.DAL.Admin.Product;
namespace EJewel.Controller.Admin.Product
{
    /*
    * Partha Ranjan
    * @ 22-01-13
    * This class manage all the details of the product setting dal
    * */
    public class ProductSettingTypeController
    {
        ProductSettingTypeDAL objDAL = new ProductSettingTypeDAL();
        /*
   * Partha Ranjan
   * @ 22-01-13
   * This class manage all the details of the product setting dal
   * */
        public List<ProductSettingPriceModel> GetProductSettingPriceList(long productID, double metalWeight, int subCategoryId)
        {
            return objDAL.GetProductSettingPriceList(productID, metalWeight, subCategoryId);
        }
        /*
  * Partha Ranjan
  * @ 22-01-13
  * save product setting details
  * */
        public ProductSettingTypeModel SaveUpdateProductSettingType(ProductSettingTypeModel model)
        {
            return objDAL.SaveUpdateProductSettingType(model);
        }
        /*
* Partha Ranjan
* @ 22-01-13
* get product setting details
* */
        public ProductSettingTypeModel GetProductSetting(long productID)
        {
            return objDAL.GetProductSetting(productID);
        }
    }
}
