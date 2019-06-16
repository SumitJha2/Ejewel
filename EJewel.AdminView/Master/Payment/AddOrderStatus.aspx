<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddOrderStatus.aspx.cs" Inherits="EJewel.AdminView.Master.Payment.AddOrderStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/asset/Script/Master/Payment/OrderStatusScript.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="span12">                    
                        <div class="head clearfix">
                            <div class="isw-grid"></div>
                            <h1 id="headingText">Order Status Master</h1>      
                        </div>
                        <div class="block-fluid">
		<table border="0" cellpadding="0" cellspacing="0"  class="table">
		 <tr>
			<td valign="top">Order Status</td>
			<td>
            <input type="text" class="" name="txtOrder" id="txtOrder" /></td>
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
		
			<input type="button" onclick="saveUpdateOrderStatus();" value="Save" />
			<input type="reset" value="Reset" id="btnReset"  />
		</th>
	</tr>
	</table>
    </div>
    </div>
</asp:Content>
