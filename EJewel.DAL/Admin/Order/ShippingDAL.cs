using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Order;

namespace EJewel.DAL.Admin.Order
{
  public class ShippingDAL
    {
      EJewelEntities objEntity = new EJewelEntities();

      public ShippingModel SaveUpdateShipping(ShippingModel model)
      {
          try
          {
              ej_ShippingMaster objShippingModel = new ej_ShippingMaster()
              {
                  ShippingNameId = model.ShippingNameId,
                  ShippingTypeId = model.ShippingTypeId,
                  CountryId = model.CountryId,
                  Price = model.Price,
                  Status = model.Status
              };
              objEntity.AddToej_ShippingMaster(objShippingModel);
              objEntity.SaveChanges();
              model.ShippingId = objShippingModel.ShippingId;
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
     
      public List<ShippingModel> GetShippingList(int shippingnameId,int shippingTypeId)
      {
           List<ej_ShippingMaster> objShippingMaster=new List<ej_ShippingMaster>();
           List<ShippingModel> lstShipmentModel = new List<ShippingModel>();
           try
           {
               if (shippingnameId > 0 && shippingTypeId > 0)
               {
                   objShippingMaster = objEntity.ej_ShippingMaster.Where(tbl => tbl.ShippingNameId == shippingnameId && tbl.ShippingTypeId == shippingTypeId).ToList();
               }
               if (objShippingMaster != null && objShippingMaster.Count > 0)
               {
                   lstShipmentModel = (from lst in objShippingMaster
                                       join country in objEntity.ej_Country
                                       on lst.CountryId equals country.CountryId
                                       where country.Status == true
                                       select new ShippingModel
                                       {
                                           ShippingId = lst.ShippingId,
                                           ShippingNameId = lst.ShippingNameId,
                                           CountryName = country.CountryName,
                                           CountryId = lst.CountryId,
                                           Status = lst.Status,
                                           Price = lst.Price
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
          return lstShipmentModel;  
      }

      public bool DeleteShippingDetails(int shippingnameId, int shippingTypeId)
      {
          try
          {
              List<ej_ShippingMaster> objShippingModel = objEntity.ej_ShippingMaster.Where(tbl => tbl.ShippingNameId == shippingnameId && tbl.ShippingTypeId == shippingTypeId).ToList();
              if (objShippingModel != null && objShippingModel.Count > 0)
              {
                  foreach (ej_ShippingMaster obj in objShippingModel)
                  {
                      objEntity.DeleteObject(obj);
                      objEntity.SaveChanges();
                  }
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
