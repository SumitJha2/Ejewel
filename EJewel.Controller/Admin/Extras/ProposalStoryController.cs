using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Extras;
using EJewel.DAL.Admin.Extras;

namespace EJewel.Controller.Admin.Extras
{
   public class ProposalStoryController
    {
       ProposalStoriesDAL objDAL = new ProposalStoriesDAL();
       public ProposalStoriesModel SaveUpdateProposalStory(ProposalStoriesModel model)
       {
           return objDAL.SaveUpdateProposalStory(model);
       }
       public List<ProposalStoriesModel> GetProposalStoryList(int proposalstoryId,CommonModel.RecordStatus rstatus)
       {
           return objDAL.GetProposalStory(proposalstoryId, rstatus);
       }
       public bool DeleteProposalStory(int proposalstoryId)
       {
           return objDAL.DeletePriposalStory(proposalstoryId);
       }
    }
}
