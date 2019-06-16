using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Common;

using EJewel.Model.Admin.Master.Metal;

using EJewel.DAL.Admin.Master.Metal;


namespace EJewel.Controller.Admin.Master.Metal
{
   public class MetalTypeController
    {
       /*
        * sumit jha
        * 21-12-2012
        * */
       MetalTypeDAL objMetalTypeDAL = new MetalTypeDAL();

       public List<MetalTypeListModel> GetMetalTypeList(int metalTypeId,CommonModel.RecordStatus rStatus)
       {
           return objMetalTypeDAL.GetMetalTypeList(metalTypeId, rStatus);
       }
       /*
        * Partha Ranjan
        * 01-02-13
        * 
        * */
       public MetalTypeModel SaveUpdateMetalType(MetalTypeModel objmetalTypeModel)
       {
           return objMetalTypeDAL.SaveUpdateMetalType(objmetalTypeModel);
       }
       /*
        * Partha Ranjan
        * 01-02-13
        * 
        * */
       public bool IsExist(int metalWeightId, int metalNameId)
       {
           return objMetalTypeDAL.IsExist(metalWeightId, metalNameId);

       }
       /* Partha Ranjan
        * @ 01-02-13
        * */
       public bool DeleteMetalType(int metalTypeId)
       {
           return objMetalTypeDAL.DeleteMetalType(metalTypeId);
       }

    }
}
