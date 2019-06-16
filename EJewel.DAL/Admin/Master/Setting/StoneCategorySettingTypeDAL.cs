using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Master.Setting;
using EJewel.Model.Admin.Common;
//
namespace EJewel.DAL.Admin.Master.Setting
{
    /// <summary>
    /// Sumit Jha @ 08-03-13,
    /// Manage the Stone Category Setting Type
    /// </summary>
    public class StoneCategorySettingTypeDAL
    {
        EJewelEntities objEntity = new EJewelEntities();

        /// <summary>
        /// Save and updat ethe stone category setting type
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public StoneCategorySettingTypeModel SaveUpdateStoneCategorySettingType(StoneCategorySettingTypeModel model)
        {
            try
            {
                if (model.StoneCategorySettingTypeId > 0)
                {
                    //get the stone category setting type
                    ej_StoneCategorySettingType objSettingType = objEntity.ej_StoneCategorySettingType.Where(tbl => tbl.StoneCategorySettingTypeId == model.StoneCategorySettingTypeId).FirstOrDefault();
                    if (objSettingType != null)
                    {
                        if (!this.IsExist(model.StoneCategoryTypeId, model.StoneCategorySettingTypeId))
                        {
                            objSettingType.StoneCategoryTypeId = model.StoneCategoryTypeId;
                            objSettingType.SettingTypeId = model.SettingTypeId;
                        }
                        objSettingType.Price = model.Price;
                        objSettingType.Status = model.Status;
                        objEntity.SaveChanges();
                    }
                }
                else
                {
                    ej_StoneCategorySettingType objSettingType = new ej_StoneCategorySettingType()
                    {
                        StoneCategorySettingTypeId = model.StoneCategorySettingTypeId,
                        SettingTypeId = model.SettingTypeId,
                        StoneCategoryTypeId = model.StoneCategoryTypeId,
                        Price = model.Price,
                        Status = model.Status
                    };
                    objEntity.AddToej_StoneCategorySettingType(objSettingType);
                    objEntity.SaveChanges();
                    model.StoneCategorySettingTypeId = objSettingType.StoneCategorySettingTypeId;
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

        /// <summary>
        /// Sumit Jha @ 08-03-13, Get Stone List
        /// </summary>
        /// <param name="stonecategorysettingtypeid"></param>
        /// <returns></returns>
        public List<StoneCategorySettingTypeModel> StoneSettingTypeList(int stoneCategorySettingTypeId, CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<ej_StoneCategorySettingType> lstStoneSettingType = null;
                if (stoneCategorySettingTypeId > 0)
                {
                    lstStoneSettingType = objEntity.ej_StoneCategorySettingType.Where(tbl => tbl.StoneCategorySettingTypeId == stoneCategorySettingTypeId).ToList();
                }
                else
                {
                    lstStoneSettingType = objEntity.ej_StoneCategorySettingType.Select(tbl => tbl).ToList();
                }
                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstStoneSettingType = lstStoneSettingType.Where(tbl => tbl.Status == true).ToList();
                }
                return this.StoneSettingTypeList(lstStoneSettingType);
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

        /// <summary>
        /// Get the Stone Setting Type From Stone Category Type
        /// </summary>
        /// <param name="stoneCategoryTypeId"></param>
        /// <param name="rStatus"></param>
        /// <returns></returns>
        public List<StoneCategorySettingTypeModel> StoneSettingTypeListFromStoneCategoryType(int stoneCategoryTypeId,CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<ej_StoneCategorySettingType> lstStoneSettingType = null;
                //get list
                lstStoneSettingType = objEntity.ej_StoneCategorySettingType.Where(tbl => tbl.StoneCategoryTypeId == stoneCategoryTypeId).ToList();
                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstStoneSettingType = lstStoneSettingType.Where(tbl => tbl.Status == true).ToList();

                }
                return this.StoneSettingTypeList(lstStoneSettingType);
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

        private List<StoneCategorySettingTypeModel> StoneSettingTypeList(List<ej_StoneCategorySettingType> lstStoneSettingType)
        {
            
            List<StoneCategorySettingTypeModel> lstStoneCategorySettingTypeModel = new List<StoneCategorySettingTypeModel>();
            try
            {
                if (lstStoneSettingType != null)
                {
                    lstStoneCategorySettingTypeModel = (from lst in lstStoneSettingType
                                                        join sctyp in objEntity.ej_StoneCategoryType
                                                        on lst.StoneCategoryTypeId equals sctyp.StoneCategoryTypeId
                                                        join styp in objEntity.ej_SettingType
                                                        on lst.SettingTypeId equals styp.SettingTypeId
                                                        where styp.Status == true && styp.Status == true
                                                        select new StoneCategorySettingTypeModel
                                                        {
                                                            StoneCategorySettingTypeId = lst.StoneCategorySettingTypeId,
                                                            StoneCategoryTypeId = lst.StoneCategoryTypeId,
                                                            SettingTypeId = lst.SettingTypeId,
                                                            StoneCategoryTypeName = sctyp.StoneCategoryTypeName,
                                                            SettingTypeName = styp.SettingTypeName,
                                                            Price = lst.Price,
                                                            Status = lst.Status
                                                        }).OrderBy(tbl => tbl.SettingTypeName).ToList();
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
            return lstStoneCategorySettingTypeModel;
        }

        /// <summary>
        /// Delete the stone setting type
        /// </summary>
        /// <param name="stonecategorysettingtypeid"></param>
        /// <returns></returns>
        public bool DeleteStoneSettingType(int stoneCategorySettingTypeId)
        {
            try
            {
                ej_StoneCategorySettingType objSettingType = objEntity.ej_StoneCategorySettingType.Where(tbl => tbl.StoneCategorySettingTypeId == stoneCategorySettingTypeId).FirstOrDefault();
                if (objSettingType != null)
                {
                    objEntity.DeleteObject(objSettingType);
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

        /// <summary>
        /// Check that the stone category setting is present or not
        /// </summary>
        /// <param name="stoneCategoryId"></param>
        /// <param name="stoneSettingTypeId"></param>
        /// <returns></returns>
        public bool IsExist(int stoneCategoryTypeId, int stoneSettingTypeId)
        {
            try
            {
                return objEntity.ej_StoneCategorySettingType.Where(tbl => tbl.StoneCategoryTypeId == stoneCategoryTypeId && tbl.SettingTypeId == stoneSettingTypeId).Any();
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

        public StoneCategorySettingTypeModel StoneSettingTypeFromCategorySettingType(int stoneCategoryTypeId, int settingTypeId, CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<ej_StoneCategorySettingType> lstStoneSettingType = null;
                //get list
                lstStoneSettingType = objEntity.ej_StoneCategorySettingType.Where(tbl => tbl.StoneCategoryTypeId == stoneCategoryTypeId && tbl.SettingTypeId == settingTypeId).ToList();
                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstStoneSettingType = lstStoneSettingType.Where(tbl => tbl.Status == true).ToList();
                }
                return this.StoneSettingTypeList(lstStoneSettingType).FirstOrDefault();
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
