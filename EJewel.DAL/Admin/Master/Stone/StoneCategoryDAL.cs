using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Common;
namespace EJewel.DAL.Admin.Master.Stone
{
    public class StoneCategoryDAL
    {
        EJewelEntities objEntity = new EJewelEntities();

        public List<StoneCategoryModel> GetStoneCategoryList(int categoryID)
        {
            List<StoneCategoryModel> lstStoneCategoryModel = new List<StoneCategoryModel>();
            try
            {
                List<ej_StoneCategory> lstStoneCategory = null;
                if (categoryID > 0)
                {
                    lstStoneCategory = objEntity.ej_StoneCategory.Where(tbl => tbl.StoneCategoryId == categoryID && tbl.Status == true).ToList();
                }
                else
                {
                    lstStoneCategory = objEntity.ej_StoneCategory.Where(tbl => tbl.Status == true).ToList();
                }
                //
                if (lstStoneCategory != null)
                {
                    lstStoneCategoryModel = (from stoneCategory in lstStoneCategory
                                             select new StoneCategoryModel()
                                             {
                                                 Status = stoneCategory.Status,
                                                 StoneCategoryID = stoneCategory.StoneCategoryId,
                                                 StoneCategoryName = stoneCategory.StoneCategoryName
                                             }).ToList();
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
            return lstStoneCategoryModel;
        }
        
    }
}
