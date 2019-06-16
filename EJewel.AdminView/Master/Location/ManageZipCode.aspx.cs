using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.Admin.Master.Location;
using EJewel.Model.Admin.Common;
using EJewel.Controller.Common;
using EJewel.Controller.Admin.Master.Location;

namespace EJewel.AdminView.Master.Location
{
    public partial class ManageZipCode : System.Web.UI.Page
    {
        CountryController objCountryController = new CountryController();
        ZipCodeController objZipCodeController = new ZipCodeController();

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



                    string zipcodeid = Request.QueryString["ZipCodeID"];
                    if (!string.IsNullOrEmpty(zipcodeid))
                    {




                        //load primary category

                        int edit_id = Convert.ToInt32(zipcodeid);
                        if (edit_id > 0)
                        {
                            //get the details of the data
                            ZipCodeModel model = objZipCodeController.GetZipCodeListByZipCodeID(edit_id, CommonModel.RecordStatus.Both).FirstOrDefault();
                            if (model != null)
                            {
                                //set the data
                                hdnID.Value = model.ZipCodeID.ToString();
                                txtZipCode.Text = model.ZipCode;
                                txtZipCodeRegularExp.Text = model.ZipCodeRegularExp;
                                txtZipCodeToolTip.Text = model.ZipCodeToolTip;
                                ddlCountry.SelectedValue = model.CountryID.ToString();
                                rblStatus.SelectedValue = model.Status.ToString();
                                // ddlStatus.SelectedIndex = model.Status ? 0 : 1;
                            }
                            else
                            {
                                //error
                                //redirect ot list
                                Response.Redirect("/Master/Location/ListZipCode.aspx");
                            }
                        }
                        else
                        {
                            Response.Redirect("/Master/Location/ListZipCode.aspx");
                        }
                        //lod status

                    }
                }
            }
        }
    }
}