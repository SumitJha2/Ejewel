<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PromotionalcodeManagement.aspx.cs" Inherits="EJewel.AdminView.Order.PromotionalcodeManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     <style type="text/css">
       
        body { font: 12px/1.7em "Open Sans", "trebuchet ms", arial, sans-serif; color: #444; }
        .color
        {
        	color:Red;
        	
        }
         .style1
         {
             width: 167px;
         }
         .style2
         {
             width: 156px;
         }
    </style>
      <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/form.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/message.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/table.css" type="text/css" />

     <link href="../assets/webcontrols/jquery_ui/css/ui-lightness/jquery-ui-1.10.3.custom.css"
        rel="stylesheet" type="text/css" />
    <script src="../assets/webcontrols/jquery_ui/js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../assets/webcontrols/jquery_ui/js/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
    <script>
        $(function () {

            var fromdate = { dateFormat: "dd-mm-yy" };
            var todate = { dateFormat: "dd-mm-yy" };


            $("#<%=txtFromDate.ClientID %>").datepicker(fromdate);
            $("#<%=txtToDate.ClientID %>").datepicker(todate);
        });
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
<div id="contentHeader">
    <h1>Promotionalcode Management</h1>
</div>
<div class="container">
<table class="table table-bordered table-striped">
<tr><td colspan="3">
<span id="spnMessage" style="color:Green;" runat="server"></span>
</td></tr>


<tr><td></td><td class="style2">Promocode Type</td><td ><asp:RadioButtonList ID="rblPromocodeType" 
        runat="server" RepeatDirection="Horizontal" AutoPostBack="True" BorderStyle="None" 
        onselectedindexchanged="rblPromocodeType_SelectedIndexChanged"></asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="rvfPromocodetype" runat="server" CssClass="color" ErrorMessage="Please select atleast one type" ControlToValidate="rblPromocodeType"></asp:RequiredFieldValidator>
        </td></tr>
<tr><td></td><td class="style2"></td><td></td></tr>
<tr><td></td><td class="style2">Promotionalcode</td><td><asp:TextBox ID="txtPromotionalCodeNumber" runat="server" Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvPromotionCode" runat="server" CssClass="color" ErrorMessage="Please enter promotion code." ControlToValidate="txtPromotionalCodeNumber"></asp:RequiredFieldValidator>
 </td></tr>
<tr><td></td><td class="style2"></td><td></td></tr>

 <tr>
 <td colspan="3">
 <table style="width:100%;" class="table table-bordered table-striped" id="tblCategory" runat="server">
 <tr><td  style="width:1px;"></td>
<td style="width:169px;" >Category</td><td><asp:DropDownList ID="ddlCategory" runat="server" Width="200px" 
        AutoPostBack="True" onselectedindexchanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvCategory" runat="server" CssClass="color" ErrorMessage="Please select category." InitialValue="0" ControlToValidate="ddlCategory"></asp:RequiredFieldValidator>
        </td></tr>
        </table>
        </td>
        </tr>

<tr><td colspan="3"></td></tr>
 <tr><td colspan="3">
 <table style="width:100%;" class="table table-bordered table-striped" id="tblSubCategory" runat="server">
 <tr><td  style="width:1px;"></td>
  <td class="style1">Sub Category</td><td><asp:DropDownList ID="ddlSubCategory" runat="server" Width="200px"></asp:DropDownList>
  <asp:RequiredFieldValidator ID="rfvSubCategory" runat="server" CssClass="color" ErrorMessage="Please select sub category." InitialValue="0" ControlToValidate="ddlSubCategory"></asp:RequiredFieldValidator>
  </td>
  </tr>
 </table>
 </td>
 </tr>


<tr><td colspan="3">
<table style="width:100%;" class="table table-bordered table-striped" id="tblDiscount" runat="server">
 <tr><td  style="width:1px;"></td>
<td style="width:169px;" >Discount</td><td><asp:TextBox ID="txtDiscountPrice" runat="server" Width="200px"></asp:TextBox>

<asp:DropDownList ID="ddlDiscountType" runat="server">
<asp:ListItem Text="%" Value="%"></asp:ListItem>
<asp:ListItem Text="$" Value="$"></asp:ListItem>
</asp:DropDownList><asp:RequiredFieldValidator ID="rfvDiscount" runat="server" CssClass="color" ErrorMessage="Please enter discount." ControlToValidate="txtDiscountPrice"></asp:RequiredFieldValidator></td></tr>
        </table>
</td>
</tr>


<tr><td></td><td class="style2"></td><td></td></tr>
<tr><td colspan="3">
<table style="width:100%;" class="table table-bordered table-striped" id="tblSku" runat="server">
 <tr><td  style="width:1px;"></td>
  <td class="style1">Product SKU</td><td><asp:TextBox ID="txtProductSKU" runat="server" Width="200px"></asp:TextBox>
  <asp:RequiredFieldValidator ID="rfvSku" runat="server" CssClass="color" ErrorMessage="Please enter sku." ControlToValidate="txtProductSKU"></asp:RequiredFieldValidator>
  </td>
  </tr>
 </table>
</td>
</tr>



<tr><td></td><td class="style2"></td><td></td></tr>

<tr><td></td><td class="style2">Offer Validity</td><td>From Date: <asp:TextBox ID="txtFromDate" runat="server" Width="200px"></asp:TextBox>&nbsp; To Date: <asp:TextBox ID="txtToDate" runat="server" Width="200px"></asp:TextBox><asp:RequiredFieldValidator ID="rvfFromDate" runat="server" CssClass="color" ErrorMessage="Please enter fromdate." ControlToValidate="txtFromDate"></asp:RequiredFieldValidator><br /><asp:RequiredFieldValidator ID="rvfToDate" runat="server" CssClass="color" ErrorMessage="Please enter todate." ControlToValidate="txtToDate"></asp:RequiredFieldValidator></td></tr>
<tr><td></td><td class="style2"></td><td></td></tr>
<tr><td></td><td class="style2">Status</td><td><asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal">
<asp:ListItem Text="Active" Value="True" Selected="True"></asp:ListItem>
<asp:ListItem Text="InActive" Value="False"></asp:ListItem>
</asp:RadioButtonList></td></tr>
<tr><td></td><td class="style2"></td><td></td></tr>
<tr><td></td><td class="style2"></td><td><asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" /><asp:Button ID="btnCancel" runat="server" 
        Text="Cancel" onclick="btnCancel_Click" CausesValidation="false" /></td></tr>

</table>
</div>
    </div>
    </form>
</body>
</html>
