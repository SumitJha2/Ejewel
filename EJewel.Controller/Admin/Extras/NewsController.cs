using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Extras;
using EJewel.DAL.Admin.Extras;

namespace EJewel.Controller.Admin.Extras
{
  
  public  class NewsController
    {
        NewsDAL objDAL = new NewsDAL();
        public NewsModel SaveUpdateNews(NewsModel model)
        {
            return objDAL.SaveUpdateNews(model);
        }
        public List<NewsModel> GetNewsDetails(int newsid,CommonModel.RecordStatus rstatus)
        {
            return objDAL.GetNewsDetails(newsid, rstatus);
        }
        public bool DeleteNewsDetails(int newsId)
        {
            return objDAL.DeleteNews(newsId);
        }

    }
}
