using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
//controller
using EJewel.Controller.User.Product;
using EJewel.Controller.Admin.Master.Stone;
using EJewel.Controller.Admin.Master.Setting;
using EJewel.Controller.Admin.Master.Category;
//model
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Master.Category;
using EJewel.Model.Admin.Product;
using EJewel.Controller.Admin.Product;
using System.Text.RegularExpressions;
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Master.Setting;
using EJewel.Controller.Common;

namespace EJewel.UserView
{
    public partial class Product : System.Web.UI.Page
    {
        ProductDetailsController objProductDetailsController = new ProductDetailsController();
        ProductPageController objController = new ProductPageController();
        StoneCategorySettingTypeController objStoneCategorySettingTypeController = new StoneCategorySettingTypeController();
        StoneShapeController objStoneShapeController = new StoneShapeController();
        StoneSpecificationController objStoneSpecificationController = new StoneSpecificationController();
        ProductCenterStoneController objProductCenterStoneController = new ProductCenterStoneController();
        //
        public int _primaryCategoryId, _subCategoryId;
        public string _subCategory, _primaryCategory, _baseurl, _extraUrl;
        public List<ProductDetailsModel> _lstProduct = null;

        public const int _PAGING_PER_PAGE = 15;
        public int _PAGING_CURRET_PAGE_INDEX = 0, _TOTAL_RECORD = 0;
        bool _newArrival = false, _onSale = false;
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string qs_primary_category = Convert.ToString(Page.RouteData.Values["primary_category"]);
                string qs_sub_category = Convert.ToString(Page.RouteData.Values["sub_category"]);
                if (!string.IsNullOrEmpty(qs_primary_category))
                {
                    //get the new arrival
                    _newArrival = this.IsNewArrival;

                    qs_primary_category = qs_primary_category.Trim();
                    _primaryCategory = qs_primary_category.ToLower();
                    //
                    if (!string.IsNullOrEmpty(qs_sub_category))
                    {
                        //for sub category
                        qs_sub_category = qs_sub_category.Trim();
                        //set sub category
                        _subCategory = qs_sub_category.ToLower();
                        //check for other condition
                        if (_primaryCategory == "browse" && (_subCategory == "all" || _subCategory=="sales"))
                        {
                            _baseurl = "/product";

                            _subCategoryId =0;
                            _primaryCategoryId = 0;

                            if(_subCategory=="sales")
                            {
                                _onSale = true;
                            }
                            //load product
                            if (_newArrival || _subCategory=="sales")
                            {
                                this.InitFilter();
                            }
                            else
                            {
                                Response.Redirect("/home");
                            }
                        }
                        else
                        {
                            //get the sub category
                            SubCategoryModel subCategoryModel = objController.GetProductSubCategoryFromName(qs_sub_category, CommonModel.RecordStatus.Enabled);
                            if (subCategoryModel != null)
                            {
                                string sub_category = subCategoryModel.SubCategoryName.Replace('-', ' ').ToLower();
                                if (sub_category == subCategoryModel.SubCategoryName.ToLower())
                                {
                                    //
                                    _baseurl = "/product/" + _primaryCategory + "/" + _subCategory;
                                    _subCategoryId = subCategoryModel.SubCategoryId;
                                    _primaryCategoryId = subCategoryModel.CategoryId;
                                    //load product
                                    this.InitFilter();
                                }
                                else
                                {
                                    //error no sub category foud
                                    Response.Redirect("/home");
                                }
                            }
                            else
                            {
                                //error
                                Response.Redirect("/home");
                            }
                        }
                    }
                    else
                    {
                        //this is for other types of filter
                        #region For Primary Categort
                        //for primary category
                        PrimaryCategoryModel primaryCategoryModel = objController.GetProductPrimaryCategoryFromName(_primaryCategory, CommonModel.RecordStatus.Enabled);
                        if (primaryCategoryModel != null)
                        {
                            string primary_category = primaryCategoryModel.CategoryName.Replace('-', ' ').ToLower();
                            if (primary_category == primaryCategoryModel.CategoryName.ToLower())
                            {
                                //
                                _baseurl = "/product/" + _primaryCategory;
                                _subCategoryId = 0;
                                _primaryCategoryId = primaryCategoryModel.CategoryId;
                                //load product
                                this.InitFilter();
                            }
                            else
                            {
                                //error no sub category foud
                                Response.Redirect("/home");
                            }
                        }
                        else
                        {
                            Response.Redirect("/home");
                        }
                        #endregion
                    }
                }
                else
                {
                    //goto custom error page
                    Response.Redirect("/home");
                }
            }
            catch(Exception ex)
            {
                //log
                Response.Redirect("/home");
            }
        }

        public string ProductCustomizeEncodeUrl(string sku, string primary_category, string sub_category, string name)
        {
            return this.GetHumanReadbleUrl(primary_category) + "/" + this.GetHumanReadbleUrl(sub_category) + "/" + this.GetHumanReadbleUrl(name) + "/" + sku;
        }

        private string GetHumanReadbleUrl(string name)
        {
            //formated name
            //lower
            name = name.ToLower();
            //replace space as -
            name = name.Replace(' ', '-');
            //replace & as and
            name = name.Replace("&", "and");
            //remove specila char
            name = Regex.Replace(name, "^[^A-Za-z0-9]*", "");
            //
            return name;
        }

        private void InitFilter()
        {
            try
            {
                bool is_new_arrival = _newArrival;
                bool is_on_sales = _onSale;
                string center_stone_shape = Convert.ToString(Request.QueryString["center-stone"]);
                string side_stone_shape = Convert.ToString(Request.QueryString["side-stone"]);
                //
                string center_stone_setting = Convert.ToString(Request.QueryString["center-stone-setting"]);
                string side_stone_setting = Convert.ToString(Request.QueryString["side-stone-setting"]);
                //
                string side_stone_color = Convert.ToString(Request.QueryString["gem-stone-color"]);
                string stone_type = Convert.ToString(Request.QueryString["gem-stone-type"]);
                //
                string qs_price_min = Convert.ToString(Request.QueryString["minPrice"]);
                string qs_price_max = Convert.ToString(Request.QueryString["maxPrice"]);
                //
                string qs_current_page = Convert.ToString(Request.QueryString["page"]);
                double min_price = 0, max_price = 0;
                if (qs_price_min != null && qs_price_max != null)
                {
                    min_price = qs_price_min.Length > 0 ? Convert.ToDouble(qs_price_min) : 0;
                    max_price = qs_price_max.Length > 0 ? Convert.ToDouble(qs_price_max) : 0;
                }
                _lstProduct = objProductDetailsController.GetProductDetailsForListing(_primaryCategoryId, _subCategoryId, center_stone_shape, side_stone_shape, center_stone_setting, side_stone_setting, min_price, max_price, side_stone_color, stone_type,is_new_arrival,is_on_sales, _PAGING_CURRET_PAGE_INDEX, _PAGING_PER_PAGE);
                _TOTAL_RECORD = objProductDetailsController.TotalFilterProduct;
                //create bread cumb
                this.CreateBreadCrumbs(center_stone_shape, side_stone_shape, center_stone_setting, side_stone_setting, side_stone_color, stone_type, min_price, max_price);
                //create
                StringBuilder sb = new StringBuilder();
                if (_subCategoryId > 0)
                {
                    ProductFilterModel filterModel = new ProductFilterController().GetProductFilter(_subCategoryId);
                    if (filterModel != null)
                    {
                        if (filterModel.CenterStoneShape)
                        {
                            //create center stone shape
                            this.LoadStoneShape(center_stone_shape, ConstantHelper.STONE_CATEGORY_DIAMOND,StoneShapeModel.ShapeVisibility.CENTERSTONE, "Center Stone", sb);
                        }
                        if (filterModel.SideStoneShape)
                        {
                            //side stone shape
                            this.LoadStoneShape(side_stone_shape, ConstantHelper.STONE_CATEGORY_GEMSTONE,StoneShapeModel.ShapeVisibility.SIDESTONE, "Accent Stone", sb);
                        }
                        if (filterModel.CenterStoneSetting)
                        {
                            //center stone setting
                            this.LoadStoneSetting(center_stone_setting, ConstantHelper.STONE_CATEGORY_DIAMOND, "Center Stone Setting", sb);
                        }
                        if (filterModel.SideStoneSetting)
                        {
                            //side stone shape
                            this.LoadStoneSetting(side_stone_setting, ConstantHelper.STONE_CATEGORY_GEMSTONE, "Accent Stone Setting", sb);
                        }
                        if (filterModel.GemStoneColor)
                        {
                            //Color
                            this.LoadStoneSpecification(side_stone_color, ConstantHelper.STONE_CATEGORY_GEMSTONE, StoneSpecificationModel.PageName.Color, "Gem Stone Color", sb);
                        }
                        if (filterModel.GemStoneType)
                        {
                            //Type
                            this.LoadStoneSpecification(stone_type, ConstantHelper.STONE_CATEGORY_GEMSTONE, StoneSpecificationModel.PageName.Type, "Gem Stone Type", sb);
                        }
                        //now price
                        this.LoadPrice(filterModel.MinPrice, filterModel.MaxPrice, filterModel.PriceDiff, "Price", sb);
                    }
                }
                else if(_primaryCategoryId>0)
                {
                    this.LoadSubCategory(_primaryCategoryId, "Category",sb);
                }
                else if(is_new_arrival || is_on_sales)
                {
                    this.LoadPrimaryCategory("Category", sb);
                }
                ltrlFilter.Text = sb.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        void LoadSubCategory(int primary_category_id,string heading,StringBuilder sb)
        {
            try
            {
                List<SubCategoryModel> lstSubCategory = new CategoryController().GetSubCategoryListFromCategory(primary_category_id, CommonModel.RecordStatus.Enabled).OrderBy(tbl => tbl.SubCategoryName).ToList();
                List<FilterPanel> filterPanel = (from category in lstSubCategory
                                                 select new FilterPanel()
                                                 {
                                                     Name = category.SubCategoryName,
                                                     URL = Server.UrlEncode(this.GetHumanReadbleUrl(category.SubCategoryName)) + this.NewArrivalUrl("?")
                                                 }).ToList();
                this.CreateFilter2(heading, filterPanel, sb);
            }
            catch(Exception ex)
            {
                
            }
        }

        void LoadPrimaryCategory(string heading, StringBuilder sb)
        {
            try
            {
                List<PrimaryCategoryModel> lstPrimaryCategory = new CategoryController().GetPrimaryCategoryList(0, CommonModel.RecordStatus.Enabled).OrderBy(tbl => tbl.CategoryName).ToList();
                List<FilterPanel> filterPanel = (from primary in lstPrimaryCategory
                                                 select new FilterPanel()
                                                 {
                                                     Name = primary.CategoryName,
                                                     URL = Server.UrlEncode(this.GetHumanReadbleUrl(primary.CategoryName)) + this.NewArrivalUrl("?")
                                                 }).ToList();
                this.CreateFilter2(heading, filterPanel, sb);
            }
            catch (Exception ex)
            {

            }
        }

        public string NewArrivalUrl(string url_prefix)
        {
            string extra_str = "";
            if(_newArrival)
            {
                extra_str = url_prefix+"new-arrival=yes";
            }
            return extra_str;
        }

        void LoadStoneShape(string qs_stone_shape, int categoryId, StoneShapeModel.ShapeVisibility visibility, string heading, StringBuilder sb)
        {
            try
            {
                if (qs_stone_shape == null)
                {
                    string qs_name = heading.ToLower().Replace(' ', '-');
                    //load center stone
                    List<StoneShapeModel> lstModel = objStoneShapeController.StoneShapeListFromCategory(categoryId, visibility, CommonModel.RecordStatus.Enabled);
                    List<FilterPanel> filterPanel = (from shape in lstModel
                                                     select new FilterPanel()
                                                     {
                                                         Name = shape.Shape,
                                                         URL = Server.UrlEncode(shape.Shape),
                                                         QSNAME = qs_name
                                                     }).ToList();

                    this.CreateFilter(heading, filterPanel, sb);
                }
            }
            catch (Exception ex)
            {

            }
        }

        void LoadStoneSpecification(string qs_stone_color,int categoryId,StoneSpecificationModel.PageName pageName,string heading,StringBuilder sb)
        {
            try
            {
                if (qs_stone_color == null)
                {
                    string qs_name = heading.ToLower().Replace(' ', '-');
                    //load center stone
                    List<StoneSpecificationModel> lstModel = objStoneSpecificationController.GetStoneSpecificationListFromCategory(categoryId, pageName, CommonModel.RecordStatus.Enabled);
                    List<FilterPanel> filterPanel = (from shape in lstModel
                                                     select new FilterPanel()
                                                     {
                                                         Name = shape.Name,
                                                         URL = Server.UrlEncode(shape.Name),
                                                         QSNAME=qs_name
                                                     }).ToList();

                    this.CreateFilter(heading, filterPanel, sb);
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
                objLogError.UserID = "User View";
                new ErrorLogController().SetErrorLog(objLogError);
            }
        }

        void LoadStoneSetting(string qs_category_setting, int categoryId, string heading, StringBuilder sb)
        {
            try
            {
                if (qs_category_setting == null)
                {
                    string qs_name = heading.ToLower().Replace(' ', '-');
                    //load center stone
                    List<StoneCategorySettingTypeModel> lstModel = objStoneCategorySettingTypeController.StoneSettingTypeListFromStoneCategoryType(categoryId, CommonModel.RecordStatus.Enabled);
                    List<FilterPanel> filterPanel = (from shape in lstModel
                                                     select new FilterPanel()
                                                     {
                                                         Name = shape.SettingTypeName,
                                                         URL = Server.UrlEncode(shape.SettingTypeName),
                                                         QSNAME=qs_name
                                                     }).ToList();

                    this.CreateFilter(heading, filterPanel, sb);
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
                objLogError.UserID = "User View";
                new ErrorLogController().SetErrorLog(objLogError);
            }
        }

        void LoadPrice(double minPrice, double maxPrice,double priceDiff, string heading, StringBuilder sb)
        {
            try
            {
                List<FilterPanel> filterPanel = new List<FilterPanel>();
                double init_value = minPrice,i=0;
                for (i= init_value; i < maxPrice; i += priceDiff)
                {
                    filterPanel.Add(new FilterPanel()
                    {
                        Name = "$" + init_value + " to $" + ((i+priceDiff)-1),
                        URL = "",
                        QSNAME = ""
                    });
                    init_value += priceDiff;
                }
                //add last value
                filterPanel.Add(new FilterPanel()
                {
                    Name = "$ " + i + " to above",
                    QSNAME = "",
                    URL = ""
                });
                this.CreateFilter(heading, filterPanel, sb);
            }
            catch (Exception ex)
            {

            }
        }

        private void CreateFilter(string heading, List<FilterPanel> filterPanel, StringBuilder sb)
        {
            if (filterPanel != null)
            {
                int total = filterPanel.Count;
                if (total > 0)
                {
                    //create heading
                    sb.Append("<h3 class='subheading'>" + heading + "</h3>");
                    sb.Append("<ul class='side-nav morelink'>");
                    string extra_url = this.NewArrivalUrl("&");
                    for (int i = 0; i < total; i++)
                    {
                        sb.Append("<li><a href='" + _baseurl + "?" + _extraUrl + filterPanel[i].QSNAME + "=" + filterPanel[i].URL + extra_url + "'>" + filterPanel[i].Name + "</a></li>");
                    }
                    sb.Append("</ul>");
                }
            }
        }

        //this for other filter
        private void CreateFilter2(string heading, List<FilterPanel> filterPanel, StringBuilder sb)
        {
            if (filterPanel != null)
            {
                int total = filterPanel.Count;
                if (total > 0)
                {
                    //create heading
                    sb.Append("<h3 class='subheading'>" + heading + "</h3>");
                    sb.Append("<ul class='side-nav'>");
                    for (int i = 0; i < total; i++)
                    {
                        sb.Append("<li><a href='" + _baseurl + "/" + filterPanel[i].URL + "'>" + filterPanel[i].Name + "</a></li>");
                    }
                    sb.Append("</ul>");
                }
            }
        }

        private void  CreateBreadCrumbs(string center_stone_shape,string side_stone_shape,string center_stone_setting,string side_stone_setting,string side_stone_color,string stone_type,double min_price,double max_price)
        {
            List<string> lstBreadCumb = new List<string>();
            List<string> lstBreadCumbQS = new List<string>();

            if(center_stone_shape!=null)
            {
                lstBreadCumb.Add(center_stone_shape);
                lstBreadCumbQS.Add("center-stone");
            }
            if(side_stone_shape!=null)
            {
                //
                lstBreadCumb.Add(side_stone_shape);
                lstBreadCumbQS.Add("side-stone");
            }
            if(center_stone_setting!=null)
            {
                //
                lstBreadCumb.Add(center_stone_setting);
                lstBreadCumbQS.Add("center-stone-setting");
            }
            if(side_stone_setting!=null)
            {

                //
                lstBreadCumb.Add(side_stone_setting);
                lstBreadCumbQS.Add("side-stone-setting");
            }
            if(side_stone_color!=null)
            {
                //
                lstBreadCumb.Add(side_stone_color);
                lstBreadCumbQS.Add("gem-stone-color");
            }
            if(stone_type!=null)
            {
                //
                lstBreadCumb.Add(stone_type);
                lstBreadCumbQS.Add("gem-stone-type");
            }

            if (lstBreadCumb.Count > 0)
            {
                int total_bread_cumb = lstBreadCumb.Count;
                for (int i = 0; i < total_bread_cumb; i++)
                {
                    _extraUrl += lstBreadCumbQS[i] + "=" + lstBreadCumb[i] + "&";
                }
                //for bread cumb
                //breadcumb += "<a href='#'> <b>X</b> " + stone_type + "</a>";
                string bread_cumb_qs = "",remove_url = "",bread_cumb_url = "";
                for (int i = 0; i < total_bread_cumb; i++)
                {
                    remove_url = "";
                    //pick one bread cumb
                    bread_cumb_qs = lstBreadCumbQS[i];
                    for (int j = 0; j < total_bread_cumb; j++)
                    {
                        if (total_bread_cumb == 1)
                        {
                            //for only one url is present
                        }
                        else
                        {
                            //compare to all
                            if (bread_cumb_qs != lstBreadCumbQS[j])
                            {
                                //append the url
                                remove_url += lstBreadCumbQS[j] + "=" + lstBreadCumb[j] + "&";
                            }
                        }
                    }
                    if (remove_url.Length > 0)
                    {
                        //remove last &
                        remove_url = remove_url.Substring(0, remove_url.Length - 1);
                        //append qs ?
                        remove_url = "?" + remove_url + this.NewArrivalUrl("&");
                    }
                    else
                    {
                        remove_url = this.NewArrivalUrl("?");
                    }
                    //creare a bread cumb
                    bread_cumb_url += "<a href='" + _baseurl+ remove_url + "'> <b>X</b> " + lstBreadCumb[i] + "</a>";
                }
                //set bread cumb
                if (bread_cumb_url.Length > 0)
                {
                    ltrlBreadCumb.Text = "<span>Your Selection : </span> " + bread_cumb_url+" <a href="+ _baseurl+"><b>clear all</b></a>";
                }
            }
            
        }

        public bool IsNewArrival
        {
            get
            {
                string new_arrival = Convert.ToString(Request.QueryString["new-arrival"]);
                if (!string.IsNullOrEmpty(new_arrival))
                {
                    if (new_arrival == "yes")
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public double TotalPrice(long productId,double productPrice)
        {
            CenterStoneModel csModel = objProductCenterStoneController.GetProductCenterStoneDefaultShape(productId, ConstantHelper.STONE_CATEGORY_DIAMOND);
            if(csModel!=null)
            {
                productPrice += csModel.StonePrice;
            }
            return productPrice;
        }

        public double SalesPrice(ProductDetailsModel model)
        {
            double price = 0;
            if(model!=null)
            {
                price = TotalPrice(model.ProductID, model.ProductDefaultPrice);
                //apply discount
                if(model.Discount>0)
                {
                    switch(model.DiscountType)
                    {
                        case ConstantHelper.DISCOUNT_TYPE_DOLLAR:
                            {
                                price = Math.Round(price - model.Discount);
                            }
                            break;
                        case ConstantHelper.DISCOUNT_TYPE_PERCENT:
                            {
                                //calculation for the discount
                                price = price - Math.Round((price * model.Discount) / 100);
                            }
                            break;
                    }
                }
            }
            return price;
        }
    }

    internal class FilterPanel
    {
        public string Name{get;set;}
        public string URL{get;set;}
        public string QSNAME { get; set; }
    }
}