<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="billingaddress--.aspx.cs" Inherits="EJewel.UserView.Checkout.billingaddress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">0

  <div class="container push-below-header">
<table class="table table-bordered table-striped" style="width:100%">


<tr><td style="width:150px;">First Name</td><td><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
    <td style="width:150px;" >
    Address</td><td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td></tr>
<tr><td></td><td ><asp:RequiredFieldValidator ID="rfvFirstName" runat="server" Display="Dynamic" ControlToValidate="txtFirstName" ErrorMessage="Please enter a valid first name." ValidationGroup="validatecheckout"></asp:RequiredFieldValidator></td>
    <td ></td><td><asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please Enter a Valid Address" ValidationGroup="validatecheckout"></asp:RequiredFieldValidator></td></tr>
<tr><td>Last Name</td><td ><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
    <td ></td><td></td></tr>
<tr><td></td><td >
<asp:RequiredFieldValidator ID="rfvLastName" runat="server" Display="Dynamic" ControlToValidate="txtLastName" ErrorMessage="Please Enter a Valid Last Name" ValidationGroup="validatecheckout"></asp:RequiredFieldValidator>

</td><td >City</td><td><asp:TextBox ID="txtCity" runat="server" CssClass="common_width"></asp:TextBox></td></tr>
<tr><td>Company</td><td ><asp:TextBox ID="txtCompany" runat="server"></asp:TextBox></td>
    <td ></td><td>
    <asp:RequiredFieldValidator ID="rfvCity" runat="server" Display="Dynamic" ControlToValidate="txtCity" ErrorMessage="Please Enter a Valid City Name" ValidationGroup="validatecheckout"></asp:RequiredFieldValidator>
    </td></tr>

<tr><td></td><td ></td><td ><asp:Label ID="lblStateName" runat="server"></asp:Label></td><td>
<asp:DropDownList ID="ddlStateName" runat="server"></asp:DropDownList>
<asp:TextBox ID="txtStateName" runat="server"></asp:TextBox>
</td></tr>
<tr><td>Phone</td><td style="width:250px;">
<asp:TextBox ID="txtCountryCode" runat="server" Width="70px"></asp:TextBox>

<asp:TextBox ID="txtPhoneNumber" runat="server" Width="90px"></asp:TextBox>
<asp:TextBox ID="txtIntlNumber" runat="server" Width="70px"></asp:TextBox>
    <br />
</td><td ></td><td>
<asp:Label ID="lblState" runat="server"></asp:Label>
</td></tr>
<tr><td></td><td >


<asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Please Enter PhoneNumber" Display="Dynamic" ValidationGroup="validatecheckout"></asp:RequiredFieldValidator>
<asp:Label ID="lblCountryCode" runat="server"></asp:Label>

</td>
    <td >
    <asp:Label ID="PostalCodeDisplayName" runat="server"></asp:Label>
    </td><td><asp:TextBox ID="txtZipCode" runat="server" CssClass="common_width"></asp:TextBox></td></tr>
<tr><td>EmailD</td><td ><asp:TextBox ID="txtEmailID" runat="server"></asp:TextBox></td>
    <td ></td><td>
    
    <asp:Label ID="lblZipCode" runat="server"></asp:Label>
    </td></tr>
<tr><td></td><td ><asp:RequiredFieldValidator ID="rfvEmailID" runat="server" 
        ControlToValidate="txtEmailID" Display="Dynamic" 
        ErrorMessage="Please Enter EmailID" ValidationGroup="validatecheckout" 
        SetFocusOnError="True"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="revEmailID" runat="server" 
        ControlToValidate="txtEmailID" ErrorMessage="Please Enter Valid EmailID" 
        Display="Dynamic" ValidationGroup="validatecheckout" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>



</td><td >Country</td><td><asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" onselectedindexchanged="ddlCountry_SelectedIndexChanged" EnableTheming="True"></asp:DropDownList></td></tr>
<tr><td>Re-type E-mail</td><td ><asp:TextBox ID="txtretypeemailID" runat="server"></asp:TextBox></td>
    <td ></td><td>
    </td></tr>

    <tr><td></td><td style="width:200px;"><asp:RequiredFieldValidator ID="rfvretypeEmailID" runat="server" ControlToValidate="txtretypeemailID" ErrorMessage="Please Enter Re-Type EmailID" ValidationGroup="validatecheckout"></asp:RequiredFieldValidator><br />
    <asp:CompareValidator ID="CVRetypeEmailID" runat="server" ControlToValidate="txtretypeemailID" ControlToCompare="txtEmailID" ErrorMessage="Your email and email confirmation do not match." ValidationGroup="validatecheckout"></asp:CompareValidator>
    
    </td><td ></td><td></td></tr>

    <tr><td><asp:Button ID="btnContinue" runat="server" Text="Continue" ValidationGroup="validatecheckout" 
            onclick="btnContinue_Click"  /></td></tr>
</table>

</div>
</asp:Content>
