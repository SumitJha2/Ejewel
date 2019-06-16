using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Controller.Admin.Common.Sfm;
using EJewel.Model.Admin.Common.Sfm;
using EJewel.Controller.Common;
using EJewel.Model.Admin.Product;
using EJewel.Controller.Admin.Product;


namespace EJewel.AdminView.Product
{
    public partial class ProductChain : System.Web.UI.Page
    {
        long productId = 0;
        List<SfmModel> objModel = new List<SfmModel>();
        SfmController objController = new SfmController();
        ProductChainController objProductChainController = new ProductChainController();
        ProductChainModel objProductChainModel = new ProductChainModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                if (Request.QueryString["id"] != null)
                {
                    productId = Convert.ToInt64(Request.QueryString["id"]);
                }
                if (!IsPostBack)
                {
                    BindChainLength();
                    BindChainStyle();
                    BindChainClasp();
                    ListHelper.BindList(ddlStatus, ListHelper.GetStatusSource(), "Value", "Text", null);
                    BindData();
                    if (Request.QueryString["status"] == "success")
                    {
                        spnMessage.Attributes.Add("style", "color:green;");
                        spnMessage.InnerText = "Details saved successfully.";
                    }
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (productId > 0)
                {
                    ProductChainModel objModel = new ProductChainController().GetProductChainDetail(productId,CommonModel.RecordStatus.Both);
                    if (objModel != null)
                    {
                        objProductChainModel.ProductChainId = objModel.ProductChainId;
                    }
                    objProductChainModel.ProductId = productId;
                    objProductChainModel.ChainLengthId = Convert.ToInt32(ddlChainLength.SelectedValue);
                    objProductChainModel.ChainStyleId = Convert.ToInt32(ddlChainStyle.SelectedValue);
                    objProductChainModel.ChainClaspId = Convert.ToInt32(ddlChainClasp.SelectedValue);
                    objProductChainModel.Status = ddlStatus.SelectedIndex == 0 ? true : false;
                    objProductChainController.SaveUpdateProductChain(objProductChainModel);
                    Response.Redirect("/Product/ProductChain.aspx?id=" + productId + "&status=success");
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
        public void BindChainLength()
        {
            try
            {
                objModel = objController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.ChainLength).ToList();
                if (objModel != null && objModel.Count > 0)
                {
                    ddlChainLength.DataSource = objModel;
                    ddlChainLength.DataTextField = "Name";
                    ddlChainLength.DataValueField = "AutoID";
                    ddlChainLength.DataBind();
                }
                ddlChainLength.Items.Insert(0, new ListItem("Please Select", "0"));
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
        public void BindChainStyle()
        {
            try
            {
                objModel = objController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.ChainStyle).ToList();
                if (objModel != null && objModel.Count > 0)
                {
                    ddlChainStyle.DataSource = objModel;
                    ddlChainStyle.DataTextField = "Name";
                    ddlChainStyle.DataValueField = "AutoID";
                    ddlChainStyle.DataBind();
                }
                ddlChainStyle.Items.Insert(0, new ListItem("Please Select", "0"));
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
        public void BindChainClasp()
        {
            try
            {
                objModel = objController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.ChainClasp).ToList();
                if (objModel != null && objModel.Count > 0)
                {
                    ddlChainClasp.DataSource = objModel;
                    ddlChainClasp.DataTextField = "Name";
                    ddlChainClasp.DataValueField = "AutoID";
                    ddlChainClasp.DataBind();
                }
                ddlChainClasp.Items.Insert(0, new ListItem("Please Select", "0"));
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
        public void BindData()
        {
            try
            {
                objProductChainModel = objProductChainController.GetProductChainDetail(productId, CommonModel.RecordStatus.Both);
                if (objProductChainModel != null)
                {
                    ddlChainClasp.SelectedValue = objProductChainModel.ChainClaspId.ToString();
                    ddlChainLength.SelectedValue = objProductChainModel.ChainLengthId.ToString();
                    ddlChainStyle.SelectedValue = objProductChainModel.ChainStyleId.ToString();
                    ddlStatus.SelectedIndex = objProductChainModel.Status == true ? 0 : 1;
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