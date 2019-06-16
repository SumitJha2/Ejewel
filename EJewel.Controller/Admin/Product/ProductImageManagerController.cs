using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Common;
//dal
using EJewel.DAL.Admin.Product;
//controller
using EJewel.Controller.Admin.Product;

namespace EJewel.Controller.Admin.Product
{
    public class ProductImageManagerController
    {
        ProductImageManagerDAL objDAL = new ProductImageManagerDAL();
        ProductDetailsController objDetails = new ProductDetailsController();

        public ProductImageManagerModel SaveUpdate(ProductImageManagerModel model)
        {
            return objDAL.SaveUpdate(model);
        }

        public bool IsExist(long productId, string GUID)
        {
            return objDAL.IsExist(productId, GUID);
        }

        public ProductImageManagerModel ProductDefaultImageFromSKU(string SKU)
        {
            ProductDetailsModel model = objDetails.GetProductFromSKU(SKU);
            if(model!=null)
            {
                return this.ProductImageListFromProduct(model.ProductID, CommonModel.RecordStatus.Enabled).FirstOrDefault();
            }
            return null;
        }

        public List<ProductImageManagerModel> ProductImageListFromProduct(long productId, CommonModel.RecordStatus rStatus)
        {
            return objDAL.ProductImageListFromProduct(productId, rStatus);
        }
        public List<ProductImageManagerModel> ProductImageListFromProductGUID(long productId, string GUID, CommonModel.RecordStatus rStatus)
        {
            return objDAL.ProductImageListFromProductGUID(productId, GUID, rStatus);
        }

        public List<ProductImageManagerModel> ProductImageListFromGUID(string SKU, string GUID, CommonModel.RecordStatus rStatus)
        {
            return objDAL.ProductImageListFromGUID(SKU,GUID, rStatus);
        }

        public List<ProductImageManagerModel> ProductDefaultImage(ProductDetailsModel productDetails, int total_image_to_generate)
        {
            return objDAL.ProductDefaultImage(productDetails, total_image_to_generate);
        }

        public ProductImageManagerModel ProductImageFromGUID(string GUID)
        {
            return objDAL.ProductImageFromGUID(GUID);
        }

        public bool DeleteAllImage(long productId)
        {
            return objDAL.DeleteAllImage(productId);
        }


    }
}
