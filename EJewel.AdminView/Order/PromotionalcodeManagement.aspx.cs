using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Controller.Admin.Product;
using EJewel.Model.Admin.Order;
using EJewel.Controller.Admin.Order;

using EJewel.Controller.Common;
using EJewel.Controller.Admin.Master.Category;
using EJewel.Model.Admin.Master.Category;

namespace EJewel.AdminView.Order
{
    public partial class PromotionalcodeManagement : System.Web.UI.Page
    {
        CategoryController objController = new CategoryController();
        List<PrimaryCategoryModel> objPrimeryCategory = new List<PrimaryCategoryModel>();
        List<SubCategoryModel> objSubCategory = new List<SubCategoryModel>();
        PromocodeTypeController objPromocodeTypeList = new PromocodeTypeController();
        PromotionalcodeManagementModel objmodel = new PromotionalcodeManagementModel();
        PromotionalcodeManagementController objPromotionalcodeManagementController = new PromotionalcodeManagementController();
        int promotionalcodeManagementId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("Default.aspx");
            }
            else
            {
                if (Request.QueryString["id"] != null)
                {
                    promotionalcodeManagementId = Convert.ToInt32(Request.QueryString["id"]);
                }
                if (!IsPostBack)
                {
                    tblCategory.Visible = false;
                    tblSubCategory.Visible = false;
                    tblDiscount.Visible = false;
                    tblSku.Visible = false;

                    BindPromocodeType();
                    BindCategory();
                    BindSubcategory(0);
                    if (promotionalcodeManagementId > 0)
                    {

                        BindPromotionalcodeManagementData();
                    }

                }
            }
        }
        void BindCategory()
        {

            objPrimeryCategory = objController.GetPrimaryCategoryList(0, CommonModel.RecordStatus.Enabled).ToList();
            if(objPrimeryCategory!=null && objPrimeryCategory.Count>0)
            {
                ddlCategory.DataSource=objPrimeryCategory;
                ddlCategory.DataTextField="CategoryName";
                ddlCategory.DataValueField="CategoryId";
                ddlCategory.DataBind();
            }
          ddlCategory.Items.Insert(0,new ListItem("Please Select","0"));

        }
        void BindPromocodeType()
        {

            try
            {
                List<PromocodeTypeModel> objPromocodeType = objPromocodeTypeList.GetPromocodeType(CommonModel.RecordStatus.Enabled);
                if (objPromocodeType.Count > 0)
                {

                    rblPromocodeType.DataSource = objPromocodeType;
                    rblPromocodeType.DataTextField = "PromocodeTypeName";
                    rblPromocodeType.DataValueField = "PromocodeTypeID";
                    rblPromocodeType.DataBind();
                }
                else
                {
                    rblPromocodeType.DataSource = null;
                    rblPromocodeType.DataBind();
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
        public void BindSubcategory(int categoryID)
        {
            if (categoryID != 0)
            {

                objSubCategory = objController.GetSubCategoryListFromCategory(categoryID, CommonModel.RecordStatus.Enabled).ToList();
                if (objSubCategory != null && objSubCategory.Count > 0)
                {
                    ddlSubCategory.DataSource = objSubCategory;
                    ddlSubCategory.DataTextField = "SubCategoryName";
                    ddlSubCategory.DataValueField = "SubCategoryId";
                    ddlSubCategory.DataBind();
                }
            }
                ddlSubCategory.Items.Insert(0, new ListItem("Please Select", "0"));

        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubcategory(Convert.ToInt32(ddlCategory.SelectedValue));
        }

        protected void rblPromocodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblPromocodeType.SelectedValue == "1")
            {
                tblCategory.Visible = false;
                tblSubCategory.Visible = false;
                ddlSubCategory.SelectedValue = "0";
                ddlCategory.SelectedValue = "0";
                tblSku.Visible = false;
                txtProductSKU.Text= "";
                tblDiscount.Visible = false;
                txtDiscountPrice.Text = "0";
            }
            else if (rblPromocodeType.SelectedValue == "2")
            {
                tblCategory.Visible = false;
                tblSubCategory.Visible = false;
                ddlSubCategory.SelectedValue = "0";
                ddlCategory.SelectedValue = "0";
                tblSku.Visible = false;
                txtProductSKU.Text = "";
                tblDiscount.Visible = false;
                txtDiscountPrice.Text = "0";
            }
            else if (rblPromocodeType.SelectedValue == "3")
            {
                tblCategory.Visible = true;
                tblSubCategory.Visible = false;
                ddlSubCategory.SelectedValue = "0";
                ddlCategory.SelectedValue = "0";
                tblSku.Visible = false;
                txtProductSKU.Text = "";
                tblDiscount.Visible = true;
                txtDiscountPrice.Text = "0";
            }
            else if (rblPromocodeType.SelectedValue == "4")
            {
                tblSubCategory.Visible = true;
                tblCategory.Visible = true;
                ddlSubCategory.SelectedValue = "0";
                ddlCategory.SelectedValue = "0";
                tblSku.Visible = false;
                txtProductSKU.Text = "";
                tblDiscount.Visible = true;
                txtDiscountPrice.Text = "0";
                
            }
            else if (rblPromocodeType.SelectedValue == "5")
            {
                tblCategory.Visible = false;
                tblSubCategory.Visible = false;
                ddlSubCategory.SelectedValue = "0";
                ddlCategory.SelectedValue = "0";
                tblSku.Visible = true;
                txtProductSKU.Text = "";
                tblDiscount.Visible = false;
                txtDiscountPrice.Text = "0";
            }
        }

        public void BindPromotionalcodeManagementData()
        {
            try
            {
                if (promotionalcodeManagementId > 0)
                {
                    objmodel = objPromotionalcodeManagementController.GetPromotionalcodeManagement(promotionalcodeManagementId, CommonModel.RecordStatus.Both).FirstOrDefault();
                    if (objmodel != null)
                    {
                        txtDiscountPrice.Text = objmodel.ProductDiscountValue.ToString();
                        txtFromDate.Text = objmodel.ProductValidFrom.ToString("dd-MM-yyyy");
                        txtProductSKU.Text= objmodel.ProductSKU;
                        txtPromotionalCodeNumber.Text = objmodel.Promotionalcode;
                        txtToDate.Text = objmodel.ProductValidTo.ToString("dd-MM-yyyy");
                        ddlCategory.SelectedValue = objmodel.CategoryID.ToString();
                       // function call for bind subcategoryin editMode

                        BindSubcategory(Convert.ToInt32(ddlCategory.SelectedValue));
                        ddlSubCategory.SelectedValue = objmodel.SubcategoryID.ToString();
                        // added by sumit on 27_May_2013
                        //if(objmodel.PromotionalcodeTypeID==3)
                        //{
                        //    tblCategory.Visible = true;
                        //}
                        //else
                        //{
                        //    tblCategory.Visible =false;
                        //}                       
                        //if (objmodel.PromotionalcodeTypeID ==4)
                        //{
                        //    tblCategory.Visible = true;
                        //    tblSubCategory.Visible = true;
                        //}
                        //else
                        //{

                        //}

                        tblCategory.Visible = objmodel.PromotionalcodeTypeID == 3 || objmodel.PromotionalcodeTypeID == 4 ? true : false;
                        tblSubCategory.Visible = objmodel.PromotionalcodeTypeID == 4 ? true : false;
                        tblSku.Visible = objmodel.PromotionalcodeTypeID != 5 ? false : true;
                        tblDiscount.Visible = objmodel.PromotionalcodeTypeID == 3 || objmodel.PromotionalcodeTypeID == 4 || objmodel.PromotionalcodeTypeID == 5 ? true : false;
                        ddlDiscountType.SelectedValue = objmodel.ProductDiscountType;
                        rblPromocodeType.SelectedValue = objmodel.PromotionalcodeTypeID.ToString();
                        rblStatus.SelectedValue = objmodel.Status.ToString();
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ProductDetailsController objProductDetailsController = new ProductDetailsController();
                PromotionalcodeManagementModel objpromotionalcodemanagement = new PromotionalcodeManagementModel();
                if(promotionalcodeManagementId>0)
                {
                    objpromotionalcodemanagement.PromotionalcodeManagementID = promotionalcodeManagementId;
                }
                objpromotionalcodemanagement.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                objpromotionalcodemanagement.SubcategoryID =Convert.ToInt32(ddlSubCategory.SelectedValue);
                objpromotionalcodemanagement.Promotionalcode = txtPromotionalCodeNumber.Text == string.Empty ? null : txtPromotionalCodeNumber.Text;
                objpromotionalcodemanagement.ProductDiscountValue = txtDiscountPrice.Text == string.Empty ? 0 : (float)System.Convert.ToSingle(txtDiscountPrice.Text);
                long productID = objProductDetailsController.GetProductIDByProductSKU(txtProductSKU.Text);
                if(productID==0 && rblPromocodeType.SelectedValue=="5")
                {
                    spnMessage.InnerText = "This sku does not exist.";
                    return;
                }
                DateTime dt1 = Convert.ToDateTime(txtFromDate.Text);
                DateTime dt2 = Convert.ToDateTime(txtToDate.Text);
                if(dt1>dt2)
                {
                    spnMessage.Attributes.Add("style", "color:Red;");
                    spnMessage.InnerText = "From date should be less then to date.";                    
                    return;

                }
           


                objpromotionalcodemanagement.ProductID = productID;
                objpromotionalcodemanagement.ProductDiscountType = ddlDiscountType.SelectedValue == string.Empty ? "0" : ddlDiscountType.SelectedValue;
                objpromotionalcodemanagement.PromotionalcodeTypeID = Convert.ToInt32(rblPromocodeType.SelectedValue);
                if (txtFromDate.Text != "")
                {
                    int dd = Convert.ToInt32(txtFromDate.Text.Substring(0, 2));
                    int mm = Convert.ToInt32(txtFromDate.Text.Substring(3, 2));
                    int yy = Convert.ToInt32(txtFromDate.Text.Substring(6, 4));
                    DateTime dt = new DateTime(yy, mm, dd);
                    objpromotionalcodemanagement.ProductValidFrom = dt;


                }
              

                if (txtToDate.Text != "")
                {

                    int dd = Convert.ToInt32(txtToDate.Text.Substring(0, 2));
                    int mm = Convert.ToInt32(txtToDate.Text.Substring(3, 2));
                    int yy = Convert.ToInt32(txtToDate.Text.Substring(6, 4));
                    DateTime dt = new DateTime(yy, mm, dd);
                    objpromotionalcodemanagement.ProductValidTo = dt;
                }
                //from date should be less than to date

             



                objpromotionalcodemanagement.Status = Convert.ToBoolean(rblStatus.SelectedValue);
                if(! new PromotionalcodeManagementController().IsExistPromotionCode(promotionalcodeManagementId,txtPromotionalCodeNumber.Text))
                {
                new PromotionalcodeManagementController().SaveUpdatePromotionalcodeManagement(objpromotionalcodemanagement);
                spnMessage.InnerText = "Details saved successfully.";
                }
                else
                {
                    spnMessage.InnerText = "Promotion code already exist.";
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
            finally
            {
                ClearField();
            }
        }
        void ClearField()
        {
            txtDiscountPrice.Text = "";
            txtFromDate.Text = "";
            txtProductSKU.Text = "";
            txtPromotionalCodeNumber.Text = "";
            txtToDate.Text = "";
            rblStatus.SelectedValue = "True";


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
        }
    }
}