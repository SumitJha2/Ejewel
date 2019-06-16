using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
namespace EJewel.UserView.Handler
{
    /// <summary>
    /// Summary description for ImageResizer
    /// </summary>
    public class ImageResizer : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            string image_path =context.Server.MapPath("~/35156.jpg");
            int height = Convert.ToInt32(context.Request.QueryString["height"]);
            Bitmap bmp = new Bitmap(image_path);
            Image img = ScaleImage(bmp, height);
            img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        public static Image ScaleImage(Bitmap image, int maxHeight)
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