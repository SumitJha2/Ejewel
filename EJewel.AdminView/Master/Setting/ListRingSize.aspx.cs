using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//model
using EJewel.Model.Admin.Master.Category;
using EJewel.Model.Admin.Common;
//controller
using EJewel.Controller.Admin.Master.Category;

using EJewel.Controller.Common;

namespace EJewel.AdminView.Master.Setting
{
    public partial class ListRingSize : System.Web.UI.Page
    {
        CategoryController objController = new CategoryController();

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
                        lblMessage.Text = "Category Ring Size Details Save Successfully.";
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
                List<SubCategoryModel> lstSubCategory = objController.GetSubCategoryList(0, CommonModel.RecordStatus.Enabled).OrderBy(tbl=>tbl.SubCategoryName).OrderBy(tbl => tbl.CategoryName).ToList();
                gridSubCategory.DataSource = lstSubCategory;
                gridSubCategory.DataBind();
                gridSubCategory.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int total_row = gridSubCategory.Rows.Count;
                if(total_row>0)
                {
                    GridViewRow row = null;
                    HiddenField hdnSubCategoryId = null;
                    CheckBox chkAvailable = null;
                    CheckBox chkEngraving = null;
                    for(int i=0;i<total_row;i++)
                    {
                        row = gridSubCategory.Rows[i];
                        if(row!=null)
                        {
                            //access the controls
                            hdnSubCategoryId = (HiddenField)row.FindControl("hdnSubCategoryId");
                            chkAvailable = (CheckBox)row.FindControl("chkAvailable");
                            chkEngraving = (CheckBox)row.FindControl("chkEngraving");
                            
                            // changes by sumit on 05-06-2013

                            if(hdnSubCategoryId!=null)
                            {
                                objController.UpdateHasRing(Convert.ToInt32(hdnSubCategoryId.Value), chkAvailable.Checked ? true : false, chkEngraving.Checked?true:false);
                            }
                        }
                    }
                    Response.Redirect("/Master/Setting/ListRingSize.aspx?status=success");
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