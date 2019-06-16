using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Product.Extras;
using EJewel.DAL.Admin.Product.Extras;

namespace EJewel.Controller.Admin.Product.Extras
{
   public class QueriesOnProductController
    {
       QueriesOnProductDAL objDAL = new QueriesOnProductDAL();
       public QueriesOnProductModel SaveUpdateQueriesOnProduct(QueriesOnProductModel model)
       {
           return objDAL.SaveUpdateProductDAL(model);
       }
       public List<QueriesOnProductModel> GetQueriesOnProduct(long queriesonproductId)
       {
           return objDAL.GetQueriesOnProduct(queriesonproductId);
       }
       public bool DeleteQueriesOnProduct(long queriesonproductId)
       {
           return objDAL.DeleteQueriesOnProduct(queriesonproductId);
       }
    }
}
