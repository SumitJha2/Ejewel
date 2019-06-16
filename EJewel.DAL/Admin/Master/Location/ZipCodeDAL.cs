using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Location;
using EJewel.Model.Admin.Common;

namespace EJewel.DAL.Admin.Master.Location
{
   public class ZipCodeDAL
    {

        EJewelEntities objEntity = new EJewelEntities();


        public ZipCodeModel SaveUpdateZipCode(ZipCodeModel model)
        {
            try
            {
                if (model.ZipCodeID > 0)
                {
                    ej_ZipCode objZipCode = objEntity.ej_ZipCode.Where(tbl => tbl.ZipCodeID == model.ZipCodeID).FirstOrDefault();
                    if (objZipCode != null)
                    {
                        //check that the sub ZipCode is present or not
                        if (objZipCode.ZipCode != model.ZipCode)
                        {
                            objZipCode.ZipCode = model.ZipCode;
                        }
                        //ZipCode
                        objZipCode.CountryId = model.CountryID;
                        objZipCode.ZipCodeToolTip = model.ZipCodeToolTip;
                        objZipCode.ZipCodeRegularExp = model.ZipCodeRegularExp;
                        objZipCode.CreatedBy = model.CreatedBy;
                        objZipCode.CreatedDate = model.CreatedDate;
                        objZipCode.Status = model.Status;
                        objEntity.SaveChanges();
                    }
                }
                else
                {
                    ej_ZipCode objZipCode = new ej_ZipCode()
                    {
                        ZipCodeID = model.ZipCodeID,
                        ZipCode = model.ZipCode,
                        CountryId = model.CountryID,
                        ZipCodeToolTip = model.ZipCodeToolTip,
                        ZipCodeRegularExp = model.ZipCodeRegularExp,
                        CreatedBy = model.CreatedBy,
                        CreatedDate = model.CreatedDate,
                        Status = model.Status,

                    };
                    objEntity.AddToej_ZipCode(objZipCode);
                    objEntity.SaveChanges();
                    model.ZipCodeID = objZipCode.ZipCodeID;
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




        public bool DeleteZipCode(int ZipCodeID)
        {
            try
            {
                ej_ZipCode objZipCode = objEntity.ej_ZipCode.Where(tbl => tbl.ZipCodeID == ZipCodeID).FirstOrDefault();
                if (objZipCode != null)
                {
                    objEntity.DeleteObject(objZipCode);
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


        public bool IsExistZipCode(int countryId, int zipCode, string ZipCode)
        {
            try
            {
                return objEntity.ej_ZipCode.Where(tbl => tbl.CountryId == countryId && tbl.ZipCode == ZipCode && tbl.ZipCodeID != zipCode).Any();
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

        public List<ZipCodeModel> GetZipCodeList(CommonModel.RecordStatus rStatus)
        {
            List<ZipCodeModel> lstModel = new List<ZipCodeModel>();

            try
            {
                List<ej_ZipCode> lstZipCode = null;
                lstZipCode = objEntity.ej_ZipCode.Select(tbl => tbl).ToList();


                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstZipCode = lstZipCode.Where(tbl => tbl.Status == true).ToList();
                }

                //
                if (lstZipCode != null)
                {
                    lstModel = (from zipcode in lstZipCode
                                join country in objEntity.ej_Country
                                on zipcode.CountryId equals country.CountryId
                                where country.Status == true
                                select new ZipCodeModel
                                {
                                    CountryID = Convert.ToInt32(zipcode.CountryId),
                                    ZipCodeID = zipcode.ZipCodeID,
                                    ZipCode = zipcode.ZipCode,
                                    CountryName = country.CountryName,
                                    ZipCodeToolTip = zipcode.ZipCodeToolTip,
                                    ZipCodeRegularExp = zipcode.ZipCodeRegularExp,
                                    CreatedBy = Convert.ToInt32(zipcode.CreatedBy),
                                    CreatedDate = Convert.ToDateTime(zipcode.CreatedDate),
                                    Status = Convert.ToBoolean(zipcode.Status)
                                }).OrderByDescending(tbl => tbl.ZipCode).ToList();
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



        public List<ZipCodeModel> GetZipCodeListByZipCodeID(int zipcodeID, CommonModel.RecordStatus rStatus)
        {
            List<ZipCodeModel> lstModel = new List<ZipCodeModel>();

            try
            {
                List<ej_ZipCode> lstZipCode = null;
                if (zipcodeID > 0)
                {
                    lstZipCode = objEntity.ej_ZipCode.Where(tbl => tbl.ZipCodeID == zipcodeID).ToList();
                }
                else
                {
                    lstZipCode = objEntity.ej_ZipCode.Select(tbl => tbl).ToList();
                }

                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstZipCode = lstZipCode.Where(tbl => tbl.Status == true).ToList();
                }

                //
                if (lstZipCode != null)
                {
                    lstModel = (from zipcode in lstZipCode
                                join country in objEntity.ej_Country
                                on zipcode.CountryId equals country.CountryId
                                where country.Status == true
                                select new ZipCodeModel
                                {
                                    CountryID = Convert.ToInt32(zipcode.CountryId),
                                    ZipCodeID = Convert.ToInt32(zipcode.ZipCodeID),
                                    ZipCode = zipcode.ZipCode,
                                    CountryName = country.CountryName,
                                    ZipCodeToolTip = zipcode.ZipCodeToolTip,
                                    ZipCodeRegularExp = zipcode.ZipCodeRegularExp,
                                    CreatedBy = Convert.ToInt32(zipcode.CreatedBy),
                                    CreatedDate = Convert.ToDateTime(zipcode.CreatedDate),
                                    Status = Convert.ToBoolean(zipcode.Status)
                                }).OrderByDescending(tbl => tbl.ZipCode).ToList();
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



        public List<ZipCodeModel> GetZipCodeByCountryID(int countryID, CommonModel.RecordStatus rStatus)
        {
            List<ZipCodeModel> lstModel = new List<ZipCodeModel>();

            try
            {
                List<ej_ZipCode> lstZipCode = null;
                if (countryID > 0)
                {
                    lstZipCode = objEntity.ej_ZipCode.Where(tbl => tbl.CountryId == countryID).ToList();
                }


                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstZipCode = lstZipCode.Where(tbl => tbl.Status == true).ToList();
                }

                //
                if (lstZipCode != null)
                {
                    lstModel = (from zipcode in lstZipCode

                                select new ZipCodeModel
                                {
                                    ZipCodeID = zipcode.ZipCodeID,
                                    CountryID = Convert.ToInt32(zipcode.CountryId),
                                    ZipCode = zipcode.ZipCode,
                                    ZipCodeToolTip = zipcode.ZipCodeToolTip,
                                    ZipCodeRegularExp = zipcode.ZipCodeRegularExp,

                                }).OrderByDescending(tbl => tbl.ZipCode).ToList();
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



    }
}
