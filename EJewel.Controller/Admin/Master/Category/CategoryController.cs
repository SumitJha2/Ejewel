using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL.Admin.Master.Category;
using EJewel.Model.Admin.Master.Category;
using EJewel.Model.Admin.Common;

namespace EJewel.Controller.Admin.Master.Category
{
    public class CategoryController
    {
        CategoryDAL objDAL = new CategoryDAL();

        #region Primary Category
        public List<PrimaryCategoryModel> GetPrimaryCategoryList(int categoryid, CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetPrimaryCategoryList(categoryid, rStatus);
        }
        #endregion

        #region Sub Category
        public SubCategoryModel SaveUpdateSubCategory(SubCategoryModel model)
        {
            return objDAL.SaveUpdateSubCategory(model);
        }
        public bool IsExistSubCategory(int categoryId, string subCategoryName)
        {
            return objDAL.IsExistSubCategory(categoryId, subCategoryName);
        }
        public bool DeleteSubCategory(int subCategoryId)
        {
            return objDAL.DeleteSubCategory(subCategoryId);
        }
        public List<SubCategoryModel> GetSubCategoryList(int subCategoryId, CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetSubCategoryList(subCategoryId, rStatus);
        }
        //
        public List<SubCategoryModel> GetSubCategoryListFromCategory(int categoryID, CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetSubCategoryListFromCategory(categoryID, rStatus);
        }

        public List<ProductCategoryModel> GetProductCategoryList()
        {
            return objDAL.GetProductCategoryList();
        }
        /* sumit jha
         * @ 18-03-2013
         * */

        public List<SubCategoryModel> GetSubCategoryList(int subCategoryId,int pageindex,int pagesize ,CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetSubCategoryList(subCategoryId,pageindex,pagesize,rStatus);
        }
        /* sumit jha
        * @ 18-03-2013
        * */

        public int TotalNoOfSubCategory(int subCategoryId, CommonModel.RecordStatus rStatus)
        {
            return objDAL.TotalNoOfSubCategory(subCategoryId, rStatus);
        }

        public void UpdateHasRing(int subCategoryId, bool hasRingStatus,bool hasengraving)
        {
            objDAL.UpdateHasRing(subCategoryId, hasRingStatus, hasengraving);
        }
        #endregion

    }
}
