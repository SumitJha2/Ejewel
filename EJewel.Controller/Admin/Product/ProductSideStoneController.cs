using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Master.Stone;
//dal
using EJewel.DAL.Admin.Product;
namespace EJewel.Controller.Admin.Product
{
    public class ProductSideStoneController
    {
        ProductSideStoneDAL objDAL = new ProductSideStoneDAL();
        private string _heading = "";
        public SideStoneActionModel.PageName GetPageView(string pageName)
        {
            SideStoneActionModel.PageName pName = SideStoneActionModel.PageName.SideStone;
            switch (pageName)
            {
                default:
                case "stone_category":
                    {
                        pName = SideStoneActionModel.PageName.SideStone;
                        this.Heading = "Product Side Stone";
                    }
                    break;
                case "matching_band":
                    {
                        pName = SideStoneActionModel.PageName.MatchingBand;
                        this.Heading = "Product Matching Band Side Stone";
                    }
                    break;
            }
            return pName;
        }

        public string Heading
        {
            get { return _heading; }
            private set { _heading = value; }
        }

        public ProductSideStoneRangeModel SaveUpdateProductSideStoneRange(ProductSideStoneRangeModel model, SideStoneActionModel.PageName pageName)
        {
            return objDAL.SaveUpdateProductSideStoneRange(model, pageName);
        }

        public ProductSideStoneShapeModel SaveUpdateProductSideStoneShape(ProductSideStoneShapeModel model, SideStoneActionModel.PageName pageName)
        {
            return objDAL.SaveUpdateProductSideStoneShape(model, pageName);
        }

        public ProductSideStoneModel SaveUpdateProductSideStone(ProductSideStoneModel model, SideStoneActionModel.PageName pageName)
        {
            return objDAL.SaveUpdateProductSideStone(model, pageName);
        }

        public ProductSideStoneAvialableStoneTypeModel SaveUpdateProductSideStoneAvialableStoneType(ProductSideStoneAvialableStoneTypeModel model, SideStoneActionModel.PageName pageName)
        {
            return objDAL.SaveUpdateProductSideStoneAvialableStoneType(model, pageName);
        }

        public List<ProductSideStoneAvialableStoneTypeModel> GetProductStoneTypeListFromSideStone(long sidestoneId, SideStoneActionModel.PageName pagename)
        {
            return objDAL.GetProductStoneTypeListFromSideStone(sidestoneId, pagename);
        }

        public List<ProductSideStoneModel> ProductSideStoneList(long productID, int stoneCategoryID, SideStoneActionModel.PageName pageName, CommonModel.RecordStatus rStatus)
        {
            return objDAL.ProductSideStoneList(productID, stoneCategoryID, pageName, rStatus);
        }

        public ProductSideStoneRangeModel ProductSideStoneRange(long productID, int stoneCategoryID, SideStoneActionModel.PageName pageName)
        {
            return objDAL.ProductSideStoneRange(productID, stoneCategoryID, pageName);
        }

        public List<int> StoneShapeList(long sideStoneRangeId, SideStoneActionModel.PageName pageName, CommonModel.RecordStatus rStatus)
        {
            return objDAL.StoneShapeList(sideStoneRangeId, pageName, rStatus);
        }

        public List<long> StoneTypeSideStoneIdList(long productSideStoneId, SideStoneActionModel.PageName pageName)
        {
            return objDAL.StoneTypeSideStoneIdList(productSideStoneId, pageName);
        }
        /*
         * sumit jha
         * @ 04-04-2013
         * */
        public List<StoneSpecificationModel> StoneShapeListForView(long sideStoneRangeId, SideStoneActionModel.PageName pageName)
        {
            return objDAL.StoneShapeListForView(sideStoneRangeId, pageName);
        }
        /*
         * sumit jha
         * @ 04-04-2013
         * */
        public List<ProductSideStoneDetailModel> ProductSideStoneListForView(long sideStoneRangeId, int stoneCategoryId, SideStoneActionModel.PageName pageName)
        {
            return objDAL.ProductSideStoneListForView(sideStoneRangeId, stoneCategoryId, pageName);
        }
        /*
        * sumit jha
        * @ 04-04-2013
        * */
        public List<StoneSpecificationModel> GetProductStoneType(long sidestoneId, SideStoneActionModel.PageName pagename)
        {
            return objDAL.GetProductStoneType(sidestoneId, pagename);
        }

        public List<SideStoneModel> GetProductSideStoneAvailableType(long sidestoneId, SideStoneActionModel.PageName pagename)
        {
            return objDAL.GetProductSideStoneAvailableType(sidestoneId, pagename);
        }
        /* sumit jha
       * @ stoneType  in side stone and matching band
       * 12-04-2013
       **/
        public List<StoneSpecificationModel> GetStoneTypeByCaretAndShape(int StonecategoryId, int shapeId, double carat)
        {
            return objDAL.GetStoneTypeByCaretAndShape(StonecategoryId, shapeId, carat);
        }

        public List<ProductSideStoneDesignTypeModel> GetProductSideStoneDesignType()
        {
            List<ProductSideStoneDesignTypeModel> lst = new List<ProductSideStoneDesignTypeModel>();
           /* lst.Add(new ProductSideStoneDesignTypeModel()
            {
                DesignType = "None",
                DesignTypeId = 0
            });*/
            lst.Add(new ProductSideStoneDesignTypeModel()
            {
                DesignType="Alternate",
                DesignTypeId=1
            });
            lst.Add(new ProductSideStoneDesignTypeModel()
            {
                DesignType = "Continuous",
                DesignTypeId = 2
            });
            return lst;
        }

        public ProductSideStoneModel GetProductSideStoneFromSideStoneType(long productId, long sideStoneId, SideStoneActionModel.PageName pagename)
        {
            return objDAL.GetProductSideStoneFromSideStoneType(productId, sideStoneId, pagename);
        }
        public SideStoneModel GetProductSideStoneDiamondSameAsGemStone(ProductSideStoneModel sideStoneDiamond, ProductSideStoneModel sideStoneGemstone)
        {
            return objDAL.GetProductSideStoneDiamondSameAsGemStone(sideStoneDiamond, sideStoneGemstone);
        }
        /* sumit jha
     * @ 03-06-2013 
     * for product view
     * *
     */
        public List<ProductSideStoneShapeModel> GetSideStoneAvailableShape(long sidestonerangeId, int stonecategoryid, SideStoneActionModel.PageName pageName)
        {
            return objDAL.GetSideStoneAvailableShape(sidestonerangeId, stonecategoryid, pageName);
        }

        public List<SideStoneModel> GetProductStoneAvailable_Type(long sidestoneId, SideStoneActionModel.PageName pagename)
        {
            return objDAL.GetProductStoneAvailable_Type(sidestoneId, pagename);
        }

    }
}
