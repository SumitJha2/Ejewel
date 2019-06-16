using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Payment;

namespace EJewel.DAL.Admin.Master.Payment
{
   public class PaymentViaDAL
    {
       /* sumit jha
        * @26-12-2012
        * */
       EJewelEntities objEntity = new EJewelEntities();
        /* sumit jha
         * @26-12-2012
         * */
       public PaymentViaModel SaveUpdatePaymentVia(PaymentViaModel model)
       {
           if (model.PaymentID > 0)
           {
               ej_PaymentVia objPayment = objEntity.ej_PaymentVia.Where(pv => pv.PaymentId == model.PaymentID).FirstOrDefault();
               objPayment.PaymentVia = model.PaymentOption;
               objPayment.Status = model.Status;
               objEntity.SaveChanges();
           }
           else
           {
               ej_PaymentVia objPayment = this.mapping(model);
               objEntity.AddToej_PaymentVia(objPayment);
               objEntity.SaveChanges();
               model.PaymentID = objPayment.PaymentId;
           }
           return model;

       }
        /* sumit jha
         * @26-12-2012
         * */
       public ej_PaymentVia mapping(PaymentViaModel model)
       {
           ej_PaymentVia objPayment = new ej_PaymentVia();
           objPayment.PaymentVia = model.PaymentOption;
           objPayment.Status = model.Status;
           return objPayment;
       }
        /* sumit jha
         * @26-12-2012
         * */
       public bool IsExistPaymentVia(PaymentViaModel model)
       {
           if (model.PaymentID > 0)
           {
               return objEntity.ej_PaymentVia.Where(pv => pv.PaymentId != model.PaymentID && pv.PaymentVia == model.PaymentOption && pv.Status == true).Any();
           }
           else
           {
               return objEntity.ej_PaymentVia.Where(pv => pv.Status == true).Any(pv => pv.PaymentVia ==model.PaymentOption);
           }

       }
        /* sumit jha
          * @14-01-2013
          * */
       public List<PaymentViaModel> GetPaymentVia(int paymentid)
       {
           List<PaymentViaModel> lstpaymentvia = new List<PaymentViaModel>();       
           if (paymentid > 0)
           {
               ej_PaymentVia objPaymentVia = objEntity.ej_PaymentVia.Where(pv => pv.PaymentId == paymentid && pv.Status == true).FirstOrDefault();
               lstpaymentvia.Add(this.Mapping(objPaymentVia));
           }
           else
           {
               foreach (var obj in objEntity.ej_PaymentVia.Where(pv => pv.Status == true))
               {
                   lstpaymentvia.Add(this.Mapping(obj));
               }

           }                   
           return lstpaymentvia.OrderByDescending(pv=>pv.PaymentID).ToList();
       }
       /* sumit jha
        * @ 14-01-2013
        * */
       public PaymentViaModel Mapping(ej_PaymentVia objPaymentVia)
       {
           PaymentViaModel model = new PaymentViaModel();
           model.PaymentID = objPaymentVia.PaymentId;
           model.PaymentOption = objPaymentVia.PaymentVia;
           model.Status = objPaymentVia.Status;
           return model;
       }
       /* sumit jha
        * @ 14-01-2013
        * */
       public bool DeletePaymentVia(PaymentViaModel model)
       {
           ej_PaymentVia objPaymentVia = objEntity.ej_PaymentVia.Where(pv => pv.PaymentId == model.PaymentID).FirstOrDefault();
           objPaymentVia.Status = model.Status;
           objEntity.SaveChanges();
           return true;
       }
    }
}
