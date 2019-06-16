<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListStoneCategory.aspx.cs" Inherits="EJewel.AdminView.Master.Stone.ListStoneCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="span12">                    
                        <div class="head clearfix">
                            <div class="isw-grid"></div>
                            <h1 id="headingText">Stone Category List</h1>
                            <ul class="buttons">
                                <li><a href="#" class="isw-download"></a></li>                                                        
                                <li>
                                    <a href="#" class="isw-settings"></a>
                                    <ul class="dd-list">
                                        <li><a href="/Product/ProductDetails.aspx"><span class="isw-plus"></span>Add New</a></li>
                                        <li><a href="#"><span class="isw-refresh"></span>Refresh</a></li>
                                    </ul>
                                </li>
                            </ul>                        
                        </div>
                        <div class="block-fluid">
<table id="tableStoneCategory"></table>
</div>
</div>
<script type="text/javascript" src="/asset/Script/Master/Stone/ListStoneCategoryScript.js"></script>
</asp:Content>
