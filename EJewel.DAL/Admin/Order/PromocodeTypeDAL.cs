using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Order;

namespace EJewel.DAL.Admin.Order
{
    public class PromocodeTypeDAL
    {
        EJewelEntities objejewelentity = new EJewelEntities();
        public List<PromocodeTypeModel> GetPromocodeType(CommonModel.RecordStatus status)
        {

            List<PromocodeTypeModel> objobjpromocodelist = new List<PromocodeTypeModel>();
            try
            {
                List<ej_PromocodeType> objpromocode;
                objpromocode = objejewelentity.ej_PromocodeType.Select(tbl => tbl).ToList();
                if (status == CommonModel.RecordStatus.Enabled)
                {
                    objpromocode = objpromocode.Where(tbl => tbl.Status == true).ToList();

                }
                if (objpromocode != null)
                {
                    objobjpromocodelist = (from promocodeType in objpromocode
                                           select new PromocodeTypeModel
                                           {
                                               PromocodeTypeID = promocodeType.PromocodeTypeID,
                                               PromocodeTypeName = promocodeType.PromocodeTypeName,
                                               Status = Convert.ToBoolean(promocodeType.Status)
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
            return objobjpromocodelist;
        }
    }
}
