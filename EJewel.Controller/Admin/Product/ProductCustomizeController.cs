using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Master.Metal;
using EJewel.Model.Admin.Master.Stone;
//dal
using EJewel.DAL.Admin.Master.Metal;
using EJewel.DAL.Admin.Product;
using EJewel.DAL.Admin.Master.Stone;
//controller
using EJewel.Controller.Admin.Master.Stone;
namespace EJewel.Controller.Admin.Product
{
    public class ProductCustomizeController
    {
        CenterStoneController objCenterStoneController = new CenterStoneController();
        CenterStoneDAL objCenterStoneDAL = new CenterStoneDAL();
        ProductPriceDAL objProductPriceDAL = new ProductPriceDAL();
        ProductSideStoneDAL objProductSideStoneDAL = new ProductSideStoneDAL();
        ProductCenterStoneDAL objProductCenterStoneDAL = new ProductCenterStoneDAL();
        SideStoneDAL objSideStoneDAL = new SideStoneDAL();

        public ProductPriceModel ProductPriceDetails(long productId, int metalTypeId, double productWeight)
        {
            double total_price = 0;
            //metal price
            double metal_price = objProductPriceDAL.MetalPrice(metalTypeId, productWeight);
            //stone price
            List<ProductSideStoneModel> lstSideStoneModel = objProductSideStoneDAL.ProductSideStoneList(productId, ConstantHelper.STONE_CATEGORY_DIAMOND, SideStoneActionModel.PageName.SideStone, CommonModel.RecordStatus.Enabled);
            List<ProductSideStoneModel> lstMatchingBandModel = objProductSideStoneDAL.ProductSideStoneList(productId, ConstantHelper.STONE_CATEGORY_DIAMOND, SideStoneActionModel.PageName.MatchingBand, CommonModel.RecordStatus.Both);
            //get setting price
            double center_stone_setting_price = 0;

            //This Price is only for the center stone model
            ProductCenterStoneModel productCenterStoneModel = objProductCenterStoneDAL.GetProductCenterStone(productId, 1);
            if (productCenterStoneModel != null)
            {
                center_stone_setting_price = objProductPriceDAL.SettingPrice(productCenterStoneModel.StoneCategorySettingTypeId, 1, 1);
            }
            double side_stone_setting_price = objProductPriceDAL.SideStoneSettingPrice(lstSideStoneModel);
            double matching_band_setting_price = objProductPriceDAL.SideStoneSettingPrice(lstMatchingBandModel);
            double setting_price = center_stone_setting_price + side_stone_setting_price + matching_band_setting_price;
            //get side stone
            //get side stone price diamond
            double side_stone_price_diamond = objProductPriceDAL.SideStonePrice(lstSideStoneModel);
            //get matching band price diamond
            double matching_band_price_diamond = objProductPriceDAL.SideStonePrice(lstMatchingBandModel);
            //get chain price
            double chain_price = objProductPriceDAL.ChainPrice(productId);
            //now calculate total price
            total_price = metal_price + setting_price + side_stone_price_diamond + matching_band_price_diamond + chain_price;
            //
            ProductPriceModel model = new ProductPriceModel()
            {
                //basic price
                MetalPrice = metal_price,
                CenterStonePrice = 0,
                SideStonePrice = side_stone_price_diamond,
                MatchingBandPrice = matching_band_price_diamond,
                //setting price
                CenterStoneSettingPrice = center_stone_setting_price,
                SideStoneSettingPrice = side_stone_setting_price,
                MatchingBandSettingPrice = matching_band_setting_price,
                TotalSettingPrice = setting_price,
                //extra price
                ChainPrice = chain_price,
                ExtraPrice = 0,
                TotalPrice = total_price
            };
            return model;
        }

