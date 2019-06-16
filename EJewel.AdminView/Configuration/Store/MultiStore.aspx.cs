using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Controller.Admin.Configuration.Store;
using EJewel.Model.Admin.Configuration.Store;
using EJewel.Controller.Admin.Configuration.Currency;
using EJewel.Model.Admin.Configuration.Currency;

using EJewel.Controller.Common;


namespace EJewel.AdminView.Configuration.Store
{
    public partial class MultiStore : System.Web.UI.Page
    {
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
                    BindCurrency(0);
                    if (Request.QueryString["EID"] != null)
                    {
                        txtURL.Enabled = false;
                        GetMultiStore(Convert.ToInt32(Request.QueryString["EID"]));

                    }
                }
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MultiStoreController objController = new MultiStoreController();
                MultiStoreModel model = new MultiStoreModel();
                model.StoreName = txtName.Text;
                model.StoreUrl = txtURL.Text.Trim();
                model.DefaultCurrency = Convert.ToInt32(ddlCurrency.SelectedValue);
                if (Convert.ToInt32(dd1Status.SelectedValue) == 1)
                {
                    model.Status = true;
                }
                else
                {
                    model.Status = false;
                }
                if (Request.QueryString["EID"] != null)
                {
                    model.StoreID = Convert.ToInt32(Request.QueryString["EID"]);
                }
                if (!objController.StoreExist(model))
                {
                    objController.SaveUpdateStore(model);
                }
                Response.Redirect("/Configuration/Store/ListMultiStore.aspx");
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
        private void BindCurrency(int currencyid)
        {
            try
            {
                CurrencyController objController = new CurrencyController();
                List<CurrencyModel> model = objController.GetCurrency(currencyid);
                if (model != null)
                {
                    ddlCurrency.DataSource = model;
                    ddlCurrency.DataTextField = "Title";
                    ddlCurrency.DataValueField = "CurrencyID";
                    ddlCurrency.DataBind();
                }
                ddlCurrency.Items.Insert(0, new ListItem("Please Select", "0"));
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
        private void GetMultiStore(int storeid)
        {
            try
            {
                MultiStoreController objController = new MultiStoreController();
                MultiStoreModel model = objController.GetMultiStore(storeid).FirstOrDefault();
                txtName.Text = model.StoreName;
                txtURL.Text = model.StoreUrl;
                ddlCurrency.SelectedValue = model.DefaultCurrency.ToString();
                dd1Status.SelectedValue = model.Status.ToString();
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