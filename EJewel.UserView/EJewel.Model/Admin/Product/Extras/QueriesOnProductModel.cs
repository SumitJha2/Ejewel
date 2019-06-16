using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Product.Extras
{
    public class QueriesOnProductModel
    {
        public long ProductQueriesId { get; set; }
        public long ProductId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }     

        public string sku { get; set; }

    }
}
