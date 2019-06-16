using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Common.Sfm;
//dal
using EJewel.DAL.Admin.Common.Sfm;

namespace EJewel.Controller.Admin.Common.Sfm
{
    /// <summary>
    /// 
    /// </summary>

    public class SfmController
    {
        SfmdDAL objDAL = new SfmdDAL();
        public string HeadingName = "";

        public SfmModel SaveUpdateSfm(SfmModel model, SfmModel.PageName pageName)
        {
            return objDAL.SaveUpdateSfm(model, pageName);
        }

        public List<SfmModel> GetSfmList(int id, CommonModel.RecordStatus status, SfmModel.PageName pageName)
        {
            return objDAL.GetSfmList(id, status, pageName);
        }

        public List<SfmModel> GetSfmList(int id, CommonModel.RecordStatus status, SfmModel.PageName pageName, int currentPageIndex, int perPageSize)
        {
            return GetSfmList(id, status, pageName);
        }

        public int GetTotalSfm(SfmModel.PageName pageName)
        {
            return objDAL.GetTotalSfm(pageName);
        }

        public bool IsExsit(string name, SfmModel.PageName pageName)
        {
            return objDAL.IsExist(name, pageName);
        }

        public SfmModel.PageName GetPageView(string viewName)
        {
            SfmModel.PageName pageName = SfmModel.PageName.None;
            switch (viewName)
            {
                case "metal_weight":
                    {
                        pageName = SfmModel.PageName.MetalWeightMaster;
                        HeadingName = "Metal Weight";
                    }break;
                case "metal_name":
                    {
                        pageName = SfmModel.PageName.MetalNameMaster;
                        HeadingName = "Metal Name";
                    } break;
                case "setting_type":
                    {
                        pageName = SfmModel.PageName.SettingType;
                        HeadingName = "Setting Type";
                    } break;
                case "chain_style":
                    {
                        pageName = SfmModel.PageName.ChainStyle;
                        HeadingName = "Chain Style";
                    } break;
                case "chain_length":
                    {
                        pageName = SfmModel.PageName.ChainLength;
                        HeadingName = "Chain Length";
                    } break;
                case "cert_gridle":
                    {
                        pageName = SfmModel.PageName.CertificateGridle;
                        HeadingName = "Certificate Gridle";
                    } break;
                case "cert_culet":
                    {
                        pageName = SfmModel.PageName.CertificateCulet;
                        HeadingName = "Certificate Culet";
                    } break;
                case "cert_polish":
                    {
                        pageName = SfmModel.PageName.CertificatePolish;
                        HeadingName = "Certificate Polish";
                    } break;
                case "cert_symmetry":
                    {
                        pageName = SfmModel.PageName.CertificateSymmetry;
                        HeadingName = "Certificate Symmetry";
                    } break;
                case "cert_flouresence":
                    {
                        pageName = SfmModel.PageName.CertificateFlouresence;
                        HeadingName = "Certificate Flouresence";
                    } break;
                case "cert_lab":
                    {
                        pageName = SfmModel.PageName.CertificateLab;
                        HeadingName = "Certificate Lab";
                    } break;
                case "ring_size":
                    {
                        pageName = SfmModel.PageName.RingSize;
                        HeadingName = "Ring Size";
                    } break;
                case "stone_shape":
                    {
                        pageName = SfmModel.PageName.StoneShape;
                        HeadingName = "Stone Shape";
                    } break;
                    // added by sumit for shipping name & shipping type
                case "shipping_name":
                    {
                        pageName = SfmModel.PageName.ShippingName;
                        HeadingName = "Shipping Name";
                    } break;
                case "shipping_type":
                    {
                        pageName = SfmModel.PageName.ShippingType;
                        HeadingName = "Shipping Type";
                    } break;
                case "news_category":
                    {
                        pageName = SfmModel.PageName.NewsCategory;
                        HeadingName = "News Category";
                    } break;
                case "chain_clasp":
                    {
                        pageName = SfmModel.PageName.ChainClasp;
                        HeadingName = "Chain Clasp";
                    } break;
                case "attribute_heading":
                    {
                        pageName = SfmModel.PageName.AttributeTitle;
                        HeadingName = "Attribute Title";
                    } break;
                default:
                    {
                        pageName = SfmModel.PageName.None;
                    }
                    break;
            }
            return pageName;
        }

        public bool DeleteSfm(int id, SfmModel.PageName pageName)
        {
            return objDAL.DeleteSfm(id, pageName);
        }

    }
}
