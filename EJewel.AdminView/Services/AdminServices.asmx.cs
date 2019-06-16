using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
//add controller
using EJewel.Controller.Admin.Configuration.Currency;
using EJewel.Controller.Admin.Configuration.Store;
using EJewel.Controller.Admin.Master.Stone;
using EJewel.Controller.Admin.Master.Metal;
using EJewel.Controller.Admin.Master.Category;
using EJewel.Controller.Admin.Master.Payment;
using EJewel.Controller.Admin.Product;
using EJewel.Controller.Admin.Common.Sfm;
using EJewel.Controller.Admin.Master.Setting;
using EJewel.Controller.Common;
//add model
using EJewel.Model.Admin.Configuration.Currency;
using EJewel.Model.Admin.Configuration.Store;
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Master.Metal;
using EJewel.Model.Admin.Master.Category;
using EJewel.Model.Admin.Master.Payment;
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Common.Sfm;
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Master.Setting;

using EJewel.Model.Admin.Master.Location;
using EJewel.Controller.Admin.Master.Location;
using EJewel.Controller.Admin.Extras;
using EJewel.Model.Admin.Extras;
namespace EJewel.AdminView.Services
{
    /// <summary>
    /// Summary description for AdminServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AdminServices : System.Web.Services.WebService
    {
        #region Configuration
        ErrorLogController objErrorController = new ErrorLogController();

        #region Excepation
        private ErrorLogModel SetErrorLogModel(Exception ex)
        {
            if (ex != null)
            {
                return new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = ex.InnerException.Message,
                    LogTime = DateTime.Now
                };

            }
            return null;
        }
        #endregion
        #region Cureency Services
        [WebMethod]
        public CurrencyModel SaveUpdateCurrency(CurrencyModel entity)
        {
            try
            {
                CurrencyController controller = new CurrencyController();
                if (!controller.IsExist(entity))
                {
                    return controller.SaveCurrency(entity);

                }
                else
                {
                    throw new Exception("Currency Already Exist.");
                }
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }

        [WebMethod]
        public List<CurrencyModel> GetCurrency(int currencyId)
        {
            try
            {
                CurrencyController objCurrencyController = new CurrencyController();
                return objCurrencyController.GetCurrency(currencyId);
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }
        [WebMethod]
        public bool DeleteCurrency(CurrencyModel model)
        {
            CurrencyController objController = new CurrencyController();
            return objController.DeleteCurrency(model);

        }
        #endregion

        #region MultiStore Services
        [WebMethod]
        public MultiStoreModel SaveUpdateMultiStore(MultiStoreModel model)
        {
            try
            {
                MultiStoreController objMultiStoreController = new MultiStoreController();
                if (!objMultiStoreController.StoreExist(model))
                {
                    return objMultiStoreController.SaveUpdateStore(model);
                }
                else
                {
                    throw new Exception("Store Already Present");
                }
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }
        /* sumit jha
         * @ 25-01-2013
         *  */
        [WebMethod]
        public List<MultiStoreModel> GetMultiStore(int storeid)
        {
            MultiStoreController objController = new MultiStoreController();
            return objController.GetMultiStore(storeid);
        }
        [WebMethod]
        public bool DeleteMultiStore(MultiStoreModel model)
        {
            MultiStoreController objController = new MultiStoreController();
            return objController.DeleteMultiStore(model);
        }
        #endregion

        #endregion

        #region Stone

        #region Stone Category
        [WebMethod]
        public List<StoneCategoryModel> GetStoneCategory(int categoryID)
        {
            try
            {
                return new StoneCategoryController().GetStoneCategoryList(categoryID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Stone Category Type
        [WebMethod]
        public List<StoneCategoryTypeModel> GetStoneCategoryType()
        {
            try
            {
                StoneCategoryTypeController objController = new StoneCategoryTypeController();
                return objController.GetStoneCategoryType();
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }
        #endregion



        [WebMethod]
        public StoneCertificateModel SaveUpdateStoneCertificate(StoneCertificateModel model)
        {
            StoneCerificateController objController = new StoneCerificateController();
            return objController.SaveUpdateStoneCertificate(model);
        }

        #endregion

        #region Metal

        /*
         * Partha Ranjan Nayak
         * 02-02-13
         * This function get the metal type list
         * */
        [WebMethod]
        public List<MetalTypeListModel> GetMetalTypeList()
        {
            try
            {
                MetalTypeController cont = new MetalTypeController();
                return cont.GetMetalTypeList(0, CommonModel.RecordStatus.Both);
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }

        }
        [WebMethod]
        public string SaveUpdateMetalType(MetalTypeModel model)
        {
            try
            {
                MetalTypeController cont = new MetalTypeController();
                if (model.MetalTypeId == 0)
                {

                    //for save
                    if (!cont.IsExist(model.MetalWeightId, model.MetalNameId))
                    {
                        model = cont.SaveUpdateMetalType(model);
                        return "Metal type saved successfully.";
                    }
                    else
                    {
                        return "Metal type already exist.";
                    }

                }
                else
                {
                    //for update
                    cont.SaveUpdateMetalType(model);
                    return "Metal type updated successfully.";
                }

            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }
        /* sumit jha
       * @ 19-03-13
       * */
        [WebMethod]
        public bool DeleteMetalType(int metalTypeId)
        {
            return new MetalTypeController().DeleteMetalType(metalTypeId);
        }
        #endregion

        #region Category

        [WebMethod]
        public string SaveUpdateSubCategory(SubCategoryModel model)
        {
            CategoryController objController = new CategoryController();
            try
            {
                model.CreateDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                //
                if (model.SubCategoryId == 0)
                {
                    if (!objController.IsExistSubCategory(model.CategoryId, model.SubCategoryName))
                    {
                        objController.SaveUpdateSubCategory(model);
                        return "Category saved successfully.";
                    }
                    else
                    {
                        return "Category already exist.";
                    }
                }
                else
                {
                    objController.SaveUpdateSubCategory(model);
                    return "Category updated successfully.";
                }
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }

        /* Partha Ranjan
         * @ 10-01-2013
         * */
        [WebMethod]
        public bool DeleteCategory(int subCategoryId)
        {
            CategoryController objController = new CategoryController();
            return objController.DeleteSubCategory(subCategoryId);
        }

        [WebMethod]
        public List<SubCategoryModel> GetSubCategoryList(int subCategoryId, int currentPageIndex, int pagesize)
        {
            try
            {
                CategoryController objController = new CategoryController();
                return objController.GetSubCategoryList(subCategoryId, currentPageIndex, pagesize, CommonModel.RecordStatus.Both);
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }

        #endregion

        #region PaymentStatus
        /* sumit jha
         * @24-12-2012
         * */
        [WebMethod]
        public PaymentModel SaveUpdatePaymentStaus(PaymentModel objPaymentStatusModel)
        {
            try
            {
                PaymentStatusController objController = new PaymentStatusController();

                if (!objController.PaymentStatusExist(objPaymentStatusModel))
                {
                    return objController.SaveUpdatePaymentStatus(objPaymentStatusModel);
                }
                else
                {
                    throw new Exception("Payment Status Already Exist.");
                }
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }
        [WebMethod]
        public List<PaymentModel> GetPaymentStatus(int paymentid)
        {
            PaymentStatusController objController = new PaymentStatusController();
            return objController.GetPaymentStatus(paymentid);
        }
        [WebMethod]
        public bool DeletePaymentStatus(PaymentModel model)
        {
            PaymentStatusController objController = new PaymentStatusController();
            return objController.DeleteStatus(model);

        }
        #endregion

        #region OrderStatus
        /* sumit jha
         * @26-12-2012
         * */
        [WebMethod]
        public OrderStatusModel SaveUpdateOrderStatus(OrderStatusModel objOrderStatusModel)
        {
            try
            {
                OrderStatusController objController = new OrderStatusController();

                if (!objController.OrderStatusExist(objOrderStatusModel))
                {
                    return objController.SaveUpdateOrderStatus(objOrderStatusModel);
                }
                else
                {
                    throw new Exception("Order Status Already Exist.");
                }
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }

        }
        [WebMethod]
        public List<OrderStatusModel> GetOrderStatus(int Orderstatusid)
        {
            OrderStatusController objController = new OrderStatusController();
            return objController.GetOrderStatus(Orderstatusid);
        }
        [WebMethod]
        public bool DeleteOrderStatus(OrderStatusModel model)
        {
            OrderStatusController objController = new OrderStatusController();
            return objController.DeleteOrderStatus(model);
        }
        #endregion

        #region PaymentVia
        /* sumit jha
         * @26-12-2012
         * */
        [WebMethod]
        public PaymentViaModel SaveUpdatePaymentVia(PaymentViaModel objPaymentViaModel)
        {
            try
            {
                PaymentViaController objController = new PaymentViaController();
                if (!objController.ExistPaymentVia(objPaymentViaModel))
                {
                    return objController.SaveUpdatePaymentVia(objPaymentViaModel);
                }
                else
                {
                    throw new Exception("Payment Option Already Exist");
                }
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }

        /* sumit jha
         * @ 14-01-2013
         * */
        [WebMethod]
        public List<PaymentViaModel> GetPaymentVia(int paymentid)
        {
            PaymentViaController objController = new PaymentViaController();
            return objController.GetPaymentVia(paymentid);
        }
        /* sumit jha
         * @ 14-01-2013
         * */
        [WebMethod]
        public bool DeletePaymentVia(PaymentViaModel model)
        {
            PaymentViaController objController = new PaymentViaController();
            return objController.DeletePaymentVia(model);
        }
        #endregion

        #region ShipmentMethod
        /* sumit jha
         * @ 26-12-2012
         * */
        [WebMethod]
        public ShipmentMethodModel SaveUpdateShipmentModel(ShipmentMethodModel model)
        {
            try
            {
                ShipmentMethodController objController = new ShipmentMethodController();
                if (!objController.ExistShipmentMethod(model))
                {
                    return objController.SaveUpdateShipment(model);
                }
                else
                {
                    throw new Exception("Shipment Method Already Exist");
                }
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }
        /* sumit jha
         * @ 14-01-2013
         * */
        [WebMethod]
        public List<ShipmentMethodModel> GetShipmentMethod(int shipmentid)
        {
            ShipmentMethodController objController = new ShipmentMethodController();
            return objController.GetShipmentMethod(shipmentid);
        }
        [WebMethod]
        public bool DeleteShipmentMethod(ShipmentMethodModel model)
        {
            ShipmentMethodController objController = new ShipmentMethodController();
            return objController.DeleteShipmentMethod(model);
        }
        #endregion

        #region TaxClass
        /* sumit jha
         * @ 27-12-2012
         * */
        [WebMethod]
        public TaxModel SaveUpdateTaxModel(TaxModel model)
        {
            try
            {
                TaxController objController = new TaxController();
                if (!objController.ExistTax(model))
                {
                    return objController.SaveUpdateTax(model);
                }
                else
                {
                    throw new Exception("Tax Method Already Exist");
                }
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }
        [WebMethod]
        public List<TaxModel> GetTax(int taxid)
        {
            TaxController objController = new TaxController();
            return objController.GetTax(taxid);
        }
        /* sumit jha
         * @ 15-01-2013
         * */
        [WebMethod]
        public bool DeleteTax(TaxModel model)
        {
            TaxController objController = new TaxController();
            return objController.DeleteTax(model);
        }
        #endregion

        #region Product
        /*
         * Partha Ranjan
         * @ 19-01-2013
         * */
        #region Product Details
        /*
         * Partha Ranjan
         * @ 19-01-2013
         * */
        [WebMethod]
        public ProductDetailsModel SaveUpdateProductDetails(ProductDetailsModel model)
        {
            ProductDetailsController controller = new ProductDetailsController();
            try
            {
                //check that the mode of the operation
                if (model.ProductID == 0)
                {
                    //for save
                    //validation sku
                    if (!controller.ExistProductSKU(model.SKU.Trim()))
                    {
                        //check for the product name/titil
                        if (!controller.ExistProductTitle(model.ProductTitle.Trim()))
                        {
                            model = controller.SaveUpdateProductDetails(model);
                        }
                        else
                        {
                            throw new Exception("Product Title Alraday Present");
                        }
                    }
                    else
                    {
                        throw new Exception("SKU Alraday Present");
                    }

                }
                else
                {
                    //for update
                }
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
            return model;
        }
        /*
         * Partha Ranjan
         * @ 21-01-2013
         * This function used to access the data of the product details
         * */
        [WebMethod]
        public ProductDetailsModel GetProductDetails(long productID)
        {
            try
            {
                //get the data from the controler
                ProductDetailsController cont = new ProductDetailsController();
                return cont.GetProductDetails(productID);
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }

        [WebMethod]
        public List<ProductDetailsModel> GetProductList(long productid, int currentPageIndex, int perPageSize, int categoryId, int subCategoryId, string sku, bool bestselling, bool newproduct, bool mengift, bool womengift, bool childgift, bool othergift, bool sale, bool IsExtraOrdinary)
        {
            try
            {
                List<ProductDetailsModel> lstProductModel = new List<ProductDetailsModel>();
                ProductDetailsController objController = new ProductDetailsController();
                lstProductModel = objController.GetProductList(productid);
                if (lstProductModel != null && lstProductModel.Count > 0)
                {
                    if (categoryId > 0)
                    {
                        lstProductModel = lstProductModel.Where(tbl => tbl.PrimaryCategoryId == categoryId).ToList();
                    }
                    if (subCategoryId > 0)
                    {
                        lstProductModel = lstProductModel.Where(tbl => tbl.SubCategoryID == subCategoryId).ToList();
                    }
                    if (sku != "")
                    {
                        lstProductModel = lstProductModel.Where(tbl => tbl.SKU == sku).ToList();
                    }
                    // used for filter in product search
                    if (bestselling == true)
                    {
                        lstProductModel = lstProductModel.Where(tbl => tbl.BestSelling == true).ToList();
                    }
                    if (newproduct == true)
                    {
                        lstProductModel = lstProductModel.Where(tbl => tbl.NewProduct == true).ToList();
                    }
                    if (mengift == true)
                    {
                        lstProductModel = lstProductModel.Where(tbl => tbl.MenGift == true).ToList();
                    }
                    if (womengift == true)
                    {
                        lstProductModel = lstProductModel.Where(tbl => tbl.WomenGift == true).ToList();
                    }
                    if (childgift == true)
                    {
                        lstProductModel = lstProductModel.Where(tbl => tbl.ChildrenGift == true).ToList();
                    }
                    if (othergift == true)
                    {
                        lstProductModel = lstProductModel.Where(tbl => tbl.OtherGift == true).ToList();
                    }
                    if (sale == true)
                    {
                        lstProductModel = lstProductModel.Where(tbl => tbl.OnSale == true).ToList();
                    }
                    if (IsExtraOrdinary == true)
                    {
                        lstProductModel = lstProductModel.Where(tbl => tbl.IsExtraOrdinary == true).ToList();
                    }
                }
                return lstProductModel.Skip(currentPageIndex * perPageSize).Take(perPageSize).ToList();
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }
        #endregion

        #region Product Metal Details
        /*
         * Partha Ranjan
         * @ 19-01-2013
         * */
        [WebMethod]
        public List<ProductMetalModel> GetProductMetalList()
        {
            ProductMetalController cont = new ProductMetalController();
            try
            {
                return cont.GetProductMetalList(0, CommonModel.RecordStatus.Both);
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }

        #endregion
        #endregion

        #region Single Field
        /*
         * Partha Ranjan
         * @ 30-01-13
         * This id function for get the single filed list
         * */
        [WebMethod]
        public List<SfmModel> GetSfmList(string view_name, int currentPageIndex, int perPageSize)
        {
            try
            {
                SfmController cont = new SfmController();
                return cont.GetSfmList(0, CommonModel.RecordStatus.Both, cont.GetPageView(view_name), currentPageIndex, perPageSize);
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }
        /* 
         * sumit jha
         * @ 20-02-2013
         * */

        [WebMethod]
        public string SaveUpdateSfm(SfmModel model, string pagename)
        {
            SfmController objController = new SfmController();
            try
            {
                SfmModel.PageName _pagename = objController.GetPageView(pagename);
                if (_pagename != SfmModel.PageName.None)
                {
                    if (model.AutoID == 0)
                    {
                        //for save 
                        if (!objController.IsExsit(model.Name, _pagename))
                        {
                            objController.SaveUpdateSfm(model, _pagename);
                            return "Data saved successfully.";
                        }
                        else
                        {
                            //User Defined Message - Logic Retutrns
                            return "This Name already exist.";
                        }
                    }
                    else
                    {
                        //for update
                        objController.SaveUpdateSfm(model, _pagename);
                        return "Data updated successfully";
                    }
                }
                else
                {
                    return "Invalid view";
                }

            }
            catch (Exception ex)
            {
                // Exception Compilation Error
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }
        /*
         * sumit
         * @ 21-02-2013
         * */
        [WebMethod]
        public bool DeleteSfm(int id, string view)
        {
            SfmController objController = new SfmController();
            SfmModel.PageName _pagename = objController.GetPageView(view);
            return objController.DeleteSfm(id, _pagename);
        }

        #endregion

        #region Setting

        [WebMethod]
        public PriceModel SaveUpdate_Setting_Setter_Price(PriceModel model, string view)
        {
            try
            {
                PriceController cont = new PriceController();
                PriceModel.PageName pgName = cont.GetPageName(view);
                if (pgName != PriceModel.PageName.None)
                {
                    if (model.AutoID == 0)
                    {
                        //save mode
                        //check that the same sub category is present or not
                        if (!cont.IsExist(model.SubCategoryId, pgName))
                        {
                            //save
                            model = cont.SaveUpdatePrice(model, pgName);
                        }
                        else
                        {
                            throw new Exception("Price Details already present");
                        }
                    }
                    else
                    {
                        //update mode
                        model = cont.SaveUpdatePrice(model, pgName);
                    }
                    return model;
                }
                else
                {
                    throw new Exception("Invalid view name");
                }
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }

        [WebMethod]
        public string SaveUpdateRingSize(RingSizeModel model)
        {
            try
            {
                RingSizeController cont = new RingSizeController();
                if (model.RingSizeId == 0)
                {
                    //save mode
                    //check that the same sub category is present or not
                    if (!cont.IsExist(model.SubCategoryId, model.RingSize))
                    {
                        //save
                        cont.SaveUpdateRingSize(model);
                        return "Ring size details saved successfully.";
                    }
                    else
                    {
                        return "Ring size already present";
                    }
                }
                else
                {
                    //update mode
                    cont.SaveUpdateRingSize(model);
                    return "Ring size details updated successfully.";
                }
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }

        # region RingSize
        /* sumit jha
     * 28-02-28
     * get ring size list
     * */
        [WebMethod]
        public List<RingSizeModel> GetRingSizeList(int ringSizeId)
        {
            RingSizeController objController = new RingSizeController();
            return objController.GetRingSizeList(ringSizeId, CommonModel.RecordStatus.Both);
        }
        /* sumit jha
         * @ 28-02-2013
         * */
        [WebMethod]
        public bool DeleteRingSize(int ringsizeid)
        {
            RingSizeController objController = new RingSizeController();
            return objController.DeleteRingSize(ringsizeid);
        }
        #endregion
        #endregion

        #region Stone
        /*
         * Partha
         * @ 11-02-13
         * This service will manage stone cut,clarity and type
         * */
        [WebMethod]
        public string SaveUpdateStoneSpecification(StoneSpecificationModel model, string view)
        {
            try
            {
                StoneSpecificationController cont = new StoneSpecificationController();

                StoneSpecificationModel.PageName pageName = cont.GetPageName(view);
                if (pageName != StoneSpecificationModel.PageName.None)
                {
                    //check that the mode of the opeation
                    if (model.AutoID == 0)
                    {
                        //for save
                        //check that the same name is present ot not
                        //hard code for stone and 
                        if (!cont.IsExist(model.StoneCategoryId, model.Name, pageName))
                        {
                            //save
                            cont.SaveUpdateStoneSpecification(model, pageName);
                            return "Data saved successfully.";
                        }
                        else
                        {
                            return "Data already present";
                        }
                    }
                    else
                    {
                        //for update
                        cont.SaveUpdateStoneSpecification(model, pageName);
                        return "Data updated successfully.";
                    }
                }
                else
                {
                    return "Invalid page";
                }
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }

        [WebMethod]
        public List<StoneSpecificationModel> GetStoneSpecificationList(int id, string pageName, int currentPageIndex, int perPageSize)
        {
            try
            {
                StoneSpecificationController cont = new StoneSpecificationController();
                return cont.GetStoneSpecificationList(id, cont.GetPageName(pageName), CommonModel.RecordStatus.Both, currentPageIndex, perPageSize);
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }

        [WebMethod]
        public List<StoneSpecificationModel> GetStoneSpecificationListFromCategory(int categoryID, string pageName)
        {
            try
            {
                StoneSpecificationController cont = new StoneSpecificationController();
                if (pageName == "shape")
                {
                    return cont.GetStoneSpecificationListForShape(0,StoneShapeModel.ShapeVisibility.BOTH, CommonModel.RecordStatus.Enabled).Where(tbl => tbl.StoneCategoryId == categoryID).ToList();
                }
                else
                {
                    return cont.GetStoneSpecificationListFromCategory(categoryID, cont.GetPageName(pageName), CommonModel.RecordStatus.Enabled);
                }
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));

                throw ex;
            }
        }
        /* sumit jha
         * @19-03-2013
         * */
        [WebMethod]
        public bool DeleteStoneSpecification(int id, string pageName)
        {
            StoneSpecificationController cont = new StoneSpecificationController();
            return cont.DeleteStoneSpecification(id, cont.GetPageName(pageName));
        }

        #endregion

        #region SettingTypeNew

        [WebMethod]
        public string SaveUpdateStoneCategorySettingType(StoneCategorySettingTypeModel model)
        {
            try
            {
                StoneCategorySettingTypeController controller = new StoneCategorySettingTypeController();
                model.Price = Math.Round(model.Price, 2);
                if (model.StoneCategorySettingTypeId == 0)
                {
                    if (!controller.IsExist(model.StoneCategoryTypeId, model.SettingTypeId))
                    {
                        controller.SaveUpdateStoneCategorySettingType(model);
                        return "Category setting type details saved successfully.";
                    }
                    else
                    {
                        return "This setting type already exist.";
                    }
                }
                else
                {
                    controller.SaveUpdateStoneCategorySettingType(model);
                    return "Category setting type details updated successfully.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        [WebMethod]
        public List<StoneCategorySettingTypeModel> StoneSettingTypeList(int stoneCategorySettingTypeId)
        {
            return new StoneCategorySettingTypeController().StoneSettingTypeList(stoneCategorySettingTypeId, CommonModel.RecordStatus.Both);
        }

        [WebMethod]
        public bool DeleteStoneSettingType(int stonecategorysettingtypeid)
        {
            return new StoneCategorySettingTypeController().DeleteStoneSettingType(stonecategorysettingtypeid);
        }

        #endregion

        #region Side Stone
        [WebMethod]
        public string SaveUpdateStone(SideStoneModel model)
        {
            try
            {
                SideStoneController objController = new SideStoneController();
                if (model.SideStoneId == 0)
                {
                    //save
                    objController.SaveUpdateSideStone(model);
                    return "Side stone saved successfully.";
                }
                else
                {
                    //update
                    objController.SaveUpdateSideStone(model);
                    return "Side stone updated successfully.";
                }

            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;

            }
        }
        [WebMethod]
        public List<SideStoneModel> GetSideStoneList(int sidestoneid, int currentPageIndex, int pagesize, int stonecategoryId, int shapeId, int colorId, int cutId, int clarityId, int typeId, double carat)
        {
            List<SideStoneModel> lstmodel = new List<SideStoneModel>();
            lstmodel = new SideStoneController().GetSideStoneList(sidestoneid, CommonModel.RecordStatus.Both).ToList();
            if (lstmodel.Count > 0)
            {
                if (stonecategoryId > 0)
                {
                    lstmodel = lstmodel.Where(lst => lst.StoneCategoryId == stonecategoryId).ToList();
                }
                if (shapeId > 0)
                {
                    lstmodel = lstmodel.Where(lst => lst.StoneShapeId == shapeId).ToList();
                }
                if (colorId > 0)
                {
                    lstmodel = lstmodel.Where(lst => lst.StoneColorId == colorId).ToList();
                }
                if (cutId > 0)
                {
                    lstmodel = lstmodel.Where(lst => lst.StoneCutId == cutId).ToList();
                }
                if (clarityId > 0)
                {
                    lstmodel = lstmodel.Where(lst => lst.StoneClarityId == clarityId).ToList();
                }
                if (typeId > 0)
                {
                    lstmodel = lstmodel.Where(lst => lst.StoneTypeId == typeId).ToList();
                }
                if (carat >= 0)
                {
                    lstmodel = lstmodel.Where(lst => lst.StoneCarate > carat).ToList();
                }

            }
            return lstmodel.OrderByDescending(lst => lst.SideStoneId).Skip(currentPageIndex * pagesize).Take(pagesize).ToList();
        }
        /* sumit jha
         * @ 02-04-2013
         * */
        [WebMethod]
        public bool DeleteSideStone(int sidestoneid)
        {
            return new SideStoneController().DeleteSideStone(sidestoneid);
        }

        #endregion

        #region Center Stone
        [WebMethod]
        public string SaveUpdateCenterStone(CenterStoneModel model)
        {
            CenterStoneController cont = new CenterStoneController();

            if (model.StoneId == 0)
            {
                //for save
                if (!cont.ExistSKU(model.SKU, CenterStoneModel.CenterStoneProvider.FascinatingDiamonds))
                {
                    cont.SaveUpdateCenterStone(model, CenterStoneModel.CenterStoneProvider.FascinatingDiamonds);
                    return "Center Stone Details Save Successfully.";
                }
                else
                {
                    return "SKU Already Present.";
                }
            }
            else
            {
                //for update
                cont.SaveUpdateCenterStone(model, CenterStoneModel.CenterStoneProvider.FascinatingDiamonds);
                return "Center Stone Details Update Successfully.";
            }
        }

        [WebMethod]
        public List<CenterStoneModel> GetCenterStoneList(int provider, int pageIndex, int perPage, int shapeId, int cutId, int colorId, int clarityId, double carat, string sku)
        {
            List<CenterStoneModel> lstmodel = new List<CenterStoneModel>();
            if (provider == 1)
            {
                lstmodel = new CenterStoneController().GetCenterStoneList(pageIndex, perPage, CenterStoneModel.CenterStoneProvider.FascinatingDiamonds, CommonModel.RecordStatus.Both);
            }
            else if (provider == 2)
            {
                lstmodel = new CenterStoneController().GetCenterStoneList(pageIndex, perPage, CenterStoneModel.CenterStoneProvider.Rapnet, CommonModel.RecordStatus.Both);
            }
            if (lstmodel.Count > 0)
            {
                // filter used for shape
                if (shapeId > 0)
                {
                    lstmodel = lstmodel.Where(lst => lst.StoneShapeId == shapeId).ToList();
                }
                // filter used for cut
                if (cutId > 0)
                {
                    lstmodel = lstmodel.Where(lst => lst.StoneCutId == cutId).ToList();
                }
                // filter used for color
                if (colorId > 0)
                {
                    lstmodel = lstmodel.Where(lst => lst.StoneColorId == colorId).ToList();
                }
                // filter used for color
                if (clarityId > 0)
                {
                    lstmodel = lstmodel.Where(lst => lst.StoneClarityId == clarityId).ToList();
                }
                // filter used for carat
                if (carat > 0)
                {
                    lstmodel = lstmodel.Where(lst => lst.StoneCarate >= carat).ToList();
                }
                if (sku != null)
                {
                    lstmodel = lstmodel.Where(lst => lst.SKU == sku.Trim()).ToList();
                }
            }
            return lstmodel.OrderByDescending(tbl => tbl.StoneId).ToList();
        }

        [WebMethod]

        public List<string> GetSKUSuggestion(int provider, string SKU)
        {
            if (provider == 1)
            {
                return new CenterStoneController().GetSKUSuggestion(SKU, CenterStoneModel.CenterStoneProvider.FascinatingDiamonds);
            }
            else if (provider == 2)
            {
                return new CenterStoneController().GetSKUSuggestion(SKU, CenterStoneModel.CenterStoneProvider.Rapnet);
            }
            return new List<string>();
        }
        #endregion

        #region Location




        #region Country


        [WebMethod]
        public string SaveUpdateCountry(CountryModel model)
        {



            CountryController cont = new CountryController();

            if (model.CountryID == 0)
            {
                //for save
                if (!cont.IsExistCountry(model.CountryName))
                {
                    cont.SaveUpdateCountry(model);
                    return "Country  Details Save Successfully.";
                }
                else
                {
                    return "CountryName Already Present.";
                }
            }
            else
            {
                //for update
                bool status = cont.IsExistCountry(model.CountryID, model.CountryName);
                if (status == false)
                {
                    cont.SaveUpdateCountry(model);
                    return "Country  Details Update Successfully.";
                }
                else
                {
                    return "CountryName Already Present.";
                }
            }





        }




        [WebMethod]
        public List<CountryModel> GetCountryList(int CountryID)
        {
            try
            {
                CountryController cont = new CountryController();
                return cont.GetCountryList(CountryID,CommonModel.RecordStatus.Both);
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }

        }



        //[WebMethod]
        //public List<CountryModel> GetCountryListByCountryID(int CountryID)
        //{
        //    try
        //    {
        //        CountryController cont = new CountryController();
        //        return cont.GetCountryListByCountryID(CountryID, CommonModel.RecordStatus.Both);
        //    }
        //    catch (Exception ex)
        //    {
        //        objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
        //        throw ex;
        //    }

        //}

        #endregion


        #region State
        [WebMethod]
        public string SaveUpdateState(StateModel model)
        {
            StateController cont = new StateController();

            if (model.StateId == 0)
            {
                //for save
                if (!cont.IsExistState(model.CountryId, model.StateId, model.StateName))
                {
                    cont.SaveUpdateState(model);
                    return "State  Details Save Successfully.";
                }
                else
                {
                    return "StateName Already Present.";
                }
            }
            else
            {
                //for update
                bool result = cont.IsExistState(model.CountryId, model.StateId, model.StateName);
                if (result == false)
                {
                    cont.SaveUpdateState(model);
                    return "State  Details Update Successfully.";
                }
                else
                {
                    return "StateName Already Present.";
                }
            }
        }
        [WebMethod]
        public List<StateModel> GetStateList(int StateID)
        {
            try
            {
                StateController cont = new StateController();
                return cont.GetStateList(StateID, CommonModel.RecordStatus.Both);
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }
        }
        #endregion


        #region City
        [WebMethod]
        public string SaveUpdateCity(CityModel model)
        {
            CityController cont = new CityController();

            if (model.StateId == 0)
            {
                //for save
                if (!cont.IsExistCity(model.CountryId, model.StateId, model.CityId, model.CityName))
                {
                    cont.SaveUpdateCity(model);
                    return "City  Details Save Successfully.";
                }
                else
                {
                    return "CityName Already Present.";
                }
            }
            else
            {
                //for update
                bool result = cont.IsExistCity(model.CountryId, model.StateId, model.CityId, model.CityName);
                if (result == false)
                {
                    cont.SaveUpdateCity(model);
                    return "City  Details Update Successfully.";
                }
                else
                {
                    return "CityName Already Present.";
                }
            }
        }

        [WebMethod]
        public List<CityModel> GetCityList(int CityID)
        {
            try
            {
                CityController cont = new CityController();
                return cont.GetCityList(CityID,CommonModel.RecordStatus.Both);
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }

        }



        [WebMethod]
        public List<CityModel> GetCityListByCityID(int cityID)
        {
            try
            {
                CityController cont = new CityController();
                return cont.GetCityList(cityID, CommonModel.RecordStatus.Both);
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }

        }


        #endregion


        #region ZipCode

        #region ZipCode
        [WebMethod]
        public string SaveUpdateZipCode(ZipCodeModel model)
        {
            ZipCodeController cont = new ZipCodeController();

            if (model.ZipCodeID == 0)
            {
                //for save
                if (!cont.IsExistZipCode(model.CountryID, model.ZipCodeID, model.ZipCode))
                {
                    cont.SaveUpdateZipCode(model);
                    return "ZipCode  Details Save Successfully.";
                }
                else
                {
                    return "ZipCode Already Present.";
                }
            }
            else
            {
                //for update
                bool result = cont.IsExistZipCode(model.CountryID, model.ZipCodeID, model.ZipCode);
                if (result == false)
                {
                    cont.SaveUpdateZipCode(model);
                    return "ZipCode  Details Update Successfully.";
                }
                else
                {
                    return "ZipCode Already Present.";
                }
            }
        }

        [WebMethod]
        public List<ZipCodeModel> GetZipCodeList()
        {
            try
            {
                ZipCodeController cont = new ZipCodeController();
                return cont.GetZipCodeList(CommonModel.RecordStatus.Both);
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }

        }


        [WebMethod]
        public List<ZipCodeModel> GetZipCodeListByZipCodeID(int zipcodeID)
        {
            try
            {
                ZipCodeController cont = new ZipCodeController();
                return cont.GetZipCodeListByZipCodeID(zipcodeID, CommonModel.RecordStatus.Both);
            }
            catch (Exception ex)
            {
                objErrorController.SetErrorLog(this.SetErrorLogModel(ex));
                throw ex;
            }

        }

        #endregion


        #endregion

        #endregion

        /* sumit jha
         * @ 06-05-2013
         * */
        [WebMethod]
        public string SaveUpdateStoneShape(StoneShapeModel model)
        {
            StoneShapeController objController = new StoneShapeController();
            CenterStoneController cont = new CenterStoneController();

            if (model.StoneShapeId == 0)
            {
                //for save
                if (!objController.IsExist(model.StoneCategoryId, model.ShapeId))
                {
                    objController.SaveUpdate(model);
                    return "Shape Saved Successfully.";
                }
                else
                {
                    return "Shape already assigned to the given category.";
                }
            }
            else
            {
                //for update
                objController.SaveUpdate(model);
                return "Shape updated Successfully.";
            }
        }
        /* sumit jha
         * @ 06-05-2012
         * */
        [WebMethod]
        public List<StoneShapeModel> GetStoneShapeList(int stoneShapeId, int currentPageIndex, int perPageSize)
        {
            return new StoneShapeController().StoneShapeList(stoneShapeId,StoneShapeModel.ShapeVisibility.BOTH, CommonModel.RecordStatus.Both);
        }
        /* sumit jha
         * @ 06-05-2013
         * */
        [WebMethod]
        public bool DeleteStoneShape(int stoneShapeId)
        {
            return new StoneShapeController().Delete(stoneShapeId);
        }

        /* sumit jha
       * @ 09-05-2013
       * */
        [WebMethod]
        public List<string> GetSkuByName(string name)
        {
            return new ProductDetailsController().GetSkuByName(name);
        }
        [WebMethod]
        public List<SubCategoryModel> GetSubCategoryListFromCategory(int categoryID)
        {
            return new CategoryController().GetSubCategoryListFromCategory(categoryID, CommonModel.RecordStatus.Enabled);
        }
        #region News
        [WebMethod]
        public NewsModel SaveUpdateNews(NewsModel model)
        {

            return new NewsController().SaveUpdateNews(model);
        }
        [WebMethod]
        public List<NewsModel> GetNewsDetails(int newsId)
        {
            return new NewsController().GetNewsDetails(newsId, CommonModel.RecordStatus.Both);
        }
        [WebMethod]
        public bool DeleteNews(int newsId)
        {
            return new NewsController().DeleteNewsDetails(newsId);
        }
        #endregion
    }
}
