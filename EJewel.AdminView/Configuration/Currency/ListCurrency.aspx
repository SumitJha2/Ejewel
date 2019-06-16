<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListCurrency.aspx.cs" Inherits="EJewel.AdminView.Configuration.Currency.ListCurrency" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div><a id="lnkCreateNew">AddCurrency</a></div>
<br />
<!-- Grid Design -->
<div class="grid">
<table id="tableCurrency"></table>    
</div>
<script src="/asset/Script/Configuration/ListCurrencyScript.js" type="text/javascript"></script>
</asp:Content>

