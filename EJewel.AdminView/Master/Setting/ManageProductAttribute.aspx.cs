using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.Admin.Master.Category;
using EJewel.Controller.Admin.Master.Category;
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Common.Sfm;
//controller
using EJewel.Controller.Common;
using EJewel.Model.Admin.Master.Setting;
using EJewel.Controller.Admin.Master.Setting;
using EJewel.Controller.Admin.Common.Sfm;


namespace EJewel.AdminView.Master.Setting
{
    public partial class ManageProductAttribute : System.Web.UI.Page
    {
        CategoryController objController = new CategoryController();
        List<SubCategoryModel> lstModel=new List<SubCategoryModel>();
        ProductAttributeController objProductAttributeController = new ProductAttributeController();
        ProductAttributeModel objProductAttributeModel = new ProductAttributeModel();
        int attributeId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                if (Request.QueryString["id"] != null)
                {
                    attributeId = Convert.ToInt32(Request.QueryString["id"]);

                }

                if (!IsPostBack)
                {
                    //load primary category
                    ListHelper.BindList(ddlPrimeryCategory, objController.GetPrimaryCategoryList(0, CommonModel.RecordStatus.Enabled), "CategoryId", "CategoryName", ListHelper.DefaultList);
                    //lod status
                    ListHelper.BindList(ddlStatus, ListHelper.GetStatusSource(), "Value", "Text", null);
                    BindSubCategory();
                    BindAttributeTitle();
                    if (attributeId > 0)
                    {
                        BindDetails();
                    }
                    if (Request.QueryString["status"] == "success")
                    {
                        spnMessage.InnerText = "Details saved successfully.";
                    }


                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (attributeId > 0)
                {
                    objProductAttributeModel.AttributeId = attributeId;
                }
                objProductAttributeModel.AttributeName = txtName.Text.Trim();
                objProductAttributeModel.AttributePrice = (float)Convert.ToDouble(txtPrice.Text.Trim());
                objProductAttributeModel.Status = ddlStatus.SelectedIndex == 0 ? true : false;
                objProductAttributeModel.SubCategoryId = Convert.ToInt32(ddlSubCategory.SelectedValue);
                objProductAttributeModel.AttributeTitleId = Convert.ToInt32(ddlAttributeTitle.SelectedValue);
                objProductAttributeModel.IsDefault = chkIsDefault.Checked == true ? true : false;
                objProductAttributeController.SaveUpdateProductAttribute(objProductAttributeModel);
                Response.Redirect("/Master/Setting/ManageProductAttribute.aspx?id=" + attributeId + "&status=success");
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
        public void BindSubCategory()
        {
            try
            {
                if (ddlPrimeryCategory.SelectedValue != "")
                {
                    lstModel = objController.GetSubCategoryListFromCategory(Convert.ToInt32(ddlPrimeryCategory.SelectedValue), CommonModel.RecordStatus.Enabled);
                    if (lstModel != null && lstModel.Count > 0)
                    {
                        ddlSubCategory.DataSource = lstModel;
                        ddlSubCategory.DataTextField = "SubCategoryName";
                        ddlSubCategory.DataValueField = "SubCategoryId";
                        ddlSubCategory.DataBind();
                    }
                }
                ddlSubCategory.Items.Insert(0, new ListItem("Please Select", "0"));
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
        protected void ddlPrimeryCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubCategory();
        }
        public void BindDetails()
        {
            try
            {
                if (attributeId > 0)
                {
                    objProductAttributeModel = objProductAttributeController.GetProductAttribute(attributeId, CommonModel.RecordStatus.Both).FirstOrDefault();
                    if (objProductAttributeModel != null)
                    {
                        ddlPrimeryCategory.SelectedValue = objProductAttributeModel.PrimeryCategoryId.ToString();
                        BindSubCategory();
                        ddlSubCategory.SelectedValue = objProductAttributeModel.SubCategoryId.ToString();
                        txtName.Text = objProductAttributeModel.AttributeName;
                        txtPrice.Text = Convert.ToString(objProductAttributeModel.AttributePrice);
                        ddlStatus.SelectedIndex = objProductAttributeModel.Status == true ? 0 : 1;
                        ddlAttributeTitle.SelectedValue = objProductAttributeModel.AttributeTitleId.ToString();
                        chkIsDefault.Checked = objProductAttributeModel.IsDefault;
                    }


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
        public void BindAttributeTitle()
        {
            List<SfmModel> objSfmList = new SfmController().GetSfmList(0, CommonModel.RecordStatus.Enabled,new SfmController().GetPageView("attribute_heading")).ToList();
            if (objSfmList != null && objSfmList.Count > 0)
            {
                ddlAttributeTitle.DataSource = objSfmList;
                ddlAttributeTitle.DataTextField = "Name";
                ddlAttributeTitle.DataValueField = "AutoID";
                ddlAttributeTitle.DataBind();
            }
            ddlAttributeTitle.Items.Insert(0, new ListItem("Please Select", "0"));
        }
    }
}