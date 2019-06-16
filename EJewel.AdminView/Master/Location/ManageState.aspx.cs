using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.Admin.Master.Location;
using EJewel.Controller.Common;
using EJewel.Model.Admin.Common;
using EJewel.Controller.Admin.Master.Location;

namespace EJewel.AdminView.Master.Location
{
    public partial class ManageState : System.Web.UI.Page
    {
        CountryController objCountryController = new CountryController();
        StateController objStateController = new StateController();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {


                if (!IsPostBack)
                {
                    ListHelper.BindList(ddlCountry, objCountryController.GetCountryList(0, CommonModel.RecordStatus.Enabled), "CountryID", "CountryName", ListHelper.DefaultList);


                    string stateid = Request.QueryString["StateID"];
                    if (!string.IsNullOrEmpty(stateid))
                    {


                        //load primary category

                        int edit_id = Convert.ToInt32(stateid);
                        if (edit_id > 0)
                        {
                            //get the details of the data
                            StateModel model = objStateController.GetStateList(edit_id, CommonModel.RecordStatus.Both).FirstOrDefault();
                            if (model != null)
                            {
                                //set the data
                                hdnID.Value = model.StateId.ToString();
                                txtStateCode.Text = model.StateCode;
                                txtStateName.Text = model.StateName;
                                ddlCountry.SelectedValue = model.CountryId.ToString();
                                rblStatus.SelectedValue = model.Status.ToString();
                                // ddlStatus.SelectedIndex = model.Status ? 0 : 1;
                            }
                            else
                            {
                                //error
                                //redirect ot list
                                Response.Redirect("/Master/Location/ListState.aspx");
                            }
                        }
                        else
                        {
                            Response.Redirect("/Master/Location/ListState.aspx");
                        }
                        //lod status

                    }

                }
            }
        }
    }
}