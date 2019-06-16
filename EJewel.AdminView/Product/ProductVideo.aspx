<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductVideo.aspx.cs" Inherits="EJewel.AdminView.Product.ProductVideo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Video</title>
    <style type="text/css">
        body { font: 12px/1.7em "Open Sans", "trebuchet ms", arial, sans-serif; color: #444; }
    </style>
    <!--CSS-->
     <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/form.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/message.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/table.css" type="text/css" />
    <!--Script-->
    <script src="/assets/themes/admin/javascripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="/assets/themes/admin/javascripts/globalscript.js" type="text/javascript"></script>
    <script src="/assets/webcontrols/jquery.lazyload.js" type="text/javascript"></script>
    <style type="text/css">
        img
        {
            border:0px;
            cursor:pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="lblMessage" runat="server" CssClass="small_success"></asp:Label>
 <table class="table table-bordered table-striped" style="width:100%">
        <thead>
        <tr><th align="center" style="text-align:center;">Video Management<br /><asp:Literal ID="ltrlHeading" runat="server"></asp:Literal></th></tr>
        </thead>
        <!--Content-->
        <tbody>
        <tr>
        <td>
            <asp:GridView ID="grdVideo" runat="server" Width="100%" GridLines="None"  AutoGenerateColumns="False" 
                ShowHeaderWhenEmpty="True" CssClass="table table-bordered table-striped" 
               Font-Size="14px" onrowdatabound="grdVideo_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Sl.">
                    <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                        <asp:HiddenField ID="hdnShape" runat="server" 
                            Value='<%# Eval("StoneShapeId") %>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Shape" HeaderText="Center Stone Shape" />
                    <asp:TemplateField HeaderText="Video URL">
                        <ItemTemplate>
                            <asp:TextBox ID="txtVideoURL" runat="server"></asp:TextBox>
                            &nbsp;<asp:HyperLink ID="lnkPlay" NavigateUrl="javascript:void(0)" runat="server" CssClass="btn btn-small">Play</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Video Image Path">
                        <ItemTemplate>
                            <asp:TextBox ID="txtImage" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
        </tr>
        <tr>
        <td>
            <asp:Button ID="btnSave" runat="server" Text="Save Video" 
                CssClass="btn btn-green" onclick="btnSave_Click" OnClientClick="return sure('Are you sure...?')" />&nbsp;
            <input id="btnClose" type="button" value="Close" class="btn btn-error" onclick="window.close();" /></td>
        </tr>
        </tbody>
        </table>
    </form>
</body>
</html>
