using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Common;
//dal
using EJewel.DAL.Admin.Master.Stone;
using EJewel.Model.Admin.Product;

namespace EJewel.Controller.Admin.Master.Stone
{
    /// <summary>
    /// Center Stone Controller
    /// Partha Ranjan Nayak
    /// @ 01-04-13
    /// </summary>
    public class CenterStoneController
    {
        CenterStoneDAL objDAL = new CenterStoneDAL();

        public CenterStoneModel SaveUpdateCenterStone(CenterStoneModel model, CenterStoneModel.CenterStoneProvider provider)
        {
            return objDAL.SaveUpdateCenterStone(model, provider);
        }

        public bool ExistSKU(string sku, CenterStoneModel.CenterStoneProvider provider)
        {
            return objDAL.ExistSKU(sku, provider);
        }

        public List<CenterStoneModel> GetCenterStoneList(long stoneId, CenterStoneModel.CenterStoneProvider provider, CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetCenterStoneList(stoneId, provider, rStatus);
        }

        public CenterstoneMinMaxRangeModel GetCenterStoneMinMaxRange()
        {
            return objDAL.GetCenterStoneMinMaxRange();
        }

        public List<CenterStoneModel> GetCenterStoneList(int pageIndex, int perPage, CenterStoneModel.CenterStoneProvider provider, CommonModel.RecordStatus rStatus)
        {
            List<CenterStoneModel> lstCenterStone = objDAL.GetCenterStoneList(0, provider, rStatus);
            return lstCenterStone.Skip(pageIndex * perPage).Take(perPage).ToList();
        }

        //soumya

        public List<CenterStoneModel> GetCenterStoneListDetails(long sideStoneId, CenterStoneModel.CenterStoneProvider provider, CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetCenterStoneList(sideStoneId, provider, rStatus).ToList();
        }

        public List<CenterStoneModel> GetAllCenterStoneList(int pageIndex, int perPage, CommonModel.RecordStatus rStatus)
        {
            List<CenterStoneModel> lstCenterStoneFD = objDAL.GetCenterStoneList(0, CenterStoneModel.CenterStoneProvider.FascinatingDiamonds, rStatus);
            List<CenterStoneModel> lstCenterStoneRapnet = objDAL.GetCenterStoneList(0, CenterStoneModel.CenterStoneProvider.Rapnet, rStatus);
            //now combine
            List<CenterStoneModel> lstCenterStone = new List<CenterStoneModel>();
            lstCenterStone.AddRange(lstCenterStoneFD);
            lstCenterStone.AddRange(lstCenterStoneRapnet);
            //retuen
            return lstCenterStone.Skip(pageIndex * perPage).Take(perPage).ToList();
        }

        public List<CenterStoneModel> FilterCenterStoneList(int ShapeID, float MinPriceRange, float MaxPriceRange, float MinCaratRange, float MaxCaratRange, int MinColorRange, int MaxColorRange, int MinCutRange, int MaxCutRange, int MinClarityRange, int MaxClarityRange)
        {
            List<CenterStoneModel> lstCenterStoneFD = objDAL.GetCenterStoneList(0, CenterStoneModel.CenterStoneProvider.FascinatingDiamonds, CommonModel.RecordStatus.Enabled);
            List<CenterStoneModel> lstCenterStoneRapnet = objDAL.GetCenterStoneList(0, CenterStoneModel.CenterStoneProvider.Rapnet, CommonModel.RecordStatus.Enabled);
            //now combine
            List<CenterStoneModel> lstCenterStone = new List<CenterStoneModel>();
            lstCenterStone.AddRange(lstCenterStoneFD);
            lstCenterStone.AddRange(lstCenterStoneRapnet);
            //
            if (lstCenterStone != null)
            {
                if (ShapeID > 0)
                {
                    lstCenterStone = lstCenterStone.Where(tbl => tbl.StoneShapeId == ShapeID).ToList();
                }
                lstCenterStone = lstCenterStone.Where(tbl => tbl.StonePrice >= MinPriceRange && tbl.StonePrice <= MaxPriceRange && tbl.StoneCarate >= MinCaratRange && tbl.StoneCarate <= MaxCaratRange && tbl.StoneColorId >= MinColorRange && tbl.StoneCutId >= MinCutRange && tbl.StoneCutId <= MaxCutRange && tbl.StoneClarityId >= MinClarityRange && tbl.StoneClarityId <= MaxClarityRange && tbl.StoneColorId <= MaxColorRange).ToList();
                int total_record = lstCenterStone.Count;
                lstCenterStone = lstCenterStone.Skip(0).Take(15).ToList();
                lstCenterStone = (from centerStone in lstCenterStone
                                  select new CenterStoneModel()
                                  {
                                      CertificateCertificationLab = centerStone.CertificateCertificationLab,
                                      CertificateCertificationLabId = centerStone.CertificateCertificationLabId,
                                      CertificateCrown = centerStone.CertificateCrown,
                                      CertificateCrownAngle = centerStone.CertificateCrownAngle,
                                      CertificateCulet = centerStone.CertificateCulet,
                                      CertificateCuletId = centerStone.CertificateCuletId,
                                      CertificateDepth = centerStone.CertificateDepth,
                                      CertificateFlouresence = centerStone.CertificateFlouresence,
                                      CertificateFlouresenceId = centerStone.CertificateFlouresenceId,
                                      CertificateGridle = centerStone.CertificateGridle,
                                      CertificateGridleId = centerStone.CertificateGridleId,
                                      CertificateMeasurement = centerStone.CertificateMeasurement,
                                      CertificatePavillion = centerStone.CertificatePavillion,
                                      CertificatePavillionAngle = centerStone.CertificatePavillionAngle,
                                      CertificatePolish = centerStone.CertificatePolish,
                                      CertificatePolishId = centerStone.CertificatePolishId,
                                      CertificateSymmetry = centerStone.CertificateSymmetry,
                                      CertificateSymmetryId = centerStone.CertificateSymmetryId,
                                      CertificateTable = centerStone.CertificateTable,
                                      Certification = centerStone.Certification,
                                      CertificationFile = centerStone.CertificationFile,
                                      SKU = centerStone.SKU,
                                      Status = centerStone.Status,
                                      StoneCarate = centerStone.StoneCarate,
                                      StoneClarity = centerStone.StoneClarity,
                                      StoneClarityId = centerStone.StoneClarityId,
                                      StoneColor = centerStone.StoneColor,
                                      StoneColorId = centerStone.StoneColorId,
                                      StoneCut = centerStone.StoneCut,
                                      StoneCutId = centerStone.StoneCutId,
                                      StoneId = centerStone.StoneId,
                                      StonePrice = centerStone.StonePrice,
                                      StoneShape = centerStone.StoneShape,
                                      StoneShapeId = centerStone.StoneShapeId,
                                      StoneType = centerStone.StoneType,
                                      StoneTypeId = centerStone.StoneTypeId,
                                      TotalRecord = total_record
                                  }).ToList();

                return lstCenterStone;
            }
            return lstCenterStone;
        }

