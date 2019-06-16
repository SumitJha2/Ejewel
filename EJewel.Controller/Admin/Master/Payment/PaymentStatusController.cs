using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Payment;
using EJewel.DAL.Admin.Master.Payment;

namespace EJewel.Controller.Admin.Master.Payment
{
    public class PaymentStatusController
    {
        /* Sumit Jha
         * @ 24-12-2012
         * */
        PaymentDAL objPaymentDAL = new PaymentDAL();
        public PaymentModel SaveUpdatePaymentStatus(PaymentModel objPaymentModel)
        {
            return objPaymentDAL.SaveUpdatePayment(objPaymentModel);
        }
        /* Sumit Jha
        * @ 24-12-2012
        * */
        public bool PaymentStatusExist(PaymentModel model)
        {
            return objPaymentDAL.IsExistPaymentStatus(model);
        }
        /* sumit jha
         * @ 11-01-2013
         * */
        public List<PaymentModel> GetPaymentStatus(int paymentid)
        {
            return objPaymentDAL.GetPaymentStatus(paymentid);
        }
        /* sumit jha
         * @ 11-01-2013
         * */
        public bool DeleteStatus(PaymentModel model)
        {
            return objPaymentDAL.DeletePaymentStatus(model);
        }
    }
}
