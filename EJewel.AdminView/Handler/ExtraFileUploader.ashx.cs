using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//controller
using EJewel.Controller.Common;
namespace EJewel.AdminView.Handler
{
    /// <summary>
    /// Partha Ranjan
    /// 01-02-13
    /// This handler is used to upload the fil in server
    /// Summary description for ExtraFileUploader
    /// </summary>
    public class ExtraFileUploader : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //get the paramters from the request
            string req_file_name = context.Request["file_name"];
            string req_upload_folder = context.Request["upload_folder"];
            string req_check_size = context.Request["check_size"];
            //upload type
            string upload_type = context.Request["upload_type"];
            //size
            string req_width = context.Request["width"];
            string req_height = context.Request["height"];
            //save the file
            if (req_file_name != "")
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
                        //now upload the file
                    }
                    else
                    {
                        //return error invalid extnsion
                    }
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