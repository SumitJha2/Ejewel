using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//model
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Common.Sfm;
//controller
using EJewel.Controller.Admin.Master.Stone;
using EJewel.Controller.Admin.Common.Sfm;
//rapnet
using EJewel.AdminView.com.rapaport.technet;

using EJewel.Controller.Common;
namespace EJewel.AdminView.Master.Stone
{
    public partial class ManageCenterStoneRapnet : System.Web.UI.Page
    {
        StoneSpecificationController objStoneSpecificationController = new StoneSpecificationController();
        SfmController objSfmController = new SfmController();
        CenterStoneController objCenterStoneController = new CenterStoneController();
        const double EXTRA_PERCENT = 35;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
        }

        private int SpecificationId(List<StoneSpecificationModel> lstSpecification, string search_data)
        {
            //replace (_) with space
            search_data = search_data.Trim();//.Replace('_', ' ');
            StoneSpecificationModel model = lstSpecification.Where(tbl => tbl.Name == search_data && tbl.StoneCategoryId == ConstantHelper.STONE_CATEGORY_DIAMOND).FirstOrDefault();
            if (model != null)
            {
                return model.AutoID;
            }
            return 0;
        }

        private int SfmId(List<SfmModel> lstSpecification, string search_data)
        {
            search_data = search_data.Trim();
            SfmModel model = lstSpecification.Where(tbl => tbl.Name == search_data).FirstOrDefault();
            if (model != null)
            {
                return model.AutoID;
            }
            return 0;
        }

        private int StoneShapeId(List<StoneShapeModel> lstShape, string shape_name)
        {
            shape_name = shape_name.Trim();
            StoneShapeModel model = lstShape.Where(tbl => tbl.Shape == shape_name).FirstOrDefault();
            if (model != null)
            {
                return model.StoneShapeId;
            }
            return 0;
        }

        private DataTable RapnetData()
        {
            com.rapaport.technet.RapNetInventoryLink webServiceManager = new com.rapaport.technet.RapNetInventoryLink();
            //This must be done in HTTPS protocol
            webServiceManager.Login("76511", "shahsalil29");
            //After log in you will receive a encrypted ticket with your credentials. This will be used to authenticate your session.
            //Now you can choose to change the protocol to HTTP so it works faster. 
            webServiceManager.Url = "http" + webServiceManager.Url.Substring(5);
            //You must use the Init() method to get the parameter class. 
            com.rapaport.technet.RapNetInventoryLinkParameters setPatams = webServiceManager.Init();
            webServiceManager.Timeout = 420000;
            Shapes[] objshapes = new Shapes[10];
            objshapes[0] = Shapes.ROUND;
            objshapes[1] = Shapes.PRINCESS;
            objshapes[2] = Shapes.EMERALD;
            objshapes[3] = Shapes.ASSCHER;
            objshapes[4] = Shapes.MARQUISE;
            objshapes[5] = Shapes.OVAL;
            objshapes[6] = Shapes.RADIANT;
            objshapes[7] = Shapes.PEAR;
            objshapes[8] = Shapes.HEART;
            objshapes[9] = Shapes.CUSHION;
            //Color
            Colors[] MyColors = new Colors[7];
            MyColors[0] = Colors.D;
            MyColors[1] = Colors.E;
            MyColors[2] = Colors.F;
            MyColors[3] = Colors.G;
            MyColors[4] = Colors.H;
            MyColors[5] = Colors.I;
            MyColors[6] = Colors.J;

            //Lab
            Labs[] MyLab = new Labs[1];
            MyLab[0] = Labs.GIA;
            //pass parameter
            setPatams.ShapeCollection = objshapes;
            setPatams.ColorCollection = MyColors;
            //setPatams.Location = Locations.USA;
            setPatams.Location = Locations.New_York;
         


            setPatams.LabCollection = MyLab;
            //Seller
            int[] MySeller = new int[5];
            MySeller[0] = 14948;
            MySeller[1] = 20996;
            MySeller[2] = 21684;
            MySeller[3] = 31449;
            MySeller[4] = 32640;
            //sex extra
            setPatams.MaxSize = 3; //Max carat
            setPatams.MinTotalPrice = 0.0;//Min Price
            //setPatams.IncludeMemberCollection = MySeller;
            //store in dataset
            DataSet ds = webServiceManager.GetDiamonds(setPatams);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            return null;
        }

        private void ManageData(DataTable table)
        {

            try
            {
                if (table != null)
                {
                    #region Access Mapping Data
                    //diamond details
                    List<StoneShapeModel> lstShape = new StoneShapeController().StoneShapeListFromCategory(ConstantHelper.STONE_CATEGORY_DIAMOND,StoneShapeModel.ShapeVisibility.CENTERSTONE, CommonModel.RecordStatus.Enabled);

                    List<StoneSpecificationModel> lstColor = objStoneSpecificationController.GetStoneSpecificationListFromCategory(ConstantHelper.STONE_CATEGORY_DIAMOND, StoneSpecificationModel.PageName.Color, CommonModel.RecordStatus.Enabled);

                    List<StoneSpecificationModel> lstCut = objStoneSpecificationController.GetStoneSpecificationListFromCategory(ConstantHelper.STONE_CATEGORY_DIAMOND, StoneSpecificationModel.PageName.Cut, CommonModel.RecordStatus.Enabled);

                    List<StoneSpecificationModel> lstClarity = objStoneSpecificationController.GetStoneSpecificationListFromCategory(ConstantHelper.STONE_CATEGORY_DIAMOND, StoneSpecificationModel.PageName.Clarity, CommonModel.RecordStatus.Enabled);
                    //diamonds certificate details
                    List<SfmModel> lstGridle = objSfmController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.CertificateGridle);

                    List<SfmModel> lstSymmetry = objSfmController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.CertificateSymmetry);

                    List<SfmModel> lstPolish = objSfmController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.CertificatePolish);

