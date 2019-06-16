using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Extras
{
   public class CustomDesignRingModel
    {
       public long CustomDesignRequestID { get; set; }
       public string DiamondItem { get; set; }
       public string SideStones { get; set; }
       public int MetalTypeId { get; set; }
       public int RingSizeId { get; set; }
       public float Budget { get; set; }
       public string LinkstoDesign { get; set; }
       public string Comments { get; set; }
       public string FileExtension { get; set; }
       public string FullName { get; set; }
       public string Email { get; set; }
       public string Phone { get; set; }
       public string BestTimeToCall { get; set; }
       public DateTime CreatedDate { get; set; }

       //
       public string MetalName { get; set; }
       public string RingSize { get; set; }

    }
}
