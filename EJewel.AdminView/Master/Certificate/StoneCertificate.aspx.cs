using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
///model
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Common.Sfm;
//controller
using EJewel.Controller.Admin.Master.Stone;
using EJewel.Controller.Admin.Common.Sfm;
using EJewel.Controller.Common;

namespace EJewel.AdminView.Master.Certificate
{
    public partial class StoneCertificate : System.Web.UI.Page
    {

        StoneCerificateController objController = new StoneCerificateController();
        StoneCertificateModel objModel = new StoneCertificateModel();
        //
        SfmController objSfmController = new SfmController();

        protected void Page_Load(object sender, EventArgs e)
        {
            string _stoneid = Request.QueryString["id"];
            if (_stoneid != null)
            {
                int stoneid = Convert.ToInt32(_stoneid);
                StoneModel stoneModel = new StoneController().GetStoneList(stoneid, CommonModel.RecordStatus.Both).FirstOrDefault();
                if (stoneModel != null)
                {
                    lblSKU.Text = stoneModel.SKU;
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
                    //status
                    ListHelper.BindList(ddlStatus, ListHelper.GetStatusSource(), "Value", "Text", null);
                    objModel = objController.GetCertificateByStoneID(stoneid);
                    if (objModel != null)
                    {
                        BindCertificationData(objModel.CertificateID);
                    }
                    //assign stoneid
                    hdnStoneid.Value = Convert.ToString(stoneid);
                }
                else
                {
                    Response.Write("<script>window.close()</script>");
                }
            }
            else
            {
                Response.Write("<script>window.close()</script>");
            }
        }

        private void BindCertificationData(int certificateid)
        {
            try
            {
                StoneCerificateController objController = new StoneCerificateController();
                StoneCertificateModel model = objController.GetCertificate(certificateid).FirstOrDefault();
                if (model != null)
                {
                    txtDepth.Text = Convert.ToString(model.CertificateDepth);
                    txtTable.Text = Convert.ToString(model.CertificateTable);
                    ddlGridle.SelectedValue = model.GridleId.ToString();
                    ddlSymmetry.SelectedValue = model.SymmetryId.ToString();
                    ddlCulet.SelectedValue = model.CuletId.ToString();
                    ddlPolish.SelectedValue = model.PolishId.ToString();
                    ddlFlouresence.SelectedValue = model.FlouresenceID.ToString();
                    txtMeasurement.Text = model.CertificateMeasurement;
                    txtCrown.Text = Convert.ToString(model.CertificateCrown);
                    txtCrownAngle.Text = Convert.ToString(model.CertificateCrownAngle);
                    txtPavillion.Text = Convert.ToString(model.CertificatePavillion);
                    txtPavillionAngle.Text = Convert.ToString(model.CertificatePavillion);
                    txtCertification.Text = Convert.ToString(model.CertificateCertification);
                    ddlLab.SelectedValue = model.LabId.ToString();
                    ddlStatus.SelectedIndex = model.Status == true ? 0 : 1;
                    //for image
                    spnProgress.Text = "<img src='/upload/images/certificate/" + model.CertificationFile + "' alt='Photo' style='width:50px;height:50px;' />";
                    hdnid.Value = Convert.ToString(certificateid);

                }
            }
            catch (Exception ex)
            {
            }

        }
    }
}
