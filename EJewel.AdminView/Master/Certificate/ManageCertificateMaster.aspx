<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageCertificateMaster.aspx.cs" Inherits="EJewel.AdminView.Master.Certificate.ManageCertificateMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="/asset/Script/Master/Certificate/CertificateMasterScript.js"></script>
<script type="text/javascript">
    function ValidateCertificate() {
        var name = $("#'<%=txtName.ClientID %>'").val();
        if (name == "") {
            alert('sumit');
            displayMsg('W', 'Required Field Can not be blank');
            return false;
        }
        else {
            return true;
        }
    }
</script>
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
         <td>Name</td>
         <td>
         <input type="hidden" id="txtID" value="0" />
         <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
         </td>
         </tr>
         <tr>
         <td>Status</td>
         <td>
         <asp:DropDownList ID="ddlstatus" runat="server">
         <asp:ListItem Text="Enabled" Value="1"></asp:ListItem>
          <asp:ListItem Text="Disabled" Value="0"></asp:ListItem>
         </asp:DropDownList>         
         </td>
         </tr>
          <tr>
			<th colspan="2">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="javascript:ValidateCertificate();"  onclick="btnSave_Click" />        
            
            </th>
		</tr>
         </table>
         </div>
         </div>
</asp:Content>
