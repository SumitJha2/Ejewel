using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Common.Sfm;


namespace EJewel.DAL.Admin.Common.Sfm
{
    public class SfmdDAL
    {
        EJewelEntities objEntity = new EJewelEntities();

        public SfmModel SaveUpdateSfm(SfmModel model, SfmModel.PageName pageName)
        {
            try
            {
                if (model.AutoID == 0)
                {
                    model = this.SaveEnityObject(model, pageName);
                }
                else
                {
                    //for update
                    model = this.UpdateEntityObject(model, pageName);
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

        private SfmModel SaveEnityObject(SfmModel model, SfmModel.PageName pageName)
        {
            try
            {
                switch (pageName)
                {
                    #region Metal Weight
                    case SfmModel.PageName.MetalWeightMaster:
                        {
                            //for weight master
                            ej_MetalWeightMaster obj = new ej_MetalWeightMaster()
                            {
                                MetalWeightId = model.AutoID,
                                MetalWeight = model.Name,
                                Status = model.Status
                            };
                            objEntity.AddToej_MetalWeightMaster(obj);
                            objEntity.SaveChanges();
                            model.AutoID = obj.MetalWeightId;
                        }
                        break;
                    #endregion

                    #region Metal Name
                    case SfmModel.PageName.MetalNameMaster:
                        {
                            //for weight name
                            ej_MetalNameMaster obj = new ej_MetalNameMaster()
                            {
                                MetalNameId = model.AutoID,
                                MetalName = model.Name,
                                Status = model.Status
                            };
                            objEntity.AddToej_MetalNameMaster(obj);
                            objEntity.SaveChanges();
                            model.AutoID = obj.MetalNameId;
                        } break;
                    #endregion

                    #region Setting Type
                    case SfmModel.PageName.SettingType:
                        {
                            //for weight name
                            ej_SettingType obj = new ej_SettingType()
                            {
                                SettingTypeId = model.AutoID,
                                SettingTypeName = model.Name,
                                Status = model.Status
                            };
                            objEntity.AddToej_SettingType(obj);
                            objEntity.SaveChanges();
                            model.AutoID = obj.SettingTypeId;
                        }
                        break;
                    #endregion

                    #region Chain Style
                    case SfmModel.PageName.ChainStyle:
                        {
                            //for weight name
                            ej_ChainStyle obj = new ej_ChainStyle()
                            {
                                ChainStyleID = model.AutoID,
                                ChainStyle = model.Name,
                                Status = model.Status
                            };
                            objEntity.AddToej_ChainStyle(obj);
                            objEntity.SaveChanges();
                            model.AutoID = obj.ChainStyleID;
                        }
                        break;
                    #endregion

                    #region Chain Length
                    case SfmModel.PageName.ChainLength:
                        {
                            //for weight name
                            ej_ChainLength obj = new ej_ChainLength()
                            {
                                ChainLengthID = model.AutoID,
                                ChainLength = Convert.ToDouble(model.Name),
                                Status = model.Status
                            };
                            objEntity.AddToej_ChainLength(obj);
                            objEntity.SaveChanges();
                            model.AutoID = obj.ChainLengthID;
                        }
                        break;
                    #endregion

                    #region Certificate Culet
                    case SfmModel.PageName.CertificateCulet:
                        {
                            //for weight name
                            ej_CertificateCulet obj = new ej_CertificateCulet()
                            {
                                CertificateCuletId = model.AutoID,
                                CertificateCuletName = model.Name,
                                Status = model.Status
                            };
                            objEntity.AddToej_CertificateCulet(obj);
                            objEntity.SaveChanges();
                            model.AutoID = obj.CertificateCuletId;
                        }
                        break;
                    #endregion

                    #region Certificate Flouresence
                    case SfmModel.PageName.CertificateFlouresence:
                        {
                            //for weight name
                            ej_CertificateFlouresence obj = new ej_CertificateFlouresence()
                            {
                                CertificateFlouresenceId = model.AutoID,
                                CertificateFlouresenceName = model.Name,
                                Status = model.Status
                            };
                            objEntity.AddToej_CertificateFlouresence(obj);
                            objEntity.SaveChanges();
                            model.AutoID = obj.CertificateFlouresenceId;
                        }
                        break;
                    #endregion

                    #region Certificate Gridle
                    case SfmModel.PageName.CertificateGridle:
                        {
                            //for weight name
                            ej_CertificateGridle obj = new ej_CertificateGridle()
                            {
                                CertificateGridleId = model.AutoID,
                                CertificateGridleName = model.Name,
                                Status = model.Status
                            };
                            objEntity.AddToej_CertificateGridle(obj);
                            objEntity.SaveChanges();
                            model.AutoID = obj.CertificateGridleId;
                        }
                        break;
                    #endregion

                    #region Certificate Lab
                    case SfmModel.PageName.CertificateLab:
                        {
                            //for weight name
                            ej_CertificationLab obj = new ej_CertificationLab()
                            {
                                CertificateLabId = model.AutoID,
                                CertificateLabName = model.Name,
                                Status = model.Status
                            };
                            objEntity.AddToej_CertificationLab(obj);
                            objEntity.SaveChanges();
                            model.AutoID = obj.CertificateLabId;
                        }
                        break;
                    #endregion

                    #region Certificate Polish
                    case SfmModel.PageName.CertificatePolish:
                        {
                            //for weight name
                            ej_CertificatePolish obj = new ej_CertificatePolish()
                            {
                                CertificatePolishId = model.AutoID,
                                CertificatePolishName = model.Name,
                                Status = model.Status
                            };
                            objEntity.AddToej_CertificatePolish(obj);
                            objEntity.SaveChanges();
                            model.AutoID = obj.CertificatePolishId;
                        }
                        break;
                    #endregion

                    #region Certificate Symmetry
                    case SfmModel.PageName.CertificateSymmetry:
                        {
                            //for weight name
                            ej_CertificateSymmetry obj = new ej_CertificateSymmetry()
                            {
                                CertificateSymmetryId = model.AutoID,
                                CertificateSymmetryName = model.Name,
                                Status = model.Status
                            };
                            objEntity.AddToej_CertificateSymmetry(obj);
                            objEntity.SaveChanges();
                            model.AutoID = obj.CertificateSymmetryId;
                        }
                        break;
                    #endregion

                    #region Ring Size
                    case SfmModel.PageName.RingSize:
                        {
                            //for weight name
                            ej_RingSizeMaster obj = new ej_RingSizeMaster()
                            {
                                RingSizeId = model.AutoID,
                                RingSize = Convert.ToDouble(model.Name),
                                Status = model.Status
                            };
                            objEntity.AddToej_RingSizeMaster(obj);
                            objEntity.SaveChanges();
                            model.AutoID = obj.RingSizeId;
                        }
                        break;
                    #endregion

                    #region Stone Shape
                    case SfmModel.PageName.StoneShape:
                        {
                            //for weight name
                            ej_StoneShapeMaster obj = new ej_StoneShapeMaster()
                            {
                                ShapeId = model.AutoID,
                                Shape = model.Name,
                                Status = model.Status
                            };
                            objEntity.AddToej_StoneShapeMaster(obj);
                            objEntity.SaveChanges();
                            model.AutoID = obj.ShapeId;
                        }
                        break;
                    #endregion

                    #region Shipping Name
                    case SfmModel.PageName.ShippingName:
                        {
                            //for weight name
                            ej_ShippingName obj = new ej_ShippingName()
                            {
                                ShippingNameId = model.AutoID,
                                ShippingName = model.Name,
                                Status = model.Status
                            };
                            objEntity.AddToej_ShippingName(obj);
                            objEntity.SaveChanges();
                            model.AutoID = obj.ShippingNameId;
                        }
                        break;
                    #endregion

                    #region Shipping Type
                    case SfmModel.PageName.ShippingType:
                        {
                            //for weight name
                            ej_ShippingType obj = new ej_ShippingType()
                            {
                                ShippingTypeId = model.AutoID,
                                ShippingType = model.Name,
                                Status = model.Status
                            };
                            objEntity.AddToej_ShippingType(obj);
                            objEntity.SaveChanges();
                            model.AutoID = obj.ShippingTypeId;
                        }
                        break;
                    #endregion

                    #region News Category
                    case SfmModel.PageName.NewsCategory:
                        {
                            //for news category

                            ej_NewsCategory obj = new ej_NewsCategory()
                            {

                                NewsCategoryID = model.AutoID,
                                CategoryName = model.Name,
                                Status = model.Status
                            };
                            objEntity.AddToej_NewsCategory(obj);
                            objEntity.SaveChanges();
                            model.AutoID = obj.NewsCategoryID;
                        }
                        break;
                    #endregion

                    #region Chain Clasp
                    case SfmModel.PageName.ChainClasp:
                        {
                            //for news category

                            ej_ChainClasp obj = new ej_ChainClasp()
                            {

                                ChainClaspId = model.AutoID,
                                ChainClasp = model.Name,
                                Status = model.Status
                            };
                            objEntity.AddToej_ChainClasp(obj);
                            objEntity.SaveChanges();
                            model.AutoID = obj.ChainClaspId;
                        }
                        break;
                    #endregion

                    #region Attribute Title
                    case SfmModel.PageName.AttributeTitle:
                        {
                            //for news category

                            ej_AttributeTitle obj = new ej_AttributeTitle()
                            {

                                AttributeTitleId = model.AutoID,
                                AttributeTitle = model.Name,
                                Status = model.Status
                            };
                            objEntity.AddToej_AttributeTitle(obj);
                            objEntity.SaveChanges();
                            model.AutoID = obj.AttributeTitleId;
                        }
                        break;
                    #endregion

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

        private SfmModel UpdateEntityObject(SfmModel model, SfmModel.PageName pageName)
        {
            try
            {
                switch (pageName)
                {
                    #region Metal Weight
                    case SfmModel.PageName.MetalWeightMaster:
                        {
                            //for wetal weight master
                            ej_MetalWeightMaster obj = objEntity.ej_MetalWeightMaster.Where(tbl => tbl.MetalWeightId == model.AutoID).FirstOrDefault();
                            if (obj != null)
                            {
                                //check that the data is not same as the metal weight
                                //check thaat the same name is present or not in the database
                                if (obj.MetalWeight != model.Name)
                                {
                                    //check thaat the same name is present or not
                                    if (!objEntity.ej_MetalWeightMaster.Where(tbl => tbl.MetalWeight == model.Name).Any())
                                    {
                                        obj.MetalWeight = model.Name;
                                    }
                                }
                                obj.Status = model.Status;
                                objEntity.SaveChanges();
                            }

                        } break;
                    #endregion

                    #region Metal Name
                    case SfmModel.PageName.MetalNameMaster:
                        {
                            //for metal weight name
                            //for wetal weight master
                            ej_MetalNameMaster obj = objEntity.ej_MetalNameMaster.Where(tbl => tbl.MetalNameId == model.AutoID).FirstOrDefault();
                            if (obj != null)
                            {
                                //check that the data is not same as the metal weight
                                //check thaat the same name is present or not in the database
                                if (obj.MetalName != model.Name)
                                {
                                    //check thaat the same name is present or not
                                    if (!objEntity.ej_MetalNameMaster.Where(tbl => tbl.MetalName == model.Name && tbl.MetalNameId != model.AutoID).Any())
                                    {
                                        obj.MetalName = model.Name;
                                    }
                                }
                                obj.Status = model.Status;
                                objEntity.SaveChanges();
                            } break;
                        }
                    #endregion

                    #region Setting Type
                    case SfmModel.PageName.SettingType:
                        {
                            //for metal weight name
                            //for wetal weight master
                            ej_SettingType obj = objEntity.ej_SettingType.Where(tbl => tbl.SettingTypeId == model.AutoID).FirstOrDefault();
                            if (obj != null)
                            {
                                //check that the data is not same as the metal weight
                                //check thaat the same name is present or not in the database
                                if (obj.SettingTypeName != model.Name)
                                {
                                    //check thaat the same name is present or not
                                    if (!objEntity.ej_SettingType.Where(tbl => tbl.SettingTypeName == model.Name).Any())
                                    {
                                        obj.SettingTypeName = model.Name;
                                    }
                                }
                                obj.Status = model.Status;
                                objEntity.SaveChanges();
                            } break;
                        }
                    #endregion

                    #region Chain Style
                    case SfmModel.PageName.ChainStyle:
                        {
                            //for metal weight name
                            //for wetal weight master
                            ej_ChainStyle obj = objEntity.ej_ChainStyle.Where(tbl => tbl.ChainStyleID == model.AutoID).FirstOrDefault();
                            if (obj != null)
                            {
                                //check that the data is not same as the metal weight
                                //check thaat the same name is present or not in the database
                                if (obj.ChainStyle != model.Name)
                                {
                                    //check thaat the same name is present or not
                                    if (!objEntity.ej_ChainStyle.Where(tbl => tbl.ChainStyle == model.Name).Any())
                                    {
                                        obj.ChainStyle = model.Name;
                                    }
                                }
                                obj.Status = model.Status;
                                objEntity.SaveChanges();
                            } break;
                        }
                    #endregion

                    #region Chain Length
                    case SfmModel.PageName.ChainLength:
                        {
                            //for metal weight name
                            //for wetal weight master
                            ej_ChainLength obj = objEntity.ej_ChainLength.Where(tbl => tbl.ChainLengthID == model.AutoID).FirstOrDefault();
                            if (obj != null)
                            {
                                double chain_length = Convert.ToDouble(model.Name);
                                //check that the data is not same as the metal weight
                                //check thaat the same name is present or not in the database
                                if (obj.ChainLength != chain_length)
                                {
                                    //check thaat the same name is present or not
                                    if (!objEntity.ej_ChainLength.Where(tbl => tbl.ChainLength == chain_length).Any())
                                    {
                                        obj.ChainLength = chain_length;
                                    }
                                }
                                obj.Status = model.Status;
                                objEntity.SaveChanges();
                            } break;
                        }
                    #endregion

                    #region Certificate Culet
                    case SfmModel.PageName.CertificateCulet:
                        {
                            ej_CertificateCulet obj = objEntity.ej_CertificateCulet.Where(tbl => tbl.CertificateCuletId == model.AutoID).FirstOrDefault();
                            if (obj != null)
                            {
                                //check that the data is not same as the metal weight
                                //check thaat the same name is present or not in the database
                                if (obj.CertificateCuletName != model.Name)
                                {
                                    //check thaat the same name is present or not
                                    if (!objEntity.ej_CertificateCulet.Where(tbl => tbl.CertificateCuletName == model.Name).Any())
                                    {
                                        obj.CertificateCuletName = model.Name;
                                    }
                                }
                                obj.Status = model.Status;
                                objEntity.SaveChanges();
                            } break;
                        }
                    #endregion

                    #region Certificate Flouresence
                    case SfmModel.PageName.CertificateFlouresence:
                        {
                            ej_CertificateFlouresence obj = objEntity.ej_CertificateFlouresence.Where(tbl => tbl.CertificateFlouresenceId == model.AutoID).FirstOrDefault();
                            if (obj != null)
                            {
                                //check that the data is not same as the metal weight
                                //check thaat the same name is present or not in the database
                                if (obj.CertificateFlouresenceName != model.Name)
                                {
                                    //check thaat the same name is present or not
                                    if (!objEntity.ej_CertificateFlouresence.Where(tbl => tbl.CertificateFlouresenceName == model.Name).Any())
                                    {
                                        obj.CertificateFlouresenceName = model.Name;
                                    }
                                }
                                obj.Status = model.Status;
                                objEntity.SaveChanges();
                            } break;
                        }
                    #endregion

                    #region Certificate Gridle
                    case SfmModel.PageName.CertificateGridle:
                        {
                            ej_CertificateGridle obj = objEntity.ej_CertificateGridle.Where(tbl => tbl.CertificateGridleId == model.AutoID).FirstOrDefault();
                            if (obj != null)
                            {
                                //check that the data is not same as the metal weight
                                //check thaat the same name is present or not in the database
                                if (obj.CertificateGridleName != model.Name)
                                {
                                    //check thaat the same name is present or not
                                    if (!objEntity.ej_CertificateGridle.Where(tbl => tbl.CertificateGridleName == model.Name).Any())
                                    {
                                        obj.CertificateGridleName = model.Name;
                                    }
                                }
                                obj.Status = model.Status;
                                objEntity.SaveChanges();
                            } break;
                        }
                    #endregion

                    #region Certificate Lab
                    case SfmModel.PageName.CertificateLab:
                        {
                            ej_CertificationLab obj = objEntity.ej_CertificationLab.Where(tbl => tbl.CertificateLabId == model.AutoID).FirstOrDefault();
                            if (obj != null)
                            {
                                //check that the data is not same as the metal weight
                                //check thaat the same name is present or not in the database
                                if (obj.CertificateLabName != model.Name)
                                {
                                    //check thaat the same name is present or not
                                    if (!objEntity.ej_CertificationLab.Where(tbl => tbl.CertificateLabName == model.Name).Any())
                                    {
                                        obj.CertificateLabName = model.Name;
                                    }
                                }
                                obj.Status = model.Status;
                                objEntity.SaveChanges();
                            } break;
                        }
                    #endregion

                    #region Certificate Poilsh
                    case SfmModel.PageName.CertificatePolish:
                        {
                            ej_CertificatePolish obj = objEntity.ej_CertificatePolish.Where(tbl => tbl.CertificatePolishId == model.AutoID).FirstOrDefault();
                            if (obj != null)
                            {
                                //check that the data is not same as the metal weight
                                //check thaat the same name is present or not in the database
                                if (obj.CertificatePolishName != model.Name)
                                {
                                    //check thaat the same name is present or not
                                    if (!objEntity.ej_CertificatePolish.Where(tbl => tbl.CertificatePolishName == model.Name).Any())
                                    {
                                        obj.CertificatePolishName = model.Name;
                                    }
                                }
                                obj.Status = model.Status;
                                objEntity.SaveChanges();
                            } break;
                        }
                    #endregion

                    #region Certificate Symmetry
                    case SfmModel.PageName.CertificateSymmetry:
                        {
                            ej_CertificateSymmetry obj = objEntity.ej_CertificateSymmetry.Where(tbl => tbl.CertificateSymmetryId == model.AutoID).FirstOrDefault();
                            if (obj != null)
                            {
                                //check that the data is not same as the metal weight
                                //check thaat the same name is present or not in the database
                                if (obj.CertificateSymmetryName != model.Name)
                                {
                                    //check thaat the same name is present or not
                                    if (!objEntity.ej_CertificateSymmetry.Where(tbl => tbl.CertificateSymmetryName == model.Name).Any())
                                    {
                                        obj.CertificateSymmetryName = model.Name;
                                    }
                                }
                                obj.Status = model.Status;
                                objEntity.SaveChanges();
                            } break;
                        }
                    #endregion

                    #region Ring Size
                    case SfmModel.PageName.RingSize:
                        {
                            ej_RingSizeMaster obj = objEntity.ej_RingSizeMaster.Where(tbl => tbl.RingSizeId == model.AutoID).FirstOrDefault();
                            if (obj != null)
                            {
                                //check that the data is not same as the metal weight
                                //check thaat the same name is present or not in the database
                                if (obj.RingSize != Convert.ToDouble(model.Name))
                                {
                                    //check thaat the same name is present or not
                                    if (!objEntity.ej_RingSizeMaster.Where(tbl => tbl.RingSize == Convert.ToDouble(model.Name)).Any())
                                    {
                                        obj.RingSize = Convert.ToDouble(model.Name);
                                    }
                                }
                                obj.Status = model.Status;
                                objEntity.SaveChanges();
                            } break;
                        }
                    #endregion

                    #region Certificate Symmetry
                    case SfmModel.PageName.StoneShape:
                        {
                            ej_StoneShapeMaster obj = objEntity.ej_StoneShapeMaster.Where(tbl => tbl.ShapeId == model.AutoID).FirstOrDefault();
                            if (obj != null)
                            {
                                //check that the data is not same as the metal weight
                                //check thaat the same name is present or not in the database
                                if (obj.Shape != model.Name)
                                {
                                    //check thaat the same name is present or not
                                    if (!objEntity.ej_StoneShapeMaster.Where(tbl => tbl.Shape == model.Name && tbl.ShapeId != model.AutoID).Any())
                                    {
                                        obj.Shape = model.Name;
                                    }
                                }
                                obj.Status = model.Status;
                                objEntity.SaveChanges();
                            } break;
                        }
                    #endregion

                    #region Shipment Name
                    case SfmModel.PageName.ShippingName:
                        {
                            ej_ShippingName obj = objEntity.ej_ShippingName.Where(tbl => tbl.ShippingNameId == model.AutoID).FirstOrDefault();
                            if (obj != null)
                            {
                                //check that the data is not same as the metal weight
                                //check thaat the same name is present or not in the database
                                if (obj.ShippingName != model.Name)
                                {
                                    //check thaat the same name is present or not
                                    if (!objEntity.ej_ShippingName.Where(tbl => tbl.ShippingName == model.Name && tbl.ShippingNameId != model.AutoID).Any())
                                    {
                                        obj.ShippingName = model.Name;
                                    }
                                }
                                obj.Status = model.Status;
                                objEntity.SaveChanges();
                            } break;
                        }
                    #endregion

                    #region Shipment Type
                    case SfmModel.PageName.ShippingType:
                        {
                            ej_ShippingType obj = objEntity.ej_ShippingType.Where(tbl => tbl.ShippingTypeId == model.AutoID).FirstOrDefault();
                            if (obj != null)
                            {
                                //check that the data is not same as the metal weight
                                //check thaat the same name is present or not in the database
                                if (obj.ShippingType != model.Name)
                                {
                                    //check thaat the same name is present or not
                                    if (!objEntity.ej_ShippingName.Where(tbl => tbl.ShippingName == model.Name && tbl.ShippingNameId != model.AutoID).Any())
                                    {
                                        obj.ShippingType = model.Name;
                                    }
                                }
                                obj.Status = model.Status;
                                objEntity.SaveChanges();
                            } break;
                        }
                    #endregion

                    #region News Category
                    case SfmModel.PageName.NewsCategory:
                        {

                            ej_NewsCategory obj = objEntity.ej_NewsCategory.Where(tbl => tbl.NewsCategoryID == model.AutoID).FirstOrDefault();
                            if (obj != null)
                            {
                                //check that the data is not same as the metal weight
                                //check thaat the same name is present or not in the database
                                if (obj.CategoryName != model.Name)
                                {
                                    //check thaat the same name is present or not
                                    if (!objEntity.ej_NewsCategory.Where(tbl => tbl.CategoryName == model.Name && tbl.NewsCategoryID != model.AutoID).Any())
                                    {
                                        obj.CategoryName = model.Name;
                                    }
                                }
                                obj.Status = model.Status;
                                objEntity.SaveChanges();
                            } break;
                        }
                    #endregion

                    #region Chain Clasp

                    case SfmModel.PageName.ChainClasp:
                        {

                            ej_ChainClasp obj = objEntity.ej_ChainClasp.Where(tbl => tbl.ChainClaspId == model.AutoID).FirstOrDefault();
                            if (obj != null)
                            {

                                //check thaat the same name is present or not in the database
                                if (obj.ChainClasp != model.Name)
                                {
                                    //check thaat the same name is present or not
                                    if (!objEntity.ej_ChainClasp.Where(tbl => tbl.ChainClasp == model.Name && tbl.ChainClaspId != model.AutoID).Any())
                                    {
                                        obj.ChainClasp = model.Name;
                                    }
                                }
                                obj.Status = model.Status;
                                objEntity.SaveChanges();
                            } break;
                        }

                    #endregion

                    #region Attribute Title

                    case SfmModel.PageName.AttributeTitle:
                        {

                            ej_AttributeTitle obj = objEntity.ej_AttributeTitle.Where(tbl => tbl.AttributeTitleId == model.AutoID).FirstOrDefault();
                            if (obj != null)
                            {

                                //check thaat the same name is present or not in the database
                                if (obj.AttributeTitle != model.Name)
                                {
                                    //check thaat the same name is present or not
                                    if (!objEntity.ej_AttributeTitle.Where(tbl => tbl.AttributeTitle == model.Name && tbl.AttributeTitleId != model.AutoID).Any())
                                    {
                                        obj.AttributeTitle = model.Name;
                                    }
                                }
                                obj.Status = model.Status;
                                objEntity.SaveChanges();
                            } break;
                        }

                    #endregion

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

        public List<SfmModel> GetSfmList(int id, CommonModel.RecordStatus rStatus, SfmModel.PageName pageName)
        {
            List<SfmModel> lstModel = new List<SfmModel>();
            try
            {
                switch (pageName)
                {
                    #region For Metal Weight Master
                    case SfmModel.PageName.MetalWeightMaster:
                        {
                            List<ej_MetalWeightMaster> lstObj = null;

                            lstObj = id > 0 ? objEntity.ej_MetalWeightMaster.Where(tbl => tbl.MetalWeightId == id).ToList() : objEntity.ej_MetalWeightMaster.Select(tbl => tbl).ToList();
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstObj != null)
                            {
                                lstModel = (from obj in lstObj
                                            select new SfmModel()
                                            {
                                                AutoID = obj.MetalWeightId,
                                                Name = obj.MetalWeight,
                                                Status = obj.Status
                                            }).ToList();
                            }

                        }
                        break;
                    #endregion

                    #region For Metal Name Master
                    case SfmModel.PageName.MetalNameMaster:
                        {
                            List<ej_MetalNameMaster> lstObj = null;
                            lstObj = id > 0 ? objEntity.ej_MetalNameMaster.Where(tbl => tbl.MetalNameId == id).ToList() : objEntity.ej_MetalNameMaster.Select(tbl => tbl).ToList();
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstObj != null)
                            {
                                lstModel = (from obj in lstObj
                                            select new SfmModel()
                                            {
                                                AutoID = obj.MetalNameId,
                                                Name = obj.MetalName,
                                                Status = obj.Status
                                            }).ToList();
                            }

                        }
                        break;
                    #endregion

                    #region For Setting Type Master
                    case SfmModel.PageName.SettingType:
                        {
                            List<ej_SettingType> lstObj = null;
                            lstObj = id > 0 ? objEntity.ej_SettingType.Where(tbl => tbl.SettingTypeId == id).ToList() : objEntity.ej_SettingType.Select(tbl => tbl).ToList();

                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstObj != null)
                            {
                                lstModel = (from obj in lstObj
                                            select new SfmModel()
                                            {
                                                AutoID = obj.SettingTypeId,
                                                Name = obj.SettingTypeName,
                                                Status = obj.Status
                                            }).ToList();
                            }
                        }
                        break;
                    #endregion

                    #region For Chain Style
                    case SfmModel.PageName.ChainStyle:
                        {
                            List<ej_ChainStyle> lstObj = null;
                            lstObj = id > 0 ? objEntity.ej_ChainStyle.Where(tbl => tbl.ChainStyleID == id).ToList() : objEntity.ej_ChainStyle.Select(tbl => tbl).ToList();

                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstObj != null)
                            {
                                lstModel = (from obj in lstObj
                                            select new SfmModel()
                                            {
                                                AutoID = obj.ChainStyleID,
                                                Name = obj.ChainStyle,
                                                Status = obj.Status
                                            }).ToList();
                            }
                        }
                        break;
                    #endregion

                    #region For Chain Length
                    case SfmModel.PageName.ChainLength:
                        {
                            List<ej_ChainLength> lstObj = null;
                            lstObj = id > 0 ? objEntity.ej_ChainLength.Where(tbl => tbl.ChainLengthID == id).ToList() : objEntity.ej_ChainLength.Select(tbl => tbl).ToList();

                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstObj != null)
                            {
                                lstModel = (from obj in lstObj
                                            select new SfmModel()
                                            {
                                                AutoID = obj.ChainLengthID,
                                                Name = Convert.ToString(obj.ChainLength),
                                                Status = obj.Status
                                            }).ToList();
                            }
                        }
                        break;
                    #endregion

                    #region For Certificate Culet
                    case SfmModel.PageName.CertificateCulet:
                        {
                            List<ej_CertificateCulet> lstObj = null;
                            //get list
                            lstObj = id > 0 ? objEntity.ej_CertificateCulet.Where(tbl => tbl.CertificateCuletId == id).ToList() : objEntity.ej_CertificateCulet.Select(tbl => tbl).ToList();
                            //for status
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstObj != null)
                            {
                                lstModel = (from obj in lstObj
                                            select new SfmModel()
                                            {
                                                AutoID = obj.CertificateCuletId,
                                                Name = obj.CertificateCuletName,
                                                Status = obj.Status
                                            }).ToList();
                            }
                        }
                        break;
                    #endregion

                    #region For Certificate Flouresence
                    case SfmModel.PageName.CertificateFlouresence:
                        {
                            List<ej_CertificateFlouresence> lstObj = null;
                            //get list
                            lstObj = id > 0 ? objEntity.ej_CertificateFlouresence.Where(tbl => tbl.CertificateFlouresenceId == id).ToList() : objEntity.ej_CertificateFlouresence.Select(tbl => tbl).ToList();
                            //for status
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstObj != null)
                            {
                                lstModel = (from obj in lstObj
                                            select new SfmModel()
                                            {
                                                AutoID = obj.CertificateFlouresenceId,
                                                Name = obj.CertificateFlouresenceName,
                                                Status = obj.Status
                                            }).ToList();
                            }
                        }
                        break;
                    #endregion

                    #region For Certificate Gridle
                    case SfmModel.PageName.CertificateGridle:
                        {
                            List<ej_CertificateGridle> lstObj = null;
                            //get list
                            lstObj = id > 0 ? objEntity.ej_CertificateGridle.Where(tbl => tbl.CertificateGridleId == id).ToList() : objEntity.ej_CertificateGridle.Select(tbl => tbl).ToList();
                            //for status
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstObj != null)
                            {
                                lstModel = (from obj in lstObj
                                            select new SfmModel()
                                            {
                                                AutoID = obj.CertificateGridleId,
                                                Name = obj.CertificateGridleName,
                                                Status = obj.Status
                                            }).ToList();
                            }
                        }
                        break;
                    #endregion

                    #region For Certificate Lab
                    case SfmModel.PageName.CertificateLab:
                        {
                            List<ej_CertificationLab> lstObj = null;
                            //get list
                            lstObj = id > 0 ? objEntity.ej_CertificationLab.Where(tbl => tbl.CertificateLabId == id).ToList() : objEntity.ej_CertificationLab.Select(tbl => tbl).ToList();
                            //for status
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstObj != null)
                            {
                                lstModel = (from obj in lstObj
                                            select new SfmModel()
                                            {
                                                AutoID = obj.CertificateLabId,
                                                Name = obj.CertificateLabName,
                                                Status = obj.Status
                                            }).ToList();
                            }
                        }
                        break;
                    #endregion

                    #region For Certificate Polish
                    case SfmModel.PageName.CertificatePolish:
                        {
                            List<ej_CertificatePolish> lstObj = null;
                            //get list
                            lstObj = id > 0 ? objEntity.ej_CertificatePolish.Where(tbl => tbl.CertificatePolishId == id).ToList() : objEntity.ej_CertificatePolish.Select(tbl => tbl).ToList();
                            //for status
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstObj != null)
                            {
                                lstModel = (from obj in lstObj
                                            select new SfmModel()
                                            {
                                                AutoID = obj.CertificatePolishId,
                                                Name = obj.CertificatePolishName,
                                                Status = obj.Status
                                            }).ToList();
                            }
                        }
                        break;
                    #endregion

                    #region For Certificate Symmetry
                    case SfmModel.PageName.CertificateSymmetry:
                        {
                            List<ej_CertificateSymmetry> lstObj = null;
                            //get list
                            lstObj = id > 0 ? objEntity.ej_CertificateSymmetry.Where(tbl => tbl.CertificateSymmetryId == id).ToList() : objEntity.ej_CertificateSymmetry.Select(tbl => tbl).ToList();
                            //for status
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstObj != null)
                            {
                                lstModel = (from obj in lstObj
                                            select new SfmModel()
                                            {
                                                AutoID = obj.CertificateSymmetryId,
                                                Name = obj.CertificateSymmetryName,
                                                Status = obj.Status
                                            }).ToList();
                            }
                        }
                        break;
                    #endregion

                    #region For Ring Size
                    case SfmModel.PageName.RingSize:
                        {
                            List<ej_RingSizeMaster> lstObj = null;
                            //get list
                            lstObj = id > 0 ? objEntity.ej_RingSizeMaster.Where(tbl => tbl.RingSizeId == id).ToList() : objEntity.ej_RingSizeMaster.Select(tbl => tbl).ToList();
                            //for status
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstObj != null)
                            {
                                lstModel = (from obj in lstObj
                                            select new SfmModel()
                                            {
                                                AutoID = obj.RingSizeId,
                                                Name = Convert.ToString(obj.RingSize),
                                                Status = obj.Status
                                            }).ToList();
                            }
                        }
                        break;
                    #endregion

