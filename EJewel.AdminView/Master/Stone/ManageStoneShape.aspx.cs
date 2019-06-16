using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.Admin.Master.Stone;
//controller
using EJewel.Controller.Admin.Master.Stone;
using EJewel.Controller.Common;
using EJewel.Model.Admin.Common;


namespace EJewel.AdminView.Master.Stone
{
    public partial class ManageStoneShape : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                ListHelper.BindList(ddlStoneCategory, new StoneCategoryController().GetStoneCategoryList(0), "StoneCategoryID", "StoneCategoryName", ListHelper.DefaultList);
                //status
                ListHelper.BindList(ddlStatus, ListHelper.GetStatusSource(), "Value", "Text", null);
                ListHelper.BindList(ddlShape, new StoneShapeController().GetStoneShapeFromMaster(0, CommonModel.RecordStatus.Enabled), "AutoID", "Name", ListHelper.DefaultList);

                string stoneshapeId = Request.QueryString["id"];
                if (stoneshapeId != null)
                {
                    int shapeId = Convert.ToInt32(stoneshapeId);
                    BindStoneShape(shapeId);
                }
                /*else
                {
                    Response.Redirect("Pagenotfound.aspx");
                }
                 */
            }
        }
        public void  BindStoneShape(int stoneshapeId)
        {
            try
            {
                StoneShapeModel lstModel = new StoneShapeController().StoneShapeList(stoneshapeId,StoneShapeModel.ShapeVisibility.BOTH, CommonModel.RecordStatus.Both).FirstOrDefault();
                if (lstModel != null)
                {
                    ddlShape.SelectedValue = lstModel.ShapeId.ToString();
                    ddlStoneCategory.SelectedValue = lstModel.StoneCategoryId.ToString();
                    ddlStatus.SelectedIndex = lstModel.Status == true ? 0 : 1;
                    if(lstModel.CenterStoneVisible==true && lstModel.SideStoneVisible==true)
                    {
                        ddlVisiable.SelectedIndex = 0;
                    }
                    else if(lstModel.CenterStoneVisible==true)
                    {
                        ddlVisiable.SelectedIndex = 1;
                    }
                    else
                    {
                        ddlVisiable.SelectedIndex = 2;
                    }
                 
                   

                    hdnID.Value = Convert.ToString(lstModel.StoneShapeId);
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