<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTax.aspx.cs" Inherits="EJewel.AdminView.Master.Payment.AddTax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/asset/Script/Master/Payment/TaxScript.js" type="text/javascript">
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<!--  start step-holder -->
		<div id="step-holder">
			<div class="step-no">1</div>
			<div class="step-dark-left">Tax</div>
			<div class="clear"></div>
		</div>
		<!--  end step-holder -->
		<!-- start id-form -->
		<table border="0" cellpadding="0" cellspacing="0"  id="id-form">
		 <tr>
			<th valign="top">Tax:</th>
			<td>
            <input type="text" class="" name="txtTax" id="txtTax" /></td>
		</tr>	

         <tr>
			<th valign="top">Percent:</th>
			<td>
            <input type="text" class="" name="txtPercent" id="txtPercent" /></td>
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
			<input type="button" onclick="saveUpdateTax();" value="" class="form-submit"/>
			<input type="reset" value="" class="form-reset" id="btnReset"  />
		</td>
	</tr>
	</table>
</asp:Content>
