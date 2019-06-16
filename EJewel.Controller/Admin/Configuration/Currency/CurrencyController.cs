using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//include Model
using EJewel.Model.Admin.Configuration.Currency;
using EJewel.Model.Admin.Configuration.Store;
//include DAL
using EJewel.DAL.Admin.Configuration.Currency;
using EJewel.DAL.Admin.Configuration.Store;

namespace EJewel.Controller.Admin.Configuration.Currency
{
    public class CurrencyController
    {
        CurrencyDAL objCurrencyDAL = new CurrencyDAL();
        public CurrencyModel SaveCurrency(CurrencyModel model)
        {
            return objCurrencyDAL.SaveUpdateCurrency(model);
        }
        //get the currency
        public List<CurrencyModel> GetCurrency(int currencyId)
        {
            return objCurrencyDAL.GetCurrency(currencyId);
        }
        /*sumit 
         * @ 22-01-2013
         * */
        public bool IsExist(CurrencyModel model)
        {
            return objCurrencyDAL.IsExistCurrency(model);
        }
        /*sumit 
       * @ 22-01-2013
       * */
        public bool DeleteCurrency(CurrencyModel model)
        {
            return objCurrencyDAL.DeleteCurrency(model);
        }
        
        
    }
}
