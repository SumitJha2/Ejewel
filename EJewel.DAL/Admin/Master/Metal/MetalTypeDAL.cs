using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Metal;
using EJewel.Model.Admin.Common;
namespace EJewel.DAL.Admin.Master.Metal
{
    public class MetalTypeDAL
    {
        /*
         * Partha Ranjan
         * @ 02-01-13
         * This class is used to manipulate the metal type
         * */
        EJewelEntities objEntity = new EJewelEntities();

        /*
         * Partha Ranjan
         * @ 02-01-13
         * This function helps to save or updat the data
         * */
        public MetalTypeModel SaveUpdateMetalType(MetalTypeModel model)
        {
            try
            {
                if (model.MetalTypeId == 0)
                {
                    //for save
                    ej_MetalTypeMaster obj = this.Mapping(model);
                    objEntity.AddToej_MetalTypeMaster(obj);
                    objEntity.SaveChanges();
                    model.MetalTypeId = obj.MetaTypeId;
                }
                else
                {
                    //for update
                    ej_MetalTypeMaster obj = objEntity.ej_MetalTypeMaster.Where(mt => mt.MetaTypeId == model.MetalTypeId).FirstOrDefault();
                    if (obj != null)
                    {
                        //sumit on  19-03-2013
                        if (!IsExist(model.MetalWeightId, model.MetalNameId))
                        {
                            obj.MetalNameId = model.MetalNameId;
                            obj.MetalWeightId = model.MetalWeightId;
                        }
                        //------------------------------------------
                        obj.Price = model.Price;
                        obj.Status = model.Status;
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

        /*
        * Partha Ranjan
        * @ 02-01-13
        * This function helps to mapp the data
        * */
        public ej_MetalTypeMaster Mapping(MetalTypeModel model)
        {
            try
            {
                if (model != null)
                {
                    return new ej_MetalTypeMaster()
                    {
                        MetalNameId = model.MetalNameId,
                        MetalWeightId = model.MetalWeightId,
                        MetaTypeId = model.MetalTypeId,
                        Price = model.Price,
                        Status = model.Status
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

      
        /*
         * Partha Ranjan
         * @ 02-01-13
         * This function helps to check thatthe metal is exist or not
         * */
        public bool IsExist(int metalWeightId,int metalNameId)
        {
            try
            {
                return objEntity.ej_MetalTypeMaster.Where(mt => mt.MetalNameId == metalNameId && mt.MetalWeightId == metalWeightId).Any();
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
        /*
         * Partha Ranjan
         * @ 02-01-13
         * This function helps to get the metal list
         * @ modified by Partha 
         * @ 08-04-13
         * */
        public List<MetalTypeListModel> GetMetalTypeList(int metaltypeid,CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<ej_MetalTypeMaster> lstMetalType = null;
                //
                if (metaltypeid > 0)
                {
                    lstMetalType = objEntity.ej_MetalTypeMaster.Where(tbl => tbl.MetaTypeId == metaltypeid).ToList();
                }
                else
                {
                    lstMetalType = objEntity.ej_MetalTypeMaster.Select(tbl => tbl).ToList();
                }
                //for status
                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstMetalType = lstMetalType.Where(tbl => tbl.Status == true).ToList();
                }
                //check for the metal type
                if (lstMetalType != null)
                {
                    return this.GetMetalTypeList(lstMetalType);
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

        private List<MetalTypeListModel> GetMetalTypeList(List<ej_MetalTypeMaster> lstMetalType)
        {
            try
            {
                return (from metalType in lstMetalType
                        join metalWeight in objEntity.ej_MetalWeightMaster
                         on metalType.MetalWeightId equals metalWeight.MetalWeightId
                        join metalName in objEntity.ej_MetalNameMaster
                        on metalType.MetalNameId equals metalName.MetalNameId
                        where metalWeight.Status == true && metalName.Status == true
                        select new MetalTypeListModel
                        {
                            MetalTypeNamePrice = metalWeight.MetalWeight + " " + metalName.MetalName + " $" + metalType.Price,
                            MetalTypeName = metalWeight.MetalWeight + " " + metalName.MetalName,
                            MetalName = metalName.MetalName,
                            MetalNameId = metalType.MetalNameId,
                            MetalPrice = metalType.Price,
                            MetalTypeId = metalType.MetaTypeId,
                            MetalWeight = metalWeight.MetalWeight,
                            MetalWeightId = metalType.MetalWeightId,
                            Status = metalType.Status
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
            return null;
        }
        /*
         * Partha Ranjan
         * @ 02-01-13
         * This function helps to delete the metal type
         * */
        public bool DeleteMetalType(int metalTypeID)
        {
            try
            {
                ej_MetalTypeMaster objMetalType = objEntity.ej_MetalTypeMaster.Where(mt => mt.MetaTypeId == metalTypeID).FirstOrDefault();
                if (objMetalType != null)
                {
                    objEntity.DeleteObject(objMetalType);
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


    }
}

