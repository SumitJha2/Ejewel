using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Stone;
namespace EJewel.DAL.Admin.Master.Stone
{
    /*
        * Partha Ranjan Nayak
        * @ 17-12-12
        * */
    public class StoneCategoryTypeDAL
    {
        EJewelEntities objEntity = new EJewelEntities();
        /*
       * Partha Ranjan Nayak
       * @ 17-12-12
       * */
        public List<StoneCategoryTypeModel> GetStoneCategoryType()
        {
            try
            {
                List<StoneCategoryTypeModel> lstStoneCategoryTypeModel = new List<StoneCategoryTypeModel>();
                foreach (var stoneCategoryType in objEntity.ej_StoneCategoryType)
                {
                    lstStoneCategoryTypeModel.Add(this.Mapping(stoneCategoryType));
                }
                return lstStoneCategoryTypeModel.OrderBy(sc => sc.StoneCategoryTypeID).ToList();
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
            return null;
        }
        /*
       * Partha Ranjan Nayak
       * @ 17-12-12
       * */
        public StoneCategoryTypeModel Mapping(ej_StoneCategoryType category)
        {
            try
            {
                StoneCategoryTypeModel model = new StoneCategoryTypeModel();
                model.StoneCategoryTypeID = category.StoneCategoryTypeId;
                model.StoneCategoryTypeName = category.StoneCategoryTypeName;
                return model;
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
            return null;
        }    

    }
}
