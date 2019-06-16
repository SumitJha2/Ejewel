using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Extras;

namespace EJewel.DAL.Admin.Extras
{
   public class CustomDesignRingDAL
    {
       EJewelEntities objEntity = new EJewelEntities();
       public CustomDesignRingModel SaveUpdateCustomDesign(CustomDesignRingModel model)
       {
           try
           {
               if (model.CustomDesignRequestID > 0)
               {
                   ej_CustomDesign_RingPopUp obj = objEntity.ej_CustomDesign_RingPopUp.Where(tbl => tbl.CustomDesignRequestID == model.CustomDesignRequestID).FirstOrDefault();
                   obj.DiamondItem = model.DiamondItem;
                   // obj.DiamondItem = model.DiamondItem;
                   obj.SideStones = model.SideStones;
                   obj.MetalTypeId = model.MetalTypeId;
                   obj.RingSizeId = model.RingSizeId;
                   obj.Budget = model.Budget;
                   obj.LinkstoDesign = model.LinkstoDesign;
                   obj.Comments = model.Comments;
                   obj.FileExtension = model.FileExtension;
                   obj.FullName = model.FullName;
                   obj.Email = model.Email;
                   obj.Phone = model.Phone;
                   obj.BestTimeToCall = model.BestTimeToCall;
                   objEntity.SaveChanges();

               }
               else
               {
                   ej_CustomDesign_RingPopUp obj = new ej_CustomDesign_RingPopUp()
                   {
                       DiamondItem = model.DiamondItem,
                       SideStones = model.SideStones,
                       MetalTypeId = model.MetalTypeId,
                       RingSizeId = model.RingSizeId,
                       Budget = model.Budget,
                       LinkstoDesign = model.LinkstoDesign,
                       Comments = model.Comments,
                       FileExtension = model.FileExtension,
                       FullName = model.FullName,
                       Email = model.Email,
                       Phone = model.Phone,
                       BestTimeToCall = model.BestTimeToCall,
                       CreatedDate = System.DateTime.Now
                   };
                   objEntity.AddToej_CustomDesign_RingPopUp(obj);
                   objEntity.SaveChanges();
                   model.CustomDesignRequestID = obj.CustomDesignRequestID;

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
       public List<CustomDesignRingModel> GetCustomDesignRing()
       {
           List<CustomDesignRingModel> model = new List<CustomDesignRingModel>();
           try
           {
               List<ej_CustomDesign_RingPopUp> obj = objEntity.ej_CustomDesign_RingPopUp.Select(tbl => tbl).ToList();
               if (obj != null)
               {
                   model = (from lst in obj
                            join metalname in objEntity.ej_MetalNameMaster
                            on lst.MetalTypeId equals metalname.MetalNameId
                            join ringsize in objEntity.ej_RingSizeMaster
                            on lst.RingSizeId equals ringsize.RingSizeId
                            where ringsize.Status == true && metalname.Status == true
                            select new CustomDesignRingModel
                            {
                                CustomDesignRequestID = lst.CustomDesignRequestID,
                                DiamondItem = lst.DiamondItem,
                                SideStones = lst.SideStones,
                                Budget = (float)lst.Budget,
                                LinkstoDesign = lst.LinkstoDesign,
                                Comments = lst.Comments,
                                FileExtension = lst.FileExtension,
                                FullName = lst.FullName,
                                Email = lst.Email,
                                Phone = lst.Phone,
                                BestTimeToCall = lst.BestTimeToCall,
                                MetalName = metalname.MetalName,
                                RingSize = Convert.ToString(ringsize.RingSize),
                                CreatedDate = lst.CreatedDate

                            }).ToList();
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
       public bool DeleteCustomDesignRingModel(long customerdesignRequestId)
       {
           bool flag = false;
           try
           {
               ej_CustomDesign_RingPopUp obj = objEntity.ej_CustomDesign_RingPopUp.Where(tbl => tbl.CustomDesignRequestID == customerdesignRequestId).FirstOrDefault();

               if (obj != null)
               {
                   objEntity.DeleteObject(obj);
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
