<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductMetal.aspx.cs" Inherits="EJewel.AdminView.Product.ProductMetal" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">

    function Validate_Metal_Selection() {
        if (document.getElementById("<%=txtWeight.ClientID %>").value.trim() == "") {
            alert('Please enter metal weight');
            return false;
        }
        else if (isNaN(document.getElementById("<%=txtWeight.ClientID %>").value)) {
            alert('Please enter metal weight in correct format.');
            return false;
        }
        else if (document.getElementById("<%=txtWidth.ClientID %>").value.trim() == "") {
            alert('Please enter metal width');
            return false;
        }
        else if (isNaN(document.getElementById("<%=txtWidth.ClientID %>").value)) {
            alert('Please enter metal width in correct format.');
            return false;
        }


        else {
            var objGridView = document.getElementById('<%=dgvMetalType.ClientID%>');
            var rows_count = objGridView.rows.length;
            var isavailable = false;
            var isdefault = false;

            for (var i = 1; i < rows_count; i++) {
                var metal_control = objGridView.rows[i].getElementsByTagName("input");
                var control_chk = metal_control[1];
                var control_radio = metal_control[2];
                if (control_chk.checked == true) {
                    isavailable = true;
                    if (control_radio.checked == true) {
                        isdefault = true;
                    }
                }

            }
            if (isavailable == true && isdefault == true) {
                return true;
            }
            else {
                alert('Please select available metal  and default metal');
                return false;
            }
        }
    }

</script>

<div id="contentHeader">
    <h1>Product Metal (<asp:Label ID="lblSku" runat="server"></asp:Label>)</h1>
</div>
<div class="container">
        <div class="grid-24"> 
      <asp:Label ID="lblMessage" runat="server" CssClass="small_error"></asp:Label>
        <table class="table table-bordered table-striped" style="width:100%">
    
        <tbody>
       
        <tr><td>Metal Weight (g.m.)<span class="small_error">*</span></td><td>
            <asp:TextBox ID="txtWeight" runat="server" Width="50px"></asp:TextBox> (g.m.)
           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ValidationGroup="validateMetal"  Display="Dynamic"   ForeColor="Red"
                    ErrorMessage="*" CssClass="small_error" ControlToValidate="txtWeight"></asp:RequiredFieldValidator>

                   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtWeight" ValidationGroup="validateMetal"
         runat="server" ErrorMessage="Please Check Values !!!" Display="Dynamic" ForeColor="Red"    ValidationExpression="^[+-]?(?:\d+\.?\d*|\d*\.?\d+)[\r\n]*$"></asp:RegularExpressionValidator>--%>
            </td></tr>
        <tr><td>Metal Width (m.m.)<span Class="small_error">*</span></td><td>
            <asp:TextBox ID="txtWidth" runat="server" Width="50px"></asp:TextBox> (m.m.)
            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"  ForeColor="Red"
                    ErrorMessage="*" CssClass="small_error" ControlToValidate="txtWidth"></asp:RequiredFieldValidator>

                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtWidth" ValidationGroup="validateMetal"
         runat="server" ErrorMessage="Please Check Values !!!" Display="Dynamic"  ForeColor="Red"   ValidationExpression="^[+-]?(?:\d+\.?\d*|\d*\.?\d+)[\r\n]*$"></asp:RegularExpressionValidator>--%>
            </td></tr>
        <tr><td colspan="2" valign="top">
       <asp:GridView ID="dgvMetalType" runat="server" AutoGenerateColumns="False" 
        Width="100%" 
        onrowdatabound="dgvMetalType_RowDataBound" 
                CssClass="table table-bordered table-striped" GridLines="None" 
                CellPadding="0" >
            <Columns>
                <asp:TemplateField HeaderText="Sl.">
                <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                    <asp:HiddenField ID="hdnMetalTypeID" runat="server" Value='<%# Eval("MetalTypeId") %>' />
                 </ItemTemplate>
                 </asp:TemplateField>
                <asp:TemplateField HeaderText="Select Avialabilty(Choose Multiple)">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkAvialableMetal" runat="server" ValidationGroup="validateMetal" />

                      

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="MetalTypeName" HeaderText="Metal Type" />
                <asp:TemplateField HeaderText="Default(Select One)">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdoDefault" runat="server" GroupName="DefaultMetal"    />
                            




                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
    </asp:GridView>
            </td></tr>
         <tr>
			<td colspan="2">
                <asp:Button ID="btnAction" runat="server" Text="Save Product Metal" 
                    onclick="btnAction_Click" CssClass="btn btn-green"  OnClientClick="return Validate_Metal_Selection()" />&nbsp;
                    <asp:HyperLink ID="lnkCenterStone" runat="server" CssClass="btn btn-info" >Center Stone »</asp:HyperLink>                   
                   <input type="button" value="« Back To Product" style="float:right;" class="btn btn-error" onclick="location.href='/Product/ProductList.aspx'" />
                    
                    </td>
		</tr>
        </tbody>
        </table>
        </div>
        </div>
        </asp:Content>