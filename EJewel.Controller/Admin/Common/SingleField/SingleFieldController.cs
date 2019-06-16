using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Common.SingleField;
//dal
using EJewel.DAL.Admin.Common.SingleField;

namespace EJewel.Controller.Admin.Common.SingleField
{
    /// <summary>
    /// 
    /// </summary>
    
    public class SingleFieldController
    {
        SingleFieldDAL objDAL = new SingleFieldDAL();
        public string HeadingName = "";

        public SingleFieldModel SaveUpdateSingleField(SingleFieldModel model,SingleFieldModel.PageName pageName)
        {
            return objDAL.SaveUpdateSingeField(model, pageName);
        }

        public bool DeleteSingleField(SingleFieldModel model)
        {
            return true;
        }

        public List<SingleFieldModel> GetSingleFieldList(int id,CommonModel.RecordStatus status,SingleFieldModel.PageName pageName)
        {
            return objDAL.GetSingleFieldList(id, status, pageName);
        }

        public bool IsExsit(string name, SingleFieldModel.PageName pageName)
        {
            return objDAL.IsExist(name, pageName);
        }

        public SingleFieldModel.PageName GetPageView(string viewName)
        {
            SingleFieldModel.PageName pageName = SingleFieldModel.PageName.None;
            switch (viewName)
            {
                case "metal_weight":
                    {
                        pageName = SingleFieldModel.PageName.MetalWeightMaster;
                        HeadingName = "Metal Weight";
                    }break;
                case "metal_name":
                    {
                        pageName = SingleFieldModel.PageName.MetalNameMaster;
                        HeadingName = "Metal Name";
                    } break;
                case "unit_master":
                    {
                        pageName = SingleFieldModel.PageName.UnitMaster;
                        HeadingName = "Unit Master";
                    } break;
                case "setting_type":
                    {
                        pageName = SingleFieldModel.PageName.SettingType;
                        HeadingName = "Setting Type Master";
                    } break;
                default:
                    {
                        pageName = SingleFieldModel.PageName.None;
                    }
                    break;
            }
            return pageName;
        }

        public bool DeleteSingleField(int id, SingleFieldModel.PageName pageName)
        {
            return objDAL.DeleteSingleField(id, pageName);
        }

    }
}
