<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageAdminUsers.aspx.cs" Inherits="EJewel.AdminView.SiteSetting.ManageAdminUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1"  runat="server">
    <title>Manage News</title>
    <style type="text/css">
       
        body { font: 12px/1.7em "Open Sans", "trebuchet ms", arial, sans-serif; color: #444; }
        
        .validation_cls
        {
        	color:Red;
        }
    </style>
    <!--CSS-->
     <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/form.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/message.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/table.css" type="text/css" />
    <!--Script-->
    <script src="/assets/themes/admin/javascripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="/assets/themes/admin/javascripts/globalscript.js" type="text/javascript"></script>
    <script src="/assets/webcontrols/fileupload/ajaxupload.3.5.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">       
<table class="table table-bordered table-striped" style="width:100%">
<tr><td colspan="2"> <span id="spnMessage" runat="server" style="color:Green;"></span></td></tr>

<tr><td>User Type<span class="small_error">&nbsp;*</span></td><td>
   
    <asp:DropDownList ID="ddlUserType" runat="server" CssClass="common_width" 
        Height="26px" Width="222px">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="rfvUserType" runat="server" CssClass="validation_cls" ErrorMessage="*" InitialValue="0" ControlToValidate="ddlUserType"></asp:RequiredFieldValidator>
    </td></tr>
<tr><td>User ID<span class="small_error">&nbsp;*</span></td><td>
  <asp:TextBox ID="txtUserID" runat="server" CssClass="common_width" Width="215px"></asp:TextBox>
  <asp:RequiredFieldValidator ID="rfvUserID" runat="server" CssClass="validation_cls" ErrorMessage="*"  ControlToValidate="txtUserID"></asp:RequiredFieldValidator>
    </td></tr>
<tr><td>User Name<span class="small_error">&nbsp;*</span></td><td>
    <asp:TextBox ID="txtUserName" runat="server" 
        CssClass="common_width" Width="222px" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" CssClass="validation_cls" ErrorMessage="*"  ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
    </td></tr>
    <tr><td>Email<span class="small_error">&nbsp;*</span></td><td>
    <asp:TextBox ID="txtUserEmail" runat="server" 
        CssClass="common_width" Width="222px"></asp:TextBox>
           <asp:RequiredFieldValidator ID="rfvEmail" runat="server" CssClass="validation_cls" Display="Dynamic" ErrorMessage="*"  ControlToValidate="txtUserEmail"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="regExp" runat="server" CssClass="validation_cls" 
            Display="Dynamic" ErrorMessage="*"  ControlToValidate="txtUserEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    </td></tr>
    

     <tr><td>Mob<span class="small_error">&nbsp;*</span></td><td>
    <asp:TextBox ID="txtMob" runat="server" CssClass="common_width" Width="222px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvMob" runat="server" CssClass="validation_cls" Display="Dynamic" ErrorMessage="*"  ControlToValidate="txtMob"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="regMob" runat="server" CssClass="validation_cls" Display="Dynamic" ErrorMessage="*"  ControlToValidate="txtMob" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
    </td></tr>

    <tr><td>Password<span class="small_error">&nbsp;*</span></td><td>
    <asp:TextBox ID="txtUserPassWord" runat="server" 
        CssClass="common_width" Width="222px"></asp:TextBox><asp:Label ID="lblMsg" runat="server" CssClass="validation_cls"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="validation_cls" Display="Dynamic"  ErrorMessage="*"  ControlToValidate="txtUserPassWord"></asp:RequiredFieldValidator>
    </td></tr>

  
<tr><td>Status</td><td>
    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="common_width" 
        Height="26px" Width="228px">
    </asp:DropDownList>
    </td></tr>
<tr>
<td colspan="2">
		<asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" class="btn btn-small" />
      
           
            </td>
</tr>
</table>
 


   
</form>
</body>
</html>
