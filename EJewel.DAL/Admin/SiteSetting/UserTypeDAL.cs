using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.SiteSetting;


namespace EJewel.DAL.Admin.SiteSetting
{
   public class UserTypeDAL
    {
       EJewelEntities objEntity = new EJewelEntities();
       public List<UserTypeModel> GetUserType()
       {
           try
           {
               List<UserTypeModel> lstUser = (from lst in objEntity.ej_UserType
                                              where lst.Status == true
                                              select new UserTypeModel
                                              {
                                                  UserTypeId = lst.UserTypeId,
                                                  UserTypeName = lst.UserType,
                                                  Status = lst.Status
                                              }).OrderBy(tbl => tbl.UserTypeName).ToList();
               return lstUser;
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
       

    }
}
