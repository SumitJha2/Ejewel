using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//model
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Common.Sfm;
using EJewel.Model.Admin.Master.Metal;
//controller
using EJewel.Controller.Common;
using EJewel.Controller.Admin.Common.Sfm;
using EJewel.Controller.Admin.Master.Metal;


namespace EJewel.AdminView.Master.Metal
{
    public partial class AddMetalType : System.Web.UI.Page
    {
        SfmController objSfmController = new SfmController();
        MetalTypeController objController = new MetalTypeController();
        int _id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    _id = Convert.ToInt32(id);
                }
              /*  else
                {
                    Response.Redirect("Pagenotfound.aspx");
                }
               */
                if (!IsPostBack)
                {
                    //load the metal weight
                    ListHelper.BindList(ddlMetalWeight, objSfmController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.MetalWeightMaster), "AutoID", "Name", ListHelper.DefaultList);
                    //load the metal name
                    ListHelper.BindList(ddlMetalName, objSfmController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.MetalNameMaster), "AutoID", "Name", ListHelper.DefaultList);
                    //load status
                    ListHelper.BindList(ddlStatus, ListHelper.GetStatusSource(), "Value", "Text", null);
                    if (_id > 0)
                    {
                        //load edit data
                        this.LoadEditData();
                    }
                }
            }
        }



        /*
         * Partha Ranjan
         * @ 02-02-13
         * This function set the edit data in the field
         * */
        public void LoadEditData()
        {
            try
            {
                //access the data
                List<MetalTypeListModel> model = objController.GetMetalTypeList(_id, CommonModel.RecordStatus.Both);
                if (model.Count > 0)
                {
                    //set the value in the field
                    ddlMetalWeight.Items.FindByValue(model[0].MetalWeightId.ToString()).Selected = true;
                    ddlMetalName.Items.FindByValue(model[0].MetalNameId.ToString()).Selected = true;
                    txtPrice.Text = model[0].MetalPrice.ToString();
                    ddlStatus.SelectedIndex = model[0].Status ? 0 : 1;
                    hdnID.Value = model[0].MetalTypeId.ToString();
                    
                    //set image
                }
                else
                {
                    //redirect to the list page
                    Response.Redirect("/Master/Metal/ListMetalType.aspx?status=invalid");
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
