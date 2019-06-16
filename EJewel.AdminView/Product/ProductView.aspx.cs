using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.Admin.Product;
using EJewel.Controller.Admin.Product;
using EJewel.Controller.Admin.Master.Metal;
using EJewel.Model.Admin.Master.Metal;
using EJewel.Model.Admin.Common;
using EJewel.Controller.Common;
using EJewel.Controller.Admin.Master.Stone;
using EJewel.Model.Admin.Master.Setting;
using EJewel.Controller.Admin.Master.Setting;
using EJewel.Model.Admin.Master.Stone;
using System.Collections;




namespace EJewel.AdminView.Product
{
    public partial class ProductView : System.Web.UI.Page
    {
        long _productID = 0;        
        int srno = 1;
        int no = 1;
        double metalWeight = 0; 
        int subCategoryId=0;

        ProductMetalController objController = new ProductMetalController();   
        ProductCenterStoneController objProductCenterStone = new ProductCenterStoneController();
        ProductCenterStoneModel objCenterStoneModel = new ProductCenterStoneModel();
        ProductSideStoneController objSideStoneController = new ProductSideStoneController();
        List<StoneSpecificationModel> stonetypemodel = new List<StoneSpecificationModel>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                string productid = Request.QueryString["id"];
                if (productid != null)
                {
                    _productID = Convert.ToInt64(productid);
                    loadProductDetails(_productID);
                    loadMetalGrid(_productID);
                    loadCenterStone(_productID);
                    //  for diamond used in sidestone
                    loadSidestoneDiamond();
                    BindsidestoneForDiamond(_productID, 1, dgvSideStone_Diamond, SideStoneActionModel.PageName.SideStone);
                    //for gemestone used in sidestone
                    loadSidestoneGemstone();
                    BindsidestoneForDiamond(_productID, 2, dgvSideStone_GemesStone, SideStoneActionModel.PageName.SideStone);
                    // for matching band
                    loadSidestoneDiamondForMatchingBand();
                    //for matching band diamond
                    BindsidestoneForDiamond(_productID, 1, gvMatchingBandDiamond, SideStoneActionModel.PageName.MatchingBand);

                    // for matching band gemstone
                    loadSidestoneGemesStoneForMatchingBand();
                    BindsidestoneForDiamond(_productID, 2, gvMatchingBandGemstone_sidestone, SideStoneActionModel.PageName.MatchingBand);
                }
                else
                {
                   // Response.Redirect("Pagenotfound.aspx");
                }
            }

        }

        #region Productdetails
        private void loadProductDetails(Int64 productdid)
        {
            try
            {
                ProductDetailsController objProductDetails = new ProductDetailsController();
                List<ProductDetailsModel> objProductDetailsModel = objProductDetails.GetProductList(productdid);
                if (objProductDetailsModel != null && objProductDetailsModel.Count > 0)
                {

                    dvProductDetails.DataSource = objProductDetailsModel;
                    dvProductDetails.DataBind();
                    lblMetalWeight.Text = objProductDetailsModel[0].ProductWeight.ToString();
                    lblMetalWidth.Text = objProductDetailsModel[0].ProductWidth.ToString();
                    subCategoryId = objProductDetailsModel[0].SubCategoryID;
                    metalWeight = objProductDetailsModel[0].ProductWeight;

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
        #endregion

        #region Metal
        private void loadMetalGrid(Int64 productid)
        {
            try
            {
                List<MetalTypeListModel> objMetalTypeModel = new List<MetalTypeListModel>();
                objMetalTypeModel = new MetalTypeController().GetMetalTypeList(0, CommonModel.RecordStatus.Enabled);
                if (objMetalTypeModel != null && objMetalTypeModel.Count > 0)
                {
                    dgvMetalType.DataSource = objMetalTypeModel; 
                    dgvMetalType.DataBind();
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
        protected void dgvMetalType_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //this event add the radio button event for single check
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {

                    HiddenField hdnMetalTypeID = (HiddenField)e.Row.FindControl("hdnMetalTypeID");
                    //System.Web.UI.HtmlControls.HtmlImage imgCorrect = (System.Web.UI.HtmlControls.HtmlImage)e.Row.FindControl("imgCorrect");
                    CheckBox chkAvialableMetal = (CheckBox)e.Row.FindControl("chkAvialableMetal");
                    Label lblMetaltype = (Label)e.Row.FindControl("lblMetaltype");
                    Label lblSRNO = (Label)e.Row.FindControl("lblSRNO");
                   Label lblImage=(Label)e.Row.FindControl("lblImage");
                    lblSRNO.Text = srno.ToString();
                    srno = srno + 1;
                    //assign the value in the control
                    ProductMetalModel model = objController.GetProductMetal(_productID, Convert.ToInt32(hdnMetalTypeID.Value));
                    //set the value
                    if (model != null)
                    {
                        e.Row.Cells[1].Visible = false;

                        if (model.DefaultMetal)
                        {
                            //imgCorrect.Src = "~/asset/template/images/extra/correct.gif";                          
                            lblImage.Text = "<img src='/assets/themes/admin/images/icon/product/correct_16.gif' />";
                        }
                        if (model.Status == false && model.DefaultMetal == false)
                        {
                            e.Row.Visible = false;
                            srno--;
                        }
                    }
                    //called when last row have neither available nor default metal
                    else
                    {
                        e.Row.Visible = false;
                        srno--;
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
        #endregion

        #region Center Stone

        public void loadCenterStone(long productid)
        {
            try
            {
                List<ProductCenterStoneShapeModel> objCenterStoneShapeModel = objProductCenterStone.GetProductCenterStoneShapeList(productid, 1, CommonModel.RecordStatus.Enabled);
                if (objCenterStoneShapeModel != null && objCenterStoneShapeModel.Count > 0)
                {
                    dgvCenterStone.DataSource = objCenterStoneShapeModel;
                    dgvCenterStone.DataBind();
                    dgvCenterStone.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                loadCaratOfCenterStone(productid);
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
        public void loadCaratOfCenterStone(long productid)
        {
            try
            {
                objCenterStoneModel = objProductCenterStone.GetProductCenterStone(productid, 1);
                if (objCenterStoneModel != null)
                {
                    lblMaxCarat.Text = Convert.ToString(objCenterStoneModel.StoneMaxCarat);
                    lblMinCarat.Text = Convert.ToString(objCenterStoneModel.StoneMinCarat);
                    lblSettingTypeCenterStone.Text = GetSettingTypeName(objCenterStoneModel.StoneCategorySettingTypeId);
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
        public string GetSettingTypeName(int stonecategorysettingTyped)
        {
            try
            {
                List<StoneCategorySettingTypeModel> settingTypeModel = new StoneCategorySettingTypeController().StoneSettingTypeList(stonecategorysettingTyped, CommonModel.RecordStatus.Enabled);
                if (settingTypeModel != null && settingTypeModel.Count > 0)
                {
                    return settingTypeModel[0].SettingTypeName;
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
            return "";

        }
        
        #endregion

        #region Side Stone
       
        public void loadSidestoneDiamond()
        {
            try
            {
                ProductSideStoneRangeModel sideStoneRangeModel = objSideStoneController.ProductSideStoneRange(_productID, 1, SideStoneActionModel.PageName.SideStone);
                if (sideStoneRangeModel != null)
                {
                    //set the value of the page
                    lblMaxCaratDiamondSS.Text = sideStoneRangeModel.StoneMaxCarat.ToString();
                    lblMinCaratDiamondSS.Text = sideStoneRangeModel.StoneMinCarat.ToString();
                    //LoadSideStoneShape(sideStoneRangeModel.ProductSideStoneRangeId, 1, gvSidestoneDiamondShape, SideStoneActionModel.PageName.SideStone);
                    //added by sumit on 3-06-2013 for productView
                   // GetSideStoneAvailableShape(sideStoneRangeModel.ProductSideStoneRangeId, CommonModel.StoneCategoryType.DIAMOND);
                    //GetSideStoneAvailableShape(sideStoneRangeModel.ProductSideStoneRangeId, 1);
                    GetSideStoneAvailableShape(sideStoneRangeModel.ProductSideStoneRangeId, 1, SideStoneActionModel.PageName.SideStone);
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
        //function used for gemstone
        public void loadSidestoneGemstone()
        {
            try
            {
                ProductSideStoneRangeModel sideStoneRangeModel = objSideStoneController.ProductSideStoneRange(_productID, 2, SideStoneActionModel.PageName.SideStone);
                if (sideStoneRangeModel != null)
                {
                    //set the value of the page
                    lblGemstoneMax.Text = sideStoneRangeModel.StoneMaxCarat.ToString();
                    lblGemstoneMin.Text = sideStoneRangeModel.StoneMinCarat.ToString();
                    GetSideStoneAvailableGemsShape(sideStoneRangeModel.ProductSideStoneRangeId, 2,SideStoneActionModel.PageName.SideStone);
                  //  LoadSideStoneShape(sideStoneRangeModel.ProductSideStoneRangeId, 2, gvSidestoneGemsShape, SideStoneActionModel.PageName.SideStone);
                  

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
        protected void dgvSideStone_Gems_rowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    HiddenField hdnSideStoneID = (HiddenField)e.Row.FindControl("hdnSideStoneID");
                    HiddenField hdnCustomize = (HiddenField)e.Row.FindControl("hdnCustomize");
                    Label lblCustomize = (Label)e.Row.FindControl("lblCustomize");

                    if (Convert.ToBoolean(hdnCustomize.Value) == true)
                    {
                        lblCustomize.Text = "<img src='/assets/themes/admin/images/icon/product/correct_16.gif' />";
                    }
                    //BulletedList lstSideStoneDiamond = (BulletedList)e.Row.FindControl("lstSideStoneGems");
                    GridView lstSideStoneGems = (GridView)e.Row.FindControl("lstSideStoneGems");

                    if (hdnSideStoneID.Value != null)
                    {

                        List<SideStoneModel> objModel = new List<SideStoneModel>();
                        objModel = objSideStoneController.GetProductStoneAvailable_Type(Convert.ToInt64(hdnSideStoneID.Value), SideStoneActionModel.PageName.SideStone);
                        if (objModel != null && objModel.Count > 0)
                        {

                            lstSideStoneGems.DataSource = objModel;                          
                            lstSideStoneGems.DataBind();
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
        }        

      
        #endregion

        #region Matching Band

        public void loadSidestoneDiamondForMatchingBand()
        {
            try
            {
                ProductSideStoneRangeModel sideStoneRangeModel = objSideStoneController.ProductSideStoneRange(_productID, 1, SideStoneActionModel.PageName.MatchingBand);
                if (sideStoneRangeModel != null)
                {
                    //set the value of the page
                    lblMaxRangeForMatchingBand.Text = sideStoneRangeModel.StoneMaxCarat.ToString();
                    lblMinRangeForMatchingBand.Text = sideStoneRangeModel.StoneMinCarat.ToString();
                    GetSideStoneAvailableShape(sideStoneRangeModel.ProductSideStoneRangeId, 1, SideStoneActionModel.PageName.MatchingBand);            


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
        public void loadSidestoneGemesStoneForMatchingBand()
        {
            try
            {
                ProductSideStoneRangeModel sideStoneRangeModel = objSideStoneController.ProductSideStoneRange(_productID, 2, SideStoneActionModel.PageName.MatchingBand);
                if (sideStoneRangeModel != null)
                {
                    //set the value of the page
                    lblMaxGemsMatchingBand.Text = sideStoneRangeModel.StoneMaxCarat.ToString();
                    lblMinGemsMatchingBand.Text = sideStoneRangeModel.StoneMinCarat.ToString();
                    GetSideStoneAvailableGemsShape(sideStoneRangeModel.ProductSideStoneRangeId, 2, SideStoneActionModel.PageName.MatchingBand);

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
        protected void dgvMatchingBand_Gems_rowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    HiddenField hdnSideStoneID = (HiddenField)e.Row.FindControl("hdnSideStoneID");
                //BulletedList lstSideStoneDiamond = (BulletedList)e.Row.FindControl("lstMatchingBandGems");
                HiddenField hdnCustomize = (HiddenField)e.Row.FindControl("hdnCustomize");
                Label lblCustomize = (Label)e.Row.FindControl("lblCustomize");
                    
            

                if (Convert.ToBoolean(hdnCustomize.Value) == true)
                {
                    lblCustomize.Text = "<img src='/assets/themes/admin/images/icon/product/correct_16.gif' />";
                }
                //BulletedList lstSideStoneDiamond = (BulletedList)e.Row.FindControl("lstSideStoneGems");
                GridView lstMatchingBandGems = (GridView)e.Row.FindControl("lstMatchingBandGems");

                if (hdnSideStoneID.Value != null)
                {

                    List<SideStoneModel> objModel = new List<SideStoneModel>();
                    objModel = objSideStoneController.GetProductStoneAvailable_Type(Convert.ToInt64(hdnSideStoneID.Value), SideStoneActionModel.PageName.MatchingBand);
                    if (objModel != null && objModel.Count > 0)
                    {

                        lstMatchingBandGems.DataSource = objModel;
                        lstMatchingBandGems.DataBind();
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
        }

        #endregion

        # region Common Methods
        private void LoadSideStoneShape(long sidestonerangeId, int stonecategoryid, GridView gvSidestoneDiamondShape,SideStoneActionModel.PageName page)
        {
            try
            {
                stonetypemodel = new ProductSideStoneController().StoneShapeListForView(sidestonerangeId, page);
                if (stonetypemodel != null && stonetypemodel.Count > 0)
                {
                    gvSidestoneDiamondShape.DataSource = stonetypemodel;
                    gvSidestoneDiamondShape.DataBind();
                    gvSidestoneDiamondShape.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        public void BindsidestoneForDiamond(long productId, int stonecategoryId, GridView gridviewSideStone,SideStoneActionModel.PageName pagename)
        {
            try
            {
                List<ProductSideStoneDetailModel> objSideStoneDetailsModel = objSideStoneController.ProductSideStoneListForView(productId, stonecategoryId, pagename);
                if (objSideStoneDetailsModel != null && objSideStoneDetailsModel.Count > 0)
                {
                    gridviewSideStone.DataSource = objSideStoneController.ProductSideStoneListForView(productId, stonecategoryId, pagename);
                    gridviewSideStone.DataBind();
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
        #endregion
        protected void dgvCenterStone_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnDefault = (HiddenField)e.Row.FindControl("hdnDefault");
                Label lblImage = (Label)e.Row.FindControl("lblImage");
                if (Convert.ToBoolean(hdnDefault.Value) == true)
                {
                    lblImage.Text = "<img src='/assets/themes/admin/images/icon/product/correct_16.gif' />";
                }
            }
        }

        // added by sumit on 03-06-2013
        // for side stone available shape


        public void GetSideStoneAvailableShape(long sidestonerangeId,int stonecategoryId,SideStoneActionModel.PageName pname)
        {
            List<ProductSideStoneShapeModel> lstSidestoneRange = new List<ProductSideStoneShapeModel>();
            if (pname ==SideStoneActionModel.PageName.SideStone)
            {
              
                lstSidestoneRange = objSideStoneController.GetSideStoneAvailableShape(sidestonerangeId, stonecategoryId, pname);
                if (lstSidestoneRange != null && lstSidestoneRange.Count > 0)
                {
                    bltSideStoneDiamondShape.DataSource = lstSidestoneRange;
                    bltSideStoneDiamondShape.DataTextField = "ShapeName";
                    bltSideStoneDiamondShape.DataValueField = "StoneShapeId";
                    bltSideStoneDiamondShape.DataBind();
                   
                }
            }
            else
            {
                lstSidestoneRange = objSideStoneController.GetSideStoneAvailableShape(sidestonerangeId, stonecategoryId, pname);
                if (lstSidestoneRange != null && lstSidestoneRange.Count > 0)
                {
                    bltMatchingBandDiamond.DataSource = lstSidestoneRange;
                    bltMatchingBandDiamond.DataTextField = "ShapeName";
                    bltMatchingBandDiamond.DataValueField = "StoneShapeId";
                    bltMatchingBandDiamond.DataBind();
                }

            }
        
        }
        public void GetSideStoneAvailableGemsShape(long sidestonerangeId, int stonecategoryId,SideStoneActionModel.PageName pname)
        {
            List<ProductSideStoneShapeModel> lstSidestoneRange = new List<ProductSideStoneShapeModel>();
            if (pname == SideStoneActionModel.PageName.SideStone)
            {
                lstSidestoneRange = objSideStoneController.GetSideStoneAvailableShape(sidestonerangeId, stonecategoryId, pname);
                if (lstSidestoneRange != null && lstSidestoneRange.Count > 0)
                {
                    bltSideStoneGemstone_Shape.DataSource = lstSidestoneRange;
                    bltSideStoneGemstone_Shape.DataTextField = "ShapeName";
                    bltSideStoneGemstone_Shape.DataValueField = "StoneShapeId";
                    bltSideStoneGemstone_Shape.DataBind();
                }
            }
            if (pname == SideStoneActionModel.PageName.MatchingBand)
            {
                lstSidestoneRange = objSideStoneController.GetSideStoneAvailableShape(sidestonerangeId, stonecategoryId, pname);
                if (lstSidestoneRange != null && lstSidestoneRange.Count > 0)
                {

                    bltMatchingBandGemsstone.DataSource = lstSidestoneRange;
                    bltMatchingBandGemsstone.DataTextField = "ShapeName";
                    bltMatchingBandGemsstone.DataValueField = "StoneShapeId";
                    bltMatchingBandGemsstone.DataBind();
                }


            }
        }
       


    }
}