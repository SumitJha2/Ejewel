using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace EJewel.UserView
{
    public partial class ImageResize : System.Web.UI.Page
    {
        string image_path ="35156.jpg";
        protected void Page_Load(object sender, EventArgs e)
        {
            image_path = Server.MapPath(image_path);
            Response.Write(image_path);
        }

        protected void btnResize_Click(object sender, EventArgs e)
        {
            //System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(image_path);
            //System.Drawing.Image img = ScaleImage(bmp, 200);
            //Page.Response.ContentType = "image/jpeg";
            //bmp.Save(Page.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
           // Image1.ImageUrl = "/Handler/ImageResizer.ashx";
        }
        public static System.Drawing.Image ScaleImage(System.Drawing.Image image, int maxHeight)
        {
            var ratio = (double)maxHeight / image.Height;
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new System.Drawing.Bitmap(newWidth, newHeight);
            using (var g = System.Drawing.Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }
    }
}