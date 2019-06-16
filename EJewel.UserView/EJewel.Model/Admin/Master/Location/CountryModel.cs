using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Location
{
   public class CountryModel
    {

        public int CountryID
        {
            get;
            set;
        }
        public string CountryName
        {
            get;
            set;
        }
        public string CountryCode
        {
            get;
            set;
        }
        public string StateDisplayName
        {
            get;
            set;
        }
        public bool HasMultipleState
        {
            get;
            set;
        }
        public string PostalCodeDisplayName
        {
            get;
            set;
        }
        public bool IsPostalCodeRequired
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
       public double Price
        {
            get;
            set;
        }


    }
}
