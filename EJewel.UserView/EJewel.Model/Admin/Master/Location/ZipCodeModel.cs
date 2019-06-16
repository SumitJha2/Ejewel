using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Location
{
   public class ZipCodeModel
    {

        public int ZipCodeID
        {
            get;
            set;
        }
        public string ZipCode
        {
            get;
            set;
        }
        public string ZipCodeToolTip
        {
            get;
            set;
        }
        public string ZipCodeRegularExp
        {
            get;
            set;
        }
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