                    List<SfmModel> lstCulet = objSfmController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.CertificateCulet);

                    List<SfmModel> lstFlouresence = objSfmController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.CertificateFlouresence);

                    List<SfmModel> lstLab = objSfmController.GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.CertificateLab);
                    #endregion

                    #region Save Region
                    //save operation
                    int total_diamonds = table.Rows.Count;

                    if (total_diamonds > 0)
                    {
                        int ColorID = 0, ShapeID = 0, CutID = 0, ClarityID = 0, GridleID = 0, SymmetryID = 0, PolishID = 0, CuletID = 0, FlouresenceID = 0, LabID = 0;
                        CenterStoneModel model = null;
                        //tuncate tbale
                        objCenterStoneController.TuncateCenterStone(CenterStoneModel.CenterStoneProvider.Rapnet);
                        string color = "";
                        for (int i = 0; i < total_diamonds; i++)
                        {
                            //
                            color = table.Rows[i]["Color"].ToString();
                            if(color.Length>1)
                            {
                                color = color.Substring(0, 1);
                            }
                            ColorID = this.SpecificationId(lstColor, color);
                            //
                            ShapeID = this.StoneShapeId(lstShape, table.Rows[i]["Shape"].ToString());
                            //
                            CutID = table.Rows[i]["Cut Grade"].ToString()!="" ? this.SpecificationId(lstCut, table.Rows[i]["Cut Grade"].ToString()) : this.SpecificationId(lstCut, "Very Good");
                            //
                            ClarityID = this.SpecificationId(lstClarity, table.Rows[i]["Clarity"].ToString());
                            //
                            GridleID = this.SfmId(lstGridle, table.Rows[i]["Girdle"].ToString());
                            //
                            SymmetryID = this.SfmId(lstSymmetry, table.Rows[i]["Symmetry"].ToString());
                            //
                            PolishID = this.SfmId(lstPolish, table.Rows[i]["Polish"].ToString());
                            //
                            CuletID = this.SfmId(lstCulet, table.Rows[i]["Culet"].ToString());
                            //
                            FlouresenceID = this.SfmId(lstFlouresence, table.Rows[i]["Fluorescence"].ToString());
                            //
                            LabID = this.SfmId(lstLab, table.Rows[i]["Lab"].ToString());
                            //create save procedure

                            model = new CenterStoneModel()
                            {
                                SKU = table.Rows[i]["RapNet Lot #"].ToString(),
                                StoneCutId = CutID,
                                StoneColorId = ColorID,
                                StoneClarityId = ClarityID,
                                StoneShapeId = ShapeID,
                                StoneTypeId = 0,
                                StoneCarate = table.Rows[i]["Weight"].ToString() == string.Empty ? 0 : Convert.ToDouble(table.Rows[i]["Weight"].ToString()),
                                StonePrice = table.Rows[i]["RapNet Price"].ToString() == string.Empty ? 0 : this.PriceCalculation(Convert.ToDouble(table.Rows[i]["RapNet Price"])),
                                CertificateDepth = table.Rows[i]["Depth %"].ToString() == string.Empty ? 0 : Convert.ToDouble(table.Rows[i]["Depth %"]),
                                CertificateTable = table.Rows[i]["Table %"].ToString() == string.Empty ? 0 : Convert.ToDouble(table.Rows[i]["Table %"]),
                                CertificateGridleId = GridleID,
                                CertificateSymmetryId = SymmetryID,
                                CertificatePolishId = PolishID,
                                CertificateCuletId = CuletID,
                                CertificateFlouresenceId = FlouresenceID,
                                CertificateMeasurement = table.Rows[i]["Measurements"].ToString(),
                                CertificateCrown = Convert.ToDouble(0.00),
                                CertificateCrownAngle = Convert.ToDouble(0.00),
                                CertificatePavillion = Convert.ToDouble(0.00),
                                CertificatePavillionAngle = Convert.ToDouble(0.00),
                                Certification = table.Rows[i]["Cert #"].ToString(),
                                CertificateCertificationLabId = LabID,
                                CertificationFile = table.Rows[i]["Certificate URL"].ToString(),
                                Status = true
                            };
                            objCenterStoneController.SaveUpdateCenterStone(model, CenterStoneModel.CenterStoneProvider.Rapnet);
                        }
                        Response.Redirect("/Master/Stone/ManageCenterStoneRapnet.aspx?status=success");
                    }
                    #endregion
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

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            this.ManageData(this.RapnetData());
        }

        private double PriceCalculation(double price)
        {
            if(price>0)
            {
                price =price+ Math.Round((EXTRA_PERCENT * price)/100);
            }
            return price;
        }
    }
}