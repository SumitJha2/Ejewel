using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Location
{
   public class CityModel
    {
        public int CityId
        {
            get;
            set;
        }
        public int CountryId
        {
            get;
            set;
        }

        public string CountryName
        {
            get;
            set;
        }


        public int StateId
        {
            get;
            set;
        }

        public string StateName
        {
            get;
            set;
        }
        public string CityName
        {
            get;
            set;
        }
        public string CityCode
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public bool Status
        {
            get;
            set;
        }
    }
}
