using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.Admin.Master.Certificate;
using EJewel.Controller.Admin.Master.Certificate;

namespace EJewel.AdminView.Master.Certificate
{
    public partial class ManageCertificateMaster : System.Web.UI.Page
    {
        string certificate;
        int edit_id=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["view"]!=null)
            {
                certificate = Request.QueryString["view"];
               // headingText.InnerHtml = "Manage  " + certificate;

                       
                if (Request.QueryString["edit_id"] != null)
                {
                    edit_id = Convert.ToInt32(Request.QueryString["edit_id"]);
                    if (!IsPostBack)
                    {
                        if (edit_id > 0)
                        {
                            BindCertificateDetails(edit_id);
                        }
                    }
                }

            }     
    
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
          //  btnSave.Attributes.Add("onclick", " return ValidateCertificate()");          
            CertificateMasterModel model = new CertificateMasterModel();            
            model.Name = txtName.Text;
            if (Convert.ToInt32(ddlstatus.SelectedValue) == 1)
            {
                model.Status = true;
            }
            else
            {
                model.Status = false;
            }

            if (edit_id > 0)
            {
                model.ID= edit_id;
            }
            /*
             * Partha 
             * @ 29-01-13
             * */
            switch (certificate)
            {
                case "gridle":
                    {
                        CertificateGridleController objController = new CertificateGridleController();
                        if (!objController.IsExist(model))
                        {
                            objController.SaveUpdate(model);
                            Response.Redirect("/Master/Certificate/ListCertificateMaster.aspx?view=gridle");
                        }
                    } break;
                case "symmerty":
                    {
                        CertificateSymmetryController objController = new CertificateSymmetryController();
                        if (!objController.IsExist(model))
                        {
                            objController.SaveUpdate(model);
                            Response.Redirect("/Master/Certificate/ListCertificateMaster.aspx?view=symmerty");
                        }
                    } break;
                case "culet":
                    {
                        CertificateCuletController objController = new CertificateCuletController();
                        if (!objController.IsExist(model))
                        {
                            objController.SaveUpdate(model);
                            Response.Redirect("/Master/Certificate/ListCertificateMaster.aspx?view=culet");
                        }
                    } break;
                case "polish":
                    {
                        CertificatePolishController objController = new CertificatePolishController();
                        if (!objController.IsExist(model))
                        {
                            objController.SaveUpdate(model);
                            Response.Redirect("/Master/Certificate/ListCertificateMaster.aspx?view=polish");
                        }
                    } break;
                case "flouresence":
                    {
                        CertificateFlouresenceController objController = new CertificateFlouresenceController();
                        if (!objController.IsExist(model))
                        {
                            objController.SaveUpdate(model);
                            Response.Redirect("/Master/Certificate/ListCertificateMaster.aspx?view=flouresence");
                        }
                    } break;
                case "lab":
                    {
                        CertificationLabController objController = new CertificationLabController();
                        if (!objController.IsExist(model))
                        {
                            objController.SaveUpdate(model);
                            Response.Redirect("/Master/Certificate/ListCertificateMaster.aspx?view=lab");
                        }
                    } break;
            }
            

        }
        private void BindCertificateDetails(int editid)
        {
            try
            {
                CertificateMasterModel model = new CertificateMasterModel();
                if (certificate == "gridle")
                {
                    CertificateGridleController objController = new CertificateGridleController();
                    model = objController.GetList(editid).FirstOrDefault();
                }
                if (certificate == "symmerty")
                {
                    CertificateSymmetryController objController = new CertificateSymmetryController();
                    model = objController.GetList(editid).FirstOrDefault();
                }
                if (certificate == "culet")
                {
                    CertificateCuletController objController = new CertificateCuletController();
                    model = objController.GetList(editid).FirstOrDefault();
                }
                if (certificate == "polish")
                {
                    CertificatePolishController objController = new CertificatePolishController();
                    model = objController.GetList(editid).FirstOrDefault();
                }
                if (certificate == "flouresence")
                {
                    CertificateFlouresenceController objController = new CertificateFlouresenceController();
                    model = objController.GetList(editid).FirstOrDefault();
                }
                if (certificate == "lab")
                {
                    CertificationLabController objController = new CertificationLabController();
                    model = objController.GetList(editid).FirstOrDefault();
                }
                txtName.Text = model.Name;
                ddlstatus.SelectedValue = model.Status.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}