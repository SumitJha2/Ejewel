using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Common.Sfm;
//controller
using EJewel.Controller.Admin.Master.Stone;
using EJewel.Controller.Common;
using EJewel.Controller.Admin.Common.Sfm;

namespace EJewel.AdminView.Master.Stone
{
    public partial class ManageCenterStone : System.Web.UI.Page
    {
        SfmController objSfmController = new SfmController();
        StoneSpecificationController objStoneSpecification = new StoneSpecificationController();
        CenterStoneController objController = new CenterStoneController();
        StoneShapeController objStoneShapeController = new StoneShapeController();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                //load the data
                ListHelper.BindList(ddlCut, objStoneSpecification.GetStoneSpecificationListFromCategory(1, StoneSpecificationModel.PageName.Cut, CommonModel.RecordStatus.Enabled), "AutoID", "Name", ListHelper.DefaultList);
                //color
                ListHelper.BindList(ddlColor, objStoneSpecification.GetStoneSpecificationListFromCategory(1, StoneSpecificationModel.PageName.Color, CommonModel.RecordStatus.Enabled), "AutoID", "Name", ListHelper.DefaultList);
                //clarity
                ListHelper.BindList(ddlClarity, objStoneSpecification.GetStoneSpecificationListFromCategory(1, StoneSpecificationModel.PageName.Clarity, CommonModel.RecordStatus.Enabled), "AutoID", "Name", ListHelper.DefaultList);
                //shape
                ListHelper.BindList(ddlShape, objStoneShapeController.StoneShapeListFromCategory(ConstantHelper.STONE_CATEGORY_DIAMOND,StoneShapeModel.ShapeVisibility.CENTERSTONE, CommonModel.RecordStatus.Enabled), "StoneShapeId", "Shape", ListHelper.DefaultList);
                //load status
                ListHelper.BindList(ddlStatus, ListHelper.GetStatusSource(), "Value", "Text", null);
                //load the certificate details
                //girdle
                ListHelper.BindList(ddlGridle, objSfmController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.CertificateGridle), "AutoID", "Name", ListHelper.DefaultList);
                //symmetry
                ListHelper.BindList(ddlSymmetry, objSfmController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.CertificateSymmetry), "AutoID", "Name", ListHelper.DefaultList);
                //culet
                ListHelper.BindList(ddlCulet, objSfmController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.CertificateCulet), "AutoID", "Name", ListHelper.DefaultList);
                //polish
                ListHelper.BindList(ddlPolish, objSfmController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.CertificatePolish), "AutoID", "Name", ListHelper.DefaultList);
                //Flouresence
                ListHelper.BindList(ddlFlouresence, objSfmController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.CertificateFlouresence), "AutoID", "Name", ListHelper.DefaultList);
                //lab
                ListHelper.BindList(ddlLab, objSfmController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.CertificateLab), "AutoID", "Name", ListHelper.DefaultList);

                string qs_id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(qs_id))
                {
                    this.LoadEditData(Convert.ToInt64(qs_id.Trim()));
                }
               /* else
                {
                    Response.Redirect("Pagenotfound.aspx");
                }
                */
            }
        }

        void LoadEditData(long centerStoneId)
        {
            try
            {
                CenterStoneModel centerStone = objController.GetCenterStoneList(centerStoneId, CenterStoneModel.CenterStoneProvider.FascinatingDiamonds, CommonModel.RecordStatus.Both).FirstOrDefault();
                if (centerStone != null)
                {
                    hdnID.Value = centerStone.StoneId.ToString();
                    //fill up the data
                    txtSKU.Text = centerStone.SKU;
                    //
                    ddlCut.SelectedValue = centerStone.StoneCutId.ToString();
                    ddlColor.SelectedValue = centerStone.StoneColorId.ToString();
                    ddlClarity.SelectedValue = centerStone.StoneClarityId.ToString();
                    ddlShape.SelectedValue = centerStone.StoneShapeId.ToString();
                    txtCarate.Text = centerStone.StoneCarate.ToString();
                    txtPrice.Text = centerStone.StonePrice.ToString();
                    //certificate
                    txtDepth.Text = centerStone.CertificateDepth.ToString();
                    txtTable.Text = centerStone.CertificateTable.ToString();
                    ddlGridle.SelectedValue = centerStone.CertificateGridleId.ToString();
                    ddlSymmetry.SelectedValue = centerStone.CertificateSymmetryId.ToString();
                    ddlCulet.SelectedValue = centerStone.CertificateCuletId.ToString();
                    ddlPolish.SelectedValue = centerStone.CertificatePolishId.ToString();
                    ddlFlouresence.SelectedValue = centerStone.CertificateFlouresenceId.ToString();
                    ddlLab.SelectedValue = centerStone.CertificateCertificationLabId.ToString();
                    ddlStatus.SelectedValue = centerStone.Status.ToString();
                    //
                    txtMeasurement.Text = centerStone.CertificateMeasurement;
                    txtCrown.Text = centerStone.CertificateCrown.ToString();
                    txtCrownAngle.Text = centerStone.CertificateCrownAngle.ToString();
                    txtPavillion.Text = centerStone.CertificatePavillion.ToString();
                    txtPavillionAngle.Text = centerStone.CertificatePavillionAngle.ToString();
                    txtCertification.Text = centerStone.Certification;
                    txtFile.Text = centerStone.CertificationFile;

                    ddlDiscountType.SelectedValue = centerStone.DiscountType.ToString();
                    txtDisCount.Text = centerStone.Discount.ToString();

                    //
                }
                else
                {
                    Response.Write("<script>window.close();</script>");
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

        protected void btnImage_Click(object sender, EventArgs e)
        {

        }

        
    }
}