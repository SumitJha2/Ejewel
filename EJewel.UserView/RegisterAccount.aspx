<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterAccount.aspx.cs" Inherits="EJewel.UserView.RegisterAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container push-below-header">
		


  Email  <asp:TextBox ID="txtEmailID" runat="server" ></asp:TextBox><br />
  <asp:RequiredFieldValidator ID="rfvEmailID" runat="server" ControlToValidate="txtEmailID" ErrorMessage="Please Enter EmailID" Display="Dynamic" ValidationGroup="ValidateRegisterCustomer"></asp:RequiredFieldValidator>
  <asp:RegularExpressionValidator ID="revEmailID" runat="server" 
        ControlToValidate="txtEmailID" ErrorMessage="Please Enter Correct EmailID" 
        Display="Dynamic" ValidationGroup="ValidateRegisterCustomer" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />

   Password  <asp:TextBox ID="txtPassword" runat="server"  TextMode="Password" Width="100%" Height="45px" BackColor="#d6d8d7"></asp:TextBox><br />
     <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please Enter Password" Display="Dynamic" ValidationGroup="ValidateRegisterCustomer"></asp:RequiredFieldValidator>
     <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Minimum 6 Character Required" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9\s]{6}$" ValidationGroup="ValidateRegisterCustomer"></asp:RegularExpressionValidator>
     
     <br />

    Password    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Width="100%" Height="45px" BackColor="#d6d8d7"></asp:TextBox><br />
      <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Please Enter ConfirmPassword" Display="Dynamic" ValidationGroup="ValidateRegisterCustomer"></asp:RequiredFieldValidator>
      <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" ErrorMessage="Password Not Match" ValidationGroup="ValidateRegisterCustomer"></asp:CompareValidator><br />


    <asp:Button ID="btnRegisterAccount" runat="server" Text="Register" ValidationGroup="ValidateRegisterCustomer" 
        onclick="btnRegisterAccount_Click" />
        <asp:Label ID="lblmessage" runat="server"></asp:Label>
		</div><!-- end container -->



</asp:Content>
