<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListTax.aspx.cs" Inherits="EJewel.AdminView.Master.Payment.ListTax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div><a id="lnkCreateNew">Add Tax</a></div>
<br />
<!-- Grid Design -->
<div class="grid">
<table id="tableTax"></table>
</div>   
    <script src="/asset/Script/Master/Payment/ListTaxScript.js" type="text/javascript"></script>
</asp:Content>
