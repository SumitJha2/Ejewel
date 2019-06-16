<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CenterStoneOverView.aspx.cs" Inherits="EJewel.AdminView.Master.Stone.CenterStoneOverView" %>

    <form id="form1" runat="server">
    <table class="table table-bordered table-striped" style="width:100%">
        <thead>
         <tr><th colspan="5">
             Center Stone Details</th></tr>
         </thead>         
         <tbody>
         <tr>
			<td>SKU</td>
			<td colspan="4"><%= _SKU %></td>
		</tr>


		<tr>
			<td>Cut</td>
			<td><%= _Cut%></td>
			<td>&nbsp;</td>
			<td>Color</td>
			<td><%= _Color%></td>
		</tr>
       
        <tr>
			<td>Clarity</td>
			<td><%= _Clarity%></td>
			<td>&nbsp;</td>
			<td>Shape</td>
			<td><%= _Shape%></td>
		</tr>
        <tr>
			<td>Carate</td>
			<td><%= _Carate%></td>	
			<td>&nbsp;</td>
			<td>Price</td>
			<td><%= _Price%></td>
		</tr>
      
        <tr>
			<td colspan="5"><b>Certificate Details</b></td>
			</tr>
			

          <tr>
			<td>Depth</td>
			<td><%= _Depth%></td>	
			<td>&nbsp;</td>
			<td>Table</td>
			<td><%= _Table%></td>
		</tr>
           <tr>
			<td>Gridle</td>
			<td><%= _Gridle%></td>	
			<td>&nbsp;</td>
			<td>Symmetry</td>
			<td><%= _Symmetry%></td>
		</tr>

          <tr>
			<td>Culet</td>
			<td><%= _Culet%></td>	
			<td>&nbsp;</td>
			<td>Polish</td>
			<td><%= _Polish%></td>
		</tr>

         <tr>
			<td>Flouresence</td>
			<td><%= _Flouresence%></td>	
			<td>&nbsp;</td>
			<td>Measurement</td>
			<td><%= _Measurement%></td>
		</tr>

          <tr>
			<td>Crown</td>
			<td><%= _Crown%></td>	
			<td>&nbsp;</td>
			<td>Crown Angle</td>
			<td><%= _CrownAngle%></td>
		</tr>

          <tr>
			<td>Pavillion</td>
			<td><%= _Pavillion%></td>	
			<td>&nbsp;</td>
			<td>Pavillion Angle</td>
			<td><%= _PavillionAngle%></td>
		</tr>
          <tr>
			<td>Certificate</td>
			<td><%= _Certificate%></td>	
			<td>&nbsp;</td>
			<td>Lab</td>
			<td><%= _Lab%></td>
		</tr>

         <tr>
			<td>File</td>
			<td colspan="4"><%= _File%></td>
		</tr>

         <tr>
			<td>Status</td>
			<td colspan="4"><%= _Status%></td>
		</tr>
    </tbody>
        </table>
    </form>
