using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL.Admin.Master.Location;
using EJewel.Model.Admin.Master.Location;
using EJewel.Model.Admin.Common;

namespace EJewel.Controller.Admin.Master.Location
{
   public class ZipCodeController
    {
        ZipCodeDAL objZipCodeDAL = new ZipCodeDAL();

        public ZipCodeModel SaveUpdateZipCode(ZipCodeModel model)
        {
            return objZipCodeDAL.SaveUpdateZipCode(model);
        }
        public bool IsExistZipCode(int countryID, int zipcodeID, string zipCode)
        {
            return objZipCodeDAL.IsExistZipCode(countryID, zipcodeID, zipCode);
        }
        public bool DeleteZipCode(int ZipCodeID)
        {
            return objZipCodeDAL.DeleteZipCode(ZipCodeID);
        }
        public List<ZipCodeModel> GetZipCodeList(CommonModel.RecordStatus rStatus)
        {
            return objZipCodeDAL.GetZipCodeList(rStatus);
        }
        public List<ZipCodeModel> GetZipCodeListByZipCodeID(int zipcodeID, CommonModel.RecordStatus rStatus)
        {
            return objZipCodeDAL.GetZipCodeListByZipCodeID(zipcodeID, rStatus);
        }
        public List<ZipCodeModel> GetZipCodeByCountryID(int countryID)
        {
            return objZipCodeDAL.GetZipCodeByCountryID(countryID, CommonModel.RecordStatus.Enabled);
        }

    }
}
