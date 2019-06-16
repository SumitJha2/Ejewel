using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.SiteSetting;

namespace EJewel.DAL.Admin.SiteSetting
{
   public class LoginDetailsDAL
    {

        EJewelEntities objEntity = new EJewelEntities();
        public LoginDetailsModel SaveUpdateLoginDetails(LoginDetailsModel model)
        {
            try
            {

                ej_LoggedUser objloggeduser = new ej_LoggedUser()
                    {
                        LoggedUserID = model.LoggedUserID,
                        LoggedDatetime = model.LoggedDatetime,
                        LoggedUserIP = model.LoggedUserIP,
                        LoginID = model.LoginID,


                    };
                objEntity.AddToej_LoggedUser(objloggeduser);
                objEntity.SaveChanges();
                model.LoggedUserID = objloggeduser.LoggedUserID;
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return model;
        }
        public List<LoginDetailsModel> GetLoginUserDetails()
        {
            try
            {
                List<LoginDetailsModel> lstloggeduserDetails = (from obj in objEntity.ej_LoggedUser
                                                                select new LoginDetailsModel
                                                                {
                                                                    LoggedUserID = obj.LoggedUserID,
                                                                    LoggedUserIP = obj.LoggedUserIP,
                                                                    LoggedDatetime = (DateTime)obj.LoggedDatetime,
                                                                    LoginID = obj.LoginID

                                                                }).OrderByDescending(tbl => tbl.LoggedUserID).ToList();
                return lstloggeduserDetails;
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return null;

        }
        public bool DeleteLoggedUser(int LoggedUserID)
        {
            try
            {
                ej_LoggedUser obj = objEntity.ej_LoggedUser.Where(tbl => tbl.LoggedUserID == LoggedUserID).FirstOrDefault();
                if (obj != null)
                {
                    objEntity.DeleteObject(obj);
                    objEntity.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return false;

        }
       
       
       
      
    }
}
