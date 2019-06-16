<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LooseDiamondDetails.aspx.cs" Inherits="EJewel.UserView.LooseDiamondDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 371px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
  <table width="100%">
  <tr>
  <td colspan="2">
 <h1><asp:Label ID="lblHeading" runat="server"></asp:Label></h1>
  </td>
  
  </tr>



  <tr>
  <td height="200px">
<%--  image part--%>
  </td>
  <td valign="top" align="center">
  <b> SKU : <asp:Label ID="lbSKU" runat="server"></asp:Label></b><br />
 <b> Our Price :</b><asp:Label ID="lblOurPrice" runat="server"></asp:Label> <br />
 
 <asp:Label ID="lblDesc" runat="server"></asp:Label>

  </td>
  
  </tr>

  <tr>
  <td colspan="2">
  <table>
  <tr>
    <td>SKU :</td>
    <td><asp:Label ID="lblSku" runat="server"></asp:Label></td>
    <td></td>
    <td>Depth</td>
    <td><asp:Label ID="lblDepth" runat="server"></asp:Label></td>
    </tr>

 <tr>
    <td>Price :</td>
    <td><asp:Label ID="lblPrice" runat="server"></asp:Label></td>
    <td></td>
    <td>Table</td>
    <td><asp:Label ID="lblTable" runat="server"></asp:Label></td>
    </tr>
     <tr>
    <td>Carat :</td>
    <td><asp:Label ID="lblCarat" runat="server"></asp:Label></td>
    <td></td>
    <td>Polish</td>
    <td><asp:Label ID="lblPolish" runat="server"></asp:Label></td>
    </tr>

    <tr>
    <td>Cut :</td>
    <td><asp:Label ID="lblCut" runat="server"></asp:Label></td>
    <td></td>
    <td>Symmetry</td>
    <td><asp:Label ID="lblSymmetry" runat="server"></asp:Label></td>
    </tr>

    <tr>
    <td>Color :</td>
    <td><asp:Label ID="lblColor" runat="server"></asp:Label></td>
    <td></td>
    <td>Griddle</td>
    <td><asp:Label ID="lblGriddle" runat="server"></asp:Label></td>
    </tr>

     <tr>
    <td>Clarity :</td>
    <td><asp:Label ID="lblClarity" runat="server"></asp:Label></td>
    <td></td>
    <td>Culet</td>
    <td><asp:Label ID="lblCulet" runat="server"></asp:Label></td>
    </tr>
      <tr>
      <td colspan="3"></td>
    <td>Fluoresence :</td>
    <td><asp:Label ID="lblFluoresence" runat="server"></asp:Label></td>
   </tr>
    
  
    <tr><td colspan="3"></td>
    <td>Measurement</td>
    <td><asp:Label ID="lblMeasurement" runat="server"></asp:Label></td>
    </tr>
    <tr><td colspan="3"></td>
    <td>Crown</td>
    <td>
    <asp:Label ID="lblCrown" runat="server"></asp:Label></td>
   
    </tr>
 <tr><td colspan="3"></td>
    <td>Crown Angle</td>
    <td><asp:Label ID="lblCrownAngle" runat="server"></asp:Label></td>
    </tr>
    <tr><td colspan="3"></td>
    <td>Pavilion</td>
    <td>
    <asp:Label ID="lblPavilion" runat="server"></asp:Label>
   
    </tr>
     <tr><td colspan="3"></td>
    <td>Pavilion Angle</td>
    <td>
    <asp:Label ID="lblPavilionAngle" runat="server"></asp:Label>
    </td>
    </tr>
     <tr><td colspan="3"></td>
    <td>Lab</td>
    <td>
    <asp:Label ID="lblLab" runat="server"></asp:Label>
   
    </td>
    </tr>

     <tr><td colspan="3"></td>
    <td>Certificate</td>
    <td>
    <asp:Label ID="lblCertificate" runat="server"></asp:Label>
   
    </td>
    </tr>
  
  </table>
  
  </td>
  </tr>



  
  </table>  
   
 




  


    </div>
    </form>
</body>
</html>
