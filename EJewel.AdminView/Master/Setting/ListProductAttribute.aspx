<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListProductAttribute.aspx.cs" Inherits="EJewel.AdminView.Master.Setting.ListProductAttribute" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">

//    function go_to_next_page() {
//        window.location.href = "/Extras/ManageProposalStories.aspx";
//    }
//    function go_to_proposalstorypage_page(id) {
//        window.location.href = "/Extras/ManageProposalStories.aspx?id=" + id;
//    }

</script>

<style type="text/css">
.border
{
	border-style:none;
	border-collapse:collapse;
}
</style>
<div id="contentHeader">
    <h1>Product Attribute</h1>
</div>
<div class="container">
        <div class="grid-24">
        <div style="float:right">    
           <div style="float:right">
        <a href="javascript:void(0)" onclick = "popupwindow('/Master/Setting/ManageProductAttribute.aspx', 800,500)"  title="" class="btn btn-small">Create New</a>
        </div>
        <br /> 
        <br />
        </div>
        <br />
        <br />
        <asp:GridView ID="gvAttribute" CssClass="table table-bordered table-striped" 
                runat="server" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="gvAttribute_PageIndexChanging"
                OnRowDataBound="gvAttribute_RowDataBound" PageSize="20" AllowPaging="true" 
                ShowHeaderWhenEmpty="True">

        <Columns>
          <asp:TemplateField HeaderText="Sl.">
                <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>  
         <asp:HiddenField ID="hdnAttributeId" runat="server" Value='<% #Eval("AttributeId") %>' />       
         <asp:HiddenField ID="hdnSubCategory" runat="server" Value='<% #Eval("SubCategoryId") %>' />
         <asp:HiddenField ID="hdnStatus" runat="server" Value='<% #Eval("Status") %>' />                
                 </ItemTemplate>
                 </asp:TemplateField>
        <asp:BoundField DataField="PrimeryCategory" HeaderText="Primary Category" />  
        <asp:BoundField DataField="SubCategory" HeaderText="Sub Category" /> 
         <asp:BoundField DataField="AttributeTitle" HeaderText="Attribute Title" /> 
        <asp:BoundField DataField="AttributeName" HeaderText="Attribute Name" />  
        <asp:BoundField DataField="AttributePrice" HeaderText="Attribute Price" /> 
         <asp:BoundField DataField="IsDefault" HeaderText="IsDefault" />              
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
