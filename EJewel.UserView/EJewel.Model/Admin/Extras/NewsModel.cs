using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Extras
{
   public class NewsModel
    {
       public int NewsId { get; set; }
       public int NewsCategory { get; set; }
       public string NewsHeading { get; set; }
       public string NewsDescription { get; set; }
       public DateTime PublisdDate { get; set; }
       public string ImagePath { get; set; }
       public bool Status { get; set; }
       public string NewsCategoryName { get; set; }
       public string Publisd_Date { get; set; }
    }
}
