using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL.Admin.Master.Stone;
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Common;
//
namespace EJewel.Controller.Admin.Master.Stone
{
   public class StoneController
    {
        StoneDAL objDAL = new StoneDAL();

        public StoneModel SaveUpdateStone(StoneModel model)
        {
            return objDAL.SaveUpdateStone(model);
        }

        public bool ExistSKU(string sku)
        {
            return objDAL.ExistSKU(sku);
        }

        public bool DeleteStone(long stoneID)
        {
            return objDAL.DeleteStone(stoneID);
        }

        public List<StoneModel> GetProductStoneTypeList(int stoneCategoryID, int stoneCategoryTypeID, double minCt, double maxCt,int [] shapes)
        {
            return objDAL.GetProductStoneTypeList(stoneCategoryID, stoneCategoryTypeID, minCt, maxCt,shapes);
        }
        public List<StoneModel> GetStoneList(long stoneId,CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetStoneList(stoneId, rStatus);
        }
        public List<StoneModel> GetStoneList(long stoneId,int pageindex, int pagesize,CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetStoneList(stoneId,pageindex, pagesize, rStatus);
        }
        /* sumit jha
        * @ 15-03-2013
        * */
        public int TotalNoOfStone(long stoneId, CommonModel.RecordStatus rStatus)
        {
            return objDAL.TotalNoOfStone(stoneId,rStatus);
        }



    }
}
