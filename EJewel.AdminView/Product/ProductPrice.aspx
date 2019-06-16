<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductPrice.aspx.cs" Inherits="EJewel.AdminView.Product.ProductPrice" %>
    <div>
    
    <table class="table table-bordered table-striped" style="width:100%">
    <thead>
    <tr><th colspan="2">Product Price ( <asp:Label ID="lblSKU" runat="server"></asp:Label>
        )</th></tr>
    </thead>
    <tbody>
    <tr>
    <td colspan="2"><i>Basic Price</i></td> 
    </tr>
    <tr>
    <td>Metal Price ( <asp:Label ID="lblDefaultMetal" runat="server"></asp:Label>
&nbsp;)</td> <td>$<asp:Label ID="lblMetalPrice" runat="server"></asp:Label></td>
    </tr>
    <tr>
    <td>Side Stone Price</td> <td>$<asp:Label ID="lblSideStone" runat="server"></asp:Label></td>
    </tr>
     <tr>
    <td>Matching Band Price</td> <td>$<asp:Label ID="lblMatchingBand" runat="server"></asp:Label></td>
    </tr>
     <tr>
    <td colspan="2"><i>Setting Price</i></td> 
    </tr>
     <tr>
    <td>Center Stone Setting Price</td> <td>$<asp:Label ID="lblCenterStoneSettingPrice" 
             runat="server"></asp:Label>
         </td>
    </tr>
     <tr>
    <td>Side Stone Setting Price</td> <td>$<asp:Label ID="lblSideStoneSettingPrice" 
             runat="server"></asp:Label>
         </td>
    </tr>
     <tr>
    <td>Matching Band Setting Price</td> <td>$<asp:Label 
             ID="lblMatchingBandSettingPrice" runat="server"></asp:Label>
         </td>
    </tr>
     <tr>
    <td>Total Setting Price</td> <td>$<asp:Label ID="lblSettingPrice" runat="server"></asp:Label></td>
    </tr>
     <tr>
    <td colspan="2"><i>Extra Price</i></td> 
    </tr>
    
     <tr>
    <td>Chain Price</td> <td>$<asp:Label ID="lblChainPrice" runat="server"></asp:Label></td>
    </tr>
    
    <tr>
    <td>Total Price</td> <td><strong>$<asp:Label ID="lblTotalPrice" runat="server"></asp:Label></strong></td>
    </tr>
    </tbody>
    </table>
    </div>
