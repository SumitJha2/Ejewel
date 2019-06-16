using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.User;

namespace EJewel.DAL.User
{
  public class CustomerAccountDetailsDAL
    {
        EJewelEntities objEntity = new EJewelEntities();


        //Save & Update CustomerDetails
        public CustomerAccountDetailsModel SaveUpdateCustomerDetails(CustomerAccountDetailsModel objCustomerAccountDetailsModel)
        {
            if (objCustomerAccountDetailsModel.CustomerDetailsID > 0)
            {
                ej_Customer_Account_Details objcustomerAccountDetails = objEntity.ej_Customer_Account_Details.Where(tbl => tbl.CustomerDetailsID == objCustomerAccountDetailsModel.CustomerDetailsID).FirstOrDefault();
                if (objcustomerAccountDetails != null)
                {
                    objcustomerAccountDetails.CustomerID = objCustomerAccountDetailsModel.CustomerID;
                    objcustomerAccountDetails.CustomerFirstName = objCustomerAccountDetailsModel.CustomerFirstName;
                    objcustomerAccountDetails.CustomerLastName = objCustomerAccountDetailsModel.CustomerLastName;
                    objcustomerAccountDetails.CustomerAddress = objCustomerAccountDetailsModel.CustomerAddress;
                    objcustomerAccountDetails.CustomerFaxNumber = objCustomerAccountDetailsModel.CustomerFaxNumber;
                    objcustomerAccountDetails.CountryId = objCustomerAccountDetailsModel.CountryId;
                    objcustomerAccountDetails.StateId = objCustomerAccountDetailsModel.StateId;
                    objcustomerAccountDetails.CityId = objCustomerAccountDetailsModel.CityId;
                    objcustomerAccountDetails.ZipCodeID = objCustomerAccountDetailsModel.ZipCodeID;
                    objcustomerAccountDetails.IsDefaultAddress = objCustomerAccountDetailsModel.IsDefaultAddress;
                    objcustomerAccountDetails.CustomerAccountModifiedDateTime = objCustomerAccountDetailsModel.ModifiedDateTime;
                    objcustomerAccountDetails.CustomerPhoneNumber = objCustomerAccountDetailsModel.CustomerPhoneNumber;
                    objEntity.SaveChanges();
                }

            }
            else
            {

                ej_Customer_Account_Details objcustomerAccountDetails = new ej_Customer_Account_Details()
                {
                    CustomerDetailsID = objCustomerAccountDetailsModel.CustomerDetailsID,
                    CustomerID = objCustomerAccountDetailsModel.CustomerID,
                    CustomerFirstName = objCustomerAccountDetailsModel.CustomerFirstName,
                    CustomerMiddleName = objCustomerAccountDetailsModel.CustomerMiddleName,
                    CustomerLastName = objCustomerAccountDetailsModel.CustomerLastName,
                    CustomerAddress = objCustomerAccountDetailsModel.CustomerAddress,
                    CustomerFaxNumber = objCustomerAccountDetailsModel.CustomerFaxNumber,
                    CityId = objCustomerAccountDetailsModel.CityId,
                    StateId = objCustomerAccountDetailsModel.StateId,
                    CountryId = objCustomerAccountDetailsModel.CountryId,
                    ZipCodeID = objCustomerAccountDetailsModel.ZipCodeID,
                    CustomerPhoneNumber = objCustomerAccountDetailsModel.CustomerPhoneNumber,
                    CustomerAccountModifiedDateTime = objCustomerAccountDetailsModel.ModifiedDateTime,
                    IsDefaultAddress = objCustomerAccountDetailsModel.IsDefaultAddress

                };
                objEntity.AddToej_Customer_Account_Details(objcustomerAccountDetails);
                objEntity.SaveChanges();
                objCustomerAccountDetailsModel.CustomerDetailsID = objcustomerAccountDetails.CustomerDetailsID;
            }
            return objCustomerAccountDetailsModel;
        }



        //Get CustomerDetails By CustomerID

        //public List<CustomerAccountDetailsModel> GetCustomerListByCustomerID(long customerID)
        //{
        //    List<CustomerAccountDetailsModel> objCustomerAccountModelList = new List<CustomerAccountDetailsModel>();
        //    List<ej_Customer_Account_Details> objCustomerAccountlist = null;



        //    if (customerID > 0)
        //    {
        //        objCustomerAccountlist =objEntity.ej_Customer_Account_Details.Where(tbl => tbl.CustomerID == customerID).ToList();

        //    }

        //    if (objCustomerAccountlist != null)
        //    {
        //        objCustomerAccountModelList = (from CustomerAccountDetails in objCustomerAccountlist

        //                                       join city in objEntity.ej_City on CustomerAccountDetails.CityId   equals city.CityId into group1
        //                                       from g1 in group1.DefaultIfEmpty()
                                              
        //                                       join state in objEntity.ej_State on CustomerAccountDetails.StateId equals state.StateId into group2
        //                                       from g2 in group2.DefaultIfEmpty()

        //                                       //join country in objEntity.ej_Country on CustomerAccountDetails.CountryId equals country.CountryId

        //                                       join zipcode in objEntity.ej_ZipCode on CustomerAccountDetails.ZipCodeID equals zipcode.ZipCodeID
        //                                       into group3 from g3 in group3.DefaultIfEmpty()

        //                                       join country in objEntity.ej_Country on CustomerAccountDetails.CountryId equals country.CountryId
        //                                       into group4 from g4 in group4.DefaultIfEmpty()

        //                                       select new CustomerAccountDetailsModel()
        //                                       {
        //                                           CustomerID = CustomerAccountDetails.CustomerID,
        //                                           CustomerFirstName = CustomerAccountDetails.CustomerFirstName,
        //                                           CustomerMiddleName = CustomerAccountDetails.CustomerMiddleName,
        //                                           CustomerLastName = CustomerAccountDetails.CustomerLastName,
        //                                           CustomerAddress = CustomerAccountDetails.CustomerAddress,
        //                                           CustomerFaxNumber = CustomerAccountDetails.CustomerFaxNumber != null ? null : CustomerAccountDetails.CustomerFaxNumber,

        //                                           CityId = Convert.ToInt32(CustomerAccountDetails.CityId),
        //                                           CityName =g1!=null?"0":g1.CityName,

        //                                           StateId = Convert.ToInt32(CustomerAccountDetails.StateId),
        //                                           StateName =g2!=null?"0":g2.StateName,

        //                                           CountryId = Convert.ToInt32(CustomerAccountDetails.CountryId),
        //                                           CountryName = g4!=null?"0":g4.CountryName,

        //                                           ZipCodeID = Convert.ToInt32(CustomerAccountDetails.ZipCodeID),
        //                                          // ZipCode =g3!=null?"0":g3.ZipCode,

        //                                           CustomerPhoneNumber = CustomerAccountDetails.CustomerPhoneNumber,

        //                                           IsDefaultAddress = Convert.ToBoolean(CustomerAccountDetails.IsDefaultAddress),

        //                                           ModifiedDateTime = Convert.ToDateTime(CustomerAccountDetails.CustomerAccountModifiedDateTime)

        //                                       }).ToList();

        //    }
        //    return objCustomerAccountModelList;
        //}

        public GetCustomerDetailsByCustomerID_Result GetCustomerListByCustomerID(long customerID)
        {
            List<GetCustomerDetailsByCustomerID_Result> lstModels = objEntity.GetCustomerDetailsByCustomerID(customerID).ToList();
            if (lstModels != null)
            {
                return lstModels.FirstOrDefault();
            }
            return null;

        }


    }
}
