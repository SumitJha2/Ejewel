<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListSingleField.aspx.cs" Inherits="EJewel.AdminView.Common.SingleField.ListSingleField" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    var PAGE_NAME = '';
    var qs = querystring("view");
    if (qs.length > 0) {
        PAGE_NAME = qs[0];
    }

    function createLink() {
        location.href = "/Common/SingleField/SingleFieldManagement.aspx?view=" + PAGE_NAME;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="span12">                    
                        <div class="head clearfix">
                            <div class="isw-grid"></div>
                            <h1 id="headingText">
                                <asp:Literal ID="ltrlHeading" runat="server"></asp:Literal></h1>
                            <ul class="buttons">
                                <li><a href="#" class="isw-download"></a></li>                                                        
                                <li>
                                    <a href="#" class="isw-settings"></a>
                                    <ul class="dd-list">
                                        <li><a href="javascript:void(0)" onclick="createLink()"><span class="isw-plus"></span>Add New</a></li>
                                        <li><a href="#"><span class="isw-refresh"></span>Refresh</a></li>
                                    </ul>
                                </li>
                            </ul>                        
                        </div>
                        <div class="block-fluid">
                        <table id="tblSingleField"></table>
                        </div>
                        </div>
    <script src="/asset/Script/Common/SingleField/ListSingleField.js" type="text/javascript"></script>   
</asp:Content>
