using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//model
using EJewel.Model.Admin.Common.SingleField;
//controller
using EJewel.Controller.Admin.Common.SingleField;
using EJewel.Controller.Common;
namespace EJewel.AdminView.Common.SingleField
{
    /*
     * Partha Ranjan
     * @ 31-01-13
     * This class manage all the single filed opeartion with field
     * Auto ID, Name and Status
     * */
    public partial class SingleFieldManagement : System.Web.UI.Page
    {
        SingleFieldController objController = new SingleFieldController();
        string _view = "";
        int _editId = 0;

        SingleFieldModel.PageName _pageName = SingleFieldModel.PageName.None;

        protected void Page_Load(object sender, EventArgs e)
        {           
            string view = Request.QueryString["view"];
            string id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(view))
            {
                _view = view.Trim();
                //get the page name
                _pageName = objController.GetPageView(_view);
                ltrlHeading.Text = objController.HeadingName;
                if (_pageName != SingleFieldModel.PageName.None)
                {
                    //bind status
                    ListHelper.BindList(ddlstatus, ListHelper.GetStatusSource(), "Value", "Text", null);
                    //view on edit mode
                    if (!string.IsNullOrEmpty(id))
                    {
                        _editId = Convert.ToInt32(id);
                        this.LoadEditData();
                    }
                }
                else
                {
                    //redirect to the default page
                    Response.Redirect("/Default.aspx");
                }
            }
            else
            {
                //redirect to the default page
                Response.Redirect("/Default.aspx");
            }
        }

        /*
         * Partha Ranjan
         * @ 02-02-13
         * This function helps to load the edit value in the page
         * */
        private void LoadEditData()
        {
            try
            {
                SingleFieldModel model = objController.GetSingleFieldList(_editId, Model.Admin.Common.CommonModel.RecordStatus.Both, _pageName).FirstOrDefault();
                if (model != null)
                {
                    txtName.Text = model.Name;
                    ddlstatus.SelectedIndex = model.Status ? 0 : 1;
                    hdnID.Value = model.AutoID.ToString();
                }
                else
                {
                    Response.Redirect("Common/SingleField/ListSingleField.aspx?view=" + _view);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}