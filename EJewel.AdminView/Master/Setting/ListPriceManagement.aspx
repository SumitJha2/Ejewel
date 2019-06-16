<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPriceManagement.aspx.cs" Inherits="EJewel.AdminView.Master.Setting.ListPriceManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
                                        <li>
                                            <asp:HyperLink ID="lnkDetails" runat="server"><span class="isw-plus"></span>Add New</asp:HyperLink></li>
                                        <li><a href="#"><span class="isw-refresh"></span>Refresh</a></li>
                                    </ul>
                                </li>
                            </ul>                        
                        </div>
                        <div class="block-fluid">
                            <asp:GridView ID="dgvDetails" runat="server" AutoGenerateColumns="False" 
                                Width="100%" onrowdatabound="dgvDetails_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sl">
                                    <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                        <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("AutoID") %>' />
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Category" DataField="SubCategory" />
                                    <asp:BoundField HeaderText="Price" DataField="Price" />
                                    <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkEdit" runat="server">Edit</asp:HyperLink>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>Delete</ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        </div>
</asp:Content>
