using System;
using System.Collections.Generic;
using System.Linq;
//model
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Common;
//
namespace EJewel.DAL.Admin.Product
{
    public class ProductImageDAL
    {
        ProductCenterStoneDAL objCenterStoneDAL = new ProductCenterStoneDAL();

        ProductSideStoneDAL objSideStoneDAL = new ProductSideStoneDAL();

        public List<StoneSpecificationModel> GetProductCenterStoneList(long productId, int stoneCategoryId, List<StoneSpecificationModel> lstStoneShapeModel)
        {
            
            List<StoneSpecificationModel> lstCenterStoneShape = null;
            try
            {
                //get product center stone shape
                List<ProductCenterStoneShapeModel> lstProductCenterStoneShapeModel = objCenterStoneDAL.GetProductCenterStoneShapeList(productId, stoneCategoryId, CommonModel.RecordStatus.Enabled);
                //now doing the mapping
                if (lstProductCenterStoneShapeModel != null && lstStoneShapeModel != null)
                {
                    lstCenterStoneShape = (from stoneShape in lstStoneShapeModel
                                           join productCenterStone in lstProductCenterStoneShapeModel
                                           on stoneShape.AutoID equals productCenterStone.StoneShapeId
                                           select stoneShape).ToList();
                }
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return lstCenterStoneShape;
        }

        public List<ProductSideStoneImageModel> GetProductSideStoneList(long productId, int stoneCategoryId, List<SideStoneModel> lstSideStoneModel, SideStoneActionModel.PageName pageName)
        {
            List<ProductSideStoneImageModel> lstSideStone = new List<ProductSideStoneImageModel>();
            try
            {
                //get product stone
                List<ProductSideStoneModel> lstProductSideStoneModel = objSideStoneDAL.ProductSideStoneList(productId, stoneCategoryId, pageName, CommonModel.RecordStatus.Enabled);
                if (lstSideStoneModel != null && lstProductSideStoneModel != null)
                {
                    lstSideStone = (from sideStone in lstSideStoneModel
                                    join productStone in lstProductSideStoneModel
                                    on sideStone.SideStoneId equals productStone.StoneId
                                    select new ProductSideStoneImageModel()
                                    {
                                        ProductSideStoneId = productStone.ProductSideStoneId,
                                        Shape = sideStone.StoneShape,
                                        ShapeId = sideStone.StoneShapeId,
                                        IsCustomize = productStone.IsCustomize
                                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return lstSideStone;
        }

        public List<ProductSideStoneAvialableStoneTypeModel> GetProductStoneTypeListFromSideStone(long sidestoneId, SideStoneActionModel.PageName pagename)
        {
            try
            {
                return objSideStoneDAL.GetProductStoneTypeListFromSideStone(sidestoneId, pagename);
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return null;
        }
    }
}
