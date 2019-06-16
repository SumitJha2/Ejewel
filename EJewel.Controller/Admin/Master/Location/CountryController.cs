using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL.Admin.Master.Location;
using EJewel.Model.Admin.Master.Location;
using EJewel.Model.Admin.Common;

namespace EJewel.Controller.Admin.Master.Location
{
   public class CountryController
    {

        CountryDAL objCountryDAL = new CountryDAL();


        public CountryModel SaveUpdateCountry(CountryModel model)
        {
            return objCountryDAL.SaveUpdateCountry(model);
        }
        public bool IsExistCountry(string countryName)
        {
            return objCountryDAL.IsExistCountry(countryName);
        }
        public bool IsExistCountry(int CountryID, string countryName)
        {
            return objCountryDAL.IsExistCountry(CountryID, countryName);
        }
        public bool DeleteCountry(int countryId)
        {
            return objCountryDAL.DeleteCountry(countryId);
        }
        public List<CountryModel> GetCountryList(int countryID,CommonModel.RecordStatus rStatus)
        {
            return objCountryDAL.GetCountryList(countryID,rStatus);
        }
        

    }
}
