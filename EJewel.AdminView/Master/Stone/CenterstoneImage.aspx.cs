using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Controller.Admin.Master.Stone;
using EJewel.Model.Admin.Master.Stone;

using EJewel.Controller.Common;

namespace EJewel.AdminView.Master.Stone
{
    public partial class CenterstoneImage : System.Web.UI.Page
    {
        string sku = null;
        CenterStoneImageController objController = new CenterStoneImageController();
        List<CenterStoneImageModel> objModel = new List<CenterStoneImageModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                if (Request.QueryString["sku"] != "")
                {
                    sku = Request.QueryString["sku"];
                }
                else
                {
                    spnMessage.InnerText = "First Save Center Stone";
                    return;
                    // Response.Redirect("/Master/Stone/ManageCenterStone.aspx");
                }
                if (!IsPostBack)
                {
                    if (sku != "")
                    {
                        BindDetail(sku);
                    }
                    if (Request.QueryString["status"] == "success")
                    {
                        spnMessage.InnerText = "Details saved successfully.";
                    }
                }
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (sku != "")
                {
                    long centerstoneId = new CenterStoneController().GetCenterStoneIDFromSKU(sku);
                    CenterStoneImageModel objImage = new CenterStoneImageModel();
                    if (txtImage.Text != null)
                    {
                        objImage.CenterstoneID = centerstoneId;
                        objImage.ImagePath = txtImage.Text;
                        if (hdnCenterstoneImageId.Value != "")
                        {
                            objImage.CenterstoneImageID = Convert.ToInt64(hdnCenterstoneImageId.Value);
                        }

                        new CenterStoneImageController().SaveUpdateCenterStoneImage(objImage);
                    }

                    Response.Redirect("/Master/Stone/CenterstoneImage.aspx?sku=" + sku + "&status=success");
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
        public void BindDetail(string sku)
        {
            try
            {
                long centerstoneId = new CenterStoneController().GetCenterStoneIDFromSKU(sku);
                if (centerstoneId > 0)
                {
                    objModel = new CenterStoneImageController().GetImageByCenterStoneID(centerstoneId).ToList();
                    if (objModel != null && objModel.Count > 0)
                    {
                        gvCenterStoneImage.DataSource = objModel;
                        gvCenterStoneImage.DataBind();
                        gvCenterStoneImage.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
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
        protected void imgEdit_Click(object sender, EventArgs e)
        {
            ImageButton imgEdit = (ImageButton)sender;
            GridViewRow gv = (GridViewRow)imgEdit.NamingContainer;
            HiddenField hdnImageId = (HiddenField)gv.FindControl("hdnImageId");
            objModel = objController.GetImageByCenterStoneImageID(Convert.ToInt32(hdnImageId.Value.ToString())).ToList();;
            txtImage.Text = objModel[0].ImagePath;
            hdnCenterstoneImageId.Value = objModel[0].CenterstoneImageID.ToString();
        }
        protected void imgDelete_Click(object sender, EventArgs e)
        {
            ImageButton imgDelete = (ImageButton)sender;
            GridViewRow gv = (GridViewRow)imgDelete.NamingContainer;
            HiddenField hdnImageId = (HiddenField)gv.FindControl("hdnImageId");
            objController.DeleteCenterStoneImage(Convert.ToInt32(hdnImageId.Value.ToString()));
            BindDetail(sku);            
        }
        protected void gv_rowdataBound(object sender, GridViewRowEventArgs e)
        {            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnCSImageID = (HiddenField)e.Row.FindControl("hdnCSImageID");
                Label lblImage = (Label)e.Row.FindControl("lblImage");
                lblImage.Text = "<img src='" + hdnCSImageID.Value + "' width='30px' height='30px'/>";

            }
        }
                     
    }
}