<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductReview.aspx.cs" Inherits="EJewel.UserView.ProductReview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <script language="javascript" type="text/javascript">
          function validate() {
               if (document.getElementById("<%=txtRating.ClientID %>").value != "") {
                  if (isNaN(document.getElementById("<%=txtRating.ClientID %>").value)) {
                      alert('Please enter rating in correct format.');
                      return false;
                  }
              }
              return true;
          }
    </script>


</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="table table-bordered table-striped" style="width:100%">
        <thead>
        <tr><th colspan="3">
            <asp:Literal ID="ltrlHeading" runat="server">Manage Product Review</asp:Literal></th></tr>
        </thead>
        <tbody>
        <tr><td colspan="2"> <span id="spnMessage" style="color:Red;" runat="server"></span></td></tr>	

        <tr>
			<td>Review Heading<span class="small_error"></span></td>
			<td>               
                <asp:TextBox ID="txtHeading" runat="server" CssClass="common_width"></asp:TextBox>              
            </td>
		</tr>
        <tr>
			<td>Review Description<span class="small_error"></span></td>
			<td>               
                <asp:TextBox ID="txtDescription" runat="server" CssClass="common_width" TextMode="MultiLine"></asp:TextBox>              
            </td>
		</tr>
         <tr>
		<td>Customer Name<span class="small_error"></span></td>
		<td>	
		<asp:TextBox ID="txtName" runat="server" CssClass="common_width"></asp:TextBox>
		</td>
        </tr>
         <tr>
		<td>Rating<span class="small_error"></span></td>
		<td>	
		<asp:TextBox ID="txtRating" runat="server" CssClass="common_width"></asp:TextBox>
		</td>
        </tr>
        <tr>
		<td>E-mail<span class="small_error"></span></td>
		<td>	
		<asp:TextBox ID="txtEmail" runat="server" CssClass="common_width"></asp:TextBox>
		</td>
        </tr>
	<tr>
		<td colspan="2">
			
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="return validate()" class="btn btn-small" 
                onclick="btnSave_Click" />
           
            </td>
		</tr>
    </tbody>
	</table>
    </div>
    </form>
</body>
</html>
