using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using EJewel.Model.Admin.Master.Certificate;
using EJewel.Controller.Admin.Master.Certificate;
using EJewel.Model.Admin.Master.Stone;
using EJewel.Controller.Admin.Master.Stone;

namespace EJewel.AdminView.Master.Certificate
{
    public partial class ManageStoneCertificate : System.Web.UI.Page
    {
        int estoneid;

        protected void Page_Load(object sender, EventArgs e)
        {
            estoneid = Convert.ToInt32(Request.QueryString["estoneid"]);
            if (!IsPostBack)
            {
                BindGriddle(0);
                BindSymmetry(0);
                BindCulet(0);
                BindPolish(0);
                BindFluroSence(0);
                BindCerificationLab(0);
                viewCertificate.Visible = false;
                if (Request.QueryString["SKU"] != null)
                {
                    lblSKU.Text = Request.QueryString["SKU"];
                }
                if (Request.QueryString["stoneid"] != null)
                {
                    int stoneid = Convert.ToInt32(Request.QueryString["stoneid"]);
                }
                if (Request.QueryString["estoneid"] != null)
                {
                    StoneCerificateController objController = new StoneCerificateController();
                    StoneCertificateModel model = objController.GetCertificateByStoneID(estoneid);
                    Session["certificateid"] = model.CertificateID;
                    BindCertificationData(model.CertificateID);
                    ShowSKU(estoneid);
                    viewCertificate.HRef = "\\Image\\Certificate\\" + Session["certificateid"] + "." + Session["flext"];
                }

            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                StoneCertificateModel model = new StoneCertificateModel();
                StoneCerificateController objController = new StoneCerificateController();
                if (Request.QueryString["stoneid"] != null)
                {
                    model.StoneID = Convert.ToInt32(Request.QueryString["stoneid"]);
                }
                if (Session["certificateid"] != null)
                {
                    model.CertificateID = Convert.ToInt32(Session["certificateid"]);
                    model.StoneID = estoneid;
                }
                model.CertificateDepth = Convert.ToDouble(txtDepth.Text);
                model.CertificateTable = Convert.ToDouble(txtDepth.Text);
                model.GridleId = Convert.ToInt32(ddlGridle.SelectedValue);
                model.SymmetryId = Convert.ToInt32(ddlSymmetry.SelectedValue);
                model.PolishId = Convert.ToInt32(ddlPolish.SelectedValue);
                model.CuletId = Convert.ToInt32(ddlCulet.SelectedValue);
                model.FlouresenceID = Convert.ToInt32(ddlFlouresence.SelectedValue);
                model.CertificateMeasurement = txtMeasurement.Text;
                model.CertificateCrown = Convert.ToDouble(txtCrown.Text);
                model.CertificateCrownAngle = Convert.ToDouble(txtCrownAngle.Text);
                model.CertificatePavillion = Convert.ToDouble(txtPavillion.Text);
                model.CertificatePavillionAngle = Convert.ToDouble(txtPavillionAngle.Text);
                model.CertificateCertification = txtCertification.Text;
                model.LabId = Convert.ToInt32(ddlLab.SelectedValue);
                //model.CertificationFile
                if (Convert.ToInt32(dd1Status.SelectedValue) == 1)
                {
                    model.Status = true;
                }
                else
                {
                    model.Status = false;
                }
                if (FdCertificate.PostedFile.ContentLength != 0)
                {
                    string filename = string.Empty;
                    filename = Path.GetFileName(FdCertificate.PostedFile.FileName);
                    model.CertificationFile = GetExtension(filename);
                }
                if (CheckFileExtension())
                {
                    model = objController.SaveUpdateStoneCertificate(model);
                    UploadFile(model.CertificateID);
                    Response.Redirect("/Master/Stone/ListStone.aspx");
                }
                else
                {
                    lblerroer.Text = "Please upload only pdf file";
                    viewCertificate.Visible = false;
                    return;
                }

            }
            catch (Exception ex)
            {
            }

        }
        private void BindGriddle(int griddleid)
        {
            CertificateGridleController objController = new CertificateGridleController();
            List<CertificateMasterModel> model = objController.GetList(griddleid);
            if (model != null)
            {
                ddlGridle.DataSource = model;
                ddlGridle.DataTextField = "Name";
                ddlGridle.DataValueField = "ID";
                ddlGridle.DataBind();
            }
            ddlGridle.Items.Insert(0, new ListItem("Please Select", "0"));

        }
        private void BindSymmetry(int symmetryid)
        {
            CertificateSymmetryController objController = new CertificateSymmetryController();
            List<CertificateMasterModel> model = objController.GetList(symmetryid);
            if (model != null)
            {
                ddlSymmetry.DataSource = model;
                ddlSymmetry.DataTextField = "Name";
                ddlSymmetry.DataValueField = "ID";
                ddlSymmetry.DataBind();
            }
            ddlSymmetry.Items.Insert(0, new ListItem("Please Select", "0"));
        }
        private void BindCulet(int culetid)
        {
            CertificateCuletController objController = new CertificateCuletController();
            List<CertificateMasterModel> model = objController.GetList(culetid);
            if (model != null)
            {
                ddlCulet.DataSource = model;
                ddlCulet.DataTextField = "Name";
                ddlCulet.DataValueField = "ID";
                ddlCulet.DataBind();
            }
            ddlCulet.Items.Insert(0, new ListItem("Please Select", "0"));

        }
        private void BindPolish(int polishid)
        {
            CertificatePolishController objController = new CertificatePolishController();
            List<CertificateMasterModel> model = objController.GetList(polishid);
            if (model != null)
            {
                ddlPolish.DataSource = model;
                ddlPolish.DataTextField = "Name";
                ddlPolish.DataValueField = "ID";
                ddlPolish.DataBind();
            }
            ddlPolish.Items.Insert(0, new ListItem("Please Select", "0"));

        }
        private void BindFluroSence(int fluorenceid)
        {
            CertificateFlouresenceController objController = new CertificateFlouresenceController();
            List<CertificateMasterModel> model = objController.GetList(fluorenceid);
            if (model != null)
            {
                ddlFlouresence.DataSource = model;
                ddlFlouresence.DataTextField = "Name";
                ddlFlouresence.DataValueField = "ID";
                ddlFlouresence.DataBind();
            }
            ddlFlouresence.Items.Insert(0, new ListItem("Please Select", "0"));
        }
        private void BindCerificationLab(int labid)
        {
            CertificationLabController objController = new CertificationLabController();
            List<CertificateMasterModel> model = objController.GetList(labid);
            if (model != null)
            {
                ddlLab.DataSource = model;
                ddlLab.DataTextField = "Name";
                ddlLab.DataValueField = "ID";
                ddlLab.DataBind();
            }
            ddlLab.Items.Insert(0, new ListItem("Please Select", "0"));
        }
        private void BindCertificationData(int certificateid)
        {
            StoneCerificateController objController = new StoneCerificateController();
            StoneCertificateModel model = objController.GetCertificate(certificateid).FirstOrDefault();
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
            dd1Status.SelectedValue = model.Status.ToString();
            Session["flext"] = model.CertificationFile;
            // lnkCertificate.Visible = true;
            viewCertificate.Visible = true;
        }

