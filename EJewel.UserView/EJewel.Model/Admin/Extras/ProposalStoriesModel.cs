using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Extras
{
   public class ProposalStoriesModel
    {
       public int ProposalStoryID { get; set; }
       public string StoryHeader { get; set; }
       public string StoryDescription { get; set; }
       public string ImagePath { get; set; }
       public DateTime StoryDate { get; set; }
       public string Story_Date { get; set; }
       public bool Status { get; set; }

    }
}
