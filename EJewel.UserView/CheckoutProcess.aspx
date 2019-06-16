<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckoutProcess.aspx.cs" Inherits="EJewel.UserView.CheckoutProcess" %>
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
							<div id="step1" runat="server" class="block current">
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


                            <asp:RadioButtonList CssClass="side-nav-second" ID="RadioButtonList1"  runat="server">
                            <asp:ListItem   Selected="True" >Register Account</asp:ListItem>
                            <asp:ListItem  >Checkout as a Guest</asp:ListItem>
                            </asp:RadioButtonList>

						
							<p class="phone-full-width">
								By creating an account you will be able to shop faster,
								be up to date on an order’s status, and keep track of the
								orders you have previously made. You can also take 
								advantage of our coupon system and gift cards.
							</p>
							<input type="submit" class="simple-submit secondary push30" value="continue">
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
									<input type="text">
								</div>
							</div>
							<div class="row">
								<div class="span3">
									<p>Password:</p>
								</div>
							</div>
							<div class="row">
								<div class="span3">
									<input type="text">
								</div>
							</div>
							<input type="submit" class="simple-submit secondary push30" value="login">
						</div>




					</div>
				</div>
			</div>
		</div>
</asp:Content>
