<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddShipmentMethod.aspx.cs" Inherits="EJewel.AdminView.Master.Payment.AddShipingMethod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/asset/Script/Master/Payment/ShipmentMethodScript.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="span12">                    
                        <div class="head clearfix">
                            <div class="isw-grid"></div>
                            <h1 id="headingText">Payment Via Master</h1>      
                        </div>
                        <div class="block-fluid">
		<table border="0" cellpadding="0" cellspacing="0" class="table">
		 <tr>
			<td valign="top">Name</td>
			<td>
            <input type="text" class="" name="txtName" id="txtName" /></td>
		</tr>
         <tr>
			<td valign="top">Price</td>
			<td>
            <input type="text" class="" name="txtPrice" id="txtPrice" /></td>
		</tr>		
        <tr>
		<td valign="top">Status</td>
		<td>	
		 <select  class="styledselect_form_1" name="ddlStatus" id="ddlStatus">
			<option value="1">Enabled</option>
			<option value="0">Disabled</option>
		    </select>
		</td>
        </tr>
	<tr>
		<th colspan="2">
			<input type="button" onclick="saveUpdateShipmentMethod();" value="Save"/>
			<input type="reset" value="Reset"  id="btnReset"  />
		</th>
	</tr>
	</table>
    </div>
    </div>
</asp:Content>
