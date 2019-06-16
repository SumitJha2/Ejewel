<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductCenterStone.aspx.cs" Inherits="EJewel.AdminView.Product.ProductCenterStone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    function Validate_CenterStoneSection_Selection() {
        if (document.getElementById("<%=txtMinCarat.ClientID %>").value.trim() == "") {
            alert('Please enter min carat.');
            return false;
        }
        else if (isNaN(document.getElementById("<%=txtMinCarat.ClientID %>").value)) {
            alert('Please enter min carat in correct format.');
            return false;
        }
        else if (document.getElementById("<%=txtMaxCarat.ClientID %>").value.trim() == "") {
            alert('Please enter max carat.');
            return false;
        }
        else if (isNaN(document.getElementById("<%=txtMaxCarat.ClientID %>").value)) {
            alert('Please enter max carat in correct format.');
            return false;
        }
        else if (document.getElementById("<%=ddlSettingType.ClientID %>").selectedIndex == 0) {
            alert('Please select setting type.');
            return false;
        }
        else {
            var objGridView = document.getElementById('<%=gridShape.ClientID%>');
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
                alert('Please select available  and default shape.');
                return false;
            }
        }

    }
    function Validate_defaultCenter_stone() {
        var objGridView = document.getElementById('<%=gridStone.ClientID%>');
        var rows_count = objGridView.rows.length;

        var isdefault = false;

        for (var i = 1; i < rows_count; i++) {
            var metal_control = objGridView.rows[i].getElementsByTagName("input");


            var control_radio = metal_control[1];
            if (control_radio.checked == true) {
                isdefault = true;
            }

        }
        if (isdefault == true) {
            return true;
        }
        else {
            alert('Please choose default stone.');
            return false;
        }
    }



</script>

    <div id="contentHeader">
    <h1>Product (<asp:Label ID="lblSKU" runat="server"></asp:Label>)</h1>
</div>
<div class="container">
        <div class="grid-24">
        <asp:Label  ID="lblMessage" runat="server" CssClass="small_error"></asp:Label>
<table class="table table-bordered table-striped" style="width:100%">
        <tr><td>
        <table class="table table-bordered table-striped" style="width:100%">
        <tbody>
        <tr><td>Stone Category Type</td><td>Diamond</td></tr>
        <tr><td>Min. &amp; Max. Carat Range</td><td>
            <asp:TextBox ID="txtMinCarat" runat="server">0.00</asp:TextBox>
            &nbsp;-
            <asp:TextBox ID="txtMaxCarat" runat="server">0.00</asp:TextBox>
            </td></tr>
        <tr><td>Setting Type</td><td>
            <asp:DropDownList ID="ddlSettingType" runat="server">
            </asp:DropDownList>
            </td></tr>
        <tr><td>Shape</td><td><asp:GridView ID="gridShape" runat="server" AutoGenerateColumns="False" 
                                CssClass="table table-bordered table-striped" GridLines="None" 
                                ShowHeaderWhenEmpty="True" 
                onrowdatabound="gridShape_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sl.">
                                    <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                        <asp:HiddenField ID="hdnShapeId" runat="server" Value='<%# Eval("StoneShapeId") %>' />
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Available">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkAvailable" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Shape" DataField="Shape" />
                                    <asp:TemplateField HeaderText="Default">
                                        <ItemTemplate>
                                            <asp:RadioButton ID="rdoDefaultShape" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView></td></tr>
        <tr><td colspan="2">
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-green" 
                onclick="btnSave_Click" Text="Save Center Stone" 
               OnClientClick="return Validate_CenterStoneSection_Selection()" />
               <input type="button" value="« Back To Product" style="float:right;" class="btn btn-error" onclick="location.href='/Product/ProductList.aspx'" />
            </td></tr>
        </tbody>
        </table>
        </td></tr>
        <tr><td>
            Default Stone <span style="float:right">
                <asp:Button ID="btnSaveStone" runat="server" Text="Save Default Stone" 
                CssClass="btn btn-green" onclick="btnSaveStone_Click" OnClientClick="return Validate_defaultCenter_stone()" /></span></td></tr>
        <tr><td>
        <asp:GridView ID="gridStone" runat="server" AutoGenerateColumns="False" 
                CellPadding="0" CssClass="table table-bordered table-striped" GridLines="None" 
                ShowHeaderWhenEmpty="True" Width="100%" 
                onrowdatabound="gridStone_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Choose">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnStoneId" runat="server" Value='<%# Eval("StoneId") %>' />
                            <asp:RadioButton ID="rdoDefault" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SKU" HeaderText="SKU" />
                    <asp:BoundField DataField="StoneShape" HeaderText="Shape" />
                    <asp:BoundField DataField="StoneColor" HeaderText="Color" />
                    <asp:BoundField DataField="StoneClarity" HeaderText="Clarity" />
                    <asp:BoundField DataField="StoneCut" HeaderText="Cut" />
                    <asp:BoundField DataField="StoneCarate" HeaderText="Carat" />
                    <asp:BoundField DataField="StonePrice" HeaderText="Price" />
                </Columns>
            </asp:GridView>
        </td></tr>
        <tr><td>
            <asp:HyperLink ID="lnkSideStone" runat="server" CssClass="btn btn-info">Side Stone »</asp:HyperLink>
            </td></tr>
         </table>
                 </div>
        </div>
</asp:Content>