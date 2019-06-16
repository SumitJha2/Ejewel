using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Stone;

namespace EJewel.DAL.Admin.Master.Stone
{
    public class CenterStoneImageDAL
    {
        EJewelEntities objEntity = new EJewelEntities();
        public CenterStoneImageModel SaveUpdateCenterStoneImage(CenterStoneImageModel model)
        {
            try
            {
                if (model.CenterstoneImageID > 0)
                {
                    ej_CenterStoneImage objImage = objEntity.ej_CenterStoneImage.Where(tbl => tbl.CenterstoneImageID == model.CenterstoneImageID).FirstOrDefault();
                    objImage.ImagePath = model.ImagePath;
                    objImage.CenterStoneId = model.CenterstoneID;
                    objEntity.SaveChanges();
                }
                else
                {
                    ej_CenterStoneImage objImage = new ej_CenterStoneImage()
                    {
                        CenterStoneId = model.CenterstoneID,
                        ImagePath = model.ImagePath
                    };
                    objEntity.AddToej_CenterStoneImage(objImage);
                    objEntity.SaveChanges();
                    model.CenterstoneImageID = objImage.CenterstoneImageID;
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

        public List<CenterStoneImageModel> GetImageByCenterStoneID(long centerstoneId)
        {
            List<CenterStoneImageModel> lstImageModel = new List<CenterStoneImageModel>();
            try
            {
                lstImageModel = (from centerstone in objEntity.ej_CenterStoneImage
                                 where centerstone.CenterStoneId == centerstoneId
                                 select new CenterStoneImageModel
                                 {
                                     CenterstoneImageID = centerstone.CenterstoneImageID,
                                     CenterstoneID = centerstone.CenterStoneId,
                                     ImagePath = centerstone.ImagePath
                                 }).ToList();
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
            return lstImageModel;
        }

        public List<CenterStoneImageModel> GetImageByCenterStoneImageID(long imageId)
        {
            List<CenterStoneImageModel> lstImageModel = new List<CenterStoneImageModel>();
            try
            {
                lstImageModel = (from centerstone in objEntity.ej_CenterStoneImage
                                 where centerstone.CenterstoneImageID == imageId
                                 select new CenterStoneImageModel
                                 {
                                     CenterstoneImageID = centerstone.CenterstoneImageID,
                                     CenterstoneID = centerstone.CenterStoneId,
                                     ImagePath = centerstone.ImagePath
                                 }).ToList();
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
            return lstImageModel;
        }

        public bool DeleteCenterStoneImage(long centerstoneImageId)
        {
            bool flag = false;
            try
            {
                ej_CenterStoneImage objImage = objEntity.ej_CenterStoneImage.Where(tbl => tbl.CenterstoneImageID == centerstoneImageId).FirstOrDefault();
                if (objImage != null)
                {
                    objEntity.DeleteObject(objImage);
                    objEntity.SaveChanges();
                    flag = true;
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
            return flag;
        }

    }
}
