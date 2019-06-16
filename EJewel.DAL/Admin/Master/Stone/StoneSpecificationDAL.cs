using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//mode
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Common;

namespace EJewel.DAL.Admin.Master.Stone
{
    /*
     * Partha Ranjan
     * @ 09-02-13
     * This class for stone specification dal
     * */
    public class StoneSpecificationDAL
    {
        EJewelEntities objEntity = new EJewelEntities();
        
        public StoneSpecificationModel SaveUpdateStoneSpecification(StoneSpecificationModel model,StoneSpecificationModel.PageName pName)
        {
            try
            {
                switch (pName)
                {
                    case StoneSpecificationModel.PageName.Clarity:
                        {
                            #region Clarity
                            if (model.AutoID == 0)
                            {
                                //for save
                                ej_StoneClarity obj = new ej_StoneClarity()
                                {
                                    Status = model.Status,
                                    StoneCategoryId = model.StoneCategoryId,
                                    StoneClarityId = model.AutoID,
                                    StoneClarityName = model.Name,
                                    ShortDescription = model.ShortDescription
                                };
                                if (obj != null)
                                {
                                    objEntity.AddToej_StoneClarity(obj);
                                    objEntity.SaveChanges();
                                    model.AutoID = obj.StoneClarityId;
                                }
                            }
                            else
                            {
                                //for update
                                //get the value from id
                                ej_StoneClarity obj = objEntity.ej_StoneClarity.Where(tbl => tbl.StoneClarityId == model.AutoID).FirstOrDefault();
                                if (obj != null)
                                {
                                    //check that the samne name is present
                                    if (!this.IsExist(model.StoneCategoryId, model.Name, StoneSpecificationModel.PageName.Clarity))
                                    {
                                        obj.StoneClarityName = model.Name;
                                    }
                                    obj.StoneCategoryId = model.StoneCategoryId;
                                    obj.Status = model.Status;
                                    obj.ShortDescription = model.ShortDescription;
                                    objEntity.SaveChanges();
                                }
                            }
                            #endregion
                        }
                        break;
                    case StoneSpecificationModel.PageName.Cut:
                        {
                            #region  Cut
                            if (model.AutoID == 0)
                            {
                                //for save
                                ej_StoneCut obj = new ej_StoneCut()
                                {
                                    Status = model.Status,
                                    StoneCategoryId = model.StoneCategoryId,
                                    StoneCutId = model.AutoID,
                                    StoneCutName = model.Name,
                                    ShortDescription = model.ShortDescription
                                };
                                if (obj != null)
                                {
                                    objEntity.AddToej_StoneCut(obj);
                                    objEntity.SaveChanges();
                                    model.AutoID = obj.StoneCutId;
                                }
                            }
                            else
                            {
                                //for update
                                //get the value from id
                                ej_StoneCut obj = objEntity.ej_StoneCut.Where(tbl => tbl.StoneCutId == model.AutoID).FirstOrDefault();
                                if (obj != null)
                                {
                                    //check that the samne name is present
                                    if (!this.IsExist(model.StoneCategoryId, model.Name, StoneSpecificationModel.PageName.Cut))
                                    {
                                        obj.StoneCutName = model.Name;
                                    }
                                    obj.StoneCategoryId = model.StoneCategoryId;
                                    obj.Status = model.Status;
                                    obj.ShortDescription = model.ShortDescription;
                                    objEntity.SaveChanges();
                                }
                            }
                            #endregion
                        }
                        break;
                    case StoneSpecificationModel.PageName.Color:
                        {
                            #region Color
                            if (model.AutoID == 0)
                            {
                                //for save
                                ej_StoneColor obj = new ej_StoneColor()
                                {
                                    Status = model.Status,
                                    StoneCategoryId = model.StoneCategoryId,
                                    StoneColorId = model.AutoID,
                                    StoneColorName = model.Name,
                                    ShortDescription = model.ShortDescription
                                };
                                if (obj != null)
                                {
                                    objEntity.AddToej_StoneColor(obj);
                                    objEntity.SaveChanges();
                                    model.AutoID = obj.StoneColorId;
                                }
                            }
                            else
                            {
                                //for update
                                //get the value from id
                                ej_StoneColor obj = objEntity.ej_StoneColor.Where(tbl => tbl.StoneColorId == model.AutoID).FirstOrDefault();
                                if (obj != null)
                                {
                                    //check that the samne name is present
                                    if (!this.IsExist(model.StoneCategoryId, model.Name, StoneSpecificationModel.PageName.Color))
                                    {
                                        obj.StoneColorName = model.Name;
                                    }
                                    obj.StoneCategoryId = model.StoneCategoryId;
                                    obj.Status = model.Status;
                                    obj.ShortDescription = model.ShortDescription;
                                    objEntity.SaveChanges();
                                }
                            }
                            #endregion
                        }
                        break;
                    case StoneSpecificationModel.PageName.Type:
                        {
                            #region Type
                            if (model.AutoID == 0)
                            {
                                //for save
                                ej_StoneType obj = new ej_StoneType()
                                {
                                    Status = model.Status,
                                    StoneCategoryId = model.StoneCategoryId,
                                    StoneTypeId = model.AutoID,
                                    StoneTypeName = model.Name,
                                    ShortDescription = model.ShortDescription
                                };
                                if (obj != null)
                                {
                                    objEntity.AddToej_StoneType(obj);
                                    objEntity.SaveChanges();
                                    model.AutoID = obj.StoneTypeId;
                                }
                            }
                            else
                            {
                                //for update
                                //get the value from id
                                ej_StoneType obj = objEntity.ej_StoneType.Where(tbl => tbl.StoneTypeId == model.AutoID).FirstOrDefault();
                                if (obj != null)
                                {
                                    //check that the samne name is present
                                    if (!this.IsExist(model.StoneCategoryId, model.Name, StoneSpecificationModel.PageName.Type))
                                    {
                                        obj.StoneTypeName = model.Name;
                                    }
                                    obj.StoneCategoryId = model.StoneCategoryId;
                                    obj.Status = model.Status;
                                    obj.ShortDescription = model.ShortDescription;
                                    objEntity.SaveChanges();
                                }
                            }
                            #endregion
                        }
                        break;
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

        public bool IsExist(int categoryID,string name, StoneSpecificationModel.PageName pName)
        {
            bool result = false;
            try
            {
                switch (pName)
                {
                    case StoneSpecificationModel.PageName.Clarity:
                        {
                            result = objEntity.ej_StoneColor.Where(tbl => tbl.StoneColorName == name && tbl.StoneCategoryId == categoryID).Any();
                        }
                        break;
                    case StoneSpecificationModel.PageName.Cut:
                        {
                            result = objEntity.ej_StoneCut.Where(tbl => tbl.StoneCutName == name && tbl.StoneCategoryId == categoryID).Any();
                        }
                        break;
                    case StoneSpecificationModel.PageName.Color:
                        {
                            result = objEntity.ej_StoneColor.Where(tbl => tbl.StoneColorName == name && tbl.StoneCategoryId == categoryID).Any();
                        }
                        break;
                    case StoneSpecificationModel.PageName.Type:
                        {
                            result = objEntity.ej_StoneType.Where(tbl => tbl.StoneTypeName == name && tbl.StoneCategoryId == categoryID).Any();
                        }
                        break;
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
            return result;
        }

        public int TotalRecord(StoneSpecificationModel.PageName pName)
        {
            
            int total_record = 0;
            try
            {
                switch (pName)
                {
                    case StoneSpecificationModel.PageName.Clarity:
                        {
                            total_record = objEntity.ej_StoneClarity.Select(tbl => tbl).Count();
                        }
                        break;
                    case StoneSpecificationModel.PageName.Color:
                        {
                            total_record = objEntity.ej_StoneColor.Select(tbl => tbl).Count();
                        }
                        break;
                    case StoneSpecificationModel.PageName.Cut:
                        {
                            total_record = objEntity.ej_StoneCut.Select(tbl => tbl).Count();
                        }
                        break;
                    case StoneSpecificationModel.PageName.Type:
                        {
                            total_record = objEntity.ej_StoneType.Select(tbl => tbl).Count();
                        }
                        break;
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
            return total_record;
        }

        public List<StoneSpecificationModel> GetStoneSpecificationList(int id, StoneSpecificationModel.PageName pName, CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<StoneSpecificationModel> lstModel = null;
                switch (pName)
                {
                    case StoneSpecificationModel.PageName.Clarity:
                        {
                            #region For Clarity
                            List<ej_StoneClarity> lstClarity = null;
                            if (id > 0)
                            {
                                lstClarity = objEntity.ej_StoneClarity.Where(tbl => tbl.StoneClarityId == id).ToList();
                            }
                            else
                            {
                                lstClarity = objEntity.ej_StoneClarity.Select(tbl => tbl).ToList();
                            }
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstClarity = lstClarity.Where(tbl => tbl.Status == true).ToList();
                            }
                            //now do iteratioin
                            if (lstClarity != null)
                            {
                                lstModel = (from clarity in lstClarity
                                            join stoneCategory in objEntity.ej_StoneCategory
                                            on clarity.StoneCategoryId equals stoneCategory.StoneCategoryId
                                            where stoneCategory.Status == true
                                            select new StoneSpecificationModel()
                                            {
                                                AutoID = clarity.StoneClarityId,
                                                Name = clarity.StoneClarityName,
                                                Status = clarity.Status,
                                                StoneCategory = stoneCategory.StoneCategoryName,
                                                StoneCategoryId = clarity.StoneCategoryId,
                                                ShortDescription = clarity.ShortDescription

                                            }).ToList();
                            }
                            #endregion

                        }
                        break;
                    case StoneSpecificationModel.PageName.Cut:
                        {
                            #region For Cut
                            List<ej_StoneCut> lstCut = null;
                            if (id > 0)
                            {
                                lstCut = objEntity.ej_StoneCut.Where(tbl => tbl.StoneCutId == id).ToList();
                            }
                            else
                            {
                                lstCut = objEntity.ej_StoneCut.Select(tbl => tbl).ToList();
                            }
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstCut = lstCut.Where(tbl => tbl.Status == true).ToList();
                            }

                            //now do iteratioin
                            if (lstCut != null)
                            {
                                lstModel = (from cut in lstCut
                                            join stoneCategory in objEntity.ej_StoneCategory
                                            on cut.StoneCategoryId equals stoneCategory.StoneCategoryId
                                            where stoneCategory.Status == true
                                            select new StoneSpecificationModel()
                                            {
                                                AutoID = cut.StoneCutId,
                                                Name = cut.StoneCutName,
                                                Status = cut.Status,
                                                StoneCategory = stoneCategory.StoneCategoryName,
                                                StoneCategoryId = cut.StoneCategoryId,
                                                ShortDescription = cut.ShortDescription

                                            }).ToList();
                            }
                            #endregion
                        }
                        break;
                    case StoneSpecificationModel.PageName.Color:
                        {
                            #region For COlor
                            List<ej_StoneColor> lstColor = null;
                            if (id > 0)
                            {
                                lstColor = objEntity.ej_StoneColor.Where(tbl => tbl.StoneColorId == id).ToList();
                            }
                            else
                            {
                                lstColor = objEntity.ej_StoneColor.Select(tbl => tbl).ToList();
                            }
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstColor = lstColor.Where(tbl => tbl.Status == true).ToList();
                            }
                            //now do iteratioin
                            if (lstColor != null)
                            {
                                lstModel = (from color in lstColor
                                            join stoneCategory in objEntity.ej_StoneCategory
                                            on color.StoneCategoryId equals stoneCategory.StoneCategoryId
                                            where stoneCategory.Status == true
                                            select new StoneSpecificationModel()
                                            {
                                                AutoID = color.StoneColorId,
                                                Name = color.StoneColorName,
                                                Status = color.Status,
                                                StoneCategory = stoneCategory.StoneCategoryName,
                                                StoneCategoryId = color.StoneCategoryId,
                                                ShortDescription = color.ShortDescription

                                            }).ToList();
                            }
                            #endregion
                        }
                        break;
                    case StoneSpecificationModel.PageName.Type:
                        {
                            #region For Type
                            List<ej_StoneType> lstType = null;

                            if (id > 0)
                            {
                                lstType = objEntity.ej_StoneType.Where(tbl => tbl.StoneTypeId == id).ToList();
                            }
                            else
                            {
                                lstType = objEntity.ej_StoneType.Select(tbl => tbl).ToList();
                            }
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstType = lstType.Where(tbl => tbl.Status == true).ToList();
                            }
                            //now do iteratioin
                            if (lstType != null)
                            {
                                lstModel = (from type in lstType
                                            join stoneCategory in objEntity.ej_StoneCategory
                                            on type.StoneCategoryId equals stoneCategory.StoneCategoryId
                                            where stoneCategory.Status == true
                                            select new StoneSpecificationModel()
                                            {
                                                AutoID = type.StoneTypeId,
                                                Name = type.StoneTypeName,
                                                Status = type.Status,
                                                StoneCategory = stoneCategory.StoneCategoryName,
                                                StoneCategoryId = type.StoneCategoryId,
                                                ShortDescription = type.ShortDescription

                                            }).ToList();
                            }
                            #endregion
                        }
                        break;
                }
                return lstModel.OrderBy(tbl => tbl.Name).ToList();
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

        public List<StoneSpecificationModel> GetStoneSpecificationList(int id, StoneSpecificationModel.PageName pName, CommonModel.RecordStatus rStatus, int currentPageIndex, int perPageSize)
        {
            try
            {
                List<StoneSpecificationModel> lstStoneSpecfication = this.GetStoneSpecificationList(id, pName, rStatus);
                return lstStoneSpecfication.Skip(currentPageIndex * perPageSize).Take(perPageSize).ToList();
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

        public List<StoneSpecificationModel> GetStoneSpecificationListFromCategory(int categoryID, StoneSpecificationModel.PageName pName, CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<StoneSpecificationModel> lstModel = null;
                switch (pName)
                {
                    case StoneSpecificationModel.PageName.Clarity:
                        {
                            #region For Clarity
                            List<ej_StoneClarity> lstClarity = null;
                            lstClarity = objEntity.ej_StoneClarity.Where(tbl => tbl.StoneCategoryId == categoryID).ToList();
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstClarity = lstClarity.Where(tbl => tbl.Status == true).ToList();
                            }
                            //now do iteratioin
                            if (lstClarity != null)
                            {
                                lstModel = (from clarity in lstClarity
                                            join stoneCategory in objEntity.ej_StoneCategory
                                            on clarity.StoneCategoryId equals stoneCategory.StoneCategoryId
                                            where stoneCategory.Status == true
                                            select new StoneSpecificationModel()
                                            {
                                                AutoID = clarity.StoneClarityId,
                                                Name = clarity.StoneClarityName,
                                                Status = clarity.Status,
                                                StoneCategory = stoneCategory.StoneCategoryName,
                                                StoneCategoryId = clarity.StoneCategoryId,
                                                ShortDescription = clarity.ShortDescription

                                            }).ToList();
                            }
                            #endregion

                        }
                        break;
                    case StoneSpecificationModel.PageName.Cut:
                        {
                            #region For Cut
                            List<ej_StoneCut> lstCut = null;
                            lstCut = objEntity.ej_StoneCut.Where(tbl => tbl.StoneCategoryId == categoryID).ToList();
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstCut = lstCut.Where(tbl => tbl.Status == true).ToList();
                            }
                            //now do iteratioin
                            if (lstCut != null)
                            {
                                lstModel = (from cut in lstCut
                                            join stoneCategory in objEntity.ej_StoneCategory
                                            on cut.StoneCategoryId equals stoneCategory.StoneCategoryId
                                            where stoneCategory.Status == true
                                            select new StoneSpecificationModel()
                                            {
                                                AutoID = cut.StoneCutId,
                                                Name = cut.StoneCutName,
                                                Status = cut.Status,
                                                StoneCategory = stoneCategory.StoneCategoryName,
                                                StoneCategoryId = cut.StoneCategoryId,
                                                ShortDescription = cut.ShortDescription

                                            }).ToList();
                            }
                            #endregion
                        }
                        break;
                    case StoneSpecificationModel.PageName.Color:
                        {
                            #region For COlor
                            List<ej_StoneColor> lstColor = null;
                            lstColor = objEntity.ej_StoneColor.Where(tbl => tbl.StoneCategoryId == categoryID).ToList();
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstColor = lstColor.Where(tbl => tbl.Status == true).ToList();
                            }
                            //now do iteratioin
                            if (lstColor != null)
                            {
                                lstModel = (from color in lstColor
                                            join stoneCategory in objEntity.ej_StoneCategory
                                            on color.StoneCategoryId equals stoneCategory.StoneCategoryId
                                            where stoneCategory.Status == true
                                            select new StoneSpecificationModel()
                                            {
                                                AutoID = color.StoneColorId,
                                                Name = color.StoneColorName,
                                                Status = color.Status,
                                                StoneCategory = stoneCategory.StoneCategoryName,
                                                StoneCategoryId = color.StoneCategoryId,
                                                ShortDescription = color.ShortDescription

                                            }).ToList();
                            }
                            #endregion
                        }
                        break;
                    case StoneSpecificationModel.PageName.Type:
                        {
                            #region For Type
                            List<ej_StoneType> lstType = null;
                            lstType = objEntity.ej_StoneType.Where(tbl => tbl.StoneCategoryId == categoryID).ToList();
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstType = lstType.Where(tbl => tbl.Status == true).ToList();
                            }
                            //now do iteratioin
                            if (lstType != null)
                            {
                                lstModel = (from type in lstType
                                            join stoneCategory in objEntity.ej_StoneCategory
                                            on type.StoneCategoryId equals stoneCategory.StoneCategoryId
                                            where stoneCategory.Status == true
                                            select new StoneSpecificationModel()
                                            {
                                                AutoID = type.StoneTypeId,
                                                Name = type.StoneTypeName,
                                                Status = type.Status,
                                                StoneCategory = stoneCategory.StoneCategoryName,
                                                StoneCategoryId = type.StoneCategoryId,
                                                ShortDescription = type.ShortDescription

                                            }).ToList();
                            }
                            #endregion
                        }
                        break;
                }
                return lstModel.OrderBy(tbl => tbl.Name).ToList();
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

        /* sumit jha
         * @ 19-03-2013
         * */
        public bool DeleteStoneSpecification(int id, StoneSpecificationModel.PageName pName)
        {
            bool flag=false;

            try
            {
                switch (pName)
                {
                    case StoneSpecificationModel.PageName.Clarity:
                        {
                            ej_StoneClarity obj = objEntity.ej_StoneClarity.Where(tbl => tbl.StoneClarityId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }

                        }
                        break;
                    case StoneSpecificationModel.PageName.Color:
                        {
                            ej_StoneColor obj = objEntity.ej_StoneColor.Where(tbl => tbl.StoneColorId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case StoneSpecificationModel.PageName.Cut:
                        {
                            ej_StoneCut obj = objEntity.ej_StoneCut.Where(tbl => tbl.StoneCutId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case StoneSpecificationModel.PageName.Type:
                        {
                            ej_StoneType obj = objEntity.ej_StoneType.Where(tbl => tbl.StoneTypeId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;

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

        /* sumit jha
     * @03-04-2018  
     * */
        //stone shape for center stone
        public List<StoneSpecificationModel> GetStoneSpecificationListForCenterStone()
        {
            List<StoneSpecificationModel> stoneshapemodel_Sort = new List<StoneSpecificationModel>();
            try
            {
                List<StoneSpecificationModel> stoneshapemodel = (from lst in objEntity.ej_CenterStone
                                                                 join shape in objEntity.ej_StoneShape
                                                                 on lst.StoneShapeId equals shape.StoneShapeId
                                                                 where lst.Status == true && shape.Status == true
                                                                 select new StoneSpecificationModel
                                                                 {
                                                                     AutoID = shape.StoneShapeId,
                                                                     Name = ""
                                                                 }).OrderByDescending(tbl => tbl.AutoID).ToList();

                var model = stoneshapemodel.Select(tbl => tbl.Name).Distinct();
                foreach (string name in model)
                {
                    stoneshapemodel_Sort.Add(stoneshapemodel.Where(lst => lst.Name == name).FirstOrDefault());
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
            return stoneshapemodel_Sort;

         }
        //stone shape for center stone
        public List<StoneSpecificationModel> GetStoneSpecificationListForSideStone()
        {
            List<StoneSpecificationModel> stoneshapemodel_Sort = new List<StoneSpecificationModel>();
            try
            {
                List<StoneSpecificationModel> stoneshapemodel = (from lst in objEntity.ej_SideStone
                                                                 join shape in objEntity.ej_StoneShape
                                                                 on lst.StoneShapeId equals shape.StoneShapeId
                                                                 where lst.Status == true && shape.Status == true
                                                                 where lst.StoneCategoryId == 1
                                                                 select new StoneSpecificationModel
                                                                 {
                                                                     AutoID = shape.StoneShapeId,
                                                                     Name = ""
                                                                 }).OrderByDescending(tbl => tbl.AutoID).ToList();

                var model = stoneshapemodel.Select(tbl => tbl.Name).Distinct();
                foreach (string name in model)
                {
                    stoneshapemodel_Sort.Add(stoneshapemodel.Where(lst => lst.Name == name).FirstOrDefault());
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
            return stoneshapemodel_Sort;

        }

    }
}
