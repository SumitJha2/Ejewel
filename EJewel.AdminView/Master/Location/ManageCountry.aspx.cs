using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.Admin.Master.Location;
using EJewel.Controller.Admin.Master.Location;
using EJewel.Model.Admin.Common;

namespace EJewel.AdminView.Master.Location
{
    public partial class ManageCountry : System.Web.UI.Page
    {

        CountryController objController = new CountryController();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                string countryid = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(countryid))
                {
                    int edit_id = Convert.ToInt32(countryid);
                    if (edit_id > 0)
                    {
                        //get the details of the data
                        CountryModel model = objController.GetCountryList(edit_id, CommonModel.RecordStatus.Both).FirstOrDefault();
                        if (model != null)
                        {
                            //set the data
                            hdnID.Value = model.CountryID.ToString();
                            txtCountryCode.Text = model.CountryCode;
                            txtCountryName.Text = model.CountryName;
                            txtPostalCodeName.Text = model.PostalCodeDisplayName;
                            txtStateDisplayName.Text = model.StateDisplayName;
                            rblMultipleState.SelectedValue = model.HasMultipleState.ToString();
                            rblPostalCodeRequired.SelectedValue = model.IsPostalCodeRequired.ToString();
                            rblStatus.SelectedValue = model.Status.ToString();
                            // ddlStatus.SelectedIndex = model.Status ? 0 : 1;
                        }
                        else
                        {
                            //error
                            //redirect ot list
                            Response.Redirect("/Master/Location/ListCountry.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("/Master/Location/ManageCountry.aspx");
                    }
                }
             
            }
        }


        void ClearField()
        {
            txtCountryCode.Text = "";
            txtCountryName.Text = "";
            txtPostalCodeName.Text = "";
            txtStateDisplayName.Text = "";
            rblMultipleState.SelectedValue = "Yes";
            rblPostalCodeRequired.SelectedValue = "Yes";
            rblStatus.SelectedValue = "Active";

        }

    }
}