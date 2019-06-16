using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Common;
//dal
using EJewel.DAL.Admin.Master.Stone;
namespace EJewel.DAL.Admin.Product
{
    /*
     * Partha Ranjan
     * @ 24-01-2013
      * details of the product center stone
     * */
    public class ProductCenterStoneDAL
    {
        EJewelEntities objEntity = new EJewelEntities();

        public ProductCenterStoneModel SaveUpdateProductCenterStone(ProductCenterStoneModel model )
        {
            try
            {
                ej_ProductCenterStone objCenterStone = objEntity.ej_ProductCenterStone.Where(tbl => tbl.ProductId == model.ProductId && tbl.StoneCategoryId == model.StoneCategoryId).FirstOrDefault();
                if (objCenterStone != null)
                {
                    //for update mode
                    objCenterStone.StoneMinCarat = model.StoneMinCarat;
                    objCenterStone.StoneMaxCarat = model.StoneMaxCarat;
                    objCenterStone.StoneCategorySettingTypeId = model.StoneCategorySettingTypeId;
                    objEntity.SaveChanges();
                    model.ProductCenterStoneId = objCenterStone.ProductCenterStoneId;
                }
                else
                {
                    //for save mode
                    ej_ProductCenterStone objStone = new ej_ProductCenterStone()
                    {
                        ProductCenterStoneId = model.ProductCenterStoneId,
                        ProductId = model.ProductId,
                        Status = model.Status,
                        StoneCategoryId = model.StoneCategoryId,
                        StoneCategorySettingTypeId = model.StoneCategorySettingTypeId,
                        StoneMaxCarat = model.StoneMaxCarat,
                        StoneMinCarat = model.StoneMinCarat
                    };
                    objEntity.AddToej_ProductCenterStone(objStone);
                    objEntity.SaveChanges();
                    model.ProductCenterStoneId = objStone.ProductCenterStoneId;
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
            return model;
        }

        public ProductCenterStoneShapeModel SaveUpdateCenterStoneShape(ProductCenterStoneShapeModel model)
        {
            try
            {
                ej_ProductCenterStoneShape objCenterStoneShape = objEntity.ej_ProductCenterStoneShape.Where(tbl => tbl.ProductCenterStoneId == model.ProductCenterStoneId && tbl.StoneShapeId == model.StoneShapeId).FirstOrDefault();
                if (objCenterStoneShape != null)
                {
                    //update
                    objCenterStoneShape.StoneShapeId = model.StoneShapeId;
                    objCenterStoneShape.Status = model.Status;
                    objCenterStoneShape.DefaultShape = model.DefaultShape;
                    objCenterStoneShape.StoneId = model.StoneId;
                    objEntity.SaveChanges();
                }
                else
                {
                    //save 
                    if (model.Status)
                    {
                        ej_ProductCenterStoneShape obj = new ej_ProductCenterStoneShape()
                        {
                            ProductCenterStoneId = model.ProductCenterStoneId,
                            ProductCenterStoneShapeId = model.ProductCenterStoneShapeId,
                            Status = model.Status,
                            StoneShapeId = model.StoneShapeId,
                            DefaultShape = model.DefaultShape,
                            StoneId = model.StoneId
                        };
                        objEntity.AddToej_ProductCenterStoneShape(obj);
                        objEntity.SaveChanges();
                        obj.ProductCenterStoneShapeId = obj.ProductCenterStoneShapeId;
                    }
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
            return model;
        }

        public ProductCenterStoneModel GetProductCenterStone(long productId, int stoneCategoryId)
        {
            try
            {
                ej_ProductCenterStone lstProductCenterStone = objEntity.ej_ProductCenterStone.Where(tbl => tbl.ProductId == productId && tbl.StoneCategoryId == stoneCategoryId).FirstOrDefault();
                if (lstProductCenterStone != null)
                {
                    return new ProductCenterStoneModel()
                    {
                        ProductCenterStoneId = lstProductCenterStone.ProductCenterStoneId,
                        ProductId = lstProductCenterStone.ProductId,
                        Status = lstProductCenterStone.Status,
                        StoneCategoryId = lstProductCenterStone.StoneCategoryId,
                        StoneCategorySettingTypeId = lstProductCenterStone.StoneCategorySettingTypeId,
                        StoneMaxCarat = lstProductCenterStone.StoneMaxCarat,
                        StoneMinCarat = lstProductCenterStone.StoneMinCarat
                    };
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
            return null;
        }

        public List<ProductCenterStoneShapeModel> GetProductCenterStoneShapeList(long productId, int stoneCategoryId, CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<ProductCenterStoneShapeModel> lstProductCenterStoneModel = (from centerStoneShape in objEntity.ej_ProductCenterStoneShape
                                                                                 join centerStone in objEntity.ej_ProductCenterStone
                                                                                 on centerStoneShape.ProductCenterStoneId equals centerStone.ProductCenterStoneId
                                                                                 join stoneShape in objEntity.ej_StoneShape
                                                                                 on centerStoneShape.StoneShapeId equals stoneShape.StoneShapeId
                                                                                 join shape in objEntity.ej_StoneShapeMaster
                                                                                 on stoneShape.ShapeId equals shape.ShapeId
                                                                                 where centerStone.ProductId == productId && centerStone.StoneCategoryId == stoneCategoryId
                                                                                 && centerStone.Status == true && stoneShape.Status == true &&
                                                                                 shape.Status == true
                                                                                 select new ProductCenterStoneShapeModel()
                                                                                 {
                                                                                     ProductCenterStoneId = centerStoneShape.ProductCenterStoneId,
                                                                                     ProductCenterStoneShapeId = centerStoneShape.ProductCenterStoneShapeId,
                                                                                     Status = centerStoneShape.Status,
                                                                                     StoneShape = shape.Shape,
                                                                                     StoneShapeId = stoneShape.StoneShapeId,
                                                                                     DefaultShape = centerStoneShape.DefaultShape,
                                                                                     StoneId = centerStoneShape.StoneId
                                                                                 }).ToList();
                if (lstProductCenterStoneModel != null)
                {
                    if (rStatus == CommonModel.RecordStatus.Enabled)
                    {
                        lstProductCenterStoneModel = lstProductCenterStoneModel.Where(tbl => tbl.Status == true).ToList();
                    }
                    return lstProductCenterStoneModel;
                }
                return lstProductCenterStoneModel;
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

        public List<StoneShapeModel> GetProductCenterStoneStoneShapeList(long productId, int stoneCategoryId,StoneShapeModel.ShapeVisibility visibility, CommonModel.RecordStatus rStatus)
        {
            List<StoneShapeModel> lstModel = null;
            try
            {
                List<ProductCenterStoneShapeModel> lstProductCenterStoneStoneShape = this.GetProductCenterStoneShapeList(productId, stoneCategoryId, rStatus);
                if (lstProductCenterStoneStoneShape != null)
                {
                    List<ej_StoneShape> lstEntityObject = (from productShape in lstProductCenterStoneStoneShape
                                                           join stoneShape in objEntity.ej_StoneShape
                                                           on productShape.StoneShapeId equals stoneShape.StoneShapeId
                                                           where stoneShape.Status == true
                                                           select stoneShape).ToList();
                    lstModel = new StoneShapeDAL().StoneShapeList(lstEntityObject, visibility);
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
            return lstModel;
        }

        public CenterStoneModel GetProductCenterStoneDefaultShape(long productId, int stoneCategoryId)
        {
            try
            {
                ProductCenterStoneShapeModel productCenterStoneShape = this.GetProductCenterStoneShapeList(productId, stoneCategoryId, CommonModel.RecordStatus.Enabled).Where(tbl => tbl.StoneId > 0).FirstOrDefault();
                if (productCenterStoneShape != null)
                {
                    return new CenterStoneDAL().GetCenterStoneList(productCenterStoneShape.StoneId, CenterStoneModel.CenterStoneProvider.FascinatingDiamonds, CommonModel.RecordStatus.Enabled).FirstOrDefault();
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
            return null;
        }
    }
}
