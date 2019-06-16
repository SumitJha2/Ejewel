<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Country.aspx.cs" Inherits="EJewel.AdminView.Master.Shipment.Country" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div class="span12">                    
                        <div class="head clearfix">
                            <div class="isw-grid"></div>
                            <h1>Country Master</h1>      
                        </div>
                        <div class="block-fluid">
		<table border="0" cellpadding="0" cellspacing="0" class="table">
		<tr>
			<th colspan="2">Country Details</th>             
			<th>&nbsp;</th>          
            
      		</tr>
		<tr>
			<td >Country Name</td>
			<td>
            <asp:TextBox ID="txtCountryName" runat="server" ></asp:TextBox>
                <asp:HiddenField ID="hdnID" runat="server" Value="0" /><br />                
            </td> </tr>
            <tr>        
			<td>Country Code</td>			         
			<td>
            <asp:TextBox ID="txtCountryCode" runat="server"></asp:TextBox>         
             
            </td>            
		</tr>   
    
        <tr>
		<td > Status</td>
		<td>
        <asp:DropDownList ID="ddlStatus" runat="server">
        </asp:DropDownList>		 
            </td>
		<td>
            &nbsp;</td>
        </tr>
      
          <tr>
			<th  colspan="5"> 
                <input id="btnSave" type="button" value="Save" onclick="btnSave_onclick()" />			
		      </th>
		</tr>
          </table>
    </div>
    </div>
    <script type="text/javascript">
        function btnSave_onclick() {
            if (confirm('Do you want to save this record')) {
                var id = $("#<%=hdnID.ClientID %>").val();
                var name = $("#<%=txtCountryName.ClientID %>").val();
                var code = $("#<%=txtCountryCode.ClientID %>").val();
                var status=parseInt($("#<%=ddlStatus.ClientID %>").val())==1?true:false;
                var model = { CountryId: id, CountryName: name, CountryCode: code, Status: status };
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/Services/AdminServices.asmx/SaveUpdateCountry",
                    data: "{model:" + JSON.stringify(model) + "}",
                    dataType: "json",
                    success: function (data) {
                        if (id == 0) {
                            alert("Country details saved successfully.");
                        }
                        else {
                            alert("Country details updated successfully.");
                        }                    
                    },
                    error: function (result) {
                        alert("Error");
                    }
                });
            }
        }
    </script>
</asp:Content>
