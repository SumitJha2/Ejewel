using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Common;
//
namespace EJewel.DAL.Admin.Product
{
    /*
         * Partha Ranjan
         * @ 19-01-2013
         * */
    public class ProductMetalDAL
    {
        EJewelEntities objEntity = new EJewelEntities();

        public List<ProductMetalModel> GetProductMetalList(long productID, CommonModel.RecordStatus rStatus)
        {
            List<ProductMetalModel> lstModel = new List<ProductMetalModel>();
            try
            {
                List<ej_ProductMetalType> lstProductMetalType = null;
                if (productID > 0)
                {
                    lstProductMetalType = objEntity.ej_ProductMetalType.Where(tbl => tbl.ProductId == productID).ToList();
                }
                else
                {
                    lstProductMetalType = objEntity.ej_ProductMetalType.Select(tbl => tbl).ToList();
                }
                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstProductMetalType = lstProductMetalType.Where(tbl => tbl.Status == true).ToList();
                }

                if (lstProductMetalType != null)
                {
                    lstModel = (from metalType in lstProductMetalType
                                select new ProductMetalModel()
                                {
                                    DefaultMetal = metalType.DefaultMetal,
                                    MetalTypeID = metalType.MetalTypeId,
                                    ProductID = metalType.ProductId,
                                    ProductMetalID = metalType.ProductMetalId,
                                    Status = metalType.Status
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
            return lstModel;
        }

        public ProductMetalModel GetProductMetal(long productID,int metalTypeID)
        {
            try
            {
                List<ProductMetalModel> lstProductMetalModel = this.GetProductMetalList(productID, CommonModel.RecordStatus.Enabled);
                if (lstProductMetalModel != null)
                {
                    lstProductMetalModel = lstProductMetalModel.Where(tbl => tbl.MetalTypeID == metalTypeID).ToList();
                }
                return lstProductMetalModel.FirstOrDefault();
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

        public bool IsExist(long productID,int metalTypeID)
        {
            try
            {
                return objEntity.ej_ProductMetalType.Where(tbl => tbl.ProductId == productID && tbl.MetalTypeId == metalTypeID).Any();
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
            return false;
        }

        public ProductMetalModel SaveUpdateProductMetal(ProductMetalModel model)
        {
            try
            {
                if (!this.IsExist(model.ProductID, model.MetalTypeID))
                {
                    //for save mode
                    if (model.Status)
                    {
                        ej_ProductMetalType metalType = new ej_ProductMetalType()
                        {
                            DefaultMetal = model.DefaultMetal,
                            MetalTypeId = model.MetalTypeID,
                            ProductId = model.ProductID,
                            ProductMetalId = model.ProductMetalID,
                            Status = model.Status
                        };
                        objEntity.AddToej_ProductMetalType(metalType);
                        objEntity.SaveChanges();
                        model.ProductMetalID = metalType.ProductMetalId;
                    }
                }
                else
                {
                    //get the product metal type
                    ej_ProductMetalType metalType = objEntity.ej_ProductMetalType.Where(pm => pm.ProductId == model.ProductID && pm.MetalTypeId == model.MetalTypeID).FirstOrDefault();
                    if (metalType != null)
                    {
                        //set the vaue
                        metalType.DefaultMetal = model.DefaultMetal;
                        metalType.Status = model.Status;
                        objEntity.SaveChanges();
                    }
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
            return model;
        }

        public bool UpdateProduct_Weight_Width(long _productID, double weight,double width)
        {
            try
            {
                ej_Product obj = objEntity.ej_Product.Where(tbl => tbl.ProductId == _productID).FirstOrDefault();
                if (obj != null)
                {
                    obj.ProductWeight = weight;
                    obj.ProductWidth = width;
                    objEntity.SaveChanges();
                    return true;
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
            return false;
        }

        /// <summary>
        /// Get Product Default metal Type
        /// Sumit @ 21-03-13
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public ProductMetalModel GetProductDefaultMetalType(long productID)
        {
            try
            {
                return this.GetProductMetalList(productID, CommonModel.RecordStatus.Enabled).Where(tbl => tbl.DefaultMetal == true).FirstOrDefault();
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