        public List<CenterStoneModel> FilterCenterStoneList(string shapes, string cuts, string colors, string clarity, float MinPriceRange, float MaxPriceRange, float MinCaratRange, float MaxCaratRange,int currentPage,int perPage)
        {
            List<CenterStoneModel> lstCenterStoneFD = objDAL.GetCenterStoneList(0, CenterStoneModel.CenterStoneProvider.FascinatingDiamonds, CommonModel.RecordStatus.Enabled);
            List<CenterStoneModel> lstCenterStoneRapnet = objDAL.GetCenterStoneList(0, CenterStoneModel.CenterStoneProvider.Rapnet, CommonModel.RecordStatus.Enabled);
            //now combine
            List<CenterStoneModel> lstCenterStone = new List<CenterStoneModel>();
            lstCenterStone.AddRange(lstCenterStoneFD);
            lstCenterStone.AddRange(lstCenterStoneRapnet);
            //
            if (lstCenterStone != null)
            {
                //shape
                if (shapes.Length > 0)
                {
                    int[] split = this.StringToIntArray(shapes, ',');
                    //lstCenterStoneRapnet = lstCenterStoneRapnet.Where(tbl => split.Contains(tbl.StoneShapeId)).ToList();
                    lstCenterStoneRapnet = (from centerstone in lstCenterStoneRapnet
                                            where (split.Contains(centerstone.StoneShapeId))
                                            select centerstone).ToList();
                }
                //cut
                if(cuts.Length>0)
                {
                    int[] split = this.StringToIntArray(cuts, ',');
                    //lstCenterStoneRapnet = lstCenterStoneRapnet.Where(tbl => split.Contains(tbl.StoneCutId)).ToList();
                    lstCenterStoneRapnet = (from centerstone in lstCenterStoneRapnet
                                            where (split.Contains(centerstone.StoneCutId))
                                            select centerstone).ToList();
                }
                //color
                if(colors.Length>0)
                {
                    int[] split = this.StringToIntArray(colors, ',');
                    //lstCenterStoneRapnet = lstCenterStoneRapnet.Where(tbl => split.Contains(tbl.StoneColorId)).ToList();
                    lstCenterStoneRapnet = (from centerstone in lstCenterStoneRapnet
                                            where (split.Contains(centerstone.StoneColorId))
                                            select centerstone).ToList();
                }
                //clarity
                if (clarity.Length > 0)
                {
                    int[] split = this.StringToIntArray(clarity, ',');
                    //lstCenterStoneRapnet = lstCenterStoneRapnet.Where(tbl => split.Contains(tbl.StoneClarityId)).ToList();

                    lstCenterStoneRapnet = (from centerstone in lstCenterStoneRapnet
                                            where (split.Contains(centerstone.StoneClarityId))
                                            select centerstone).ToList();
                }
                //stone price and carat
                lstCenterStoneRapnet = lstCenterStoneRapnet.Where(tbl => tbl.StonePrice >= MinPriceRange && tbl.StonePrice <= MaxPriceRange && tbl.StoneCarate >= MinCaratRange && tbl.StoneCarate <= MaxCaratRange).ToList();
                int total_record = lstCenterStoneRapnet.Count;
                lstCenterStoneRapnet = lstCenterStoneRapnet.Skip(currentPage*perPage).Take(perPage).ToList();
                lstCenterStoneRapnet = (from centerStone in lstCenterStoneRapnet
                                  select new CenterStoneModel()
                                  {
                                      CertificateCertificationLab = centerStone.CertificateCertificationLab,
                                      CertificateCertificationLabId = centerStone.CertificateCertificationLabId,
                                      CertificateCrown = centerStone.CertificateCrown,
                                      CertificateCrownAngle = centerStone.CertificateCrownAngle,
                                      CertificateCulet = centerStone.CertificateCulet,
                                      CertificateCuletId = centerStone.CertificateCuletId,
                                      CertificateDepth = centerStone.CertificateDepth,
                                      CertificateFlouresence = centerStone.CertificateFlouresence,
                                      CertificateFlouresenceId = centerStone.CertificateFlouresenceId,
                                      CertificateGridle = centerStone.CertificateGridle,
                                      CertificateGridleId = centerStone.CertificateGridleId,
                                      CertificateMeasurement = centerStone.CertificateMeasurement,
                                      CertificatePavillion = centerStone.CertificatePavillion,
                                      CertificatePavillionAngle = centerStone.CertificatePavillionAngle,
                                      CertificatePolish = centerStone.CertificatePolish,
                                      CertificatePolishId = centerStone.CertificatePolishId,
                                      CertificateSymmetry = centerStone.CertificateSymmetry,
                                      CertificateSymmetryId = centerStone.CertificateSymmetryId,
                                      CertificateTable = centerStone.CertificateTable,
                                      Certification = centerStone.Certification,
                                      CertificationFile = centerStone.CertificationFile,
                                      SKU = centerStone.SKU,
                                      Status = centerStone.Status,
                                      StoneCarate = centerStone.StoneCarate,
                                      StoneClarity = centerStone.StoneClarity,
                                      StoneClarityId = centerStone.StoneClarityId,
                                      StoneColor = centerStone.StoneColor,
                                      StoneColorId = centerStone.StoneColorId,
                                      StoneCut = centerStone.StoneCut,
                                      StoneCutId = centerStone.StoneCutId,
                                      StoneId = centerStone.StoneId,
                                      StonePrice = centerStone.StonePrice,
                                      StoneShape = centerStone.StoneShape,
                                      StoneShapeId = centerStone.StoneShapeId,
                                      StoneType = centerStone.StoneType,
                                      StoneTypeId = centerStone.StoneTypeId,
                                      TotalRecord = total_record
                                  }).OrderBy(tbl=>tbl.StonePrice).ToList();

                return lstCenterStoneRapnet;
            }
            return lstCenterStoneRapnet;
        }

