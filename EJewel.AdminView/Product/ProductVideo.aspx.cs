using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//model
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Master.Category;
using EJewel.Model.Admin.Master.Metal;
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Common.Sfm;
using EJewel.Model.Admin.Master.Stone;

using System.IO;
using EJewel.Controller.Admin.Product;

namespace EJewel.AdminView.Product
{
    public partial class ProductVideo : System.Web.UI.Page
    {
        ProductDetailsController objController = new ProductDetailsController();
        ProductVideoController objProductVideoController = new ProductVideoController();
        ProductCenterStoneController objProductCenterStoneController = new ProductCenterStoneController();
        long _productID = 0;
        public int _totalImage = 0;
        string PRODUCT_SKU = "", product_title = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(Guid.NewGuid().ToString());
            try
            {
                string pID = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(pID))
                {
                    _productID = Convert.ToInt64(pID.Trim());
                    ProductDetailsModel productModel = objController.GetProductList(_productID).FirstOrDefault();
                    if (productModel != null)
                    {
                        PRODUCT_SKU = productModel.SKU.ToUpper().Trim();
                        product_title = productModel.ProductTitle;
                        if (!IsPostBack)
                        {
                            ltrlHeading.Text = productModel.SKU + " / " + productModel.ProductTitle;

                            this.LoadVideo(productModel.ProductID);
                        }
                        string qs_status = Request.QueryString["status"];
                        if (!string.IsNullOrEmpty(qs_status))
                        {
                            if (qs_status == "success")
                            {
                                lblMessage.Text = "Image Imported successfully.";
                            }
                            else if (qs_status == "error")
                            {
                                lblMessage.Text = "Error in Import.";
                            }
                        }

                    }
                    else
                    {
                        //error 
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void LoadVideo(long ProductID)
        {
            try
            {
                List<StoneShapeModel> lstShapes = objProductCenterStoneController.GetProductCenterStoneStoneShapeList(ProductID, ConstantHelper.STONE_CATEGORY_DIAMOND, StoneShapeModel.ShapeVisibility.CENTERSTONE, CommonModel.RecordStatus.Enabled);
                if(lstShapes!=null && lstShapes.Count>0)
                {
                    grdVideo.DataSource = lstShapes;
                    grdVideo.DataBind();
                    grdVideo.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    btnSave.Visible = false;
                }
            }
            catch(Exception ex)
            {
                
            }
        }

        protected void grdVideo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //access the cotrols
                HiddenField hdnShape = (HiddenField)e.Row.FindControl("hdnShape");
                TextBox txtVideoURL = (TextBox)e.Row.FindControl("txtVideoURL");
                TextBox txtImage = (TextBox)e.Row.FindControl("txtImage");
                if(hdnShape!=null)
                {
                    //access the video accordin to shape
                    ProductVideoModel model = objProductVideoController.ProductVideo(_productID, Convert.ToInt32(hdnShape.Value), CommonModel.RecordStatus.Enabled);
                    if(model!=null)
                    {
                        HyperLink lnkPlay = (HyperLink)e.Row.FindControl("lnkPlay");
                        //set the value of the controls
                        txtVideoURL.Text = model.VideoPathURL;
                        txtImage.Text = model.VideoPhotoURL;
                        lnkPlay.Attributes.Add("onclick", "popupwindow('/Product/ProductVideoPlayer.aspx?product=" + _productID + "&shape=" + hdnShape.Value + "',500,400,'new_video')");
                    }
                }
            }
            catch(Exception ex)
            {
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //now save the data
                int total_row = grdVideo.Rows.Count;
                GridViewRow row = null;
                HiddenField hdnShape = null;
                TextBox txtVideoURL = null;
                TextBox txtImage = null;

                for (int i = 0; i < total_row; i++)
                {
                    row = grdVideo.Rows[i];
                    if (row != null)
                    {
                        hdnShape = (HiddenField)row.FindControl("hdnShape");
                        txtVideoURL = (TextBox)row.FindControl("txtVideoURL");
                        txtImage = (TextBox)row.FindControl("txtImage");
                        //create model
                        ProductVideoModel model = new ProductVideoModel()
                        {
                            CenterStoneShapeId=Convert.ToInt32(hdnShape.Value),
                            ProductId=_productID,
                            Status=true,
                            VideoPathURL = txtVideoURL.Text.Trim(),
                            VideoPhotoURL=txtImage.Text.Trim()
                        };
                        objProductVideoController.SaveUpdate(model);
                    }
                    //
                }
            }
            catch(Exception ex)
            {
                
            }
            Response.Redirect("/Product/ProductVideo.aspx?id=" + _productID + "&status=success");
        }
    }
}