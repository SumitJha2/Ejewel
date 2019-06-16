using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//other
using System.Text;
//controller
using EJewel.Controller.Admin.Product;
using EJewel.Controller.Admin.Master.Stone;
using EJewel.Controller.Admin.Master.Metal;
using EJewel.Controller.Admin.Master.Setting;
//model

using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Master.Category;
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Master.Metal;
using EJewel.Model.Admin.Master.Setting;
using EJewel.UserView.Services;
using EJewel.Controller.Admin.Product.Extras;
using EJewel.Model.Admin.Product.Extras;


namespace EJewel.UserView
{
    public partial class ProductCustomize : System.Web.UI.Page
    {
        ProductDetailsController objController = new ProductDetailsController();
        StoneSpecificationController objStoneSpecificationController = new StoneSpecificationController();
        SideStoneController objSideStoneController = new SideStoneController();
        ProductSideStoneController objProductSideStoneController = new ProductSideStoneController();
        ProductViewController objProductViewController = new ProductViewController();
        ProductCenterStoneController objProductCenterStoneController = new ProductCenterStoneController();
        ProductCustomizeController objProductCustomizeController = new ProductCustomizeController();
        ProductPriceController objProductPriceController = new ProductPriceController();
        ProductImageManagerController objProductImageManagerController = new ProductImageManagerController();
        ProductChainController objProductChainController = new ProductChainController();
        //
        public string _SKU = "", _CENTER_STONE_SKU = "", _PRODUCT_DESC = "", _DEF_IMAGE_GUID = "", _DEFSHAPE = "";
        public double _INITIAL_PRICE = 0, _CENTER_STONE_PRICE = 0;
        public long _PRODUCT_ID = 0;
        //get the default
        public int _DEF_METAL_TYPE_ID = 0, _DEF_CENTER_STONE_SHAPE_ID = 0, _TOTAL_IMAGE = 0;
        public long _DEF_CENTER_STONE_ID = 0, _DEF_SIDE_STONE_ID = 0,_DEF_MATCHING_BAND_SIDE_STONE_ID=0, _DEF_SIDE_STONE_CATEGORY_ID = 1;
        //filter
        public double _MINPRICE, _MAXPRICE, _MINCARAT, _MAXCARAT, _MINTABLE, _MAXTABLE, _MINDEPTH, _MAXDEPTH;

        private string _PRODUCT_SETTING = "";
        List<ProductCenterStoneShapeModel> _lstCenterStoneShape = null;

