using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Master.Setting;
using EJewel.Model.Admin.Common;
//
namespace EJewel.DAL.Admin.Master.Setting
{
    /// <summary>
    /// Mange the price of the setting
    /// setting price and setter price
    /// </summary>
    public class PriceDAL
    {
        EJewelEntities objEntity = new EJewelEntities();

        /// <summary>
        /// Save and update the price of setting & setter
        /// </summary>
        /// <param name="model">price model</param>
        /// <param name="pgName">page name</param>
        /// <returns>price model</returns>
        public PriceModel SaveUpdatePrice(PriceModel model, PriceModel.PageName pgName)
        {
            try
            {
                if (model.AutoID == 0)
                {
                    #region For Save Mode
                    //for save
                    if (!this.IsExist(model.SubCategoryId, pgName))
                    {
                        switch (pgName)
                        {
                            case PriceModel.PageName.SetterPrice:
                                {
                                    ej_SetterPrice obj = (ej_SetterPrice)this.Mapping(model, pgName);
                                    if (obj != null)
                                    {
                                        objEntity.AddToej_SetterPrice(obj);
                                        objEntity.SaveChanges();
                                        model.AutoID = obj.SetterPriceId;
                                    }
                                }
                                break;
                            case PriceModel.PageName.SettingPrice:
                                {
                                    ej_SettingPrice obj = (ej_SettingPrice)this.Mapping(model, pgName);
                                    if (obj != null)
                                    {
                                        objEntity.AddToej_SettingPrice(obj);
                                        objEntity.SaveChanges();
                                        model.AutoID = obj.SettingPriceId;
                                    }
                                }
                                break;
                        }

                    }
                    #endregion
                }
                else
                {
                    #region For Update Mode
                    switch (pgName)
                    {
                        case PriceModel.PageName.SetterPrice:
                            {
                                ej_SetterPrice obj = objEntity.ej_SetterPrice.Where(tbl => tbl.SetterPriceId == model.AutoID).FirstOrDefault();
                                if (obj != null)
                                {
                                    obj.Price = model.Price;
                                    obj.Status = model.Status;
                                    objEntity.SaveChanges();
                                }
                            }
                            break;
                        case PriceModel.PageName.SettingPrice:
                            {
                                ej_SettingPrice obj = objEntity.ej_SettingPrice.Where(tbl => tbl.SettingPriceId == model.AutoID).FirstOrDefault();
                                if (obj != null)
                                {
                                    obj.Price = model.Price;
                                    obj.Status = model.Status;
                                    objEntity.SaveChanges();
                                }
                            }
                            break;
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

        /// <summary>
        /// Check that the price category is present or not
        /// </summary>
        /// <param name="subcategoryId">sub category</param>
        /// <param name="pgName">page name</param>
        /// <returns>boolean</returns>
        public bool IsExist(int subcategoryId, PriceModel.PageName pgName)
        {
            try
            {
                switch (pgName)
                {
                    case PriceModel.PageName.SetterPrice:
                        {
                            return objEntity.ej_SetterPrice.Where(tbl => tbl.SubCategoryId == subcategoryId).Any();
                        }
                        break;
                    case PriceModel.PageName.SettingPrice:
                        {
                            return objEntity.ej_SettingPrice.Where(tbl => tbl.SubCategoryId == subcategoryId).Any();
                        }
                        break;
                }
                return false;
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
            return true;

        }

        /// <summary>
        /// Mapping the model to entity
        /// </summary>
        /// <param name="model">model</param>
        /// <param name="pgName">page name</param>
        /// <returns>entity object</returns>
        private object Mapping(PriceModel model, PriceModel.PageName pgName)
        {
            try
            {
                if (model != null)
                {
                    switch (pgName)
                    {
                        case PriceModel.PageName.SetterPrice:
                            {
                                return new ej_SetterPrice()
                                {
                                    SetterPriceId = model.AutoID,
                                    Status = model.Status,
                                    SubCategoryId = model.SubCategoryId,
                                    Price = model.Price
                                };
                            }
                            break;
                        case PriceModel.PageName.SettingPrice:
                            {
                                return new ej_SettingPrice()
                                {
                                    SettingPriceId = model.AutoID,
                                    Status = model.Status,
                                    SubCategoryId = model.SubCategoryId,
                                    Price = model.Price
                                };
                            }
                            break;
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
            return null;
        }

        /// <summary>
        /// Get orice list from price id
        /// </summary>
        /// <param name="priceID">price id</param>
        /// <param name="rStatus">record status</param>
        /// <param name="pgName">page name</param>
        /// <returns>collection of price list</returns>
        public List<PriceModel> GetPriceList(int priceID, CommonModel.RecordStatus rStatus, PriceModel.PageName pgName)
        {
            try
            {
                //create model list
                List<PriceModel> lstModel = new List<PriceModel>();
                //create null object of enity
                List<ej_SetterPrice> lstSetterPrice = null;
                List<ej_SettingPrice> lstSettingPrice = null;
                switch (pgName)
                {
                    #region Setter Price
                    case PriceModel.PageName.SetterPrice:
                        {
                            if (priceID > 0)
                            {
                                lstSetterPrice = objEntity.ej_SetterPrice.Where(tbl => tbl.SetterPriceId == priceID).ToList();
                            }
                            else
                            {
                                lstSetterPrice = objEntity.ej_SetterPrice.Select(tbl => tbl).ToList();
                            }
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstSetterPrice = lstSetterPrice.Where(tbl => tbl.Status == true).ToList();
                            }
                            //get the value from the setter
                            if (lstSetterPrice != null)
                            {
                                lstModel = this.GetPriceListFromSetter(lstSetterPrice);
                            }
                        }
                        break;
                    #endregion

                    #region Setting Price
                    case PriceModel.PageName.SettingPrice:
                        {
                            if (priceID > 0)
                            {
                                lstSettingPrice = objEntity.ej_SettingPrice.Where(tbl => tbl.SettingPriceId == priceID).ToList();
                            }
                            else
                            {
                                lstSettingPrice = objEntity.ej_SettingPrice.Select(tbl => tbl).ToList();
                            }
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstSettingPrice = lstSettingPrice.Where(tbl => tbl.Status == true).ToList();
                            }
                            //get the value from the setting price
                            if (lstSettingPrice != null)
                            {
                                lstModel = this.GetPriceListFromSetting(lstSettingPrice);
                            }
                        }
                        break;
                    #endregion
                }
                return lstModel;
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

        /// <summary>
        /// Get the price details from the sub category
        /// </summary>
        /// <param name="subCategoryId">subcategory id</param>
        /// <param name="rStatus">record status</param>
        /// <param name="pgName">page name</param>
        /// <returns>collection of price</returns>
        public List<PriceModel> GetPriceListFromSubCategory(int subCategoryId, CommonModel.RecordStatus rStatus, PriceModel.PageName pgName)
        {
            //create model list
            List<PriceModel> lstModel = new List<PriceModel>();
            try
            {
                //create null object of enity
                List<ej_SetterPrice> lstSetterPrice = null;
                List<ej_SettingPrice> lstSettingPrice = null;
                switch (pgName)
                {
                    #region Setter Price
                    case PriceModel.PageName.SetterPrice:
                        {
                            lstSetterPrice = objEntity.ej_SetterPrice.Where(tbl => tbl.SubCategoryId == subCategoryId).ToList();
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstSetterPrice = lstSetterPrice.Where(tbl => tbl.Status == true).ToList();
                            }
                            //get the value from the setter
                            if (lstSetterPrice != null)
                            {
                                lstModel = this.GetPriceListFromSetter(lstSetterPrice);
                            }
                        }
                        break;
                    #endregion

                    #region Setting Price
                    case PriceModel.PageName.SettingPrice:
                        {
                            lstSettingPrice = objEntity.ej_SettingPrice.Where(tbl => tbl.SubCategoryId == subCategoryId).ToList();
                            if (rStatus == CommonModel.RecordStatus.Enabled)
                            {
                                lstSettingPrice = lstSettingPrice.Where(tbl => tbl.Status == true).ToList();
                            }
                            //get the value from the setting price
                            if (lstSettingPrice != null)
                            {
                                lstModel = this.GetPriceListFromSetting(lstSettingPrice);
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
            return lstModel;
        }

        /// <summary>
        /// Get the price list from setter
        /// </summary>
        /// <param name="lstSetterPrice">list of setter price</param>
        /// <returns>collection of price model</returns>
        private List<PriceModel> GetPriceListFromSetter(List<ej_SetterPrice> lstSetterPrice)
        {
            try
            {
                if (lstSetterPrice != null)
                {
                    return (from setterPrice in lstSetterPrice
                            join subCategory in objEntity.ej_SubCategoryMaster
                            on setterPrice.SubCategoryId equals subCategory.SubCategoryId
                            where subCategory.Status == true
                            select new PriceModel()
                            {
                                AutoID = setterPrice.SetterPriceId,
                                Price = setterPrice.Price,
                                Status = setterPrice.Status,
                                SubCategory = subCategory.SubCategoryName,
                                SubCategoryId = subCategory.SubCategoryId
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
            return new List<PriceModel>();
        }

        /// <summary>
        /// Get the price list from setting
        /// </summary>
        /// <param name="lstSettingPrice">list of setter price</param>
        /// <returns>collection of price model</returns>
        private List<PriceModel> GetPriceListFromSetting(List<ej_SettingPrice> lstSettingPrice)
        {
            try
            {
                if (lstSettingPrice != null)
                {
                    return (from settingPrice in lstSettingPrice
                            join subCategory in objEntity.ej_SubCategoryMaster
                            on settingPrice.SubCategoryId equals subCategory.SubCategoryId
                            where subCategory.Status == true
                            select new PriceModel()
                            {
                                AutoID = settingPrice.SettingPriceId,
                                Price = settingPrice.Price,
                                Status = settingPrice.Status,
                                SubCategory = subCategory.SubCategoryName,
                                SubCategoryId = subCategory.SubCategoryId
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
            return new List<PriceModel>();
        }
    }
}
