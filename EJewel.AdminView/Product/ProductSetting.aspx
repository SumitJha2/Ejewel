<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductSetting.aspx.cs" Inherits="EJewel.AdminView.Product.ProductSetting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Setting</title>
     <style type="text/css">
        body { font: 12px/1.7em "Open Sans", "trebuchet ms", arial, sans-serif; color: #444; }
    </style>
    <!--CSS-->
     <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/form.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/message.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/table.css" type="text/css" />
    <!--Script-->
    <script src="/assets/themes/admin/javascripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="/assets/themes/admin/javascripts/globalscript.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnSave">
    <div>
    <table class="table table-bordered table-striped" style="width:100%">
        <thead>
        <tr><th colspan="4">Product Setting</th></tr>
        </thead>
        <tbody>    
      <tr>
      <td colspan="4">SKU : <asp:Label ID="lblSKUDetails" runat="server"></asp:Label></td>   
      </tr>
      <tr>
      <td width="20%">Best Selling</td>
      <td width="5%"><asp:CheckBox ID="chkBestSelling" runat="server" /></td>
      <td align="right">New Product</td>
      <td><asp:CheckBox ID="chkNewProduct" runat="server" /></td>
      </tr>
     
      <tr>
      <td>Men's Gift</td>
      <td><asp:CheckBox ID="chkMenGift" runat="server" /></td>
       <td align="right">Women's Gift</td>
      <td><asp:CheckBox ID="chkWomenGift" runat="server" /></td>
      </tr>
   
       <tr>
      <td>Children's Gift</td>
      <td><asp:CheckBox ID="chkChildrenGift" runat="server" /></td>
       <td align="right">Others Gift</td>
      <td><asp:CheckBox ID="chkOthersGift" runat="server" /></td>
      </tr>
     
      <tr>
      <td>Sales</td>
      <td colspan="3"><asp:CheckBox ID="chkSales" runat="server" AutoPostBack="true" oncheckedchanged="chkSales_changed"/> 
             
              <span id="spnDiscount" runat="server">
              <asp:Label ID="lblDiscount" runat="server" Text="Discount"></asp:Label>&nbsp;&nbsp;
              <asp:TextBox ID="txtDiscount" runat="server" onkeyup="this.value = this.value.replace(/[^0-9,\. ]/, '')" onkeydown="this.value = this.value.replace(/[^0-9,\. ]/, '')"></asp:TextBox>&nbsp;
              &nbsp;&nbsp;Type &nbsp;
              <asp:DropDownList ID="ddlDiscountType" runat="server">
              <asp:ListItem Value="1" Text="$"></asp:ListItem>
              <asp:ListItem Value="2" Text="%"></asp:ListItem>             
              </asp:DropDownList>
              </span>
      </td>     
      </tr>      
      <tr>
      <td>Publish</td>
      <td><asp:CheckBox ID="chkPublish" runat="server" /></td>  
        <td align="right">Extra Ordinary</td>
      <td><asp:CheckBox ID="chkExtraOrdinary" runat="server" /></td>          
      </tr>

      <tr>
      <td></td>
      <td colspan="3">
      <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" class="btn btn-small" Text="Save"/>
       <span id="spnMessage" runat="server" style="color:Green;"></span>
      </td>
      </tr>
        </tbody>
        </table>
    </div>
    </form>
</body>
</html>
