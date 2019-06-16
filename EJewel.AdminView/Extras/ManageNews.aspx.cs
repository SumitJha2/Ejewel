using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Controller.Admin.Extras;
using EJewel.Controller.Admin.Common.Sfm;
using EJewel.Controller.Common;
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Extras;

using System.IO;

namespace EJewel.AdminView.Extras
{
    public partial class ManageNews : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
           txtNewsDate.Attributes.Add("readonly", "readonly");

            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                //load news  category
                if (!IsPostBack)
                {
                   // txtNewsDate.ReadOnly = true;
                    ListHelper.BindList(ddlNewsCategory, new SfmController().GetSfmList(0, CommonModel.RecordStatus.Enabled, Model.Admin.Common.Sfm.SfmModel.PageName.NewsCategory), "AutoID", "Name", ListHelper.DefaultList);
                    //lod status
                    ListHelper.BindList(ddlStatus, ListHelper.GetStatusSource(), "Value", "Text", null);
                    if (Request.QueryString["id"] != null)
                    {
                        int newsid = Convert.ToInt32(Request.QueryString["id"]);
                        loadNews(newsid);
                    }
                }
            }
          
        }

        public void loadNews(int newsid)
        {
            try
            {
                NewsModel model = new NewsController().GetNewsDetails(newsid, CommonModel.RecordStatus.Both).FirstOrDefault();
                if (model != null)
                {
                    hdnID.Value = model.NewsId.ToString();
                    ddlNewsCategory.SelectedValue = model.NewsCategory.ToString();
                    txtHeading.Text = model.NewsHeading;
               
                    txtdescription.Content = model.NewsDescription;
                    ddlStatus.SelectedIndex = model.Status == true ? 0 : 1;
                  //  txtNewsDate.Text = model.PublisdDate.ToString("dd-MM-yyyy");
                    txtNewsDate.Text = model.PublisdDate.ToString("MM/dd/yyyy");


                    spnProgress.InnerHtml = "<img src='" + "/upload/images/news/" + newsid+model.ImagePath + "' alt='Photo' style='width:50px;height:50px;' />";

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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                string imagename = null;
                string fileExtn = null;
                imagename = fuImage.FileName.ToString();
                fileExtn = Path.GetExtension(imagename).ToLower();
                NewsModel objNewsModel = new NewsModel();               
                objNewsModel.NewsCategory = Convert.ToInt32(ddlNewsCategory.SelectedValue);
                objNewsModel.NewsDescription = txtdescription.Content;
                objNewsModel.NewsHeading = txtHeading.Text;
                int newsid = 0;
                if (Request.QueryString["id"] != null)
                {
                    newsid = Convert.ToInt32(Request.QueryString["id"]);
                    objNewsModel.NewsId = newsid;
                }
                if(ddlStatus.SelectedValue=="1")
                {
                    objNewsModel.Status=true;
                }
                else
                {
                     objNewsModel.Status=false;
                }
                if (txtNewsDate.Text != "")
                {
                    string[] s = txtNewsDate.Text.Split('/');
                    int mm= Convert.ToInt32(s[0]);
                    int dd = Convert.ToInt32(s[1]);
                    int yyyy = Convert.ToInt32(s[2]);

                    /*
                                        int dd = Convert.ToInt32(txtNewsDate.Text.Substring(0, 2));
                                        int mm = Convert.ToInt32(txtNewsDate.Text.Substring(3, 2));
                                        int yyyy = Convert.ToInt32(txtNewsDate.Text.Substring(6, 4));
                     * */
                    DateTime dt = new DateTime(yyyy, mm, dd);
                    objNewsModel.PublisdDate = dt;
                }
                else
                {
                    objNewsModel.PublisdDate = DateTime.Now;
                }
                //save and retrive the inserting new Id.
                objNewsModel=new NewsController().SaveUpdateNews(objNewsModel);                              
                if (fileExtn != "")
                {
                    if (CheckImagePath(fileExtn))
                    {
                        objNewsModel.ImagePath = fileExtn;

                    }
                    else
                    { 
                    //message
                    }
                }             
                FileInfo fileInfo = new FileInfo(Server.MapPath("/upload/images/news/" + objNewsModel.NewsId +fileExtn));
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
                fuImage.SaveAs(Server.MapPath("/upload/images/news/" + objNewsModel.NewsId + fileExtn));
                new NewsController().SaveUpdateNews(objNewsModel);
                lblMessage.Text = "Details saved successfully.";
               
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

        private bool CheckImagePath(string path)
        {

            string ext = Path.GetExtension(path);
            switch (ext.ToLower())
            { 
                case".jpg":return true;
                case ".png": return true;
                case ".jpeg": return true;
                case ".gif": return true;
                case ".JPG": return true;
                case ".GIF": return true;
                default: return false;
            
            }
       
        }

    }
}