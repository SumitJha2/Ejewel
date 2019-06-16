using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Controller.Admin.Product;
using EJewel.Model.Admin.Product;
//
using EJewel.Model.Admin.Master.Metal;
using EJewel.Controller.Admin.Master.Metal;

using EJewel.Controller.Common;
//
namespace EJewel.AdminView.Product
{
    public partial class ProductPrice : System.Web.UI.Page
    {
        ProductDetailsController objController = new ProductDetailsController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                try
                {
                    if (Request.QueryString["id"] != null)
                    {
                        long productid = Convert.ToInt64(Request.QueryString["id"]);
                        ProductDetailsModel productModel = objController.GetProductDetails(productid);
                        ProductMetalModel metalModel = new ProductMetalController().GetProductDefaultMetalType(productid);
                        if (productModel != null && metalModel != null)
                        {
                            MetalTypeListModel metalTypeModel = new MetalTypeController().GetMetalTypeList(metalModel.MetalTypeID, CommonModel.RecordStatus.Both).FirstOrDefault();
                            if (metalTypeModel != null)
                            {
                                lblDefaultMetal.Text = metalTypeModel.MetalTypeName;
                            }
                            lblSKU.Text = productModel.SKU + " / " + productModel.ProductTitle;
                            ProductPriceModel priceModel = objController.ProductPriceDetails(productid, metalModel.MetalTypeID, productModel.ProductWeight, productModel.IsExtraOrdinary);
                            if (priceModel != null)
                            {
                                //basic
                                lblMetalPrice.Text = Convert.ToString(priceModel.MetalPrice);
                                lblSideStone.Text = Convert.ToString(priceModel.SideStonePrice);
                                lblMatchingBand.Text = Convert.ToString(priceModel.MatchingBandPrice);
                                //setting price
                                lblCenterStoneSettingPrice.Text = priceModel.CenterStoneSettingPrice.ToString();
                                lblSideStoneSettingPrice.Text = priceModel.SideStoneSettingPrice.ToString();
                                lblMatchingBandSettingPrice.Text = priceModel.MatchingBandSettingPrice.ToString();
                                lblSettingPrice.Text = Convert.ToString(priceModel.TotalSettingPrice);
                                //extra
                                lblChainPrice.Text = Convert.ToString(priceModel.ChainPrice);
                                lblTotalPrice.Text = Convert.ToString(priceModel.TotalPrice);
                            }
                            else
                            {
                                //error
                            }
                        }
                        else
                        {
                            Response.Redirect("Pagenotfound.aspx");
                        }

                    }
                    else
                    {
                        Response.Redirect("Pagenotfound.aspx");
                    }
                }
                catch (Exception ex)
                {
                    ErrorLogModel objLogError = new ErrorLogModel();
                    objLogError.ErrorMessage = ex.Message;
                    objLogError.ErrorSource = ex.Source;
                    objLogError.StackTrace = ex.StackTrace;
                    objLogError.InnerException = Convert.ToString(ex.InnerException);
                    objLogError.LogTime = DateTime.Now;
                    objLogError.UserID = Session["loginID"].ToString();
                    new ErrorLogController().SetErrorLog(objLogError);
                }
            }
        }
    }
}