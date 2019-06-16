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
    public partial class ProposalStory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProposalstories();
            }
        }
        void BindProposalstories()
        {
            StringBuilder objstringbuilder = new StringBuilder();
            List<ProposalStoriesModel> objproposalStorieslist = new ProposalStoryController().GetProposalStoryList(0,CommonModel.RecordStatus.Enabled);
            if (objproposalStorieslist.Count > 0)
            {

                objstringbuilder.Append("<div>");
                for (int i = 0; i < objproposalStorieslist.Count; i++)
                {

                    objstringbuilder.Append("<h5> " + objproposalStorieslist[i].StoryHeader + " </h5>");


                    objstringbuilder.Append("<p style='text-align: justify;'><img width='250px' height='300px' style='padding-left:16px;float:right; border:4px; border-color:#646464;margin-top: 8px;' src='http://localhost:4419/upload/images/proposalstory/" + objproposalStorieslist[i].ImagePath + "'/>" + objproposalStorieslist[i].StoryDescription + "</p><span>" + objproposalStorieslist[i].StoryDate.ToString("dd-MM-yyyy") + "</span>");


                    //objstringbuilder.Append("<p> " + "<table><tr><td width='720px' valign='top' >" + objproposalStorieslist[i].StoryDescription + "</td><td valign='top'>" +

                    //     "<img width='200px' height='200px' style='padding-left:30px; border:4px; border-color:#646464;' src='http://localhost:4419/upload/images/proposalstory/b659f1d9-7e0.jpg'/> </td></tr></table></p><span>" + objproposalStorieslist[i].StoryDate.ToString("dd-MM-yyyy") + "</span>");

                   
                  
                  
                }
                objstringbuilder.Append("</div>");
                divProposalStories.InnerHtml=objstringbuilder.ToString();
            }

        
        }
    }
}