<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPaymentStatus.aspx.cs" Inherits="EJewel.AdminView.Master.Payment.ListPaymentStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div><a id="lnkCreateNew">Add Payment Status</a></div>
<!-- Grid Design -->
<div class="grid">
<br />
<table id="tablePaymentStatus"></table>
</div>
    <script src="/asset/Script/Master/Payment/ListPaymentStatusScript.js" type="text/javascript"></script>
</asp:Content>
