using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EJewel.Controller.Common;
using EJewel.Controller.User;
using EJewel.Model.User;

namespace EJewel.UserView
{
    public partial class RegisterAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegisterAccount_Click(object sender, EventArgs e)
        {
            try
            {
                RegisterCustomerController objRegisterCustomerController = new RegisterCustomerController();
                if (objRegisterCustomerController.IsExitsRegisterCustomer(txtEmailID.Text.ToString().Trim()) == false)
                {
                    RegisterCustomerModel objRegisterCustomerModel = new RegisterCustomerModel();
                    objRegisterCustomerModel.CustomerEmailID = txtEmailID.Text.ToString().Trim();
                    objRegisterCustomerModel.CustomerPassword = txtPassword.Text.ToString().Trim();
                    objRegisterCustomerModel.CustomerStatus = Convert.ToBoolean("True");
                    objRegisterCustomerModel.ModifiedDateTime = DateTime.Now;
                    long ID = objRegisterCustomerController.SaveUpdateRegisterCustomer(objRegisterCustomerModel).CustomerID;
                    //lblmessage.Text = "Customer Details Save Sucessfully";
                    Session["RegisterUser"] = ID;
                    Response.Redirect("CustomerDetailsEditView.aspx");
                }
                else
                {
                    lblmessage.Text = "CustomerName Already Exits";
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
                objLogError.UserID = "1";
                new ErrorLogController().SetErrorLog(objLogError);
            }
            finally
            {
                ClearField();
            }
        }
        void ClearField()
        {
            txtConfirmPassword.Text = "";
            txtEmailID.Text = "";
            txtPassword.Text = "";
        }
    }
}