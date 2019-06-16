<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageProductAttribute.aspx.cs" Inherits="EJewel.AdminView.Master.Setting.ManageProductAttribute" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1"  runat="server">
    <title>Single Field Management</title>
    <style type="text/css">
        @import url(http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,600);
        body { font: 12px/1.7em "Open Sans", "trebuchet ms", arial, sans-serif; color: #444; }
        .color
        {
        	color:Green;
        }
         .Validation_color
        {
        	color:red;
        }
    </style>
    <!--CSS-->
     <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/form.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/message.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/table.css" type="text/css" />
    <!--Script-->
    <script src="/assets/themes/admin/javascripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="/assets/themes/admin/javascripts/globalscript.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        
       
    </script>
</head>
<body>
<form id="form1" runat="server" autocomplete="off">
		<table class="table table-bordered table-striped" style="width:100%">
        <thead>
        <tr><th colspan="3">
            Product Attribute
            </th>
            </tr>
        </thead>
        <tbody>
        <tr><td colspan="2"> <span id="spnMessage" runat="server" class="color"></span></td></tr>
		<tr>
			<td>Primary Category<span class="small_error">&nbsp;*</span></td>
			<td>              
                <asp:DropDownList ID="ddlPrimeryCategory" runat="server" AutoPostBack="true" 
                    CssClass="common_width" 
                    onselectedindexchanged="ddlPrimeryCategory_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="Validation_color" ControlToValidate="ddlPrimeryCategory" InitialValue="" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
		</tr>
        <tr>
			<td>Sub Category<span class="small_error">&nbsp;*</span></td>
			<td>
                
                <asp:DropDownList ID="ddlSubCategory" runat="server" CssClass="common_width">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="Validation_color" ControlToValidate="ddlSubCategory" InitialValue="0" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
		</tr>

         <tr>
			<td>Attribute Title<span class="small_error">&nbsp;*</span></td>
			<td>
                
                <asp:DropDownList ID="ddlAttributeTitle" runat="server" CssClass="common_width">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="Validation_color" ControlToValidate="ddlAttributeTitle" InitialValue="0" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
		</tr>


        
         <tr>
		<td>Attribute Name<span class="small_error">&nbsp;*</span></td>
		<td>	
		<asp:TextBox ID="txtName" runat="server" CssClass="common_width"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="Validation_color" ControlToValidate="txtName"  runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
		</td>
        </tr>	
          <tr>
		<td>Attribute Price<span class="small_error">&nbsp;*</span></td>
		<td>	
		<asp:TextBox ID="txtPrice" runat="server" CssClass="common_width" onkeyup="this.value = this.value.replace(/[^0-9,\. ]/, '')"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="Validation_color" ControlToValidate="txtPrice"  runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
		</td>
        </tr>  
         <tr>
		<td>Default<span class="small_error"></span></td>
		<td>	
		<asp:CheckBox ID="chkIsDefault" runat="server" />
      
		</td>
        </tr>         
        	
         <tr>
		<td>Status</td>
		<td>	
		 <asp:DropDownList ID="ddlStatus" runat="server" CssClass="common_width">
            </asp:DropDownList>
		</td>
        </tr>
	<tr>
		<td colspan="2">
        <asp:Button ID="btnSave" runat="server" class="btn btn-small" Text="Save" onclick="btnSave_Click" />
           
            </td>
		</tr>
    </tbody>
	</table>
    </form>
</body>
</html>
