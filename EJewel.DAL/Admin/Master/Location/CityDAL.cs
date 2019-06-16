using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Location;
using EJewel.Model.Admin.Common;

namespace EJewel.DAL.Admin.Master.Location
{
   public class CityDAL
    {

        EJewelEntities objEntity = new EJewelEntities();



        public CityModel SaveUpdateCity(CityModel model)
        {
            try
            {
                if (model.CityId > 0)
                {
                    ej_City objCity = objEntity.ej_City.Where(tbl => tbl.CityId == model.CityId).FirstOrDefault();
                    if (objCity != null)
                    {
                        //check that the sub City is present or not
                        if (objCity.CityName != model.CityName)
                        {
                            objCity.CityName = model.CityName;
                        }
                        //City
                        objCity.CountryId = model.CountryId;
                        objCity.StateId = model.StateId;
                        objCity.CityCode = model.CityCode;
                        objCity.CreatedBy = model.CreatedBy;
                        objCity.CreatedDate = model.CreatedDate;
                        objCity.Status = model.Status;
                        objEntity.SaveChanges();
                    }
                }
                else
                {
                    ej_City objCity = new ej_City()
                    {
                        CityId = model.CityId,
                        CountryId = model.CountryId,
                        StateId = model.StateId,
                        CityName = model.CityName,
                        CityCode = model.CityCode,
                        CreatedBy = model.CreatedBy,
                        CreatedDate = model.CreatedDate,
                        Status = model.Status,

                    };
                    objEntity.AddToej_City(objCity);
                    objEntity.SaveChanges();
                    model.CityId = objCity.CityId;
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



        public bool DeleteCity(int CityID)
        {
            try
            {
                ej_City objCity = objEntity.ej_City.Where(tbl => tbl.CityId == CityID).FirstOrDefault();
                if (objCity != null)
                {
                    objEntity.DeleteObject(objCity);
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


        public bool IsExistCity(int countryId, int stateId, int CityID, string CityName)
        {
            try
            {
                return objEntity.ej_City.Where(tbl => tbl.CountryId == countryId && tbl.StateId == stateId && tbl.CityId != CityID && tbl.CityName == CityName).Any();
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






       




        public List<CityModel> GetCityList(int CityID, CommonModel.RecordStatus Status)
        {
            List<CityModel> objcityModel = new List<CityModel>();
            List<ej_City> objcity = null;
            if (CityID > 0)
            {
                objcity = objEntity.ej_City.Where(tbl => tbl.CityId == CityID).ToList();
            }
            else
            {
                objcity = objEntity.ej_City.Select(tbl => tbl).ToList();
            }
            if (Status == CommonModel.RecordStatus.Enabled)
            {
                objcity = objcity.Where(tbl => tbl.Status == true).ToList();
            }
            if (objcity != null)
            {
                objcityModel = (from city in objcity
                                join country in objEntity.ej_Country on city.CountryId equals country.CountryId
                                join state in objEntity.ej_State on city.StateId equals state.StateId
                                where country.Status==true && state.Status==true                                
                                select new CityModel()
                                {
                                    CityId = city.CityId,
                                    CityName = city.CityName,
                                    CountryId = Convert.ToInt32(city.CountryId),
                                    StateId = city.StateId,
                                    CountryName = country.CountryName,
                                    StateName = state.StateName,
                                    CityCode = city.CityCode,
                                    CreatedBy = Convert.ToInt32(city.CreatedBy),
                                    CreatedDate = Convert.ToDateTime(city.CreatedDate)

                                }).ToList();

            }
            return objcityModel;

        }


        //31-05-2013 By Soumya    Get CityList By Country,State And City ID
        public List<CityModel> GetCityList(int countryID, int stateID, int CityID, CommonModel.RecordStatus Status)
        {
            List<CityModel> objcityModel = new List<CityModel>();
            List<ej_City> objcity = null;
            if (countryID > 0)
            {
                objcity = objEntity.ej_City.Where(tbl => tbl.CountryId == countryID).ToList();
            }
            if (stateID > 0)
            {
                objcity = objEntity.ej_City.Where(tbl => tbl.StateId == stateID).ToList();
            }
            if (CityID > 0)
            {
                objcity = objEntity.ej_City.Where(tbl => tbl.CityId == CityID).ToList();
            }
            else
            {
                objcity = objEntity.ej_City.Select(tbl => tbl).ToList();
            }
            if (Status == CommonModel.RecordStatus.Enabled)
            {
                objcity = objcity.Where(tbl => tbl.Status == true).ToList();
            }
            if (objcity != null)
            {
                objcityModel = (from city in objcity
                                join country in objEntity.ej_Country on city.CountryId equals country.CountryId
                                join state in objEntity.ej_State on city.StateId equals state.StateId
                                where country.Status==true && state.Status==true
                                select new CityModel()
                                {
                                    CityId = city.CityId,
                                    CityName = city.CityName,
                                    CountryId = Convert.ToInt32(city.CountryId),
                                    StateId = city.StateId,
                                    CountryName = country.CountryName,
                                    StateName = state.StateName,
                                    CityCode = city.CityCode,
                                    CreatedBy = Convert.ToInt32(city.CreatedBy),
                                    CreatedDate = Convert.ToDateTime(city.CreatedDate)

                                }).ToList();

            }
            return objcityModel;


        }


        public List<CityModel> GetCityIDByCityName(int countryID, int stateID, string  CityName)
        {
            List<CityModel> objcityModel = new List<CityModel>();
            List<ej_City> objcity = null;
            objcity = objEntity.ej_City.Where(tbl => tbl.CountryId == countryID && tbl.StateId==stateID && tbl.CityName==CityName && tbl.Status==true).ToList();
          
            if (objcity != null)
            {
                objcityModel = (from city in objcity
                                select new CityModel()
                                {
                                    CityId = city.CityId,
                                    CityName = city.CityName,
                                   

                                }).ToList();

            }
            return objcityModel;


        }



    }
}
