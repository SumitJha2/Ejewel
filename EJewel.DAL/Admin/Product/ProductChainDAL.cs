using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Product;

namespace EJewel.DAL.Admin.Product
{

    public class ProductChainDAL
    {
        EJewelEntities objEntity = new EJewelEntities();
        public ProductChainModel SaveUpdateProductChain(ProductChainModel model)
        {
            try
            {
                if (model.ProductChainId > 0)
                {
                    ej_ProductChain objChain = objEntity.ej_ProductChain.Where(tbl => tbl.ProductChainId == model.ProductChainId).FirstOrDefault();
                    objChain.ProductId = model.ProductId;
                    objChain.ChainLengthId = model.ChainLengthId;
                    objChain.ChainStyleId = model.ChainStyleId;
                    objChain.ChainClaspId = model.ChainClaspId;
                    objChain.Status = model.Status;
                    objEntity.SaveChanges();
                }
                else
                {
                    ej_ProductChain objChain = new ej_ProductChain()
                    {
                        ChainLengthId = model.ChainLengthId,
                        ChainStyleId = model.ChainStyleId,
                        ChainClaspId = model.ChainClaspId,
                        ProductId = model.ProductId,
                        Status = model.Status
                    };
                    objEntity.AddToej_ProductChain(objChain);
                    objEntity.SaveChanges();
                    model.ProductChainId = model.ProductChainId;
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
        public ProductChainModel GetProductChainDetail(long productId, CommonModel.RecordStatus rstatus)
        {
            try
            {
                List<ej_ProductChain> objProductChain = new List<ej_ProductChain>();
                if (productId > 0)
                {
                    objProductChain = objEntity.ej_ProductChain.Where(tbl => tbl.ProductId == productId).ToList();
                }
                else
                {
                    objProductChain = objEntity.ej_ProductChain.Select(tbl => tbl).ToList();

                }
                if (rstatus == CommonModel.RecordStatus.Enabled)
                {
                    objProductChain = objProductChain.Where(tbl => tbl.Status == true).ToList();
                }




                ProductChainModel objModel = new ProductChainModel();
                objModel = (from obj in objProductChain
                            join clsp in objEntity.ej_ChainClasp
                            on obj.ChainClaspId equals clsp.ChainClaspId
                            join length in objEntity.ej_ChainLength
                            on obj.ChainLengthId equals length.ChainLengthID
                            join style in objEntity.ej_ChainStyle
                            on obj.ChainStyleId equals style.ChainStyleID
                            where obj.ProductId == productId && clsp.Status == true
                            && length.Status == true && style.Status == true
                            select new ProductChainModel
                            {
                                ProductChainId = obj.ProductChainId,
                                ProductId = obj.ProductId,
                                ChainLengthId = obj.ChainLengthId,
                                ChainStyleId = obj.ChainStyleId,
                                ChainClaspId = obj.ChainClaspId,
                                Length = length.ChainLength,
                                Style = style.ChainStyle,
                                Clasp = clsp.ChainClasp,
                                Status = obj.Status

                            }).FirstOrDefault();
                return objModel;
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
