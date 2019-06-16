using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL.User;
using EJewel.Model.User;
using EJewel.DAL;

namespace EJewel.Controller.User
{
   public class CustomerAccountDetailsController
    {
       
       //31-05-2013
      
        CustomerAccountDetailsDAL objCustomerAccountDetailsDAL = new CustomerAccountDetailsDAL();

        //Save & Update CustomerDetails
        public CustomerAccountDetailsModel SaveUpdateCustomerDetails(CustomerAccountDetailsModel objCustomerAccountDetailsModel)
        {

            return objCustomerAccountDetailsDAL.SaveUpdateCustomerDetails(objCustomerAccountDetailsModel);
        }

       //Get CustomerDetails By CustomerID
        public GetCustomerDetailsByCustomerID_Result GetCustomerListByCustomerID(long CustomerID)
        {
            return objCustomerAccountDetailsDAL.GetCustomerListByCustomerID(CustomerID);
        }

    }
}
