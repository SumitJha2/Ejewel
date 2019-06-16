using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL.Admin.Master.Location;
using EJewel.Model.Admin.Master.Location;
using EJewel.Model.Admin.Common;

namespace EJewel.Controller.Admin.Master.Location
{
   public class CityController
    {

        CityDAL objCityDAL = new CityDAL();

        public CityModel SaveUpdateCity(CityModel model)
        {
            return objCityDAL.SaveUpdateCity(model);
        }
        public bool IsExistCity(int countryID, int stateId, int cityID, string cityName)
        {
            return objCityDAL.IsExistCity(countryID, stateId, cityID, cityName);
        }
        public bool DeleteState(int cityId)
        {
            return objCityDAL.DeleteCity(cityId);
        }
       public List<CityModel> GetCityList(int cityID, CommonModel.RecordStatus rStatus)
        {
            return objCityDAL.GetCityList(cityID, rStatus);
        }


       //31-05-2013  Soumya
       public List<CityModel> GetCityList(int countryID, int stateID, int cityID, CommonModel.RecordStatus rStatus)
       {
           return objCityDAL.GetCityList(countryID, stateID, cityID, rStatus);
       }
       public List<CityModel> GetCityIDByCityName(int countryID, int stateID, string cityName)
       {
           return objCityDAL.GetCityIDByCityName(countryID, stateID, cityName);
       }



    }
}
