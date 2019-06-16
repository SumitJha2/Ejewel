<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListMultiStore.aspx.cs" Inherits="EJewel.AdminView.Configuration.Store.ListMultiStore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div><a id="lnkCreateNew">Add MultiStore</a></div>
<br />
<!-- Grid Design -->
<div class="grid">
<table id="tableMultiStore"></table>    
</div>
    <script src="/asset/Script/Configuration/ListMultiStoreScript.js" type="text/javascript"></script>
</asp:Content>
