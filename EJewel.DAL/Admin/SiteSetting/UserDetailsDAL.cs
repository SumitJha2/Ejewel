using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.SiteSetting;

namespace EJewel.DAL.Admin.SiteSetting
{
   public class UserDetailsDAL
    {
       EJewelEntities objEntity=new EJewelEntities();
       public UserDetailsModel SaveUpdateUserDetails(UserDetailsModel model)
       {
           try
           {
               if (model.UId > 0)
               {
                   ej_UserDetails objUserDetails = objEntity.ej_UserDetails.Where(tbl => tbl.UId == model.UId).FirstOrDefault();
                   if (objUserDetails != null)
                   {
                       objUserDetails.UserName = model.UserName;
                       objUserDetails.UserMobNo = model.UserMobNo;
                       objUserDetails.UserId = model.UserId;
                       objUserDetails.UserPassWord = model.UserPassword;
                       objUserDetails.UserTypeId = model.UserTypeId;
                       objUserDetails.Status = model.Status;
                       objUserDetails.UserEmail = model.UserEmail;
                       objEntity.SaveChanges();
                   }

               }
               else
               {
                   ej_UserDetails objUserDetails = new ej_UserDetails()
                       {
                           UserName = model.UserName,
                           UserEmail = model.UserEmail,
                           UserPassWord = model.UserPassword,
                           UserMobNo = model.UserMobNo,
                           UserId = model.UserId,
                           Status = model.Status,
                           UserTypeId = model.UserTypeId
                       };
                   objEntity.AddToej_UserDetails(objUserDetails);
                   objEntity.SaveChanges();
                   model.UId = objUserDetails.UId;
               }
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
       public List<UserDetailsModel> GetUserDetails(int uid,CommonModel.RecordStatus rstatus)
       {
           try
           {
               List<ej_UserDetails> objUserDetails = new List<ej_UserDetails>();
               if (uid > 0)
               {
                   objUserDetails = objEntity.ej_UserDetails.Where(tbl => tbl.UId == uid).ToList();
               }
               else
               {
                   objUserDetails = objEntity.ej_UserDetails.Select(tbl => tbl).ToList();
               }
               if (rstatus == CommonModel.RecordStatus.Enabled)
               {
                   objUserDetails = objUserDetails.Where(tbl => tbl.Status == true).ToList();
               }
               List<UserDetailsModel> lstUserDetails = (from obj in objUserDetails
                                                        join lst in objEntity.ej_UserType
                                                        on obj.UserTypeId equals lst.UserTypeId
                                                        where lst.Status == true
                                                        select new UserDetailsModel
                                                        {
                                                            UId = obj.UId,
                                                            UserTypeId = obj.UserTypeId,
                                                            UserId = obj.UserId,
                                                            UserName = obj.UserName,
                                                            UserPassword = obj.UserPassWord,
                                                            UserEmail = obj.UserEmail,
                                                            UserMobNo = obj.UserMobNo,
                                                            UserTypeName = lst.UserType,
                                                            Status = obj.Status
                                                        }).OrderByDescending(tbl => tbl.UId).ToList();
               return lstUserDetails;
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
       public List<UserDetailsModel> CheckLoginUser(string userID, string password)
       {
           try
           {
               ej_UserDetails objUserDetails = new ej_UserDetails();
               if (userID != "" && password != "")
               {
                   objUserDetails = objEntity.ej_UserDetails.Where(tbl => tbl.UserId.ToLower() == userID && tbl.UserPassWord.ToLower() == password && tbl.Status == true).FirstOrDefault();
               }
               List<UserDetailsModel> lstUserDetails = (from obj in objEntity.ej_UserDetails
                                                        where obj.UserId == userID && obj.UserPassWord == password
                                                         && obj.Status == true
                                                        select new UserDetailsModel
                                                        {

                                                            UserTypeId = obj.UserTypeId,
                                                            UserId = obj.UserId,
                                                            UserName = obj.UserName,
                                                            UserPassword = obj.UserPassWord,
                                                            UserEmail = obj.UserEmail
                                                        }).ToList();
               return lstUserDetails;
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
       public bool DeleteUserDetails(int uid)
       {
           try
           {
               ej_UserDetails objUserDetails = objEntity.ej_UserDetails.Where(tbl => tbl.UId == uid).FirstOrDefault();
               if (objUserDetails != null)
               {
                   objEntity.DeleteObject(objUserDetails);
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
       public bool IsExistUser(int uid,string userId)
       {
           try
           {
               if (uid > 0)
               {
                   return objEntity.ej_UserDetails.Where(tbl => tbl.UserId == userId.Trim() && tbl.UId != uid).Any();
               }
               else
               {
                   return objEntity.ej_UserDetails.Where(tbl => tbl.UserId == userId.Trim()).Any();
               }
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

       public bool CheckPasswordExist(string userID, string oldpassword)
       {
           try
           {
               return objEntity.ej_UserDetails.Where(tbl => tbl.UserId == userID && tbl.UserPassWord == oldpassword && tbl.Status == true).Any();
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
       public bool ChangePassword(string userID, string newPassword)
       {
           bool flag = false;
           try
           {
               ej_UserDetails objUserDetails = objEntity.ej_UserDetails.Where(tbl => tbl.UserId == userID).FirstOrDefault();
               if (objUserDetails != null)
               {
                   objUserDetails.UserPassWord = newPassword;
                   objEntity.SaveChanges();
                   flag = true;
               }
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
           return flag;
       }
    }
}
