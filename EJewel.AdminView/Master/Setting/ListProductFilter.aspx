<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListProductFilter.aspx.cs" Inherits="EJewel.AdminView.Master.Setting.ListProductFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="contentHeader">
    <h1>Product Filter</h1>
</div>
<div class="container">
        <div class="grid-24">
            <asp:Label ID="lblMessage" runat="server" CssClass="small_success"></asp:Label>
        <table style="width:100%" css="table table-bordered table-striped" >
        <tbody>
        <tr>
        <td>
<asp:GridView ID="gridSubCategory" runat="server" 
                CssClass="table table-bordered table-striped" AutoGenerateColumns="False" 
                GridLines="None" Width="100%" 
                ShowHeaderWhenEmpty="True" onrowdatabound="gridSubCategory_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Sl.">
                    <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                        <asp:HiddenField ID="hdnSubCategoryId" runat="server" Value='<%# Eval("SubCategoryId") %>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Primary Category" DataField="CategoryName" />
                    <asp:BoundField HeaderText="Sub Category" DataField="SubCategoryName" />
                    <asp:TemplateField HeaderText="Assign Filter">
                    <ItemTemplate>
                     <asp:CheckBox ID="chkCenterStoneShape" runat="server" Text="CenterStoneShape" /><br />
                     <asp:CheckBox ID="chkSideStoneShape" runat="server" Text="SideStoneShape" /><br />
                     <asp:CheckBox ID="chkCenterStoneSetting" runat="server" Text="CenterStoneSetting" /><br />
                     <asp:CheckBox ID="chkSideStoneSetting" runat="server" Text="SideStoneSetting" /><br />
                      <asp:CheckBox ID="chkGemStoneColor" runat="server" Text="GemStoneColor" /><br />
                        <asp:CheckBox ID="chkGemStoneType" runat="server" Text="GemStoneType" />
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price Filter (Min.)">
                        <ItemTemplate>
                            <asp:TextBox ID="txtPriceMin" runat="server" MaxLength="8" Width="60px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price Filter(Max.)">
                        <ItemTemplate>
                            <asp:TextBox ID="txtPriceMax" runat="server" MaxLength="8" Width="60px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price Filter(Diff.)">
                        <ItemTemplate>
                            <asp:TextBox ID="txtPriceDiff" runat="server" MaxLength="8" Width="60px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
        </tr>
        <tr>
        <td>
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-small" 
                onclick="btnSave_Click" Text="Save" OnClientClick="return sure('Are you sure...?')" />
        </td>
        </tr>
        </tbody>
        
            </table>
        </div>
        </div>
</asp:Content>
