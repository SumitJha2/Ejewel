using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Net;
using System.IO;
using EJewel.Controller.Admin.Product;
using EJewel.Model.Admin.Product;
using EJewel.Controller.Common;
//
namespace EJewel.UserView.Handler
{
    /// <summary>
    /// Summary description for ImageManager
    /// </summary>
    public class ImageManager : IHttpHandler
    {
        ProductImageManagerController objController = new ProductImageManagerController();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            try
            {
                string GUID = Convert.ToString(context.Request.QueryString["GUID"]); 
                string qs_height = Convert.ToString(context.Request.QueryString["height"]);
                int height = Convert.ToInt32(qs_height);
                if (string.IsNullOrEmpty(GUID))
                {
                    string qs_view = Convert.ToString(context.Request.QueryString["view"]);
                    string SKU = Convert.ToString(context.Request.QueryString["SKU"]);
                    //get product details
                    if (!string.IsNullOrEmpty(SKU))
                    {
                        ProductDetailsModel productDetails = new ProductDetailsController().GetProductFromSKU(SKU.Trim());
                        if (productDetails != null)
                        {
                            if (string.IsNullOrEmpty(qs_view))
                            {
                                string qs_comb = context.Request.QueryString["comb"];
                                string qs_angle = context.Request.QueryString["angle"];
                                //access the image
                                string combination = qs_comb + qs_angle;
                                ProductImageManagerModel model = objController.ProductImageListFromGUID(SKU, combination, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                                this.CreateImage(context, model, Convert.ToInt32(qs_height));
                            }
                            else
                            {
                                //for default image
                                qs_view = qs_view.Trim();
                                if (qs_view == "def")
                                {
                                    ProductImageManagerModel model = objController.ProductDefaultImage(productDetails, 1).FirstOrDefault();
                                    if (model != null)
                                    {
                                        this.CreateImage(context, model, height);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    ProductImageManagerModel model = objController.ProductImageFromGUID(GUID.Trim());
                    if(model!=null)
                    {
                        this.CreateImage(context, model, height);
                    }
                }
            }
            catch(Exception ex)
            {
                ErrorLogModel objLogError = new ErrorLogModel();
                objLogError.ErrorMessage = ex.Message;
                objLogError.ErrorSource = ex.Source;
                objLogError.StackTrace = ex.StackTrace;
                objLogError.InnerException = Convert.ToString(ex.InnerException);
                objLogError.LogTime = DateTime.Now;
                objLogError.UserID = "Handler";
                new ErrorLogController().SetErrorLog(objLogError);
            }
        }

        void CreateImage(HttpContext context,ProductImageManagerModel model,int height)
        {
            
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.ImagePath))
                {
                    var request = WebRequest.Create(model.ImagePath);
                    var response = request.GetResponse();
                    Stream stream = response.GetResponseStream();
                    Image bmp = Bitmap.FromStream(stream);
                    Image img = ScaleImage(bmp, height);
                    img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }

        public static Image ScaleImage(Image image, int maxHeight)
        {
            var ratio = (double)maxHeight / image.Height;
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(newImage);
            g.DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
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