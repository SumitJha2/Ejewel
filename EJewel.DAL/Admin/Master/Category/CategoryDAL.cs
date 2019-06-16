using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Category;
using EJewel.Model.Admin.Common;
namespace EJewel.DAL.Admin.Master.Category
{
    /*
     * Partha Ranjan
     * January 2013
     * */
    public class CategoryDAL
    {
        EJewelEntities objEntity = new EJewelEntities();

        #region Sub Category

        /*
         * Partha Ranjan
         * @ 04-02-13
         * This function save update sub category
         * */
        public SubCategoryModel SaveUpdateSubCategory(SubCategoryModel model)
        {
            try
            {
                if (model.SubCategoryId > 0)
                {
                    ej_SubCategoryMaster objSubCategory = objEntity.ej_SubCategoryMaster.Where(tbl => tbl.SubCategoryId == model.SubCategoryId).FirstOrDefault();
                    if (objSubCategory != null)
                    {
                        //check that the sub category is present or not
                        if (objSubCategory.SubCategoryName != model.SubCategoryName)
                        {
                            objSubCategory.SubCategoryName = model.SubCategoryName;
                        }
                        //category
                        objSubCategory.CategoryId = model.CategoryId;
                        //seo
                        objSubCategory.PageTitle = model.PageTitle;
                        objSubCategory.MetaDescription = model.MetaDescription;
                        objSubCategory.MetaKeywords = model.MetaKeywords;
                        //info
                        objSubCategory.ModifiedBy = model.ModifiedBy;
                        objSubCategory.ModifiedDate = model.ModifiedDate;
                        objSubCategory.Status = model.Status;
                        objEntity.SaveChanges();
                    }
                }
                else
                {
                    ej_SubCategoryMaster objSubCategory = new ej_SubCategoryMaster()
                    {
                        CategoryId = model.CategoryId,
                        CreateBy = model.CreateBy,
                        CreateDate = model.CreateDate,
                        MetaDescription = model.MetaDescription,
                        MetaKeywords = model.MetaKeywords,
                        ModifiedBy = model.ModifiedBy,
                        ModifiedDate = model.ModifiedDate,
                        PageTitle = model.PageTitle,
                        Status = model.Status,
                        SubCategoryId = model.SubCategoryId,
                        SubCategoryName = model.SubCategoryName,
                        HasRing = false,
                        HasEngraving = false
                    };
                    objEntity.AddToej_SubCategoryMaster(objSubCategory);
                    objEntity.SaveChanges();
                    model.SubCategoryId = objSubCategory.SubCategoryId;
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

        public void UpdateHasRing(int subCategoryId,bool hasRingStatus,bool hasEngraving)
        {
            try
            {
                ej_SubCategoryMaster objSubCategory = objEntity.ej_SubCategoryMaster.Where(tbl => tbl.SubCategoryId == subCategoryId).FirstOrDefault();
                if (objSubCategory != null)
                {
                    objSubCategory.HasRing = hasRingStatus;
                    objSubCategory.HasEngraving = hasEngraving;
                    objEntity.SaveChanges();
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
        /* Partha Ranjan
         * @ 04-02-13
         * Delete the sub category
         * */
        public bool DeleteSubCategory(int subCategoryId)
        {
            try
            {
                ej_SubCategoryMaster objSubCategory = objEntity.ej_SubCategoryMaster.Where(tbl => tbl.SubCategoryId == subCategoryId).FirstOrDefault();
                if (objSubCategory != null)
                {
                    objEntity.DeleteObject(objSubCategory);
                    objEntity.SaveChanges();
                    return true;
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
            return false;
        }

        /* Partha Ranjan
         * @ 04-02-13
         * Check that the sub category present or not
         * */
        public bool IsExistSubCategory(int categoryId, string subCategoryName)
        {
            try
            {
                return objEntity.ej_SubCategoryMaster.Where(tbl => tbl.CategoryId == categoryId && tbl.SubCategoryName == subCategoryName).Any();
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

        /*
         * Partha Ranjan
         * @ 04-02-13
         * get sub category details
         * */
        public List<SubCategoryModel> GetSubCategoryList(int subCategoryId, CommonModel.RecordStatus rStatus)
        {
            List<SubCategoryModel> lstModel = new List<SubCategoryModel>();
            try
            {
                List<ej_SubCategoryMaster> lstSubCategory = null;
                if (subCategoryId > 0)
                {
                    lstSubCategory = objEntity.ej_SubCategoryMaster.Where(tbl => tbl.SubCategoryId == subCategoryId).ToList();
                }
                else
                {
                    lstSubCategory = objEntity.ej_SubCategoryMaster.Select(tbl => tbl).ToList();
                }
                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstSubCategory = lstSubCategory.Where(tbl => tbl.Status == true).ToList();
                }
                //
                if (lstSubCategory != null)
                {
                    lstModel = this.GetSubCategoryList(lstSubCategory);
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

        /*
         * Partha Ranjan Nayak
         * @ 03-04-13
         * For Get the sub category name from the name
         * */
        public SubCategoryModel GetSubCategoryFromName(string sub_category, CommonModel.RecordStatus rStatus)
        {
            SubCategoryModel model = null;
            try
            {
                List<ej_SubCategoryMaster> lstSubCategory = null;
                lstSubCategory = objEntity.ej_SubCategoryMaster.Where(tbl => tbl.SubCategoryName == sub_category).ToList();
                //status
                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstSubCategory = lstSubCategory.Where(tbl => tbl.Status == true).ToList();
                }
                //
                if (lstSubCategory != null)
                {
                    model = this.GetSubCategoryList(lstSubCategory).FirstOrDefault();
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

        public List<SubCategoryModel> GetSubCategoryListFromCategory(int categoryId, CommonModel.RecordStatus rStatus)
        {
            List<SubCategoryModel> lstModel = new List<SubCategoryModel>();
            try
            {
                List<ej_SubCategoryMaster> lstSubCategory = null;
                lstSubCategory = objEntity.ej_SubCategoryMaster.Where(tbl => tbl.CategoryId == categoryId).ToList();
                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstSubCategory = lstSubCategory.Where(tbl => tbl.Status == true).ToList();
                }
                //
                if (lstSubCategory != null)
                {
                    lstModel = this.GetSubCategoryList(lstSubCategory);
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

        private List<SubCategoryModel> GetSubCategoryList(List<ej_SubCategoryMaster> objSubCategory)
        {
            try
            {
                List<SubCategoryModel> lstSubCategoryModel = (from subcat in objSubCategory
                                                              join cat in objEntity.ej_PrimaryCategory
                                                              on subcat.CategoryId equals cat.CategoryId
                                                              where cat.Status == true
                                                              select new SubCategoryModel
                                                              {
                                                                  SubCategoryId = subcat.SubCategoryId,
                                                                  SubCategoryName = subcat.SubCategoryName,
                                                                  PageTitle = subcat.PageTitle,
                                                                  MetaDescription = subcat.MetaDescription,
                                                                  MetaKeywords = subcat.MetaKeywords,
                                                                  CategoryId = cat.CategoryId,
                                                                  CategoryName = cat.CategoryName,
                                                                  Status = subcat.Status,
                                                                  HasRing = subcat.HasRing,
                                                                  HasEngraving = subcat.HasEngraving

                                                              }).OrderByDescending(sc => sc.SubCategoryId).ToList();
                return lstSubCategoryModel;
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
         * @ 18-03-2013
         * */
        public List<SubCategoryModel> GetSubCategoryList(int subCategoryId,int pageindex,int pagesize,CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<SubCategoryModel> lstModel = GetSubCategoryList(subCategoryId, rStatus).Skip(pageindex * pagesize).Take(pagesize).ToList();
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
        /* sumit jha
          * @ 18-03-2013
         * */
        public int TotalNoOfSubCategory(int subCategoryId, CommonModel.RecordStatus rstatus)
        {
            int count = 0;
            try
            {

                List<SubCategoryModel> lstModel = GetSubCategoryList(subCategoryId, rstatus);
                count = lstModel.Count();
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
            return count;
        }

        #endregion

        #region Primary Category

        /*
         * Partha
         * @ 04-02-13
         * This function get the details of the primary category details
         * */
        public List<PrimaryCategoryModel> GetPrimaryCategoryList(int categoryId, CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<PrimaryCategoryModel> lstModel = new List<PrimaryCategoryModel>();
                List<ej_PrimaryCategory> lstCategory = null;
                if (categoryId > 0)
                {
                    lstCategory = objEntity.ej_PrimaryCategory.Where(tbl => tbl.CategoryId == categoryId).ToList();
                }
                else
                {
                    lstCategory = objEntity.ej_PrimaryCategory.Select(tbl => tbl).ToList();
                }
                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstCategory = lstCategory.Where(tbl => tbl.Status == true).ToList();
                }
                return this.GetPrimaryCategoryList(lstCategory);
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

        private List<PrimaryCategoryModel> GetPrimaryCategoryList(List<ej_PrimaryCategory> lstPrimaryCategory)
        {
            List<PrimaryCategoryModel> lstModel = new List<PrimaryCategoryModel>();
            try
            {
                if (lstPrimaryCategory != null)
                {
                    if (lstPrimaryCategory != null)
                    {
                        lstModel = (from category in lstPrimaryCategory
                                    select new PrimaryCategoryModel()
                                    {
                                        CategoryId = category.CategoryId,
                                        CategoryName = category.CategoryName,
                                        MetaDescription = category.MetaDescription,
                                        MetaKeyword = category.MetaKeyword,
                                        PageTitle = category.PageTitle,
                                        Status = category.Status
                                    }).OrderByDescending(tbl => tbl.CategoryName).ToList();
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
            return lstModel;
        }

        public PrimaryCategoryModel GetPrimaryCategoryFromName(string primary_category, CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<ej_PrimaryCategory> lstPrimaryCategory = null;
                lstPrimaryCategory = objEntity.ej_PrimaryCategory.Where(tbl => tbl.CategoryName == primary_category).ToList();
                //status
                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstPrimaryCategory = lstPrimaryCategory.Where(tbl => tbl.Status == true).ToList();
                }
                return this.GetPrimaryCategoryList(lstPrimaryCategory).FirstOrDefault();
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
        #endregion

        #region Product Category
        /*
         * Partha Ranjan
         * @ 06-02-13
         * This function bind the product category
         * */
        public List<ProductCategoryModel> GetProductCategoryList()
        {
            
            List<ProductCategoryModel> lstModel = new List<ProductCategoryModel>();
            try
            {
                //get category
                List<PrimaryCategoryModel> lstCategoryModel = this.GetPrimaryCategoryList(0, CommonModel.RecordStatus.Enabled).OrderBy(tbl => tbl.CategoryName).ToList();

                foreach (PrimaryCategoryModel primaryCategory in lstCategoryModel)
                {
                    //get sub category
                    List<SubCategoryModel> lstSubCategoryModel = this.GetSubCategoryListFromCategory(primaryCategory.CategoryId, CommonModel.RecordStatus.Enabled).OrderBy(tbl => tbl.SubCategoryName).ToList();
                    foreach (SubCategoryModel subCategory in lstSubCategoryModel)
                    {
                        lstModel.Add(new ProductCategoryModel()
                        {
                            CategoryID = subCategory.SubCategoryId,
                            CategoryName = primaryCategory.CategoryName + " » " + subCategory.SubCategoryName
                        });
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
            return lstModel;
        }
        #endregion
    }
}
