using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.SiteSetting;
using EJewel.DAL.Admin.SiteSetting;

namespace EJewel.Controller.Admin.SiteSetting
{
   public class UserTypeController
    {
       UserTypeDAL objDAL = new UserTypeDAL();
       public List<UserTypeModel> GetUserType()
       {
           return objDAL.GetUserType();
       }
    }
}