        public List<ProductImageManagerModel> _lstProductImageManager = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //GetCustomerReview();
            string qs_sub_category = Convert.ToString(Page.RouteData.Values["sub_category"]);
            string qs_sku = Convert.ToString(Page.RouteData.Values["sku"]);
            if (!string.IsNullOrEmpty(qs_sub_category) && !string.IsNullOrEmpty(qs_sku))
            {
                //redefined the query string
                qs_sku = qs_sku.Trim();
                qs_sub_category = qs_sub_category.Trim();
                //get product details from the sku and sub category id
                ProductDetailsModel productDetailsModel = objController.GetProductFromSKU(qs_sku);
                if (productDetailsModel != null)
                {
                    //check product details
                    if(productDetailsModel.IsExtraOrdinary)
                    {
                        Response.Redirect("/home");
                    }
                    //set the seo details
                    Page.Title = productDetailsModel.PageTitle;
                    Page.MetaKeywords = productDetailsModel.MetaKeyword;
                    Page.MetaDescription = productDetailsModel.MetaDescripation;
                    //set other details
                    _PRODUCT_ID = productDetailsModel.ProductID;
                    _SKU = productDetailsModel.SKU;
                    _PRODUCT_DESC = productDetailsModel.ProductDescripation;
                    //set setting info
                    ltrlProductTitle.Text = productDetailsModel.ProductTitle;
                    //diaplay center stone details

                    #region Create Customize Tab
                    //create customize
                    _lstCenterStoneShape = objProductCenterStoneController.GetProductCenterStoneShapeList(_PRODUCT_ID, ConstantHelper.STONE_CATEGORY_DIAMOND, CommonModel.RecordStatus.Enabled).OrderBy(tbl => tbl.DefaultShape == false).ToList();
                    this.CreateCustomizeTab(productDetailsModel, _lstCenterStoneShape);
                    #endregion

                    #region Set Price
                    //set price
                    _INITIAL_PRICE = productDetailsModel.ProductDefaultPrice;
                    //set the product center stone price
                    CenterStoneModel csModel = objProductCenterStoneController.GetProductCenterStoneDefaultShape(productDetailsModel.ProductID, ConstantHelper.STONE_CATEGORY_DIAMOND);
                    if(csModel!=null)
                    {
                        _CENTER_STONE_PRICE = csModel.StonePrice;
                    }
                    ltrlPrice.Text = (_INITIAL_PRICE + _CENTER_STONE_PRICE).ToString();
                    #endregion

                    #region Product Metal Details
                    //set default product
                    ProductMetalModel productMetalModel = new ProductMetalController().GetProductDefaultMetalType(productDetailsModel.ProductID);
                    if (productMetalModel != null)
                    {
                        //set the default metal
                        _DEF_METAL_TYPE_ID = productMetalModel.MetalTypeID;
                        //
                        MetalTypeListModel metalTypeModel = new MetalTypeController().GetMetalTypeList(productMetalModel.MetalTypeID, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                        if (metalTypeModel != null)
                        {
                            //set the product setting infor
                            StringBuilder sbSettingInfo = new StringBuilder();
                            //create table
                            sbSettingInfo.Append("<table width=\"85%\" class=\"productoverviewheader\" cellspacing=\"0\">");
                            //create sku
                            sbSettingInfo.Append("<tr><td><span class=\"item_head\"></span> Item Code</td><td align=\"right\">" + _SKU + "</td></tr>");
                            //metal
                            sbSettingInfo.Append("<tr><td><span class=\"item_head\"></span> Metal</td><td align=\"right\" id=\"spanMetal\">"+ metalTypeModel.MetalTypeName + "</td></tr>");
                            //width
                            sbSettingInfo.Append("<tr><td><span class=\"item_head\"></span> Width</td><td align=\"right\">" + productDetailsModel.ProductWidth + " mm.</td></tr>");
                            //setting
                            if (_PRODUCT_SETTING.Length > 0)
                            {
                                sbSettingInfo.Append("<tr><td><span class=\"item_head\"></span> Setting Type</td><td align=\"right\">" + _PRODUCT_SETTING + "</td></tr>");
                            }
                            //chain info
                            ProductChainModel productChain = objProductChainController.GetProductChainDetail(productDetailsModel.ProductID,CommonModel.RecordStatus.Enabled);
                            if(productChain!=null)
                            {
                                //set chain details
                                sbSettingInfo.Append("<tr><td><span class=\"item_head\"></span> Clasp</td><td>"+productChain.Clasp+"</td></tr>");
                                sbSettingInfo.Append("<tr><td><span class=\"item_head\"></span> Chain Length</td><td>"+productChain.Length+" inch</td></tr>");
                                sbSettingInfo.Append("<tr><td><span class=\"item_head\"></span> Chain Style</td><td>"+productChain.Style+"</td></tr>");
                            }
                            sbSettingInfo.Append("</table>");
                            panSettingInfo.Controls.Add(new LiteralControl(sbSettingInfo.ToString()));
                        }
                    }
                    #endregion

                    #region Center Stone Info
                    this.ShowProductDefaultCenterStoneInfo(productDetailsModel.ProductID);
                    #endregion

                    #region Image
                    //render the image 6 is default param for image
                    _lstProductImageManager = objProductImageManagerController.ProductDefaultImage(productDetailsModel, 20);
                    _TOTAL_IMAGE = _lstProductImageManager.Count;
                    #endregion
                }
                else
                {
                    Response.Redirect("/home");
                }
            }
            else
            {
                Response.Redirect("/home");
            }
        }

