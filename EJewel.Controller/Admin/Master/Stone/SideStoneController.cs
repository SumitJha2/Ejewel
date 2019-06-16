using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Common;
//dal
using EJewel.DAL.Admin.Master.Stone;
namespace EJewel.Controller.Admin.Master.Stone
{
    /// <summary>
    /// Manage the Side Stone Controller
    /// Partha Ranjan Nayak
    /// @ 01-04-13
    /// </summary>
    public class SideStoneController
    {
        SideStoneDAL objDAL = new SideStoneDAL();

        public SideStoneModel SaveUpdateSideStone(SideStoneModel model)
        {
            return objDAL.SaveUpdateSideStone(model);
        }

        public List<SideStoneModel> GetSideStoneList(long sideStoneId, CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetSideStoneList(sideStoneId, rStatus);
        }

        /*
        public List<SideStoneModel> GetSideStoneList(long sideStoneId, int pageindex, int pagesize, CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetSideStoneList(sideStoneId, rStatus).Skip(pageindex * pagesize).Take(pagesize).ToList();
            //return objDAL.GetSideStoneList(sideStoneId, rStatus);
        }
         * */

        public List<SideStoneModel> GetSideStoneListFromCategory(int stoneCategoryId, CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetSideStoneListFromCategory(stoneCategoryId, rStatus);
        }

        public List<SideStoneModel> GetSideStoneListFromCategory(int stoneCategoryId, double minCart, double maxCart, int[] stoneShapes, CommonModel.RecordStatus rStatus)
        {

            List<SideStoneModel> lstSideStone = objDAL.GetSideStoneListFromCategory(stoneCategoryId, rStatus);
            lstSideStone = (from sideStone in lstSideStone
                            where stoneShapes.Contains(sideStone.StoneShapeId) &&
                            sideStone.StoneCarate >= minCart && sideStone.StoneCarate <= maxCart
                            select sideStone).ToList();


            return lstSideStone;
        }

        /*sumit jha
         * @ 02-02-2013
         * */
        public bool DeleteSideStone(int sidestoneid)
        {
            return objDAL.DeleteSideStone(sidestoneid);
        }
        // sumit jha
        //@  13-05-2013
        // for stone type changes in view page

        public List<SideStoneModel> GetSideStoneListFromCategory_New(int stoneCategoryId, double minCart, double maxCart, int[] stoneShapes, CommonModel.RecordStatus rStatus)
        {
            List<SideStoneModel> lstSideStone = objDAL.GetSideStoneListForProductCreationFillter(stoneCategoryId, minCart, maxCart, stoneShapes, rStatus);
            switch (stoneCategoryId)
            {
                case 1:
                    {
                        //for diamonds

                    } break;
                case 2:
                    {
                        List<SideStoneModel> lstModel = new List<SideStoneModel>();
                        //for gemstone
                        var lstItem = lstSideStone.GroupBy(tbl => new { tbl.StoneShapeId, tbl.StoneCarate }).ToList();
                        //clear items
                        int total_item = lstItem.Count;
                        SideStoneModel model = null;
                        for (int i = 0; i < total_item; i++)
                        {
                            model = lstSideStone.Where(tbl => tbl.StoneShapeId == lstItem[i].Key.StoneShapeId && tbl.StoneCarate == lstItem[i].Key.StoneCarate).FirstOrDefault();
                            if (model != null)
                            {
                                lstModel.Add(model);
                            }
                        }
                        return lstModel;
                    }
            }
            return lstSideStone;
        }

        public List<SideStoneModel> GetSideStoneTypeForProductCreation(int stoneCategoryId, int stoneShapeid, double carat)
        {
            return objDAL.GetSideStoneTypeForProductCreation(stoneCategoryId, stoneShapeid, carat);
        }
    }
}
