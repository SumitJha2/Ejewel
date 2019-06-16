using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL.Admin.SiteSetting;
using EJewel.Model.Admin.SiteSetting;

namespace EJewel.Controller.Admin.SiteSetting
{
   public class CustomerLoginDetailsController
    {

       CustomerLoginDetailsDAL objDAL = new CustomerLoginDetailsDAL();


       public CustomerLoginDetailsModel SaveUpdateCustomerLoginDetails(CustomerLoginDetailsModel model)
        {
            return objDAL.SaveUpdateCustomerLoginDetails(model);
        }
       public List<CustomerLoginDetailsModel> GetLoginCustomerDetails()
        {
            return objDAL.GetLoginCustomerDetails();
        }
       public bool DeleteLoggedCustomer(int LoggedCustomerID)
        {
            return objDAL.DeleteLoggedCustomer(LoggedCustomerID);
        }

    }
}
