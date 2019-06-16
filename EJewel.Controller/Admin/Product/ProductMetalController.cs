using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Common;
//dal
using EJewel.DAL.Admin.Product;

namespace EJewel.Controller.Admin.Product
{
    /// <summary>
    /// Manage the product metal
    /// Author: Partha Ranjan
    /// @ 25-02-13
    /// </summary>
    
    public class ProductMetalController
    {
        ProductMetalDAL objDAL = new ProductMetalDAL();

        public List<ProductMetalModel> GetProductMetalList(long productID, CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetProductMetalList(productID, rStatus);
        }

        public ProductMetalModel GetProductMetal(long productID, int metalTypeID)
        {
            return objDAL.GetProductMetal(productID, metalTypeID);
        }

        public bool IsExist(long productID, int metalTypeID)
        {
            return objDAL.IsExist(productID, metalTypeID);
        }

        public ProductMetalModel SaveUpdateProductMetal(ProductMetalModel model)
        {
            return objDAL.SaveUpdateProductMetal(model);
        }

        public bool UpdateProduct_Weight_Width(long productID, double weight, double width)
        {
            return objDAL.UpdateProduct_Weight_Width(productID, weight, width);
        }

        public ProductMetalModel GetProductDefaultMetalType(long productID)
        {
            return objDAL.GetProductDefaultMetalType(productID);
        }
    }
}
