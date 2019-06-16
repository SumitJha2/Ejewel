using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EJewel.Controller.Cart;
using EJewel.Model.Cart;
//
using EJewel.Controller.Admin.Product;
using EJewel.Model.Admin.Product;
//
using EJewel.Model.Admin.Master.Category;
using EJewel.Controller.Admin.Master.Category;
//
using EJewel.Controller.Admin.Common.Sfm;
using EJewel.Model.Admin.Common.Sfm;
//
using EJewel.Controller.Admin.Master.Metal;
using EJewel.Model.Admin.Master.Metal;
//
using EJewel.Model.Admin.Master.Stone;
using EJewel.Controller.Admin.Master.Stone;

namespace EJewel.UserView
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        CenterStoneController objCenterStoneController = new CenterStoneController();
        SideStoneController objSideStoneController = new SideStoneController();
        MetalTypeController objMetalTypeController = new MetalTypeController();
        SfmController objSfmController = new SfmController();
        CategoryController objCategoryController=new CategoryController();
        ProductDetailsController objProductDetailsController=new ProductDetailsController();
        public List<CartProductModel> _lstCartProduct = null;
        public double _SubTotal = 0;
        public List<SfmModel> _lstRingSize = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CartController.Instance != null)
            {
                _lstCartProduct = CartController.Instance.ProductItems;
                _SubTotal = CartController.Instance.GetSubTotal();
                //load ring size
                this.LoadRingSize();
            }
            else
            {
                //error page
            }
        }

        void LoadRingSize()
        {
            try
            {
                _lstRingSize = objSfmController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.RingSize);
            }
            catch(Exception ex)
            {
                
            }
        }

        public ProductDetailsModel ProductDetailsFromSKU(long productId)
        {
            return objProductDetailsController.GetProductList(productId).FirstOrDefault();
        }

        public SubCategoryModel SubCategoryDetails(int subcategoryId)
        {
           return objCategoryController.GetSubCategoryList(subcategoryId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
        }

        public List<SfmModel> RingSizeSource()
        {
            return _lstRingSize;
        }

        public MetalTypeListModel MetalTypeInfo(int metalTypeid)
        {
            return objMetalTypeController.GetMetalTypeList(metalTypeid, CommonModel.RecordStatus.Enabled).FirstOrDefault();
        }
        public SideStoneModel SideStoneInfo(long sideStoneid)
        {
            return objSideStoneController.GetSideStoneList(sideStoneid, CommonModel.RecordStatus.Enabled).FirstOrDefault();
        }

        public CenterStoneModel CenterStoneInfo(string centerStoneSKU)
        {
            return objCenterStoneController.GetCenterStoneDetailsFromSKU(centerStoneSKU);
        }
    }
}