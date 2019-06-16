using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Master.Setting;
using EJewel.DAL.Admin.Master.Setting;
using EJewel.Model.Admin.Master.Stone;
namespace EJewel.DAL.Admin.Product
{
    /*
    * Partha Ranjan
    * @ 19-01-2013
    * this class helps to do all the operation of the product details
    * */
    public class ProductDetailsDAL
    {
        EJewelEntities objEntity = new EJewelEntities();
        //added by sumit for price calculation
        ProductSideStoneDAL objSideStoneDAL = new ProductSideStoneDAL();
        ProductPriceDAL objProductPrice = new ProductPriceDAL();
        StoneCategorySettingTypeDAL objSettingTypeDAL = new StoneCategorySettingTypeDAL();
        StoneCategorySettingTypeModel objStoneSettongTypeModel = new StoneCategorySettingTypeModel();
        ProductCenterStoneDAL objCenterStoneDAL = new ProductCenterStoneDAL();
        ProductDetailsModel objProductDetailsModel = new ProductDetailsModel();
        ProductMetalDAL objProductMetalDAL = new ProductMetalDAL();
        ProductPriceDAL objProductPriceDAL = new ProductPriceDAL();

        public ProductDetailsModel SaveUpdateProductDetails(ProductDetailsModel model)
        {
            try
            {
                if (model.ProductID == 0)
                {
                    //for save mode
                    ej_Product product = new ej_Product()
                    {
                        ProductId = model.ProductID,
                        SubCategoryID = model.SubCategoryID,
                        SKU = model.SKU,
                        ProductTitle = model.ProductTitle,
                        ProductDescription = model.ProductDescripation,
                        PageTitle = model.PageTitle,
                        MetaKeywords = model.MetaKeyword,
                        MetaDescription = model.MetaDescripation,
                        //

                        Status = model.Status,
                        NewProduct = true,
                        Publish = true


                    };
                    objEntity.AddToej_Product(product);
                    objEntity.SaveChanges();
                    model.ProductID = product.ProductId;
                }
                else
                {
                    //for update mode
                    ej_Product product = objEntity.ej_Product.Where(tbl => tbl.ProductId == model.ProductID).FirstOrDefault();
                    if (product != null)
                    {
                        //set the value of the sku
                        //check that the same sku is present || not
                        if (!objEntity.ej_Product.Where(tbl => tbl.SKU == model.SKU).Any())
                        {
                            product.SKU = model.SKU;
                        }
                        //check that the category is present || not
                        if (!objEntity.ej_Product.Where(tbl => tbl.SubCategoryID == model.SubCategoryID && tbl.SKU == model.SKU).Any())
                        {
                            product.SubCategoryID = model.SubCategoryID;
                        }
                        //set the field value
                        product.ProductTitle = model.ProductTitle;
                        product.ProductDescription = model.ProductDescripation;
                        //seo
                        product.PageTitle = model.PageTitle;
                        product.MetaKeywords = model.MetaKeyword;
                        product.MetaDescription = model.MetaDescripation;
                        objEntity.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return model;
        }

        public bool ExitProductSKU(string sku)
        {
            try
            {
                return objEntity.ej_Product.Where(pro => pro.SKU == sku).Any();
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return false;
        }

        public bool ExistProductTitle(string title)
        {
            try
            {
                return objEntity.ej_Product.Where(pro => pro.ProductTitle == title).Any();
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return false;
        }

        public List<ProductDetailsModel> GetProductList(long productID)
        {
            try
            {
                List<ej_Product> lstproduct = new List<ej_Product>();
                List<ProductDetailsModel> lstmodelwithprice = new List<ProductDetailsModel>();
                if (productID > 0)
                {
                    lstproduct = objEntity.ej_Product.Where(pr => pr.ProductId == productID).ToList();
                }
                else
                {
                    lstproduct = objEntity.ej_Product.Select(pr => pr).ToList();
                }
                return this.GetProductList(lstproduct);
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return null;
        }

        private List<ProductDetailsModel> GetProductList(List<ej_Product> lstproduct)
        {
            try
            {
                if (lstproduct != null)
                {
                    List<ProductDetailsModel> lstmodel = (from product in lstproduct
                                                          join subCategory in objEntity.ej_SubCategoryMaster
                                                          on product.SubCategoryID equals subCategory.SubCategoryId
                                                          join primaryCategory in objEntity.ej_PrimaryCategory
                                                          on subCategory.CategoryId equals primaryCategory.CategoryId

                                                          where subCategory.Status == true && primaryCategory.Status == true

                                                          select new ProductDetailsModel
                                                          {
                                                              ProductID = product.ProductId,
                                                              SKU = product.SKU,
                                                              SubCategoryID = product.SubCategoryID,
                                                              ProductTitle = product.ProductTitle,
                                                              PrimaryCategoryName = primaryCategory.CategoryName,
                                                              PrimaryCategoryId = primaryCategory.CategoryId,
                                                              SubCategoryName = subCategory.SubCategoryName,
                                                              ProductDescripation = product.ProductDescription,
                                                              //27-02-13 default price this.ProductTotalDefaultPrice(product.ProductId, product.ProductWeight)
                                                              Status = product.Status,
                                                              Publish = product.Publish,
                                                              ProductWeight = product.ProductWeight,//added by sumit on 30-03-2013
                                                              ProductWidth = product.ProductWidth,//added by sumit on 30-03-2013
                                                              PageTitle = product.PageTitle,
                                                              MetaKeyword = product.MetaKeywords,
                                                              MetaDescripation = product.MetaDescription,
                                                              /* added by sumit on 09-05-2013 */
                                                              //added by sumit on 14-05-2013
                                                              BestSelling = product.BestSelling,
                                                              OnSale = product.OnSale,
                                                              OtherGift = product.OtherGift,
                                                              MenGift = product.ManGift,
                                                              WomenGift = product.WomenGift,
                                                              ChildrenGift = product.ChildrenGift,
                                                              DiscountType = product.DiscountType,
                                                              NewProduct = product.NewProduct,
                                                              Discount = (float)product.Discount,
                                                              IsExtraOrdinary = product.IsExtraOrdinary,
                                                              ProductDefaultPrice = ProductTotalDefaultPrice(product.ProductId, product.ProductWeight, product.IsExtraOrdinary)
                                                          }).OrderByDescending(pr => pr.ProductID).ToList();
                    return lstmodel;
                }
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return null;
        }

        public List<ProductDetailsModel> GetProductList(long productID, int currentPageIndex, int perPageSize)
        {
            try
            {
                List<ProductDetailsModel> lstProduct = this.GetProductList(productID);
                return lstProduct.Skip(currentPageIndex * perPageSize).Take(perPageSize).ToList();
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return null;
        }

        //Get the product deetails from SKU :) Partha @ 08-04-13
        public ProductDetailsModel GetProductFromSKU(string sku)
        {
            try
            {
                return this.GetProductList(objEntity.ej_Product.Where(tbl => tbl.SKU == sku).ToList()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return null;
        }

        public int TotalProduct
        {
            get
            {
                try
                {
                    return objEntity.ej_Product.Select(tbl => tbl).Count();
                }
                catch (Exception ex)
                {
                    ErrorLogDAL obj = new ErrorLogDAL();
                    obj.SetErrorLog(new ErrorLogModel()
                    {
                        ErrorMessage = ex.Message,
                        ErrorSource = ex.Source,
                        InnerException = Convert.ToString(ex.InnerException),
                        LogTime = DateTime.Now,
                        StackTrace = ex.StackTrace,
                        UserID = "DAL"
                    });
                }
                return 0;
            }
        }

        public double ProductTotalDefaultPrice(long productId, double metalWeight,bool extraOdinary)
        {
            try
            {
                //get the default metal
                ProductMetalModel productMetalmodel = objProductMetalDAL.GetProductDefaultMetalType(productId);
                if (productMetalmodel != null)
                {
                    //get the center Stone Price
                    return this.ProductPriceDetails(productId, productMetalmodel.MetalTypeID, metalWeight, extraOdinary).TotalPrice;
                }
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return 0;
        }
       
        /* sumit jha
      *  This function is used for listing in front end...
      * @ 25-03-2013
         * modified by partha
         * @ 08-04-13
      * */
        public List<ProductDetailsModel> GetProductDetailsForListing(int primartCategoryId, int subCategoryId, string centerStoneshape, string sideStoneshape, string centerStoneSettingTypeName, string sideStoneSettingTypeName, double minPrice, double maxPrice, string gemstone_color, string gemstone_type,bool is_new_arrival,bool is_on_sales, int currentPage, int perPage)
        {
            try
            {
                //get the product details
                //get the data based on sub category
                List<ej_Product> lstProduct = new List<ej_Product>();
                if (subCategoryId > 0)
                {
                    lstProduct = objEntity.ej_Product.Where(tbl => tbl.SubCategoryID == subCategoryId).ToList();
                }
                else
                {
                    lstProduct = objEntity.ej_Product.Select(tbl => tbl).ToList();
                }
                List<ProductDetailsModel> lstProductModel = this.GetProductList(lstProduct);
                //for primary category
                //for no new arrival
                if (primartCategoryId > 0)
                {
                    //for primary category
                    lstProductModel = lstProductModel.Where(tbl => tbl.PrimaryCategoryId == primartCategoryId).ToList();
                }
                if (is_new_arrival)
                {
                    lstProductModel = lstProductModel.Where(tbl => tbl.NewProduct == true).ToList();
                }
                if (is_on_sales)
                {
                    lstProductModel = lstProductModel.Where(tbl => tbl.OnSale == true).ToList();
                }
                //
                if (lstProductModel != null && lstProductModel.Count > 0)
                {
                    //for center stone shape wise filter
                    if (centerStoneshape != null && centerStoneshape.Length > 0)
                    {
                        lstProductModel = (from product in lstProductModel
                                           join centerStone in objEntity.ej_ProductCenterStone
                                           on product.ProductID equals centerStone.ProductId
                                           join centerStoneShape in objEntity.ej_ProductCenterStoneShape
                                           on centerStone.ProductCenterStoneId equals centerStoneShape.ProductCenterStoneId
                                           join stone in objEntity.ej_StoneShape
                                           on centerStoneShape.StoneShapeId equals stone.StoneShapeId
                                           join stoneMaster in objEntity.ej_StoneShapeMaster
                                           on stone.ShapeId equals stoneMaster.ShapeId
                                           where stoneMaster.Shape == centerStoneshape && centerStone.Status == true
                                           && centerStoneShape.Status == true && stone.Status == true
                                           select product).ToList();
                    }
                    //for side stone
                    if (sideStoneshape != null && sideStoneshape.Length > 0)
                    {
                        lstProductModel = (from product in lstProductModel
                                           join pss in objEntity.ej_ProductSideStone
                                           on product.ProductID equals pss.ProductId
                                           join sideStone in objEntity.ej_SideStone
                                           on pss.StoneId equals sideStone.SideStoneId
                                           join stone in objEntity.ej_StoneShape
                                           on sideStone.StoneShapeId equals stone.StoneShapeId
                                           join stoneMaster in objEntity.ej_StoneShapeMaster
                                           on stone.ShapeId equals stoneMaster.ShapeId
                                           where stoneMaster.Shape == sideStoneshape && pss.Status == true
                                           && sideStone.Status == true
                                           select product).ToList();
                    }
                    //for setting type Center Stone
                    if (centerStoneSettingTypeName != null && centerStoneSettingTypeName.Length > 0)
                    {
                        lstProductModel = (from product in lstProductModel
                                           join pcs in objEntity.ej_ProductCenterStone
                                           on product.ProductID equals pcs.ProductId
                                           join stonecategorysettingtype in objEntity.ej_StoneCategorySettingType
                                           on pcs.StoneCategorySettingTypeId equals stonecategorysettingtype.StoneCategorySettingTypeId
                                           join settingtype in objEntity.ej_SettingType on
                                           stonecategorysettingtype.SettingTypeId equals settingtype.SettingTypeId
                                           where settingtype.SettingTypeName == centerStoneSettingTypeName &&
                                           pcs.Status == true && stonecategorysettingtype.Status == true
                                           && settingtype.Status == true
                                           select product).ToList();
                    }

                    //for setting type sideStone
                    if (sideStoneSettingTypeName != null && sideStoneSettingTypeName.Length > 0)
                    {
                        lstProductModel = (from product in lstProductModel
                                           join pss in objEntity.ej_ProductSideStone
                                           on product.ProductID equals pss.ProductId
                                           join stonecategorysettingtype in objEntity.ej_StoneCategorySettingType
                                           on pss.StoneCategorySettingTypeId equals stonecategorysettingtype.StoneCategorySettingTypeId
                                           join settingtype in objEntity.ej_SettingType on
                                           stonecategorysettingtype.SettingTypeId equals settingtype.SettingTypeId
                                           where settingtype.SettingTypeName == sideStoneSettingTypeName && pss.Status == true
                                           && stonecategorysettingtype.Status == true && settingtype.Status == true && pss.StoneCategoryId == 1
                                           select product).ToList();
                    }
                    //color
                    if (gemstone_color != null && gemstone_color.Length > 0)
                    {
                        lstProductModel = (from product in lstProductModel
                                           join sidestone in objEntity.ej_ProductSideStone
                                           on product.ProductID equals sidestone.ProductId
                                           join avltype in objEntity.ej_ProductSideStoneAvialableStoneType
                                           on sidestone.ProductSideStoneId equals avltype.ProductSideStoneId
                                           join stone in objEntity.ej_SideStone
                                           on avltype.StoneId equals stone.SideStoneId
                                           join color in objEntity.ej_StoneColor
                                           on stone.StoneColorId equals color.StoneColorId
                                           where color.StoneColorName == gemstone_color && sidestone.StoneCategoryId == 2
                                           && sidestone.Status == true && stone.Status == true && avltype.Status == true
                                           && color.Status == true
                                           select product).ToList();


                    }
                    //stone type (gem stone type)
                    if (gemstone_type != null && gemstone_type.Length > 0)
                    {
                        lstProductModel = (from product in lstProductModel
                                           join sidestone in objEntity.ej_ProductSideStone
                                           on product.ProductID equals sidestone.ProductId
                                           join avltype in objEntity.ej_ProductSideStoneAvialableStoneType
                                           on sidestone.ProductSideStoneId equals avltype.ProductSideStoneId
                                           join stone in objEntity.ej_SideStone
                                           on avltype.StoneId equals stone.SideStoneId
                                           join type in objEntity.ej_StoneType
                                           on stone.StoneTypeId equals type.StoneTypeId
                                           where type.StoneTypeName == gemstone_type && sidestone.StoneCategoryId == 2
                                           && sidestone.Status == true && stone.Status == true && avltype.Status == true
                                           && type.Status == true
                                           select product).ToList();

                    }
                    //for price
                    if (minPrice >= 0 && maxPrice > 0)
                    {
                        //for range
                        lstProductModel = lstProductModel.Where(tbl => tbl.ProductDefaultPrice >= minPrice && tbl.ProductDefaultPrice < maxPrice).ToList();
                    }
                    else if (minPrice > 0)
                    {
                        //for more than min price
                        lstProductModel = lstProductModel.Where(tbl => tbl.ProductDefaultPrice >= minPrice).ToList();
                    }
                    //now just do some opeartion
                    //get distinct product
                    IEnumerable<long> lstProductIds = lstProductModel.Select(product => product.ProductID).Distinct();
                    lstProductModel = (from lstPro in lstProductModel
                                       where lstProductIds.Contains(lstPro.ProductID)
                                       select lstPro).ToList();

                }
                this.TotalFilterProduct = lstProductModel.Count;
                lstProductModel = lstProductModel.Skip(currentPage * perPage).Take(perPage).ToList();
                return lstProductModel;
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return null;
        }
        /* sumit jha
        * @ 30-03-2013
        * */
        public ProductPriceModel ProductPriceDetails(long productId, int metalTypeId, double productWeight, bool extraOdinary)
        {
            try
            {
                double total_price = 0;
                //metal price
                double metal_price = objProductPriceDAL.MetalPrice(metalTypeId, productWeight);
                //stone price
                List<ProductSideStoneModel> lstSideStoneDiamondModel = objSideStoneDAL.ProductSideStoneList(productId, ConstantHelper.STONE_CATEGORY_DIAMOND, SideStoneActionModel.PageName.SideStone, CommonModel.RecordStatus.Both);
                List<ProductSideStoneModel> lstSideStoneGemstoneModel = objSideStoneDAL.ProductSideStoneList(productId, ConstantHelper.STONE_CATEGORY_GEMSTONE, SideStoneActionModel.PageName.SideStone, CommonModel.RecordStatus.Both);

                List<ProductSideStoneModel> lstMatchingBandDiamondModel = objSideStoneDAL.ProductSideStoneList(productId, ConstantHelper.STONE_CATEGORY_DIAMOND, SideStoneActionModel.PageName.MatchingBand, CommonModel.RecordStatus.Both);
                List<ProductSideStoneModel> lstMatchingBandGemstoneModel = objSideStoneDAL.ProductSideStoneList(productId, ConstantHelper.STONE_CATEGORY_GEMSTONE, SideStoneActionModel.PageName.MatchingBand, CommonModel.RecordStatus.Both);
                //get setting price
                double center_stone_setting_price = 0;
                //This Price is only for the center stone model
                ProductCenterStoneModel productCenterStoneModel = objCenterStoneDAL.GetProductCenterStone(productId, ConstantHelper.STONE_CATEGORY_DIAMOND);
                if (productCenterStoneModel != null)
                {
                    center_stone_setting_price = objProductPriceDAL.SettingPrice(productCenterStoneModel.StoneCategorySettingTypeId, ConstantHelper.STONE_CATEGORY_DIAMOND, 1);
                }
                double side_stone_setting_price = objProductPrice.SideStoneSettingPrice(lstSideStoneDiamondModel);
                double matching_band_setting_price = objProductPrice.SideStoneSettingPrice(lstMatchingBandDiamondModel);
                //get side stone
                //get side stone price diamond
                double side_stone_price_diamond = objProductPrice.SideStonePrice(lstSideStoneDiamondModel);
                //get matching band price diamond
                double matching_band_price_diamond = objProductPrice.SideStonePrice(lstMatchingBandDiamondModel);
                //extra odinary price
                if (extraOdinary)
                {
                    //add gemstone setting price
                    side_stone_setting_price += objProductPrice.SideStoneSettingPrice(lstSideStoneGemstoneModel);
                    matching_band_setting_price += objProductPrice.SideStoneSettingPrice(lstMatchingBandGemstoneModel);
                    //gem stone price
                    side_stone_price_diamond += this.SideStoneGemstonePrice(lstSideStoneGemstoneModel, SideStoneActionModel.PageName.SideStone);
                    matching_band_price_diamond += this.SideStoneGemstonePrice(lstMatchingBandGemstoneModel, SideStoneActionModel.PageName.MatchingBand);
                }
                //get chain price
                double chain_price = objProductPriceDAL.ChainPrice(productId);
                //setting price
                double setting_price = center_stone_setting_price + side_stone_setting_price + matching_band_setting_price;
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
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return null;
        }

        private double SideStoneGemstonePrice(List<ProductSideStoneModel> lstSideStoneModel, SideStoneActionModel.PageName pName)
        {
            double total = 0;
            try
            {
                if (lstSideStoneModel != null)
                {
                    ProductSideStoneDAL objProductSideStoneDAL = new ProductSideStoneDAL();
                    int total_side_stone_shape = lstSideStoneModel.Count;
                    int total_avilable_type = 0;
                    for (int i = 0; i < total_side_stone_shape; i++)
                    {
                        List<SideStoneModel> lstpssast = objProductSideStoneDAL.GetProductSideStoneAvailableType(lstSideStoneModel[i].ProductSideStoneId, pName);
                        if (lstpssast != null)
                        {
                            total_avilable_type = lstpssast.Count;
                            for (int j = 0; j < total_avilable_type; j++)
                            {
                                total += Math.Round(lstpssast[j].StonePrice * lstSideStoneModel[i].NoOfStone, 0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return total;
        }

        /* sumit jha
        * @ 09-05-2013
        * */
        public List<string> GetSkuByName(string name)
        {
            List<string> lstSku = new List<string>();
            try
            {
                List<ej_Product> lstProduct = objEntity.ej_Product.Where(tbl => tbl.SKU.Contains(name) && tbl.Status == true).ToList();
                lstSku = (from lst in lstProduct
                          select lst.SKU).ToList();
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return lstSku;
        }
        /* sumit jha
  * @ 14-05-2013
  * */
        public bool UpdateProductSetting(ProductDetailsModel model)
        {
            try
            {
                ej_Product objProduct = objEntity.ej_Product.Where(tbl => tbl.ProductId == model.ProductID).FirstOrDefault();
                if (objProduct != null)
                {
                    objProduct.OnSale = model.OnSale;
                    objProduct.NewProduct = model.NewProduct;
                    objProduct.OtherGift = model.OtherGift;
                    objProduct.ManGift = model.MenGift;
                    objProduct.WomenGift = model.WomenGift;
                    objProduct.ChildrenGift = model.ChildrenGift;
                    objProduct.DiscountType = Convert.ToInt32(model.DiscountType);
                    objProduct.BestSelling = model.BestSelling;
                    objProduct.Discount = model.Discount;
                    objProduct.Publish = model.Publish;
                    objProduct.IsExtraOrdinary = model.IsExtraOrdinary;
                    objEntity.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return false;
        }

        public long GetProductIDByProductSKU(string productSKU)
        {

            try
            {

                List<long> choolCourse = (from cs in objEntity.ej_Product
                                          where cs.SKU == productSKU
                                          select cs.ProductId).ToList();

                long productId = choolCourse.Select(tbl => tbl).FirstOrDefault();

                return productId;
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return 0;




        }

        int _totalFilterProduct = 0;

        public int TotalFilterProduct
        {
            get { return _totalFilterProduct; }
            private set { _totalFilterProduct = value; }
        }

    }
}
