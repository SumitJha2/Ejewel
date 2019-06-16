<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageStoneCertificate.aspx.cs" Inherits="EJewel.AdminView.Master.Certificate.ManageStoneCertificate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<script src="/asset/Script/Master/Certificate/CertificateScript.js" type="text/javascript"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="span12">                    
                        <div class="head clearfix">
                            <div class="isw-grid"></div>
                            <h1 id="headingText">Product Category Master</h1>      
                        </div>
                        <div class="block-fluid">
       <table border="0" cellpadding="0" cellspacing="0" class="table">
        <tr>
			<th valign="top">SKU:</th>
			<td>
            <asp:Label ID="lblSKU" runat="server"></asp:Label>
           </td>
		</tr>
		<tr>
			<th valign="top">Depth:</th>
			<td>
          <asp:TextBox ID="txtDepth" runat="server"></asp:TextBox>            
            </td>
		</tr>
        <tr>
			<th valign="top">Table:</th>
			<td>
             <asp:TextBox ID="txtTable" runat="server"></asp:TextBox>       
            
            </td>
		</tr>
        <tr>
			<th valign="top">Gridle:</th>
			<td>
            <asp:DropDownList ID="ddlGridle" runat="server"></asp:DropDownList>            
            </td>
		</tr>
        <tr>
			<th valign="top">Symmetry:</th>
			<td>
           <asp:DropDownList ID="ddlSymmetry" runat="server">
            </asp:DropDownList>
            
            </td>
		</tr>
        <tr>
			<th valign="top">Culet:</th>
			<td>
            <asp:DropDownList ID="ddlCulet" runat="server">
            </asp:DropDownList>
            </td>
		</tr>
         <tr>
			<th valign="top">Polish:</th>
			<td>          
             <asp:DropDownList ID="ddlPolish" runat="server">
            </asp:DropDownList>
            </td>
		</tr>
         <tr>
			<th valign="top">Flouresence:</th>
			<td>         
             <asp:DropDownList ID="ddlFlouresence" runat="server">
            </asp:DropDownList>
            </td>
		</tr>
         <tr>
			<th valign="top">Measurement:</th>
			<td>
          <asp:TextBox ID="txtMeasurement" runat="server"></asp:TextBox>
  
            </td>
		</tr>
         <tr>
			<th valign="top">Crown:</th>
			<td>          
               <asp:TextBox ID="txtCrown" runat="server"></asp:TextBox>
            </td>
		</tr>
         <tr>
			<th valign="top">Crown Angle:</th>
			<td>         
             <asp:TextBox ID="txtCrownAngle" runat="server"></asp:TextBox>    
            </td>
		</tr>
         <tr>
			<th valign="top">Pavillion:</th>
			<td>          
             <asp:TextBox ID="txtPavillion" runat="server"></asp:TextBox>  
            </td>
		</tr>
        <tr>
			<th valign="top">Pavillion Angle:</th>
			<td>          
              <asp:TextBox ID="txtPavillionAngle" runat="server"></asp:TextBox>  
            </td>
		</tr>
        <tr>
			<th valign="top">Certification:</th>
			<td>           
             <asp:TextBox ID="txtCertification" runat="server"></asp:TextBox>  
            </td>
		</tr>

         <tr>
			<th valign="top">Lab:</th>
			<td>           
            <asp:DropDownList ID="ddlLab" runat="server"></asp:DropDownList>
            </td>
		</tr>
         <tr>
			<th valign="top">File:</th>
			<td>
            <asp:FileUpload id="FdCertificate" runat="server" />
           <font color="red" size="3px"><asp:Label ID="lblerroer" runat="server"></asp:Label></font>
            <a id="viewCertificate" runat="server" target="_blank">View Certificate</a>
               <%-- <asp:LinkButton ID="lnkCertificate" runat="server" Text="View Certificate" 
                    Visible="false" onclick="lnkCertificate_Click"></asp:LinkButton>         --%>    
                    </td> 
		</tr>
            <tr>
			<th valign="top">Status:</th>
			<td>           
            <asp:DropDownList ID="dd1Status" runat="server">
            <asp:ListItem Text="Enabled" Value="1"></asp:ListItem>
            <asp:ListItem Text="Disabled" Value="0"></asp:ListItem>
            </asp:DropDownList>
            </td>
		</tr>
         <tr>
			<th colspan="2">
              <asp:Button ID="btnSave" runat="server" Text="Save" class="form-submit" 
                    onclick="btnSave_Click" />            
		     </th>
			
        </table>
        </div>
        </div>
</asp:Content>
