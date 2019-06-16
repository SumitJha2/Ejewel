using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EJewel.Model.Admin.Master.Category;
using EJewel.Model.Admin.Master.Setting;
using EJewel.Controller.Common;
using EJewel.Controller.Admin.Master.Category;
using EJewel.Controller.Admin.Master.Setting;

namespace EJewel.AdminView.Master.Setting
{
    public partial class ListProductFilter : System.Web.UI.Page
    {
        CategoryController objController = new CategoryController();
        ProductFilterModel objFilterModel = new ProductFilterModel();
        ProductFilterController objFilterController = new ProductFilterController();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    this.LoadSubCategory();
                }
                //for status
                string q_status = Request.QueryString["status"];
                if (!string.IsNullOrEmpty(q_status))
                {
                    if (q_status == "success")
                    {
                        lblMessage.Text = "Filter  Details Saved Successfully.";
                        lblMessage.CssClass = "small_success";
                    }
                }
                /* else
                 {
                     Response.Redirect("Pagenotfound.aspx");
                 }
                 */
            }
        }

        void LoadSubCategory()
        {
            try
            {
                List<SubCategoryModel> lstSubCategory = objController.GetSubCategoryList(0, CommonModel.RecordStatus.Enabled).OrderBy(tbl => tbl.SubCategoryName).OrderBy(tbl => tbl.CategoryName).ToList();
                gridSubCategory.DataSource = lstSubCategory;
                gridSubCategory.DataBind();
                gridSubCategory.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow gv in gridSubCategory.Rows)
                {
                    ProductFilterModel objModel = new ProductFilterModel();
                    // ProductFilterController objProductController = new ProductFilterController();

                    HiddenField hdnSubCategoryId = (HiddenField)gv.FindControl("hdnSubCategoryId");
                    CheckBox chkCenterStoneShape = (CheckBox)gv.FindControl("chkCenterStoneShape");
                    CheckBox chkCenterStoneSetting = (CheckBox)gv.FindControl("chkCenterStoneSetting");
                    CheckBox chkSideStoneShape = (CheckBox)gv.FindControl("chkSideStoneShape");

                    CheckBox chkSideStoneSetting = (CheckBox)gv.FindControl("chkSideStoneSetting");
                    CheckBox chkGemStoneColor = (CheckBox)gv.FindControl("chkGemStoneColor");
                    CheckBox chkGemStoneType = (CheckBox)gv.FindControl("chkGemStoneType");

                    TextBox txtPriceMin = (TextBox)gv.FindControl("txtPriceMin");
                    TextBox txtPriceMax = (TextBox)gv.FindControl("txtPriceMax");
                    TextBox txtPriceDiff = (TextBox)gv.FindControl("txtPriceDiff");

                    objModel.SubCategoryId = Convert.ToInt32(hdnSubCategoryId.Value);
                    objModel.CenterStoneShape = chkCenterStoneShape.Checked == true ? true : false;
                    objModel.CenterStoneSetting = chkCenterStoneSetting.Checked == true ? true : false;
                    objModel.SideStoneSetting = chkSideStoneSetting.Checked == true ? true : false;
                    objModel.SideStoneShape = chkSideStoneShape.Checked == true ? true : false;
                    objModel.GemStoneColor = chkGemStoneColor.Checked == true ? true : false;
                    objModel.GemStoneType = chkGemStoneType.Checked == true ? true : false;
                    //price
                    objModel.MaxPrice = this.Price(txtPriceMax.Text);
                    objModel.MinPrice = this.Price(txtPriceMin.Text);
                    objModel.PriceDiff = this.Price(txtPriceDiff.Text);

                    new ProductFilterController().SaveUpdateProductFilter(objModel);
                }
                Response.Redirect("/Master/Setting/ListProductFilter.aspx?status=success");
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
        private double Price(string text)
        {
            try
            {
              if(text.Length>0)
              {
                  return Convert.ToDouble(text);
              }
            }
            catch(Exception ex)
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
            return 0;
        }
        protected void gridSubCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hdnSubCategoryId = (HiddenField)e.Row.FindControl("hdnSubCategoryId");
                    CheckBox chkCenterStoneShape = (CheckBox)e.Row.FindControl("chkCenterStoneShape");
                    CheckBox chkSideStoneShape = (CheckBox)e.Row.FindControl("chkSideStoneShape");
                    CheckBox chkCenterStoneSetting = (CheckBox)e.Row.FindControl("chkCenterStoneSetting");
                    CheckBox chkSideStoneSetting = (CheckBox)e.Row.FindControl("chkSideStoneSetting");
                    CheckBox chkGemStoneColor = (CheckBox)e.Row.FindControl("chkGemStoneColor");
                    CheckBox chkGemStoneType = (CheckBox)e.Row.FindControl("chkGemStoneType");
                    //
                    TextBox txtPriceMin = (TextBox)e.Row.FindControl("txtPriceMin");
                    TextBox txtPriceMax = (TextBox)e.Row.FindControl("txtPriceMax");
                    TextBox txtPriceDiff = (TextBox)e.Row.FindControl("txtPriceDiff");
                    //set attribute 
                    txtPriceMin.Attributes.Add("onkeydown", "return allow_only_number(event)");
                    txtPriceMax.Attributes.Add("onkeydown", "return allow_only_number(event)");
                    txtPriceDiff.Attributes.Add("onkeydown", "return allow_only_number(event)");
                    //
                    objFilterModel = objFilterController.GetProductFilter(Convert.ToInt32(hdnSubCategoryId.Value));
                    if (objFilterModel != null)
                    {
                        chkCenterStoneShape.Checked = objFilterModel.CenterStoneShape;
                        chkSideStoneShape.Checked = objFilterModel.SideStoneShape;
                        chkCenterStoneSetting.Checked = objFilterModel.CenterStoneSetting;
                        chkSideStoneSetting.Checked = objFilterModel.SideStoneSetting;
                        chkGemStoneColor.Checked = objFilterModel.GemStoneColor;
                        chkGemStoneType.Checked = objFilterModel.GemStoneType;
                        txtPriceMin.Text = objFilterModel.MinPrice.ToString();
                        txtPriceMax.Text = objFilterModel.MaxPrice.ToString();
                        txtPriceDiff.Text = objFilterModel.PriceDiff.ToString();
                    }

                }
            }
            catch(Exception ex)
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