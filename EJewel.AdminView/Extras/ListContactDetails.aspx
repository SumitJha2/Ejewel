<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListContactDetails.aspx.cs" Inherits="EJewel.AdminView.Extras.ListContactDetails" %>
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
    <h1>Contact Details</h1>
</div>
<div class="container">
        <div class="grid-24">
        <br />
        <br />
       <asp:GridView ID="gvContactDetails" runat="server" CssClass="table table-bordered table-striped"  AutoGenerateColumns="False" onpageindexchanging="gvContactDetails_PageIndexChanging" PageSize="20" AllowPaging="true">
       <Columns>
     <asp:TemplateField HeaderText="Sl.">
     <ItemTemplate>
      <%# Container.DataItemIndex+1 %>  
      <asp:HiddenField ID="hdnContctDetailsId" runat="server" Value='<% #Eval("ContactDetailsId") %>' />  
      </ItemTemplate>
     </asp:TemplateField>
       <asp:BoundField DataField="FirstName" HeaderText="First Name" />
       <asp:BoundField DataField="LastName" HeaderText="Last Name" />
       <asp:BoundField DataField="Email" HeaderText="Email" />
       <asp:BoundField DataField="Message" HeaderText="Message" />
       <asp:BoundField DataField="Telephone" HeaderText="Phone No" />
        <asp:BoundField DataField="ContactDate" HeaderText="Date" DataFormatString="{0:dd-MM-yyyy}" />
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