        void CreateCustomizeTab(ProductDetailsModel productDetailsModel, List<ProductCenterStoneShapeModel> lstCenterStoneShape)
        {
            if (productDetailsModel != null)
            {
                //create metal tab
                List<MetalTypeListModel> lstMetalType = objProductViewController.GetMetalTypeList(productDetailsModel.ProductID).ToList();
                if (lstMetalType != null)
                {
                    //get the product default price
                    //_INITIAL_PRICE = objProductCustomizeController.Product_CenterStone_Price(productDetailsModel.SKU);
                    StringBuilder sb = new StringBuilder();
                    //for metal type
                    this.CreateMetalType(lstMetalType, productDetailsModel.ProductID, sb);
                    //for side stone
                    this.CreateSideStoneStr(productDetailsModel.ProductID, sb, SideStoneActionModel.PageName.SideStone,"Accent Stone 1", "customize_side_stone");
                    //for center stone
                    this.CreateCenterStoneStr(productDetailsModel.ProductID, lstCenterStoneShape, sb);
                    //for matching band
                    this.LoadMatchingBand(productDetailsModel);
                    //add item in panel
                    ltrlCustomizeTab.Text = sb.ToString(); // commented by Pravin 1-6-13
                    //panCustomize.Controls.Add(new LiteralControl());
                }
            }
        }

        #region Create Customization

        private void CreateMetalType(List<MetalTypeListModel> lstMetalType,long ProductID, StringBuilder sb)
        {
            int total_item = lstMetalType.Count;
            if (total_item > 0)
            {
                this.CreateToogle(sb, "Metal", lstMetalType[0].MetalTypeName, "swatch-stone-metal-"+GetMetalCSS(lstMetalType[0]), "default_metal_select");
                string css = "";
                for (int i = 0; i < total_item; i++)
                {
                    css = "swatch-stone-metal-" + GetMetalCSS(lstMetalType[i]) + "";
                    sb.Append("<i class='" + css + "' data-event='metal' data-metal-css='" + css + "' data-metal-name='" + lstMetalType[i].MetalTypeName + "' data-metal-id='" + lstMetalType[i].MetalTypeId + "'></i>\n");
                }
                this.CloseToogle(sb);
            }
        }

        private void CreateCenterStoneStr(long ProductID,List<ProductCenterStoneShapeModel> lstCenterStoneShape, StringBuilder sb)
        {
            if (lstCenterStoneShape != null)
            {
                int total_item = lstCenterStoneShape.Count;
                if (total_item > 0)
                {
                    string css=lstCenterStoneShape[0].StoneShape.ToLower().Replace(' ', '-');
                    //set default shape id
                    _DEF_CENTER_STONE_SHAPE_ID = lstCenterStoneShape[0].StoneShapeId;
                    _DEFSHAPE = lstCenterStoneShape[0].StoneShape.ToString();
                    //create haeading
                    this.CreateToogle(sb, "Center Stone",  lstCenterStoneShape[0].StoneShape, "swatch-stone-center-" +css, "default_centerstone_select");
                    //default as no center stone shape
                    for (int i = 0; i < total_item; i++)
                    {
                        css = lstCenterStoneShape[i].StoneShape.ToLower().Replace(' ', '-');
                        sb.Append("<i class='swatch-stone-center-" + css + "' data-event='centerstone' data-centerstone-css='swatch-stone-center-" + css + "' data-centerstone-name='" + lstCenterStoneShape[i].StoneShape + "'  data-centerstone-id='" + lstCenterStoneShape[i].StoneShapeId + "'></i>");
                    }
                    this.CloseToogle(sb);
                }
            }
        }

