using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using EJewel.Controller.Admin.Product;
using EJewel.Model.Admin.Product;
using System.Collections;
namespace EJewel.AdminView.Product
{
    public partial class ProductExport : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        List<ProductDetailsModel> objModel = new List<ProductDetailsModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Getproductlist();
        }

        public void Getproductlist()
        {
            DataTable table = new DataTable();
            table.Columns.Add("SKU", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("GoogleProductCategory", typeof(string));
            table.Columns.Add("ProductType", typeof(string));
            table.Columns.Add("Link", typeof(string));
            table.Columns.Add("ImageLink", typeof(string));
            table.Columns.Add("AdditionalLink", typeof(string));
            table.Columns.Add("Condition", typeof(string));
            table.Columns.Add("Avaiblity", typeof(string));
            table.Columns.Add("Price", typeof(string));
            table.Columns.Add("Brand", typeof(string));
            table.Columns.Add("Gender", typeof(string));
            table.Columns.Add("age_group", typeof(string));
            table.Columns.Add("color", typeof(string));
            table.Columns.Add("size", typeof(string));
            table.Columns.Add("Keywords", typeof(string));
            table.Columns.Add("VideoLink", typeof(string));
            table.Columns.Add("VideoTitle", typeof(string));

            DataSet ds = new DataSet();
            objModel = new ProductDetailsController().GetProductList(0).ToList();
            if (objModel != null)
            {
                foreach (var propInfo in objModel)
                {
                    table.Rows.Add(propInfo.SKU, propInfo.ProductTitle, propInfo.ProductDescripation, "", "", "", "", "", "NEW", "In Stock", propInfo.ProductDefaultPrice, "Fascinating Diamonds", "", "", "white", "", "", "", "");
                    //table.Rows.Add(propInfo.SKU,propInfo.ProductTitle,propInfo.ProductDescripation,"","","","","","","In Stock",propInfo.ProductDefaultPrice,"","","","white","","","","");
                }

            }
            ds.Tables.Add(table);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string attachment = "attachment; filename=ProductDetails.xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/vnd.ms-excel";

                MemoryStream m = new MemoryStream();
                ExcelLibrary.DataSetHelper.CreateWorkbook(m, ds);
                m.WriteTo(Response.OutputStream);
                ds.Dispose();
                m.Dispose();
            }
        }
    }
}


 
