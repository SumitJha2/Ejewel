using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model
using EJewel.Model.Admin.Master.Setting;
using EJewel.Model.Admin.Common;
//dal
using EJewel.DAL.Admin.Master.Setting;

namespace EJewel.Controller.Admin.Master.Setting
{
    public class PriceController
    {
        PriceDAL objDAL = new PriceDAL();
        string _pageName = "",_lableHeading="";

        /// <summary>
        /// Get the page name enum
        /// </summary>
        /// <param name="view_name">view name</param>
        /// <returns>page name enum</returns>
        public PriceModel.PageName GetPageName(string view_name)
        {
            PriceModel.PageName pgName = PriceModel.PageName.None;
            switch (view_name)
            {
                case "setter":
                    {
                        pgName = PriceModel.PageName.SetterPrice;
                        this.PageName = "Setter Price";
                    }
                    break;
                case "setting":
                    {
                        pgName = PriceModel.PageName.SettingPrice;
                        this.PageName = "Setting Price";
                    }
                    break;
            }
            return pgName;
        }

        /// <summary>
        /// Get the page name of price
        /// </summary>
        public string PageName
        {
            private set { _pageName = value; }
            get { return _pageName; }
        }

        /// <summary>
        /// Save and update the price of setting & setter
        /// </summary>
        /// <param name="model">price model</param>
        /// <param name="pgName">page name</param>
        /// <returns>price model</returns>
        public PriceModel SaveUpdatePrice(PriceModel model, PriceModel.PageName pgName)
        {
            return objDAL.SaveUpdatePrice(model, pgName);
        }

        /// <summary>
        /// Check that the price category is present or not
        /// </summary>
        /// <param name="subcategoryId">sub category</param>
        /// <param name="pgName">page name</param>
        /// <returns>boolean</returns>
        public bool IsExist(int subcategoryId, PriceModel.PageName pgName)
        {
            return objDAL.IsExist(subcategoryId, pgName);
        }

        /// <summary>
        /// Get orice list from price id
        /// </summary>
        /// <param name="priceID">price id</param>
        /// <param name="rStatus">record status</param>
        /// <param name="pgName">page name</param>
        /// <returns>collection of price list</returns>
        public List<PriceModel> GetPriceList(int priceID, CommonModel.RecordStatus rStatus, PriceModel.PageName pgName)
        {
            return objDAL.GetPriceList(priceID, rStatus, pgName);
        }

        /// <summary>
        /// Get the price details from the sub category
        /// </summary>
        /// <param name="subCategoryId">subcategory id</param>
        /// <param name="rStatus">record status</param>
        /// <param name="pgName">page name</param>
        /// <returns>collection of price</returns>
        public List<PriceModel> GetPriceListFromSubCategory(int subCategoryId, CommonModel.RecordStatus rStatus, PriceModel.PageName pgName)
        {
            return objDAL.GetPriceListFromSubCategory(subCategoryId, rStatus, pgName);
        }
    }
}
