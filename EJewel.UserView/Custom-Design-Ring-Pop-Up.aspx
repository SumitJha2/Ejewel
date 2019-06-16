<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Custom-Design-Ring-Pop-Up.aspx.cs" Inherits="EJewel.UserView.Custom_Design_Ring_Pop_Up" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<style type="text/css">
.validation_cls
{
	color:Red;
}
.width_cls
{
	width:250px;
}


</style>

    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td>
    <table>
    <tr><td><b>Diamond Information</b></td></tr>
    <tr>
    <td>Diamond Item</td>
    <td><asp:TextBox ID="txtDiamondInformation" CssClass="width_cls" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Side stones (# of stones, weight, width etc.)</td>
    <td><asp:TextBox ID="txtSideStone" CssClass="width_cls" runat="server"></asp:TextBox></td>
    </tr>
    <tr><td height="40px"></td></tr>
    <tr><td>
    Metal Type
    </td>
    <td><asp:DropDownList ID="ddlMetalType" CssClass="width_cls" runat="server"></asp:DropDownList></td>
    </tr>
     <tr><td>
    Ring Size
    </td>
    <td><asp:DropDownList ID="ddlRingSize" CssClass="width_cls" runat="server"></asp:DropDownList></td>
    </tr>
    <tr><td>
    Budget (not including center diamond)
    </td>
    <td><asp:TextBox ID="txtBudget" runat="server" CssClass="width_cls" ></asp:TextBox><asp:RegularExpressionValidator ID="reg1" runat="server" 
                                    ControlToValidate="txtBudget" CssClass="validation_cls" ErrorMessage="*"  Display="Dynamic"
                                    ValidationExpression="^[ #-]*([0-9]*){0,12}$"></asp:RegularExpressionValidator></td>
    </tr>

     <tr><td>
   Links to design I like
    </td>
    <td><asp:TextBox ID="txtLike" CssClass="width_cls" runat="server"></asp:TextBox></td>
    </tr>
     <tr><td>
   Comments
    </td>
    <td><asp:TextBox ID="txtComments" CssClass="width_cls" runat="server" TextMode="MultiLine"></asp:TextBox></td>
    </tr>

     <tr><td>
   Choose File
    </td>
    <td><asp:FileUpload ID="fdFileUpload" CssClass="width_cls" runat="server" /></td>
    </tr>

    </table>
    
    </td>


    <td>
    <table>
    <tr><td><b>Contact Details</b></td></tr>
    <tr>
    <td>Full Name</td>
    <td><asp:TextBox ID="txtFullName" runat="server" CssClass="width_cls"></asp:TextBox>
    <asp:RequiredFieldValidator  ID="RequiredFieldValidator2"  Display="Dynamic" runat="server" ErrorMessage="*" ControlToValidate="txtFullName" CssClass="validation_cls"></asp:RequiredFieldValidator>
    </td>
    </tr>
     <tr>
    <td>Email</td>
    <td><asp:TextBox ID="txtEmail" runat="server" CssClass="width_cls"></asp:TextBox><asp:RequiredFieldValidator
            ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"  Display="Dynamic" ControlToValidate="txtEmail" CssClass="validation_cls"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
            CssClass="validation_cls" ControlToValidate="txtEmail"  Display="Dynamic"
            runat="server" ErrorMessage="*" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
    </tr>
     <tr>
    <td>Phone</td>
    <td><asp:TextBox ID="txtPhone" runat="server" CssClass="width_cls"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  Display="Dynamic" ErrorMessage="*" ControlToValidate="txtPhone" CssClass="validation_cls"></asp:RequiredFieldValidator>
    
    </td>
    </tr>
   <tr>
    <td>Best time to call</td>
    <td><asp:DropDownList ID="ddlBestTimeToCall" CssClass="width_cls" runat="server">
    <asp:ListItem Text="Not Sure"></asp:ListItem>
    <asp:ListItem Text="Two weeks or less"></asp:ListItem>
    <asp:ListItem Text="One Month or less"></asp:ListItem>
    <asp:ListItem Text="More than a month"></asp:ListItem>
    </asp:DropDownList>    
    </td>
    </tr>

    <tr><td height="50px"></td></tr>
    <tr><td colspan="2">What's next?<br />
    Our designers will contact you as soon as we
have processed your request.
    </td></tr>
   

    
    </table>
        <asp:Button ID="btnSave" runat="server" Text="Send" onclick="btnSave_Click" />
        <asp:Label ID="lblMessage" runat="server" CssClass="validation_cls"></asp:Label>
    </td>

    </tr>
    
    </table>


    </div>
    </form>
</body>
</html>
