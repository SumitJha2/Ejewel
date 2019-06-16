using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL.Admin.Master.Stone;
using EJewel.Model.Admin.Master.Stone;

namespace EJewel.Controller.Admin.Master.Stone
{
    
   public class CenterStoneImageController
    {
       CenterStoneImageDAL objDAL = new CenterStoneImageDAL();
       public CenterStoneImageModel SaveUpdateCenterStoneImage(CenterStoneImageModel model)
       {
           return objDAL.SaveUpdateCenterStoneImage(model);
       }
       public List<CenterStoneImageModel> GetImageByCenterStoneID(long centerstoneId)
       {
           return objDAL.GetImageByCenterStoneID(centerstoneId);
       }
       public List<CenterStoneImageModel> GetImageByCenterStoneImageID(long imageId)
       {
           return objDAL.GetImageByCenterStoneImageID(imageId);
       }


    
       public bool DeleteCenterStoneImage(long centerstoneImageId)
       {
           return objDAL.DeleteCenterStoneImage(centerstoneImageId);
       } 
         
    }
}
