<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageResize.aspx.cs" Inherits="EJewel.UserView.ImageResize" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtSize" runat="server"></asp:TextBox>
        <asp:Button ID="btnResize" runat="server" onclick="btnResize_Click" 
            Text="Resize" />
        <asp:Image ID="Image1" runat="server" ImageUrl="/Handler/ImageResizer.ashx?height=200" />
    
    </div>
    </form>
</body>
</html>
