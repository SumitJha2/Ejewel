using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//include Model
using EJewel.Model.Admin.Configuration.Currency;
namespace EJewel.DAL.Admin.Configuration.Currency
{
    /*
        * Partha Ranjan Nayak
        * @ 15-12-12
        * */
    public class CurrencyDAL
    {
        EJewelEntities objEntity = new EJewelEntities();
        /*
        * Partha Ranjan Nayak
        * @ 15-12-12
        * */
        public CurrencyModel SaveUpdateCurrency(CurrencyModel model)
        {
            if (model.CurrencyID > 0)
            {
                ej_Currency objCurrency = objEntity.ej_Currency.Where(cus => cus.CurrencyId == model.CurrencyID).FirstOrDefault();
                objCurrency.CurrencyTitle = model.Title;
                objCurrency.DecimalPlaces = model.DecimalPlaces;
                objCurrency.CurrencySymbole = model.Symbol;
                objCurrency.DefaultCurrency = model.DefaultCurrency;
                objCurrency.Status = model.Status;
                objCurrency.CurrencyCode = model.Code;
                objCurrency.Value = model.Value;
                objEntity.SaveChanges();               
            }
            else
            {
                ej_Currency currency = this.MappingEntity(model);
                objEntity.AddToej_Currency(currency);
                objEntity.SaveChanges();
                model.CurrencyID = currency.CurrencyId;
            }
           
            return model;
        }
        /*
        * Partha Ranjan Nayak
        * @ 15-12-12
        * */
        public List<CurrencyModel> GetCurrency(int currencyID)
        {
            List<CurrencyModel> lstCurrencyModel = new List<CurrencyModel>();
            if (currencyID > 0)
            {
                ej_Currency currency = objEntity.ej_Currency.Select(cu => cu).Where(cu => cu.CurrencyId == currencyID).FirstOrDefault();
                lstCurrencyModel.Add(this.MappingEntity(currency));
            }
            else
            {
                foreach (var cur in objEntity.ej_Currency.Where(cr=>cr.Status==true))
                {
                    lstCurrencyModel.Add(this.MappingEntity(cur));
                }
            }
            return lstCurrencyModel.OrderBy(ce => ce.CurrencyID).ToList();
        }
        /*
        * Partha Ranjan Nayak
        * @ 15-12-12
        * */
        private CurrencyModel MappingEntity(ej_Currency currency)
        {
            CurrencyModel model = new CurrencyModel();
            model.CurrencyID = currency.CurrencyId;
            model.Title = currency.CurrencyTitle;
            model.Code = currency.CurrencyCode;
            model.Symbol = currency.CurrencySymbole;
            model.DecimalPlaces = currency.DecimalPlaces;
            model.Value = currency.Value;
            model.DefaultCurrency = currency.DefaultCurrency;
            model.Status = currency.Status;
            return model;
        }
        /*
        * Partha Ranjan Nayak
        * @ 15-12-12
        * */
        private ej_Currency MappingEntity(CurrencyModel model)
        {
            ej_Currency currency = new ej_Currency();
            currency.CurrencyId = model.CurrencyID;
            currency.CurrencyTitle = model.Title;
            currency.CurrencyCode = model.Code;
            currency.CurrencySymbole = model.Symbol;
            currency.DecimalPlaces = model.DecimalPlaces;
            currency.Value = model.Value;
            currency.DefaultCurrency = model.DefaultCurrency;
            currency.Status = model.Status;
            return currency;
        }
      /* sumit jha
     * @ 22-01-2013
     * */
        public bool DeleteCurrency(CurrencyModel model)
        {
            ej_Currency objCurrency = objEntity.ej_Currency.Where(cus => cus.CurrencyId == model.CurrencyID).FirstOrDefault();
            objCurrency.Status = model.Status;
            objEntity.SaveChanges();
            return true;
        }
        /* sumit jha
        * @ 22-01-2013
        * */
        public bool IsExistCurrency(CurrencyModel model)
        {
            if (model.CurrencyID > 0)
            {
                return objEntity.ej_Currency.Where(cm => cm.CurrencyId != model.CurrencyID && cm.CurrencyTitle == model.Title && cm.CurrencyCode == model.Code && cm.Status == true).Any();
            }
            else
            {
                return objEntity.ej_Currency.Where(cm =>cm.CurrencyTitle == model.Title && cm.CurrencyCode == model.Code && cm.Status == true).Any();
            }
        }
    }
   
     
}
