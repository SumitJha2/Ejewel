using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Master.Stone;

namespace EJewel.DAL.Admin.Master.Stone
{
    public class StoneShapeDAL
    {
        EJewelEntities objEntity = new EJewelEntities();

        public StoneShapeModel SaveUpdate(StoneShapeModel model)
        {
            try
            {
                if (model.StoneShapeId == 0)
                {                //for save
                    ej_StoneShape entityObject = new ej_StoneShape()
                    {
                        ShapeId = model.ShapeId,
                        Status = model.Status,
                        StoneCategoryId = model.StoneCategoryId,
                        StoneShapeId = model.StoneShapeId,
                        CenterStoneVisible = model.CenterStoneVisible,
                        SideStoneVisible = model.SideStoneVisible
                    };
                    objEntity.AddToej_StoneShape(entityObject);
                    objEntity.SaveChanges();
                    model.StoneShapeId = entityObject.StoneShapeId;
                }
                else
                {
                    //for update
                    ej_StoneShape entityObject = objEntity.ej_StoneShape.Where(tbl => tbl.StoneShapeId == model.StoneShapeId).FirstOrDefault();
                    if (entityObject != null)
                    {
                        entityObject.Status = model.Status;
                        entityObject.CenterStoneVisible = model.CenterStoneVisible;
                        entityObject.SideStoneVisible = model.SideStoneVisible;
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

        public List<StoneShapeModel> StoneShapeList(int stoneShapeId,StoneShapeModel.ShapeVisibility visibility, CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<ej_StoneShape> lstObj;
                if (stoneShapeId > 0)
                {
                    lstObj = objEntity.ej_StoneShape.Where(tbl => tbl.StoneShapeId == stoneShapeId).ToList();
                }
                else
                {
                    lstObj = objEntity.ej_StoneShape.Select(tbl => tbl).ToList();
                }
                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                }
                //check for the visibility
                return this.StoneShapeList(lstObj, visibility);
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

        public List<StoneShapeModel> StoneShapeListFromCategory(int stoneCategoryId,StoneShapeModel.ShapeVisibility visibility, CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<ej_StoneShape> lstObj;
                lstObj = objEntity.ej_StoneShape.Where(tbl => tbl.StoneCategoryId == stoneCategoryId).ToList();
                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                }
                return this.StoneShapeList(lstObj, visibility);
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

        public List<StoneShapeModel> StoneShapeList(List<ej_StoneShape> lstObj, StoneShapeModel.ShapeVisibility visibility)
        {
            List<StoneShapeModel> lstModel = new List<StoneShapeModel>();
            try
            {
                if (lstObj != null)
                {
                    switch (visibility)
                    {
                        case StoneShapeModel.ShapeVisibility.CENTERSTONE:
                            {
                                lstObj = lstObj.Where(tbl => tbl.CenterStoneVisible == true).ToList();
                            } break;
                        case StoneShapeModel.ShapeVisibility.SIDESTONE:
                            {
                                lstObj = lstObj.Where(tbl => tbl.SideStoneVisible == true).ToList();
                            } break;
                    }
                    lstModel = (from stoneShape in lstObj
                                join shape in objEntity.ej_StoneShapeMaster
                                on stoneShape.ShapeId equals shape.ShapeId
                                join stoneCategory in objEntity.ej_StoneCategory
                                on stoneShape.StoneCategoryId equals stoneCategory.StoneCategoryId
                                where shape.Status == true && stoneCategory.Status == true
                                select new StoneShapeModel()
                                {
                                    Shape = shape.Shape,
                                    ShapeId = shape.ShapeId,
                                    Status = stoneShape.Status,
                                    StoneCategoryId = stoneShape.StoneCategoryId,
                                    StoneCategoryName = stoneCategory.StoneCategoryName,
                                    StoneShapeId = stoneShape.StoneShapeId,
                                    CenterStoneVisible = stoneShape.CenterStoneVisible,
                                    SideStoneVisible = stoneShape.SideStoneVisible,
                                    //added by sumit on 05-06-2013
                                    ShortDescription = shape.ShortDescription,
                                    LongDescription = shape.LongDescription

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

        public bool IsExist(int stoneCategoryId, int shapeId)
        {
            try
            {
                return objEntity.ej_StoneShape.Where(tbl => tbl.StoneCategoryId == stoneCategoryId && tbl.ShapeId == shapeId).Any();
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
            return false;
        }

        public bool Delete(int stoneShapeId)
        {
            try
            {
                ej_StoneShape entity = objEntity.ej_StoneShape.Where(tbl => tbl.StoneShapeId == stoneShapeId).FirstOrDefault();
                if (entity != null)
                {
                    objEntity.DeleteObject(entity);
                    objEntity.SaveChanges();
                    return true;
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
            return false;
        }

        public List<StoneSpecificationModel> GetStoneShapeFromMaster(int shapeId, CommonModel.RecordStatus rStatus)
        {
            List<ej_StoneShapeMaster> objStoneShape = new List<ej_StoneShapeMaster>();
            List<StoneSpecificationModel> lstStoneSpecification = new List<StoneSpecificationModel>();
            try
            {
                if (shapeId > 0)
                {
                    objStoneShape = objEntity.ej_StoneShapeMaster.Where(tbl => tbl.ShapeId == shapeId).ToList();
                }
                else
                {
                    objStoneShape = objEntity.ej_StoneShapeMaster.Select(tbl => tbl).ToList();
                }
                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    objStoneShape = objStoneShape.Where(tbl => tbl.Status == true).ToList();
                }
                lstStoneSpecification = (from obj in objStoneShape
                                         select new StoneSpecificationModel
                                         {
                                             AutoID = obj.ShapeId,
                                             Name = obj.Shape,
                                             Status = obj.Status
                                         }).OrderBy(tbl => tbl.Name).ToList();
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

            return lstStoneSpecification;

        }
    }
}
