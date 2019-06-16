using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL.Admin.Master.Metal;
using EJewel.Model.Admin.Master.Metal;
//model
using EJewel.Model.Admin.Master.Setting;
using EJewel.Model.Admin.Common;
//dal
using EJewel.DAL.Admin.Master.Setting;

namespace EJewel.Controller.Admin.Master.Setting
{
   public class RingSizeController
    {

       RingSizeDAL objDAL = new RingSizeDAL();

       public RingSizeModel SaveUpdateRingSize(RingSizeModel ringSize)
        {
            return objDAL.SaveUpdateRingSize(ringSize);
        }

       public bool IsExist(int subcategoryId, double ringRize)
       {
           return objDAL.IsExist(subcategoryId, ringRize);
       }

       public List<RingSizeModel> GetRingSizeList(int ringSizeId, CommonModel.RecordStatus rStatus)
       {
           return objDAL.GetRingSizeList(ringSizeId, rStatus);
       }

       public bool DeleteRingSize(int ringsizeid)
       {
           return objDAL.DeleteRingSize(ringsizeid);
       }
    }
}
