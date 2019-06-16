using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Configuration.Currency
{
    public class CurrencyModel
    {
        public int CurrencyID { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
        public int DecimalPlaces { get; set; }
        public double Value { get; set; }
        public bool DefaultCurrency { get; set; }
        public bool Status { get; set; }
    }
}
