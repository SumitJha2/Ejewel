<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EJewel.AdminView.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="/asset/template/css/login.css" rel="stylesheet" type="text/css" />
    <script src="/asset/template/js/template/jquery.min.js" type="text/javascript"></script>
    <script src="/asset/template/js/template/login.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
      <div id="bar">
        <div id="container">
            <!-- Login Starts Here -->
            <div id="loginContainer">
               <a href="#" id="loginButton"><span>Login</span><em></em></a>
                <div style="clear:both"></div>
                <div id="loginBox">                
                    <div id="loginForm">
                        <fieldset id="body">
                            <fieldset>
                                <label for="email">User ID</label>



                                <input type="text" name="email" id="email" />
                            </fieldset>
                            <fieldset>
                                <label for="password">Password</label>
                                <input type="password" name="password" id="password" />
                            </fieldset>
                            <input type="button" onclick="location.href='/Default.aspx'" id="login" value="Sign in" />
                            <label for="checkbox"><input type="checkbox" id="checkbox" />Remember me</label>
                        </fieldset>
                        <span><a href="#">Forgot your password?</a></span>
                    </div>
                </div>
            </div>
            <!-- Login Ends Here -->
        </div>

       
    </div>
<div class="PageContent">
    <img src="/asset/template/images/site/logo.jpg" />
</div>
    </form>
</body>
</html>
