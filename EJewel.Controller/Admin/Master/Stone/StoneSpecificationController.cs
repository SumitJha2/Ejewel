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
    /*
     * Partha Ranjan
     * @ 09-02-13
     * This class manage the cut, clarity and type of the diamonds and gem stone
     * */
    public class StoneSpecificationController
    {
        StoneSpecificationDAL objDAL = new StoneSpecificationDAL();
        private string _headingName;
        //get the page name
        public StoneSpecificationModel.PageName GetPageName(string pageName)
        {
            StoneSpecificationModel.PageName pName = StoneSpecificationModel.PageName.None;
            switch (pageName)
            {
                case "cut":
                    {
                        pName = StoneSpecificationModel.PageName.Cut;
                        this.Heading = "Stone Cut";
                    }
                    break;
                case "clarity":
                    {
                        pName = StoneSpecificationModel.PageName.Clarity;
                        this.Heading = "Stone Clarity";
                    }
                    break;
                case "color":
                    {
                        pName = StoneSpecificationModel.PageName.Color;
                        this.Heading = "Stone Color";
                    }
                    break;
                case "type":
                    {
                        pName = StoneSpecificationModel.PageName.Type;
                        this.Heading = "Stone Type";
                    }
                    break;
                default:
                    {
                        pName = StoneSpecificationModel.PageName.None;
                    }
                    break;
            }
            return pName;
        }

        public string Heading
        {
            private set { _headingName = value; }
            get { return _headingName; }
        }

        public StoneSpecificationModel SaveUpdateStoneSpecification(StoneSpecificationModel model,StoneSpecificationModel.PageName pageName)
        {
            return objDAL.SaveUpdateStoneSpecification(model, pageName);
        }

        public bool IsExist(int categoryID,string  name,StoneSpecificationModel.PageName pageName)
        {
            return objDAL.IsExist(categoryID, name, pageName);
        }

        public int TotalRecord(StoneSpecificationModel.PageName pageName)
        {
            return objDAL.TotalRecord(pageName);
        }

        public List<StoneSpecificationModel> GetStoneSpecificationList(int id,StoneSpecificationModel.PageName pageName, CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetStoneSpecificationList(id, pageName, rStatus);
        }

        public List<StoneSpecificationModel> GetStoneSpecificationListForShape(int stoneShapeId,StoneShapeModel.ShapeVisibility visibility,CommonModel.RecordStatus rStatus)
        {
            List<StoneSpecificationModel> lstModel = new List<StoneSpecificationModel>();
            StoneShapeController cont = new StoneShapeController();
            List<StoneShapeModel> lstShapeModel = cont.StoneShapeList(stoneShapeId,visibility, rStatus);
            if(lstShapeModel!=null && lstShapeModel.Count>0)
            {
                lstModel = (from stoneShape in lstShapeModel
                            select new StoneSpecificationModel()
                            {
                                AutoID = stoneShape.StoneShapeId,
                                Name = stoneShape.Shape,
                                Status = stoneShape.Status,
                                StoneCategoryId = stoneShape.StoneCategoryId
                            }).ToList();

            }
            return lstModel;

        }
        //GetStoneSpecificationList

        public List<StoneSpecificationModel> GetStoneSpecificationList(int id, StoneSpecificationModel.PageName pageName, CommonModel.RecordStatus rStatus, int currentPageIndex, int perPageSize)
        {
            return objDAL.GetStoneSpecificationList(id, pageName, rStatus,currentPageIndex,perPageSize);
        }

        public List<StoneSpecificationModel> GetStoneSpecificationListFromCategory(int categoryID, StoneSpecificationModel.PageName pageName, CommonModel.RecordStatus rStatus)
        {
            return objDAL.GetStoneSpecificationListFromCategory(categoryID, pageName, rStatus);
        }
          /* sumit jha
         * @ 19-03-2013
         * */
        public bool DeleteStoneSpecification(int id, StoneSpecificationModel.PageName pName)
        {
            return objDAL.DeleteStoneSpecification(id, pName);
        }

    }
}
