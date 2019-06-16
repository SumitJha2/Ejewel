using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.User;
using EJewel.Controller.User;
using EJewel.Controller.Admin.SiteSetting;
using EJewel.Model.Admin.SiteSetting;

using EJewel.Controller.Common;

namespace EJewel.UserView
{
    public partial class Login : System.Web.UI.Page
    {
        RegisterCustomerController objRegisterCustomerController = new RegisterCustomerController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmailID.Text != "" && txtPassword.Text != "")
                {
                    List<RegisterCustomerModel> objRegisterCustomerlist = objRegisterCustomerController.GetRegisterCustomerList(txtEmailID.Text, txtPassword.Text);
                    if (objRegisterCustomerlist.Count > 0)
                    {
                        string IP4Address = String.Empty;
                        HttpRequest requests = base.Request;
                        string address = Server.HtmlEncode(requests.UserHostAddress);
                        string HostName = requests.UserHostName;
                        string[] Languages = requests.UserLanguages;
                        Session["IP"] = address;



                        Session["RegisterUser"] = objRegisterCustomerlist[0].CustomerID;

                        try
                        {
                            CustomerLoginDetailsController objCustomerLoginDetailsList = new CustomerLoginDetailsController();
                            CustomerLoginDetailsModel objloggeduser = new CustomerLoginDetailsModel();
                            objloggeduser.CustomerID = Session["RegisterUser"].ToString();
                            objloggeduser.LoggedDatetime = Convert.ToDateTime(DateTime.Now);
                            objloggeduser.LoggedCustomerIP = address;
                            objCustomerLoginDetailsList.SaveUpdateCustomerLoginDetails(objloggeduser);
                            Response.Redirect("CustomerDetailsEditView.aspx", false);
                          
                        }
                        catch (Exception ex)
                        {
                            ErrorLogModel objLogError = new ErrorLogModel();
                            objLogError.ErrorMessage = ex.Message;
                            objLogError.ErrorSource = ex.Source;
                            objLogError.StackTrace = ex.StackTrace;
                            objLogError.InnerException = Convert.ToString(ex.InnerException);
                            objLogError.LogTime = DateTime.Now;
                            objLogError.UserID = Session["RegisterUser"].ToString();
                            new ErrorLogController().SetErrorLog(objLogError);
                        }
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {


            }
        }
    }
}