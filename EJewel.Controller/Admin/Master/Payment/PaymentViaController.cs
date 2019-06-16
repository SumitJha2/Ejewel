using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Payment;
using EJewel.DAL.Admin.Master.Payment;

namespace EJewel.Controller.Admin.Master.Payment
{
   public class PaymentViaController
    {
       PaymentViaDAL objPaymentViaDAL = new PaymentViaDAL();

       /* sumit jha
       * @26-12-2012
       * */
       public PaymentViaModel SaveUpdatePaymentVia(PaymentViaModel objPaymentVia)
       {
           return objPaymentViaDAL.SaveUpdatePaymentVia(objPaymentVia);
       }
        /* sumit jha
        * @26-12-2012
        * */
       public bool ExistPaymentVia(PaymentViaModel model)
       {
           return objPaymentViaDAL.IsExistPaymentVia(model);
       }
       /* sumit jha
        * @ 14-01-2013
        * */
       public List<PaymentViaModel> GetPaymentVia(int paymentid)
       {
           return objPaymentViaDAL.GetPaymentVia(paymentid);
       }
       /* sumit jha
        * @ 14-01-2013
        * */
       public bool DeletePaymentVia(PaymentViaModel model)
       {
           return objPaymentViaDAL.DeletePaymentVia(model);
       }

       
    }
}
