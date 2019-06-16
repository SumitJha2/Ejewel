<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PriceManagement.aspx.cs" Inherits="EJewel.AdminView.Master.Setting.PriceManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
     var PAGE_NAME = '';
     var qs = querystring("view");
     if (qs.length > 0) {
         PAGE_NAME = qs[0];
     }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="span12">                    
                        <div class="head clearfix">
                            <div class="isw-grid"></div>
                            <h1 id="headingText">
                                <asp:Literal ID="ltrlHeading" runat="server"></asp:Literal>
                            </h1>      
                        </div>
                        <div class="block-fluid">
         <table border="0" cellpadding="0" cellspacing="0" class="table">
         <tr>
         <td>Sub Category</td>
         <td>
         <input type="hidden" id="txtID" value="0" />
             <asp:DropDownList ID="ddlSubCategory" runat="server">
             </asp:DropDownList>
             <asp:HiddenField ID="hdnID" Value="0" runat="server" />
         </td>
         </tr>
         <tr>
         <td>Price</td>
         <td>
             <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
         </td>
         </tr>
         <tr>
         <td>Status</td>
         <td>
         <asp:DropDownList ID="ddlStatus" runat="server">
         </asp:DropDownList>         
         </td>
         </tr>
          <tr>
			<th colspan="2">
                <input id="btnSave" type="button" value="Save" onclick="btnSave_onclick()" /></th>
		</tr>
         </table>
         </div>
         </div>
    <script language="javascript" type="text/javascript">
<!--

        function btnSave_onclick() {
            if (sure("Do You want to save...?")) {
                try {
                    var hdnID = parseInt($("#<%= hdnID.ClientID  %>").val());
                    var categoryID = parseInt($("#<%= ddlSubCategory.ClientID %>").val());
                    var price = parseFloat($("#<%= txtPrice.ClientID %>").val());
                    var status = parseInt($("#<%= ddlStatus.ClientID  %>").val()) == 1 ? true : false;
                    //validation
                    var model = new PriceModel(hdnID, categoryID, price, status);
                    //
                    EJewel.AdminView.Services.AdminServices.SaveUpdate_Setting_Setter_Price(model, PAGE_NAME,
             function (successResult) {
                 if (hdnID == 0) {
                     alert('Price Details  Save Successfully');
                     document.getElementById("form1").reset();
                 }
                 else {
                     alert('Price Details  Update Successfully');
                 }
             },
                  onServiceError
                   );
                }
                catch (e) {
                    alert(e);
                }
            }
        }
        //error
        function onServiceError(result) {
            alert(result._message);
        }
        //model
        function PriceModel(_PriceId, _SubCategoryId, _Price, _Status) {
            this.AutoID = _PriceId;
            this.SubCategoryId = _SubCategoryId;
            this.Price = _Price;
            this.Status = _Status;
        }

// -->
    </script>
</asp:Content>
