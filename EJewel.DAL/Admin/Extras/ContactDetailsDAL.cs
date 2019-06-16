using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Extras;

namespace EJewel.DAL.Admin.Extras
{
   public class ContactDetailsDAL
    {
       EJewelEntities objEntity = new EJewelEntities();
       public ContactDetailsModel SaveContactDetails(ContactDetailsModel model)
       {
           try
           {
               ej_ContactDetails objContactDetails = new ej_ContactDetails();
               if (model != null)
               {
                   objContactDetails.FirstName = model.FirstName;
                   objContactDetails.LastName = model.LastName;
                   objContactDetails.Message = model.Message;
                   //objContactDetails.Status = true;
                   objContactDetails.Email = model.Email;
                   objContactDetails.Telephone = model.Telephone;
                   objContactDetails.ContactDate = System.DateTime.Now;
                   objEntity.AddToej_ContactDetails(objContactDetails);
                   objEntity.SaveChanges();
               }
               model.ContactDetailsId = objContactDetails.ContactDetailsId;
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
       public List<ContactDetailsModel> GetContactDetails()
       {
           try
           {
               List<ej_ContactDetails> objContactDetails = objEntity.ej_ContactDetails.Select(tbl => tbl).ToList();
               List<ContactDetailsModel> lstContactDetails = (from lst in objContactDetails
                                                              select new ContactDetailsModel
                                                              {
                                                                  ContactDetailsId = lst.ContactDetailsId,
                                                                  FirstName = lst.FirstName,
                                                                  LastName = lst.LastName,
                                                                  Email = lst.Email,
                                                                  Telephone = lst.Telephone,
                                                                  Message = lst.Message,
                                                                  ContactDate = lst.ContactDate
                                                              }).OrderByDescending(tbl => tbl.ContactDetailsId).ToList();
               return lstContactDetails;
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
       public bool DeleteContactDetails(int contactDetailsId)
       {
           bool lflag = false;
           try
           {
               ej_ContactDetails objContactDetails = objEntity.ej_ContactDetails.Where(tbl => tbl.ContactDetailsId == contactDetailsId).FirstOrDefault();
               if (objContactDetails != null)
               {
                   objEntity.DeleteObject(objContactDetails);
                   objEntity.SaveChanges();
                   lflag = true;
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
           return lflag;
       }
    }
}
