<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultiStore.aspx.cs" Inherits="EJewel.AdminView.Configuration.Store.MultiStore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<script src="/asset/Script/Configuration/StoreScript.js" type="text/javascript"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!--  start step-holder -->
		<div id="step-holder">
			<div class="step-no">1</div>
			<div class="step-dark-left">Store Management</div>
			<div class="clear"></div>
		</div>
		<!--  end step-holder -->
		<!-- start id-form -->
		<table border="0" cellpadding="0" cellspacing="0"  id="id-form">
		<tr>
			<th valign="top">Store Name:</th>
			<td>           
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
		</tr>
		<tr>
			<th valign="top">Store URL:</th>
			<td>            
            <asp:TextBox ID="txtURL" runat="server"></asp:TextBox>
            </td>
		</tr>
        <tr>
		<th valign="top">Default Currency:</th>
		<td>
         <asp:DropDownList ID="ddlCurrency" runat="server"></asp:DropDownList>     
      </td>
        </tr>
            
        <tr>
		<th valign="top">Status:</th>
		<td>
         <asp:DropDownList ID="dd1Status" runat="server">
         <asp:ListItem Text="Enabled" Value="1"></asp:ListItem>
          <asp:ListItem Text="Disabled" Value="0"></asp:ListItem>
         </asp:DropDownList>  	
		</td>
        </tr>
	<tr>
		<th><span id="loader" class="loading_small" style="float:right;right:5px;visibility:hidden;"></span></th>
		<td valign="top">
        <asp:Button ID="btnSave" runat="server" class="form-submit" 
                onclick="btnSave_Click" />			
		</td>
	</tr>            
	</table>	
</asp:Content>
