
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageShipping.aspx.cs" Inherits="EJewel.AdminView.Order.ManageShipping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    function Validate_Price() {
        var gridcontrol = document.getElementById("<%=gvCountryPrice.ClientID %>");
        var no_rows = gridcontrol.rows.length;
        for (var i = 1; i < no_rows; i++) {
            var current_rows = gridcontrol.rows[i].getElementsByTagName("input");
            var price_textbox = current_rows[0];
            if (price_textbox.value == "") {
                alert('Please enter price.');
                return false;
            }  
           if (isNaN(price_textbox.value.trim())) {
                alert('Please enter price in correct format.');
                return false;
            }

        }
        return true;

   


    }
</script>
   <div id="contentHeader">
    <h1>Shipping Charges</h1>
</div>
   <div class="container">
   <div class="grid-24"> 
		<table class="table table-bordered table-striped" style="width:100%">       
        <tbody>
        <tr><td colspan="2"> <span id="spnMessage" runat="server" style="color:Green;"></span></td></tr>
        <tr>
			<td>Shipping Name<span class="small_error">&nbsp;*</span></td>
			<td>              
                <asp:DropDownList ID="ddlShippingName" runat="server" CssClass="common_width">
                </asp:DropDownList>
             <asp:RequiredFieldValidator ID="rfvShippingName" runat="server" style="color:Red;" ControlToValidate="ddlShippingName" InitialValue="0" ErrorMessage="Please select shipping name."></asp:RequiredFieldValidator>
            </td>
		</tr>
		<tr>
			<td>Shipping Type<span class="small_error">&nbsp;*</span></td>
			<td>
                <asp:HiddenField ID="hdnID" runat="server" Value="0" />                
                <asp:DropDownList ID="ddlShippingType" runat="server" 
                    CssClass="common_width">
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="rfvShippingType" runat="server" style="color:Red;" ControlToValidate="ddlShippingType" InitialValue="0" ErrorMessage="Please select shipping type."></asp:RequiredFieldValidator>
            </td>
		</tr>
        <tr>
			<td><span class="small_error"></span></td>
			<td><asp:Button ID="btnShow" runat="server" class="btn btn-small" onclick="btnShow_Click" Text="Show" />                
            </td>
		</tr>       
        <tr>
        <td colspan="2">
        <asp:GridView ID="gvCountryPrice" runat="server" GridLines="None" AutoGenerateColumns="false" Width="100%" 
                onrowdatabound="gvCountryPrice_RowDataBound" CellPadding="0" CssClass="table table-bordered table-striped">
        <Columns>
        <asp:TemplateField HeaderText="Sr. No.">
        <ItemTemplate>
         <%# Container.DataItemIndex+1 %>
        </ItemTemplate>
         <ItemStyle HorizontalAlign="Center"/>   
        </asp:TemplateField>
          <asp:TemplateField HeaderText="Country">
        <ItemTemplate>
      <asp:Label ID="lblCountryId" runat="server" Text='<% #Eval("CountryName") %>'></asp:Label> 
         </ItemTemplate>
         <ItemStyle HorizontalAlign="Center"/>   
          </asp:TemplateField>

        <asp:TemplateField HeaderText="Price">
        <ItemTemplate>
        <asp:TextBox ID="txtPrice" runat="server" Text='<% #Eval("Price") %>'></asp:TextBox>
        <asp:HiddenField ID="hdnCountryId" runat="server" Value='<% #Eval("CountryID") %>' />
         </ItemTemplate>
         <ItemStyle HorizontalAlign="Center"/>   
              </asp:TemplateField>
        <asp:TemplateField HeaderText="Status">
        <ItemTemplate>
        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="common_width">
        <asp:ListItem Text="Enabled" Value="1"></asp:ListItem>
         <asp:ListItem Text="Disabled" Value="0"></asp:ListItem>
            </asp:DropDownList>
            <asp:HiddenField ID="hdnStatus" runat="server" Value='<% #Eval("Status") %>' />
        </ItemTemplate>
          <ItemStyle HorizontalAlign="Center"/>   
        </asp:TemplateField>
        
        </Columns>
        </asp:GridView>        
        </td>        
        </tr>
	<tr>
		<td colspan="2">
        <asp:Button ID="btnSave" runat="server" class="btn btn-small" OnClientClick="return Validate_Price()" onclick="btnSave_Click" Text="Save" />
    	&nbsp;
           
            </td>
		</tr>
    </tbody>
	</table>
    </div>
    </div>
</asp:Content>
