<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListShipmentMethod.aspx.cs" Inherits="EJewel.AdminView.Master.Payment.ListShipmentMethod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div><a id="lnkCreateNew">Add Shipment Method</a></div>
<!-- Grid Design -->
<div class="grid">
<br />
<table id="tableShipmentMethod"></table>
</div>   
  <script src="/asset/Script/Master/Payment/ListShipmentMethodScript.js" type="text/javascript"></script>
</asp:Content>

