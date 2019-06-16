<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="EJewel.View._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>


    <p>
    
    
    </p>
    <script type="text/javascript">

        var objUserEntity = new UserEntity("1001", "Linku", "Mumbai");
        EJewel.View.AdminService.SaveUser(objUserEntity,SaveUserSuccess,OnError);

        function UserEntity(code, name, address) {        
        this.Code=code;
        this.Name=name;
        this.Address = address;
    }
    function SaveUserSuccess(result) {
      alert(result.ID);
    }

    function OnError(result) {
    }
    </script>
</asp:Content>