        private void CreateSideStoneStr(long productID, StringBuilder sb,SideStoneActionModel.PageName pageName,string headingName,string event_name)
        {
            #region For Side Stone & matching band
            //get the side stone diamond
            List<ProductSideStoneModel> lstProductSideStoneDiamond = objProductSideStoneController.ProductSideStoneList(productID, ConstantHelper.STONE_CATEGORY_DIAMOND, pageName, CommonModel.RecordStatus.Enabled);
            //get  the product side stone for gem stone
            List<ProductSideStoneModel> lstProductSideStoneGemStone = objProductSideStoneController.ProductSideStoneList(productID, ConstantHelper.STONE_CATEGORY_GEMSTONE, pageName, CommonModel.RecordStatus.Enabled).OrderBy(tbl => tbl.IsCustomize == true).ToList();
            //get side stone
            if (lstProductSideStoneDiamond!=null && lstProductSideStoneGemStone != null && lstProductSideStoneDiamond.Count>0 && lstProductSideStoneGemStone.Count > 0)
            {
                /*
                 * Get the product Side stone Gem stone model
                 * It will help for creating more genralize for image genration
                 * */
                SideStoneModel sideStoneGemStone = objSideStoneController.GetSideStoneList(lstProductSideStoneGemStone[0].StoneId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                if (sideStoneGemStone != null)
                {
                    //set setting price
                    this.SetProductSetting(lstProductSideStoneDiamond[0].StoneCategorySettingTypeId);
                    //set the default side stone shape
                   _DEF_SIDE_STONE_ID = objProductCustomizeController.DefaultSideStoneId(lstProductSideStoneDiamond, lstProductSideStoneGemStone, productID, pageName);
                   //_INITIAL_PRICE += objProductCustomizeController.SideStoneTotalPrice(productID, _DEF_SIDE_STONE_ID, pageName);
                   
                    #region Customize Side Stone Tab
                   /*
                    * * In every Side Stone Customization
                    * * we put white diamond as default 
                    * * because the default product based on diamond
                    * * If the user need customize it will chnage accroding.
                    * * */
                   string css = "white-diamond";
                    //create heading
                   this.CreateToogle(sb, headingName, "White Diamond", "swatch-stone-side-white-diamond", "default_sidestone_select");
                    //create default
                   sb.Append("<i class='swatch-stone-side-white-diamond' data-stone-category='1' data-event='sidestone' data-sidestone-name='White Diamond' data-sidestone-css='swatch-stone-side-" + css + "'  data-sidestone-id='" + _DEF_SIDE_STONE_ID + "'></i>");
                    /*
                     * Get the customize Type for show to the user
                     * for more customize the side stone geme stone
                     * */
                    List<SideStoneModel> lstSideStoneType = objProductSideStoneController.GetProductSideStoneAvailableType(lstProductSideStoneGemStone[0].ProductSideStoneId, SideStoneActionModel.PageName.SideStone);
                    if (lstSideStoneType != null)
                    {
                        int total_side_stone_type = lstSideStoneType.Count;
                        if (total_side_stone_type > 0)
                        {
                            for (int j = 0; j < total_side_stone_type; j++)
                            {
                                css = this.GetSideStoneCSS(lstSideStoneType[j]);
                                sb.Append("<i class='swatch-stone-side-" + css + "' data-stone-category='2' data-event='sidestone' data-sidestone-name='" + lstSideStoneType[j].StoneColor + " " + lstSideStoneType[j].StoneType + "' data-sidestone-css='swatch-stone-side-" + css + "'  data-sidestone-id='" + lstSideStoneType[j].SideStoneId + "'></i>");
                            }
                        }
                        else
                        {
                            //no yet ready @ partha
                        }
                    }
                    else
                    {
                        //not yet ready @ partha
                    }
                    //end div
                    //sb.Append("</li>");
                    this.CloseToogle(sb);
                   #endregion

                }
            }
            else if (lstProductSideStoneDiamond != null && lstProductSideStoneDiamond.Count > 0)
            {
                //get the diamond details
                _DEF_SIDE_STONE_ID = lstProductSideStoneDiamond[0].StoneId;
                //set setting price
                this.SetProductSetting(lstProductSideStoneDiamond[0].StoneCategorySettingTypeId);
            }
            #endregion
        }

        void CreateToogle(StringBuilder sb, string heading_name, string sub_heading, string css_clss, string heading_id)
        {
            sb.Append("\n<li class='customize-item'>\n");
            sb.Append("<div class='customize-item-heading'>\n");
            //heading
            sb.Append("<dl><dt><span class='title1'>" + heading_name + "</span>\n");
            //sub heading
            sb.Append("<span id='sub_" + heading_id + "' class='title2 sel-stone-name'>" + sub_heading + "</span></dt>\n");
            //default selection
            sb.Append("<dd><i id='" + heading_id + "' class='" + css_clss + " sel-stone-img'></i></dd></dl></div>\n");
            //other swatch
            sb.Append("<div class='customize-item-description'>\n");
            sb.Append("<p class='item-details'></p>\n");
            sb.Append("<div class='swatch-wrap'>\n");
        }

        void CloseToogle(StringBuilder sb)
        {
            sb.Append("</div><div class='row-fluid'>\n");
            sb.Append("<input type='button' class='btn btn-small' value='Cancel'>\n");
            sb.Append("<input type='button' class='btn btn-small btn-primary pull-right' value='Continue'>\n");
            sb.Append("</div></div></li>");
        }

        private string GetMetalCSS(MetalTypeListModel model)
        {
            return model.MetalWeight.ToLower() + "-" + model.MetalName.ToLower().Replace(' ', '-');
        }

        private string GetSideStoneCSS(SideStoneModel stoneModel)
        {
            return stoneModel.StoneColor.ToLower() + "-" + stoneModel.StoneType.ToLower().Replace(' ', '-');
        }
        #endregion

        void ShowProductDefaultCenterStoneInfo(long productId)
        {
            CenterStoneModel modelCenterStone = objProductCenterStoneController.GetProductCenterStoneDefaultShape(productId, ConstantHelper.STONE_CATEGORY_DIAMOND);
            if (modelCenterStone != null)
            {
                //set the center stone shape id and ceter id
                _CENTER_STONE_SKU = modelCenterStone.SKU;
                _DEF_CENTER_STONE_ID = modelCenterStone.StoneId;
                _DEF_CENTER_STONE_SHAPE_ID = modelCenterStone.StoneShapeId;
                //create table str
                StringBuilder sb = new StringBuilder();
                //create table
                sb.Append("<table width=\"85%\" class=\"productoverviewheader\" cellspacing=\"0\"><tbody id=\"tblCenterStoneDetails\">");
                //SKU
                sb.Append("<tr><td><span class=\"item_head\"></span> SKU #</td><td   align=\"right\">" + modelCenterStone.SKU + "</td></tr>");
                //Shape
                sb.Append("<tr><td><span class=\"item_head\"></span> Shape</td><td align=\"right\">" + modelCenterStone.StoneShape + "</td></tr>");
                //weight
                sb.Append("<tr><td><span class=\"item_head\"></span> Weight</td><td align=\"right\">" + modelCenterStone.StoneCarate + "</td></tr>");
                //Clarity
                sb.Append("<tr><td><span class=\"item_head\"></span> Clarity</td><td align=\"right\">" + modelCenterStone.StoneClarity + "</td></tr>");
                //Color
                sb.Append("<tr><td><span class=\"item_head\"></span> Color</td><td  align=\"right\">" + modelCenterStone.StoneColor + "</td></tr>");
                //Cut
                sb.Append("<tr><td><span class=\"item_head\"></span> Cut</td><td align=\"right\">" + modelCenterStone.StoneCut + "</td></tr>");
                //Price
                sb.Append("<tr><td><span class=\"item_head\"></span> Price</td><td  align=\"right\"> $" + modelCenterStone.StonePrice + "</td></tr>");
                //Certification
                sb.Append("<tr><td><span class=\"item_head\"></span> Certification</td><td align=\"right\">" + modelCenterStone.CertificateCertificationLab + "</td></tr>");
                //close 
                sb.Append("</tbody></table>");
                //add this item in panel
                panCenterStone.Controls.Add(new LiteralControl(sb.ToString()));
                //For center stone range
                CenterstoneMinMaxRangeModel rangeModel = new CenterStoneController().GetCenterStoneMinMaxRange();
                if (rangeModel != null)
                {
                    //price
                    _MINPRICE = rangeModel.MinPrice;
                    _MAXPRICE = rangeModel.MaxPrice;
                    //table
                    _MINTABLE = rangeModel.MinTable;
                    _MAXTABLE = rangeModel.MaxTable;
                    //depth
                    _MINDEPTH = rangeModel.MinDepth;
                    _MAXDEPTH = rangeModel.MaxDepth;
                }
                //set the setting type of the product
                ProductCenterStoneModel productcenterStone = objProductCenterStoneController.GetProductCenterStone(productId, ConstantHelper.STONE_CATEGORY_DIAMOND);
                if (productcenterStone != null)
                {
                    //center range
                    _MINCARAT = productcenterStone.StoneMinCarat;
                    _MAXCARAT = productcenterStone.StoneMaxCarat;
                }
            }
        }

        public List<StoneSpecificationModel> GetStoneSpecificationList(StoneSpecificationModel.PageName pageName)
        {
            return objStoneSpecificationController.GetStoneSpecificationListFromCategory(ConstantHelper.STONE_CATEGORY_DIAMOND, pageName, CommonModel.RecordStatus.Enabled).OrderBy(tbl => tbl.Name).ToList();
        }

        public List<StoneShapeModel> GetStoneShapeList()
        {
            List<StoneShapeModel> lstShape = new StoneShapeController().StoneShapeListFromCategory(ConstantHelper.STONE_CATEGORY_DIAMOND,StoneShapeModel.ShapeVisibility.CENTERSTONE, CommonModel.RecordStatus.Enabled).OrderBy(tbl => tbl.Shape).ToList();
            if (_lstCenterStoneShape != null)
            {
                lstShape = (from shape in lstShape
                            join productShape in _lstCenterStoneShape
                            on shape.StoneShapeId equals productShape.StoneShapeId
                            select shape).ToList();
            }
            return lstShape;
        }

        void LoadMatchingBand(ProductDetailsModel productDetailsModel)
        {
            try
            {
                //panMatchingBand
                List<ProductSideStoneModel> lstProductSideStoneDiamond = objProductSideStoneController.ProductSideStoneList(productDetailsModel.ProductID, ConstantHelper.STONE_CATEGORY_DIAMOND, SideStoneActionModel.PageName.MatchingBand, CommonModel.RecordStatus.Enabled);
                if (lstProductSideStoneDiamond != null)
                {
                    #region For Diamond
                    int total_side_stone_diamond_shape = lstProductSideStoneDiamond.Count;
                    //create bulider
                    if (total_side_stone_diamond_shape > 0)
                    {
                        _DEF_MATCHING_BAND_SIDE_STONE_ID = lstProductSideStoneDiamond[0].StoneId;
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {

            }
        }

        private string CreateSideStoneView(SideStoneModel sideStoneModel, int total_stone, double total_carat)
        {
            StringBuilder sb = new StringBuilder();
            if (sideStoneModel != null)
            {
                //color
                sb.Append("Color :" + sideStoneModel.StoneColor + "</br>");
                //color
                sb.Append("Cut :" + sideStoneModel.StoneCut + "</br>");
                //color
                sb.Append("Clarity :" + sideStoneModel.StoneClarity + "</br>");
                //weight
                sb.Append("Total : " + total_stone + " stones, " + total_carat + "cts total</br>");
            }
            return sb.ToString();
        }

        public void GetCustomerReview()
        {
            //will be change
            List<ProductReviewModel> objModel = new List<ProductReviewModel>();
            objModel = new ProductReviewController().GetProductReviewList(0, CommonModel.RecordStatus.Enabled);
            if (objModel != null)
            {
                string tbl = "";
                tbl = "<table width='100%'>";
                foreach (ProductReviewModel obj in objModel)
                {
                    tbl = tbl + "<tr><td><b>" + obj.Heading + "</b></td></tr>";
                    tbl = tbl + "<tr><td>Review :<b>" + obj.Review + "</b></td></tr>";
                    tbl = tbl + "<tr><td>Rating :<b>" + obj.Rating + "</b></td></tr>";
                    tbl = tbl + "<tr><td>Name :<b>" + obj.Name + "</b></td></tr>";
                    tbl = tbl + "<tr><td><b>" + obj.date.ToString("dd-MM-yyyy") + "</b></td></tr>";
                }
                tbl = tbl + "</table>";
                spnReview.InnerHtml = tbl;
            }

        }

        private void SetProductSetting(int categorySettingTypeId)
        {
            try
            {
                StoneCategorySettingTypeModel stoneCategorySettingTypeModel = new StoneCategorySettingTypeController().StoneSettingTypeList(categorySettingTypeId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                if(stoneCategorySettingTypeModel!=null)
                {
                    _PRODUCT_SETTING = stoneCategorySettingTypeModel.SettingTypeName;   
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}