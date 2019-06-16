using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL.Admin.Extras;
using EJewel.Model.Admin.Extras;

namespace EJewel.Controller.Admin.Extras
{
   public class CustomDesignRingController
    {
       CustomDesignRingDAL objDAL = new CustomDesignRingDAL();
       public CustomDesignRingModel SaveUpdateCustomDesign(CustomDesignRingModel model)
       {
           return objDAL.SaveUpdateCustomDesign(model);
       }
       public List<CustomDesignRingModel> GetCustomDesignRing()
       {
           return objDAL.GetCustomDesignRing();
       }
       public bool DeleteCustomDesignRingModel(long customerrequestId)
       {
           return objDAL.DeleteCustomDesignRingModel(customerrequestId);
       }
    }
}
