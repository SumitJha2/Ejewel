using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//controller
using EJewel.Controller.Admin.Common.Sfm;
using EJewel.Controller.Admin.Master.Category;
using EJewel.Controller.Admin.Product;
using EJewel.Controller.Common;
using EJewel.Controller.Admin.Master.Setting;
//model
using EJewel.Model.Admin.Common.Sfm;
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Master.Category;
using EJewel.Model.Admin.Master.Setting;
using EJewel.Model.Admin.Common;
namespace EJewel.AdminView.Master.Setting
{
    public partial class ListPriceManagement : System.Web.UI.Page
    {
        PriceController objController = new PriceController();
        int _editID = 0;
        PriceModel.PageName _pageName = PriceModel.PageName.None;
        string _view = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            _view = Request.QueryString["view"];
            lnkDetails.NavigateUrl = "/Master/Setting/PriceManagement.aspx?view=" + _view;
            if (!string.IsNullOrEmpty(_view))
            {
                _pageName = objController.GetPageName(_view);
                ltrlHeading.Text = objController.PageName;
                if (_pageName != PriceModel.PageName.None)
                {
                    LoadData();
                }
                else
                {
                    //redirect to default page
                    Response.Redirect("/Default.aspx?ref=price_management&status=invalid");
                }

            }
            else
            {
                //redirect to default page
                Response.Redirect("/Default.aspx?ref=price_management&status=invalid");
            }
        }

        void LoadData()
        {
            try
            {
                dgvDetails.DataSource = objController.GetPriceList(0, CommonModel.RecordStatus.Both, _pageName);
                dgvDetails.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void dgvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //acces the dtaa
                HiddenField hdnID = (HiddenField)e.Row.FindControl("hdnID");
                HyperLink lnkEdit = (HyperLink)e.Row.FindControl("lnkEdit");
                if (hdnID != null)
                {
                    lnkEdit.NavigateUrl = "/Master/Setting/PriceManagement.aspx?id="+hdnID.Value+"&view="+_view;
                }
            }
        }
    }
}