using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL.Admin.SiteSetting;
using EJewel.Model.Admin.SiteSetting;

namespace EJewel.Controller.Admin.SiteSetting
{
   public class UserDetailsController
    {
       UserDetailsDAL objDAL = new UserDetailsDAL();
       public UserDetailsModel SaveUpdateUserDetails(UserDetailsModel model)
       {
           return objDAL.SaveUpdateUserDetails(model);
       }
       public List<UserDetailsModel> GetUserDetails(int uid, CommonModel.RecordStatus rstatus)
       {
           return objDAL.GetUserDetails(uid, rstatus);
       }
       public List<UserDetailsModel> CheckLoginUser(string userID,string password)
       {
           return objDAL.CheckLoginUser(userID, password);
       }
       public bool DeleteUserDetails(int uid)
       {
           return objDAL.DeleteUserDetails(uid);
       }
       public bool IsExistUserID(int uid,string userId)
       {
           return objDAL.IsExistUser(uid,userId);
       }
       public bool CheckPasswordExist(string userID, string oldpassword)
       {
           return objDAL.CheckPasswordExist(userID, oldpassword);
       }
       public bool ChangePassword(string userID, string newpassword)
       {
           return objDAL.ChangePassword(userID,newpassword);
       }
    }
}
