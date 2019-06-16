<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPaymentVia.aspx.cs" Inherits="EJewel.AdminView.Master.Payment.ListPaymentVia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div><a id="lnkCreateNew">Add Payment Option</a></div>
<!-- Grid Design -->
<div class="grid">
<br />
<table id="tablePaymentVia"></table>
</div>   
    <script src="/asset/Script/Master/Payment/ListPaymentViaScript.js" type="text/javascript"></script>
</asp:Content>
