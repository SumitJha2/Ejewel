<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageProductReview.aspx.cs" Inherits="EJewel.AdminView.Customers.ManageProductReview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1"  runat="server">
    <title>Single Field Management</title>
    <style type="text/css">
        @import url(http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,600);
        body { font: 12px/1.7em "Open Sans", "trebuchet ms", arial, sans-serif; color: #444; }
    </style>
    <!--CSS-->
     <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/form.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/message.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/table.css" type="text/css" />
    <!--Script-->
    <script src="/assets/themes/admin/javascripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="/assets/themes/admin/javascripts/globalscript.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function validate() {
            if (document.getElementById("<%=txtSKU.ClientID %>").value == "") {
                alert('Please enter sku.');
                return false;              
          }
          return true;
        }
    </script>
</head>
<body>
<form id="form1" runat="server" autocomplete="off">
		<table class="table table-bordered table-striped" style="width:100%">
        <thead>
        <tr><th colspan="3">
            <asp:Literal ID="ltrlHeading" runat="server">Manage Product Review</asp:Literal></th></tr>
        </thead>
        <tbody>
        <tr><td colspan="2"> <span id="spnMessage" style="color:Red;" runat="server"></span></td></tr>
		<tr>
			<td>SKU<span class="small_error">&nbsp;*</span></td>
			<td>             
                <asp:TextBox ID="txtSKU" runat="server" CssClass="common_width"></asp:TextBox>              
            </td>
		</tr>

        <tr>
			<td>Review Heading<span class="small_error"></span></td>
			<td>               
                <asp:TextBox ID="txtHeading" runat="server" CssClass="common_width"></asp:TextBox>              
            </td>
		</tr>
        <tr>
			<td>Review Description<span class="small_error"></span></td>
			<td>               
                <asp:TextBox ID="txtDescription" runat="server" CssClass="common_width" TextMode="MultiLine"></asp:TextBox>              
            </td>
		</tr>
         <tr>
		<td>Customer Name<span class="small_error"></span></td>
		<td>	
		<asp:TextBox ID="txtName" runat="server" CssClass="common_width"></asp:TextBox>
		</td>
        </tr>
         <tr>
		<td>Rating<span class="small_error"></span></td>
		<td>	
     <asp:DropDownList ID="ddlRating" runat="server"  CssClass="common_width">  
    <asp:ListItem Text="1"></asp:ListItem>
      <asp:ListItem Text="2"></asp:ListItem>
        <asp:ListItem Text="3"></asp:ListItem>
          <asp:ListItem Text="4"></asp:ListItem>
            <asp:ListItem Text="5"></asp:ListItem>
    </asp:DropDownList>
		</td>
        </tr>
        <tr>
		<td>E-mail<span class="small_error"></span></td>
		<td>	
		<asp:TextBox ID="txtEmail" runat="server" CssClass="common_width"></asp:TextBox>
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
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="return validate()" class="btn btn-small" 
                onclick="btnSave_Click" />           
            </td>
		</tr>
    </tbody>
	</table>
    </form>
</body>
</html>
