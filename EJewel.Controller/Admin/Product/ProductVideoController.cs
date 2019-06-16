using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EJewel.Model.Admin.Product;
using EJewel.DAL.Admin.Product;
namespace EJewel.Controller.Admin.Product
{
    public class ProductVideoController
    {
        ProductVideoDAL objDAL = new ProductVideoDAL();

        public ProductVideoModel SaveUpdate(ProductVideoModel model)
        {
            return objDAL.SaveUpdate(model);
        }

        public List<ProductVideoModel> ProductVideo(long productId, CommonModel.RecordStatus rStatus)
        {
            return objDAL.ProductVideo(productId, rStatus);
        }

        public ProductVideoModel ProductVideo(long productId, int centerShapeId, CommonModel.RecordStatus rStatus)
        {
            return objDAL.ProductVideo(productId, centerShapeId, rStatus);
        }
    }
}
