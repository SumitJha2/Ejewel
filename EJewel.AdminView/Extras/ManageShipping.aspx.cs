using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Controller.Admin.Common.Sfm;
// model
using EJewel.Model.Admin.Order;
using EJewel.Model.Admin.Master.Location;
using EJewel.Model.Admin.Common.Sfm;
using EJewel.Model.Admin.Common;
//controller
using EJewel.Controller.Common;
using EJewel.Controller.Admin.Master.Location;
using EJewel.Controller.Admin.Order;


namespace EJewel.AdminView.Order
{
    public partial class ManageShipping : System.Web.UI.Page
    {
        SfmController objSfmController = new SfmController();
        List<SfmModel> objSfmModel = new List<SfmModel>();
        CountryController objCountryController = new CountryController();
        ShippingController objShippingController = new ShippingController();
        int nameId = 0;
        int typeId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("Default.aspx");
            }
            else
            {
                if (Request.QueryString["NameId"] != null)
                {
                    nameId = Convert.ToInt32(Request.QueryString["NameId"]);
                }
                if (Request.QueryString["TypeId"] != null)
                {
                    typeId = Convert.ToInt32(Request.QueryString["TypeId"]);
                }
                if (!IsPostBack)
                {
                    BindShippingName();
                    BindShippingType();
                    if (nameId != 0 && typeId != 0)
                    {
                        LoadCountry(nameId, typeId);
                    }
                    if (Request.QueryString["status"] == "success")
                    {
                        spnMessage.InnerText = "Details saved successfully.";
                    }
                }
            }

        }
        // function used to load country 
        void LoadCountry(int nameId,int typeId)
        {
            // get shipping list country if exist 
            List<ShippingModel> objShippingModel = objShippingController.GetShippingList(nameId, typeId).ToList();
            if (objShippingModel != null && objShippingModel.Count > 0)
            {
                gvCountryPrice.DataSource = objShippingModel;
                gvCountryPrice.DataBind();
                gvCountryPrice.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                // get list of country
                List<CountryModel> objCountryModel = objCountryController.GetCountryList(0, CommonModel.RecordStatus.Enabled);            

                if (objCountryModel != null && objCountryModel.Count > 0)
                {
                    gvCountryPrice.DataSource = objCountryModel;
                    gvCountryPrice.DataBind();
                    gvCountryPrice.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            ddlShippingType.SelectedValue = typeId.ToString();
            ddlShippingName.SelectedValue = nameId.ToString();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                //first delete the existing details for same nameId and TypeId        
                ShippingModel objShippingDelModel = new ShippingModel();
                objShippingController.DeleteShippingDetails(nameId, typeId);
                foreach (GridViewRow gv in gvCountryPrice.Rows)
                {
                    ShippingModel objShippingModel = new ShippingModel();
                    HiddenField hdnCountryId = (HiddenField)gv.FindControl("hdnCountryId");
                    TextBox txtPrice = (TextBox)gv.FindControl("txtPrice");
                    DropDownList ddlStatus = (DropDownList)gv.FindControl("ddlStatus");
                    objShippingModel.ShippingNameId = nameId;
                    objShippingModel.ShippingTypeId = typeId;
                    objShippingModel.CountryId = Convert.ToInt32(hdnCountryId.Value);
                    objShippingModel.Price = Convert.ToDouble(txtPrice.Text);
                    objShippingModel.Status = Convert.ToInt32(ddlStatus.SelectedValue) == 1 ? true : false;
                    objShippingController.SaveUpdateShipment(objShippingModel);
                }

                Response.Redirect("/Order/ManageShipping.aspx?NameId=" + nameId + "&TypeId=" + typeId + "&status=success");
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
        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (ddlShippingName.SelectedValue != "0" && ddlShippingType.SelectedValue != "0")
            {
                Response.Redirect("/Order/ManageShipping.aspx?NameId=" + ddlShippingName.SelectedValue + "&TypeId=" + ddlShippingType.SelectedValue);
            }
            else
            { 
            //Message
            }
         
        }
        public void BindShippingName()
        {
            try
            {
                objSfmModel = objSfmController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.ShippingName);
                if (objSfmModel != null && objSfmModel.Count > 0)
                {
                    ddlShippingName.DataSource = objSfmModel;
                    ddlShippingName.DataTextField = "Name";
                    ddlShippingName.DataValueField = "AutoID";
                    ddlShippingName.DataBind();
                }
                ddlShippingName.Items.Insert(0, new ListItem("Please Select", "0"));
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
        public void BindShippingType()
        {
            try
            {
                objSfmModel = objSfmController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.ShippingType);
                //, "AutoID", "Name", ListHelper.DefaultList);
                if (objSfmModel != null && objSfmModel.Count > 0)
                {
                    ddlShippingType.DataSource = objSfmModel;
                    ddlShippingType.DataTextField = "Name";
                    ddlShippingType.DataValueField = "AutoID";
                    ddlShippingType.DataBind();
                }
                ddlShippingType.Items.Insert(0, new ListItem("Please Select", "0"));
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
        protected void gvCountryPrice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
                    DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");
                    string s = hdnStatus.Value;
                    ddlStatus.SelectedIndex = hdnStatus.Value == "True" ? 0 : 1;
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
}