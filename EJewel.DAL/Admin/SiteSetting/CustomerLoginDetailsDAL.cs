using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.SiteSetting;

namespace EJewel.DAL.Admin.SiteSetting
{
   public class CustomerLoginDetailsDAL
    {

        EJewelEntities objEntity = new EJewelEntities();
        public CustomerLoginDetailsModel SaveUpdateCustomerLoginDetails(CustomerLoginDetailsModel model)
        {
            try
            {

                ej_LoggedCustomer objloggedcustomer = new ej_LoggedCustomer()
                {
                    LoggedCustomerID = model.LoggedCustomerID,
                    LoggedDatetime = model.LoggedDatetime,
                    LoggedCustomerIP = model.LoggedCustomerIP,
                    CustomerID = model.CustomerID,


                };
                objEntity.AddToej_LoggedCustomer(objloggedcustomer);
                objEntity.SaveChanges();
                model.LoggedCustomerID = objloggedcustomer.LoggedCustomerID;
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
        public List<CustomerLoginDetailsModel> GetLoginCustomerDetails()
        {

            try
            {
                List<CustomerLoginDetailsModel> lstloggedCustomerDetails = (from obj in objEntity.ej_LoggedCustomer
                                                                            select new CustomerLoginDetailsModel
                                                                    {
                                                                        LoggedCustomerID = obj.LoggedCustomerID,
                                                                        LoggedCustomerIP = obj.LoggedCustomerIP,
                                                                        LoggedDatetime = (DateTime)obj.LoggedDatetime,
                                                                        CustomerID = obj.CustomerID

                                                                    }).OrderByDescending(tbl => tbl.LoggedCustomerID).ToList();
                return lstloggedCustomerDetails;
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
        public bool DeleteLoggedCustomer(int LoggedCustomerID)
        {
            try
            {
                ej_LoggedCustomer obj = objEntity.ej_LoggedCustomer.Where(tbl => tbl.LoggedCustomerID == LoggedCustomerID).FirstOrDefault();
                if (obj != null)
                {
                    objEntity.DeleteObject(obj);
                    objEntity.SaveChanges();
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
            return true;

        }
    }
}
