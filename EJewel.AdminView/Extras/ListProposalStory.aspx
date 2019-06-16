<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListProposalStory.aspx.cs" Inherits="EJewel.AdminView.Extras.ListProposalStory" %>
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
    <h1>Proposal Story</h1>
</div>
<div class="container">
        <div class="grid-24">
        <div style="float:right">
        
          <%--  <a href="javascript:void(0)" onclick = "popupwindow('/Extras/ManageProposalStories.aspx', 800,500)"  title="" class="thickbox btn btn-small">Create New</a>--%>
            <a href="javascript:void(0)" onclick = "go_to_next_page()"  title="" class="thickbox btn btn-small">Create New</a>
        </div>
        <br />
        <br />
        <asp:GridView ID="gvProposdalStories" CssClass="table table-bordered table-striped" 
                runat="server" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="gvProposdalStories_PageIndexChanging"
                OnRowDataBound="gvProposdalStories_RowDataBound" PageSize="20" AllowPaging="true">

        <Columns>
          <asp:TemplateField HeaderText="Sl.">
                <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>  
         <asp:HiddenField ID="hdnProposalId" runat="server" Value='<% #Eval("ProposalStoryID") %>' />       
         <asp:HiddenField ID="hdnImagePath" runat="server" Value='<% #Eval("ImagePath") %>' />
         <asp:HiddenField ID="hdnStatus" runat="server" Value='<% #Eval("Status") %>' />                
                 </ItemTemplate>
                 </asp:TemplateField>
        <asp:BoundField DataField="StoryHeader" HeaderText="Story Header" />   
        <asp:TemplateField HeaderText="Story Description">
        <ItemTemplate>
        <div id="divStoryDescriprion" style="overflow:Auto; height:100px;">
        <asp:Label ID="lblStoryDescription" runat="server" Text='<%#Bind("StoryDescription")%>'></asp:Label>
        </div>
        </ItemTemplate>
        </asp:TemplateField>   
  <%-- <asp:BoundField DataField="StoryDescription" HeaderText="Story Description"
                HtmlEncode="False" />--%>
        <asp:TemplateField HeaderText="Image">
        <ItemTemplate>
        <asp:Label ID="lblImage" runat="server"></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
          <asp:BoundField DataField="StoryDate" HeaderText="Date" DataFormatString="{0:dd-MM-yyyy}" />       
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
