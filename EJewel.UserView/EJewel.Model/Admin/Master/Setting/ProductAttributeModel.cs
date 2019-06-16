using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Setting
{
   public class ProductAttributeModel
    {
       public int AttributeId { get; set; }
       public int SubCategoryId { get; set; }
       public string AttributeName { get; set; }
       public float AttributePrice { get; set; }      
       public bool Status { get; set; }

       public int PrimeryCategoryId { get; set; }    
       public string PrimeryCategory { get; set; }
       public string SubCategory { get; set; }

       public int AttributeTitleId { get; set; }
       public string AttributeTitle { get; set; }
       public bool IsDefault { get; set; }

    }
}
