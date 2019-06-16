<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListOrderStatus.aspx.cs" Inherits="EJewel.AdminView.Master.Payment.ListOrderStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div><a id="lnkCreateNew">Add Order Status</a></div>
<!-- Grid Design -->
<div class="grid">
<br />
<table id="tableOrderStatus"></table>
</div>
    <script src="/asset/Script/Master/Payment/ListOrderStatusScript.js" type="text/javascript"></script>
</asp:Content>
