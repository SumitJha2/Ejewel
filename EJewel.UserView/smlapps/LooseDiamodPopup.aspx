<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LooseDiamodPopup.aspx.cs" Inherits="EJewel.UserView.smlapps.LooseDiamodPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="dialog_center_stone" title="Center Stone">
    <table class="table table-bordered table-striped" style="width:100%">
    <thead>
    </thead>
    <tbody>
    <!--Fillter-->
    <tr>
    <td valign="top">
    <table class="table table-bordered table-striped" style="width:100%">
    <tbody>
    <!--Shape-->
    <tr>
    <td colspan="3" align="right">
    Setting Price : $<span id="spanSettingPrice"></span> + Center Stone Price : $<span id="spanCenterStonePrice">0</span> = 
    $<span id="spanTotalPrice"></span>
    </td>
    </tr>
    <tr>
    <td>Shape</td>
    <td>Carat</td>
    <td>Color</td>
    </tr>
    <tr>
    <!--Shape-->
    <td>
    <div id="shape_button"></div>
    </td>
    <!--Carat-->
    <td align="center">
    <div id="carat_slider" style="width:200px;"></div><br />
    <span id="spanCaratRange"></span>
    <input type="hidden" id="hdnMinCarat" />
    <input type="hidden" id="hdnMaxCarat" />
    </td>
    <!--Color-->
    <td align="center">
    <div id="color_slider" style="width:200px;"></div><br />
    <span id="spancolorText" class="slide_text"></span>
     <input type="hidden" id="hdnMinColor" />
     <input type="hidden" id="hdnMaxColor" />
    </td>
    </tr>
    <tr>
    <td>Price</td>
    <td>Cut</td>
    <td>Clarity</td>
    </tr>
    <tr>
    <!--Price-->
    <td align="center">
    <div id="price_slider" style="width:200px;"></div><br />
    <span id="spanPriceRange"></span>
    <input type="hidden" id="hdnMinPrice" />
    <input type="hidden" id="hdnMaxPrice" />
    </td>
    <!--Cut-->
    <td align="center">
    <div id="cut_slider" style="width:330px;"></div>
    <span id="spanCutText"></span>
    <input type="hidden" id="hdnMinCut" />
    <input type="hidden" id="hdnMaxCut" />
    </td>
    <!--Clarity-->
    <td align="center">
    <div id="clarity_slider" style="width:330px;"></div>
    <span id="spanClarityText"></span>
    <input type="hidden" id="hdnMinClarity" />
    <input type="hidden" id="hdnMaxClarity" />
    </td>
    </tr>
    </tbody>
    </table>
    </td>
    </tr>
    <!--Dettails-->
    <tr>
    <td valign="top">
    <table class="table table-bordered table-striped" style="width:100%">
    <thead>
    <tr>
        <th>Compare</th>
        <th>Shape</th>
        <th>Carat</th>
        <th>Cut</th>
        <th>Color</th>
        <th>Clarity</th>
        <th>Price</th>
        <th>Details</th>
    </tr>
    </thead>
    <tbody id="tblCenterStone"></tbody>
    </table>
    </td>
    </tr>
    <!--Compare-->
    <tr>
    <td valign="top">
    <table class="table table-bordered table-striped" style="width:100%">
    <thead>
    <tr><th colspan="8">Compare</th></tr>
    <tr>
        <th>Remove</th>
        <th>Shape</th>
        <th>Carat</th>
        <th>Cut</th>
        <th>Color</th>
        <th>Clarity</th>
        <th>Price</th>
        <th>Details</th>
    </tr>
    </thead>
    <tbody id="tblStoneCompare">
    </tbody>
    </table>
    </td>
    </tr>
    </tbody>
</table>
   
    </div>

    <div id="loose_diamond_details">
     <table style="width:100%" class="table table-bordered table-striped">
     <tbody>
     <tr>
     <td>SKU #</td>
     <td><span id="ldd_sku"></span></td>
     </tr>
     <tr>
     <td>Depth</td>
     <td><span id="ldd_depth"></span></td>
     </tr>
     <tr>
     <td>Table</td>
     <td><span id="ldd_table"></span></td>
     </tr>
      <tr>
     <td>Gridle</td>
     <td><span id="ldd_gridle"></span></td>
     </tr>
     <tr>
      <td>Polish</td>
     <td><span id="ldd_polish"></span></td>
     </tr>

     <tr>
      <td>Symmetry</td>
     <td><span id="ldd_symmetry"></span></td>
     </tr>

      <tr>
      <td>Culet</td>
     <td><span id="ldd_culet"></span></td>
     </tr>

     <tr>
      <td>Fluorescence</td>
     <td><span id="ldd_fluorescence"></span></td>
     </tr>

      <tr>
     <td>Measurements</td>
     <td><span id="ldd_measurements"></span></td>
     </tr>

      <tr>
     <td>Price</td>
     <td><span id="ldd_price"></span></td>
     </tr>
     </tbody>
     </table>
    </div>


    </form>
</body>
</html>
