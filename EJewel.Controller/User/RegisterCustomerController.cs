using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL.User;
using EJewel.Model.User;

namespace EJewel.Controller.User
{
   public class RegisterCustomerController
    {
        RegisterCustomerDAL objRegisterCustomerDAL = new RegisterCustomerDAL();

        public RegisterCustomerModel SaveUpdateRegisterCustomer(RegisterCustomerModel objRegisterCustomerModel)
        {
            return objRegisterCustomerDAL.SaveUpdateRegisterCustomer(objRegisterCustomerModel);
        }
        public List<RegisterCustomerModel> GetRegisterCustomerList(CommonModel.RecordStatus status)
        {
            return objRegisterCustomerDAL.GetRegisterCustomerList(status);

        }
        public List<RegisterCustomerModel> GetRegisterCustomerList(string customeremailID, string password)
        {
            return objRegisterCustomerDAL.GetRegisterCustomerList(customeremailID, password);

        }
        public bool IsExitsRegisterCustomer(string customerEmailID)
        {
            return objRegisterCustomerDAL.IsExitsRegisterCustomer(customerEmailID);
        }
        public bool IsExitsRegisterCustomer(int customerID, string customerEmailID)
        {
            return objRegisterCustomerDAL.IsExitsRegisterCustomer(customerID, customerEmailID);
        }
        public bool IsExitsRegisterCustomer(string customerEmailID, string password)
        {
            return objRegisterCustomerDAL.IsExitsRegisterCustomer(customerEmailID, password);
        }
    }
}
