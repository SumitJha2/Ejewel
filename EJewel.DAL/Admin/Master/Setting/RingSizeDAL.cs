using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Master.Setting;
using EJewel.Model.Admin.Common;

namespace EJewel.DAL.Admin.Master.Setting
{
    public class RingSizeDAL
    {
        EJewelEntities objEntity = new EJewelEntities();

        public RingSizeModel SaveUpdateRingSize(RingSizeModel model)
        {
            try
            {
                if (model.RingSizeId == 0)
                {
                    //save
                    if (!this.IsExist(model.SubCategoryId, model.RingSize))
                    {
                        ej_RingSize ringSize = new ej_RingSize()
                        {
                            RingSize = model.RingSize,
                            RingSizeId = model.RingSizeId,
                            Status = model.Status,
                            SubCategoryId = model.SubCategoryId
                        };
                        if (ringSize != null)
                        {
                            objEntity.AddToej_RingSize(ringSize);
                            objEntity.SaveChanges();
                            model.RingSizeId = ringSize.RingSizeId;
                        }
                    }
                }
                else
                {
                    //update
                    ej_RingSize ringSize = objEntity.ej_RingSize.Where(tbl => tbl.RingSizeId == model.RingSizeId).FirstOrDefault();
                    if (ringSize != null)
                    {
                        ringSize.RingSize = model.RingSize;
                        ringSize.Status = model.Status;
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

        public bool IsExist(int subcategoryId,double ringRize)
        {
            try
            {
                return objEntity.ej_RingSize.Where(tbl => tbl.SubCategoryId == subcategoryId && tbl.RingSize == ringRize).Any();
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

        public List<RingSizeModel> GetRingSizeList(int ringSizeId, CommonModel.RecordStatus rStatus)
        {
            List<RingSizeModel> lstRingSizeModel = new List<RingSizeModel>();
            try
            {
                List<ej_RingSize> lstRingSize = null;
                if (ringSizeId > 0)
                {
                    lstRingSize = objEntity.ej_RingSize.Where(tbl => tbl.RingSizeId == ringSizeId).ToList();
                }
                else
                {
                    lstRingSize = objEntity.ej_RingSize.Select(tbl => tbl).ToList();
                }
                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstRingSize = lstRingSize.Where(tbl => tbl.Status == true).ToList();
                }
                if (lstRingSize != null)
                {
                    lstRingSizeModel = (from ringSize in lstRingSize
                                        join subCategory in objEntity.ej_SubCategoryMaster
                                        on ringSize.SubCategoryId equals subCategory.SubCategoryId
                                        where subCategory.Status == true
                                        select new RingSizeModel()
                                        {
                                            RingSize = ringSize.RingSize,
                                            RingSizeId = ringSize.RingSizeId,
                                            Status = ringSize.Status,
                                            SubCategory = subCategory.SubCategoryName,
                                            SubCategoryId = subCategory.SubCategoryId
                                        }).OrderBy(tbl => tbl.RingSizeId).ToList();
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
            return lstRingSizeModel;
        }

        public bool DeleteRingSize(int ringsizeid)
        {
            bool flag = false;
            try
            {
                if (ringsizeid > 0)
                {
                    ej_RingSize objringsize = objEntity.ej_RingSize.Where(rs => rs.RingSizeId == ringsizeid).FirstOrDefault();
                    if (objringsize != null)
                    {
                        objEntity.DeleteObject(objringsize);
                        objEntity.SaveChanges();
                        flag = true;
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
            return flag;
        }
    }
}
