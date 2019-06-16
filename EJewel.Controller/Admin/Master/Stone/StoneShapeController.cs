using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Master.Stone;
//dal
using EJewel.DAL.Admin.Master.Stone;

namespace EJewel.Controller.Admin.Master.Stone
{
    public class StoneShapeController
    {
        StoneShapeDAL objDAL = new StoneShapeDAL();

        public StoneShapeModel SaveUpdate(StoneShapeModel model)
        {
            return objDAL.SaveUpdate(model);
        }

        public List<StoneShapeModel> StoneShapeList(int stoneShapeId, StoneShapeModel.ShapeVisibility visibility, CommonModel.RecordStatus rStatus)
        {
            return objDAL.StoneShapeList(stoneShapeId, visibility, rStatus);
        }

        public List<StoneShapeModel> StoneShapeListFromCategory(int stoneCategoryId,StoneShapeModel.ShapeVisibility visibility, CommonModel.RecordStatus rStatus)
        {
            return objDAL.StoneShapeListFromCategory(stoneCategoryId, visibility, rStatus);
        }

        public bool IsExist(int stoneCategoryId, int shapeId)
        {
            return objDAL.IsExist(stoneCategoryId, shapeId);
        }

        public bool Delete(int stoneShapeId)
        {
            return objDAL.Delete(stoneShapeId);
        }

        /* sumit jha
         * @ 06-05-2013
         * */
        public List<StoneSpecificationModel> GetStoneShapeFromMaster(int shapeId, CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetStoneShapeFromMaster(shapeId, rStatus);
        }
    }
}
