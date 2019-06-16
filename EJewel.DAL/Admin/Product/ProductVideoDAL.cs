using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Product;
namespace EJewel.DAL.Admin.Product
{
    public class ProductVideoDAL
    {
        EJewelEntities objEntity = new EJewelEntities();

        public ProductVideoModel SaveUpdate(ProductVideoModel model)
        {
            try
            {
                if (!objEntity.ej_ProductVideo.Where(tbl => tbl.ProductId == model.ProductId && tbl.CenterStoneShapeId == model.CenterStoneShapeId).Any())
                {
                    //for save
                    ej_ProductVideo obj = new ej_ProductVideo()
                    {
                        CenterStoneShapeId = model.CenterStoneShapeId,
                        ProductId = model.ProductId,
                        ProductVideoId = model.ProductVideoId,
                        Status = model.Status,
                        VideoPathURL = model.VideoPathURL,
                        VideoPhotoURL = model.VideoPhotoURL
                    };
                    objEntity.AddToej_ProductVideo(obj);
                    objEntity.SaveChanges();
                    model.ProductVideoId = obj.ProductVideoId;
                }
                else
                {
                    //for update
                    ej_ProductVideo obj = objEntity.ej_ProductVideo.Where(tbl => tbl.ProductId == model.ProductId && tbl.CenterStoneShapeId == model.CenterStoneShapeId).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.CenterStoneShapeId = model.CenterStoneShapeId;
                        obj.ProductId = model.ProductId;
                        obj.Status = model.Status;
                        obj.VideoPathURL = model.VideoPathURL;
                        obj.VideoPhotoURL = model.VideoPhotoURL;
                        objEntity.SaveChanges();
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

        private List<ProductVideoModel> ProductVideo(List<ej_ProductVideo> lstObj)
        {
            List<ProductVideoModel> lstModel = new List<ProductVideoModel>();
            try
            {
                if (lstObj != null)
                {
                    lstModel = (from video in lstObj
                                select new ProductVideoModel()
                                {
                                    CenterStoneShapeId = video.CenterStoneShapeId,
                                    ProductId = video.ProductId,
                                    ProductVideoId = video.ProductVideoId,
                                    Status = video.Status,
                                    VideoPathURL = video.VideoPathURL,
                                    VideoPhotoURL = video.VideoPhotoURL
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
            return lstModel;
        }

        public List<ProductVideoModel> ProductVideo(long productId, CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<ej_ProductVideo> lstObj = null;
                if (productId > 0)
                {
                    lstObj = objEntity.ej_ProductVideo.Where(tbl => tbl.ProductId == productId).ToList();
                }
                else
                {
                    lstObj = objEntity.ej_ProductVideo.Select(tbl => tbl).ToList();
                }
                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    if (lstObj != null)
                    {
                        lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                    }
                }
                return this.ProductVideo(lstObj);
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

        public ProductVideoModel ProductVideo(long productId, int centerShapeId, CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<ej_ProductVideo> lstObj = objEntity.ej_ProductVideo.Where(tbl => tbl.ProductId == productId && tbl.CenterStoneShapeId == centerShapeId).ToList();
                return this.ProductVideo(lstObj).FirstOrDefault();
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
