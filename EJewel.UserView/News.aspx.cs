using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EJewel.Model.Admin.Extras;
using EJewel.Controller.Admin.Extras;

namespace EJewel.UserView
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindNews();
            }
        }
        void BindNews()
        {
            StringBuilder objstringbuilder = new StringBuilder();
            List<NewsModel> objNewslist = new NewsController().GetNewsDetails(0, CommonModel.RecordStatus.Enabled);
            if (objNewslist.Count > 0)
            {

                objstringbuilder.Append("<div>");
                for (int i = 0; i < objNewslist.Count; i++)
                {

                    objstringbuilder.Append("<h4> " + objNewslist[i].NewsHeading + " </h4>");
                    objstringbuilder.Append("<h5>Tags:" + objNewslist[i].NewsCategoryName + " </h5>");


                    //objstringbuilder.Append("<p style='text-align: justify;'><img width='250px' height='300px' style='padding-left:16px;float:right; border:4px;margin-top: 8px; border-color:#646464;' src='http://localhost:4419/upload/images/news/" + objNewslist[i].NewsId + objNewslist[i].ImagePath + "'/>" + objNewslist[i].NewsDescription + "</p><span>" + objNewslist[i].PublisdDate.ToString("dd-MM-yyyy") + "</span>");


                    objstringbuilder.Append("<p> " + "<table><tr><td width='720px' valign='top' >" + objNewslist[i].NewsDescription + "</td><td valign='top'>" +

                        "<img width='200px' height='200px' style='padding-left:30px; border:4px; border-color:#646464;' src='http://localhost:4419/upload/images/news/" + objNewslist[i].NewsId + objNewslist[i].ImagePath + "'/> </td></tr></table></p><span>" + objNewslist[i].PublisdDate.ToString("dd-MM-yyyy") + "</span>");




                }
                objstringbuilder.Append("</div>");
                divNews.InnerHtml = objstringbuilder.ToString();
            }


        }
    }
}