        // function for certificate pdf
        private void UploadFile(int certificateid)
        {
            string filepath = string.Empty;
            string savepath = string.Empty;
            filepath = Server.MapPath("/") + "Image\\Certificate";
            if (FdCertificate.PostedFile.ContentLength != 0)
            {
                string filename = string.Empty;
                filename = Path.GetFileName(FdCertificate.PostedFile.FileName);
                string extention = GetExtension(filename);
                // to rename file with certificate id
                filename = certificateid + "." + extention;
                if (Session["certificateid"] != null)
                {
                    if (Session["flext"] != null)
                    {

                        string completePath = Server.MapPath("/") + "Image\\Certificate\\" + certificateid + "." + Session["flext"];
                        if (System.IO.File.Exists(completePath))
                        {
                            System.IO.File.Delete(completePath);
                        }

                    }

                }

                savepath = "~/Image/Certificate/" + filename; //foldername
                FdCertificate.PostedFile.SaveAs(filepath + "/" + filename);

            }


        }
        private string GetExtension(string FileName)
        {
            string[] split = FileName.Split('.');
            string Extension = split[split.Length - 1];
            return Extension;
        }
        private bool CheckFileExtension()
        {
            if (FdCertificate.PostedFile.ContentLength != 0)
            {
                string filename = string.Empty;
                filename = Path.GetFileName(FdCertificate.PostedFile.FileName);
                Session["flext"] = GetExtension(filename);
            }
            if (Session["flext"] != null)
            {
                string s = (string)Session["flext"];
                //code for upload only pdf
                if ((string)Session["flext"] != "pdf")
                {
                    return false;
                }
                else
                    return true;
            }
            else
                return false;
        }
        private void ShowSKU(int estoneid)
        {
            StoneController objController = new StoneController();
            GetStoneModel model = objController.GetStoneModel(estoneid).FirstOrDefault();
            lblSKU.Text = model.SKU;


        }


    }
}