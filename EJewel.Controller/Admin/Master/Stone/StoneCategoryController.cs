using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Master.Stone;
//dal
using EJewel.DAL.Admin.Master.Stone;
namespace EJewel.Controller.Admin.Master.Stone
{
    /// <summary>
    /// Stone Category Controller
    /// </summary>
    public class StoneCategoryController
    {
        /// <summary>
        /// Get Stone Category List
        /// </summary>
        /// <param name="categoryID">category id</param>
        /// <returns>collection of category</returns>
        public List<StoneCategoryModel> GetStoneCategoryList(int category)
        {
            return new StoneCategoryDAL().GetStoneCategoryList(category);
        }
    }
}
