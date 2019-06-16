using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Payment;

namespace EJewel.DAL.Admin.Master.Payment
{
    public class OrderStatusDAL
    {
        /* sumit jha
       * @ 26-12-2012
       * */
        EJewelEntities objEntity = new EJewelEntities();
        /* sumit jha
      * @ 26-12-2012
      * */
        public OrderStatusModel SaveUpdateOrderStatus(OrderStatusModel model)
        {
            try
            {
                if (model.OrderStatusID > 0)
                {
                    ej_OrderStatus objOrder = objEntity.ej_OrderStatus.Where(sc => sc.OrderStatusId == model.OrderStatusID).FirstOrDefault();
                    objOrder.OrderStatusName = model.OrderStatusName;
                    objOrder.Status = model.Status;
                    objEntity.SaveChanges();
                }
                else
                {
                    ej_OrderStatus objOrder = this.mapping(model);
                    objEntity.AddToej_OrderStatus(objOrder);
                    objEntity.SaveChanges();
                    model.OrderStatusID = objOrder.OrderStatusId;
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
        /* sumit jha
     * @ 26-12-2012
     * */
        public ej_OrderStatus mapping(OrderStatusModel model)
        {
            try
            {
                ej_OrderStatus objOrder = new ej_OrderStatus();
                objOrder.OrderStatusName = model.OrderStatusName;
                objOrder.Status = model.Status;
                return objOrder;
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
        /* sumit jha
         * @ 26-12-2012
         * */
        public bool IsExistOrderStatus(OrderStatusModel model)
        {
            try
            {
                if (model.OrderStatusID > 0)
                {
                    return objEntity.ej_OrderStatus.Where(os => os.Status == true).Where(os => os.OrderStatusId != model.OrderStatusID).Any(os => os.OrderStatusName == model.OrderStatusName);
                }
                else
                {
                    return objEntity.ej_OrderStatus.Where(os => os.Status == true).Any(os => os.OrderStatusName == model.OrderStatusName);
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
        /*sumit jha
         * @ 11-01-2013
         * */
        public List<OrderStatusModel> GetOrderStatus(int odrstsid)
        {
            try
            {
                List<OrderStatusModel> lstodrstsmodel = new List<OrderStatusModel>();
                if (odrstsid > 0)
                {
                    ej_OrderStatus objOrderStatus = objEntity.ej_OrderStatus.Where(os => os.OrderStatusId == odrstsid && os.Status == true).FirstOrDefault();
                    lstodrstsmodel.Add(this.mapping(objOrderStatus));
                }
                else
                {
                    foreach (var obj in objEntity.ej_OrderStatus.Select(sc => sc).Where(sc => sc.Status == true))
                    {
                        lstodrstsmodel.Add(this.mapping(obj));
                    }

                }
                return lstodrstsmodel.OrderByDescending(os => os.OrderStatusID).ToList();
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
        /* sumit jha
         * @ 11-01-2013
         * */
        public OrderStatusModel mapping(ej_OrderStatus objorderstatus)
        {
            try
            {

                OrderStatusModel model = new OrderStatusModel();
                model.OrderStatusName = objorderstatus.OrderStatusName;
                model.OrderStatusID = objorderstatus.OrderStatusId;
                model.Status = objorderstatus.Status;
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
        /* sumit jha
       * @ 11-01-2013
       * */
        public bool DeleteOrderStatus(OrderStatusModel model)
        {
            try
            {
                ej_OrderStatus objOrderStatus = objEntity.ej_OrderStatus.Where(os => os.OrderStatusId == model.OrderStatusID).FirstOrDefault();
                objOrderStatus.Status = model.Status;
                objEntity.SaveChanges();
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
