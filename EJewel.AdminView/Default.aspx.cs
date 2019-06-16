using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using EJewel.Model.Admin.SiteSetting;
using EJewel.Controller.Admin.SiteSetting;
using System.Data;
using System.Xml;

using EJewel.Controller.Common;

namespace EJewel.AdminView
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Abandon();
            }
        }
        public string GetVisitorIpAddress()
        {

            string stringIpAddress;

            stringIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (stringIpAddress == null) //may be the HTTP_X_FORWARDED_FOR is null
            {

                stringIpAddress = Request.ServerVariables["REMOTE_ADDR"];//we can use REMOTE_ADDR

            }

            return "Your ip is " + stringIpAddress;

        }
        public string GetLanIPAddress()
        {

            //Get the Host Name

            string stringHostName = Dns.GetHostName();

            //Get The Ip Host Entry

            IPHostEntry ipHostEntries = Dns.GetHostEntry(stringHostName);

            //Get The Ip Address From The Ip Host Entry Address List

            IPAddress[] arrIpAddress = ipHostEntries.AddressList;

            return arrIpAddress[arrIpAddress.Length - 1].ToString();

        }

      
        protected void btnLogin_Click(object sender, EventArgs e)
        {
             

            List<UserDetailsModel> objLoginList = new UserDetailsController().CheckLoginUser(txtUserID.Text.ToString().Trim(), txtPassword.Text.ToString().Trim());
            if (objLoginList.Count > 0)
            {
                Session["loginID"] = txtUserID.Text.ToString().Trim();
                Session["UType"] = objLoginList[0].UserTypeId;
                //Session["UID"] = objLoginList[0].UID;
                Session["Name"] = objLoginList[0].UserName;
                //IPHostEntry hostname = Dns.GetHostByName(textBox1.Text);
                //IPAddress[] ip = hostname.AddressList;
                //textBox2.Text = ip[0].ToString();



                string IP4Address = String.Empty;
                // foreach (IPAddress IPA in Dns.GetHostAddresses(Request.ServerVariables["REMOTE_ADDR"].ToString()))
                // {
                //      if (IPA.AddressFamily.ToString() == "InterNetwork")
                //      {
                //        IP4Address = IPA.ToString();
                //        break;
                //      }
                // }

                //if (IP4Address != String.Empty)
                //{
                // string x=IP4Address;
                //}

                //foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
                //{
                //  if (IPA.AddressFamily.ToString() == "InterNetwork")
                //  {
                //    IP4Address = IPA.ToString();
                //    break;
                //  }
                //}

                //string y=IP4Address;
                //Session["IP"] =  IP4Address;


                // string strVisitorIpAddress = GetVisitorIpAddress();
                //string strLanIpAddress = GetLanIPAddress();



                //string strHostName = System.Net.Dns.GetHostName();
                //string clientIPAddress = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
                //string clientip = clientIPAddress.ToString();


                HttpRequest requests = base.Request;



                string address = Server.HtmlEncode(requests.UserHostAddress);
                // = request.UserHostAddress;
                string HostName = requests.UserHostName;
                string[] Languages = requests.UserLanguages;
                Session["IP"] = address;


               //DataTable dt=GetLocation(address);
                try
                {
                    LoginDetailsController objLoginDetailsList = new LoginDetailsController();
                    LoginDetailsModel objloggeduser = new LoginDetailsModel();
                    objloggeduser.LoginID = Session["loginID"].ToString();
                    objloggeduser.LoggedDatetime = Convert.ToDateTime(DateTime.Now);
                    objloggeduser.LoggedUserIP = address;
                    objLoginDetailsList.SaveUpdateLoginDetails(objloggeduser);
                    Response.Redirect("/Dashboard.aspx");

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
            else
            {
                ClearField();
                Session.Abandon();
                lblmessage.Text = "Invalid UserID and Password";
               // Response.Redirect("/Default.aspx");
            }

           // Response.Redirect("Dashboard.aspx");
        }

        void ClearField()
        {
            txtUserID.Text = "";
            txtPassword.Text = "";
        }
    }
}