        public CenterStoneModel GetCenterStoneDetailsFromSKU(string SKU)
        {
            CenterStoneModel model = null;
            CenterStoneModel.CenterStoneProvider provider = objDAL.GetDiamondProviderFromSKU(SKU);
            switch (provider)
            {
                case CenterStoneModel.CenterStoneProvider.FascinatingDiamonds:
                    {
                        model = objDAL.GetCenterStoneFromSKU(SKU, CenterStoneModel.CenterStoneProvider.FascinatingDiamonds, CommonModel.RecordStatus.Enabled);
                    } break;
                case CenterStoneModel.CenterStoneProvider.Rapnet:
                    {
                        model = objDAL.GetCenterStoneFromSKU(SKU, CenterStoneModel.CenterStoneProvider.Rapnet, CommonModel.RecordStatus.Enabled);
                    }
                    break;
            }
            return model;
        }

        public List<CenterStoneModel> GetCenterStoneListFromShapeAndRange(int shape_id, double minCarat, double maxCarat, CenterStoneModel.CenterStoneProvider provider)
        {
            return objDAL.GetCenterStoneListFromShapeAndRange(shape_id, minCarat, maxCarat, provider);
        }

        public int TotalCenterStone(CenterStoneModel.CenterStoneProvider provider)
        {
            return objDAL.TotalCenterStone(provider);
        }

        public void TuncateCenterStone(CenterStoneModel.CenterStoneProvider provider)
        {
            objDAL.TuncateCenterStone(provider);
        }

        public List<string> GetSKUSuggestion(string name, CenterStoneModel.CenterStoneProvider provider)
        {
            return objDAL.GetSKUSuggestion(name, provider);
        }

        private int [] StringToIntArray(string input,char separator)
        {
            return Array.ConvertAll(input.Split(separator), s => int.Parse(s));
        }

        public long GetCenterStoneIDFromSKU(string sku)
        {
            return objDAL.GetCenterStoneIDFromSKU(sku);
        }

    }
}
