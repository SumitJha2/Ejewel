<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListAdminUser.aspx.cs" Inherits="EJewel.AdminView.SiteSetting.ListAdminUser" %>
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
    <h1>User Details</h1>
</div>

 
<div class="container">
        <div class="grid-24">
        <div style="float:right">
        
            <a href="javascript:void(0)" onclick = "popupwindow('/SiteSetting/ManageAdminUsers.aspx', 800,500)"  title="" class="thickbox btn btn-small">Create New</a>
        </div>
        <br />
        <br />
       <asp:GridView ID="gvUserDetails" runat="server" CssClass="table table-bordered table-striped"  AutoGenerateColumns="False" onpageindexchanging="gvUserDetails_PageIndexChanging" OnRowDataBound="gvUserDetails_RowDataBound" PageSize="20" AllowPaging="true">
       <Columns>
     <asp:TemplateField HeaderText="Sl.">
     <ItemTemplate>
      <%# Container.DataItemIndex+1 %>  
      <asp:HiddenField ID="hdnUid" runat="server" Value='<% #Eval("UId") %>' />  
      </ItemTemplate>
     </asp:TemplateField>
       <asp:BoundField DataField="UserId" HeaderText="UserID" />
       <asp:BoundField DataField="UserName" HeaderText="User Name" />
       <asp:BoundField DataField="UserEmail" HeaderText="Email" />
       <asp:BoundField DataField="UserMobNo" HeaderText="Mob No." />
       <asp:BoundField DataField="UserTypeName" HeaderText="Type" />

        
         <asp:TemplateField HeaderText="Edit">
        <ItemTemplate>
       <asp:HyperLink ID="hprEdit" runat="server" NavigateUrl="#"><img src="/assets/themes/admin/images/icon/edit_16.png" /></asp:HyperLink>         
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
