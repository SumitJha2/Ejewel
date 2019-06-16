using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL.Admin.SiteSetting;
using EJewel.Model.Admin.SiteSetting;

namespace EJewel.Controller.Admin.SiteSetting
{
   public class LoginDetailsController
    {
       LoginDetailsDAL objDAL = new LoginDetailsDAL();
       public LoginDetailsModel SaveUpdateLoginDetails(LoginDetailsModel model)
        {
            return objDAL.SaveUpdateLoginDetails(model);
        }
        public List<LoginDetailsModel> GetUserDetails()
        {
            return objDAL.GetLoginUserDetails();
        }
        public bool DeleteLoggedUser(int LoggedUserID)
        {
            return objDAL.DeleteLoggedUser(LoggedUserID);
        }
       
    }
}
