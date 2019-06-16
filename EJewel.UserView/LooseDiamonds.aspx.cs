using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Product;
using EJewel.Controller.Admin.Master.Stone;
namespace EJewel.UserView
{
    public partial class LooseDiamonds : System.Web.UI.Page
    {
        CenterStoneController objCenterStoneController = new CenterStoneController();
        public StoneSpecificationController objStoneSpecificationController = new StoneSpecificationController();
        public double _MINPRICE, _MAXPRICE, _MINCARAT, _MAXCARAT, _MINTABLE, _MAXTABLE, _MINDEPTH, _MAXDEPTH;
        public string _DEFSHAPE;
        protected void Page_Load(object sender, EventArgs e)
        {
            _DEFSHAPE = Convert.ToString(Page.RouteData.Values["shape_name"]).ToLower();
            //get center stone details
            CenterstoneMinMaxRangeModel rangeModel = objCenterStoneController.GetCenterStoneMinMaxRange();
            if (rangeModel != null)
            {
                //price
                _MINPRICE = rangeModel.MinPrice;
                _MAXPRICE = rangeModel.MaxPrice;
                //carat
                _MINCARAT = rangeModel.MinCarat;
                _MAXCARAT = rangeModel.MaxCarat;
                //table
                _MINTABLE = rangeModel.MinTable;
                _MAXTABLE = rangeModel.MaxTable;
                //depth
                _MINDEPTH = rangeModel.MinDepth;
                _MAXDEPTH = rangeModel.MaxDepth;
            }
        }

        public List<StoneSpecificationModel> GetStoneSpecificationList(StoneSpecificationModel.PageName pageName)
        {
            return objStoneSpecificationController.GetStoneSpecificationListFromCategory(ConstantHelper.STONE_CATEGORY_DIAMOND, pageName, CommonModel.RecordStatus.Enabled).OrderBy(tbl => tbl.Name).ToList();
        }

        public List<StoneShapeModel> GetStoneShapeList()
        {
            return new StoneShapeController().StoneShapeListFromCategory(ConstantHelper.STONE_CATEGORY_DIAMOND,StoneShapeModel.ShapeVisibility.CENTERSTONE, CommonModel.RecordStatus.Enabled).OrderBy(tbl => tbl.Shape).ToList();
        }
    }
}