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
    public partial class PriceManagement : System.Web.UI.Page
    {
        PriceController objController = new PriceController();
        int _editID = 0;
        PriceModel.PageName _pageName = PriceModel.PageName.None;

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string view = Request.QueryString["view"];
            if (!string.IsNullOrEmpty(view))
            {
                _pageName = objController.GetPageName(view);
                ltrlHeading.Text = objController.PageName;
                if (_pageName != PriceModel.PageName.None)
                {
                    //load the default data
                    //load the category
                    ListHelper.BindList(ddlSubCategory, new CategoryController().GetProductCategoryList(), "CategoryID", "CategoryName", ListHelper.DefaultList);
                    //load status
                    ListHelper.BindList(ddlStatus, ListHelper.GetStatusSource(), "Value", "Text", null);
                    //edit
                    if (!string.IsNullOrEmpty(id))
                    {
                        _editID = Convert.ToInt32(id);
                        this.LoadEditValue(_editID);
                    }
                }
                else
                {
                    //redirect to default page
                    Response.Redirect("/Default.aspx&ref=price_management&status=invalid");
                }
               
            }
            else
            {
                //redirect to default page
                Response.Redirect("/Default.aspx&ref=price_management&status=invalid");
            }
            
        }

        /*
         * Partha Ranjan
         * @ 07-02-13
         * This for edit mode
         * */
        private void LoadEditValue(int settingPriceId)
        {
            try
            {
                PriceModel model = objController.GetPriceList(settingPriceId,CommonModel.RecordStatus.Both,_pageName).FirstOrDefault();
                if (model != null)
                {
                    hdnID.Value = model.AutoID.ToString();
                    ddlSubCategory.Items.FindByValue(model.SubCategoryId.ToString()).Selected = true;
                    ddlStatus.SelectedIndex = model.Status ? 0 : 1;
                    txtPrice.Text = model.Price.ToString();
                }
            }
            catch (Exception ex)
            {
                //error
            }
        }

    }
}