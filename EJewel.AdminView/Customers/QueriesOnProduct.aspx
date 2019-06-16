<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QueriesOnProduct.aspx.cs" Inherits="EJewel.AdminView.Customers.QueriesOnProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<style type="text/css">
.border
{
	border-style:none;
	border-collapse:collapse;
}
</style>
<div id="contentHeader">
    <h1>Queries On Product</h1>
</div>
<div class="container">
        <div class="grid-24">      
       
        <asp:GridView ID="gvQueriesOnProduct" CssClass="table table-bordered table-striped" 
                runat="server" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="gvQueriesOnProduct_PageIndexChanging"
               PageSize="20" 
                AllowPaging="True" ShowHeaderWhenEmpty="True">
        <Columns>
          <asp:TemplateField HeaderText="Sl.">
                <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>  
         <asp:HiddenField ID="hdnProductQueriesId" runat="server" Value='<% #Eval("ProductQueriesId") %>' />
                 </ItemTemplate>
                 </asp:TemplateField>
        <asp:BoundField DataField="sku" HeaderText="SKU" />  
        <asp:BoundField DataField="FirstName" HeaderText="First Name" />  
        <asp:BoundField DataField="LastName" HeaderText="Last Name" />  
        <asp:BoundField DataField="Email" HeaderText="Email" />  
        <asp:BoundField DataField="Telephone" HeaderText="Telephone" />
        <asp:BoundField DataField="Message" HeaderText="Message" />
        <asp:BoundField DataField="Date" HeaderText="Date" 
                DataFormatString="{0:dd-MM-yyyy}" />                
        <asp:TemplateField HeaderText="Delete">
        <ItemTemplate>
         <asp:ImageButton ID="imgDelete" runat="server" OnClick="imgDelete_Click" OnClientClick="return confirm('Are you sure you want delete');" CssClass="border" ImageUrl="/assets/themes/admin/images/icon/delete_16.png"  width="15px" height="15px" />      
        </ItemTemplate>        
        </asp:TemplateField>             
        </Columns>        
        </asp:GridView>
        </div>
        </div>
</asp:Content>
