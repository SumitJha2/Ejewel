using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Order;
using EJewel.DAL.Admin.Order;

namespace EJewel.Controller.Admin.Order
{
   public class PromotionalcodeManagementController
    {
       public PromotionalcodeManagementModel SaveUpdatePromotionalcodeManagement(PromotionalcodeManagementModel model)
       {
           return new PromotionalcodeManagementDAL().SaveUpdatePromotionalcodeManagement(model);
       }
       public List<PromotionalcodeManagementModel> GetPromotionalcodeManagement(int promotionalcodeManagementId,CommonModel.RecordStatus status)
       {
           return new PromotionalcodeManagementDAL().GetPromotionalcodeManagement(promotionalcodeManagementId,status);
       }
        public bool DeletePromotionCode(int promotioncodeId)
        {
            return new PromotionalcodeManagementDAL().DeletePromotionCode(promotioncodeId);
        }
        public bool IsExistPromotionCode(int promotioncodeId,string promotioncode)
         {
             return new PromotionalcodeManagementDAL().IsExistPromotionCode(promotioncodeId, promotioncode);
         }
       
    }
}
