using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Stone;
using EJewel.DAL.Admin.Master.Stone;
namespace EJewel.Controller.Admin.Master.Stone
{
    public class StoneCategoryTypeController
    {
        StoneCategoryTypeDAL objdal = new StoneCategoryTypeDAL();
        /**
         * Partha Ranjan Nayak
         * @ 17-12-2012
         * */
        public List<StoneCategoryTypeModel> GetStoneCategoryType()
        {
            return objdal.GetStoneCategoryType();
        }

    }
}
