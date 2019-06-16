using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Controller.Admin.Master.Stone;
using EJewel.Model.Admin.Master.Stone;

namespace EJewel.UserView
{
    public partial class LooseDiamondDetails : System.Web.UI.Page
    {
        public string _sku="";
        public double _price=0;

        public double _carat=0;
        public string _cut;
        public string _color;
        public string _clarity;

        public string _depth="";
        public string _table="";
        public string _polish;
        public string _symmetry;
        public string _griddle;
        public string _culet;
        public string _fluoresence;
        public string _measurement;

       

        CenterStoneController objController = new CenterStoneController();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDetails();
            }
         
        }

          public void GetDetails()
          {
            _sku = "L050AS-EN39-97";
            CenterStoneModel centerstonemodel=objController.GetCenterStoneDetailsFromSKU(_sku);
           

           if (centerstonemodel != null)
            {
                lblSku.Text = centerstonemodel.SKU;
                lblPrice.Text = Convert.ToString(centerstonemodel.StonePrice);
                lblCarat.Text = Convert.ToString(centerstonemodel.StoneCarate);
                lblCut.Text = centerstonemodel.StoneCut;
                lblColor.Text = centerstonemodel.StoneColor;
                lblClarity.Text = centerstonemodel.StoneClarity;
                lblDepth.Text = Convert.ToString(centerstonemodel.CertificateDepth)+"%";
                lblTable.Text = Convert.ToString(centerstonemodel.CertificateTable)+"%";
                lblPolish.Text = Convert.ToString(centerstonemodel.CertificatePolish);
                lblSymmetry.Text = centerstonemodel.CertificateSymmetry;
                lblGriddle.Text = centerstonemodel.CertificateGridle;
                lblCut.Text = centerstonemodel.CertificateCulet;
                lblFluoresence.Text = centerstonemodel.CertificateFlouresence;
                lblMeasurement.Text = centerstonemodel.CertificateMeasurement;
                lblCulet.Text = centerstonemodel.CertificateCulet;
               
                    lblCrown.Text = Convert.ToString(centerstonemodel.CertificateCrown);
               
                    lblCrownAngle.Text = Convert.ToString(centerstonemodel.CertificateCrownAngle);
               
                lblPavilion.Text = Convert.ToString(centerstonemodel.CertificatePavillion) + "%";
                lblPavilionAngle.Text=Convert.ToString(centerstonemodel.CertificatePavillionAngle);
                lblCertificate.Text = centerstonemodel.Certification != null ? centerstonemodel.Certification : "N.A";
                string _header = "";
                _header = centerstonemodel.StoneCarate + " Carat " + centerstonemodel.StoneClarity + "  " + centerstonemodel.StoneCut + "  " + centerstonemodel.StoneShape + " Diamond";
                lblLab.Text = centerstonemodel.CertificateCertificationLab;
                lblHeading.Text = _header;
                Page.Title = _header;
                lblOurPrice.Text = Convert.ToString(centerstonemodel.StonePrice);
                lbSKU.Text = centerstonemodel.SKU;
                lblDesc.Text = "Buy Affordable" + "  " + centerstonemodel.StoneCarate + " Carat " + centerstonemodel.StoneShape + "cut Diamond online that are " + centerstonemodel.CertificateCertificationLab + " Certified with " + centerstonemodel.StoneCut + " Diamond " + centerstonemodel.StoneClarity + " Diamond at Fascinating Diamonds";
              


            }
              


          }

            

        
    }
}