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
    public class ProductPriceController
    {
        
        ProductPriceDAL objDAL = new ProductPriceDAL();

        public double SettingPrice(int categorySettingTypeId, int stoneCategoryTypeId, int noOfStone)
        {
            return objDAL.SettingPrice(categorySettingTypeId, stoneCategoryTypeId, noOfStone);
        }

        public double ProductCustomizeprice(ProductDetailsModel productDetails, int metalTypeId)
        {
            double totalPrice = 0;
            try
            {
                if (productDetails != null)
                {
                    //get product metal price
                    double metalPrice = objDAL.MetalPrice(metalTypeId, productDetails.ProductWeight);
                    //get centerstone price with setting
                }
            }
            catch (Exception ex)
            {

            }
            return totalPrice;
        }
    }
}
