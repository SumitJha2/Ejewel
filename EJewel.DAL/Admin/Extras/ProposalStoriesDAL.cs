using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Extras;

namespace EJewel.DAL.Admin.Extras
{
   public class ProposalStoriesDAL
    {
       EJewelEntities objEntity = new EJewelEntities();
       public ProposalStoriesModel SaveUpdateProposalStory(ProposalStoriesModel model)
       {
           try
           {
               if (model.ProposalStoryID > 0)
               {
                   ej_ProposalStory objProposal = objEntity.ej_ProposalStory.Where(tbl => tbl.ProposalStoryID == model.ProposalStoryID).FirstOrDefault();
                   objProposal.StoryHeader = model.StoryHeader;
                   objProposal.StoryDescription = model.StoryDescription;
                   objProposal.StoryImage = model.ImagePath;
                   objProposal.Status = model.Status;
                   objEntity.SaveChanges();
               }
               else
               {
                   ej_ProposalStory objProposal = new ej_ProposalStory()
                   {
                       StoryHeader = model.StoryHeader,
                       StoryDescription = model.StoryDescription,
                       StoryImage = model.ImagePath,
                       StoryDate = System.DateTime.Now,
                       Status = model.Status
                   };
                   objEntity.AddToej_ProposalStory(objProposal);
                   objEntity.SaveChanges();
                   model.ProposalStoryID = objProposal.ProposalStoryID;
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
       public List<ProposalStoriesModel> GetProposalStory(int proposalstoryId,CommonModel.RecordStatus rstatus)
       {
           try
           {
               List<ej_ProposalStory> objProposalStory = null;
               if (proposalstoryId > 0)
               {
                   objProposalStory = objEntity.ej_ProposalStory.Where(tbl => tbl.ProposalStoryID == proposalstoryId).ToList(); ;
               }
               else
               {
                   objProposalStory = objEntity.ej_ProposalStory.Select(tbl => tbl).ToList();
               }
               if (rstatus == CommonModel.RecordStatus.Enabled)
               {
                   objProposalStory = objProposalStory.Where(tbl => tbl.Status == true).ToList();
               }
               List<ProposalStoriesModel> lstmodel = (from story in objProposalStory
                                                      select new ProposalStoriesModel
                                                      {
                                                          ProposalStoryID = story.ProposalStoryID,
                                                          StoryHeader = story.StoryHeader,
                                                          StoryDescription = story.StoryDescription,
                                                          ImagePath = story.StoryImage,
                                                          StoryDate = story.StoryDate,
                                                          Status = story.Status
                                                      }).OrderByDescending(tbl => tbl.ProposalStoryID).ToList();
               return lstmodel;
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

       public bool DeletePriposalStory(int proposalstoryId)
       {
           try
           {
               ej_ProposalStory objProposalstory = objEntity.ej_ProposalStory.Where(tbl => tbl.ProposalStoryID == proposalstoryId).FirstOrDefault();
               if (objProposalstory != null)
               {
                   objEntity.DeleteObject(objProposalstory);
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
