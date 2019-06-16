using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL.Admin.Master.Payment;
using EJewel.Model.Admin.Master.Payment;

namespace EJewel.Controller.Admin.Master.Payment
{
   public class TaxController
    {
       /* sumit jha
        * @ 26-12-2012
        * */
       TaxDAL objTaxDal = new TaxDAL();
       public TaxModel SaveUpdateTax(TaxModel objModel)
       {
           return objTaxDal.SaveUpdateTax(objModel);
       }
       /* sumit jha
       * @ 26-12-2012
       * */
       public bool ExistTax(TaxModel model)
       {
           return objTaxDal.IsExistTax(model);
       }
       /* sumit jha
        * @ 15-01-2013
        * */
       public List<TaxModel> GetTax(int taxid)
       {
           return objTaxDal.GetTax(taxid);
       }
       /* sumit jha
        * @ 15-01-2013
        * */
       public bool DeleteTax(TaxModel model)
       {
           return objTaxDal.DeleteTax(model);
       }
    }
}
