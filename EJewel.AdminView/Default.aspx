<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EJewel.AdminView.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="assets/themes/admin/stylesheets/reset.css" rel="stylesheet" type="text/css" />
    <link href="assets/themes/admin/stylesheets/text.css" rel="stylesheet" type="text/css" />
    <link href="assets/themes/admin/stylesheets/buttons.css" rel="stylesheet" type="text/css" />

    <link href="assets/themes/admin/stylesheets/theme-default.css" rel="stylesheet" type="text/css" />
    <link href="assets/themes/admin/stylesheets/login.css" rel="stylesheet" type="text/css" />




</head>
<body>
    <form id="form1" runat="server">
    
    <div>
   
      
      <div id="login">
	<h1>Dashboard</h1>
	<div id="login_panel">
			
			<div class="login_fields">
				<div class="field">
					<label for="email">User ID <div style="float:right;">

<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="validateLogin" runat="server" ForeColor="Red" ControlToValidate="txtUserID" ErrorMessage="Please enter User ID !!!"></asp:RequiredFieldValidator>


                    </div>
                    </label>

                    <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
                  

				</div>
				
				<div class="field">
					<label for="password">Password <div style="float:right;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="validateLogin" runat="server" ForeColor="Red" ControlToValidate="txtPassword" ErrorMessage="Please enter password !!!"></asp:RequiredFieldValidator>
                    
                    
                    
                    </div>
                    </label>

                     <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
<small><a  href="#">Forgot Password?</a></small>
                   
 
                   
						
				</div>
                <div><asp:Label ID="lblmessage" runat="server"></asp:Label></div>
			</div> <!-- .login_fields -->
			
			<div class="login_actions">
                <asp:Button ID="btnLogin" CssClass="btn btn-small" runat="server" 
                    ValidationGroup="validateLogin" Text="Login" onclick="btnLogin_Click" />
                 


				<%--<button type="submit" class="" tabindex="3">Login</button>--%>
			</div>
	
	</div> <!-- #login_panel -->		
</div> <!-- #login -->




    </div>
    
    </form>
</body>
</html>
