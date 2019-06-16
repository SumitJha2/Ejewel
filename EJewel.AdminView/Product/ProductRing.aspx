<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductRing.aspx.cs" Inherits="EJewel.AdminView.Product.ProductRing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <!--  start step-holder -->
		<div id="step-holder">
			<div class="step-no">6</div>
			<div class="step-dark-left">Product Ring</div>
			<div class="clear"></div>
		</div>
        <table border="0" cellpadding="0" cellspacing="0"  id="id-form">
        <tr><th>Name/SKU</th><td>&nbsp;</td></tr>
        <tr><th>Default Ring Size</th><td><select id="ddlRingSize" name="ddlRingSize"></select></td></tr>
        <tr><th>Avialable Ring Size</th><td>
        <div style="height:150px; overflow:scroll;" id="avialableRing">

        </div>
        </td></tr>
         <tr>
			<th valign="top"></th>
			<td><input type="button" id="btnProcess"  value="" class="form-submit" />
			<input type="reset" value="" class="form-reset"  /></td>
		</tr>
        </table>
</asp:Content>
