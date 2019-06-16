using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
//model
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Master.Metal;
using EJewel.Model.Admin.Common;
//dal
using EJewel.DAL.Admin.Product;
using EJewel.DAL.Admin.Master.Stone;
namespace EJewel.Controller.Admin.Product
{
    /// <summary>
    /// Helps to manage the product image
    /// Partha Ranjan
    /// @ 02-04-13
    /// </summary>
    public class ProductImageController
    {
        ProductImageDAL objProductImageDAL = new ProductImageDAL();
        public List<MetalTypeListModel> GetMetalTypeList(long productId)
        {
            return new ProductViewController().GetMetalTypeList(productId);
        }

        public List<StoneSpecificationModel> GetProductCenterStoneList(long productId,int stoneCategoryId, List<StoneSpecificationModel> lstStoneShapeModel)
        {
            return objProductImageDAL.GetProductCenterStoneList(productId,stoneCategoryId,lstStoneShapeModel);
        }

        public List<ProductSideStoneImageModel> GetProductSideStoneList(long productId, int stoneCategoryId, List<SideStoneModel> lstSideStoneModel, SideStoneActionModel.PageName pageName)
        {
            return objProductImageDAL.GetProductSideStoneList(productId,stoneCategoryId,lstSideStoneModel,pageName);
        }

        public List<StoneSpecificationModel> GetSideStoneTypeList(long productSideStoneId, List<StoneSpecificationModel> lstStoneTypeModel, SideStoneActionModel.PageName pageName)
        {
            List<int> lstProductSideStoneTypeList = new List<int>();// new ProductSideStoneDAL().StoneTypeList(productSideStoneId, pageName);
            if (lstStoneTypeModel != null && lstProductSideStoneTypeList != null)
            {
                lstStoneTypeModel = (from stoneType in lstStoneTypeModel
                                     where (lstProductSideStoneTypeList.Contains(stoneType.AutoID))
                                     select stoneType).ToList();
            }
            return lstStoneTypeModel;
        }

        public List<ProductImageSideStoneModel> GetSideStoneImageListWithoutType(List<ProductSideStoneImageModel> lstSideStoneModel)
        {
            //init
            List<ProductImageSideStoneModel> lstProductImageSideStone=new List<ProductImageSideStoneModel>();
            int total_side_stone = lstSideStoneModel.Count;
            for (int j = 0; j < total_side_stone; j++)
            {
                lstProductImageSideStone.Add(new ProductImageSideStoneModel()
                {
                    SideStoneShape = lstSideStoneModel[j].Shape,
                    SideStoneShapeId = lstSideStoneModel[j].ShapeId,
                    ProductSideStoneId = lstSideStoneModel[j].ProductSideStoneId
                });
            }
            return lstProductImageSideStone;
        }

        public List<ProductImageSideStoneTypeModel>[] GetSideStoneImageListWithType(List<ProductSideStoneImageModel> lstSideStoneModel, List<StoneSpecificationModel> lstStoneTypeModel, SideStoneActionModel.PageName sideStonePageName)
        {
            int total_side_stone = lstSideStoneModel.Count;
            if (total_side_stone > 0)
            {
                List<List<StoneSpecificationModel>> lstSideStoneType = new List<List<StoneSpecificationModel>>();
                for (int i = 0; i < total_side_stone; i++)
                {
                    List<StoneSpecificationModel> lstSideStoneTypeModel = this.GetSideStoneTypeList(lstSideStoneModel[i].ProductSideStoneId, lstStoneTypeModel, sideStonePageName);
                    if (lstSideStoneTypeModel != null)
                    {
                        lstSideStoneType.Add(lstSideStoneTypeModel);
                    }
                }
                List<ProductImageSideStoneTypeModel>[] arrProductImageSideStoneTypeList = this.GeneratePermutationCombinationForSideStone(lstSideStoneType, total_side_stone);
                return arrProductImageSideStoneTypeList;
            }
            return null;
        }

        private List<ProductImageSideStoneTypeModel> [] GeneratePermutationCombinationForSideStone(List<List<StoneSpecificationModel>> lstSideStoneType,int total_side_stone)
        {
            //this hard codered for till concept 
            /*
             * We will take maximum 3 shape for side stone
             * */
            List<ProductImageSideStoneTypeModel>[] lstProductSideStoneType = new List<ProductImageSideStoneTypeModel>[total_side_stone];
            switch (total_side_stone)
            {
                case 1:
                    {
                        int total_type = lstSideStoneType[0].Count;
                        if (total_type > 0)
                        {
                            for (int i = 0; i < total_type; i++)
                            {
                                lstProductSideStoneType[0].Add(new ProductImageSideStoneTypeModel()
                                {
                                    SideStoneTypeId = lstSideStoneType[0][i].AutoID,
                                    SideStoneType = lstSideStoneType[0][i].Name
                                });
                            }
                        }
                    }
                    break;
                case 2:
                    {
                        int c1 = lstSideStoneType[0].Count;
                        int c2 = lstSideStoneType[1].Count;
                        for (int i = 0; i < c1; i++)
                        {
                            for (int j = 0; j < c2; j++)
                            {
                                //add item in the list
                                //add side stone type 1
                                lstProductSideStoneType[0].Add(new ProductImageSideStoneTypeModel()
                                {
                                    SideStoneTypeId = lstSideStoneType[0][i].AutoID,
                                    SideStoneType = lstSideStoneType[0][i].Name
                                });
                                //add ston type 2
                                lstProductSideStoneType[1].Add(new ProductImageSideStoneTypeModel()
                                {
                                    SideStoneTypeId = lstSideStoneType[1][j].AutoID,
                                    SideStoneType = lstSideStoneType[1][j].Name
                                });
                            }
                        }
                    }
                    break;
                case 3:
                    {
                        int count_1 = lstSideStoneType[0].Count;
                        int count_2 = lstSideStoneType[1].Count;
                        int count_3 = lstSideStoneType[2].Count;
                        for (int i = 0; i < count_1; i++)
                        {
                            for (int j = 0; j < count_2; j++)
                            {
                                for (int k = 0; k < count_3; k++)
                                {
                                    //add item in the list
                                    //add side stone type 1
                                    lstProductSideStoneType[0].Add(new ProductImageSideStoneTypeModel()
                                    {
                                        SideStoneTypeId = lstSideStoneType[0][i].AutoID,
                                        SideStoneType = lstSideStoneType[0][i].Name
                                    });
                                    //add ston type 2
                                    lstProductSideStoneType[1].Add(new ProductImageSideStoneTypeModel()
                                    {
                                        SideStoneTypeId = lstSideStoneType[1][j].AutoID,
                                        SideStoneType = lstSideStoneType[1][j].Name
                                    });
                                    //add ston type 3
                                    lstProductSideStoneType[1].Add(new ProductImageSideStoneTypeModel()
                                    {
                                        SideStoneTypeId = lstSideStoneType[2][k].AutoID,
                                        SideStoneType = lstSideStoneType[2][k].Name
                                    });
                                }
                            }
                        }
                    }
                    break;
            }
            return lstProductSideStoneType;
        }

        public List<ProductSideStoneAvialableStoneTypeModel> GetProductStoneTypeListFromSideStone(long sidestoneId, SideStoneActionModel.PageName pagename)
        {
            return objProductImageDAL.GetProductStoneTypeListFromSideStone(sidestoneId, pagename);
        }
    }
}