                    #region For Stone Shape
                    case SfmModel.PageName.StoneShape:
                        {
                            List<ej_StoneShapeMaster> lstObj = null;
                            //get list
                            lstObj = id > 0 ? objEntity.ej_StoneShapeMaster.Where(tbl => tbl.ShapeId == id).ToList() : objEntity.ej_StoneShapeMaster.Select(tbl => tbl).ToList();
                            //for status
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstObj != null)
                            {
                                lstModel = (from obj in lstObj
                                            select new SfmModel()
                                            {
                                                AutoID = obj.ShapeId,
                                                Name = obj.Shape,
                                                Status = obj.Status
                                            }).ToList();
                            }
                        }
                        break;
                    #endregion

                    #region For Shipping Name
                    case SfmModel.PageName.ShippingName:
                        {
                            List<ej_ShippingName> lstObj = null;
                            //get list
                            lstObj = id > 0 ? objEntity.ej_ShippingName.Where(tbl => tbl.ShippingNameId == id).ToList() : objEntity.ej_ShippingName.Select(tbl => tbl).ToList();
                            //for status
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstObj != null)
                            {
                                lstModel = (from obj in lstObj
                                            select new SfmModel()
                                            {
                                                AutoID = obj.ShippingNameId,
                                                Name = obj.ShippingName,
                                                Status = obj.Status
                                            }).ToList();
                            }
                        }
                        break;
                    #endregion

                    #region For Shipping Type
                    case SfmModel.PageName.ShippingType:
                        {
                            List<ej_ShippingType> lstObj = null;
                            //get list
                            //lstObj = id > 0 ? objEntity.ej_ShippingType.Where(tbl => tbl.ShippingTypeId == id).ToList() : objEntity.ej_ShippingName.Select(tbl => tbl).ToList();
                            lstObj = id > 0 ? objEntity.ej_ShippingType.Where(tbl => tbl.ShippingTypeId == id).ToList() : objEntity.ej_ShippingType.Select(tbl => tbl).ToList();
                            //for status
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstObj != null)
                            {
                                lstModel = (from obj in lstObj
                                            select new SfmModel()
                                            {
                                                AutoID = obj.ShippingTypeId,
                                                Name = obj.ShippingType,
                                                Status = obj.Status
                                            }).ToList();
                            }
                        }
                        break;
                    #endregion

                    #region For News Category
                    case SfmModel.PageName.NewsCategory:
                        {
                            List<ej_NewsCategory> lstObj = null;
                            //get list
                            //lstObj = id > 0 ? objEntity.ej_ShippingType.Where(tbl => tbl.ShippingTypeId == id).ToList() : objEntity.ej_ShippingName.Select(tbl => tbl).ToList();
                            lstObj = id > 0 ? objEntity.ej_NewsCategory.Where(tbl => tbl.NewsCategoryID == id).ToList() : objEntity.ej_NewsCategory.Select(tbl => tbl).ToList();
                            //for status
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstObj != null)
                            {
                                lstModel = (from obj in lstObj
                                            select new SfmModel()
                                            {
                                                AutoID = obj.NewsCategoryID,
                                                Name = obj.CategoryName,
                                                Status = obj.Status
                                            }).ToList();
                            }
                        }
                        break;
                    #endregion

                    #region For Chain Clasp
                    case SfmModel.PageName.ChainClasp:
                        {
                            List<ej_ChainClasp> lstObj = null;
                            //get list
                            //lstObj = id > 0 ? objEntity.ej_ShippingType.Where(tbl => tbl.ShippingTypeId == id).ToList() : objEntity.ej_ShippingName.Select(tbl => tbl).ToList();
                            lstObj = id > 0 ? objEntity.ej_ChainClasp.Where(tbl => tbl.ChainClaspId == id).ToList() : objEntity.ej_ChainClasp.Select(tbl => tbl).ToList();
                            //for status
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstObj != null)
                            {
                                lstModel = (from obj in lstObj
                                            select new SfmModel()
                                            {
                                                AutoID = obj.ChainClaspId,
                                                Name = obj.ChainClasp,
                                                Status = obj.Status
                                            }).ToList();
                            }
                        }
                        break;
                    #endregion

                    #region For Attribute Title
                    case SfmModel.PageName.AttributeTitle:
                        {
                            List<ej_AttributeTitle> lstObj = null;
                            //get list

                            lstObj = id > 0 ? objEntity.ej_AttributeTitle.Where(tbl => tbl.AttributeTitleId == id).ToList() : objEntity.ej_AttributeTitle.Select(tbl => tbl).ToList();
                            //for status
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                            }
                            if (lstObj != null)
                            {
                                lstModel = (from obj in lstObj
                                            select new SfmModel()
                                            {
                                                AutoID = obj.AttributeTitleId,
                                                Name = obj.AttributeTitle,
                                                Status = obj.Status
                                            }).ToList();
                            }
                        }
                        break;
                    #endregion



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
            return lstModel.OrderBy(tbl => tbl.Name).ToList();
        }

        public int GetTotalSfm(SfmModel.PageName pageName)
        {
            int total = 0;
            try
            {
                switch (pageName)
                {
                    case SfmModel.PageName.MetalWeightMaster:
                        {
                            total = objEntity.ej_MetalWeightMaster.Select(tbl => tbl).Count();
                        }
                        break;
                    case SfmModel.PageName.MetalNameMaster:
                        {
                            total = objEntity.ej_MetalNameMaster.Select(tbl => tbl).Count();
                        }
                        break;
                    case SfmModel.PageName.SettingType:
                        {
                            total = objEntity.ej_SettingType.Select(tbl => tbl).Count();
                        }
                        break;
                    case SfmModel.PageName.ChainStyle:
                        {
                            total = objEntity.ej_ChainStyle.Select(tbl => tbl).Count();
                        }
                        break;
                    case SfmModel.PageName.ChainLength:
                        {
                            total = objEntity.ej_ChainLength.Select(tbl => tbl).Count();
                        }
                        break;
                    case SfmModel.PageName.CertificateCulet:
                        {
                            total = objEntity.ej_CertificateCulet.Select(tbl => tbl).Count();
                        }
                        break;
                    case SfmModel.PageName.CertificateFlouresence:
                        {
                            total = objEntity.ej_CertificateFlouresence.Select(tbl => tbl).Count();
                        }
                        break;
                    case SfmModel.PageName.CertificateGridle:
                        {
                            total = objEntity.ej_CertificateGridle.Select(tbl => tbl).Count();
                        }
                        break;
                    case SfmModel.PageName.CertificateLab:
                        {
                            total = objEntity.ej_CertificationLab.Select(tbl => tbl).Count();
                        }
                        break;
                    case SfmModel.PageName.CertificatePolish:
                        {
                            total = objEntity.ej_CertificatePolish.Select(tbl => tbl).Count();
                        }
                        break;
                    case SfmModel.PageName.CertificateSymmetry:
                        {
                            total = objEntity.ej_CertificateSymmetry.Select(tbl => tbl).Count();
                        }
                        break;
                    case SfmModel.PageName.RingSize:
                        {
                            total = objEntity.ej_RingSizeMaster.Select(tbl => tbl).Count();
                        }
                        break;
                    case SfmModel.PageName.StoneShape:
                        {
                            total = objEntity.ej_StoneShapeMaster.Select(tbl => tbl).Count();
                        }
                        break;
                    case SfmModel.PageName.ShippingName:
                        {
                            total = objEntity.ej_ShippingName.Select(tbl => tbl).Count();
                        }
                        break;
                    case SfmModel.PageName.ShippingType:
                        {
                            total = objEntity.ej_ShippingType.Select(tbl => tbl).Count();
                        }
                        break;
                    case SfmModel.PageName.NewsCategory:
                        {
                            total = objEntity.ej_NewsCategory.Select(tbl => tbl).Count();
                        }
                        break;
                    case SfmModel.PageName.ChainClasp:
                        {
                            total = objEntity.ej_ChainClasp.Select(tbl => tbl).Count();
                        }
                        break;
                    case SfmModel.PageName.AttributeTitle:
                        {
                            total = objEntity.ej_AttributeTitle.Select(tbl => tbl).Count();
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
            return total;
        }

        public bool IsExist(string name, SfmModel.PageName pageName)
        {
            bool result = true;
            try
            {
                switch (pageName)
                {
                    case SfmModel.PageName.MetalWeightMaster:
                        {
                            result = objEntity.ej_MetalWeightMaster.Where(tbl => tbl.MetalWeight == name).Any();
                        }
                        break;
                    case SfmModel.PageName.MetalNameMaster:
                        {
                            result = objEntity.ej_MetalNameMaster.Where(tbl => tbl.MetalName == name).Any();
                        }
                        break;
                    case SfmModel.PageName.SettingType:
                        {
                            result = objEntity.ej_SettingType.Where(tbl => tbl.SettingTypeName == name).Any();
                        }
                        break;
                    case SfmModel.PageName.ChainStyle:
                        {
                            result = objEntity.ej_ChainStyle.Where(tbl => tbl.ChainStyle == name).Any();
                        }
                        break;
                    case SfmModel.PageName.ChainLength:
                        {
                            double chain_length = Convert.ToDouble(name);
                            result = objEntity.ej_ChainLength.Where(tbl => tbl.ChainLength == chain_length).Any();
                        }
                        break;
                    case SfmModel.PageName.CertificateCulet:
                        {
                            result = objEntity.ej_CertificateCulet.Where(tbl => tbl.CertificateCuletName == name).Any();
                        }
                        break;
                    case SfmModel.PageName.CertificateFlouresence:
                        {
                            result = objEntity.ej_CertificateFlouresence.Where(tbl => tbl.CertificateFlouresenceName == name).Any();
                        }
                        break;
                    case SfmModel.PageName.CertificateGridle:
                        {
                            result = objEntity.ej_CertificateGridle.Where(tbl => tbl.CertificateGridleName == name).Any();
                        }
                        break;
                    case SfmModel.PageName.CertificateLab:
                        {
                            result = objEntity.ej_CertificationLab.Where(tbl => tbl.CertificateLabName == name).Any();
                        }
                        break;
                    case SfmModel.PageName.CertificatePolish:
                        {
                            result = objEntity.ej_CertificatePolish.Where(tbl => tbl.CertificatePolishName == name).Any();
                        }
                        break;
                    case SfmModel.PageName.CertificateSymmetry:
                        {
                            result = objEntity.ej_CertificateSymmetry.Where(tbl => tbl.CertificateSymmetryName == name).Any();
                        }
                        break;
                    case SfmModel.PageName.RingSize:
                        {
                            double ring_size = Convert.ToDouble(name);
                            result = objEntity.ej_RingSizeMaster.Where(tbl => tbl.RingSize == ring_size).Any();
                        }
                        break;
                    case SfmModel.PageName.StoneShape:
                        {
                            result = objEntity.ej_StoneShapeMaster.Where(tbl => tbl.Shape == name).Any();
                        }
                        break;
                    case SfmModel.PageName.ShippingName:
                        {
                            result = objEntity.ej_ShippingName.Where(tbl => tbl.ShippingName == name).Any();
                        }
                        break;
                    case SfmModel.PageName.ShippingType:
                        {
                            result = objEntity.ej_ShippingType.Where(tbl => tbl.ShippingType == name).Any();
                        }
                        break;
                    case SfmModel.PageName.NewsCategory:
                        {
                            result = objEntity.ej_NewsCategory.Where(tbl => tbl.CategoryName == name).Any();
                        }
                        break;
                    case SfmModel.PageName.ChainClasp:
                        {
                            result = objEntity.ej_ChainClasp.Where(tbl => tbl.ChainClasp == name).Any();
                        }
                        break;
                    case SfmModel.PageName.AttributeTitle:
                        {
                            result = objEntity.ej_AttributeTitle.Where(tbl => tbl.AttributeTitle == name).Any();
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

        public bool DeleteSfm(int id, SfmModel.PageName pageName)
        {
            bool flag = false;
            try
            {
                switch (pageName)
                {
                    case SfmModel.PageName.MetalNameMaster:
                        {
                            ej_MetalNameMaster obj = objEntity.ej_MetalNameMaster.Where(tbl => tbl.MetalNameId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case SfmModel.PageName.MetalWeightMaster:
                        {
                            ej_MetalWeightMaster obj = objEntity.ej_MetalWeightMaster.Where(tbl => tbl.MetalWeightId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case SfmModel.PageName.SettingType:
                        {
                            ej_SettingType obj = objEntity.ej_SettingType.Where(tbl => tbl.SettingTypeId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case SfmModel.PageName.ChainStyle:
                        {
                            ej_ChainStyle obj = objEntity.ej_ChainStyle.Where(tbl => tbl.ChainStyleID == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case SfmModel.PageName.ChainLength:
                        {
                            ej_ChainLength obj = objEntity.ej_ChainLength.Where(tbl => tbl.ChainLengthID == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case SfmModel.PageName.CertificateCulet:
                        {
                            ej_CertificateCulet obj = objEntity.ej_CertificateCulet.Where(tbl => tbl.CertificateCuletId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case SfmModel.PageName.CertificateFlouresence:
                        {
                            ej_CertificateFlouresence obj = objEntity.ej_CertificateFlouresence.Where(tbl => tbl.CertificateFlouresenceId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case SfmModel.PageName.CertificateGridle:
                        {
                            ej_CertificateGridle obj = objEntity.ej_CertificateGridle.Where(tbl => tbl.CertificateGridleId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case SfmModel.PageName.CertificateLab:
                        {
                            ej_CertificationLab obj = objEntity.ej_CertificationLab.Where(tbl => tbl.CertificateLabId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case SfmModel.PageName.CertificatePolish:
                        {
                            ej_CertificatePolish obj = objEntity.ej_CertificatePolish.Where(tbl => tbl.CertificatePolishId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case SfmModel.PageName.CertificateSymmetry:
                        {
                            ej_CertificateSymmetry obj = objEntity.ej_CertificateSymmetry.Where(tbl => tbl.CertificateSymmetryId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case SfmModel.PageName.RingSize:
                        {
                            ej_RingSizeMaster obj = objEntity.ej_RingSizeMaster.Where(tbl => tbl.RingSizeId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case SfmModel.PageName.StoneShape:
                        {
                            ej_StoneShapeMaster obj = objEntity.ej_StoneShapeMaster.Where(tbl => tbl.ShapeId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case SfmModel.PageName.ShippingName:
                        {
                            ej_ShippingName obj = objEntity.ej_ShippingName.Where(tbl => tbl.ShippingNameId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case SfmModel.PageName.ShippingType:
                        {
                            ej_ShippingType obj = objEntity.ej_ShippingType.Where(tbl => tbl.ShippingTypeId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case SfmModel.PageName.NewsCategory:
                        {
                            ej_NewsCategory obj = objEntity.ej_NewsCategory.Where(tbl => tbl.NewsCategoryID == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case SfmModel.PageName.ChainClasp:
                        {
                            ej_ChainClasp obj = objEntity.ej_ChainClasp.Where(tbl => tbl.ChainClaspId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
                            }
                        }
                        break;
                    case SfmModel.PageName.AttributeTitle:
                        {
                            ej_AttributeTitle obj = objEntity.ej_AttributeTitle.Where(tbl => tbl.AttributeTitleId == id).FirstOrDefault();
                            if (obj != null)
                            {
                                objEntity.DeleteObject(obj);
                                objEntity.SaveChanges();
                                flag = true;
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
            return flag;
        }

    }
}
