using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//model
using EJewel.Model.Admin.Master.Stone;
//controller
using EJewel.Controller.Admin.Master.Stone;

namespace EJewel.AdminView.Master.Stone
{
    public partial class CenterStoneOverView : System.Web.UI.Page
    {
        CenterStoneController objController = new CenterStoneController();

        public string _SKU, _Cut, _Color,_Clarity,_Shape,_Carate, _Price, _Depth, _Table, _Culet, _Polish, _Flouresence, _Measurement, _Crown, _CrownAngle, _Pavillion, _PavillionAngle, _Certificate, _Lab, _File, _Status,_Gridle,_Symmetry;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                string SKU = Request.QueryString["SKU"];
                if (!string.IsNullOrEmpty(SKU))
                {
                    SKU = SKU.Trim();
                    CenterStoneModel model = objController.GetCenterStoneDetailsFromSKU(SKU);
                    if (model != null)
                    {
                        //set the value of the center stone
                        _SKU = model.SKU;
                        _Cut = model.StoneCut;
                        _Color = model.StoneColor;
                        _Shape = model.StoneShape;
                        _Clarity = model.StoneClarity;
                        _Carate = model.StoneCarate.ToString();
                        _Price = model.StonePrice.ToString();
                        _Depth = model.CertificateDepth + " %";
                        _Table = model.CertificateTable + " %";
                        _Gridle = model.CertificateGridle;
                        _Symmetry = model.CertificateSymmetry;
                        _Culet = model.CertificateCulet;
                        _Polish = model.CertificatePolish;
                        _Flouresence = model.CertificateFlouresence;
                        _Measurement = model.CertificateMeasurement + " mm.";
                        _Crown = model.CertificateCrown == 0 ? "N/A" : model.CertificateCrown.ToString();
                        _CrownAngle = model.CertificateCrownAngle == 0 ? "N/A" : model.CertificateCrownAngle.ToString();
                        _Pavillion = model.CertificatePavillion == 0 ? "N/A" : model.CertificatePavillion.ToString();
                        _PavillionAngle = model.CertificatePavillionAngle == 0 ? "N/A" : model.CertificatePavillionAngle.ToString();
                        _Certificate = model.Certification;
                        _Lab = model.CertificateCertificationLab;
                        _File = model.CertificationFile.Length > 0 ? "<a href=\"" + model.CertificationFile + "\" target=\"_blank\">" + model.CertificationFile + "</a>" : "";
                        _Status = model.Status == true ? "Enabled" : "Disabled";
                    }
                    else
                    {
                        //No Record Found
                    }
                }
                else
                {
                    Response.Redirect("Pagenotfound.aspx");
                }
            }
        }
    }
}