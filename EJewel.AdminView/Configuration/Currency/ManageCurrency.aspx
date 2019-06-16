<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageCurrency.aspx.cs" Inherits="EJewel.AdminView.Configuration.Currency.ManageCurrency" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="/asset/Script/Configuration/CurrencyScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!--  start step-holder -->
		<div id="step-holder">
			<div class="step-no">1</div>
			<div class="step-dark-left">Currency Management</div>
			<div class="clear"></div>
		</div>
        <table border="0" cellpadding="0" cellspacing="0"  id="id-form">
		<tr>
			<th valign="top">Currency Title:</th>
			<td><input type="text" class="" name="txtTitle" id="txtTitle" /></td>
		</tr>
		<tr>
			<th valign="top">Code:</th>
			<td><input type="text" name="txtCode" id="txtCode" class="" /></td>
		</tr>
        <tr>
			<th valign="top">Symbol:</th>
			<td><input type="text" name="txtSymbol" id="txtSymbol" class="" /></td>
		</tr>
        <tr>
			<th valign="top">Decimal Places:</th>
			<td><input type="text" name="txtDecimal" id="txtDecimal" class="" /></td>
		</tr>
        <tr>
			<th valign="top">Value:</th>
			<td><input type="text" name="txtValue" id="txtValue" class="" /></td>
		</tr>
        <tr>
			<th valign="top">Default:</th>
			<td>
            <select  class="styledselect_form_1" name="ddlDefault" id="ddlDefault">
            <option value="0">No</option>
			<option value="1">Yes</option>
		    </select>
            </td>
		</tr>
        <tr>
			<th valign="top">Status:</th>
			<td>
            <select  class="styledselect_form_1" name="ddlStatus" id="ddlStatus">
			<option value="1">Enabled</option>
			<option value="0">Disabled</option>
		    </select>
            </td>
		</tr>
	<tr>
		<th><span id="loader" class="loading_small" style="float:right;right:5px;visibility:hidden;"></span></th>
		<td valign="top">
			<input type="button" id="btnProcess" onclick="saveNewCurrency();" value="" class="form-submit" />
			<input type="reset" value="" class="form-reset"  />
		</td>
	</tr>
	</table>
</asp:Content>
