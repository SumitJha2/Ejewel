using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Master.Setting;
using EJewel.Model.Admin.Common;
//dal
using EJewel.DAL.Admin.Master.Setting;
namespace EJewel.Controller.Admin.Master.Setting
{
    /*
     * Partha Ranjan
     * @ 22-01-13
     * This class manage all the details of the setting category
     * */
    public class CategorySettingTypeController
    {
        CategorySettingTypeDAL objDAL = new CategorySettingTypeDAL();

        /*
         * Partha 
         * 07-02-13
         * For save and update
         * */
        public CategorySettingTypeModel SaveUpdateCategorySettingType(CategorySettingTypeModel model)
        {
            return objDAL.SaveUpdateCategorySettingType(model);
        }
        /*
     * Partha Ranjan
     * 07-02-13
     * get categoru setting type
     * */
        public List<ListCategorySettingTypeModel> GetCategorySettingTypeList(int subCategorySettingTypeId, CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetCategorySettingTypeList(subCategorySettingTypeId, rStatus);
        }
        /*
     * Partha Ranjan
     * 07-02-13
     * get categoru setting type
     * */
        public List<ListCategorySettingTypeModel> GetCategorySettingTypeListFromSubCategory(int subcategoryId, CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetCategorySettingTypeListFromSubCategory(subcategoryId, rStatus);
        }

        public bool IsExistCategorySetting(int subcategoryId, int settingId)
        {
            return objDAL.IsExistCategorySetting(subcategoryId, settingId);
        }

        public bool DeleteCategorySettingType(int categorysettingtypeid)
        {
            return objDAL.DeleteCategorySettingType(categorysettingtypeid);
        }
    }
}
