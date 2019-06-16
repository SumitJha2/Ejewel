using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Configuration.Store
{
    public struct MultiStoreModel
    {
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreUrl { get; set; }
        public int DefaultCurrency { get; set; }
        public bool Status { get; set; }
    }
}
