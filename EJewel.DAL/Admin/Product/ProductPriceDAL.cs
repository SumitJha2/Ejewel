using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Master.Setting;
//dal
using EJewel.DAL.Admin.Master.Setting;
namespace EJewel.DAL.Admin.Product
{
    /// <summary>
    /// Product Price Details
    /// Author: Partha Ranjan @ 27-02-13
    /// </summary>
    public class ProductPriceDAL
    {
        EJewelEntities objEntity = new EJewelEntities();

        //get metal price
        public double MetalPrice(int metalTypeId, double ProductMetalWeight)
        {
            double metal_price = 0;
            try
            {
                ej_MetalTypeMaster metalType = objEntity.ej_MetalTypeMaster.Where(tbl => tbl.MetaTypeId == metalTypeId).FirstOrDefault();
                if (metalType != null)
                {
                    metal_price = Math.Round(metalType.Price * ProductMetalWeight, 0);
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
            return metal_price;
        }

        public double SideStonePrice(List<ProductSideStoneModel> lstSideStoneModel)
        {
            double side_stone_price = 0;
            try
            {
                int total_side_stone = lstSideStoneModel.Count;
                if (total_side_stone > 0)
                {
                    for (int i = 0; i < total_side_stone; i++)
                    {
                        side_stone_price += this.StonePrice(lstSideStoneModel[i].StoneId, lstSideStoneModel[i].NoOfStone, ConstantHelper.STONE_CATEGORY_GEMSTONE);//2 for side stone
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
            return side_stone_price;
        }

        public double SideStoneSettingPrice(List<ProductSideStoneModel> lstSideStoneModel)
        {
            double side_setting_price = 0;
            try
            {
                int total_side_stone = lstSideStoneModel.Count;
                if (total_side_stone > 0)
                {
                    for (int i = 0; i < total_side_stone; i++)
                    {
                        //2 for side stone
                        side_setting_price += this.SettingPrice(lstSideStoneModel[i].StoneCategorySettingTypeId, 2, lstSideStoneModel[i].NoOfStone);
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
            return side_setting_price;
        }

        public double ChainPrice(long productId)
        {
            return 0;
        }

        public double SettingPrice(int categorySettingTypeId, int stoneCategoryTypeId, int noOfStone)
        {
            double setting_price = 0;
            try
            {
                ej_StoneCategorySettingType settingtype = objEntity.ej_StoneCategorySettingType.Where(tbl => tbl.StoneCategorySettingTypeId == categorySettingTypeId && tbl.StoneCategoryTypeId == stoneCategoryTypeId).FirstOrDefault();
                if (settingtype != null)
                {
                    setting_price = Math.Round(settingtype.Price * noOfStone, 0);
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
            return setting_price;
        }

        private double StonePrice(long stoneId, int noOfStone, int stoneCategoryId)
        {
            /*
             * For future concept we will add the stone category id
             * 1 for center stone 2 for side stone
             * */
            double stone_price = 0;
            try
            {
                ej_SideStone stone = objEntity.ej_SideStone.Where(tbl => tbl.SideStoneId == stoneId).FirstOrDefault();
                if (stone != null)
                {
                    stone_price = Math.Round(stone.StonePrice * noOfStone, 0);
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
            return stone_price;

        }

        public double SideStonePrice(long stoneIdDiamond, long StoneIdGemstone, int noOfStoneDiamond, int noOfStoneGemstone, int categorySettingTypeId, CommonModel.StoneCategoryType contineousStoneCategoryType, CommonModel.SideStoneDesignType designType)
        {
            /*
             * For future concept we will add the stone category id
             * 1 for center stone 2 for side stone
             * */
            double side_stone_price = 0, stone_setting_price = 0;
            try
            {
                //get side stone diamond details
                ej_SideStone sideStoneDiamond = objEntity.ej_SideStone.Where(tbl => tbl.SideStoneId == stoneIdDiamond).FirstOrDefault();
                //get side stone gemstone details
                ej_SideStone sideStoneGemstone = objEntity.ej_SideStone.Where(tbl => tbl.SideStoneId == StoneIdGemstone).FirstOrDefault();
                //get the price of the setting type
                ej_StoneCategorySettingType stoneCategorySettingType = objEntity.ej_StoneCategorySettingType.Where(tbl => tbl.StoneCategorySettingTypeId == categorySettingTypeId && tbl.StoneCategoryTypeId == ConstantHelper.STONE_CATEGORY_GEMSTONE).FirstOrDefault();
                if (stoneCategorySettingType != null)
                {
                    double per_stone_price = stoneCategorySettingType.Price;
                    switch (designType)
                    {
                        case CommonModel.SideStoneDesignType.ALTERNATE:
                            {
                                if (sideStoneDiamond != null && sideStoneGemstone != null)
                                {
                                    //for alternate
                                    //now do the logic
                                    int total_no_of_diamond = noOfStoneDiamond - noOfStoneGemstone;
                                    //calculate the price
                                    //for diamond
                                    side_stone_price = Math.Round(sideStoneDiamond.StonePrice * total_no_of_diamond, 0);
                                    //set diamond setting price
                                    stone_setting_price = Math.Round(per_stone_price * total_no_of_diamond, 0);
                                    //for side stone
                                    side_stone_price += Math.Round(sideStoneGemstone.StonePrice * noOfStoneGemstone, 0);
                                    //set gemstone setting price
                                    stone_setting_price += Math.Round(per_stone_price * noOfStoneGemstone, 0);
                                }
                            } break;
                        case CommonModel.SideStoneDesignType.CONTINEOUS:
                            {
                                //for contineous
                                switch (contineousStoneCategoryType)
                                {
                                    case CommonModel.StoneCategoryType.DIAMOND:
                                        {
                                            if (sideStoneDiamond != null)
                                            {
                                                side_stone_price = Math.Round(sideStoneDiamond.StonePrice * noOfStoneDiamond, 0);
                                                stone_setting_price = Math.Round(per_stone_price * noOfStoneDiamond, 0);
                                            }
                                        } break;
                                    case CommonModel.StoneCategoryType.GEMSTONE:
                                        {
                                            if (sideStoneGemstone != null)
                                            {
                                                side_stone_price = Math.Round(sideStoneGemstone.StonePrice * noOfStoneGemstone, 0);
                                                stone_setting_price = Math.Round(per_stone_price * noOfStoneGemstone, 0);
                                            }
                                        } break;
                                }

                            } break;
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
            return (side_stone_price + stone_setting_price);
        }

    }
}
