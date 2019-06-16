using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.User;

namespace EJewel.DAL.User
{
   public class RegisterCustomerDAL
    {

       //31-05-2013

        EJewelEntities objEntity = new EJewelEntities();


        //Save & Update Register Customer Account
        public RegisterCustomerModel SaveUpdateRegisterCustomer(RegisterCustomerModel objRegisterCustomerModel)
        {

            if (objRegisterCustomerModel.CustomerID > 0)
            {
                ej_Customer_Account objcustomeraccount = objEntity.ej_Customer_Account.Where(tbl => tbl.CustomerID == objRegisterCustomerModel.CustomerID).FirstOrDefault();
                if (objcustomeraccount != null)
                {
                    objcustomeraccount.CustomerEmailID = objRegisterCustomerModel.CustomerEmailID;
                    objcustomeraccount.CustomerPassword = objRegisterCustomerModel.CustomerPassword;
                    objcustomeraccount.CustomerStatus = objRegisterCustomerModel.CustomerStatus;
                    objEntity.SaveChanges();

                }
            }
            else
            {
                ej_Customer_Account objCustomerAccount = new ej_Customer_Account()
                {
                    CustomerID = objRegisterCustomerModel.CustomerID,
                    CustomerEmailID = objRegisterCustomerModel.CustomerEmailID,
                    CustomerPassword = objRegisterCustomerModel.CustomerPassword,
                    CustomerStatus = objRegisterCustomerModel.CustomerStatus,
                    CustomerAccountModifiedDateTime = objRegisterCustomerModel.ModifiedDateTime,
                };
                objEntity.AddToej_Customer_Account(objCustomerAccount);
                objEntity.SaveChanges();
                objRegisterCustomerModel.CustomerID = objCustomerAccount.CustomerID;
            }
            return objRegisterCustomerModel;
        }



        //Get Register Customer Account Details
        public List<RegisterCustomerModel> GetRegisterCustomerList(CommonModel.RecordStatus Status)
        {
            List<RegisterCustomerModel> objRegisterCustomerModel = new List<RegisterCustomerModel>();
            List<ej_Customer_Account> objRegisterCustomer = null;
            if (Status == CommonModel.RecordStatus.Enabled)
            {
                objRegisterCustomer = objEntity.ej_Customer_Account.Where(tbl => tbl.CustomerStatus == true).ToList();
            }
            if (objRegisterCustomer != null)
            {

                objRegisterCustomerModel = (from RegisterCustomer in objRegisterCustomer
                                            select new RegisterCustomerModel()
                                            {
                                                CustomerID = RegisterCustomer.CustomerID,
                                                CustomerEmailID = RegisterCustomer.CustomerEmailID,
                                                CustomerPassword = RegisterCustomer.CustomerPassword,
                                                CustomerStatus = RegisterCustomer.CustomerStatus,
                                                ModifiedDateTime = RegisterCustomer.CustomerAccountModifiedDateTime

                                            }).ToList();
            }
            return objRegisterCustomerModel;

        }


        //Get Register Customer Account Password
        public List<RegisterCustomerModel> GetRegisterCustomerList(string customerEmailID, string password)
        {
            List<RegisterCustomerModel> objRegisterCustomerModel = new List<RegisterCustomerModel>();
            List<ej_Customer_Account> objRegisterCustomer = null;

            objRegisterCustomer = objEntity.ej_Customer_Account.Where(tbl => tbl.CustomerEmailID == customerEmailID && tbl.CustomerPassword == password.ToLower() && tbl.CustomerStatus == true).ToList();

            if (objRegisterCustomer != null)
            {

                objRegisterCustomerModel = (from RegisterCustomer in objRegisterCustomer
                                            select new RegisterCustomerModel()
                                            {
                                                CustomerID = RegisterCustomer.CustomerID,
                                                CustomerEmailID = RegisterCustomer.CustomerEmailID,
                                                CustomerPassword = RegisterCustomer.CustomerPassword,
                                                CustomerStatus = RegisterCustomer.CustomerStatus,
                                                ModifiedDateTime = RegisterCustomer.CustomerAccountModifiedDateTime

                                            }).ToList();
            }
            return objRegisterCustomerModel;

        }

        public bool IsExitsRegisterCustomer(string customerEmailID)
        {
            return objEntity.ej_Customer_Account.Where(tbl => tbl.CustomerEmailID == customerEmailID).Any();
        }
        public bool IsExitsRegisterCustomer(int customerID, string customerEmailID)
        {
            return objEntity.ej_Customer_Account.Where(tbl => tbl.CustomerID != customerID && tbl.CustomerEmailID == customerEmailID).Any();
        }

        public bool IsExitsRegisterCustomer(string customerEmailID, string password)
        {
            return objEntity.ej_Customer_Account.Where(tbl => tbl.CustomerEmailID != customerEmailID && tbl.CustomerPassword == password).Any();
        }
    }
}
