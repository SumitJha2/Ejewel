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
using EJewel.Controller.Common;
using EJewel.Model.Admin.Common;

namespace EJewel.AdminView.Master.Stone
{
    public partial class StoneSpecificationManagement : System.Web.UI.Page
    {
        StoneSpecificationController objController = new StoneSpecificationController();
       public string _viewName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                _viewName = Request.QueryString["view"];
                if (!string.IsNullOrEmpty(_viewName))
                {
                    //get the page name
                    StoneSpecificationModel.PageName pgname = objController.GetPageName(_viewName);
                    if (pgname != StoneSpecificationModel.PageName.None)
                    {
                        ltrlHeading.Text = objController.Heading;
                        //load stone category
                        ListHelper.BindList(ddlStoneCategory, new StoneCategoryController().GetStoneCategoryList(0), "StoneCategoryID", "StoneCategoryName", ListHelper.DefaultList);
                        //status
                        ListHelper.BindList(ddlStatus, ListHelper.GetStatusSource(), "Value", "Text", null);
                        //show the edit date
                        string qs_id = Request.QueryString["id"];
                        if (!string.IsNullOrEmpty(qs_id))
                        {
                            int edit_id = Convert.ToInt32(qs_id);
                            if (edit_id > 0)
                            {
                                //get the details of the data
                                StoneSpecificationModel model = objController.GetStoneSpecificationList(edit_id, pgname, CommonModel.RecordStatus.Both).FirstOrDefault();
                                if (model != null)
                                {
                                    //set the data
                                    hdnID.Value = model.AutoID.ToString();
                                    ddlStoneCategory.Items.FindByValue(model.StoneCategoryId.ToString()).Selected = true;
                                    txtName.Text = model.Name;
                                    txtShortDescription.Text = model.ShortDescription;
                                    ddlStatus.SelectedIndex = model.Status ? 0 : 1;
                                }
                                else
                                {
                                    //error
                                    //redirect ot list
                                    Response.Redirect("/Master/Stone/ListStoneSpecification.aspx?view=" + _viewName);
                                }
                            }
                            else
                            {
                                Response.Redirect("/Master/Stone/ListStoneSpecification.aspx?view=" + _viewName);
                            }
                        }
                      
                    }
                    else
                    {
                        Response.Redirect("/Default.aspx");
                    }
                }
                //else
                //{
                //    //Redirect to stone page
                //    Response.Redirect("/Default.aspx");
                //}
                else
                {
                    Response.Redirect("Pagenotfound.aspx");
                }
            }
        }

    }
}