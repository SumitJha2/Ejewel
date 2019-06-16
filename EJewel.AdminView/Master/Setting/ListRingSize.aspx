<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListRingSize.aspx.cs" Inherits="EJewel.AdminView.Master.Setting.ListRingSize" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="contentHeader">
    <h1>Ring Size</h1>
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
                ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:TemplateField HeaderText="Sl.">
                    <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                        <asp:HiddenField ID="hdnSubCategoryId" runat="server" Value='<%# Eval("SubCategoryId") %>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Primary Category" DataField="CategoryName" />
                    <asp:BoundField HeaderText="Sub Category" DataField="SubCategoryName" />
                    <asp:TemplateField HeaderText="Has Ring">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkAvailable" runat="server" 
                            Checked='<%# Eval("HasRing") %>' />
                    </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Has Engraving">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkEngraving" runat="server" 
                            Checked='<%# Eval("HasEngraving") %>' />
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
