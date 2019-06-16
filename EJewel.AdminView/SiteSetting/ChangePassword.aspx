<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="EJewel.AdminView.SiteSetting.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<style type="text/css">
.validation_cls
{
	color:Red;
	font-size:11px;
}
</style>
<div id="contentHeader">
    <h1>Change Password</h1>
</div>
<div class="container">
<table class="table table-bordered table-striped" style="width:50%">
 <tr><td></td><td colspan="2">
        <asp:Label ID="lblmessage" CssClass="validation_cls"  Font-Bold="true" Font-Size="11px" runat="server" ></asp:Label>
    
    </td>
    </tr>


       <tr>
         <td><span class="small_error">&nbsp;*&nbsp;</span>User ID </td>
         <td><label id="lbUserID" runat="server"></label>
         </td>
     </tr>
     <tr><td></td><td></td></tr>
       <tr>
         <td><span class="small_error">&nbsp;*&nbsp;</span>Old Password &nbsp;<span class="validation_cls"></span> </td>
         <td><asp:TextBox ID="txtOldPassword" ValidationGroup="ValidatePassword"  runat="server" Font-Size="11px" TabIndex="3" Width="200px" TextMode="Password"></asp:TextBox>
         </td>
     </tr>
     <tr>
    <td></td><td><asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" CssClass="validation_cls" Text="Please Enter Old Password !!!" ControlToValidate="txtOldPassword" SetFocusOnError="true" ValidationGroup="ValidatePassword"></asp:RequiredFieldValidator></td>
     </tr>   
     
      <tr>
         <td ><span class="small_error">&nbsp;*&nbsp;</span>New Password &nbsp;<span class="validation_cls"></span></td>
         <td><asp:TextBox ID="txtNewPassword" ValidationGroup="ValidatePassword" TextMode="Password"  runat="server" Font-Size="11px" TabIndex="3" Width="200px"></asp:TextBox>
         </td>
     </tr>
     <tr><td></td><td><asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" CssClass="validation_cls" Text="Please Enter New Password !!!" ControlToValidate="txtNewPassword" SetFocusOnError="true" ValidationGroup="ValidatePassword"></asp:RequiredFieldValidator>
     </td></tr>
     <tr>
         <td ><span class="small_error">&nbsp;*&nbsp;</span>Confirm Password &nbsp;<span class="validation_cls"></span> </td>
         <td><asp:TextBox ID="txtConfirmPassword" TextMode="Password" ValidationGroup="ValidatePassword"  runat="server" Font-Size="11px" TabIndex="3" Width="200px"></asp:TextBox>
         </td>
     </tr>
     <tr><td></td><td><asp:RequiredFieldValidator ID="rfvConfirmPassword" Display="Dynamic" runat="server" Text="Please Enter Confirm Password !!!" ControlToValidate="txtConfirmPassword" SetFocusOnError="true" CssClass="validation_cls" ValidationGroup="ValidatePassword"></asp:RequiredFieldValidator>
         <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" CssClass="validation_cls" ValidationGroup="ValidatePassword" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" 
             ErrorMessage="New password and confirm password should be same."></asp:CompareValidator>
         </td></tr>
     
     <tr><td></td><td>
     <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" class="thickbox btn btn-small" 
             ValidationGroup="ValidatePassword" onclick="btnChangePassword_Click" />
     &nbsp <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="thickbox btn btn-small" 
             onclick="btnCancel_Click" />
             <span id="spnMessage" runat="server" style="color:Green;"></span>
     </td></tr>
     </table>
     <br /><br />
       </div>


</asp:Content>
