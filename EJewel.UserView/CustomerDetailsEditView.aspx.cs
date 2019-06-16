using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.Admin.Master.Location;

using EJewel.Controller.Common;
using EJewel.Model.User;
using EJewel.Controller.User;
using EJewel.Controller.Admin.Master.Location;
using EJewel.DAL;

namespace EJewel.UserView
{
    public partial class CustomerDetailsEditView : System.Web.UI.Page
    {
        StateController objStateController = new StateController();
        CountryController objCountryController = new CountryController();
        CityController objCityController = new CityController();
        ZipCodeController objZipController = new ZipCodeController();
        CustomerAccountDetailsController objCustomerAccountDetailsController = new CustomerAccountDetailsController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtStateName.Visible = true;
                txtCity.Visible = true;
                ddlState.Visible = false;
                ddlCity.Visible = false;
                BindCountry();
                if(Session["RegisterUser"]!=null)
                {
                    BindUserDetails(Convert.ToInt64(Session["RegisterUser"]));
                }
            }

        }
        void BindUserDetails(long customerID)
        {

            if (customerID > 0)
            {

                GetCustomerDetailsByCustomerID_Result GetCustomerListByCustomerID = objCustomerAccountDetailsController.GetCustomerListByCustomerID(customerID);
               // List<CustomerAccountDetailsModel> objCustomerAccountDetailModel = objCustomerAccountDetailsController.GetCustomerListByCustomerID(customerID);


                if (GetCustomerListByCustomerID!=null)
                {
                    hfcustomerID.Value = "";
                    hfcustomerID.Value = GetCustomerListByCustomerID.CustomerDetailsID.ToString();
                    txtAddress.Text = GetCustomerListByCustomerID.CustomerAddress;
                    txtFaxNumber.Text = GetCustomerListByCustomerID.CustomerFaxNumber;
                    txtFirstName.Text =GetCustomerListByCustomerID.CustomerFirstName;
                    txtLastName.Text =GetCustomerListByCustomerID.CustomerLastName;
                    txtMiddleName.Text =GetCustomerListByCustomerID.CustomerMiddleName;
                  
                    ddlCountry.SelectedValue = GetCustomerListByCustomerID.CountryId.ToString();
                    BindFieldByCountryID(Convert.ToInt32(ddlCountry.SelectedValue));
                    BindState(Convert.ToInt32(ddlCountry.SelectedValue));
                    if (txtStateName.Visible == true)
                    {
                        txtStateName.Text = GetCustomerListByCustomerID.StateName;
                    }
                    else
                    {
                        ddlState.SelectedValue = GetCustomerListByCustomerID.StateId.ToString();
                    }
                    BindZipCode(Convert.ToInt32(ddlCountry.SelectedValue));



                    ddlZipCode.SelectedValue = GetCustomerListByCustomerID.ZipCodeID.ToString();
                    BindCity(Convert.ToInt32(ddlCountry.SelectedValue), Convert.ToInt32(ddlState.SelectedValue));

                    if (txtCity.Visible == true)
                    {
                      txtCity.Text = GetCustomerListByCustomerID.CityName;
                    }
                    else
                    {
                        ddlCity.SelectedValue = GetCustomerListByCustomerID.CityId.ToString();
                    }

                    if (GetCustomerListByCustomerID.IsDefaultAddress == true)
                    {
                        chkboxDefaultAddress.Checked = true;
                    }
                    else
                    {
                        chkboxDefaultAddress.Checked = false;
                    }
                    txtPhoneNumber.Text = GetCustomerListByCustomerID.CustomerPhoneNumber;
                  
                }
            }

        }




        void BindCountry()
        {
            try
            {
                List<CountryModel> objCountrylist = objCountryController.GetCountryList(0, CommonModel.RecordStatus.Enabled);
                if (objCountrylist.Count > 0)
                {
                    ddlCountry.DataSource = objCountrylist;
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataValueField = "CountryID";
                    ddlCountry.DataBind();
                }
                else
                {
                    ddlCountry.DataSource = null;
                    ddlCountry.DataBind();
                }
                ddlCountry.Items.Insert(0, new ListItem("Select", "0"));


                BindFieldByCountryID(Convert.ToInt32(ddlCountry.SelectedValue));


                // ListHelper.BindList(ddlCountry, objCountryController.GetCountryList(0, CommonModel.RecordStatus.Enabled), "CountryID", "CountryName", ListHelper.DefaultList);
            }
            catch (Exception ex)
            {
                ErrorLogModel objLogError = new ErrorLogModel();
                objLogError.ErrorMessage = ex.Message;
                objLogError.ErrorSource = ex.Source;
                objLogError.StackTrace = ex.StackTrace;
                objLogError.InnerException = Convert.ToString(ex.InnerException);
                objLogError.LogTime = DateTime.Now;
                objLogError.UserID = "1";
                new ErrorLogController().SetErrorLog(objLogError);

            }

        }

        void BindState(int countryID)
        {
            try
            {
                if (countryID != 0)
                {
                    List<StateModel> objStatelist = objStateController.GetStateListByCountryID(countryID, CommonModel.RecordStatus.Enabled);
                    if (objStatelist.Count > 0)
                    {
                        ddlState.DataSource = objStatelist;
                        ddlState.DataTextField = "StateName";
                        ddlState.DataValueField = "StateID";
                        ddlState.DataBind();
                    }
                    else
                    {
                        ddlState.DataSource = null;
                        ddlState.DataBind();
                    }
                    ddlCity.Items.Clear();
                    ddlState.Items.Insert(0, new ListItem("Select", "0"));
                    ddlCity.Visible = true;
                    txtCity.Visible = false;
                }
                else
                {
                    ddlCity.Visible = false;
                    txtCity.Visible = true;
                }


                //ListHelper.BindList(ddlState, objStateController.GetStateListByCountryID(countryID, CommonModel.RecordStatus.Enabled), "StateID", "StateName", ListHelper.DefaultList);
            }
            catch (Exception ex)
            {
                ErrorLogModel objLogError = new ErrorLogModel();
                objLogError.ErrorMessage = ex.Message;
                objLogError.ErrorSource = ex.Source;
                objLogError.StackTrace = ex.StackTrace;
                objLogError.InnerException = Convert.ToString(ex.InnerException);
                objLogError.LogTime = DateTime.Now;
                objLogError.UserID = "1";
                new ErrorLogController().SetErrorLog(objLogError);

            }

        }

        void BindCity(int countryID, int StateID)
        {
            try
            {

                if (countryID != 0 && StateID != 0)
                {
                    List<CityModel> objCitylist = objCityController.GetCityList(countryID, StateID, 0, CommonModel.RecordStatus.Enabled);
                    if (objCitylist.Count > 0)
                    {
                        ddlCity.DataSource = objCitylist;
                        ddlCity.DataTextField = "CityName";
                        ddlCity.DataValueField = "CityID";
                        ddlCity.DataBind();
                    }
                    else
                    {
                        ddlCity.DataSource = null;
                        ddlCity.DataBind();
                    }
                    ddlCity.Visible = true;
                    txtCity.Visible = false;
                    ddlCity.Items.Insert(0, new ListItem("Select", "0"));
                }
                else
                {
                    ddlCity.Items.Clear();
                    ddlCity.Visible = false;
                    txtCity.Visible = true;

                }




                // ListHelper.BindList(ddlCity, objCityController.GetCityList(countryID,StateID,0,CommonModel.RecordStatus.Enabled), "CityID", "CityName", ListHelper.DefaultList);
            }
            catch (Exception ex)
            {
                ErrorLogModel objLogError = new ErrorLogModel();
                objLogError.ErrorMessage = ex.Message;
                objLogError.ErrorSource = ex.Source;
                objLogError.StackTrace = ex.StackTrace;
                objLogError.InnerException = Convert.ToString(ex.InnerException);
                objLogError.LogTime = DateTime.Now;
                objLogError.UserID = "1";
                new ErrorLogController().SetErrorLog(objLogError);

            }

        }

        void BindZipCode(int countryID)
        {
            try
            {

                if (countryID != 0)
                {

                    List<ZipCodeModel> objZiplist = objZipController.GetZipCodeByCountryID(countryID);
                    if (objZiplist.Count > 0)
                    {
                        ddlZipCode.DataSource = objZiplist;
                        ddlZipCode.DataTextField = "ZipCode";
                        ddlZipCode.DataValueField = "ZipCodeID";
                        ddlZipCode.DataBind();
                    }
                    else
                    {
                        ddlZipCode.DataSource = null;
                        ddlZipCode.DataBind();
                    }
                    ddlZipCode.Items.Insert(0, new ListItem("Select", "0"));
                }
                else
                {
                    ddlZipCode.Items.Clear();

                }

                //ListHelper.BindList(ddlZipCode, objZipController.GetZipCodeByCountryID(countryID), "ZipCodeID","ZipCode", ListHelper.DefaultList);
            }
            catch (Exception ex)
            {
                ErrorLogModel objLogError = new ErrorLogModel();
                objLogError.ErrorMessage = ex.Message;
                objLogError.ErrorSource = ex.Source;
                objLogError.StackTrace = ex.StackTrace;
                objLogError.InnerException = Convert.ToString(ex.InnerException);
                objLogError.LogTime = DateTime.Now;
                objLogError.UserID = "1";
                new ErrorLogController().SetErrorLog(objLogError);

            }

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            CustomerAccountDetailsController objCustomerAccountDetailsController = new CustomerAccountDetailsController();
            try
            {
                CustomerAccountDetailsModel objCustomerAccountDetailsModel = new CustomerAccountDetailsModel();
                if (hfcustomerID.Value != "")
                {
                    objCustomerAccountDetailsModel.CustomerDetailsID = Convert.ToInt32(hfcustomerID.Value);
                }
                objCustomerAccountDetailsModel.CustomerID = Session["RegisterUser"].ToString() == string.Empty ? 0 : Convert.ToInt64(Session["RegisterUser"]);
                objCustomerAccountDetailsModel.CustomerFirstName = txtFirstName.Text == string.Empty ? null : txtFirstName.Text.ToString().Trim();
                objCustomerAccountDetailsModel.CustomerMiddleName = txtMiddleName.Text == string.Empty ? null : txtMiddleName.Text.ToString().Trim();
                objCustomerAccountDetailsModel.CustomerLastName = txtLastName.Text == string.Empty ? null : txtLastName.Text.ToString().Trim();
                objCustomerAccountDetailsModel.CustomerAddress = txtAddress.Text == string.Empty ? null : txtAddress.Text.ToString().Trim();
                objCustomerAccountDetailsModel.CustomerFaxNumber = txtFaxNumber.Text == string.Empty ? null : txtFaxNumber.Text.ToString();
                objCustomerAccountDetailsModel.CountryId = ddlCountry.SelectedValue == string.Empty ? 0 : Convert.ToInt32(ddlCountry.SelectedValue);
                int stateID = 0;
                if (txtStateName.Visible == true)
                {

                    List<StateModel> objstatelist = objStateController.GetStateIDByStateName(txtStateName.Text);
                    if (objstatelist.Count > 0)
                    {
                        stateID = objstatelist[0].StateId;
                       
                    }
                    else
                    {
                        StateModel objstateModel = new StateModel();
                        objstateModel.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
                        objstateModel.CreatedDate = DateTime.Now;
                        objstateModel.StateCode = "";
                        objstateModel.StateName = txtStateName.Text;
                        objstateModel.Status = true;
                        objstateModel.CreatedBy = 1;
                        stateID = objStateController.SaveUpdateState(objstateModel).StateId;
                    }
                    objCustomerAccountDetailsModel.StateId = stateID.ToString() == string.Empty ? 0 : stateID;
                }
                else
                {
                    objCustomerAccountDetailsModel.StateId = ddlState.SelectedValue == string.Empty ? 0 : Convert.ToInt32(ddlState.SelectedValue);
                }
                int cityID = 0;
                if (txtCity.Visible == true)
                {

                    List<CityModel> objCityList = objCityController.GetCityIDByCityName(Convert.ToInt32(ddlCountry.SelectedValue), stateID, txtCity.Text);
                         if(objCityList.Count>0)
                         {
                             cityID=objCityList[0].CityId;
                         }
                         else
                         {
                            CityModel objCityModel = new CityModel();
                            objCityModel.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
                            objCityModel.StateId = stateID;
                            objCityModel.CityName = txtCity.Text;
                            objCityModel.CityCode = "";
                            objCityModel.CreatedBy = 1;
                            objCityModel.CreatedDate = DateTime.Now;
                            objCityModel.Status = true;
                            cityID = objCityController.SaveUpdateCity(objCityModel).CityId;
                         }
                        objCustomerAccountDetailsModel.CityId = cityID.ToString() == string.Empty ? 0 : cityID;
                }
                else
                {
                    objCustomerAccountDetailsModel.CityId = ddlCity.SelectedValue == string.Empty ? 0 : Convert.ToInt32(ddlCity.SelectedValue);

                }
                objCustomerAccountDetailsModel.ZipCodeID = ddlZipCode.SelectedValue == string.Empty ? 0 : Convert.ToInt32(ddlZipCode.SelectedValue);
                objCustomerAccountDetailsModel.CustomerPhoneNumber = txtPhoneNumber.Text == string.Empty ? null : txtPhoneNumber.Text.ToString().Trim();
                objCustomerAccountDetailsModel.ModifiedDateTime = DateTime.Now;
                if (chkboxDefaultAddress.Checked == true)
                {
                    objCustomerAccountDetailsModel.IsDefaultAddress = true;
                }
                else
                {
                    objCustomerAccountDetailsModel.IsDefaultAddress = false;
                }

                objCustomerAccountDetailsController.SaveUpdateCustomerDetails(objCustomerAccountDetailsModel);

            }
            catch (Exception ex)
            {
                ErrorLogModel objLogError = new ErrorLogModel();
                objLogError.ErrorMessage = ex.Message;
                objLogError.ErrorSource = ex.Source;
                objLogError.StackTrace = ex.StackTrace;
                objLogError.InnerException = Convert.ToString(ex.InnerException);
                objLogError.LogTime = DateTime.Now;
                objLogError.UserID = "1";
                new ErrorLogController().SetErrorLog(objLogError);

            }
            finally
            {
                lblmessage.Text = "Customer Details Addead Sucessfully";
                ClearField();
            }
        }
        void ClearField()
        {
            txtAddress.Text = "";
            ddlCountry.SelectedValue = "0";
            ddlState.Items.Clear();
            ddlZipCode.Items.Clear();
            ddlCity.Items.Clear();
            txtFaxNumber.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMiddleName.Text = "";
            chkboxDefaultAddress.Checked = false;
            txtPhoneNumber.Text = "";
            txtStateName.Text = "";
            txtCity.Text = "";
            txtCity.Visible = true;
            txtStateName.Visible = true;
            ddlCity.Visible = false;
            ddlState.Visible = false;
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCity.Text = "";
            txtStateName.Text = "";
            if (ddlCountry.SelectedValue != "")
            {
                BindState(Convert.ToInt32(ddlCountry.SelectedValue));
                BindZipCode(Convert.ToInt32(ddlCountry.SelectedValue));
                BindFieldByCountryID(Convert.ToInt32(ddlCountry.SelectedValue));
            }

        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCity.Text = "";
            if (ddlCountry.SelectedValue != "" && ddlState.SelectedValue != "")
            {
                BindCity(Convert.ToInt32(ddlCountry.SelectedValue), Convert.ToInt32(ddlState.SelectedValue));
            }
        }
        void BindFieldByCountryID(int countryID)
        {

            if (countryID > 0)
            {
                List<CountryModel> objCountryList = objCountryController.GetCountryList(countryID, CommonModel.RecordStatus.Enabled);


                txtPhoneNumber.Text = "";
                if (objCountryList.Count > 0)
                {
                    PostalCodeDisplayName.Text = objCountryList[0].PostalCodeDisplayName;
                    lblStateName.Text = objCountryList[0].StateDisplayName;

                    if (objCountryList[0].HasMultipleState == true)
                    {
                        ddlState.Visible = true;
                        txtStateName.Visible = false;
                        ddlCity.Visible = false;
                        txtCity.Visible = true;

                        ddlCity.Items.Clear();
                        // BindState(Convert.ToInt32(ddlCountry.SelectedValue));
                    }
                    else if (objCountryList[0].HasMultipleState == false)
                    {
                        ddlState.Items.Clear();
                        ddlCity.Items.Clear();
                        ddlState.Visible = false;
                        ddlCity.Visible = false;
                        txtStateName.Visible = true;
                        txtCity.Visible = true;
                    }
                    //if (objCountryList[0].IsPostalCodeRequired == true)
                    //{
                    //    PostalCodeDisplayName.Text = "*" + PostalCodeDisplayName.Text;
                    //}
                    //else
                    //{
                    //    PostalCodeDisplayName.Text = PostalCodeDisplayName.Text;
                    //}

                }
                else
                {
                    PostalCodeDisplayName.Text = "Zip Code";
                    lblStateName.Text = "State";
                    txtStateName.Visible = true;
                    txtStateName.Visible = true;
                    ddlState.Visible = false;

                }

            }
            else
            {
                ddlCity.Items.Clear();
                ddlState.Items.Clear();
                PostalCodeDisplayName.Text = "Zip Code";
                lblStateName.Text = "State";
                txtStateName.Visible = true;
                ddlState.Visible = false;
                ddlCity.Visible = false;
                txtCity.Visible = true;
            }

        }
    }
}