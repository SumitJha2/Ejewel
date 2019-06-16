<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SingleFieldManagement.aspx.cs" Inherits="EJewel.AdminView.Common.SingleField.SingleFieldManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" language="javascript">
var PAGE_NAME="";
var view=querystring('view');
if (view.length > 0) {
    PAGE_NAME = view[0];
    }
</script>
    <div class="span12">                    
                        <div class="head clearfix">
                            <div class="isw-grid"></div>
                            <h1 id="headingText">
                                <asp:Literal ID="ltrlHeading" runat="server"></asp:Literal></h1>      
                        </div>
                        <div class="block-fluid">
         <table border="0" cellpadding="0" cellspacing="0" class="table">
         <tr>
         <td>Name</td>
         <td>
             <asp:HiddenField ID="hdnID" runat="server" Value="0" />
         <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
         <br />
         <asp:Label ID="lblNameErrer" runat="server" CssClass="validate"></asp:Label>
         </td>
         </tr>
         <tr>
         <td>Status</td>
         <td>
         <asp:DropDownList ID="ddlstatus" runat="server">
         </asp:DropDownList>         
         </td>
         </tr>
          <tr>
			<th colspan="2">
            <input type="button" id="btnSave" value="Save" onclick="btnSave_Click()"/>     
            </th>
		</tr>
         </table>
         </div>
         </div>
         <script type="text/javascript" language="javascript">
             function validate() {                
                 if ($("#<%=txtName.ClientID %>").val().trim() == "")  
                 {
                  $("#<%=lblNameErrer.ClientID %>").text('Please enter name.');                    
                     return false;
                 }
                 else {
                     return true;
                 }
             }
             function btnSave_Click() {
                 try {
                     if (confirm('Are you sure you want to save ...')) {
                         if (validate()) {
                             var id = parseInt($("#<%=hdnID.ClientID %>").val());
                             var name = $("#<%=txtName.ClientID %>").val().trim();
                             var status = parseInt($("#<%=ddlstatus.ClientID %>").val()) == 1 ? true : false;
                             //create model
                             var model = new SingleFielModel(id, name, status);
                             //call services
                             EJewel.AdminView.Services.AdminServices.SaveUpdateSingleField(model, PAGE_NAME,
                    function (successResult) {
                        if (id == 0) {
                            alert('Data Saved Successfully');
                            document.getElementById("form1").reset();
                        }
                        else {
                            alert('Data Update Successfully');
                        }
                       

                    },
                  onServiceError
                   );
                         }
                     }
                 }
            catch (e) {
                alert(e);
                 }
        }
             //create object of the model
             function SingleFielModel(_AutoID,_Name, _Status) {
                 this.Name = _Name;
                 this.Status = _Status;
                 this.AutoID = _AutoID
             }

             function onServiceError(result) {
                 alert(result._message);
             }           

         </script>
</asp:Content>
