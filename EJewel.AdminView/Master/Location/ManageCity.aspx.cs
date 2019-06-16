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
    public partial class ManageCity : System.Web.UI.Page
    {
        StateController objStateController = new StateController();
        CountryController objCountryController = new CountryController();
        CityController objCityController = new CityController();



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

                        //load primary state
                        string cityid = Request.QueryString["CityId"];
                        if (!string.IsNullOrEmpty(cityid))
                        {

                            //load primary category

                            int edit_id = Convert.ToInt32(cityid);
                            if (edit_id > 0)
                            {
                                //get the details of the data
                                CityModel model = objCityController.GetCityList(edit_id, CommonModel.RecordStatus.Both).FirstOrDefault();
                                if (model != null)
                                {
                                    //set the data
                                    hdnID.Value = model.StateId.ToString();
                                    txtCityCode.Text = model.CityCode;
                                    txtCityName.Text = model.CityName;
                                    ddlCountry.SelectedValue = model.CountryId.ToString();
                                    BindState(Convert.ToInt32(ddlCountry.SelectedValue));
                                    ddlState.SelectedValue = model.StateId.ToString();
                                    rblStatus.SelectedValue = model.Status.ToString();
                                    // ddlStatus.SelectedIndex = model.Status ? 0 : 1;
                                }
                                else
                                {
                                    //error
                                    //redirect ot list
                                    Response.Redirect("/Master/Location/ListCity.aspx");
                                }
                            }
                            else
                            {
                                Response.Redirect("/Master/Location/ListCity.aspx");
                            }
                            //lod status
                        }

                    }

                //lod status

            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCountry.SelectedValue != "")
            {
                BindState(Convert.ToInt32(ddlCountry.SelectedValue));
            }
        }
        void BindState(int CountryID)
        {
            try
            {
                List<StateModel> objStateList = objStateController.GetStateListByCountryID(CountryID, CommonModel.RecordStatus.Enabled);
                if (objStateList.Count > 0)
                {

                    ListHelper.BindList(ddlState, objStateList, "StateId", "StateName", ListHelper.DefaultList);
                }
            }
            catch (Exception ex)
            {
                ErrorLogModel objLogError = new ErrorLogModel();
                objLogError.ErrorMessage = ex.Message;
                objLogError.ErrorSource = ex.Source;
                objLogError.StackTrace = ex.StackTrace;
                objLogError.InnerException = Convert.ToString(ex.InnerException);
                objLogError.LogTime = DateTime.Now;
                objLogError.UserID = Session["loginID"].ToString();
                new ErrorLogController().SetErrorLog(objLogError);
            }

        }
    }
}