using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//access the product video id
using EJewel.Model.Admin.Product;
using EJewel.Controller.Admin.Product;

namespace EJewel.AdminView.Product
{
    public partial class ProductVideoPlayer : System.Web.UI.Page
    {
        ProductVideoController objProductVideoController = new ProductVideoController();
        public string _URL = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                long productID = Convert.ToInt64(Request.QueryString["product"]);
                int shapeId = Convert.ToInt32(Request.QueryString["shape"]);

                ProductVideoModel model = objProductVideoController.ProductVideo(productID, shapeId, CommonModel.RecordStatus.Enabled);
                if(model!=null)
                {
                    _URL = model.VideoPathURL;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}