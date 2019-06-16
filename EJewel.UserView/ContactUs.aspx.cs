using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.Admin.Extras;
using EJewel.Controller.Admin.Extras;

namespace EJewel.UserView
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["save"] == "success")
            {
                spanMsg.InnerText = "Thank you for contact us";
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ContactDetailsController objController = new ContactDetailsController();
            ContactDetailsModel objModel = new ContactDetailsModel();
            objModel.FirstName = txtFirstName.Text;
            objModel.LastName = txtLastName.Text;
            objModel.Message = txtMessage.Text;
            objModel.Email = txtEmail.Text;
            objModel.Telephone = txtTelephone.Text;
            objController.SaveContactDetails(objModel);          
            Response.Redirect("/ContactUs.aspx?save=success");
           
        }
    }
}