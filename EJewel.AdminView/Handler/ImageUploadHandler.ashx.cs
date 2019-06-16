using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//class
using System.IO;
using System.Drawing;
//controller
using EJewel.Controller.Common;
namespace EJewel.AdminView.Handler
{
    /// <summary>
    /// Summary description for ImageUploadHandler
    /// </summary>
    public class ImageUploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //get the paramters from the request
            string req_upload_folder = context.Request["upload_folder"];
            string req_check_size = context.Request["check_size"];
            //size
            int width =Convert.ToInt32(context.Request["width"]);
            int height = Convert.ToInt32(context.Request["height"]);
            string result = "";
            //save the file
            if (req_upload_folder != "")
            {
                HttpPostedFile postFile = context.Request.Files[0];
                if (postFile != null && !string.IsNullOrEmpty(postFile.FileName))
                {
                    //upload the file to the server
                    //get the file extention
                    string fileExt = StringHelper.GetFileExtention(postFile.FileName, false);
                    //check that the extnetsion is present or not
                    if (StringHelper.IsValidExtention(fileExt))
                    {
                        try
                        {
                            //now upload the file
                            
                            string fileName=StringHelper.UniqueString(12) + "." + fileExt;
                            string file_path = "upload/images/" + req_upload_folder + "/" + fileName;
                            //now upload the file
                            postFile.SaveAs(context.Server.MapPath("~/" + file_path));
                            result = "success$" + fileName;
                            //now check the file width & height
                            if (Convert.ToInt16(req_check_size) == 1)
                            {
                                //now get the height and width of the file
                                Bitmap img = new Bitmap(context.Server.MapPath("~/" + file_path));
                                if (img != null)
                                {
                                    if (width <= img.Width && height <= img.Height)
                                    {

                                    }
                                    else
                                    {
                                        //delete the file in the server
                                        //throw error
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //error
                            result = "error$" + ex.Message;
                        }
                    }
                    else
                    {
                        //return error invalid extnsion
                        result = "error$Invalid File Extention";
                    }
                }
            }
            else
            {
                result = "error$Parameter Error";
            }
            context.Response.ClearContent();
            context.Response.Write(result);
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