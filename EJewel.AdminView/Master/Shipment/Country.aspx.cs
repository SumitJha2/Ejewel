using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Controller.Common;
using EJewel.Controller.Admin.Master.Shipment;
using EJewel.Model.Admin.Master.Shipment;
using EJewel.Model.Admin.Common;

namespace EJewel.AdminView.Master.Shipment
{
    public partial class Country : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];                
                ListHelper.BindList(ddlStatus, ListHelper.GetStatusSource(), "Value", "Text", null);
                if (id != null)
                {
                    int countryid = Convert.ToInt32(id);

                    BindEditData(countryid);
                }
               
            }

        }
        public void BindEditData(int countryid)
        {

            CountryModel model = new CountryController().ListCountry(countryid, CommonModel.RecordStatus.Enabled).FirstOrDefault();
            if (model != null)
            {
                txtCountryName.Text = model.CountryName;
                txtCountryCode.Text = model.CountryCode;
                hdnID.Value = model.CountryId.ToString();
                ddlStatus.SelectedIndex = model.Status == true ? 1 : 0;

            }

        }
      
    }
}