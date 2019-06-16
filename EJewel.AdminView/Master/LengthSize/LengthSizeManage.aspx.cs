using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using EJewel.Model.Admin.Common.SingleField;
using EJewel.Model.Admin.Master.Category;
using EJewel.Model.Admin.Master.Metal;
//controller
using EJewel.Controller.Admin.Master.Category;
using EJewel.Controller.Admin.Master.Metal;
using EJewel.Controller.Common;
using EJewel.Controller.Admin.Common.SingleField;

namespace EJewel.AdminView.Master.LengthSize
{
    public partial class LengthSizeManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //load the category
                //ListHelper.BindList(ddlCategory, new CategoryController().GetProductCategoryList(), "CategoryID", "CategoryName", ListHelper.DefaultList);
                //metal
                ListHelper.BindList(ddlMetal, new MetalTypeController().GetMetalTypeList(0, Model.Admin.Common.CommonModel.RecordStatus.Enabled), "MetalTypeId", "MetalTypeNamePrice", ListHelper.DefaultList);
                //unit
               // ListHelper.BindList(dd, new SingleFieldController().GetSingleFieldList(0, Model.Admin.Common.CommonModel.RecordStatus.Enabled, SingleFieldModel.PageName.UnitMaster), "AutoID", "Name", new ListItem("-- Unit --", ""));
                //status
                ListHelper.BindList(ddlStatus, ListHelper.GetStatusSource(), "Value", "Text",null);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}