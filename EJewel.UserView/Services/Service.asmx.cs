using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
//add controller
using EJewel.Controller.Admin.Configuration.Currency;
using EJewel.Controller.Admin.Configuration.Store;
using EJewel.Controller.Admin.Master.Stone;
using EJewel.Controller.Admin.Master.Metal;
using EJewel.Controller.Admin.Master.Category;
using EJewel.Controller.Admin.Master.Payment;
using EJewel.Controller.Admin.Product;
using EJewel.Controller.Admin.Common.Sfm;
using EJewel.Controller.Admin.Master.Setting;
using EJewel.Controller.Common;
//add model
using EJewel.Model.Admin.Configuration.Currency;
using EJewel.Model.Admin.Configuration.Store;
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Master.Metal;
using EJewel.Model.Admin.Master.Category;
using EJewel.Model.Admin.Master.Payment;
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Common.Sfm;
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Master.Setting;
using System.Text;
using EJewel.Model.Cart;
using EJewel.Controller.Cart;

// added by sumit on 07-06-2013
using EJewel.Model.Admin.Product.Extras;
using EJewel.Controller.Admin.Product.Extras;
namespace EJewel.UserView.Services
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {


        #region getproductlist



        /* sumit jha
         * @ 29-03-2013
         * */
        [WebMethod]
        public List<SfmModel> GetSettingType()
        {
            return new SfmController().GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.SettingType);
        }
        /* sumit jha
         * @ 30-03-2013
         * */
        [WebMethod]
        public List<MetalTypeListModel> GetMetalTypeList(int metaltypeid)
        {
            return new MetalTypeController().GetMetalTypeList(metaltypeid, CommonModel.RecordStatus.Both);
        }
        //get the center stone shape list (diamond)
        [WebMethod]
        public List<StoneSpecificationModel> GetDiamondStoneShapeList()
        {
            //return new StoneSpecificationController().GetStoneSpecificationListFromCategory(ConstantHelper.STONE_CATEGORY_DIAMOND, StoneSpecificationModel.PageName.Shape, CommonModel.RecordStatus.Enabled);
            return new List<StoneSpecificationModel>();
        }
        //get the center stone shape list (diamond)
        [WebMethod]
        public List<StoneSpecificationModel> GetDiamondStoneColorList()
        {
            return new StoneSpecificationController().GetStoneSpecificationListFromCategory(ConstantHelper.STONE_CATEGORY_DIAMOND, StoneSpecificationModel.PageName.Color, CommonModel.RecordStatus.Enabled);
        }
        //get the center stone color list (gemstone)
        [WebMethod]
        public List<StoneSpecificationModel> GetGemStoneColorList()
        {
            return new StoneSpecificationController().GetStoneSpecificationListFromCategory(ConstantHelper.STONE_CATEGORY_GEMSTONE, StoneSpecificationModel.PageName.Color, CommonModel.RecordStatus.Enabled);
        }
        //get the center stone type list (gemstone)
        [WebMethod]
        public List<StoneSpecificationModel> GetGemStoneTypeList()
        {
            return new StoneSpecificationController().GetStoneSpecificationListFromCategory(ConstantHelper.STONE_CATEGORY_GEMSTONE, StoneSpecificationModel.PageName.Type, CommonModel.RecordStatus.Enabled);
        }
        #endregion

        #region Product Customization
        [WebMethod]

        public MetalTypeListModel GetProductCustomizeMetalDetails(string SKU, int metal_type_id)
        {
            ProductDetailsController objProductController = new ProductDetailsController();
            ProductDetailsModel productDetails = objProductController.GetProductFromSKU(SKU);
            if (productDetails != null)
            {
                ProductPriceModel priceModel = objProductController.ProductPriceDetails(productDetails.ProductID, metal_type_id, productDetails.ProductWeight, productDetails.IsExtraOrdinary);
                if (priceModel != null)
                {
                    MetalTypeListModel model = new MetalTypeController().GetMetalTypeList(metal_type_id, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                    if (model != null)
                    {
                        model.MetalPrice = priceModel.TotalPrice;
                    }
                    return model;
                }
            }
            return null;
        }
        //partha @ 17-05-13 for more customization
        [WebMethod]
        public double GetSideStoneCustomizePrice(string SKU, long sideStoneId)
        {
            double price = 0;
            ProductDetailsController objProductController = new ProductDetailsController();
            ProductDetailsModel productDetails = objProductController.GetProductFromSKU(SKU);
            if (productDetails != null)
            {
                ProductCustomizeController objCustomize = new ProductCustomizeController();
                price = objCustomize.SideStoneTotalPrice(productDetails.ProductID, sideStoneId, SideStoneActionModel.PageName.SideStone);
            }
            return price;
        }
        [WebMethod]
        public List<MetalTypeListModel> GetProductMetalTypeFromSKU(string SKU)
        {
            ProductDetailsModel productModel = new ProductDetailsController().GetProductFromSKU(SKU);
            if (productModel != null)
            {
                //get the product metal type list
                return new ProductViewController().GetMetalTypeList(productModel.ProductID);
            }
            return null;
        }
        [WebMethod]
        public List<ProductCenterStoneShapeModel> GetProductCenterStoneShape(string SKU)
        {
            ProductDetailsModel productModel = new ProductDetailsController().GetProductFromSKU(SKU);
            if (productModel != null)
            {
                return new ProductCenterStoneController().GetProductCenterStoneShapeList(productModel.ProductID, ConstantHelper.STONE_CATEGORY_DIAMOND, CommonModel.RecordStatus.Both);
            }
            return null;
        }
        [WebMethod]
        public double GetProductCustomizeDetails(string SKU, int metalTypeId, long centerStoneId)
        {
            double totalPrice = 0;
            ProductDetailsController objProductController = new ProductDetailsController();
            ProductDetailsModel productDetails = objProductController.GetProductFromSKU(SKU);
            if (productDetails != null)
            {
                ProductPriceModel priceModel = objProductController.ProductPriceDetails(productDetails.ProductID, metalTypeId, productDetails.ProductWeight, productDetails.IsExtraOrdinary);
                if (priceModel != null)
                {
                    totalPrice = priceModel.TotalPrice;
                }
            }
            return totalPrice;
        }
        #endregion

        #region Custom
        [WebMethod]
        public List<CenterStoneModel> GetAllCenterStoneList(int pageIndex, int perPage)
        {

            return new CenterStoneController().GetAllCenterStoneList(pageIndex, perPage, CommonModel.RecordStatus.Enabled);

        }

        [WebMethod]
        public List<CenterStoneModel> FilterCenterStoneList(int ShapeID, float MinPriceRange, float MaxPriceRange, float MinCaratRange, float MaxCaratRange, int MinColorRange, int MaxColorRange, int MinCutRange, int MaxCutRange, int MinClarityRange, int MaxClarityRange)
        {
            return new CenterStoneController().FilterCenterStoneList(ShapeID, MinPriceRange, MaxPriceRange, MinCaratRange, MaxCaratRange, MinColorRange, MaxColorRange, MinCutRange, MaxCutRange, MinClarityRange, MaxClarityRange);
        }

        [WebMethod]
        public List<CenterStoneModel> LooseDiamondFilter( string shapes,string cuts,string colors,string clarity,float MinPriceRange, float MaxPriceRange, float MinCaratRange, float MaxCaratRange,int currentPage,int perPage)
        {
            return new CenterStoneController().FilterCenterStoneList(shapes, cuts, colors, clarity, MinPriceRange, MaxPriceRange, MinCaratRange, MaxCaratRange, currentPage, perPage);
        }
        [WebMethod]
        public List<StoneSpecificationModel> GetColorStoneSpecificationListFromCategory()
        {
            return new StoneSpecificationController().GetStoneSpecificationListFromCategory(1, StoneSpecificationModel.PageName.Color, CommonModel.RecordStatus.Enabled);
        }

        [WebMethod]
        public List<StoneSpecificationModel> GetCutStoneSpecificationListFromCategory()
        {
            return new StoneSpecificationController().GetStoneSpecificationListFromCategory(1, StoneSpecificationModel.PageName.Cut, CommonModel.RecordStatus.Enabled);
        }

        [WebMethod]
        public List<StoneSpecificationModel> GetClarityStoneSpecificationListFromCategory()
        {
            return new StoneSpecificationController().GetStoneSpecificationListFromCategory(1, StoneSpecificationModel.PageName.Clarity, CommonModel.RecordStatus.Enabled);
        }
        #endregion

        [WebMethod]
        public CenterStoneModel GetCenterStoneDetailsFromSKU(string SKU)
        {
            return new CenterStoneController().GetCenterStoneDetailsFromSKU(SKU);
        }

        [WebMethod]
        public List<StoneSpecificationModel> GetDiamondShapes()
        {
            //return new StoneSpecificationController().GetStoneSpecificationListFromCategory(ConstantHelper.STONE_CATEGORY_DIAMOND, StoneSpecificationModel.PageName.Shape, CommonModel.RecordStatus.Enabled);
            return new List<StoneSpecificationModel>();
        }

        [WebMethod]
        public List<LooseDiamondShapeModel> GetLooseDiamondShape(int shapeId)
        {
            return new LooseDiamondShapeController().GetLooseDiamondShape(shapeId);
        }

        /* sumit jha
       * @ 07-05-2013
       * For front end listing
       * */
        [WebMethod]
        public List<StoneSpecificationModel> GetStoneShapeList(int categoryId)
        {
            StoneSpecificationController cont = new StoneSpecificationController();
            return cont.GetStoneSpecificationListForShape(0,StoneShapeModel.ShapeVisibility.BOTH, CommonModel.RecordStatus.Enabled).Where(tbl => tbl.StoneCategoryId == categoryId).ToList();

        }

        [WebMethod]
        public List<StoneShapeModel> GetProductCenterStoneStoneShapeList(long productId)
        {
            return new ProductCenterStoneController().GetProductCenterStoneStoneShapeList(productId, ConstantHelper.STONE_CATEGORY_DIAMOND,StoneShapeModel.ShapeVisibility.CENTERSTONE, CommonModel.RecordStatus.Enabled);
        }

        [WebMethod]
        public double GetProductCustomizeProductPrice(string SKU, int metal_type_id, string center_stone_sku, long side_stone_id)
        {
            double price = 0;
            ProductDetailsController objController = new ProductDetailsController();
            ProductDetailsModel productDetails = objController.GetProductFromSKU(SKU);
            if (productDetails != null)
            {
                ProductCustomizeController cont = new ProductCustomizeController();
                price = cont.ProductTotalCustomizePrice(productDetails, metal_type_id, center_stone_sku, side_stone_id);
            }
            return price;
        }
        [WebMethod]
        public string GetSideStoneInfo(string SKU, long sideStoneId,int pageNameId)
        {
            SideStoneActionModel.PageName pageName = SideStoneActionModel.PageName.SideStone;
            switch(pageNameId)
            {
                default:case 1:
                    {
                        pageName = SideStoneActionModel.PageName.SideStone;
                    }
                    break;
                case 2:
                    {
                        pageName = SideStoneActionModel.PageName.MatchingBand;
                    }
                    break;
            }
            StringBuilder sb = new StringBuilder();
            ProductDetailsModel productDetailsModel = new ProductDetailsController().GetProductFromSKU(SKU);
            ProductSideStoneController objProductSideStoneController = new ProductSideStoneController();
            SideStoneController objSideStoneController = new SideStoneController();
            if (productDetailsModel != null)
            {
                ProductSideStoneModel productSideStoneModel = null;
                string shapes = "";
                SideStoneModel sideStoneModel = objSideStoneController.GetSideStoneList(sideStoneId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                if (sideStoneModel != null)
                {
                    //panSideStoneInfo
                    List<ProductSideStoneModel> lstProductSideStoneDiamond = objProductSideStoneController.ProductSideStoneList(productDetailsModel.ProductID, ConstantHelper.STONE_CATEGORY_DIAMOND, pageName, CommonModel.RecordStatus.Enabled);
                    int total_side_stone_diamond_shape = lstProductSideStoneDiamond.Count;
                    if(total_side_stone_diamond_shape==0)
                    {
                        return "";
                    }
                    switch (sideStoneModel.StoneCategoryId)
                    {
                        case ConstantHelper.STONE_CATEGORY_DIAMOND:
                            {
                                #region For Diamond
                                //create bulider
                                if (total_side_stone_diamond_shape > 0)
                                {
                                    //set side stone diamond heading
                                    sb.Append("<table width=\"80%\" class=\"productoverviewheader\" cellspacing=\"0\">");
                                    //set heading
                                    sb.Append("<tr><td colspan=\"2\"><b>Diamond Information</b></td></tr>");
                                    //set shapes
                                    sb.Append("<tr><td><span class=\"item_head\"></span> Shapes</td>");
                                    double total_carat = 0;
                                    int total_stone = 0;
                                    for (int i = 0; i < total_side_stone_diamond_shape; i++)
                                    {
                                        productSideStoneModel = lstProductSideStoneDiamond[i];
                                        if (productSideStoneModel != null)
                                        {
                                            sideStoneModel = objSideStoneController.GetSideStoneList(productSideStoneModel.StoneId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                                            if (sideStoneModel != null)
                                            {
                                                total_stone += productSideStoneModel.NoOfStone;
                                                total_carat += Math.Round(productSideStoneModel.NoOfStone * sideStoneModel.StoneCarate, 2);
                                                shapes += sideStoneModel.StoneShape + ",";
                                            }
                                        }
                                    }
                                    //remove last comma from the shape
                                    if (shapes.Length > 0)
                                    {
                                        shapes = shapes.Substring(0, shapes.Length - 1);
                                    }
                                    sb.Append("<td align=\"right\">"+shapes + "</td></tr>");
                                    //get first item details
                                    productSideStoneModel = lstProductSideStoneDiamond[0];
                                    sideStoneModel = objSideStoneController.GetSideStoneList(productSideStoneModel.StoneId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                                    if (sideStoneModel != null)
                                    {
                                        sb.Append(CreateSideStoneView(sideStoneModel, total_stone, total_carat));
                                    }
                                    sb.Append("</table>");
                                }
                                #endregion

                            } break;
                        case ConstantHelper.STONE_CATEGORY_GEMSTONE:
                            {
                                #region For Gemstone
                                int total_stone_diamond = 0, total_stone_gemstone = 0;
                                double totl_ct_weight_diamond = 0, totl_ct_weight_gemstone = 0;
                                List<ProductSideStoneModel> lstProductSideStoneGemstone = objProductSideStoneController.ProductSideStoneList(productDetailsModel.ProductID, ConstantHelper.STONE_CATEGORY_GEMSTONE, pageName, CommonModel.RecordStatus.Enabled).OrderBy(tbl => tbl.IsCustomize == true).ToList();
                                //get underline side stone details
                                productSideStoneModel = objProductSideStoneController.GetProductSideStoneFromSideStoneType(productDetailsModel.ProductID, sideStoneId, pageName);
                                //calculate
                                int total_side_stone_gemstone_shape = lstProductSideStoneGemstone.Count;
                                List<long> diamondSideStone = new List<long>();
                                SideStoneModel sideStoneCustomize = null;
                                for (int i = 0; i < total_side_stone_gemstone_shape; i++)
                                {
                                    //top item is always customize
                                    if (i == 0)
                                    {
                                        //get the top item becuase its is the customize item
                                        //and if this will change then the rest side stone gems stone
                                        sideStoneCustomize = objSideStoneController.GetSideStoneList(productSideStoneModel.StoneId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                                    }
                                    //get the diamond
                                    for (int j = 0; j < total_side_stone_diamond_shape; j++)
                                    {
                                        //get the side stone diamond same as gemstone side stone shape
                                        SideStoneModel sideStoneSameDiamond = objProductSideStoneController.GetProductSideStoneDiamondSameAsGemStone(lstProductSideStoneDiamond[j], lstProductSideStoneGemstone[i]);
                                        if (sideStoneSameDiamond != null && sideStoneSameDiamond.SideStoneId > 0)
                                        {
                                            //error
                                            SideStoneModel sideStoneGemStone = objSideStoneController.GetSideStoneList(lstProductSideStoneGemstone[i].StoneId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                                            if (i == 0)
                                            {
                                                diamondSideStone.Add(lstProductSideStoneDiamond[j].StoneId);
                                                //get price
                                                total_stone_gemstone += lstProductSideStoneGemstone[i].NoOfStone;
                                                totl_ct_weight_gemstone += Math.Round(lstProductSideStoneGemstone[i].NoOfStone * sideStoneGemStone.StoneCarate, 2);
                                                //calculate the side stone
                                                total_stone_diamond += lstProductSideStoneDiamond[i].NoOfStone - lstProductSideStoneGemstone[i].NoOfStone;
                                                totl_ct_weight_diamond += Math.Round((lstProductSideStoneDiamond[i].NoOfStone - lstProductSideStoneGemstone[i].NoOfStone) * sideStoneSameDiamond.StoneCarate, 2);
                                                break;
                                            }
                                            else
                                            {
                                                //get the details of the customize gemstone
                                                //get the available type of the side stone
                                                List<SideStoneModel> lstSideStoneAvailableType = objProductSideStoneController.GetProductSideStoneAvailableType(lstProductSideStoneGemstone[i].ProductSideStoneId, pageName);
                                                //get the appropriate side stone
                                                SideStoneModel sideStonePerfectMatching = lstSideStoneAvailableType.Where(tbl => tbl.StoneColorId == sideStoneCustomize.StoneColorId && tbl.StoneTypeId == sideStoneCustomize.StoneTypeId).FirstOrDefault();
                                                if (sideStonePerfectMatching != null)
                                                {
                                                    //add in diamond
                                                    diamondSideStone.Add(lstProductSideStoneDiamond[j].StoneId);
                                                    //now calculate the price
                                                    //get price
                                                    total_stone_gemstone += lstProductSideStoneGemstone[i].NoOfStone;
                                                    totl_ct_weight_gemstone += Math.Round(lstProductSideStoneGemstone[i].NoOfStone * sideStoneGemStone.StoneCarate, 2);
                                                    //calculate the side stone
                                                    total_stone_diamond += lstProductSideStoneDiamond[i].NoOfStone - lstProductSideStoneGemstone[i].NoOfStone;
                                                    totl_ct_weight_diamond += Math.Round((lstProductSideStoneDiamond[i].NoOfStone - lstProductSideStoneGemstone[i].NoOfStone) * sideStoneSameDiamond.StoneCarate, 2);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                //calculate the extra
                                if (diamondSideStone.Count > 0)
                                {
                                    //sort the item
                                    if (total_side_stone_diamond_shape > total_side_stone_gemstone_shape)
                                    {
                                        List<ProductSideStoneModel> lstProductSideStoneDiamondRest = lstProductSideStoneDiamond.Where(tbl => !diamondSideStone.Contains(tbl.StoneId)).ToList();
                                        int total_rest_diamond = lstProductSideStoneDiamondRest.Count;
                                        for (int i = 0; i < total_rest_diamond; i++)
                                        {
                                            SideStoneModel sideStoneDiamod = objSideStoneController.GetSideStoneList(lstProductSideStoneDiamondRest[i].StoneId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                                            total_stone_diamond += lstProductSideStoneDiamondRest[i].NoOfStone;
                                            totl_ct_weight_diamond += Math.Round(lstProductSideStoneDiamondRest[i].NoOfStone * sideStoneDiamod.StoneCarate, 2);
                                            //
                                            shapes += sideStoneDiamod.StoneShape + ",";
                                        }
                                    }
                                }
                                //set side stone diamond heading
                                sb.Append("<table width=\"80%\" class=\"productoverviewheader\" cellspacing=\"0\">");
                                //show the details of the diamond
                                #region Shaow Diamond Details
                                if (total_stone_diamond > 0)
                                {
                                    //show the diamond details
                                    //set heading
                                    sb.Append("<tr><td colspan=\"2\"><b>Diamond Information</b></td></tr>");
                                    //set shapes
                                    sb.Append("<tr><td><span class=\"item_head\"></span> Shapes</td>");
                                    if (shapes.Length > 0)
                                    {
                                        shapes = shapes.Substring(0, shapes.Length - 1);
                                    }
                                    sb.Append("<td align=\"right\">" + shapes + "</td></tr>");
                                    //show other details
                                    ProductSideStoneModel productSideStoneDiamondModel = lstProductSideStoneDiamond[0];
                                    sideStoneModel = objSideStoneController.GetSideStoneList(productSideStoneDiamondModel.StoneId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                                    if (sideStoneModel != null)
                                    {
                                        sb.Append(CreateSideStoneView(sideStoneModel, total_stone_diamond, totl_ct_weight_diamond));
                                    }
                                }
                                #endregion

                                #region Show Gemstone Details
                                //show the diamond details
                                sb.Append("<tr><td colspan=\"2\"><b>Gemstone Information</b></td></tr>");
                                
                                sideStoneModel = objSideStoneController.GetSideStoneList(productSideStoneModel.StoneId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                                if (sideStoneModel != null)
                                {
                                    if (total_stone_diamond == 0)
                                    {
                                        //show shapes in when diamond is not present
                                        sb.Append("<tr><td>Shapes</td>");
                                        sb.Append("<td align=\"right\">" + sideStoneModel.StoneShape + "</td></tr>");
                                    }
                                    sb.Append(CreateSideStoneView(sideStoneModel, total_stone_gemstone, totl_ct_weight_gemstone));
                                }
                                #endregion

                                sb.Append("</table>");
                                //show gemstone details
                                #endregion

                            } break;
                    }
                }
            }
            return sb.ToString();
        }

        private string CreateSideStoneView(SideStoneModel sideStoneModel, int total_stone, double total_carat)
        {
            StringBuilder sb = new StringBuilder();
            if (sideStoneModel != null)
            {
                //total no of diamond
                sb.Append("<tr><td><span class=\"item_head\"></span> # Of Diamond </td><td align=\"right\">" + total_stone + "</td></tr>");
                //carat 
                sb.Append("<tr><td><span class=\"item_head\"></span> Ct. Total Weight </td><td align=\"right\">" + total_carat + " Ctw</td></tr>");
                //color
                if (sideStoneModel.StoneCategoryId == ConstantHelper.STONE_CATEGORY_DIAMOND)
                {
                    //for diamond
                    sb.Append("<tr><td><span class=\"item_head\"></span> Color  </td><td align=\"right\">" + sideStoneModel.StoneColor + "</td></tr>");
                }
                else
                {
                    //for gemstone
                    sb.Append("<tr><td><span class=\"item_head\"></span> Color  </td><td align=\"right\">" + sideStoneModel.StoneColor + " " + sideStoneModel.StoneType + "</td></tr>");
                }
                //cut
                sb.Append("<tr><td><span class=\"item_head\"></span> Cut  </td><td align=\"right\">" + sideStoneModel.StoneCut + "</td></tr>");
                //color
                sb.Append("<tr><td><span class=\"item_head\"></span> Clarity  </td><td align=\"right\">" + sideStoneModel.StoneClarity + "</td></tr>");
            }
            return sb.ToString();
        }

        [WebMethod(EnableSession=true)]
        public int AddToCart(string ProductSKU, int metalTypeId, string CenterStoneSKU, long sideStoneId, string imageGUID)
        {
            try
            {
                //get the product details
                ProductCustomizeController cont = new ProductCustomizeController();
                ProductDetailsModel productDetails = new ProductDetailsController().GetProductFromSKU(ProductSKU);
                if(productDetails!=null)
                {
                    double totalPrice = 0;
                    //get the product price
                    if (ProductSKU.Length == 0)
                    {
                        //only for the center stone
                    }
                    else
                    {
                        //for whole product
                        totalPrice = cont.ProductTotalCustomizePrice(productDetails, metalTypeId, CenterStoneSKU, sideStoneId);
                        //add the product in shoping bag
                        CartController.Instance.AddItem(metalTypeId,productDetails.ProductID, CenterStoneSKU, ConstantHelper.CART_PRODUCT_TYPE_PRODUCT, sideStoneId, imageGUID, totalPrice);
                    }
                    return 1;
                }
            }
            catch(Exception ex)
            {
                
            }
            return 0;
        }

        [WebMethod(EnableSession = true)]
        public int UpdateCartRingSize(int cartId, int ringSizeId)
        {
            CartController.Instance.UpdateRingSize(cartId, ringSizeId);
            return 1;
        }

        [WebMethod(EnableSession = true)]
        public int UpdateCartEngraving(int cartId, string text)
        {
            CartController.Instance.UpdateEngraving(cartId, text);
            return 1;
        }

        [WebMethod(EnableSession = true)]
        public int RemoveCart(int cartId)
        {
            CartController.Instance.RemoveItem(cartId);
            return 1;
        }

        // added by sumit on 07-06-2013
        [WebMethod]
        public QueriesOnProductModel SaveUpdateQueriesOnProduct(QueriesOnProductModel model)
        {
            return new QueriesOnProductController().SaveUpdateQueriesOnProduct(model);
        }
    }

}
