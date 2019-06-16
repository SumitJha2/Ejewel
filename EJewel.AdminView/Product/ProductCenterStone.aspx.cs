using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//model
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Master.Setting;
//controller
using EJewel.Controller.Admin.Master.Stone;
using EJewel.Controller.Admin.Product;
using EJewel.Controller.Admin.Master.Setting;
using EJewel.Controller.Common;

namespace EJewel.AdminView.Product
{
    public partial class ProductCenterStone : System.Web.UI.Page
    {
        ProductCenterStoneController objController = new ProductCenterStoneController();
        CenterStoneController objCenterStoneController = new CenterStoneController();
        StoneShapeController objStoneShapeController = new StoneShapeController();
        long _productID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                string qs_productID = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(qs_productID))
                {
                    _productID = Convert.ToInt64(qs_productID);
                    //load deafult onclick=""
                    ProductDetailsModel pdModel = new ProductDetailsController().GetProductDetails(_productID);
                    if (pdModel != null)
                    {
                        if (!IsPostBack)
                        {
                            lnkSideStone.NavigateUrl = "/Product/ProductSideStone.aspx?id=" + _productID + "&view=side_stone&stone_category=1&ref=center_stone";
                            //show detils of the page
                            //set the value
                            lblSKU.Text = pdModel.SKU + " / " + pdModel.ProductTitle;
                            //load stone category
                            this.LoadShape();
                            this.LoadSettingType();
                            //basic info
                            ProductCenterStoneModel centerStoneModel = this.LoadCenterStoneDetails();
                            //load saved shape
                            this.LoadCenterStoneSavedShape(centerStoneModel);

                        }
                    }
                    else
                    {
                        //redirect to home page
                        Response.Redirect("/Product/ProductList.aspx");
                    }
                }
                else
                {
                    //redirect to home page
                    Response.Redirect("/Product/ProductList.aspx");
                }
                //for status
                string q_status = Request.QueryString["status"];
                if (!string.IsNullOrEmpty(q_status))
                {
                    if (q_status == "success")
                    {
                        lblMessage.Text = "Product Center Stone Details Save Successfully.";
                        lblMessage.CssClass = "small_success";
                    }
                }
            }
        }

        long GetSelectedStone()
        {
            long stone_id = 0;
            int total_row = gridStone.Rows.Count;
            GridViewRow row = null;
            HiddenField hdnStoneId = null;
            RadioButton rdoDefault = null;
            for (int i = 0; i < total_row; i++)
            {
                row = gridStone.Rows[i];
                if (row != null)
                {
                    //access the cotrols
                    hdnStoneId = (HiddenField)row.FindControl("hdnStoneId");
                    rdoDefault = (RadioButton)row.FindControl("rdoDefault");
                    if (hdnStoneId != null && rdoDefault.Checked)
                    {
                        stone_id = Convert.ToInt64(hdnStoneId.Value);
                        break;
                    }
                }
            }
            return stone_id;
        }

        void ShowLooseDiamond(long stoneId, int shape, double minCarat, double maxCarat)
        {
            try
            {
                //access the center stone
                gridStone.DataSource = objCenterStoneController.GetCenterStoneListFromShapeAndRange(shape, minCarat, maxCarat, CenterStoneModel.CenterStoneProvider.FascinatingDiamonds);
                gridStone.DataBind();
                gridStone.HeaderRow.TableSection = TableRowSection.TableHeader;
                if (stoneId > 0)
                {
                    int total_row = gridStone.Rows.Count;
                    GridViewRow row = null;
                    HiddenField hdnStoneId = null;
                    RadioButton rdoDefault = null;
                    for (int i = 0; i < total_row; i++)
                    {
                        row = gridStone.Rows[i];
                        if (row != null)
                        {
                            hdnStoneId = (HiddenField)row.FindControl("hdnStoneId");
                            rdoDefault = (RadioButton)row.FindControl("rdoDefault");
                            if (hdnStoneId != null && Convert.ToInt64(hdnStoneId.Value) == stoneId)
                            {
                                rdoDefault.Checked = true;
                                break;
                            }
                        }
                    }
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

        void LoadShape()
        {
            gridShape.DataSource = objStoneShapeController.StoneShapeListFromCategory(ConstantHelper.STONE_CATEGORY_DIAMOND,StoneShapeModel.ShapeVisibility.CENTERSTONE, CommonModel.RecordStatus.Enabled);
            gridShape.DataBind();
            gridShape.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        void LoadSettingType()
        {
            try
            {
                ListHelper.BindList(ddlSettingType, new StoneCategorySettingTypeController().StoneSettingTypeListFromStoneCategoryType(ConstantHelper.STONE_CATEGORY_DIAMOND, CommonModel.RecordStatus.Enabled), "StoneCategorySettingTypeId", "SettingTypeName", ListHelper.DefaultList);
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

        void LoadCenterStoneSavedShape(ProductCenterStoneModel centerStoneModel)
        {
            #region Product Center Stone Shape
            int default_shape_id = 0;
            long default_stone_id = 0;
            try
            {
                List<ProductCenterStoneShapeModel> centerStoneShapeModel = objController.GetProductCenterStoneShapeList(_productID, ConstantHelper.STONE_CATEGORY_DIAMOND, CommonModel.RecordStatus.Enabled);
                if (centerStoneShapeModel != null)
                {
                    int total_center_stone_shape = centerStoneShapeModel.Count;
                    int total_shape_row = gridShape.Rows.Count;
                    if (total_center_stone_shape > 0 && total_shape_row > 0)
                    {
                        ProductCenterStoneShapeModel model = null;
                        CheckBox chkAvailable = null;
                        RadioButton rdoDefaultShape = null;
                        HiddenField hdnShapeId = null;
                        for (int i = 0; i < total_center_stone_shape; i++)
                        {
                            model = centerStoneShapeModel[i];
                            if (model != null && model.Status)
                            {
                                for (int j = 0; j < total_shape_row; j++)
                                {
                                    hdnShapeId = (HiddenField)gridShape.Rows[j].FindControl("hdnShapeId");
                                    chkAvailable = (CheckBox)gridShape.Rows[j].FindControl("chkAvailable");
                                    rdoDefaultShape = (RadioButton)gridShape.Rows[j].FindControl("rdoDefaultShape");
                                    if (chkAvailable != null)
                                    {
                                        if (model.Status && Convert.ToInt32(hdnShapeId.Value) == model.StoneShapeId)
                                        {
                                            chkAvailable.Checked = model.Status;
                                            rdoDefaultShape.Checked = model.DefaultShape;
                                            if (default_shape_id == 0)
                                            {
                                                if (model.DefaultShape)
                                                {
                                                    default_shape_id = Convert.ToInt32(hdnShapeId.Value);
                                                    default_stone_id = model.StoneId;
                                                }
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (centerStoneModel != null)
                    {
                        this.ShowLooseDiamond(default_stone_id, default_shape_id, centerStoneModel.StoneMinCarat, centerStoneModel.StoneMaxCarat);
                    }
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
            #endregion
        }

        ProductCenterStoneModel LoadCenterStoneDetails()
        {
            #region Product Center Stone Details
            ProductCenterStoneModel centerStoneModel = objController.GetProductCenterStone(_productID, ConstantHelper.STONE_CATEGORY_DIAMOND);
            try
            {

                if (centerStoneModel != null)
                {
                    txtMinCarat.Text = centerStoneModel.StoneMinCarat.ToString();
                    txtMaxCarat.Text = centerStoneModel.StoneMaxCarat.ToString();
                    ddlSettingType.SelectedValue = Convert.ToString(centerStoneModel.StoneCategorySettingTypeId);
                    //
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
             return centerStoneModel;
            
            #endregion
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //access the controls
                double minCarat = Convert.ToDouble(txtMinCarat.Text);
                double maxCarat = Convert.ToDouble(txtMaxCarat.Text);
                int categorySettingId = Convert.ToInt32(ddlSettingType.SelectedValue);
                //save process
                ProductCenterStoneModel centerStoneModel = new ProductCenterStoneModel()
                {
                    ProductId = _productID,
                    Status = true,
                    StoneCategoryId = ConstantHelper.STONE_CATEGORY_DIAMOND,
                    StoneCategorySettingTypeId = categorySettingId,
                    StoneMaxCarat = maxCarat,
                    StoneMinCarat = minCarat
                };
                centerStoneModel = objController.SaveUpdateProductCenterStone(centerStoneModel);
                //now do the save the stone center operation
                if (centerStoneModel.ProductCenterStoneId > 0)
                {
                    int total_shape = gridShape.Rows.Count;
                    if (total_shape > 0)
                    {
                        GridViewRow rowShape = null;
                        HiddenField hdnShapeId = null;
                        CheckBox chkAvailable = null;
                        RadioButton rdoDefaultShape = null;
                        for (int i = 0; i < total_shape; i++)
                        {
                            //access the controls
                            rowShape = gridShape.Rows[i];
                            if (rowShape != null)
                            {
                                //access the controls
                                hdnShapeId = (HiddenField)rowShape.FindControl("hdnShapeId");
                                chkAvailable = (CheckBox)rowShape.FindControl("chkAvailable");
                                rdoDefaultShape = (RadioButton)rowShape.FindControl("rdoDefaultShape");
                                if (hdnShapeId != null)
                                {
                                    ProductCenterStoneShapeModel model = new ProductCenterStoneShapeModel()
                                    {
                                        DefaultShape = rdoDefaultShape.Checked ? true : false,
                                        StoneId = 0,
                                        ProductCenterStoneId = centerStoneModel.ProductCenterStoneId,
                                        Status = chkAvailable.Checked ? true : false,
                                        StoneShapeId = Convert.ToInt32(hdnShapeId.Value)
                                    };
                                    objController.SaveUpdateCenterStoneShape(model);
                                }
                            }
                        }
                    }
                    Response.Redirect("/Product/ProductCenterStone.aspx?id=" + _productID + "&status=success");
                }
                else
                {
                    //error
                    lblMessage.Text = "Error In Save";
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

        protected void gridShape_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    RadioButton rdoDefaultShape = (RadioButton)e.Row.FindControl("rdoDefaultShape");
                    if (rdoDefaultShape != null)
                    {
                        rdoDefaultShape.Attributes.Add("onclick", "checkRadioChangeInGrid('" + gridShape.ClientID + "','" + rdoDefaultShape.ClientID + "')");
                    }
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

        protected void gridStone_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    RadioButton rdoDefault = (RadioButton)e.Row.FindControl("rdoDefault");
                    if (rdoDefault != null)
                    {
                        rdoDefault.Attributes.Add("onclick", "checkRadioChangeInGrid('" + gridStone.ClientID + "','" + rdoDefault.ClientID + "')");
                    }
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

        protected void btnSaveStone_Click(object sender, EventArgs e)
        {
            try
            {
                long stone_id = this.GetSelectedStone();
                if (stone_id > 0)
                {
                    ProductCenterStoneModel centerStoneModel = objController.GetProductCenterStone(_productID, ConstantHelper.STONE_CATEGORY_DIAMOND);
                    if (centerStoneModel != null)
                    {
                        //save the stone details
                        ProductCenterStoneShapeModel centerStoneShapeModel = objController.GetProductCenterStoneShapeList(_productID, ConstantHelper.STONE_CATEGORY_DIAMOND, CommonModel.RecordStatus.Enabled).Where(tbl => tbl.DefaultShape == true).FirstOrDefault();
                        if (centerStoneShapeModel != null)
                        {
                            //save the cente stone details
                            ProductCenterStoneShapeModel model = new ProductCenterStoneShapeModel()
                            {
                                DefaultShape = true,
                                StoneId = stone_id,
                                ProductCenterStoneId = centerStoneModel.ProductCenterStoneId,
                                Status = true,
                                StoneShapeId = centerStoneShapeModel.StoneShapeId
                            };
                            objController.SaveUpdateCenterStoneShape(model);
                            Response.Redirect("/Product/ProductCenterStone.aspx?id=" + _productID + "&status=success");
                        }
                        else
                        {
                            lblMessage.Text = "Error In save";
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Error In save";
                    }
                }
                else
                {
                    lblMessage.Text = "Select Default Stone";
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