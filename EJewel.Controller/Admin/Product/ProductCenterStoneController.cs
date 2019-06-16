using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Common;
//dal
using EJewel.DAL.Admin.Product;
namespace EJewel.Controller.Admin.Product
{
    /// <summary>
    /// Partha @ 13-03-13
    /// </summary>
    public class ProductCenterStoneController
    {
        ProductCenterStoneDAL objDAL = new ProductCenterStoneDAL();

        public ProductCenterStoneModel SaveUpdateProductCenterStone(ProductCenterStoneModel model)
        {
            return objDAL.SaveUpdateProductCenterStone(model);
        }

        public ProductCenterStoneShapeModel SaveUpdateCenterStoneShape(ProductCenterStoneShapeModel model)
        {
            return objDAL.SaveUpdateCenterStoneShape(model);
        }

        public ProductCenterStoneModel GetProductCenterStone(long productID, int stoneCategoryID)
        {
            return objDAL.GetProductCenterStone(productID, stoneCategoryID);
        }

        public List<ProductCenterStoneShapeModel> GetProductCenterStoneShapeList(long productID, int stoneCategoryID, CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetProductCenterStoneShapeList(productID, stoneCategoryID, rStatus);
        }

        public List<StoneShapeModel> GetProductCenterStoneStoneShapeList(long productId, int stoneCategoryId,StoneShapeModel.ShapeVisibility visibility, CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetProductCenterStoneStoneShapeList(productId, stoneCategoryId,visibility, rStatus);
        }

        public CenterStoneModel GetProductCenterStoneDefaultShape(long productId, int stoneCategoryId)
        {
            return objDAL.GetProductCenterStoneDefaultShape(productId, stoneCategoryId);
        }

    }
}
