using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Master.Metal;
using EJewel.Model.Admin.Common;
//DAL
using EJewel.DAL.Admin.Product;

namespace EJewel.Controller.Admin.Product
{
    /// <summary>
    /// Helps to get the product All Details
    /// Partha Ranjan
    /// @ 02-04-13
    /// </summary>
    public class ProductViewController
    {
        ProductViewDAL objDAL = new ProductViewDAL();

        public List<MetalTypeListModel> GetMetalTypeList(long productId)
        {
            return objDAL.GetMetalTypeList(productId);
        }
    }
}
