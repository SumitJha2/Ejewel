using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Controller.Admin.Master.Category;
using EJewel.Model.Admin.Common;
//


namespace EJewel.AdminView.Master.Category
{
    public partial class ListCategory : System.Web.UI.Page
    {
        public int _totalRecord = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                _totalRecord = new CategoryController().TotalNoOfSubCategory(0, CommonModel.RecordStatus.Both);
            }
        }
    }
}