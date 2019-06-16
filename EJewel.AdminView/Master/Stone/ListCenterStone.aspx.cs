using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using EJewel.Controller.Admin.Master.Stone;
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Common;

using EJewel.Controller.Common;
namespace EJewel.AdminView.Master.Stone
{
    public partial class ListCenterStone : System.Web.UI.Page
    {
        CenterStoneController objController = new CenterStoneController();
        StoneSpecificationController objStoneSpecificationController = new StoneSpecificationController();
        List<StoneSpecificationModel> model = new List<StoneSpecificationModel>();
        public int _totalRecord= 0;
        public int _provider = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                _totalRecord = objController.TotalCenterStone(Model.Admin.Master.Stone.CenterStoneModel.CenterStoneProvider.FascinatingDiamonds);
                ///Master/Stone/ManageCenterStone.aspx
                string qs_provider = Request.QueryString["provider"];
                if (!string.IsNullOrEmpty(qs_provider))
                {
                    qs_provider = qs_provider.Trim();
                    switch (qs_provider)
                    {
                        default:
                        case "def":
                            {
                                _provider = 1;
                                ltrlHeading.Text = "Center Stone (FD)";
                                lnkCreate.NavigateUrl = "/Master/Stone/ManageCenterStone.aspx";
                            } break;
                        case "rapnet":
                            {
                                _provider = 2;
                                ltrlHeading.Text = "Center Stone (Rapnet)";
                                lnkCreate.NavigateUrl = "javascript:void(0)";
                                lnkCreate.Text = "Generate Rapnet Diamonds";
                                lnkCreate.Attributes.Add("onclick", "popupwindow('/Master/Stone/ManageCenterStoneRapnet.aspx',300,100)");
                                _totalRecord = objController.TotalCenterStone(Model.Admin.Master.Stone.CenterStoneModel.CenterStoneProvider.Rapnet);
                            }
                            break;
                    }
                }
                else
                {
                    Response.Redirect("Pagenotfound.aspx");
                }
                //load data
                bindStoneShape();
                bindStoneCut();
                bindStoneColor();
                bindStoneClarity();
            }
        }

        public void bindStoneShape()
        {
            try
            {
                List<StoneShapeModel> shapemodel = new StoneShapeController().StoneShapeListFromCategory(ConstantHelper.STONE_CATEGORY_DIAMOND,StoneShapeModel.ShapeVisibility.CENTERSTONE, CommonModel.RecordStatus.Enabled);

                if (shapemodel != null && shapemodel.Count > 0)
                {
                    ddlShape.DataSource = shapemodel;
                    ddlShape.DataTextField = "Shape";
                    ddlShape.DataValueField = "StoneShapeId";
                    ddlShape.DataBind();
                }
                ddlShape.Items.Insert(0, new ListItem("--Shape--", "0"));
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

        public void bindStoneCut()
        {
            try
            {
                model = objStoneSpecificationController.GetStoneSpecificationListFromCategory(ConstantHelper.STONE_CATEGORY_DIAMOND, StoneSpecificationModel.PageName.Cut, CommonModel.RecordStatus.Enabled);
                if (model != null && model.Count > 0)
                {

                    ddlCut.DataSource = model;
                    ddlCut.DataTextField = "Name";
                    ddlCut.DataValueField = "AutoID";
                    ddlCut.DataBind();
                }
                ddlCut.Items.Insert(0, new ListItem("--Cut--", "0"));
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

        public void bindStoneColor()
        {
            try
            {
                model = objStoneSpecificationController.GetStoneSpecificationListFromCategory(ConstantHelper.STONE_CATEGORY_DIAMOND, StoneSpecificationModel.PageName.Color, CommonModel.RecordStatus.Enabled);
                if (model != null && model.Count > 0)
                {
                    ddlColor.DataSource = model;
                    ddlColor.DataTextField = "Name";
                    ddlColor.DataValueField = "AutoID";
                    ddlColor.DataBind();
                }
                ddlColor.Items.Insert(0, new ListItem("--Color--", "0"));
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

        public void bindStoneClarity()
        {
            try
            {
                model = objStoneSpecificationController.GetStoneSpecificationListFromCategory(ConstantHelper.STONE_CATEGORY_DIAMOND, StoneSpecificationModel.PageName.Clarity, CommonModel.RecordStatus.Enabled);
                if (model != null && model.Count > 0)
                {

                    ddlClarity.DataSource = model;
                    ddlClarity.DataTextField = "Name";
                    ddlClarity.DataValueField = "AutoID";
                    ddlClarity.DataBind();
                }
                ddlClarity.Items.Insert(0, new ListItem("--Clarity--", "0"));
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