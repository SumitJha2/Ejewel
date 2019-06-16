using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.Admin.Master.Location;
using EJewel.Controller.Common;
using EJewel.Controller.Admin.Master.Location;

namespace EJewel.UserView.Checkout
{
    public partial class billingaddress : System.Web.UI.Page
    {
        StateController objStateController = new StateController();
        CountryController objCountryController = new CountryController();
        ZipCodeController objZipcodelist = new ZipCodeController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //load primary state
                txtCountryCode.Visible = false;
                ddlStateName.Visible = true;
                txtStateName.Visible = true;
                BindCountry();
                BindFieldByCountryID(Convert.ToInt32(ddlCountry.SelectedValue));


            }
        }
        void BindCountry()
        {
            ListHelper.BindList(ddlCountry, objCountryController.GetCountryList(0,CommonModel.RecordStatus.Enabled), "CountryID", "CountryName");

        }


        void BindState(int CountryID)
        {
            List<StateModel> objStateList = objStateController.GetStateListByCountryID(CountryID, CommonModel.RecordStatus.Enabled);
            if (objStateList.Count > 0)
            {
                ListHelper.BindList(ddlStateName, objStateList, "StateId", "StateName", ListHelper.DefaultList);

            }
            else
            {

                ListHelper.BindList(ddlStateName, null, "StateId", "StateName", ListHelper.DefaultList);
            }

        }



        void BindFieldByCountryID(int countryID)
        {

            if (countryID != 0)
            {
                List<CountryModel> objCountryList = objCountryController.GetCountryList(countryID, CommonModel.RecordStatus.Enabled);

                txtCountryCode.Text = "";
                txtIntlNumber.Text = "";
                txtPhoneNumber.Text = "";
                lblCountryCode.Text = "";
                lblZipCode.Text = "";
                lblState.Text = "";
                if (objCountryList.Count > 0)
                {
                    PostalCodeDisplayName.Text = objCountryList[0].PostalCodeDisplayName;
                    lblStateName.Text = objCountryList[0].StateDisplayName;

                    if (objCountryList[0].HasMultipleState == true)
                    {
                        ddlStateName.Visible = true;
                        txtStateName.Visible = false;
                        BindState(Convert.ToInt32(ddlCountry.SelectedValue));
                    }
                    else if (objCountryList[0].HasMultipleState == false)
                    {
                        ddlStateName.Visible = false;
                        txtStateName.Visible = true;
                    }
                    if (objCountryList[0].CountryCode != "")
                    {
                        txtCountryCode.Visible = true;
                    }
                    else
                    {
                        txtCountryCode.Visible = false;
                    }
                    if (objCountryList[0].IsPostalCodeRequired == true)
                    {
                        PostalCodeDisplayName.Text = "*" + PostalCodeDisplayName.Text;

                    }
                    else
                    {
                        PostalCodeDisplayName.Text = PostalCodeDisplayName.Text;

                    }

                }
            }

        }


        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindState(Convert.ToInt32(ddlCountry.SelectedValue));
            BindFieldByCountryID(Convert.ToInt32(ddlCountry.SelectedValue));
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {

            List<CountryModel> objCountryList = objCountryController.GetCountryList(Convert.ToInt32(ddlCountry.SelectedValue), CommonModel.RecordStatus.Enabled);
            if (objCountryList[0].CountryCode != "")
            {
                if (txtCountryCode.Text != "")
                {
                    for (int i = 0; i < objCountryList.Count; i++)
                    {
                        if (txtCountryCode.Text == objCountryList[i].CountryCode)
                        {
                            lblCountryCode.Text = "";
                        }
                        else
                        {
                            lblCountryCode.Text = "Please Enter Valid Country Code";
                        }

                    }
                }
                else
                {
                    lblCountryCode.Text = "Please Enter Country Code";

                }
            }
            else
            {
                lblCountryCode.Text = "";
            }
            if (objCountryList[0].IsPostalCodeRequired == true)
            {

                List<ZipCodeModel> objzipcodemodel = objZipcodelist.GetZipCodeByCountryID(Convert.ToInt32(ddlCountry.SelectedValue));
                if (objzipcodemodel.Count > 0)
                {
                    for (int i = 0; i < objzipcodemodel.Count; i++)
                    {
                        if (txtZipCode.Text == objzipcodemodel[i].ZipCode)
                        {
                            lblZipCode.Text = "";
                        }
                        else
                        {
                            lblZipCode.Text = "Please Enter Valid " + objCountryList[0].PostalCodeDisplayName + "";
                        }
                    }
                }
                else
                {
                    lblZipCode.Text = " ";
                }
            }
            else
            {
                PostalCodeDisplayName.Text = PostalCodeDisplayName.Text;
                lblZipCode.Text = "";
            }
            if (objCountryList[0].HasMultipleState == true)
            {
                if (ddlStateName.SelectedValue == "")
                {
                    lblState.Text = "Please Select State";
                }
                else
                {
                    lblState.Text = "";
                }
            }
            else
            {
                lblState.Text = "";
            }

        }
    }
}