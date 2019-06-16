using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//model
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Common;
//controller
using EJewel.Controller.Admin.Master.Stone;
using EJewel.Controller.Common;


namespace EJewel.AdminView.Master.Stone
{
    public partial class ManageSideStone : System.Web.UI.Page
    {
        StoneShapeController objStoneShapeController = new StoneShapeController();
        long _editID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                //load stone category
                ListHelper.BindList(ddlStoneCategory, new StoneCategoryController().GetStoneCategoryList(0), "StoneCategoryID", "StoneCategoryName", ListHelper.DefaultList);
                //attribute
                ddlStoneCategory.Attributes.Add("onchange", "loadStoneDetails(this.value)");
                //load status
                ListHelper.BindList(ddlStatus, ListHelper.GetStatusSource(), "Value", "Text", null);
                //edit id
                if (Request.QueryString["id"] != null)
                {
                    _editID = Convert.ToInt64(Request.QueryString["id"]);
                    this.LoadEditData(_editID);
                }
                else
                {
                    //load default value
                    //cut
                    ddlCut.Items.Add(ListHelper.DefaultList);
                    //color
                    ddlColor.Items.Add(ListHelper.DefaultList);
                    //clarity
                    ddlClarity.Items.Add(ListHelper.DefaultList);
                    //shape
                    ddlShape.Items.Add(ListHelper.DefaultList);
                    //type
                    ddlType.Items.Add(ListHelper.DefaultList);
                }
            }

        }

        private void LoadEditData(long sidestoneId)
        {
            try
            {
                //access the details of the stone
                SideStoneModel stoneModel = new SideStoneController().GetSideStoneList(sidestoneId, CommonModel.RecordStatus.Both).FirstOrDefault();
                if (stoneModel != null)
                {
                    StoneSpecificationController controller = new StoneSpecificationController();
                    //load cut
                    ListHelper.BindList(ddlCut, controller.GetStoneSpecificationListFromCategory(stoneModel.StoneCategoryId, StoneSpecificationModel.PageName.Cut, CommonModel.RecordStatus.Enabled), "AutoID", "Name", ListHelper.DefaultList);
                    //load color
                    ListHelper.BindList(ddlColor, controller.GetStoneSpecificationListFromCategory(stoneModel.StoneCategoryId, StoneSpecificationModel.PageName.Color, CommonModel.RecordStatus.Enabled), "AutoID", "Name", ListHelper.DefaultList);
                    //load clarity
                    ListHelper.BindList(ddlClarity, controller.GetStoneSpecificationListFromCategory(stoneModel.StoneCategoryId, StoneSpecificationModel.PageName.Clarity, CommonModel.RecordStatus.Enabled), "AutoID", "Name", ListHelper.DefaultList);
                    //load shape
                    ListHelper.BindList(ddlShape, objStoneShapeController.StoneShapeListFromCategory(stoneModel.StoneCategoryId,StoneShapeModel.ShapeVisibility.BOTH, CommonModel.RecordStatus.Enabled), "StoneShapeId", "Shape", ListHelper.DefaultList);
                    //load type
                    ListHelper.BindList(ddlType, controller.GetStoneSpecificationListFromCategory(stoneModel.StoneCategoryId, StoneSpecificationModel.PageName.Type, CommonModel.RecordStatus.Enabled), "AutoID", "Name", ListHelper.DefaultList);
                    //do the selection
                 
                    ddlStoneCategory.SelectedValue = stoneModel.StoneCategoryId.ToString();
                    //clarity
                    ddlClarity.SelectedValue = stoneModel.StoneClarityId.ToString();
                    //color
                    ddlColor.SelectedValue = stoneModel.StoneColorId.ToString();
                    //cut
                    ddlCut.SelectedValue = stoneModel.StoneCutId.ToString();
                    //shape
                    ddlShape.SelectedValue = stoneModel.StoneShapeId.ToString();
                    //type
                    ddlType.SelectedValue = stoneModel.StoneTypeId.ToString();
                    //sku                
                    txtPrice.Text = Convert.ToString(stoneModel.StonePrice);
                    txtCarate.Text = Convert.ToString(stoneModel.StoneCarate);
                    ddlStatus.SelectedIndex = stoneModel.Status == true ? 0 : 1;                   
                    hdnID.Value = Convert.ToString(stoneModel.SideStoneId);
                }
                else
                {
                    //redirect stone list
                    Response.Redirect("/Master/Stone/ListSideStone.aspx?status=invalid&ref=edit");
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