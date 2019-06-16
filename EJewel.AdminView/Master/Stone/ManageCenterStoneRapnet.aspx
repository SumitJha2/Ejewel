<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCenterStoneRapnet.aspx.cs" Inherits="EJewel.AdminView.Master.Stone.ManageCenterStoneRapnet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rapnet Diamond Generation</title>
    <style type="text/css">
        h1
        {
            color:Green;
        }
    </style>
    <script type="text/javascript">
        function save() {
            if (confirm('Are you sure...?')) {
                //var btn = document.getElementById("<%= btnGenerate.ClientID %>");
                //btn.setAttribute("disabled", "disabled");
                //btn.value = "Please wait...";
                return true;
            }
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <asp:Button ID="btnGenerate" runat="server" Text="Generate Rapnet Diamonds" 
            onclick="btnGenerate_Click" OnClientClick="return save()" /><br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
