using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
//
using EJewel.Controller.Admin.Product;
using EJewel.Model.Admin.Product;
//
namespace EJewel.AdminView.Handler
{
    /// <summary>
    /// Summary description for ProductDescriptionHandler
    /// </summary>
    public class ProductDescriptionHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string qs_productID = context.Request.QueryString["id"];
            string qs_view = context.Request.QueryString["view"];
            if (!string.IsNullOrEmpty(qs_productID))
            {
                try
                {
                    long productID = Convert.ToInt64(qs_productID);
                    if (productID > 0)
                    {
                        string view = qs_view.ToString();
                        if (qs_productID.Length > 0)
                        {
                            switch (view)
                            {
                                case "def_price":
                                    {
                                        StringBuilder sb = new StringBuilder();
                                        
                                        ProductDetailsModel productModel = new ProductDetailsController().GetProductDetails(productID);
                                        if (productModel != null)
                                        {
                                            ProductPriceController.DefaultPrice objDefPrice = new ProductPriceController.DefaultPrice(productID);
                                            if (objDefPrice != null)
                                            {
                                                double metal_price = objDefPrice.MetalPrice(productModel.ProductWeight);
                                                double setting_price = objDefPrice.SettingPrice(productModel.SubCategoryID, productModel.ProductWeight);
                                                double side_stone_price = objDefPrice.SideStonePrice(1);
                                                double matching_band = objDefPrice.MatchingBandPrice(1);
                                                sb.Append("<table>");
                                                sb.Append("<tr><th colspan='3'>Price Details</th></tr>");
                                                sb.Append("<tr><td>Metal Price</td><td>:</td><td>" +metal_price + "</td></tr>");
                                                sb.Append("<tr><td>Setting Price</td><td>:</td><td>" + setting_price + "</td></tr>");
                                                sb.Append("<tr><td>Side Stone (Diamond)</td><td>:</td><td>" + side_stone_price + "</td></tr>");
                                                sb.Append("<tr><td>Matching Band (Diamond)</td><td>:</td><td>" + matching_band + "</td></tr>");
                                                sb.Append("<tr><td>Total</td><td>:</td><td>"+(metal_price+setting_price+side_stone_price+matching_band)+"</td></tr>");
                                                //
                                                context.Response.Write(sb);
                                            }
                                        }
                                    }
                                    break;
                                default:
                                    {

                                    }
                                    break;
                            }
                        
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        //throw error
                    }
                }
                catch (Exception ex)
                {
                    context.Response.Write(ex.InnerException);
                }
            }
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}