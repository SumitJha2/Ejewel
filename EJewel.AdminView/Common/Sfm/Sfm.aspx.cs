using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//model
using EJewel.Model.Admin.Common.Sfm;
//controller
using EJewel.Controller.Admin.Common.Sfm;
using EJewel.Controller.Common;
using EJewel.Model.Admin.Common;


namespace EJewel.AdminView.Common.Sfm
{
    /*
     * Partha Ranjan
     * @ 31-01-13
     * This class manage all the single filed opeartion with field
     * Auto ID, Name and Status
     * @ Modified in 05-03-13 by Partha
     * More flexible and short name
     * */
    public partial class Sfm : System.Web.UI.Page
    {
        SfmController objController = new SfmController();
        public string _view = "";
        int _editId = 0;

        SfmModel.PageName _pageName = SfmModel.PageName.None;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                _view = Request.QueryString["view"];
                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(_view))
                {
                    _view = _view.Trim();
                    //get the page name
                    _pageName = objController.GetPageView(_view);
                    ltrlHeading.Text = objController.HeadingName;
                    if (_pageName != SfmModel.PageName.None)
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
                SfmModel model = objController.GetSfmList(_editId,CommonModel.RecordStatus.Both, _pageName).FirstOrDefault();
                if (model != null)
                {
                    txtName.Text = model.Name;
                    ddlstatus.SelectedIndex = model.Status ? 0 : 1;
                    hdnID.Value = model.AutoID.ToString();
                }
                else
                {
                    Response.Redirect("/Common/Sfm/Sfm.aspx?view=" + _view);
                }
            }
            catch (Exception ex)
            {
                ErrorLogModel objLogError = new ErrorLogModel();
                objLogError.ErrorMessage = ex.Message;
                objLogError.ErrorSource = ex.Source;
                objLogError.StackTrace = ex.StackTrace;
                objLogError.InnerException = Convert.ToString(ex.InnerException);
                objLogError.LogTime = DateTime.Now;
                objLogError.UserID = Session["loginID"].ToString();
                new ErrorLogController().SetErrorLog(objLogError);
            }
        }
    }
}