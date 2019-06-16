using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//mode
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Master.Stone;
//dal
using EJewel.DAL.Admin.Master.Stone;
namespace EJewel.DAL.Admin.Product
{
    /// <summary>
    /// Manage the Product Side Stone 
    /// Author: Partha Ranjan
    /// @ 21-02-13
    /// </summary>

    public class ProductSideStoneDAL
    {
        EJewelEntities objEntity = new EJewelEntities();

        public ProductSideStoneRangeModel SaveUpdateProductSideStoneRange(ProductSideStoneRangeModel model, SideStoneActionModel.PageName pageName)
        {
            try
            {
                switch (pageName)
                {
                    case SideStoneActionModel.PageName.SideStone:
                        {
                            #region For Side Stone
                            //check that the any data record present
                            if (!objEntity.ej_ProductSideStoneRange.Where(tbl => tbl.ProductId == model.ProductId && tbl.StoneCategoryId == model.StoneCategoryId).Any())
                            {
                                //for save
                                ej_ProductSideStoneRange stoneRage = new ej_ProductSideStoneRange()
                                {
                                    ProductSideStoneRangeId = model.ProductSideStoneRangeId,
                                    ProductId = model.ProductId,
                                    StoneCategoryId = model.StoneCategoryId,
                                    StoneMaxCarat = model.StoneMaxCarat,
                                    StoneMinCarat = model.StoneMinCarat,
                                };
                                objEntity.AddToej_ProductSideStoneRange(stoneRage);
                                objEntity.SaveChanges();
                                model.ProductSideStoneRangeId = stoneRage.ProductSideStoneRangeId;
                            }
                            else
                            {
                                //for update
                                ej_ProductSideStoneRange stone = objEntity.ej_ProductSideStoneRange.Where(tbl => tbl.ProductId == model.ProductId && tbl.StoneCategoryId == model.StoneCategoryId).FirstOrDefault();
                                if (stone != null)
                                {
                                    stone.StoneMaxCarat = model.StoneMaxCarat;
                                    stone.StoneMinCarat = model.StoneMinCarat;
                                    objEntity.SaveChanges();
                                }
                                model.ProductSideStoneRangeId = stone.ProductSideStoneRangeId;
                            }
                            #endregion
                        }
                        break;
                    case SideStoneActionModel.PageName.MatchingBand:
                        {
                            #region For Matching Band
                            //check that the any data record present
                            if (!objEntity.ej_ProductMatchingBandRange.Where(tbl => tbl.ProductId == model.ProductId && tbl.StoneCategoryId == model.StoneCategoryId).Any())
                            {
                                //for save
                                ej_ProductMatchingBandRange stoneRage = new ej_ProductMatchingBandRange()
                                {
                                    ProductMatchingBandRangeId = model.ProductSideStoneRangeId,
                                    ProductId = model.ProductId,
                                    StoneCategoryId = model.StoneCategoryId,
                                    StoneMaxCarat = model.StoneMaxCarat,
                                    StoneMinCarat = model.StoneMinCarat
                                };
                                objEntity.AddToej_ProductMatchingBandRange(stoneRage);
                                objEntity.SaveChanges();
                                model.ProductSideStoneRangeId = stoneRage.ProductMatchingBandRangeId;
                            }
                            else
                            {
                                //for update
                                ej_ProductMatchingBandRange stone = objEntity.ej_ProductMatchingBandRange.Where(tbl => tbl.ProductId == model.ProductId && tbl.StoneCategoryId == model.StoneCategoryId).FirstOrDefault();
                                if (stone != null)
                                {
                                    stone.StoneMaxCarat = model.StoneMaxCarat;
                                    stone.StoneMinCarat = model.StoneMinCarat;
                                    objEntity.SaveChanges();
                                }
                                model.ProductSideStoneRangeId = stone.ProductMatchingBandRangeId;
                            }
                            #endregion
                        }
                        break;
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

        public ProductSideStoneShapeModel SaveUpdateProductSideStoneShape(ProductSideStoneShapeModel model, SideStoneActionModel.PageName pageName)
        {
            try
            {
                switch (pageName)
                {
                    case SideStoneActionModel.PageName.SideStone:
                        {
                            #region For Side Stone
                            //check that the any data record present
                            if (!objEntity.ej_ProductSideStoneShape.Where(tbl => tbl.ProductSideStoneRangeId == model.ProductSideStoneRangeId && tbl.StoneShapeId == model.StoneShapeId).Any())
                            {
                                if (model.Status)
                                {
                                    //for save
                                    ej_ProductSideStoneShape stoneShape = new ej_ProductSideStoneShape()
                                    {
                                        ProductSideStoneRangeId = model.ProductSideStoneRangeId,
                                        ProductSideStoneShapeId = model.ProductSideStoneShapeId,
                                        Status = model.Status,
                                        StoneShapeId = model.StoneShapeId

                                    };
                                    objEntity.AddToej_ProductSideStoneShape(stoneShape);
                                    objEntity.SaveChanges();
                                }
                            }
                            else
                            {
                                //for update
                                ej_ProductSideStoneShape stone = objEntity.ej_ProductSideStoneShape.Where(tbl => tbl.ProductSideStoneRangeId == model.ProductSideStoneRangeId && tbl.StoneShapeId == model.StoneShapeId).FirstOrDefault();
                                if (stone != null)
                                {
                                    stone.Status = model.Status;
                                    stone.StoneShapeId = model.StoneShapeId;
                                    objEntity.SaveChanges();
                                }
                            }
                            #endregion
                        }
                        break;
                    case SideStoneActionModel.PageName.MatchingBand:
                        {
                            #region For matching band
                            //check that the any data record present
                            if (!objEntity.ej_ProductMatchingBandShape.Where(tbl => tbl.ProductMatchingBandRangeId == model.ProductSideStoneRangeId && tbl.StoneShapeId == model.StoneShapeId).Any())
                            {
                                if (model.Status)
                                {
                                    //for save
                                    ej_ProductMatchingBandShape stoneShape = new ej_ProductMatchingBandShape()
                                    {
                                        ProductMatchingBandRangeId = model.ProductSideStoneRangeId,
                                        ProductMatchingBandShapeId = model.ProductSideStoneShapeId,
                                        Status = model.Status,
                                        StoneShapeId = model.StoneShapeId

                                    };
                                    objEntity.AddToej_ProductMatchingBandShape(stoneShape);
                                    objEntity.SaveChanges();
                                }
                            }
                            else
                            {
                                //for update
                                ej_ProductMatchingBandShape stone = objEntity.ej_ProductMatchingBandShape.Where(tbl => tbl.ProductMatchingBandRangeId == model.ProductSideStoneRangeId && tbl.StoneShapeId == model.StoneShapeId).FirstOrDefault();
                                if (stone != null)
                                {
                                    stone.Status = model.Status;
                                    stone.StoneShapeId = model.StoneShapeId;
                                    objEntity.SaveChanges();
                                }
                            }
                            #endregion
                        }
                        break;
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

        public ProductSideStoneModel SaveUpdateProductSideStone(ProductSideStoneModel model, SideStoneActionModel.PageName pageName)
        {
            try
            {
            switch (pageName)
            {
                case SideStoneActionModel.PageName.SideStone:
                    {
                        #region For Side Stone
                        //check that the any data record present
                        if (!objEntity.ej_ProductSideStone.Where(tbl => tbl.ProductId == model.ProductId && tbl.StoneCategoryId == model.StoneCategoryId && tbl.StoneId == model.StoneId).Any())
                        {
                            //for save
                            if (model.Status)
                            {
                                ej_ProductSideStone stone = new ej_ProductSideStone()
                                {
                                    ProductSideStoneId = model.ProductSideStoneId,
                                    ProductId = model.ProductId,
                                    Status = model.Status,
                                    StoneCategoryId = model.StoneCategoryId,
                                    StoneId = model.StoneId,
                                    NoOfStone = model.NoOfStone,
                                    StoneCategorySettingTypeId = model.StoneCategorySettingTypeId,
                                    DesignTypeId=model.DesignTypeId,
                                    IsCustomize = model.IsCustomize
                                };
                                objEntity.AddToej_ProductSideStone(stone);
                                objEntity.SaveChanges();
                                model.ProductSideStoneId = stone.ProductSideStoneId;
                            }
                        }
                        else
                        {
                            //for update
                            ej_ProductSideStone stone = objEntity.ej_ProductSideStone.Where(tbl => tbl.ProductId == model.ProductId && tbl.StoneCategoryId == model.StoneCategoryId && tbl.StoneId == model.StoneId).FirstOrDefault();
                            if (stone != null)
                            {
                                stone.Status = model.Status;
                                stone.NoOfStone = model.NoOfStone;
                                stone.StoneCategorySettingTypeId = model.StoneCategorySettingTypeId;
                                stone.IsCustomize = model.IsCustomize;
                                stone.DesignTypeId = model.DesignTypeId;
                                objEntity.SaveChanges();
                                model.ProductSideStoneId = stone.ProductSideStoneId;
                            }
                        }
                        #endregion
                    }
                    break;
                case SideStoneActionModel.PageName.MatchingBand:
                    {
                        #region Matching Band
                        //check that the any data record present
                        if (!objEntity.ej_ProductMatchingBand.Where(tbl => tbl.ProductId == model.ProductId && tbl.StoneCategoryId == model.StoneCategoryId && tbl.StoneId == model.StoneId).Any())
                        {
                            //for save
                            if (model.Status)
                            {
                                ej_ProductMatchingBand stone = new ej_ProductMatchingBand()
                                {
                                    ProductMatchingBandId = model.ProductSideStoneId,
                                    ProductId = model.ProductId,
                                    Status = model.Status,
                                    StoneCategoryId = model.StoneCategoryId,
                                    StoneId = model.StoneId,
                                    NoOfStone = model.NoOfStone,
                                    StoneCategorySettingTypeId = model.StoneCategorySettingTypeId,
                                    DesignTypeId = model.DesignTypeId,
                                    IsCustomize = model.IsCustomize
                                };
                                objEntity.AddToej_ProductMatchingBand(stone);
                                objEntity.SaveChanges();
                                model.ProductSideStoneId = stone.ProductMatchingBandId;
                            }
                        }
                        else
                        {
                            //for update
                            ej_ProductMatchingBand stone = objEntity.ej_ProductMatchingBand.Where(tbl => tbl.ProductId == model.ProductId && tbl.StoneCategoryId == model.StoneCategoryId && tbl.StoneId == model.StoneId).FirstOrDefault();
                            if (stone != null)
                            {
                                stone.Status = model.Status;
                                stone.NoOfStone = model.NoOfStone;
                                stone.StoneCategorySettingTypeId = model.StoneCategorySettingTypeId;
                                stone.IsCustomize = model.IsCustomize;
                                stone.DesignTypeId = model.DesignTypeId;
                                objEntity.SaveChanges();
                                model.ProductSideStoneId = stone.ProductMatchingBandId;
                            }
                        }
                        #endregion
                    }
                    break;
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

        public ProductSideStoneAvialableStoneTypeModel SaveUpdateProductSideStoneAvialableStoneType(ProductSideStoneAvialableStoneTypeModel model, SideStoneActionModel.PageName pageName)
        {
            try
            {
                switch (pageName)
                {
                    case SideStoneActionModel.PageName.SideStone:
                        {
                            #region For Side Stone
                            //check that the this data is present ot not
                            if (!objEntity.ej_ProductSideStoneAvialableStoneType.Where(tbl => tbl.ProductSideStoneId == model.ProductSideStoneId && tbl.StoneId == model.StoneId).Any())
                            {
                                //check that the status of the record
                                if (model.Status)
                                {
                                    ej_ProductSideStoneAvialableStoneType sideStoneAvialableType = new ej_ProductSideStoneAvialableStoneType()
                                    {
                                        ProductSideStoneAvialableId = model.ProductSideStoneAvialableId,
                                        ProductSideStoneId = model.ProductSideStoneId,
                                        Status = model.Status,
                                        StoneId = model.StoneId
                                    };
                                    if (sideStoneAvialableType != null)
                                    {
                                        objEntity.AddToej_ProductSideStoneAvialableStoneType(sideStoneAvialableType);
                                        objEntity.SaveChanges();
                                        model.ProductSideStoneAvialableId = sideStoneAvialableType.ProductSideStoneAvialableId;
                                    }
                                }
                            }
                            else
                            {
                                //for update
                                ej_ProductSideStoneAvialableStoneType sideStoneAvialableType = objEntity.ej_ProductSideStoneAvialableStoneType.Where(tbl => tbl.ProductSideStoneId == model.ProductSideStoneId && tbl.StoneId == model.StoneId).FirstOrDefault();
                                if (sideStoneAvialableType != null)
                                {
                                    sideStoneAvialableType.Status = model.Status;
                                    objEntity.SaveChanges();
                                }
                            }
                            #endregion
                        }
                        break;
                    case SideStoneActionModel.PageName.MatchingBand:
                        {
                            #region For Matching Band
                            //check that the this data is present ot not
                            if (!objEntity.ej_ProductMatchingBandAvialableStoneType.Where(tbl => tbl.ProductMatchingBandId == model.ProductSideStoneId && tbl.StoneId == model.StoneId).Any())
                            {
                                //check that the status of the record
                                if (model.Status)
                                {
                                    ej_ProductMatchingBandAvialableStoneType sideStoneAvialableType = new ej_ProductMatchingBandAvialableStoneType()
                                    {
                                        ProductMatchingBandSideStoneAvialableId = model.ProductSideStoneAvialableId,
                                        ProductMatchingBandId = model.ProductSideStoneId,
                                        Status = model.Status,
                                        StoneId = model.StoneId
                                    };
                                    if (sideStoneAvialableType != null)
                                    {
                                        objEntity.AddToej_ProductMatchingBandAvialableStoneType(sideStoneAvialableType);
                                        objEntity.SaveChanges();
                                        model.ProductSideStoneAvialableId = sideStoneAvialableType.ProductMatchingBandSideStoneAvialableId;
                                    }
                                }
                            }
                            else
                            {
                                //for update
                                ej_ProductMatchingBandAvialableStoneType sideStoneAvialableType = objEntity.ej_ProductMatchingBandAvialableStoneType.Where(tbl => tbl.ProductMatchingBandId == model.ProductSideStoneId && tbl.StoneId == model.StoneId).FirstOrDefault();
                                if (sideStoneAvialableType != null)
                                {
                                    sideStoneAvialableType.Status = model.Status;
                                    objEntity.SaveChanges();
                                }
                            }
                            #endregion
                        }
                        break;
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

        public List<ProductSideStoneModel> ProductSideStoneList(long productID, int stoneCategoryID, SideStoneActionModel.PageName pageName, CommonModel.RecordStatus rStatus)
        {
            List<ProductSideStoneModel> lstModel = new List<ProductSideStoneModel>();
            try
            {
                switch (pageName)
                {
                    case SideStoneActionModel.PageName.SideStone:
                        {
                            List<ej_ProductSideStone> lstStone = null;
                            lstStone = objEntity.ej_ProductSideStone.Where(tbl => tbl.ProductId == productID && tbl.StoneCategoryId == stoneCategoryID).ToList();
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstStone = lstStone.Where(tbl => tbl.Status == true).ToList();
                            }
                            lstModel = this.ProductSideStoneList(lstStone);
                        }
                        break;
                    case SideStoneActionModel.PageName.MatchingBand:
                        {
                            List<ej_ProductMatchingBand> lstStone = null;
                            lstStone = lstStone = objEntity.ej_ProductMatchingBand.Where(tbl => tbl.ProductId == productID && tbl.StoneCategoryId == stoneCategoryID).ToList();
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstStone = lstStone.Where(tbl => tbl.Status == true).ToList();
                            }
                            lstModel = this.ProductSideStoneList(lstStone);
                        }
                        break;
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

            return lstModel;
        }

        private List<ProductSideStoneModel> ProductSideStoneList( List<ej_ProductSideStone> lstStone)
        {
            List<ProductSideStoneModel> lstModel = new List<ProductSideStoneModel>();
            try
            {
                if (lstStone != null)
                {
                    lstModel = (from sideStone in lstStone
                                select new ProductSideStoneModel()
                                {
                                    ProductId = sideStone.ProductId,
                                    ProductSideStoneId = sideStone.ProductSideStoneId,
                                    Status = sideStone.Status,
                                    StoneCategoryId = sideStone.StoneCategoryId,
                                    StoneId = sideStone.StoneId,
                                    NoOfStone = sideStone.NoOfStone,
                                    StoneCategorySettingTypeId = sideStone.StoneCategorySettingTypeId,
                                    IsCustomize = sideStone.IsCustomize,
                                    DesignTypeId = sideStone.DesignTypeId
                                }).ToList();
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
            return lstModel;
        }

        private List<ProductSideStoneModel> ProductSideStoneList(List<ej_ProductMatchingBand> lstStone)
        {
            List<ProductSideStoneModel> lstModel = new List<ProductSideStoneModel>();
            try
            {
                if (lstStone != null)
                {
                    lstModel = (from sideStone in lstStone
                                select new ProductSideStoneModel()
                                {
                                    ProductId = sideStone.ProductId,
                                    ProductSideStoneId = sideStone.ProductMatchingBandId,
                                    Status = sideStone.Status,
                                    StoneCategoryId = sideStone.StoneCategoryId,
                                    StoneId = sideStone.StoneId,
                                    NoOfStone = sideStone.NoOfStone,
                                    StoneCategorySettingTypeId = sideStone.StoneCategorySettingTypeId,
                                    IsCustomize = sideStone.IsCustomize,
                                    DesignTypeId = sideStone.DesignTypeId
                                }).ToList();
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
            return lstModel;
        }

        public ProductSideStoneRangeModel ProductSideStoneRange(long productID, int stoneCategoryID, SideStoneActionModel.PageName pageName)
        {
            try
            {
                switch (pageName)
                {
                    case SideStoneActionModel.PageName.SideStone:
                        {
                            ej_ProductSideStoneRange sideStoneRange = objEntity.ej_ProductSideStoneRange.Where(tbl => tbl.ProductId == productID && tbl.StoneCategoryId == stoneCategoryID).FirstOrDefault();
                            if (sideStoneRange != null)
                            {
                                return new ProductSideStoneRangeModel()
                                {
                                    ProductId = sideStoneRange.ProductId,
                                    ProductSideStoneRangeId = sideStoneRange.ProductSideStoneRangeId,
                                    StoneCategoryId = sideStoneRange.StoneCategoryId,
                                    StoneMaxCarat = sideStoneRange.StoneMaxCarat,
                                    StoneMinCarat = sideStoneRange.StoneMinCarat
                                };
                            }
                        }
                        break;
                    case SideStoneActionModel.PageName.MatchingBand:
                        {
                            ej_ProductMatchingBandRange sideStoneRange = objEntity.ej_ProductMatchingBandRange.Where(tbl => tbl.ProductId == productID && tbl.StoneCategoryId == stoneCategoryID).FirstOrDefault();
                            if (sideStoneRange != null)
                            {
                                return new ProductSideStoneRangeModel()
                                {
                                    ProductId = sideStoneRange.ProductId,
                                    ProductSideStoneRangeId = sideStoneRange.ProductMatchingBandRangeId,
                                    StoneCategoryId = sideStoneRange.StoneCategoryId,
                                    StoneMaxCarat = sideStoneRange.StoneMaxCarat,
                                    StoneMinCarat = sideStoneRange.StoneMinCarat
                                };
                            }
                        }
                        break;
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

        public List<int> StoneShapeList(long sideStoneRangeId, SideStoneActionModel.PageName pageName, CommonModel.RecordStatus rStatus)
        {
            List<int> lstStoneShape = new List<int>();
            try
            {
                switch (pageName)
                {
                    case SideStoneActionModel.PageName.SideStone:
                        {
                            List<ej_ProductSideStoneShape> lstSideStone = objEntity.ej_ProductSideStoneShape.Where(tbl => tbl.ProductSideStoneRangeId == sideStoneRangeId).ToList();
                            //
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstSideStone = lstSideStone.Where(tbl => tbl.Status == true).ToList();
                            }
                            //
                            lstStoneShape = (from sideStone in lstSideStone
                                             select sideStone.StoneShapeId).ToList();
                        }
                        break;
                    case SideStoneActionModel.PageName.MatchingBand:
                        {
                            List<ej_ProductMatchingBandShape> lstSideStone = objEntity.ej_ProductMatchingBandShape.Where(tbl => tbl.ProductMatchingBandRangeId == sideStoneRangeId).ToList();
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstSideStone = lstSideStone.Where(tbl => tbl.Status == true).ToList();
                            }
                            //
                            lstStoneShape = (from sideStone in lstSideStone
                                             select sideStone.StoneShapeId).ToList();
                        }
                        break;
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
            return lstStoneShape;
        }

        public List<long> StoneTypeSideStoneIdList(long productSideStoneId, SideStoneActionModel.PageName pageName)
        {
            List<long> lstSideStoneTypeSideStoneID = new List<long>();
            try
            {
                switch (pageName)
                {
                    case SideStoneActionModel.PageName.SideStone:
                        {
                            lstSideStoneTypeSideStoneID = (from sideStone in objEntity.ej_ProductSideStoneAvialableStoneType
                                                           where productSideStoneId == sideStone.ProductSideStoneId && sideStone.Status == true
                                                           select sideStone.StoneId).ToList();

                        }
                        break;
                    case SideStoneActionModel.PageName.MatchingBand:
                        {
                            lstSideStoneTypeSideStoneID = (from sideStone in objEntity.ej_ProductMatchingBandAvialableStoneType
                                                           where productSideStoneId == sideStone.ProductMatchingBandId && sideStone.Status == true
                                                           select sideStone.StoneId).ToList();
                        }
                        break;
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
            return lstSideStoneTypeSideStoneID;
        }
        /* sumit jha
      * @ available shape for side stone and matching band
      * 04-04-2013
      **/
        public List<StoneSpecificationModel> StoneShapeListForView(long sideStoneRangeId, SideStoneActionModel.PageName pageName)
        {
            List<StoneSpecificationModel> lstStoneShape = new List<StoneSpecificationModel>();
            try
            {
                switch (pageName)
                {
                    case SideStoneActionModel.PageName.SideStone:
                        {
                            List<ej_ProductSideStoneShape> lstSideStone = objEntity.ej_ProductSideStoneShape.Where(tbl => tbl.ProductSideStoneRangeId == sideStoneRangeId).ToList();
                            //
                            lstStoneShape = (from sideStone in lstSideStone
                                             join shape in objEntity.ej_StoneShape
                                             on sideStone.StoneShapeId equals shape.StoneShapeId
                                             where sideStone.Status == true && shape.Status == true
                                             select new StoneSpecificationModel
                                             {
                                                 AutoID = shape.StoneShapeId,
                                                 Name = ""
                                             }).ToList();
                        }
                        break;
                    case SideStoneActionModel.PageName.MatchingBand:
                        {
                            List<ej_ProductMatchingBandShape> lstSideStone = objEntity.ej_ProductMatchingBandShape.Where(tbl => tbl.ProductMatchingBandRangeId == sideStoneRangeId).ToList();
                            //
                            lstStoneShape = (from sideStone in lstSideStone
                                             join shape in objEntity.ej_StoneShape
                                             on sideStone.StoneShapeId equals shape.StoneShapeId
                                             where sideStone.Status == true && shape.Status == true

                                             select new StoneSpecificationModel
                                             {
                                                 AutoID = shape.StoneShapeId,
                                                 Name = ""
                                             }).ToList();
                        }
                        break;
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
            return lstStoneShape;


        }
        /* sumit jha
         * @ available  side stone and matching band
         * 04-04-2013
         **/
        public List<ProductSideStoneDetailModel> ProductSideStoneListForView(long productID, int stoneCategoryID, SideStoneActionModel.PageName pageName)
        {
            List<ProductSideStoneDetailModel> lstSideStoneDetailsModel = new List<ProductSideStoneDetailModel>();
            try
            {
                List<ProductSideStoneModel> lstProductSideStoteModel = this.ProductSideStoneList(productID, stoneCategoryID, pageName, CommonModel.RecordStatus.Enabled);


                if (lstProductSideStoteModel != null)
                {
                    lstSideStoneDetailsModel = (from lst in lstProductSideStoteModel
                                                join sidestone in objEntity.ej_SideStone
                                                on lst.StoneId equals sidestone.SideStoneId
                                                join categorysettingtype in objEntity.ej_StoneCategorySettingType
                                                on lst.StoneCategorySettingTypeId equals categorysettingtype.StoneCategorySettingTypeId
                                                join settingtype in objEntity.ej_SettingType on
                                                categorysettingtype.SettingTypeId equals settingtype.SettingTypeId
                                                join cut in objEntity.ej_StoneCut
                                                on sidestone.StoneCutId equals cut.StoneCutId
                                                join clarity in objEntity.ej_StoneClarity
                                                on sidestone.StoneClarityId equals clarity.StoneClarityId
                                                join stoneShape in objEntity.ej_StoneShape
                                                on sidestone.StoneShapeId equals stoneShape.StoneShapeId
                                                join stone in objEntity.ej_StoneShapeMaster on stoneShape.ShapeId equals stone.ShapeId
                                                join color in objEntity.ej_StoneColor
                                                on sidestone.StoneColorId equals color.StoneColorId
                                                where sidestone.Status == true && categorysettingtype.Status == true &&
                                                settingtype.Status == true && cut.Status == true && clarity.Status == true
                                                && stoneShape.Status == true && stone.Status == true && color.Status == true
                                                select new ProductSideStoneDetailModel
                                                {
                                                    ProductSideStoneId = lst.ProductSideStoneId,
                                                    ProductId = lst.ProductId,
                                                    StoneCategoryId = lst.StoneCategoryId,
                                                    NoOfStone = lst.NoOfStone,
                                                    StoneCategorySettingTypeId = lst.StoneCategorySettingTypeId,
                                                    StoneId = lst.StoneId,
                                                    cut = cut.StoneCutName,
                                                    color = color.StoneColorName,
                                                    clarity = clarity.StoneClarityName,
                                                    shape = stone.Shape,
                                                    settingType = settingtype.SettingTypeName,
                                                    Price = sidestone.StonePrice,
                                                    StoneCarate = sidestone.StoneCarate,
                                                    DesignTypeId = lst.DesignTypeId,
                                                    // added by sumit for customize
                                                    IsCustomize = lst.IsCustomize
                                                }).ToList();


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
            return lstSideStoneDetailsModel;
        }

        /* sumit jha
       * @ Type  side stone and matching band
       * 05-04-2013
       **/
        public List<StoneSpecificationModel> GetProductStoneType(long sidestoneId, SideStoneActionModel.PageName pagename)
        {
            List<StoneSpecificationModel> lstStoneSpecificationmodel = new List<StoneSpecificationModel>();
            try
            {
                switch (pagename)
                {
                    case SideStoneActionModel.PageName.SideStone:
                        {
                            lstStoneSpecificationmodel = (from sidestone in objEntity.ej_ProductSideStoneAvialableStoneType
                                                          join stone in objEntity.ej_SideStone
                                                          on sidestone.StoneId equals stone.SideStoneId
                                                          join stonetype in objEntity.ej_StoneType
                                                          on stone.StoneTypeId equals stonetype.StoneTypeId
                                                          where sidestone.ProductSideStoneId == sidestoneId
                                                          && stone.Status == true && stonetype.Status == true
                                                          select new StoneSpecificationModel
                                                          {
                                                              AutoID = stonetype.StoneTypeId,
                                                              Name = stonetype.StoneTypeName
                                                          }).ToList();
                        }
                        break;
                    case SideStoneActionModel.PageName.MatchingBand:
                        {
                            lstStoneSpecificationmodel = (from sidestone in objEntity.ej_ProductMatchingBandAvialableStoneType
                                                          join stone in objEntity.ej_SideStone
                                                          on sidestone.StoneId equals stone.SideStoneId
                                                          join stonetype in objEntity.ej_StoneType
                                                          on stone.StoneTypeId equals stonetype.StoneTypeId
                                                          where sidestone.ProductMatchingBandId == sidestoneId
                                                          && stone.Status == true && stonetype.Status == true && sidestone.Status == true
                                                          select new StoneSpecificationModel
                                                          {
                                                              AutoID = stonetype.StoneTypeId,
                                                              Name = stonetype.StoneTypeName
                                                          }).ToList();
                        }
                        break;
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
            return lstStoneSpecificationmodel;
        }

        public List<SideStoneModel> GetProductSideStoneAvailableType(long ProductSideStoneId, SideStoneActionModel.PageName pagename)
        {
            try
            {
                List<ej_SideStone> lstEntityObject = null;
                switch (pagename)
                {
                    case SideStoneActionModel.PageName.SideStone:
                        {
                            lstEntityObject = (from sidestone in objEntity.ej_ProductSideStoneAvialableStoneType
                                               join stone in objEntity.ej_SideStone
                                               on sidestone.StoneId equals stone.SideStoneId
                                               join stonetype in objEntity.ej_StoneType
                                               on stone.StoneTypeId equals stonetype.StoneTypeId
                                               where sidestone.ProductSideStoneId == ProductSideStoneId
                                               && stone.Status == true && stonetype.Status == true && sidestone.Status == true
                                               select stone).ToList();
                        }
                        break;
                    case SideStoneActionModel.PageName.MatchingBand:
                        {
                            lstEntityObject = (from sidestone in objEntity.ej_ProductMatchingBandAvialableStoneType
                                               join stone in objEntity.ej_SideStone
                                               on sidestone.StoneId equals stone.SideStoneId
                                               join stonetype in objEntity.ej_StoneType
                                               on stone.StoneTypeId equals stonetype.StoneTypeId
                                               where sidestone.ProductMatchingBandId == ProductSideStoneId
                                               && stone.Status == true && stonetype.Status == true && sidestone.Status == true
                                               select stone).ToList();
                        }
                        break;
                }
                return new SideStoneDAL().GetSideStoneList(lstEntityObject);
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
       * @ stoneType  in side stone and matching band
       * 12-04-2013
       **/
        public List<StoneSpecificationModel> GetStoneTypeByCaretAndShape(int StonecategoryId, int shapeId, double carat)
        {
            List<StoneSpecificationModel> lstStoneType = new List<StoneSpecificationModel>();
            try
            {
                List<ej_SideStone> objSidestone = objEntity.ej_SideStone.Where(tbl => tbl.StoneShapeId == shapeId && tbl.StoneCarate == carat && tbl.StoneCategoryId == StonecategoryId && tbl.Status == true).ToList();
                if (objSidestone != null)
                {
                    lstStoneType = (from sidestone in objSidestone
                                    join stonetype in objEntity.ej_StoneType
                                    on sidestone.StoneTypeId equals stonetype.StoneTypeId
                                    where stonetype.Status == true
                                    select new StoneSpecificationModel
                                    {
                                        AutoID = (int)sidestone.SideStoneId,
                                        //Here set StoneId for customization in front end...
                                        Name = stonetype.StoneTypeName

                                    }).ToList();

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
            return lstStoneType;

        }


        public List<ProductSideStoneAvialableStoneTypeModel> GetProductStoneTypeListFromSideStone(long productSideStoneId, SideStoneActionModel.PageName pagename)
        {
            List<ProductSideStoneAvialableStoneTypeModel> lstProductSideStoneAvialableStoneTypeModel = new List<ProductSideStoneAvialableStoneTypeModel>();
            try
            {
                switch (pagename)
                {
                    case SideStoneActionModel.PageName.SideStone:
                        {
                            lstProductSideStoneAvialableStoneTypeModel = (from sidestone in objEntity.ej_ProductSideStoneAvialableStoneType
                                                                          join stone in objEntity.ej_SideStone
                                                                          on sidestone.StoneId equals stone.SideStoneId
                                                                          join stonetype in objEntity.ej_StoneType
                                                                          on stone.StoneTypeId equals stonetype.StoneTypeId
                                                                          where sidestone.ProductSideStoneId == productSideStoneId
                                                                          && stone.Status == true && stonetype.Status == true && sidestone.Status == true
                                                                          select new ProductSideStoneAvialableStoneTypeModel
                                                                          {
                                                                              ProductSideStoneAvialableId = sidestone.ProductSideStoneAvialableId,
                                                                              ProductSideStoneId = sidestone.ProductSideStoneId,
                                                                              Status = sidestone.Status,
                                                                              StoneId = sidestone.StoneId,
                                                                              StoneType = stonetype.StoneTypeName,
                                                                              StoneTypeId = stonetype.StoneTypeId
                                                                          }).ToList();
                        }
                        break;
                    case SideStoneActionModel.PageName.MatchingBand:
                        {
                            lstProductSideStoneAvialableStoneTypeModel = (from sidestone in objEntity.ej_ProductMatchingBandAvialableStoneType
                                                                          join stone in objEntity.ej_SideStone
                                                                          on sidestone.StoneId equals stone.SideStoneId
                                                                          join stonetype in objEntity.ej_StoneType
                                                                          on stone.StoneTypeId equals stonetype.StoneTypeId
                                                                          where sidestone.ProductMatchingBandId == productSideStoneId
                                                                          && stone.Status == true && stonetype.Status == true && sidestone.Status == true
                                                                          select new ProductSideStoneAvialableStoneTypeModel
                                                                          {
                                                                              ProductSideStoneAvialableId = sidestone.ProductMatchingBandSideStoneAvialableId,
                                                                              ProductSideStoneId = sidestone.ProductMatchingBandId,
                                                                              Status = sidestone.Status,
                                                                              StoneId = sidestone.StoneId,
                                                                              StoneType = stonetype.StoneTypeName,
                                                                              StoneTypeId = stonetype.StoneTypeId

                                                                          }).ToList();
                        }
                        break;
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
            return lstProductSideStoneAvialableStoneTypeModel;
        }

        public ProductSideStoneModel GetProductSideStoneFromSideStoneType(long productId, long sideStoneId, SideStoneActionModel.PageName pagename)
        {
            ProductSideStoneModel productSideStoneModel = null;
            try
            {
                switch (pagename)
                {
                    case SideStoneActionModel.PageName.SideStone:
                        {
                            productSideStoneModel = (from availableType in objEntity.ej_ProductSideStoneAvialableStoneType
                                                     join productsideStone in objEntity.ej_ProductSideStone
                                                     on availableType.ProductSideStoneId equals productsideStone.ProductSideStoneId
                                                     where productsideStone.ProductId == productId && availableType.StoneId == sideStoneId
                                                     && availableType.Status == true && productsideStone.Status == true
                                                     select new ProductSideStoneModel()
                                                     {
                                                         DesignTypeId = productsideStone.DesignTypeId,
                                                         IsCustomize = productsideStone.IsCustomize,
                                                         NoOfStone = productsideStone.NoOfStone,
                                                         ProductId = productsideStone.ProductId,
                                                         ProductSideStoneId = productsideStone.ProductSideStoneId,
                                                         Status = productsideStone.Status,
                                                         StoneCategoryId = productsideStone.StoneCategoryId,
                                                         StoneCategorySettingTypeId = productsideStone.StoneCategorySettingTypeId,
                                                         StoneId = availableType.StoneId
                                                     }).FirstOrDefault();
                        }
                        break;
                    case SideStoneActionModel.PageName.MatchingBand:
                        {
                            productSideStoneModel = (from availableType in objEntity.ej_ProductMatchingBandAvialableStoneType
                                                     join productsideStone in objEntity.ej_ProductMatchingBand
                                                     on availableType.ProductMatchingBandId equals productsideStone.ProductMatchingBandId
                                                     where productsideStone.ProductId == productId && availableType.StoneId == sideStoneId
                                                     && availableType.Status == true && productsideStone.Status == true
                                                     select new ProductSideStoneModel()
                                                     {
                                                         DesignTypeId = productsideStone.DesignTypeId,
                                                         IsCustomize = productsideStone.IsCustomize,
                                                         NoOfStone = productsideStone.NoOfStone,
                                                         ProductId = productsideStone.ProductId,
                                                         ProductSideStoneId = productsideStone.ProductMatchingBandId,
                                                         Status = productsideStone.Status,
                                                         StoneCategoryId = productsideStone.StoneCategoryId,
                                                         StoneCategorySettingTypeId = productsideStone.StoneCategorySettingTypeId,
                                                         StoneId = availableType.StoneId
                                                     }).FirstOrDefault();
                        }
                        break;
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
            return productSideStoneModel;
        }

        //partha @ 14-05-13
        public SideStoneModel GetSameSideStoneForCustomize(List<ProductSideStoneModel> lstProductSideStoneDiamond, SideStoneModel sideStoneGemstoneModel)
        {
            try
            {
                List<ej_SideStone> lstmodel = (from productSideStone in lstProductSideStoneDiamond
                                               join sideStone in objEntity.ej_SideStone
                                               on productSideStone.StoneId equals sideStone.SideStoneId
                                               where sideStone.SideStoneId == sideStoneGemstoneModel.SideStoneId
                                               select sideStone).ToList();
                return new SideStoneDAL().GetSideStoneList(lstmodel).FirstOrDefault();
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
        //partha @ 14-05-13

        public List<SideStoneModel> GetSameSideStoneForCustomize(List<ProductSideStoneModel> lstProductSideStoneDiamond, List<ProductSideStoneModel> lstProductSideStoneGemstone)
        {
            try
            {
                //get the side stone diamond
                List<ej_SideStone> lstSideStoneDiamond = (from productSideStone in lstProductSideStoneDiamond
                                                          join sideStone in objEntity.ej_SideStone
                                                          on productSideStone.StoneId equals sideStone.SideStoneId
                                                          where sideStone.Status == true
                                                          select sideStone).ToList();
                //get the side stone gem stone
                List<ej_SideStone> lstSideStoneGemstone = (from productSideStone in lstProductSideStoneGemstone
                                                           join sideStone in objEntity.ej_SideStone
                                                           on productSideStone.StoneId equals sideStone.SideStoneId
                                                           where sideStone.Status == true
                                                           select sideStone).ToList();
                //now get the common values
                List<ej_SideStone> lstCombineModel = (from sideStoneDiamond in lstSideStoneDiamond
                                                      join sideStoneGemstone in lstSideStoneGemstone
                                                      on sideStoneDiamond.StoneShapeId equals sideStoneGemstone.StoneShapeId
                                                      select sideStoneDiamond).ToList();
                return new SideStoneDAL().GetSideStoneList(lstCombineModel);
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

        //partha @ 14-05-13
        public ProductSideStoneModel ProductSideStoneFromSideStone(long productId, long sideStoneId, SideStoneActionModel.PageName pageName)
        {

            ProductSideStoneModel lstModel = new ProductSideStoneModel();
            try
            {
                switch (pageName)
                {
                    case SideStoneActionModel.PageName.SideStone:
                        {
                            List<ej_ProductSideStone> lstEntityObject = objEntity.ej_ProductSideStone.Where(tbl => tbl.ProductId == productId && tbl.StoneId == sideStoneId).ToList();
                            lstModel = this.ProductSideStoneList(lstEntityObject).FirstOrDefault();
                        } break;
                    case SideStoneActionModel.PageName.MatchingBand:
                        {
                            List<ej_ProductMatchingBand> lstEntityObject = objEntity.ej_ProductMatchingBand.Where(tbl => tbl.ProductId == productId && tbl.StoneId == sideStoneId).ToList();
                            lstModel = this.ProductSideStoneList(lstEntityObject).FirstOrDefault();
                        } break;
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
            return lstModel;
        }

        //partha @ 16-05-13
        public ProductSideStoneModel GetProductSideStoneModelFromShape(long productId, ProductSideStoneModel productSideStoneGemstone, int stoneCategoryId, SideStoneActionModel.PageName pagename)
        {
            ProductSideStoneModel productSideStoneDiamond = null;
            try
            {
                if (productSideStoneGemstone != null)
                {
                    //get all
                    List<ProductSideStoneModel> lstProductSideStoneDiamond = this.ProductSideStoneList(productId, stoneCategoryId, pagename, CommonModel.RecordStatus.Enabled);
                    int total_product_side_stone = lstProductSideStoneDiamond.Count;

                    for (int i = 0; i < total_product_side_stone; i++)
                    {
                        SideStoneModel sideStoneModel = this.GetProductSideStoneDiamondSameAsGemStone(lstProductSideStoneDiamond[i], productSideStoneGemstone);
                        if (sideStoneModel != null)
                        {
                            productSideStoneDiamond = lstProductSideStoneDiamond[i];
                            break;
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
            return productSideStoneDiamond;
        }

        public SideStoneModel GetProductSideStoneDiamondSameAsGemStone(ProductSideStoneModel sideStoneDiamond, ProductSideStoneModel sideStoneGemstone)
        {
            SideStoneModel model = null;
            try
            {
                ej_SideStone sideStoneDiamondModel = objEntity.ej_SideStone.Where(tbl => tbl.SideStoneId == sideStoneDiamond.StoneId).FirstOrDefault();
                ej_SideStone sideStoneGemStoneModel = objEntity.ej_SideStone.Where(tbl => tbl.SideStoneId == sideStoneGemstone.StoneId).FirstOrDefault();
                if (sideStoneDiamondModel != null && sideStoneGemStoneModel != null)
                {
                    StoneShapeDAL ssDAL = new StoneShapeDAL();
                    int diamond_shape_id = ssDAL.StoneShapeList(sideStoneDiamondModel.StoneShapeId, StoneShapeModel.ShapeVisibility.SIDESTONE, CommonModel.RecordStatus.Enabled).FirstOrDefault().ShapeId;
                    int gemstone_shape_id = ssDAL.StoneShapeList(sideStoneGemStoneModel.StoneShapeId, StoneShapeModel.ShapeVisibility.SIDESTONE, CommonModel.RecordStatus.Enabled).FirstOrDefault().ShapeId;
                    //now get the orginal shape id
                    if (diamond_shape_id == gemstone_shape_id)
                    {
                        List<ej_SideStone> lstModel = new List<ej_SideStone>();
                        lstModel.Add(sideStoneDiamondModel);
                        model = new SideStoneDAL().GetSideStoneList(lstModel).FirstOrDefault();
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


        /* sumit jha
      * @ 03-06-2013 
      * for product view
      * *
      */
        public List<ProductSideStoneShapeModel> GetSideStoneAvailableShape(long sidestonerangeId, int stonecategoryid, SideStoneActionModel.PageName pageName)
        {

            List<ProductSideStoneShapeModel> objModel = new List<ProductSideStoneShapeModel>();
            try
            {
                if (pageName == SideStoneActionModel.PageName.SideStone)
                {
                    List<ej_ProductSideStoneShape> objShape = objEntity.ej_ProductSideStoneShape.Where(tbl => tbl.ProductSideStoneRangeId == sidestonerangeId).ToList();
                    if (objShape != null && objShape.Count > 0)
                    {
                        objModel = (from lst in objShape
                                    join stoneshape in objEntity.ej_StoneShape
                                    on lst.StoneShapeId equals stoneshape.StoneShapeId
                                    join shapemaster in objEntity.ej_StoneShapeMaster
                                    on stoneshape.ShapeId equals shapemaster.ShapeId
                                    where stoneshape.Status == true && shapemaster.Status == true
                                    select new ProductSideStoneShapeModel
                                    {
                                        StoneShapeId = stoneshape.StoneShapeId,
                                        ShapeName = shapemaster.Shape
                                    }).ToList();

                    }
                }
                else
                {
                    List<ej_ProductMatchingBandShape> objShape = objEntity.ej_ProductMatchingBandShape.Where(tbl => tbl.ProductMatchingBandRangeId == sidestonerangeId).ToList();
                    if (objShape != null && objShape.Count > 0)
                    {
                        objModel = (from lst in objShape
                                    join stoneshape in objEntity.ej_StoneShape
                                    on lst.StoneShapeId equals stoneshape.StoneShapeId
                                    join shapemaster in objEntity.ej_StoneShapeMaster
                                    on stoneshape.ShapeId equals shapemaster.ShapeId
                                    where stoneshape.Status == true && shapemaster.Status == true
                                    select new ProductSideStoneShapeModel
                                    {
                                        StoneShapeId = stoneshape.StoneShapeId,
                                        ShapeName = shapemaster.Shape
                                    }).ToList();

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
            return objModel;
        }
        // sumit jha
        //03-06-2103 

        public List<SideStoneModel> GetProductStoneAvailable_Type(long sidestoneId, SideStoneActionModel.PageName pagename)
        {
            List<SideStoneModel> lstStoneSpecificationmodel = new List<SideStoneModel>();
            try
            {
                switch (pagename)
                {
                    case SideStoneActionModel.PageName.SideStone:
                        {
                            lstStoneSpecificationmodel = (from sidestone in objEntity.ej_ProductSideStoneAvialableStoneType
                                                          join stone in objEntity.ej_SideStone
                                                          on sidestone.StoneId equals stone.SideStoneId
                                                          join stonetype in objEntity.ej_StoneType
                                                          on stone.StoneTypeId equals stonetype.StoneTypeId
                                                          join color in objEntity.ej_StoneColor
                                                          on stone.StoneColorId equals color.StoneColorId
                                                          where sidestone.ProductSideStoneId == sidestoneId
                                                          && stone.Status == true && stonetype.Status == true && sidestone.Status == true
                                                          && color.Status == true
                                                          select new SideStoneModel
                                                          {
                                                              StonePrice = stone.StonePrice,
                                                              StoneColor = color.StoneColorName,
                                                              StoneType = stonetype.StoneTypeName
                                                          }).ToList();
                        }
                        break;
                    case SideStoneActionModel.PageName.MatchingBand:
                        {
                            lstStoneSpecificationmodel = (from sidestone in objEntity.ej_ProductMatchingBandAvialableStoneType
                                                          join stone in objEntity.ej_SideStone
                                                          on sidestone.StoneId equals stone.SideStoneId
                                                          join stonetype in objEntity.ej_StoneType
                                                          on stone.StoneTypeId equals stonetype.StoneTypeId
                                                          join color in objEntity.ej_StoneColor
                                                          on stone.StoneColorId equals color.StoneColorId
                                                          where sidestone.ProductMatchingBandId == sidestoneId
                                                          && stone.Status == true && stonetype.Status == true && sidestone.Status == true
                                                          && color.Status == true
                                                          select new SideStoneModel
                                                          {
                                                              StonePrice = stone.StonePrice,
                                                              StoneColor = color.StoneColorName,
                                                              StoneType = stonetype.StoneTypeName
                                                          }).ToList();
                        }
                        break;
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
            return lstStoneSpecificationmodel;
        }

    }
}