        //get price for each side stone
        private double SideStoneCustomizePrice(long productId, long sideStoneId,int stoneCategoryId, SideStoneActionModel.PageName pageName)
        {
            double side_stone_price = 0;
            //get the detais of the stone
            ProductSideStoneModel productSelectedSideStone = null;
            if(stoneCategoryId==ConstantHelper.STONE_CATEGORY_DIAMOND)
            {
                productSelectedSideStone = objProductSideStoneDAL.ProductSideStoneFromSideStone(productId, sideStoneId, pageName);
            }
            else if(stoneCategoryId==ConstantHelper.STONE_CATEGORY_GEMSTONE)
            {
                productSelectedSideStone = objProductSideStoneDAL.GetProductSideStoneFromSideStoneType(productId, sideStoneId, pageName);
            }
            if (productSelectedSideStone!=null && productSelectedSideStone.StoneId > 0)
            {
                //check that design type
                if (productSelectedSideStone.DesignTypeId == ConstantHelper.SIDE_STONE_DESIGN_TYPE_ALTERNATE)
                {
                    //get the side stone details
                    SideStoneModel sideStoneModel = objSideStoneDAL.GetSideStoneList(productSelectedSideStone.StoneId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                    if (sideStoneModel != null)
                    {
                        if (productSelectedSideStone.StoneCategoryId == ConstantHelper.STONE_CATEGORY_GEMSTONE)
                        {
                            //for gemstone
                            //get the diamond price
                            ProductSideStoneModel productSideStoneDiamond = this.GetProductSideStoneModelFromShape(productId, productSelectedSideStone, ConstantHelper.STONE_CATEGORY_DIAMOND, pageName);
                            if (productSideStoneDiamond != null)
                            {
                                //get price of the alternative
                                //here no need to send the the stone category type it simple ignore
                                side_stone_price = objProductPriceDAL.SideStonePrice(productSideStoneDiamond.StoneId, sideStoneId, productSideStoneDiamond.NoOfStone, productSelectedSideStone.NoOfStone,productSelectedSideStone.StoneCategorySettingTypeId, CommonModel.StoneCategoryType.GEMSTONE, CommonModel.SideStoneDesignType.ALTERNATE);
                            }
                        }
                    }
                }
                else if (productSelectedSideStone.DesignTypeId == ConstantHelper.SIDE_STONE_DESIGN_TYPE_CONTINEOUS)
                {
                    //for conteneous
                    if (productSelectedSideStone.StoneCategoryId == ConstantHelper.STONE_CATEGORY_DIAMOND)
                    {
                        //for diamond
                        side_stone_price = objProductPriceDAL.SideStonePrice(sideStoneId, 0, productSelectedSideStone.NoOfStone, 0,productSelectedSideStone.StoneCategorySettingTypeId, CommonModel.StoneCategoryType.DIAMOND, CommonModel.SideStoneDesignType.CONTINEOUS);
                    }
                    else if (productSelectedSideStone.StoneCategoryId == ConstantHelper.STONE_CATEGORY_GEMSTONE)
                    {
                        //for gemstone
                        side_stone_price = objProductPriceDAL.SideStonePrice(0, sideStoneId, 0, productSelectedSideStone.NoOfStone,productSelectedSideStone.StoneCategorySettingTypeId, CommonModel.StoneCategoryType.GEMSTONE, CommonModel.SideStoneDesignType.CONTINEOUS);
                    }
                }
            }
            return side_stone_price;
        }

        private ProductSideStoneModel GetProductSideStoneModelFromShape(long productid, ProductSideStoneModel productSideStoneGemStoneModel, int stoneCategoryId, SideStoneActionModel.PageName pagename)
        {
            return objProductSideStoneDAL.GetProductSideStoneModelFromShape(productid, productSideStoneGemStoneModel, stoneCategoryId, pagename);
        }

        public double SideStoneTotalPrice(long productId, long selectedStoneId, SideStoneActionModel.PageName pageName)
        {
            double side_stone_diamond_price = 0;
            //
            ProductSideStoneModel productSideStoneModel = null;
            SideStoneModel sideStoneModel = objSideStoneDAL.GetSideStoneList(selectedStoneId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
            if (sideStoneModel == null)
            {
                return 0;
            }
            //get side stone diamond
            List<ProductSideStoneModel> lstProductSideStoneDiamond = objProductSideStoneDAL.ProductSideStoneList(productId, ConstantHelper.STONE_CATEGORY_DIAMOND, pageName, CommonModel.RecordStatus.Enabled);
            //get side stone gemstone
            List<ProductSideStoneModel> lstProductSideStoneGemstone = objProductSideStoneDAL.ProductSideStoneList(productId, ConstantHelper.STONE_CATEGORY_GEMSTONE, pageName, CommonModel.RecordStatus.Enabled).OrderBy(tbl => tbl.IsCustomize == true).ToList();
            //get the total shape
            int total_side_stone_diamond_shape = lstProductSideStoneDiamond.Count;
            int total_side_stone_gemstone_shape = lstProductSideStoneGemstone.Count;
            if (total_side_stone_diamond_shape > 0)
            {
                //for both side stone and gemstone
                //get all the gemstone
                if (sideStoneModel.StoneCategoryId == ConstantHelper.STONE_CATEGORY_DIAMOND)
                {
                    //for diamond case
                    productSideStoneModel = lstProductSideStoneDiamond.Where(tbl => tbl.StoneId == selectedStoneId).FirstOrDefault();
                }
                else if (sideStoneModel.StoneCategoryId == ConstantHelper.STONE_CATEGORY_GEMSTONE)
                {
                    //for gemstone
                    //get avialable type
                    //get product side stone from type
                    productSideStoneModel = objProductSideStoneDAL.GetProductSideStoneFromSideStoneType(productId, selectedStoneId, pageName);
                }
                //do the orginal
                if (productSideStoneModel != null)
                {
                    if (productSideStoneModel.StoneCategoryId == ConstantHelper.STONE_CATEGORY_DIAMOND)
                    {
                        //Its very simply for all diamond
                        //for doamond case                        
                        for (int i = 0; i < total_side_stone_diamond_shape; i++)
                        {
                            side_stone_diamond_price += this.SideStoneCustomizePrice(productId, lstProductSideStoneDiamond[i].StoneId, ConstantHelper.STONE_CATEGORY_DIAMOND, pageName);
                        }
                    }
                    else if (productSideStoneModel.StoneCategoryId == ConstantHelper.STONE_CATEGORY_GEMSTONE)
                    {
                        //
                        if (total_side_stone_gemstone_shape == 0)
                        {
                            return 0;
                        }
                        //condition
                        if (total_side_stone_gemstone_shape == 1 && total_side_stone_diamond_shape == 1)
                        {
                            //only one gemstone and one diamond side stone is present
                            side_stone_diamond_price += this.SideStoneCustomizePrice(productId, productSideStoneModel.StoneId, ConstantHelper.STONE_CATEGORY_GEMSTONE, pageName);
                        }
                        else
                        {
                            List<long> diamondSideStone = new List<long>();
                            SideStoneModel sideStoneCustomize = null;
                            for (int i = 0; i < total_side_stone_gemstone_shape; i++)
                            {
                                //top item is always customize
                                if (i == 0)
                                {
                                    //get the top item becuase its is the customize item
                                    //and if this will change then the rest side stone gems stone
                                    sideStoneCustomize = objSideStoneDAL.GetSideStoneList(productSideStoneModel.StoneId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                                }
                                //get the diamond
                                for (int j = 0; j < total_side_stone_diamond_shape; j++)
                                {
                                    //get the side stone diamond same as gemstone side stone shape
                                    SideStoneModel sideStoneSame = objProductSideStoneDAL.GetProductSideStoneDiamondSameAsGemStone(lstProductSideStoneDiamond[j], lstProductSideStoneGemstone[i]);
                                    if (sideStoneSame != null && sideStoneSame.SideStoneId > 0)
                                    {
                                        if (i == 0)
                                        {
                                            diamondSideStone.Add(lstProductSideStoneDiamond[j].StoneId);
                                            //get price
                                            side_stone_diamond_price += this.SideStoneCustomizePrice(productId, productSideStoneModel.StoneId, ConstantHelper.STONE_CATEGORY_GEMSTONE, pageName);
                                            break;
                                        }
                                        else
                                        {
                                            //get the details of the customize gemstone
                                            //get the available type of the side stone
                                            List<SideStoneModel> lstSideStoneAvailableType = objProductSideStoneDAL.GetProductSideStoneAvailableType(lstProductSideStoneGemstone[i].ProductSideStoneId, pageName);
                                            //get the appropriate side stone
                                            SideStoneModel sideStonePerfectMatching = lstSideStoneAvailableType.Where(tbl => tbl.StoneColorId == sideStoneCustomize.StoneColorId && tbl.StoneTypeId == sideStoneCustomize.StoneTypeId).FirstOrDefault();
                                            if (sideStonePerfectMatching != null)
                                            {
                                                //add in diamond
                                                diamondSideStone.Add(lstProductSideStoneDiamond[j].StoneId);
                                                //now calculate the price
                                                side_stone_diamond_price += this.SideStoneCustomizePrice(productId, sideStonePerfectMatching.SideStoneId, ConstantHelper.STONE_CATEGORY_GEMSTONE, pageName);
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
                                        side_stone_diamond_price += this.SideStoneCustomizePrice(productId, lstProductSideStoneDiamondRest[i].StoneId, ConstantHelper.STONE_CATEGORY_DIAMOND, pageName);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return side_stone_diamond_price;
        }

        public long DefaultSideStoneId(List<ProductSideStoneModel> lstProductSideStoneDiamond,List<ProductSideStoneModel> lstProductSideStoneGemstone, long productId, SideStoneActionModel.PageName pageName)
        {
            long default_stone_id = 0;
            ProductSideStoneModel productSideStoneModel = null;
            //get the total shape
            int total_side_stone_diamond_shape = lstProductSideStoneDiamond.Count;
            int total_side_stone_gemstone_shape = lstProductSideStoneGemstone.Count;
            //
            if (total_side_stone_diamond_shape > 0 && total_side_stone_gemstone_shape > 0)
            {
                //for both side stone and gemstone
                //get all the gemstone
                productSideStoneModel = lstProductSideStoneGemstone.Where(tbl => tbl.StoneId == lstProductSideStoneGemstone[0].StoneId).FirstOrDefault();
                //do the orginal
                if (productSideStoneModel != null)
                {
                    if (productSideStoneModel.StoneCategoryId == ConstantHelper.STONE_CATEGORY_GEMSTONE)
                    {
                        //condition
                        if (total_side_stone_gemstone_shape == 1 && total_side_stone_diamond_shape == 1)
                        {
                            //only one gemstone and one diamond side stone is present
                            default_stone_id = lstProductSideStoneDiamond[0].StoneId;
                        }
                        else
                        {
                            SideStoneModel sideStoneCustomize = null;
                            for (int i = 0; i < total_side_stone_gemstone_shape; i++)
                            {
                                //top item is always customize
                                if (i == 0)
                                {
                                    //get the top item becuase its is the customize item
                                    //and if this will change then the rest side stone gems stone
                                    sideStoneCustomize = objSideStoneDAL.GetSideStoneList(productSideStoneModel.StoneId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                                }
                                //get the diamond
                                for (int j = 0; j < total_side_stone_diamond_shape; j++)
                                {
                                    //get the side stone diamond same as gemstone side stone shape
                                    SideStoneModel sideStoneSame = objProductSideStoneDAL.GetProductSideStoneDiamondSameAsGemStone(lstProductSideStoneDiamond[j], lstProductSideStoneGemstone[i]);
                                    if (sideStoneSame != null && sideStoneSame.SideStoneId > 0)
                                    {
                                        if (i == 0)
                                        {
                                            //set default side stone
                                            default_stone_id = lstProductSideStoneDiamond[j].StoneId;
                                            return default_stone_id;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return default_stone_id;
        }

        public double MetalPrice(ProductDetailsModel productDetails, int metalTypeId)
        {
            return objProductPriceDAL.MetalPrice(metalTypeId, productDetails.ProductWeight);
        }

        public double CenterStonePrice(string SKU)
        {
            CenterStoneModel centerStone = objCenterStoneController.GetCenterStoneDetailsFromSKU(SKU);
            if (centerStone != null)
            {
                return centerStone.StonePrice;
            }
            return 0;
        }

        public double ProductTotalCustomizePrice(ProductDetailsModel productDetails,int metalTypeId,string centerStoneSKU,long sideStoneId)
        {
            double total = 0;
            try
            {
                //access the metal price
                double metalPrice = this.MetalPrice(productDetails, metalTypeId);
                double centerStonePrice = 0;
                if (centerStoneSKU.Length > 0)
                {
                    //access the center stone price
                    centerStonePrice = this.CenterStonePrice(centerStoneSKU);
                    //add center stone setting price
                    ProductCenterStoneModel productCenterStoneModel = objProductCenterStoneDAL.GetProductCenterStone(productDetails.ProductID, ConstantHelper.STONE_CATEGORY_DIAMOND);
                    if (productCenterStoneModel != null)
                    {
                        //defaulut stone is always 1
                        centerStonePrice += objProductPriceDAL.SettingPrice(productCenterStoneModel.StoneCategorySettingTypeId, ConstantHelper.STONE_CATEGORY_DIAMOND, 1);
                    }
                }
                //side stone price
                double side_stone_price = this.SideStoneTotalPrice(productDetails.ProductID, sideStoneId, SideStoneActionModel.PageName.SideStone);
                //matching band price
                double matching_band_price = this.SideStoneTotalPrice(productDetails.ProductID, sideStoneId, SideStoneActionModel.PageName.MatchingBand);
                //calculate the total price
                total = metalPrice + centerStonePrice + side_stone_price + matching_band_price;

            }
            catch (Exception ex)
            {

            }
            return total;
        }

    }
}
