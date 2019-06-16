using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.DAL.Admin.Master.Setting;
using EJewel.Model.Admin.Common;
//dal
using EJewel.Model.Admin.Master.Setting;
namespace EJewel.Controller.Admin.Master.Setting
{
    public class StoneCategorySettingTypeController
    {
        StoneCategorySettingTypeDAL objDAL = new StoneCategorySettingTypeDAL();

        public StoneCategorySettingTypeModel SaveUpdateStoneCategorySettingType(StoneCategorySettingTypeModel model)
        {
            return objDAL.SaveUpdateStoneCategorySettingType(model);
        }

        public List<StoneCategorySettingTypeModel> StoneSettingTypeList(int stoneCategorySettingTypeId, CommonModel.RecordStatus rStatus)
        {
            return objDAL.StoneSettingTypeList(stoneCategorySettingTypeId, rStatus);
        }

        public List<StoneCategorySettingTypeModel> StoneSettingTypeListFromStoneCategoryType(int stoneCategoryTypeId, CommonModel.RecordStatus rStatus)
        {
            return objDAL.StoneSettingTypeListFromStoneCategoryType(stoneCategoryTypeId, rStatus);
        }

        public bool DeleteStoneSettingType(int stonecategorysettingtypeid)
        {
            return objDAL.DeleteStoneSettingType(stonecategorysettingtypeid);
        }

        public bool IsExist(int stoneCategoryTypeId, int stoneSettingTypeId)
        {
            return objDAL.IsExist(stoneCategoryTypeId, stoneSettingTypeId);
        }
    }
         
   
}
