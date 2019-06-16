using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Location;
using EJewel.Model.Admin.Common;

namespace EJewel.DAL.Admin.Master.Location
{
   public class CountryDAL
    {


        EJewelEntities objEntity = new EJewelEntities();


        public CountryModel SaveUpdateCountry(CountryModel model)
        {
            try
            {
                if (model.CountryID > 0)
                {
                    ej_Country objCountry = objEntity.ej_Country.Where(tbl => tbl.CountryId == model.CountryID).FirstOrDefault();
                    if (objCountry != null)
                    {
                        //check that the sub country is present or not
                        if (objCountry.CountryName != model.CountryName)
                        {
                            objCountry.CountryName = model.CountryName;
                        }
                        //country
                        objCountry.CountryCode = model.CountryCode;
                        objCountry.StateDisplayName = model.StateDisplayName;
                        objCountry.HasMultipleState = model.HasMultipleState;
                        objCountry.PostalCodeDisplayName = model.PostalCodeDisplayName;
                        objCountry.IsPostalCodeRequired = model.IsPostalCodeRequired;
                        objCountry.CreatedBy = model.CreatedBy;
                        objCountry.CreatedDate = model.CreatedDate;
                        objCountry.Status = model.Status;
                        objEntity.SaveChanges();
                    }
                }
                else
                {
                    ej_Country objCountry = new ej_Country()
                    {
                        CountryId = model.CountryID,
                        CountryName = model.CountryName,
                        CountryCode = model.CountryCode,
                        StateDisplayName = model.StateDisplayName,
                        HasMultipleState = model.HasMultipleState,
                        PostalCodeDisplayName = model.PostalCodeDisplayName,
                        IsPostalCodeRequired = model.IsPostalCodeRequired,
                        CreatedBy = model.CreatedBy,
                        CreatedDate = model.CreatedDate,
                        Status = model.Status,

                    };
                    objEntity.AddToej_Country(objCountry);
                    objEntity.SaveChanges();
                    model.CountryID = objCountry.CountryId;
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



        public bool DeleteCountry(int countryId)
        {
            try
            {
                ej_Country objCountry = objEntity.ej_Country.Where(tbl => tbl.CountryId == countryId).FirstOrDefault();
                if (objCountry != null)
                {
                    objEntity.DeleteObject(objCountry);
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



        public bool IsExistCountry(string countryName)
        {
            try
            {
                return objEntity.ej_Country.Where(tbl => tbl.CountryName == countryName).Any();
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
        public bool IsExistCountry(int countryID, string countryName)
        {
            return objEntity.ej_Country.Where(tbl => tbl.CountryName == countryName && tbl.CountryId != countryID).Any();
        }


        public List<CountryModel> GetCountryList(int CountryID,CommonModel.RecordStatus rStatus)
        {

            List<CountryModel> lstModel = new List<CountryModel>();
            try
            {
                List<ej_Country> lstCountry = null;

                if (CountryID > 0)
                {
                    lstCountry = objEntity.ej_Country.Where(tbl => tbl.CountryId == CountryID).ToList();
                }
                else
                {
                    lstCountry = objEntity.ej_Country.Select(tbl => tbl).ToList();
                }


                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstCountry = lstCountry.Where(tbl => tbl.Status == true).ToList();
                }

                //
                if (lstCountry != null)
                {
                    lstModel = (from country in lstCountry
                                select new CountryModel
                                {
                                    CountryID = country.CountryId,
                                    CountryName = country.CountryName,
                                    CountryCode = country.CountryCode,
                                    StateDisplayName = country.StateDisplayName,
                                    HasMultipleState = Convert.ToBoolean(country.HasMultipleState),
                                    PostalCodeDisplayName = country.PostalCodeDisplayName,
                                    IsPostalCodeRequired = Convert.ToBoolean(country.IsPostalCodeRequired),
                                    CreatedBy = Convert.ToInt32(country.CreatedBy),
                                    CreatedDate = Convert.ToDateTime(country.CreatedDate),
                                    Status = Convert.ToBoolean(country.Status)
                                }).OrderByDescending(tbl => tbl.CountryName).ToList();
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
