using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Payment;

namespace EJewel.DAL.Admin.Master.Payment
{
  public  class PaymentDAL
    {
      /*
       * sumit jha
       * @24-12-2012
       * */
      EJewelEntities objEntity = new EJewelEntities();

      /*
       * sumit jha
       * @24-12-2012
       * */
      public PaymentModel SaveUpdatePayment(PaymentModel model)
      {
          //function for update
          if (model.PaymentStatusID > 0)
          {
              ej_PaymentStatus objPayment =objEntity.ej_PaymentStatus.Where(sc=>sc.PaymentStatusId==model.PaymentStatusID).FirstOrDefault();
              objPayment.PaymentStatus = model.PaymentStatus;
              objPayment.Status = model.Status;
              objEntity.SaveChanges();
          }
          else
          {
              ej_PaymentStatus objPayment = this.Mapping(model);
              objEntity.AddToej_PaymentStatus(objPayment);
              objEntity.SaveChanges();
              model.PaymentStatusID = objPayment.PaymentStatusId;
          }
          return model;
      }
        /*
       * sumit jha
       * @24-12-2012
       * */
      public ej_PaymentStatus Mapping(PaymentModel model)
      {
          ej_PaymentStatus objPayment = new ej_PaymentStatus();
          objPayment.PaymentStatus = model.PaymentStatus;
          objPayment.Status = model.Status;
          return objPayment;
      }
        /*
        * sumit jha
        * @24-12-2012
        * */
      public bool IsExistPaymentStatus(PaymentModel model)
      {
          if (model.PaymentStatusID > 0)
          {
              return objEntity.ej_PaymentStatus.Where(ps =>ps.PaymentStatus == model.PaymentStatus).Where(st => st.PaymentStatusId != model.PaymentStatusID).Any(st => st.Status == true);
          }
          else
          {
              return objEntity.ej_PaymentStatus.Where(sts => sts.Status == true).Any(sc => sc.PaymentStatus == model.PaymentStatus);
          }
      }
      /* sumit jha
       * @ 11-01-2013
       * */
      public List<PaymentModel> GetPaymentStatus(int paymentid)
      {
          List<PaymentModel> lstpaymentmodel = new List<PaymentModel>();
          if (paymentid > 0)
          {
              ej_PaymentStatus objStatus = objEntity.ej_PaymentStatus.Where(sc => sc.PaymentStatusId == paymentid).FirstOrDefault();
              lstpaymentmodel.Add(this.Mapping(objStatus));
          }
          else
          {
              foreach (var obj in objEntity.ej_PaymentStatus.Where(sc => sc.Status == true))
              {
                  lstpaymentmodel.Add(this.Mapping(obj));
              }
          }
          return lstpaymentmodel;
      }
      /* sumit jha
       * @ 11-01-2013
       *  */
      public PaymentModel Mapping(ej_PaymentStatus objStatus)
      {
          PaymentModel model = new PaymentModel();
          model.PaymentStatusID = objStatus.PaymentStatusId;
          model.PaymentStatus = objStatus.PaymentStatus;
          model.Status = objStatus.Status;
          return model;
      }
        /* sumit jha
      * @ 11-01-2013
      *  */
      public bool DeletePaymentStatus(PaymentModel model)
      {
          ej_PaymentStatus objPayment = objEntity.ej_PaymentStatus.Where(sc=>sc.PaymentStatusId==model.PaymentStatusID).FirstOrDefault();
          objPayment.Status= model.Status;
          objEntity.SaveChanges();
          return true;
      }



    }
}
