<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoggedUserDetails.aspx.cs" Inherits="EJewel.AdminView.SiteSetting.LoggedUserDetails" %>
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
    <h1>Logged User Details</h1>
</div>

 
<div class="container">
        <div class="grid-24">
      
        <br />
        <br />
       <asp:GridView ID="gvLoggedUserDetails" runat="server" CssClass="table table-bordered table-striped"  AutoGenerateColumns="False" onpageindexchanging="gvUserDetails_PageIndexChanging"  PageSize="20" AllowPaging="true">
       <Columns>
     <asp:TemplateField HeaderText="Sl.">
     <ItemTemplate>
      <%# Container.DataItemIndex+1 %>  
      <asp:HiddenField ID="hdnLoggedUserID" runat="server" Value='<% #Eval("LoggedUserID") %>' />  
      </ItemTemplate>
     </asp:TemplateField>
       <asp:BoundField DataField="LoginID" HeaderText="User ID" />
       <asp:BoundField DataField="LoggedDatetime" HeaderText="Date" />     
       <asp:BoundField DataField="LoggedUserIP" HeaderText="IP-Address" />
        
       
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
