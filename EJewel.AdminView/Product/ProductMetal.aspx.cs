using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//model
using EJewel.Model.Admin.Master.Metal;
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Common;
//controller
using EJewel.Controller.Admin.Master.Metal;
using EJewel.Controller.Admin.Product;

using EJewel.Controller.Common;

namespace EJewel.AdminView.Product
{
    public partial class ProductMetal : System.Web.UI.Page
    {
        ProductMetalController objController = new ProductMetalController();
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
                string qs_status = Request.QueryString["status"];
                if (!string.IsNullOrEmpty(qs_productID))
                {
                    _productID = Convert.ToInt64(qs_productID);
                    //load the default
                    if (!IsPostBack)
                    {
                        //get the product details
                        ProductDetailsModel proDetails = new ProductDetailsController().GetProductDetails(_productID);
                        if (proDetails != null)
                        {
                            //set value
                            //set product detils
                            lblSku.Text = proDetails.SKU + " / " + proDetails.ProductTitle;
                            txtWeight.Text = proDetails.ProductWeight.ToString();
                            txtWidth.Text = proDetails.ProductWidth.ToString();
                            //loadmetal type list
                            this.LoadMetalType(_productID);
                            //set the link of center stone
                            lnkCenterStone.NavigateUrl = "/Product/ProductCenterStone.aspx?id=" + _productID + "&ref=metal";
                        }
                        else
                        {
                            //redirect to the details page with error
                            Response.Redirect("/Product/ProductList.aspx?ref=metal&status=invalid");
                        }
                    }
                }
                else
                {
                    //redirect to tje product page
                    Response.Redirect("/Product/ProductList.aspx?ref=metal&status=missing");
                }
                //for status
                string q_status = Request.QueryString["status"];
                if (!string.IsNullOrEmpty(q_status))
                {
                    if (q_status == "success")
                    {
                        lblMessage.Text = "Product Metal Details Save Successfully.";
                        lblMessage.CssClass = "small_success";
                    }
                }
              
            }
        }
        /*
         * Partha Ranjan
         * @ 21-01-13
         * This function load the metal type
         * */
        public void LoadMetalType(long productID)
        {
            try
            {
                dgvMetalType.DataSource = new MetalTypeController().GetMetalTypeList(0, CommonModel.RecordStatus.Both);
                dgvMetalType.DataBind();
                dgvMetalType.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void dgvMetalType_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //this event add the radio button event for single check
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    HiddenField hdnMetalTypeID=(HiddenField)e.Row.FindControl("hdnMetalTypeID");
                    RadioButton rdoDefault = (RadioButton)e.Row.FindControl("rdoDefault");
                    CheckBox chkAvialableMetal = (CheckBox)e.Row.FindControl("chkAvialableMetal");
                    if (rdoDefault != null)
                    {
                        //add the attribute of unckecj
                        rdoDefault.Attributes.Add("onclick", "checkRadioChangeInGrid('" + dgvMetalType.ClientID + "','" + rdoDefault.ClientID + "')");
                        //assign the value in the control
                        ProductMetalModel model = objController.GetProductMetal(_productID, Convert.ToInt32(hdnMetalTypeID.Value));
                        //set the value
                        if (model != null)
                        {
                            chkAvialableMetal.Checked = model.Status ? true : false;
                            rdoDefault.Checked = model.DefaultMetal;
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
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                //update the metal weight
                double weight = Convert.ToDouble(txtWeight.Text);
                double width = Convert.ToDouble(txtWidth.Text);
                //update the metal weight
                if (weight > 0 && width>0)
                {
                    if (objController.UpdateProduct_Weight_Width(_productID, weight, width))
                    {
                        //now save the 
                        if (this.SaveUpdateMetalWeight())
                        {
                            Response.Redirect("/Product/ProductMetal.aspx?id=" + _productID + "&status=success");
                        }
                        else
                        {
                            //error
                        }
                    }
                    else
                    {
                        //show error
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
        /*
         * Partha Ranjan
         * 06-02-13
         * This function save the metal weight
         * */
        private bool SaveUpdateMetalWeight()
        {
            try
            {
                int metalType = 0;
                bool defaultMetal = false;
                bool status = false;              


                foreach (GridViewRow row in dgvMetalType.Rows)
                {
                    //access the control
                    HiddenField hdnMetalTypeID = (HiddenField)row.FindControl("hdnMetalTypeID");
                    CheckBox chkAvialableMetal = (CheckBox)row.FindControl("chkAvialableMetal");
                    RadioButton rdoDefault = (RadioButton)row.FindControl("rdoDefault");
                   
                    //now check for null
                    if (hdnMetalTypeID != null)
                    {
                        //access data
                        metalType = Convert.ToInt32(hdnMetalTypeID.Value);
                        defaultMetal = rdoDefault.Checked ? true : false;
                        status = chkAvialableMetal.Checked ? true : false;
                        //now save/update the details
                        ProductMetalModel model = new ProductMetalModel()
                        {
                            ProductID = _productID,
                            MetalTypeID = metalType,
                            DefaultMetal = defaultMetal,
                            Status = status
                        };
                       
                            objController.SaveUpdateProductMetal(model);
                                             
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}