using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Extras;

namespace EJewel.DAL.Admin.Extras
{
   public class NewsDAL
    {
       EJewelEntities objEntity = new EJewelEntities();
       public NewsModel SaveUpdateNews(NewsModel model)
       {
           try
           {
               if (model.NewsId > 0)
               {
                   ej_News objNews = objEntity.ej_News.Where(tbl => tbl.NewsId == model.NewsId).FirstOrDefault();
                   if (objNews != null)
                   {
                       objNews.NewsCategory = model.NewsCategory;
                       objNews.NewsHeading = model.NewsHeading;
                       objNews.NewsDescription = model.NewsDescription;
                       objNews.PublishDate = model.PublisdDate;
                       objNews.Status = model.Status;
                       if (model.ImagePath != null)
                       {
                           objNews.Image = model.ImagePath;
                       }
                       objEntity.SaveChanges();
                   }
               }
               else
               {
                   ej_News objNews = new ej_News();
                   objNews.NewsCategory = model.NewsCategory;
                   objNews.NewsHeading = model.NewsHeading;
                   objNews.NewsDescription = model.NewsDescription;
                   objNews.PublishDate = model.PublisdDate;
                   if (model.ImagePath != null)
                   {
                       objNews.Image = model.ImagePath;
                   }
                   objNews.Status = model.Status;
                   objEntity.AddToej_News(objNews);
                   objEntity.SaveChanges();
                   model.NewsId = objNews.NewsId;
               }
           }
           catch (Exception ex)
           {
               ErrorLogDAL obj = new ErrorLogDAL();
               obj.SetErrorLog(new ErrorLogModel()
               {
                   ErrorMessage = ex.Message,
                   ErrorSource = ex.Source,
                   InnerException = Convert.ToString(ex.InnerException),
                   LogTime = DateTime.Now,
                   StackTrace = ex.StackTrace,
                   UserID = "DAL"
               });
           }
           return model;
       }
       public List<NewsModel> GetNewsDetails(int newsId,CommonModel.RecordStatus  rstatus )
       {
           try
           {
               List<ej_News> objNews = new List<ej_News>();
               if (newsId > 0)
               {
                   objNews = objEntity.ej_News.Where(tbl => tbl.NewsId == newsId).ToList();
               }
               else
               {
                   objNews = objEntity.ej_News.Select(tbl => tbl).ToList();
               }
               if (rstatus == CommonModel.RecordStatus.Enabled)
               {
                   objNews = objNews.Where(tbl => tbl.Status == true).ToList();
               }
               List<NewsModel> lstNews = (from news in objNews
                                          join newscategory in objEntity.ej_NewsCategory
                                          on news.NewsCategory equals newscategory.NewsCategoryID
                                          where newscategory.Status == true
                                          select new NewsModel
                                          {
                                              NewsId = news.NewsId,
                                              NewsHeading = news.NewsHeading,
                                              NewsDescription = news.NewsDescription,
                                              PublisdDate = news.PublishDate,
                                              Publisd_Date = news.PublishDate.ToShortDateString(),
                                              NewsCategory = news.NewsCategory,
                                              NewsCategoryName = newscategory.CategoryName,
                                              Status = news.Status,
                                              ImagePath = news.Image
                                          }).OrderByDescending(tbl => tbl.NewsId).ToList();
               return lstNews;
           }
           catch (Exception ex)
           {
               ErrorLogDAL obj = new ErrorLogDAL();
               obj.SetErrorLog(new ErrorLogModel()
               {
                   ErrorMessage = ex.Message,
                   ErrorSource = ex.Source,
                   InnerException = Convert.ToString(ex.InnerException),
                   LogTime = DateTime.Now,
                   StackTrace = ex.StackTrace,
                   UserID = "DAL"
               });
           }
           return null;
       }
       public bool DeleteNews(int newsId)
       {
           try
           {
               ej_News objNews = objEntity.ej_News.Where(tbl => tbl.NewsId == newsId).FirstOrDefault();
               if (objNews != null)
               {
                   objEntity.DeleteObject(objNews);
                   objEntity.SaveChanges();
               }
               return true;
           }
           catch (Exception ex)
           {
               ErrorLogDAL obj = new ErrorLogDAL();
               obj.SetErrorLog(new ErrorLogModel()
               {
                   ErrorMessage = ex.Message,
                   ErrorSource = ex.Source,
                   InnerException = Convert.ToString(ex.InnerException),
                   LogTime = DateTime.Now,
                   StackTrace = ex.StackTrace,
                   UserID = "DAL"
               });
           }
           return false;
       }
    }
}
