<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductReviewStatus.aspx.cs" Inherits="EJewel.AdminView.Customers.ProductReviewStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">

    function go_to_next_page() {
        window.location.href = "/Extras/ManageProposalStories.aspx";
    }
    function go_to_proposalstorypage_page(id) {
        window.location.href = "/Extras/ManageProposalStories.aspx?id=" + id;
    }

</script>
<style type="text/css">
.border
{
	border-style:none;
	border-collapse:collapse;
}
</style>
<div id="contentHeader">
    <h1>Product Review Status</h1>
</div>
<div class="container">
        <div class="grid-24">
        <div style="float:right">
        
      <a href="javascript:void(0)" onclick = "popupwindow('/Customers/ManageProductReview.aspx', 800,500)"  title="" class="thickbox btn btn-small">Create New</a>
         
        </div>
        <br />
        <br />
        <asp:GridView ID="gvProductReview" CssClass="table table-bordered table-striped" 
                runat="server" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="gvProductReview_PageIndexChanging"
                PageSize="20" AllowPaging="true" 
                onrowdatabound="gvProductReview_RowdataBound">

        <Columns>
          <asp:TemplateField HeaderText="Sl.">
                <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>  
         <asp:HiddenField ID="hdnReviewId" runat="server" Value='<% #Eval("ReviewId") %>' />       
         <asp:HiddenField ID="hdnProductId" runat="server" Value='<% #Eval("ProductId") %>' />        
                 </ItemTemplate>
                 </asp:TemplateField>
        <asp:BoundField DataField="sku" HeaderText="SKU" />   
        <asp:BoundField DataField="Heading" HeaderText="Heading" /> 
        <asp:BoundField DataField="Review" HeaderText="Review" />   
        <asp:BoundField DataField="Name" HeaderText="Name" />
          <asp:BoundField DataField="email" HeaderText="Email" />   
        <asp:BoundField DataField="Rating" HeaderText="Rating" />
         <asp:BoundField DataField="date" HeaderText="Date" DataFormatString="{0:dd-MM-yyyy}" />
           <asp:BoundField DataField="Status" HeaderText="Status"/>
        

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
