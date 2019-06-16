using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Common;
namespace EJewel.DAL.Admin.Product
{
    public class ProductImageManagerDAL
    {
        EJewelEntities objEntity = new EJewelEntities();

        public ProductImageManagerModel SaveUpdate(ProductImageManagerModel model)
        {
            try
            {
                if (!this.IsExist(model.ProductId, model.GUID))
                {
                    //for save
                    ej_ProductImage obj = new ej_ProductImage()
                    {
                        GUID = model.GUID,
                        ImagePath = model.ImagePath,
                        ProductId = model.ProductId,
                        ImageAlt=model.ImageAlt,
                        Angle = model.Angle,
                        Status = model.Status
                    };
                    objEntity.AddToej_ProductImage(obj);
                    objEntity.SaveChanges();
                    model.ImageId = obj.ImageId;
                }
                else
                {
                    //for update
                    ej_ProductImage obj = objEntity.ej_ProductImage.Where(tbl => tbl.ProductId == model.ProductId && tbl.GUID == model.GUID).FirstOrDefault();
                    if (obj != null)
                    {
                        //update path and staus
                        obj.ImagePath = model.ImagePath;
                        obj.Status = model.Status;
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

        public List<ProductImageManagerModel> ProductImageListFromProduct(long productId,CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<ej_ProductImage> lstObj = objEntity.ej_ProductImage.Where(tbl => tbl.ProductId == productId).ToList();
                if (lstObj != null && rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                }
                return this.ProductImageList(lstObj);
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

        public List<ProductImageManagerModel> ProductImageListFromProductGUID(long productId, string GUID, CommonModel.RecordStatus rStatus)
        {
            try
            {
                List<ej_ProductImage> lstObj = objEntity.ej_ProductImage.Where(tbl => tbl.ProductId == productId && tbl.GUID == GUID).ToList();
                if (lstObj != null && rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                }
                return this.ProductImageList(lstObj);
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

        public List<ProductImageManagerModel> ProductImageListFromGUID(string SKU, string GUID, CommonModel.RecordStatus rStatus)
        {
            try
            {
                ProductDetailsModel detailsModel = new ProductDetailsDAL().GetProductFromSKU(SKU);
                if (detailsModel != null)
                {
                    List<ej_ProductImage> lstObj = objEntity.ej_ProductImage.Where(tbl => tbl.GUID == GUID && tbl.ProductId == detailsModel.ProductID).ToList();
                    if (lstObj != null && rStatus == CommonModel.RecordStatus.Enabled)
                    {
                        lstObj = lstObj.Where(tbl => tbl.Status == true).ToList();
                    }
                    return this.ProductImageList(lstObj);
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
            return new List<ProductImageManagerModel>();
            
        }

        public ProductImageManagerModel ProductImageFromGUID(string GUID)
        {
            try
            {
                List<ej_ProductImage> lstObj = objEntity.ej_ProductImage.Where(tbl => tbl.GUID == GUID).ToList();
                if (lstObj != null)
                {
                    return this.ProductImageList(lstObj).FirstOrDefault();
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
            return null;
        }

        private List<ProductImageManagerModel> ProductImageList(List<ej_ProductImage> lstObj)
        {
            List<ProductImageManagerModel> lstModel = new List<ProductImageManagerModel>();
            try
            {
                if (lstObj != null)
                {
                    lstModel = (from image in lstObj
                                select new ProductImageManagerModel()
                                {
                                    GUID = image.GUID,
                                    ImageId = image.ImageId,
                                    ImagePath = image.ImagePath,
                                    ProductId = image.ProductId,
                                    Status = image.Status,
                                    Angle = image.Angle
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

        public bool IsExist(long productId,string GUID)
        {
            try
            {
                return objEntity.ej_ProductImage.Where(tbl => tbl.ProductId == productId && tbl.GUID == GUID).Any();
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

        //partha 01-06-13

        public List<ProductImageManagerModel> ProductDefaultImage(ProductDetailsModel productDetails, int total_image_to_generate)
        {
            List<ProductImageManagerModel> lstModel = new List<ProductImageManagerModel>();
            try
            {
                if (productDetails != null)
                {
                    /*
                     * for faster process we did not join any other class
                     * or mapping the data in enetity object
                     */
                    //get metal
                    ej_ProductMetalType metalType = objEntity.ej_ProductMetalType.Where(tbl => tbl.ProductId == productDetails.ProductID && tbl.DefaultMetal == true).FirstOrDefault();
                    if (metalType != null)
                    {
                        int center_stone = 0;
                        string default_side_stone_id = "0";
                        //access the center stone
                        ej_ProductCenterStone centerStone = objEntity.ej_ProductCenterStone.Where(tbl => tbl.ProductId == productDetails.ProductID && tbl.StoneCategoryId == ConstantHelper.STONE_CATEGORY_DIAMOND).FirstOrDefault();
                        if (centerStone != null)
                        {
                            ej_ProductCenterStoneShape centerStoneShape = objEntity.ej_ProductCenterStoneShape.Where(tbl => tbl.ProductCenterStoneId == centerStone.ProductCenterStoneId && tbl.DefaultShape == true).FirstOrDefault();
                            if (centerStoneShape != null)
                            {
                                center_stone = centerStoneShape.StoneShapeId;
                            }
                        }
                        //access the side stone
                        List<ej_ProductSideStone> lstSideStone = objEntity.ej_ProductSideStone.Where(tbl => tbl.ProductId == productDetails.ProductID && tbl.StoneCategoryId == ConstantHelper.STONE_CATEGORY_DIAMOND).ToList();
                        if(lstSideStone!=null)
                        {
                            int total_item = lstSideStone.Count;
                            if(total_item>0)
                            {
                                default_side_stone_id = "0";
                                /*
                                //put default as 0 for all diamond
                                for(int i=0;i<total_item;i++)
                                {
                                    default_side_stone_id += "0-";
                                }
                                //remove the last - from the string
                                if(default_side_stone_id.Length>0)
                                {
                                    default_side_stone_id = default_side_stone_id.Substring(0, default_side_stone_id.Length - 1);
                                }
                                */
                            }
                        }

                        //now create image for default
                        string combaine = metalType.MetalTypeId + "-" + center_stone;
                        string temp_combine = "";
                        if(default_side_stone_id.Length>0)
                        {
                            combaine +="-"+default_side_stone_id;
                        }
                        combaine = productDetails.SKU + "-" + combaine;
                        //get the image for all different angle
                        ej_ProductImage image = null;
                        for(int i=1;i<=total_image_to_generate;i++)
                        {
                            temp_combine = combaine + "-A" + i;
                            image = objEntity.ej_ProductImage.Where(tbl => tbl.GUID == temp_combine).FirstOrDefault();
                            if(image!=null)
                            {
                                if (image.ImagePath.Length > 0)
                                {
                                    lstModel.Add(new ProductImageManagerModel()
                                    {
                                        GUID = image.GUID,
                                        ImagePath = image.ImagePath,
                                        Angle = "A" + i,
                                        ImageId = image.ImageId,
                                        ProductId = image.ProductId,
                                        Status = image.Status
                                    });
                                }
                            }
                        }
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
            return lstModel;
        }

        public bool DeleteAllImage(long productId)
        {
            try
            {
                objEntity.ExecuteStoreCommand("delete from ej_ProductImage where ProductId="+productId+"");
                return true;
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
    }
}
