﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddChainStyle.aspx.cs" Inherits="EJewel.AdminView.Master.Metal.AddChain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/asset/Script/Master/Metal/ChainStyleScript.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="span12">                    
                        <div class="head clearfix">
                            <div class="isw-grid"></div>
                            <h1 id="headingText">Chain Style Master</h1>      
                        </div>
                        <div class="block-fluid">
		<table border="0" cellpadding="0" cellspacing="0"  class="table">
		 <tr>
		<th >Style Name:</th>
		<td>	
		<input type="text" class="" name="txtName" id="txtName" />
		</td>
        </tr>       
        <tr>
		<th >Status:</th>
		<td>	
		 <select  name="ddlStatus" id="ddlStatus">
			<option value="1">Enabled</option>
			<option value="0">Disabled</option>
		    </select>
		</td>
        </tr>
	<tr>
		<th colspan="2">
			<input type="button" onclick="SaveUpdateChainStyle();" value="Save"/>
			<input type="reset" value="Reset"  id="btnReset"  />
		</th>
	</tr>
	</table>
    </div>
    </div>
</asp:Content>
