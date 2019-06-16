<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="EJewel.UserView.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style type="text/css">
   .msgcolor
   {
   	color:Red;
   }
</style>
<div class="container push-below-header">
			<div class="row">
				<div class="span3 side-options phone-span-diff">
					<h3 class="subheading">Contact us:</h3>
                   <p style="text-align:justify;">We hold immense value and trust in our customer’s and hence would be glad to assist you at every step of your purchase. We are available for you 24 hours X 7 days a week to clear all your queries and help you in the best way possible.</p> 
                   <p class="secondary push20">Chat with us and get the answer to your questions instantly.</p>
					<%--<ul class="side-nav">
						<li><a href="#">Live Chat</a></li>
				
					</ul>--%>
                    <p>Live Chat</p>
				</div>


				<div class="span6">
					<div class="row push30">
						<div class="span6">
							<p class="primary long phone-block">
								Get in touch.we aim to guide you at every step !
							</p>
						</div>
					</div>

					<div class="row push20 phone-block">
						<div class="span3">
							<p>First Name: <asp:RequiredFieldValidator ID="rfvFirstName"  runat="server" CssClass="msgcolor" ControlToValidate="txtFirstName" ErrorMessage="*"></asp:RequiredFieldValidator></p>
						</div>
						<div class="span3">
							<p>Last Name: <asp:RequiredFieldValidator ID="rfvLastName"  runat="server" CssClass="msgcolor" ControlToValidate="txtLastName" ErrorMessage="*"></asp:RequiredFieldValidator></p>
						</div>
					</div>	
					<div class="row">
						<div class="span3">
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
							
						</div>
						<div class="span3">
							<%--<input type="text">--%>
                         <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
						</div>
					</div>
					<div class="row phone-block">
						<div class="span3">
							<p>E-mail: <asp:RequiredFieldValidator ID="rfvemail" Display="Dynamic"  runat="server" CssClass="msgcolor" ControlToValidate="txtEmail" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rexvalidator" runat="server" 
                                    ControlToValidate="txtEmail" CssClass="msgcolor" ErrorMessage="*"  Display="Dynamic"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </p>
						</div>
						<div class="span3">
							<p>Telephone: <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="txtTelephone" CssClass="msgcolor" ErrorMessage="*"  Display="Dynamic"
                                    ValidationExpression="^[ #-]*([0-9][ /-]*){0,12}$"></asp:RegularExpressionValidator></p>
						</div>
					</div>
					<div class="row">
						<div class="span3">
						<%--	<input type="text">--%>
                           <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
						</div>
						<div class="span3">
					
                               <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
						</div>
					</div>
					<div class="row phone-block">
						<div class="span6">
							<p>Message:  <asp:RequiredFieldValidator ID="rfvMsg" Display="Dynamic"  runat="server" CssClass="msgcolor" ControlToValidate="txtMessage" ErrorMessage="*"></asp:RequiredFieldValidator></p>
						</div>
					</div>
					<div class="row">
						<div class="span6">
							
                             <asp:TextBox ID="txtMessage" TextMode="MultiLine" runat="server"></asp:TextBox>
						</div>
					</div>
					<div class="row">
						<div class="span6 push40">							
                            <asp:Button ID="btnSave" runat="server" Text="Submit" 
                                class="simple-submit secondary" onclick="btnSave_Click" />
                                <span id="spanMsg" runat="server"  class="msgcolor"></span>

						</div>
					</div>
				</div>


               

				<div class="span3 push30 lister phone-block">
					<p class="subheading">Our Stores</p>
					<p class="secondary push20">Address</p>
					<p class="push10"> 42 West 48th St. Suite 1603,</p>
					<p>New York,</p>
					<p>NY 10036 </p>
			
				
					<p class="secondary push20">Call Us Now</p>
					<p class="push10">USA (NY): 212.840.1811</p>


                  <p class="secondary push20">  Leave a message</p>

<p class="push10">Drop in a voice message on our office numbers and we will call you back.</p>
                    <p class="secondary push20">Email Us</p>
					<p>Mail us your queries or complaints and we will revert back to you within two business days.</p>
					
					<p class="push10">info@fascinatingdiamonds.com</p>
					
				</div>
			</div>
		</div><!-- end container -->
        <br />
</asp:Content>
