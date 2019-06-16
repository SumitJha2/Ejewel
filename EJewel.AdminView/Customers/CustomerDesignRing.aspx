<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerDesignRing.aspx.cs" Inherits="EJewel.AdminView.Customers.CustomerDesignRing" %>
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
    <h1>Customer Design Ring</h1>
</div>
<div class="container">
        <div class="grid-24">
        <div style="float:right">    
     
           
        </div>
        <br />
        <br />
        <asp:GridView ID="gvCustomerDesign" CssClass="table table-bordered table-striped" 
                runat="server" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="gvProposdalStories_PageIndexChanging"
                OnRowDataBound="gvCustomerDesign_RowDataBound" PageSize="20" 
                AllowPaging="True">

        <Columns>
          <asp:TemplateField HeaderText="Sl.">
                <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>  
         <asp:HiddenField ID="hdnCustomDesignRequestID" runat="server" Value='<% #Eval("CustomDesignRequestID") %>' />       
           
                 </ItemTemplate>
                 </asp:TemplateField>
         <asp:BoundField DataField="FullName" HeaderText="Full Name" />            
        <asp:BoundField DataField="Email" HeaderText="E-mail" /> 
        <asp:BoundField DataField="Phone" HeaderText="Phone" />
        <asp:BoundField DataField="DiamondItem" HeaderText="Diamond Item" /> 
        <asp:BoundField DataField="SideStones" HeaderText="Side Stone" />   
        <asp:BoundField DataField="Budget" HeaderText="Budget" />   
        <asp:BoundField DataField="LinkstoDesign" HeaderText="Links to Design" />  
          <asp:BoundField DataField="Comments" HeaderText="Comments" />     
            
        <asp:BoundField DataField="BestTimeToCall" HeaderText="Best Time Call" />   
        <asp:BoundField DataField="MetalName" HeaderText="Metal Name" />  
         <asp:BoundField DataField="RingSize" HeaderText="Ring Size" />  
           <asp:BoundField DataField="CreatedDate" HeaderText="Date" 
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
