using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Common;
//
namespace EJewel.DAL.Admin.Master.Stone
{
    /// <summary>
    /// This DAL used for store the side stone information
    /// Partha Ranjan
    /// @ 01-04-13
    /// </summary>
    public class SideStoneDAL
    {
        EJewelEntities objEntity = new EJewelEntities();

        public SideStoneModel SaveUpdateSideStone(SideStoneModel model)
        {
            try
            {
                if (model.SideStoneId == 0)
                {
                    //for save mode
                    ej_SideStone sideStone = new ej_SideStone()
                    {
                        SideStoneId = model.SideStoneId,
                        Status = model.Status,
                        StoneCarate = model.StoneCarate,
                        StoneCategoryId = model.StoneCategoryId,
                        StoneClarityId = model.StoneClarityId,
                        StoneColorId = model.StoneColorId,
                        StoneCutId = model.StoneCutId,
                        StonePrice = model.StonePrice,
                        StoneShapeId = model.StoneShapeId,
                        StoneTypeId = model.StoneTypeId
                    };
                    objEntity.AddToej_SideStone(sideStone);
                    objEntity.SaveChanges();
                    model.SideStoneId = sideStone.SideStoneId;
                }
                else
                {
                    //for update
                    ej_SideStone sideStone = objEntity.ej_SideStone.Where(tbl => tbl.SideStoneId == model.SideStoneId).FirstOrDefault();
                    if (sideStone != null)
                    {
                        //update the details of the side stone
                        sideStone.Status = model.Status;
                        sideStone.StoneCarate = model.StoneCarate;
                        sideStone.StoneCategoryId = model.StoneCategoryId;
                        sideStone.StoneClarityId = model.StoneClarityId;
                        sideStone.StoneColorId = model.StoneColorId;
                        sideStone.StoneCutId = model.StoneCutId;
                        sideStone.StonePrice = model.StonePrice;
                        sideStone.StoneShapeId = model.StoneShapeId;
                        sideStone.StoneTypeId = model.StoneTypeId;
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

        public List<SideStoneModel> GetSideStoneList(long sideStoneId, CommonModel.RecordStatus rStatus)
        {
            try
            {
                //sideStoneId = 3;
                List<ej_SideStone> lstSideStone = null;
                if (sideStoneId > 0)
                {
                    //for indivisual
                    lstSideStone = objEntity.ej_SideStone.Where(tbl => tbl.SideStoneId == sideStoneId).ToList();
                }
                else
                {
                    //for all
                    lstSideStone = objEntity.ej_SideStone.Select(tbl => tbl).ToList();
                }
                //for status
                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstSideStone = lstSideStone.Where(tbl => tbl.Status == true).ToList();
                }
                if (lstSideStone != null)
                {
                    //get  the data of the list
                    return this.GetSideStoneList(lstSideStone);
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

        public List<SideStoneModel> GetSideStoneListFromCategory(int stoneCategoryId, CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<ej_SideStone> lstSideStone = null;
                //get stone category
                lstSideStone = objEntity.ej_SideStone.Where(tbl => tbl.StoneCategoryId == stoneCategoryId).ToList();
                //for status
                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstSideStone = lstSideStone.Where(tbl => tbl.Status == true).ToList();
                }
                return this.GetSideStoneList(lstSideStone);

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

        public List<SideStoneModel> GetSideStoneListForProductCreationFillter(int stoneCategoryId, double minCart, double maxCart, int[] stoneShapes, CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<ej_SideStone> lstSideStone = null;
                //get stone category
                lstSideStone = objEntity.ej_SideStone.Where(tbl => tbl.StoneCategoryId == stoneCategoryId && stoneShapes.Contains(tbl.StoneShapeId) && tbl.StoneCarate >= minCart && tbl.StoneCarate <= maxCart).ToList();
                //for status
                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstSideStone = lstSideStone.Where(tbl => tbl.Status == true).ToList();
                }
                return this.GetSideStoneList(lstSideStone);
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

       public List<SideStoneModel> GetSideStoneList(List<ej_SideStone> lstSideStone)
        {
            List<SideStoneModel> lstSideStoneModel = new List<SideStoneModel>();
            try
            {
                if (lstSideStone != null)
                {
                    lstSideStoneModel = (from sideStone in lstSideStone
                                         join stone_Category in objEntity.ej_StoneCategory
                                         on sideStone.StoneCategoryId equals stone_Category.StoneCategoryId
                                         join stoneClarity in objEntity.ej_StoneClarity on sideStone.StoneClarityId equals stoneClarity.StoneClarityId
                                         join stoneShape in objEntity.ej_StoneShape on sideStone.StoneShapeId equals stoneShape.StoneShapeId
                                         join shape in objEntity.ej_StoneShapeMaster on stoneShape.ShapeId equals shape.ShapeId
                                         join stoneCut in objEntity.ej_StoneCut on sideStone.StoneCutId equals stoneCut.StoneCutId
                                         join stoneColor in objEntity.ej_StoneColor on sideStone.StoneColorId equals stoneColor.StoneColorId
                                         join stoneType in objEntity.ej_StoneType on sideStone.StoneTypeId equals stoneType.StoneTypeId into group_Stone_Type
                                         from g_stone_Type in group_Stone_Type.DefaultIfEmpty()
                                         where stone_Category.Status == true && stoneClarity.Status == true && stoneShape.Status == true
                                         && shape.Status == true && stoneCut.Status == true && stoneColor.Status == true
                                         // && g_stone_Type.Status==true
                                         select new SideStoneModel()
                                         {
                                             SideStoneId = sideStone.SideStoneId,
                                             StoneCategoryId = sideStone.StoneCategoryId,
                                             Status = sideStone.Status,
                                             StoneCarate = sideStone.StoneCarate,
                                             StoneCategory = stone_Category.StoneCategoryName,
                                             StoneClarity = stoneClarity.StoneClarityName,
                                             StoneClarityId = stoneClarity.StoneClarityId,
                                             StoneColor = stoneColor.StoneColorName,
                                             StoneColorId = stoneColor.StoneColorId,
                                             StoneCut = stoneCut.StoneCutName,
                                             StoneCutId = stoneCut.StoneCutId,
                                             StonePrice = sideStone.StonePrice,
                                             StoneShape = shape.Shape,
                                             StoneShapeId = stoneShape.StoneShapeId,
                                             StoneType = g_stone_Type == null ? "" : g_stone_Type.StoneTypeName,
                                             StoneTypeId = sideStone.StoneTypeId
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
            return lstSideStoneModel.OrderByDescending(tbl=>tbl.SideStoneId).ToList();
        }
        /* sumit jha
         * 2-03-2013
         * */
       public bool DeleteSideStone(int sidestoneid)
       {
           try
           {
               ej_SideStone objStone = objEntity.ej_SideStone.Where(st => st.SideStoneId == sidestoneid).FirstOrDefault();
               if (objStone != null)
               {
                   objEntity.DeleteObject(objStone);
                   objEntity.SaveChanges();
               }
               return true;
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

       //partha @ 06-05-13
       public List<SideStoneModel> GetSideStoneTypeForProductCreation(int stoneCategoryId, int stoneShapeid, double carat)
       {
           try
           {

               List<ej_SideStone> lstEntityObject = objEntity.ej_SideStone.Where(tbl => tbl.StoneCategoryId == stoneCategoryId && tbl.StoneShapeId == stoneShapeid && tbl.StoneCarate == carat && tbl.Status == true).ToList();
               return this.GetSideStoneList(lstEntityObject);
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
