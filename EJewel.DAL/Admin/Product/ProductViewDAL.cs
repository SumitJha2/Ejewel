using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Master.Metal;
using EJewel.Model.Admin.Common;
//dal
using EJewel.DAL.Admin.Master.Metal;
namespace EJewel.DAL.Admin.Product
{
    /// <summary>
    /// Get the details of the product
    /// Partha Ranjan
    /// @ 02-04-13
    /// </summary>
    public class ProductViewDAL
    {
        //Metal Type
        MetalTypeDAL objMetalTypeDAL = new MetalTypeDAL();
        ProductMetalDAL objProductMetalDAL = new ProductMetalDAL();
        //
        public List<MetalTypeListModel> GetMetalTypeList(long productId)
        {
            try
            {
                List<MetalTypeListModel> lstMetalTypeModel = objMetalTypeDAL.GetMetalTypeList(0, CommonModel.RecordStatus.Enabled);
                if (lstMetalTypeModel != null)
                {
                    //get the metal type
                    //get product metal type
                    List<ProductMetalModel> lstProductMetalTypeModel = objProductMetalDAL.GetProductMetalList(productId, CommonModel.RecordStatus.Enabled).OrderBy(tbl => tbl.DefaultMetal == false).ToList();
                    if (lstProductMetalTypeModel != null)
                    {
                        //now compare
                        lstMetalTypeModel = (from product in lstProductMetalTypeModel
                                             join metalType in lstMetalTypeModel
                                             on product.MetalTypeID equals metalType.MetalTypeId
                                             select new MetalTypeListModel()
                                             {
                                                 MetalTypeId = product.MetalTypeID,
                                                 MetalTypeName = metalType.MetalTypeName,
                                                 MetalName = metalType.MetalName,
                                                 MetalWeight = metalType.MetalWeight,
                                             }).ToList();
                    }
                }
                return lstMetalTypeModel;
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
