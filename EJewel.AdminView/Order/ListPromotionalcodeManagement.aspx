<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPromotionalcodeManagement.aspx.cs" Inherits="EJewel.AdminView.Order.ListPromotionalcodeManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<style type="text/css">
.border
{
	border-style:none;
	border-collapse:collapse;
}
</style>
<div id="contentHeader">
    <h1>PromotionalCode Management</h1>
</div>
<div class="container">
        <div class="grid-24">
        <div style="float:right">
        
            <a href="javascript:void(0)" onclick = "popupwindow('/Order/PromotionalcodeManagement.aspx', 800,500)"  title="" class="thickbox btn btn-small">Create New</a>
        </div>
        <br />
        <br />
        <asp:GridView ID="gvPromotionalCodeManagement" CssClass="table table-bordered table-striped" 
                runat="server" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="gvPromotionalCodeManagement_PageIndexChanging"
                OnRowDataBound="gvPromotionalCodeManagement_RowDataBound" PageSize="20" AllowPaging="true">

        <Columns>
          <asp:TemplateField HeaderText="Sl.">
                <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>  
         <asp:HiddenField ID="hdnPromotionalCodeManagementId" runat="server" Value='<% #Eval("PromotionalcodeManagementID") %>' />       
         <asp:HiddenField ID="hdnStatus" runat="server" Value='<% #Eval("Status") %>' />                
                 </ItemTemplate>
                 </asp:TemplateField>
                   <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" />   
                     <asp:BoundField DataField="SubCategoryName" HeaderText="SubCategoryName" />   
                       <asp:BoundField DataField="ProductSKU" HeaderText="SKU" />   
        <asp:BoundField DataField="Promotionalcode" HeaderText="Promotionalcode" />   
         <asp:BoundField DataField="ProductValidFrom" HeaderText="ValidFrom" DataFormatString="{0:dd-MM-yyyy}" />   
          <asp:BoundField DataField="ProductValidTo" HeaderText="ValidTo" DataFormatString="{0:dd-MM-yyyy}" />   
           <asp:BoundField DataField="ProductDiscountValue" HeaderText="Discount Value" />   
           <asp:BoundField DataField="ProductDiscountType" HeaderText="Discount Type" />    
        <asp:TemplateField HeaderText="Status">
        <ItemTemplate>
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        </ItemTemplate>        
        </asp:TemplateField>          
         <asp:TemplateField HeaderText="Edit">
        <ItemTemplate>       
       <asp:HyperLink ID="hprEdit" runat="server"><img src="/assets/themes/admin/images/icon/edit_16.png" /></asp:HyperLink> 

        </ItemTemplate>        
        </asp:TemplateField> 
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
