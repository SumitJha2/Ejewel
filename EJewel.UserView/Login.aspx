<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EJewel.UserView.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container push-below-header">

<div class="row">
				<div class="span12">
					<h2 class="section-heading noBottom">Checkout</h2>
				</div>
			</div>
			
			<div class="row">
				<div class="span12 push40">
					<div class="row">
						<div class="span3">
							<div class="block current">
								<span class="uber-text one-liner">1 /</span>
								<span class="primary">Options</span>
							</div>
							<div class="block pointer">
								<span class="uber-text one-liner">2 /</span>
								<span class="primary">Billing / Shipping</span>
							</div>
							<div class="block pointer">
								<span class="uber-text one-liner">3 /</span>
								<span class="primary">Payment</span>
							</div>
							<div class="block pointer">
								<span class="uber-text one-liner">4 /</span>
								<span class="primary">Confirmation</span>
							</div>
							
						</div>
						<div class="span4 offset1 phone-block">
							<p class="primary phone-block phone-push30">New Customers</p>
							<p>New to Fascinating Diamonds? You have two options:</p>
							<ul class="side-nav-second">
								<li>
									<input type="radio" name="register" id="new" checked>
									<label for="new">Register Account</label>
								</li>
								<li>
									<input type="radio" name="register" id="guest" checked>
									<label for="guest">Checkout as a Guest</label>
								</li>
							</ul>
							<p class="phone-full-width">
								By creating an account you will be able to shop faster,
								be up to date on an order’s status, and keep track of the
								orders you have previously made. You can also take 
								advantage of our coupon system and gift cards.
							</p>
							<input type="button" class="simple-submit secondary push30" value="continue" onclick="location.href='/RegisterAccount.aspx'">
						</div>
						<div class="span3 phone-block phone-push30">
							<p class="primary">Returning Customers</p>
							<div class="row">
								<div class="span3">
									<p>E-mail:</p>
								</div>
							</div>
							<div class="row">
								<div class="span3">
									<asp:TextBox ID="txtEmailID" runat="server"></asp:TextBox>
								</div>
							</div>
							<div class="row">
								<div class="span3">
									<p>Password:</p>
								</div>
							</div>
							<div class="row">
								<div class="span3">
									<asp:TextBox ID="txtPassword" runat="server" ></asp:TextBox>
								</div>
							</div>
						<asp:Button ID="btnLogin" runat="server" Text="login" 
                                        class="simple-submit secondary push30" onclick="btnLogin_Click" />
						</div>
					</div>
				</div>
			</div>

             



<%--<div class="container">
				<div class="row" id="close-login">
					<div class="span8 offset2">
						<div class="login">
							<div class="row">
								<div class="span3 offset1 phone-block">
									<p class="primary white">Login</p>
									<p class="push30">E-mail:</p>
								<asp:TextBox ID="txtEmailID" runat="server"></asp:TextBox>
									<p>Password:</p>
									<asp:TextBox ID="txtPassword" runat="server" ></asp:TextBox>
									<a href="#" class="adtext forgotten">forgot your password?</a>
                                    <asp:Button ID="btnLogin" runat="server" Text="login" 
                                        class="simple-submit secondary push30" onclick="btnLogin_Click" />
								
								</div>
								<div class="span3 margin-left30 phone-block">
									<p class="primary white">New Customer</p>
									<p class="push30">New to Diagonal? Register here, we won’t disappoint you.</p>
									<input type="button" class="simple-submit secondary push30" onclick="location.href='/RegisterAccount.aspx'" value="register">
								</div>
							</div>
						</div>
					</div>
				</div>
</div>--%>



		
		</div><!-- end container -->
</asp:Content>
