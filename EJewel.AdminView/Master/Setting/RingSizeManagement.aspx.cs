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
    public partial class RingSizeManagement : System.Web.UI.Page
    {
        RingSizeController objController = new RingSizeController();
        int _editID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
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

        private void LoadEditValue(int ringSizeId)
        {
            try
            {
                RingSizeModel model = objController.GetRingSizeList(ringSizeId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                if (model != null)
                {
                    hdnID.Value = model.RingSizeId.ToString();
                    ddlSubCategory.Items.FindByValue(model.SubCategoryId.ToString()).Selected = true;
                    ddlStatus.SelectedIndex = model.Status ? 0 : 1;
                    txtSize.Text = model.RingSize.ToString();
                }
                else
                {
                    //redirect to home page
                    Response.Redirect("/Default.aspx?ref=ring_size&status=invalid");
                }
            }
            catch (Exception ex)
            {
                //error
                throw ex;
            }
        }
    }
}