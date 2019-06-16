<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductChain.aspx.cs" Inherits="EJewel.AdminView.Product.ProductChain" %>

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
            $("#<%=spnMessage.ClientID %>").css("color", "red");
            if (document.getElementById("<%=ddlChainStyle.ClientID %>").selectedIndex == 0) {
                $("#<%=spnMessage.ClientID %>").text('Please select chain style.');
                return false;
            }
           else if (document.getElementById("<%=ddlChainLength.ClientID %>").selectedIndex == 0) {
               $("#<%=spnMessage.ClientID %>").text('Please select chain length.');
                return false;
            }
            else if (document.getElementById("<%=ddlChainClasp.ClientID %>").selectedIndex == 0) {
                $("#<%=spnMessage.ClientID %>").text('Please select chain clasp.');
                return false;
            }          
            else {
                return true;
            }
        }
     
    </script>
</head>
<body>
<form id="form1" runat="server" autocomplete="off">
		<table class="table table-bordered table-striped" style="width:100%">
        <thead>
        
        <tr><th colspan="3">
            Product Chain</th></tr>
        </thead>
        <tbody>
        <tr><td colspan="2"> <span id="spnMessage" runat="server"></span></td></tr>
		<tr>
			<td>Chain Style<span class="small_error">&nbsp;*</span></td>
			<td>
                <asp:HiddenField ID="hdnID" runat="server" Value="0" />
                <asp:DropDownList ID="ddlChainStyle" runat="server" CssClass="common_width">
                </asp:DropDownList>
            </td>
		</tr>
         <tr>
		<td>Chain Length<span class="small_error">&nbsp;*</span></td>
		<td>	
	 <asp:DropDownList ID="ddlChainLength" runat="server" CssClass="common_width">
                </asp:DropDownList>
		</td>
        </tr>	
        <tr>
		<td>Chain Clasp<span class="small_error">&nbsp;*</span></td>
		<td>	
	    <asp:DropDownList ID="ddlChainClasp" runat="server" CssClass="common_width">
                </asp:DropDownList>
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
        
			<asp:Button ID="btnSave" runat="server" CssClass="btn btn-small" OnClientClick="return validate()"  onclick="btnSave_Click"  Text="Save"/>
           
            </td>
		</tr>
    </tbody>
	</table>
    </form>
</body>
</html>
