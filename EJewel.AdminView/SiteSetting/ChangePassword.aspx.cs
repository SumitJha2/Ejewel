using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Controller.Admin.SiteSetting;
using EJewel.Model.Admin.SiteSetting;
using System.Net;
using System.Net.Mail;
using System.Text;

using EJewel.Controller.Common;


namespace EJewel.AdminView.SiteSetting
{
    public partial class ChangePassword : System.Web.UI.Page
    {
      
        UserDetailsModel objModel = new UserDetailsModel();
        UserDetailsController objController = new UserDetailsController();
        string userId = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] != null)
            {
                userId =Session["loginID"].ToString();
                lbUserID.InnerText = userId;
                if (Request.QueryString["save"] == "success")
                {
                    spnMessage.InnerText = "Password changed successfully.";
                }
            }
            else
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
        }
        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {


                if (txtNewPassword.Text.Trim().Length < 6)
                {
                    lblmessage.Text = "Password should be minimum of six character.";
                    return;
                }
                else
                {
                    if (txtOldPassword.Text.Trim() != txtNewPassword.Text.Trim())
                    {
                        if (objController.CheckPasswordExist(userId, txtOldPassword.Text.Trim()))
                        {
                            bool flag = objController.ChangePassword(userId, txtNewPassword.Text.Trim());
                            if (flag == true)
                            {
                                Response.Redirect("/SiteSetting/ChangePassword.aspx?save=success");

                            }
                        }
                        else
                        {
                            lblmessage.Text = "Old password is incorrect.";
                        }
                    }
                    else
                    {
                        lblmessage.Text = "Old and new password can't be same.";
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SiteSetting/ChangePassword.aspx");
        }
/*
        public void Email_Setup()
        {
            objModel=objController.

          
          
            StringBuilder strB = new StringBuilder();
            strB.Append("\n\r");
            strB.Append(" Customer Name : " + userId + "<br/>");
            strB.AppendLine();
            strB.Append(" Email ID      : " + txtEmail.Text + "<br/>");
            strB.AppendLine();
            strB.Append(" Phone No      : " + txtPhone.Text + "<br/>");
            strB.AppendLine();
            strB.Append(" Enquiry       : " + txtDesc.Text + "<br/>");
            strB.AppendLine();
            strB.Append(" Reference URL : " + Path.GetFileName(Request.PhysicalPath) + "<br/>");
            strB.AppendLine();
            string[] strSku = new string[100];
            strSku = lblSetSKU.Text.ToString().Split(':');
            strB.Append(" SKU No        : " + strSku[1] + "<br/>");
            strB.AppendLine();
            //string strMes1 = utl.sendE_Mail("manju@pixel-studios.com,ritzsavla@gmail.com", "Enquiry for SKU No : " + dtvSettingInfo.Rows[0].Cells[1].Text, strB.ToString());
            #region
            string htmlbody = "";
            htmlbody = "<table width='500' border='1' cellpadding='0' cellspacing='0' bordercolor='#d17d05'><tr><td><table width='100%' height='144' border='0' cellpadding='5' cellspacing='0'><tr bgcolor='#d17d05'><td height='24' colspan='3' valign='top'><font face='Arial, Helvetica, sans-serif' size='4' color='#FFFFFF'><b>ONLINE ENQUIRY - " + strSku[1] + "</b></font></td></tr><tr><td width='24%' height='24' valign='top'><font face='Arial, Helvetica, sans-serif' size='2' color='#000000'>Customer Name</font></td><td valign='top'><font face='Arial, Helvetica, sans-serif' size='2' color='#000000'>: </font></td><td width='74%' valign='top'>" + txtName.Text + "</td></tr><tr><td height='24' valign='top'><font face='Arial, Helvetica, sans-serif' size='2' color='#000000'>E-mail Id</font></td><td valign='top'><font face='Arial, Helvetica, sans-serif' size='2' color='#000000'>: </font></td><td width='74%' valign='top'>" + txtEmail.Text + "</td></tr><tr><td height='24' valign='top'><font face='Arial, Helvetica, sans-serif' size='2' color='#000000'>Phone No</font></td><td valign='top'><font face='Arial, Helvetica, sans-serif' size='2' color='#000000'>: </font></td><td width='74%' valign='top'>" + txtPhone.Text + "</td></tr><tr><td height='24' valign='top'><font face='Arial, Helvetica, sans-serif' size='2' color='#000000'>Enquiry</font></td>        <td valign='top'><font face='Arial, Helvetica, sans-serif' size='2' color='#000000'>: </font></td><td width='74%' valign='top'>" + txtDesc.Text + "</td></tr> <tr>       <td height='24' valign='top'><font face='Arial, Helvetica, sans-serif' size='2' color='#000000'>Reference URL</font></td><td valign='top'><font face='Arial, Helvetica, sans-serif' size='2' color='#000000'>: </font></td><td width='74%' valign='top'>" + Path.GetFileName(Request.PhysicalPath) + "</td></tr><tr><td height='24' valign='top'><font face='Arial, Helvetica, sans-serif' size='2' color='#000000'>SKU No</font></td> <td valign='top'><font face='Arial, Helvetica, sans-serif' size='2' color='#000000'>: </font></td><td width='74%' valign='top'>" + strSku[1] + "</td></tr></table></td></tr></table>";
            #endregion
            string strMes = utl.sendE_Mail("info@fascinatingdiamonds.com", "Online Enquiry - " + strSku[1] + "", htmlbody.ToString());
            htmlbody = "<table width='500' border='1' cellpadding='0' cellspacing='0'><tr><td><table width='100%' border='0' cellpadding='5' cellspacing='0'>";

            string htmlbodys = "";

            htmlbodys = "<table width='500' border='1' cellpadding='0' cellspacing='0'><tr><td><table width='100%' border='0' cellpadding='5' cellspacing='0'>";
            htmlbodys = htmlbodys + "<tr bgcolor='#d17d05'><td  style='height:10px;font-family:Palatino Linotype;' valign='top'><font size='4' color='#FFFFFF'>";
            htmlbodys = htmlbodys + "<b>Online Enquiry :</b></font></td></tr><tr><td width='40%' height='24' valign='top' style='font-family:Palatino Linotype'><font size='3' color='#000000'>Dear" + " " + txtName.Text + "</font></td></tr>";
            htmlbodys = htmlbodys + "<tr><td  valign='top' style='font-family:Palatino Linotype'><i><font  size='3' color='#000000'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Thanks for enquiry.We will get back to you shortly.</font></i></td></tr></table></td></tr></table>";
            string strMessageuser = utl.sendE_Mail(txtEmail.Text, "" + "Online Enquiry - " + strSku[1] + "", htmlbodys.ToString());



            if (strMes.Trim().Length > 0)
            {
                Label2.Text = "Error while send mail";
            }
            else
            {
                Label2.Text = "Thank you for your Enquiry. We will get back you shortly";
                txtName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtDesc.Text = string.Empty;

            }
        }

        public void Send_Email()
        {
            try
            {
                string login = "queries@fascinatingdiamonds.com";
                string password = "S@mbeet29";
                System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
                mail.To = strTo;

                //Check  differentfacets@hotmail.com
                string sesValue = "";
                try
                {
                    sesValue = HttpContext.Current.Session["Mailto"].ToString();
                    if (sesValue == "FD")
                    {
                        mail.Cc = "differentfacets@hotmail.com";
                    }
                    else
                    {
                        mail.Bcc = "differentfacets@hotmail.com";
                        //differentfacets@hotmail.com
                    }

                }
                catch
                {
                    mail.Bcc = "differentfacets@hotmail.com";
                }

                //Check

                mail.From = login;
                mail.Subject = strSubject;
                mail.Body = strBody;
                // mail.BodyEncoding = System.Web.Mail.MailEncoding;
                mail.BodyFormat = System.Web.Mail.MailFormat.Html;
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", login);
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", password);
                //System.Web.Mail.SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
                System.Web.Mail.SmtpMail.SmtpServer = "smtp.fascinatingdiamonds.com";
                System.Web.Mail.SmtpMail.Send(mail);
                mail = null;
                return "";

            }
            catch (Exception ex)
            {
                utl.ExecuteQuery("Insert into fd_errorlog(ErPage,ErCause) values('payment mail','" + ex.InnerException.ToString() + "')");
                return ex.Message.ToString();
            }

        }
 */
      
    }
}