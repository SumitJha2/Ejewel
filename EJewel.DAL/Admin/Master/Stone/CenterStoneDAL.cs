using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Product;

namespace EJewel.DAL.Admin.Master.Stone
{
    public class CenterStoneDAL
    {
        EJewelEntities objEntity = new EJewelEntities();

        public CenterStoneModel SaveUpdateCenterStone(CenterStoneModel model, CenterStoneModel.CenterStoneProvider provider)
        {
            try
            {
                switch (provider)
                {
                    case CenterStoneModel.CenterStoneProvider.FascinatingDiamonds:
                        {
                            #region For FD
                            //for fd
                            if (model.StoneId == 0)
                            {
                                #region For Save
                                ej_CenterStone centerStone = new ej_CenterStone()
                                {
                                    CenterStoneId = model.StoneId,
                                    CertificateCertificationLabId = model.CertificateCertificationLabId,
                                    CertificateCrown = model.CertificateCrown,
                                    CertificateCrownAngle = model.CertificateCrownAngle,
                                    CertificateCuletId = model.CertificateCuletId,
                                    CertificateDepth = model.CertificateDepth,
                                    CertificateFlouresenceId = model.CertificateFlouresenceId,
                                    CertificateGridleId = model.CertificateGridleId,
                                    CertificateMeasurement = model.CertificateMeasurement,
                                    CertificatePavillion = model.CertificatePavillion,
                                    CertificatePavillionAngle = model.CertificatePavillionAngle,
                                    CertificatePolishId = model.CertificatePolishId,
                                    CertificateSymmetryId = model.CertificateSymmetryId,
                                    CertificateTable = model.CertificateTable,
                                    Certification = model.Certification,
                                    CertificationFile = model.CertificationFile,

                                    SKU = model.SKU,
                                    Status = model.Status,
                                    StoneCarate = model.StoneCarate,
                                    StoneClarityId = model.StoneClarityId,
                                    StoneColorId = model.StoneColorId,
                                    StoneCutId = model.StoneCutId,
                                    StonePrice = model.StonePrice,
                                    StoneShapeId = model.StoneShapeId,
                                    StoneTypeId = model.StoneTypeId,
                                    // added by sumit on 31-05-2013
                                    Discount = Math.Round(model.Discount, 2),
                                    DiscountType = model.DiscountType
                                };
                                objEntity.AddToej_CenterStone(centerStone);
                                objEntity.SaveChanges();
                                model.StoneId = centerStone.CenterStoneId;
                                #endregion
                            }
                            else
                            {
                                #region For Update
                                //for update
                                ej_CenterStone centerStone = objEntity.ej_CenterStone.Where(tbl => tbl.CenterStoneId == model.StoneId).FirstOrDefault();
                                if (centerStone != null)
                                {
                                    centerStone.CertificateCertificationLabId = model.CertificateCertificationLabId;
                                    centerStone.CertificateCrown = model.CertificateCrown;
                                    centerStone.CertificateCrownAngle = model.CertificateCrownAngle;
                                    centerStone.CertificateCuletId = model.CertificateCuletId;
                                    centerStone.CertificateDepth = model.CertificateDepth;
                                    centerStone.CertificateFlouresenceId = model.CertificateFlouresenceId;
                                    centerStone.CertificateGridleId = model.CertificateGridleId;
                                    centerStone.CertificateMeasurement = model.CertificateMeasurement;
                                    centerStone.CertificatePavillion = model.CertificatePavillion;
                                    centerStone.CertificatePavillionAngle = model.CertificatePavillionAngle;
                                    centerStone.CertificatePolishId = model.CertificatePolishId;
                                    centerStone.CertificateSymmetryId = model.CertificateSymmetryId;
                                    centerStone.CertificateTable = model.CertificateTable;
                                    centerStone.Certification = model.Certification;
                                    centerStone.Discount = Math.Round(model.Discount, 2);
                                    centerStone.DiscountType = model.DiscountType;
                                    //for file
                                    if (model.CertificationFile.Length > 0)
                                    {
                                        centerStone.CertificationFile = model.CertificationFile;
                                    }
                                    //check that sku is present or not
                                    if (!this.ExistSKU(model.SKU, CenterStoneModel.CenterStoneProvider.FascinatingDiamonds))
                                    {
                                        centerStone.SKU = model.SKU;
                                    }

                                    centerStone.Status = model.Status;
                                    centerStone.StoneCarate = model.StoneCarate;
                                    centerStone.StoneClarityId = model.StoneClarityId;
                                    centerStone.StoneColorId = model.StoneColorId;
                                    centerStone.StoneCutId = model.StoneCutId;
                                    centerStone.StonePrice = model.StonePrice;
                                    centerStone.StoneShapeId = model.StoneShapeId;
                                    centerStone.StoneTypeId = model.StoneTypeId;
                                    objEntity.SaveChanges();
                                }
                                #endregion
                            }
                            #endregion

                        }
                        break;
                    case CenterStoneModel.CenterStoneProvider.Rapnet:
                        {
                            #region For Rapnet
                            //for rapnet
                            ej_CenterStoneRapnet centerStone = new ej_CenterStoneRapnet()
                            {
                                RapnetStoneId = model.StoneId,
                                CertificateCertificationLabId = model.CertificateCertificationLabId,
                                CertificateCrown = model.CertificateCrown,
                                CertificateCrownAngle = model.CertificateCrownAngle,
                                CertificateCuletId = model.CertificateCuletId,
                                CertificateDepth = model.CertificateDepth,
                                CertificateFlouresenceId = model.CertificateFlouresenceId,
                                CertificateGridleId = model.CertificateGridleId,
                                CertificateMeasurement = model.CertificateMeasurement,
                                CertificatePavillion = model.CertificatePavillion,
                                CertificatePavillionAngle = model.CertificatePavillionAngle,
                                CertificatePolishId = model.CertificatePolishId,
                                CertificateSymmetryId = model.CertificateSymmetryId,
                                CertificateTable = model.CertificateTable,
                                Certification = model.Certification,
                                CertificationFile = model.CertificationFile,
                                SKU = model.SKU,
                                Status = model.Status,
                                StoneCarate = model.StoneCarate,
                                StoneClarityId = model.StoneClarityId,
                                StoneColorId = model.StoneColorId,
                                StoneCutId = model.StoneCutId,
                                StonePrice = model.StonePrice,
                                StoneShapeId = model.StoneShapeId,
                                StoneTypeId = model.StoneTypeId

                            };
                            objEntity.AddToej_CenterStoneRapnet(centerStone);
                            objEntity.SaveChanges();
                            model.StoneId = centerStone.RapnetStoneId;
                            #endregion
                        }
                        break;

                    case CenterStoneModel.CenterStoneProvider.Supplier:
                        {
                            //future
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

        public bool ExistSKU(string sku, CenterStoneModel.CenterStoneProvider provider)
        {
            bool result = false;
            try
            {
                switch (provider)
                {
                    case CenterStoneModel.CenterStoneProvider.FascinatingDiamonds:
                        {
                            result = objEntity.ej_CenterStone.Where(tbl => tbl.SKU == sku).Any();
                        }
                        break;
                    case CenterStoneModel.CenterStoneProvider.Rapnet:
                        {
                            result = objEntity.ej_CenterStoneRapnet.Where(tbl => tbl.SKU == sku).Any();
                        }
                        break;
                    case CenterStoneModel.CenterStoneProvider.Supplier:
                        {
                            //future
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
            return result;
        }

        public List<CenterStoneModel> GetCenterStoneList(long stoneId, CenterStoneModel.CenterStoneProvider provider, CommonModel.RecordStatus rStatus)
        {
            List<CenterStoneModel> lstCenterStoneModel = null;
            try
            {
                switch (provider)
                {
                    case CenterStoneModel.CenterStoneProvider.FascinatingDiamonds:
                        {
                            #region For FD
                            List<ej_CenterStone> lstCenterStone = null;
                            if (stoneId > 0)
                            {
                                lstCenterStone = objEntity.ej_CenterStone.Where(tbl => tbl.CenterStoneId == stoneId).ToList();
                            }
                            else
                            {
                                lstCenterStone = objEntity.ej_CenterStone.Select(tbl => tbl).ToList();
                            }
                            //for status
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstCenterStone = lstCenterStone.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstCenterStone != null)
                            {
                                lstCenterStoneModel = (from centerStone in lstCenterStone
                                                       join stoneClarity in objEntity.ej_StoneClarity on centerStone.StoneClarityId equals stoneClarity.StoneClarityId
                                                       join stoneShape in objEntity.ej_StoneShape on centerStone.StoneShapeId equals stoneShape.StoneShapeId
                                                       join stone in objEntity.ej_StoneShapeMaster on stoneShape.ShapeId equals stone.ShapeId
                                                       join stoneCut in objEntity.ej_StoneCut on centerStone.StoneCutId equals stoneCut.StoneCutId
                                                       join stoneColor in objEntity.ej_StoneColor on centerStone.StoneColorId equals stoneColor.StoneColorId
                                                       //Certificate
                                                       //Gridle
                                                       join certGridle in objEntity.ej_CertificateGridle on centerStone.CertificateGridleId equals certGridle.CertificateGridleId
                                                       //Symmetry
                                                       join certSymmetry in objEntity.ej_CertificateSymmetry on centerStone.CertificateSymmetryId equals certSymmetry.CertificateSymmetryId
                                                       //Polish
                                                       join certPolish in objEntity.ej_CertificatePolish on centerStone.CertificatePolishId equals certPolish.CertificatePolishId
                                                       //Culet
                                                       join certCulet in objEntity.ej_CertificateCulet on centerStone.CertificateCuletId equals certCulet.CertificateCuletId
                                                       //Flouresence
                                                       join certFlouresence in objEntity.ej_CertificateFlouresence on centerStone.CertificateFlouresenceId equals certFlouresence.CertificateFlouresenceId
                                                       //CertificateCertificationLabId
                                                       join certLab in objEntity.ej_CertificationLab on centerStone.CertificateCertificationLabId equals certLab.CertificateLabId

                                                       where stoneClarity.Status == true && stoneShape.Status == true && stone.Status == true
                                                       && stoneCut.Status == true && stoneColor.Status == true && certGridle.Status == true
                                                       && certSymmetry.Status == true && certPolish.Status == true && certCulet.Status == true
                                                       && certFlouresence.Status == true && certLab.Status == true
                                                       select new CenterStoneModel()
                                                       {
                                                           StoneId = centerStone.CenterStoneId,
                                                           SKU = centerStone.SKU,
                                                           Status = centerStone.Status,
                                                           StoneCarate = centerStone.StoneCarate,
                                                           StoneClarity = stoneClarity.StoneClarityName,
                                                           StoneClarityId = stoneClarity.StoneClarityId,
                                                           StoneColor = stoneColor.StoneColorName,
                                                           StoneColorId = stoneColor.StoneColorId,
                                                           StoneCut = stoneCut.StoneCutName,
                                                           StoneCutId = stoneCut.StoneCutId,
                                                           StonePrice = centerStone.StonePrice,
                                                           StoneShape = stone.Shape,
                                                           StoneShapeId = stoneShape.StoneShapeId,
                                                           //certificate
                                                           //lab
                                                           CertificateCertificationLab = certLab.CertificateLabName,
                                                           CertificateCertificationLabId = certLab.CertificateLabId,
                                                           //
                                                           CertificateCrown = centerStone.CertificateCrown,
                                                           CertificateCrownAngle = centerStone.CertificateCrownAngle,
                                                           //culet
                                                           CertificateCulet = certCulet.CertificateCuletName,
                                                           CertificateCuletId = certCulet.CertificateCuletId,

                                                           CertificateDepth = centerStone.CertificateDepth,
                                                           //flouresense
                                                           CertificateFlouresence = certFlouresence.CertificateFlouresenceName,
                                                           CertificateFlouresenceId = certFlouresence.CertificateFlouresenceId,
                                                           //gridle
                                                           CertificateGridle = certGridle.CertificateGridleName,
                                                           CertificateGridleId = certGridle.CertificateGridleId,
                                                           //
                                                           CertificateMeasurement = centerStone.CertificateMeasurement,
                                                           CertificatePavillion = centerStone.CertificatePavillion,
                                                           CertificatePavillionAngle = centerStone.CertificatePavillionAngle,
                                                           //polish
                                                           CertificatePolish = certPolish.CertificatePolishName,
                                                           CertificatePolishId = certPolish.CertificatePolishId,
                                                           //symmetry
                                                           CertificateSymmetry = certSymmetry.CertificateSymmetryName,
                                                           CertificateSymmetryId = certSymmetry.CertificateSymmetryId,
                                                           //
                                                           CertificateTable = centerStone.CertificateTable,
                                                           Certification = centerStone.Certification,
                                                           CertificationFile = centerStone.CertificationFile,
                                                           DiscountType = centerStone.DiscountType,
                                                           Discount = (float)centerStone.Discount

                                                       }).ToList();
                            }
                            #endregion
                        }
                        break;
                    case CenterStoneModel.CenterStoneProvider.Rapnet:
                        {
                            #region For Rapnet
                            List<ej_CenterStoneRapnet> lstCenterStone = null;
                            if (stoneId > 0)
                            {
                                lstCenterStone = objEntity.ej_CenterStoneRapnet.Where(tbl => tbl.RapnetStoneId == stoneId).ToList();
                            }
                            else
                            {
                                lstCenterStone = objEntity.ej_CenterStoneRapnet.Select(tbl => tbl).ToList();
                            }
                            //for status
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstCenterStone = lstCenterStone.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstCenterStone != null)
                            {
                                lstCenterStoneModel = (from centerStone in lstCenterStone
                                                       join stoneType in objEntity.ej_StoneType on centerStone.StoneTypeId equals stoneType.StoneTypeId into group_Stone_Type
                                                       from g_stone_Type in group_Stone_Type.DefaultIfEmpty()

                                                       join stoneClarity in objEntity.ej_StoneClarity on centerStone.StoneClarityId equals stoneClarity.StoneClarityId
                                                       join stoneShape in objEntity.ej_StoneShape on centerStone.StoneShapeId equals stoneShape.StoneShapeId
                                                       join stone in objEntity.ej_StoneShapeMaster on stoneShape.ShapeId equals stone.ShapeId
                                                       join stoneCut in objEntity.ej_StoneCut on centerStone.StoneCutId equals stoneCut.StoneCutId
                                                       join stoneColor in objEntity.ej_StoneColor on centerStone.StoneColorId equals stoneColor.StoneColorId
                                                       //Certificate
                                                       //Gridle
                                                       join certGridle in objEntity.ej_CertificateGridle on centerStone.CertificateGridleId equals certGridle.CertificateGridleId
                                                       //Symmetry
                                                       join certSymmetry in objEntity.ej_CertificateSymmetry on centerStone.CertificateSymmetryId equals certSymmetry.CertificateSymmetryId
                                                       //Polish
                                                       join certPolish in objEntity.ej_CertificatePolish on centerStone.CertificatePolishId equals certPolish.CertificatePolishId
                                                       //Culet
                                                       join certCulet in objEntity.ej_CertificateCulet on centerStone.CertificateCuletId equals certCulet.CertificateCuletId
                                                       //Flouresence
                                                       join certFlouresence in objEntity.ej_CertificateFlouresence on centerStone.CertificateFlouresenceId equals certFlouresence.CertificateFlouresenceId
                                                       //CertificateCertificationLabId
                                                       join certLab in objEntity.ej_CertificationLab on centerStone.CertificateCertificationLabId equals certLab.CertificateLabId
                                                       //
                                                       where
                                                           // g_stone_Type.Status==true &&
                                                       stoneClarity.Status == true && stoneShape.Status == true
                                                       && stone.Status == true && stoneCut.Status == true && stoneColor.Status == true
                                                       && certGridle.Status == true && certSymmetry.Status == true && certPolish.Status == true
                                                       && certCulet.Status == true && certFlouresence.Status == true && certLab.Status == true

                                                       select new CenterStoneModel()
                                                       {
                                                           SKU = centerStone.SKU,
                                                           StoneId = centerStone.RapnetStoneId,
                                                           Status = centerStone.Status,
                                                           StoneCarate = centerStone.StoneCarate,
                                                           StoneClarity = stoneClarity.StoneClarityName,
                                                           StoneClarityId = stoneClarity.StoneClarityId,
                                                           StoneColor = stoneColor.StoneColorName,
                                                           StoneColorId = stoneColor.StoneColorId,
                                                           StoneCut = stoneCut.StoneCutName,
                                                           StoneCutId = stoneCut.StoneCutId,
                                                           StonePrice = centerStone.StonePrice,
                                                           StoneShape = stone.Shape,
                                                           StoneShapeId = stoneShape.StoneShapeId,
                                                           //StoneType = g_stone_Type.StoneTypeName,
                                                           //StoneTypeId = g_stone_Type.StoneTypeId,
                                                           //certificate
                                                           //lab
                                                           CertificateCertificationLab = certLab.CertificateLabName,
                                                           CertificateCertificationLabId = certLab.CertificateLabId,
                                                           //
                                                           CertificateCrown = centerStone.CertificateCrown,
                                                           CertificateCrownAngle = centerStone.CertificateCrownAngle,
                                                           //culet
                                                           CertificateCulet = certCulet.CertificateCuletName,
                                                           CertificateCuletId = certCulet.CertificateCuletId,

                                                           CertificateDepth = centerStone.CertificateDepth,
                                                           //flouresense
                                                           CertificateFlouresence = certFlouresence.CertificateFlouresenceName,
                                                           CertificateFlouresenceId = certFlouresence.CertificateFlouresenceId,
                                                           //gridle
                                                           CertificateGridle = certGridle.CertificateGridleName,
                                                           CertificateGridleId = certGridle.CertificateGridleId,
                                                           //
                                                           CertificateMeasurement = centerStone.CertificateMeasurement,
                                                           CertificatePavillion = centerStone.CertificatePavillion,
                                                           CertificatePavillionAngle = centerStone.CertificatePavillionAngle,
                                                           //polish
                                                           CertificatePolish = certPolish.CertificatePolishName,
                                                           CertificatePolishId = certPolish.CertificatePolishId,
                                                           //symmetry
                                                           CertificateSymmetry = certSymmetry.CertificateSymmetryName,
                                                           CertificateSymmetryId = certSymmetry.CertificateSymmetryId,
                                                           //
                                                           CertificateTable = centerStone.CertificateTable,
                                                           Certification = centerStone.Certification,
                                                           CertificationFile = centerStone.CertificationFile,
                                                           DiscountType = 0,
                                                           Discount = 0

                                                       }).ToList();
                            }
                            #endregion
                        }
                        break;
                    case CenterStoneModel.CenterStoneProvider.Supplier:
                        {
                            //future
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
            return lstCenterStoneModel;
        }

        private List<CenterStoneModel> GetCenterStoneList(List<ej_CenterStone> lstCenterStone)
        {
            List<CenterStoneModel> lstCenterStoneModel = new List<CenterStoneModel>();
            try
            {
                lstCenterStoneModel = (from centerStone in lstCenterStoneModel
                                       join stone_Category in objEntity.ej_StoneCategory
                                       on centerStone.StoneId equals stone_Category.StoneCategoryId
                                       join stoneClarity in objEntity.ej_StoneClarity on centerStone.StoneClarityId equals stoneClarity.StoneClarityId
                                       join stoneShape in objEntity.ej_StoneShape on centerStone.StoneShapeId equals stoneShape.StoneShapeId
                                       join stone in objEntity.ej_StoneShapeMaster on stoneShape.ShapeId equals stone.ShapeId
                                       join stoneCut in objEntity.ej_StoneCut on centerStone.StoneCutId equals stoneCut.StoneCutId
                                       join stoneColor in objEntity.ej_StoneColor on centerStone.StoneColorId equals stoneColor.StoneColorId
                                       join stoneType in objEntity.ej_StoneType on centerStone.StoneTypeId equals stoneType.StoneTypeId into group_Stone_Type
                                       from g_stone_Type in group_Stone_Type.DefaultIfEmpty()
                                       where stone_Category.Status == true && stoneClarity.Status == true && stoneShape.Status == true
                                       && stone.Status == true && stoneCut.Status == true && stoneColor.Status == true 
                                       select new CenterStoneModel()
                                       {
                                           StoneId = centerStone.StoneId,
                                           Status = centerStone.Status,
                                           StoneCarate = centerStone.StoneCarate,
                                           StoneClarity = stoneClarity.StoneClarityName,
                                           StoneClarityId = stoneClarity.StoneClarityId,
                                           StoneColor = stoneColor.StoneColorName,
                                           StoneColorId = stoneColor.StoneColorId,
                                           StoneCut = stoneCut.StoneCutName,
                                           StoneCutId = stoneCut.StoneCutId,
                                           StonePrice = centerStone.StonePrice,
                                           StoneShape = stone.Shape,
                                           StoneShapeId = stoneShape.StoneShapeId,
                                           StoneType = g_stone_Type == null ? "" : g_stone_Type.StoneTypeName,
                                           StoneTypeId = centerStone.StoneTypeId,
                                           Discount = centerStone.Discount,
                                           DiscountType = centerStone.DiscountType
                                       }).ToList();
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
            return lstCenterStoneModel.OrderByDescending(tbl => tbl.StoneId).ToList();
        }
        //soumya 10/04/2013
        public CenterstoneMinMaxRangeModel GetCenterStoneMinMaxRange()
        {
            CenterstoneMinMaxRangeModel model = new CenterstoneMinMaxRangeModel();
            try
            {

                #region Price
                //for FD
                double min1 = objEntity.ej_CenterStone.Min(tbl => tbl.StonePrice);
                double max1 = objEntity.ej_CenterStone.Max(tbl => tbl.StonePrice);
                //from Rapnet
                double min2 = objEntity.ej_CenterStoneRapnet.Min(tbl => tbl.StonePrice);
                double max2 = objEntity.ej_CenterStoneRapnet.Max(tbl => tbl.StonePrice);
                //add
                model.MinPrice = Math.Min(min1, min2);
                model.MaxPrice = Math.Max(max1, max2);
                #endregion

                #region Carat
                min1 = objEntity.ej_CenterStone.Min(tbl => tbl.StoneCarate);
                max1 = objEntity.ej_CenterStone.Max(tbl => tbl.StoneCarate);
                //from Rapnet
                min2 = objEntity.ej_CenterStoneRapnet.Min(tbl => tbl.StoneCarate);
                max2 = objEntity.ej_CenterStoneRapnet.Max(tbl => tbl.StoneCarate);
                //
                model.MinCarat = Math.Min(min1, min2);
                model.MaxCarat = Math.Max(max1, max2);
                #endregion

                #region Table
                min1 = objEntity.ej_CenterStone.Min(tbl => tbl.CertificateTable);
                max1 = objEntity.ej_CenterStone.Max(tbl => tbl.CertificateTable);
                //from Rapnet
                min2 = objEntity.ej_CenterStoneRapnet.Min(tbl => tbl.CertificateTable);
                max2 = objEntity.ej_CenterStoneRapnet.Max(tbl => tbl.CertificateTable);
                //
                model.MinTable = Math.Min(min1, min2);
                model.MaxTable = Math.Max(max1, max2);
                #endregion

                #region Depath
                min1 = objEntity.ej_CenterStone.Min(tbl => tbl.CertificateDepth);
                max1 = objEntity.ej_CenterStone.Max(tbl => tbl.CertificateDepth);
                //from Rapnet
                min2 = objEntity.ej_CenterStoneRapnet.Min(tbl => tbl.CertificateDepth);
                max2 = objEntity.ej_CenterStoneRapnet.Max(tbl => tbl.CertificateDepth);
                //
                model.MinDepth = Math.Min(min1, min2);
                model.MaxDepth = Math.Max(max1, max2);
                #endregion
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
        //Partha @ 10-04-13
        public CenterStoneModel GetCenterStoneFromSKU(string SKU, CenterStoneModel.CenterStoneProvider provider, CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<CenterStoneModel> lstCenterStoneModel = null;
                switch (provider)
                {
                    case CenterStoneModel.CenterStoneProvider.FascinatingDiamonds:
                        {
                            #region For FD
                            List<ej_CenterStone> lstCenterStone = null;
                            lstCenterStone = objEntity.ej_CenterStone.Where(tbl => tbl.SKU == SKU).ToList();
                            //for status
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstCenterStone = lstCenterStone.Where(tbl => tbl.Status == true).ToList();
                            }
                            lstCenterStoneModel = this.GetCenterStoneListFromFascinatingDiamonds(lstCenterStone);
                            #endregion
                        }
                        break;
                    case CenterStoneModel.CenterStoneProvider.Rapnet:
                        {
                            #region For Rapnet
                            List<ej_CenterStoneRapnet> lstCenterStone = null;
                            lstCenterStone = objEntity.ej_CenterStoneRapnet.Where(tbl => tbl.SKU == SKU).ToList();
                            //for status
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstCenterStone = lstCenterStone.Where(tbl => tbl.Status == true).ToList();
                            }
                            lstCenterStoneModel = this.GetCenterStoneListFromRapnet(lstCenterStone);
                            #endregion
                        }
                        break;
                }
                if (lstCenterStoneModel != null)
                {
                    return lstCenterStoneModel.FirstOrDefault();
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
        //Partha @ 10-04-13
        public CenterStoneModel.CenterStoneProvider GetDiamondProviderFromSKU(string SKU)
        {
            try
            {
                //first from the FD its OUR
                if (objEntity.ej_CenterStone.Where(tbl => tbl.SKU == SKU).Any())
                {
                    return CenterStoneModel.CenterStoneProvider.FascinatingDiamonds;
                }
                else if (objEntity.ej_CenterStoneRapnet.Where(tbl => tbl.SKU == SKU).Any())
                {
                    return CenterStoneModel.CenterStoneProvider.Rapnet;
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
            return CenterStoneModel.CenterStoneProvider.None;
        }
        //Partha @ 10-04-13
        private List<CenterStoneModel> GetCenterStoneListFromFascinatingDiamonds(List<ej_CenterStone> lstCenterStone)
        {
            List<CenterStoneModel> lstCenterStoneModel = null;
            try
            {
                if (lstCenterStone != null)
                {
                    lstCenterStoneModel = (from centerStone in lstCenterStone
                                           join stoneClarity in objEntity.ej_StoneClarity on centerStone.StoneClarityId equals stoneClarity.StoneClarityId
                                           join stoneShape in objEntity.ej_StoneShape on centerStone.StoneShapeId equals stoneShape.StoneShapeId
                                           join shape in objEntity.ej_StoneShapeMaster on stoneShape.ShapeId equals shape.ShapeId
                                           join stoneCut in objEntity.ej_StoneCut on centerStone.StoneCutId equals stoneCut.StoneCutId
                                           join stoneColor in objEntity.ej_StoneColor on centerStone.StoneColorId equals stoneColor.StoneColorId
                                           //Certificate
                                           //Gridle
                                           join certGridle in objEntity.ej_CertificateGridle on centerStone.CertificateGridleId equals certGridle.CertificateGridleId
                                           //Symmetry
                                           join certSymmetry in objEntity.ej_CertificateSymmetry on centerStone.CertificateSymmetryId equals certSymmetry.CertificateSymmetryId
                                           //Polish
                                           join certPolish in objEntity.ej_CertificatePolish on centerStone.CertificatePolishId equals certPolish.CertificatePolishId
                                           //Culet
                                           join certCulet in objEntity.ej_CertificateCulet on centerStone.CertificateCuletId equals certCulet.CertificateCuletId
                                           //Flouresence
                                           join certFlouresence in objEntity.ej_CertificateFlouresence on centerStone.CertificateFlouresenceId equals certFlouresence.CertificateFlouresenceId
                                           //CertificateCertificationLabId
                                           join certLab in objEntity.ej_CertificationLab on centerStone.CertificateCertificationLabId equals certLab.CertificateLabId
                                           //
                                           where stoneClarity.Status == true && stoneShape.Status == true && shape.Status == true
                                           && stoneCut.Status == true && stoneColor.Status == true && certGridle.Status == true
                                           && certSymmetry.Status == true && certPolish.Status == true && certCulet.Status == true
                                           && certFlouresence.Status == true && certLab.Status == true

                                           select new CenterStoneModel()
                                           {
                                               StoneId = centerStone.CenterStoneId,
                                               SKU = centerStone.SKU,
                                               Status = centerStone.Status,
                                               StoneCarate = centerStone.StoneCarate,
                                               StoneClarity = stoneClarity.StoneClarityName,
                                               StoneClarityId = stoneClarity.StoneClarityId,
                                               StoneColor = stoneColor.StoneColorName,
                                               StoneColorId = stoneColor.StoneColorId,
                                               StoneCut = stoneCut.StoneCutName,
                                               StoneCutId = stoneCut.StoneCutId,
                                               StonePrice = centerStone.StonePrice,
                                               StoneShape = shape.Shape,
                                               StoneShapeId = stoneShape.StoneShapeId,
                                               //certificate
                                               //lab
                                               CertificateCertificationLab = certLab.CertificateLabName,
                                               CertificateCertificationLabId = certLab.CertificateLabId,
                                               //
                                               CertificateCrown = centerStone.CertificateCrown,
                                               CertificateCrownAngle = centerStone.CertificateCrownAngle,
                                               //culet
                                               CertificateCulet = certCulet.CertificateCuletName,
                                               CertificateCuletId = certCulet.CertificateCuletId,

                                               CertificateDepth = centerStone.CertificateDepth,
                                               //flouresense
                                               CertificateFlouresence = certFlouresence.CertificateFlouresenceName,
                                               CertificateFlouresenceId = certFlouresence.CertificateFlouresenceId,
                                               //gridle
                                               CertificateGridle = certGridle.CertificateGridleName,
                                               CertificateGridleId = certGridle.CertificateGridleId,
                                               //
                                               CertificateMeasurement = centerStone.CertificateMeasurement,
                                               CertificatePavillion = centerStone.CertificatePavillion,
                                               CertificatePavillionAngle = centerStone.CertificatePavillionAngle,
                                               //polish
                                               CertificatePolish = certPolish.CertificatePolishName,
                                               CertificatePolishId = certPolish.CertificatePolishId,
                                               //symmetry
                                               CertificateSymmetry = certSymmetry.CertificateSymmetryName,
                                               CertificateSymmetryId = certSymmetry.CertificateSymmetryId,
                                               //
                                               CertificateTable = centerStone.CertificateTable,
                                               Certification = centerStone.Certification,
                                               CertificationFile = centerStone.CertificationFile,
                                               DiscountType = centerStone.DiscountType,
                                               Discount = centerStone.Discount,
                                               Provider = 1 //for fd

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
            return lstCenterStoneModel;
        }
        //Partha @ 10-04-13
        private List<CenterStoneModel> GetCenterStoneListFromRapnet(List<ej_CenterStoneRapnet> lstCenterStone)
        {
            List<CenterStoneModel> lstCenterStoneModel = null;
            try
            {
                if (lstCenterStone != null)
                {
                    lstCenterStoneModel = (from centerStone in lstCenterStone
                                           join stoneClarity in objEntity.ej_StoneClarity on centerStone.StoneClarityId equals stoneClarity.StoneClarityId
                                           join stoneShape in objEntity.ej_StoneShape on centerStone.StoneShapeId equals stoneShape.StoneShapeId
                                           join shape in objEntity.ej_StoneShapeMaster on stoneShape.ShapeId equals shape.ShapeId
                                           join stoneCut in objEntity.ej_StoneCut on centerStone.StoneCutId equals stoneCut.StoneCutId
                                           join stoneColor in objEntity.ej_StoneColor on centerStone.StoneColorId equals stoneColor.StoneColorId
                                           //Certificate
                                           //Gridle
                                           join certGridle in objEntity.ej_CertificateGridle on centerStone.CertificateGridleId equals certGridle.CertificateGridleId
                                           //Symmetry
                                           join certSymmetry in objEntity.ej_CertificateSymmetry on centerStone.CertificateSymmetryId equals certSymmetry.CertificateSymmetryId
                                           //Polish
                                           join certPolish in objEntity.ej_CertificatePolish on centerStone.CertificatePolishId equals certPolish.CertificatePolishId
                                           //Culet
                                           join certCulet in objEntity.ej_CertificateCulet on centerStone.CertificateCuletId equals certCulet.CertificateCuletId
                                           //Flouresence
                                           join certFlouresence in objEntity.ej_CertificateFlouresence on centerStone.CertificateFlouresenceId equals certFlouresence.CertificateFlouresenceId
                                           //CertificateCertificationLabId
                                           join certLab in objEntity.ej_CertificationLab on centerStone.CertificateCertificationLabId equals certLab.CertificateLabId
                                           //
                                           where stoneClarity.Status == true && stoneShape.Status == true && shape.Status == true
                                           && stoneCut.Status == true && stoneColor.Status == true && certGridle.Status == true
                                           && certSymmetry.Status == true && certPolish.Status == true && certCulet.Status == true
                                           && certFlouresence.Status == true && certLab.Status == true
                                           select new CenterStoneModel()
                                           {
                                               StoneId = centerStone.RapnetStoneId,
                                               SKU = centerStone.SKU,
                                               Status = centerStone.Status,
                                               StoneCarate = centerStone.StoneCarate,
                                               StoneClarity = stoneClarity.StoneClarityName,
                                               StoneClarityId = stoneClarity.StoneClarityId,
                                               StoneColor = stoneColor.StoneColorName,
                                               StoneColorId = stoneColor.StoneColorId,
                                               StoneCut = stoneCut.StoneCutName,
                                               StoneCutId = stoneCut.StoneCutId,
                                               StonePrice = centerStone.StonePrice,
                                               StoneShape = shape.Shape,
                                               StoneShapeId = stoneShape.StoneShapeId,
                                               //certificate
                                               //lab
                                               CertificateCertificationLab = certLab.CertificateLabName,
                                               CertificateCertificationLabId = certLab.CertificateLabId,
                                               //
                                               CertificateCrown = centerStone.CertificateCrown,
                                               CertificateCrownAngle = centerStone.CertificateCrownAngle,
                                               //culet
                                               CertificateCulet = certCulet.CertificateCuletName,
                                               CertificateCuletId = certCulet.CertificateCuletId,

                                               CertificateDepth = centerStone.CertificateDepth,
                                               //flouresense
                                               CertificateFlouresence = certFlouresence.CertificateFlouresenceName,
                                               CertificateFlouresenceId = certFlouresence.CertificateFlouresenceId,
                                               //gridle
                                               CertificateGridle = certGridle.CertificateGridleName,
                                               CertificateGridleId = certGridle.CertificateGridleId,
                                               //
                                               CertificateMeasurement = centerStone.CertificateMeasurement,
                                               CertificatePavillion = centerStone.CertificatePavillion,
                                               CertificatePavillionAngle = centerStone.CertificatePavillionAngle,
                                               //polish
                                               CertificatePolish = certPolish.CertificatePolishName,
                                               CertificatePolishId = certPolish.CertificatePolishId,
                                               //symmetry
                                               CertificateSymmetry = certSymmetry.CertificateSymmetryName,
                                               CertificateSymmetryId = certSymmetry.CertificateSymmetryId,
                                               //
                                               CertificateTable = centerStone.CertificateTable,
                                               Certification = centerStone.Certification,
                                               CertificationFile = centerStone.CertificationFile,
                                               DiscountType = 0,
                                               Discount = 0,
                                               Provider=2// from rapnet
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
            return lstCenterStoneModel;
        }
        //partha @ 29-04-13
        public List<CenterStoneModel> GetCenterStoneListFromShapeAndRange(int shape_id, double minCarat, double maxCarat, CenterStoneModel.CenterStoneProvider provider)
        {
            List<CenterStoneModel> lstModel = null;
            try
            {
                switch (provider)
                {
                    case CenterStoneModel.CenterStoneProvider.FascinatingDiamonds:
                        {
                            List<ej_CenterStone> lstCenterStone = objEntity.ej_CenterStone.Where(tbl => tbl.StoneShapeId == shape_id && (tbl.StoneCarate >= minCarat && tbl.StoneCarate <= maxCarat)).ToList();
                            lstModel = this.GetCenterStoneListFromFascinatingDiamonds(lstCenterStone);

                        } break;
                    case CenterStoneModel.CenterStoneProvider.Rapnet:
                        {
                            List<ej_CenterStoneRapnet> lstCenterStone = objEntity.ej_CenterStoneRapnet.Where(tbl => tbl.StoneShapeId == shape_id && (tbl.StoneCarate >= minCarat && tbl.StoneCarate <= maxCarat)).ToList();
                            lstModel = this.GetCenterStoneListFromRapnet(lstCenterStone);
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
        //partha @ 04-05-13
        public int TotalCenterStone(CenterStoneModel.CenterStoneProvider provider)
        {
            try
            {
                switch (provider)
                {
                    case CenterStoneModel.CenterStoneProvider.FascinatingDiamonds:
                        {
                            return objEntity.ej_CenterStone.Select(tbl => tbl).Count();
                        }
                    case CenterStoneModel.CenterStoneProvider.Rapnet:
                        {
                            return objEntity.ej_CenterStoneRapnet.Select(tbl => tbl).Count();
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
            return 0;
        }

        public void TuncateCenterStone(CenterStoneModel.CenterStoneProvider provider)
        {
            try
            {
                switch (provider)
                {
                    case CenterStoneModel.CenterStoneProvider.FascinatingDiamonds:
                        {
                            objEntity.ExecuteStoreCommand("delete * from ej_CenterStone");

                        } break;
                    case CenterStoneModel.CenterStoneProvider.Rapnet:
                        {
                            objEntity.ExecuteStoreCommand("truncate table from ej_CenterStoneRapnet");
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
        }

        public List<string> GetSKUSuggestion(string name, CenterStoneModel.CenterStoneProvider provider)
        {
            List<string> lstSKU = new List<string>();
            try
            {
                switch (provider)
                {
                    case CenterStoneModel.CenterStoneProvider.FascinatingDiamonds:
                        {
                            List<ej_CenterStone> lstCenterstone = objEntity.ej_CenterStone.Where(tbl => tbl.SKU.Contains(name)).ToList();
                            if (lstCenterstone != null)
                            {
                                lstSKU = (from cs in lstCenterstone
                                          select cs.SKU).ToList();
                            }

                        } break;
                    case CenterStoneModel.CenterStoneProvider.Rapnet:
                        {
                            List<ej_CenterStoneRapnet> lstCenterstone = objEntity.ej_CenterStoneRapnet.Where(tbl => tbl.SKU.Contains(name)).ToList();
                            if (lstCenterstone != null)
                            {
                                lstSKU = (from cs in lstCenterstone
                                          select cs.SKU).ToList();
                            }
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
            return lstSKU;
        }
        //added by sumit on 31-05-2013
        //get  stone isdd from sku
        public long GetCenterStoneIDFromSKU(string sku)
        {
            List<long> lstId = new List<long>();
            long Id = 0;
            try
            {
                if (sku != null)
                {
                    List<ej_CenterStone> objStone = objEntity.ej_CenterStone.Where(tbl => tbl.SKU == sku).ToList();
                    lstId = (from obj in objStone
                             select obj.CenterStoneId).ToList();
                    Id = lstId.FirstOrDefault();
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
            return Id;
        }

    }
}
