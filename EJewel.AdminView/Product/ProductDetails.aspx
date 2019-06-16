<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="EJewel.AdminView.Product.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="contentHeader">
    <h1>Manage Product</h1>
</div>
<div class="container">
        <div class="grid-24">
        <asp:Label ID="lblMessage" runat="server" CssClass="small_error"></asp:Label>
        <table class="table table-bordered table-striped" style="width:100%">

        <thead>
        <tr>
        <th colspan="2">Product Details</th>
        <th colspan="2">SEO Details (For the Product)</th>
        </tr>
         </thead>

        <tbody>
        <tr>
        <td>Product Category<span class="small_error">&nbsp;*</span></td>
        <td>
            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="common_width">
            </asp:DropDownList>
           
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="ddlCategory" CssClass="small_error" ErrorMessage="*"></asp:RequiredFieldValidator>
           
            </td>
            

       <td>Page Title<span class="small_error">&nbsp;*</span></td>
        <td>
            <asp:TextBox ID="txtPageTitle" runat="server"   CssClass="common_width"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtPageTitle" CssClass="small_error" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            </tr>

        <tr><td>SKU (Should Be Unique)<span class="small_error">&nbsp;*</span></td>
        <td>
            <asp:TextBox ID="txtSKU" runat="server" CssClass="common_width"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="txtSKU" CssClass="small_error" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td><td>Meta Keyword<span class="small_error">&nbsp;*</span></td><td>
            <asp:TextBox ID="txtMetaKeyword" runat="server" CssClass="common_width"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="txtMetaKeyword" CssClass="small_error" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td></tr>
        <tr><td>Product Title<span class="small_error">&nbsp;*</span></td>
        <td>
            <asp:TextBox ID="txtTitle" runat="server" MaxLength="60" CssClass="common_width"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="txtTitle" CssClass="small_error" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td><td>
                &nbsp;</td><td>
                &nbsp;</td></tr>
        <tr><td>Product Description<span class="small_error">&nbsp;*</span></td>
        <td>
            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Height="100px"  CssClass="common_width"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                ControlToValidate="txtDesc" CssClass="small_error" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td><td>Meta Description<span class="small_error">&nbsp;*</span></td><td>
       
            <asp:TextBox ID="txtMetaDesc" runat="server" TextMode="MultiLine" Height="100px" CssClass="common_width"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="txtMetaDesc" CssClass="small_error" ErrorMessage="*"></asp:RequiredFieldValidator>
       
            </td></tr>
            <tr><td colspan="4">
            <asp:Button ID="btnAction" runat="server" Text="Save Product Details" onclick="btnAction_Click"  CssClass="btn btn-green" OnClientClick="" /> &nbsp;
            <asp:HyperLink ID="lnkMetal" runat="server"></asp:HyperLink>
            <input type="button" value="« Back To Product" style="float:right;" class="btn btn-error" onclick="location.href='/Product/ProductList.aspx'" />
            </td></tr>
        </tbody>
        </table>
        </div>
        </div>
</asp:Content>