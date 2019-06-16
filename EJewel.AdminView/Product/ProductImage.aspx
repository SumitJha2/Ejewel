<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ProductImage.aspx.cs" Inherits="EJewel.AdminView.Product.ProductImage" %>
<html>
<head  runat="server">
    <title>Product Image</title>
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
    <p>
        <br />
    </p>
<form id="form1" runat="server" autocomplete="off">
        <table class="table table-bordered table-striped" style="width:100%">
        <thead>
        <tr><th align="center" style="text-align:center;">Image Management<br /><asp:Literal ID="ltrlHeading" runat="server"></asp:Literal></th></tr>
        </thead>
        <!--Content-->
        <tbody>
        <tr>
        <td>
        <table class="table table-bordered table-striped" align="center" style="width:600px;">
        <tbody>
        <tr>
        <td>Total No. Of Angles</td>
        <td>
            <asp:DropDownList ID="ddlAngle" runat="server">
            </asp:DropDownList>
&nbsp;<asp:Button ID="btnGenerate" runat="server" CssClass="btn btn-small" 
                onclick="btnGenerate_Click" Text="&lt;&lt; Generate Image &gt;&gt;" />
            </td>
        </tr>
        <tr>
        <td>Total Image Type Generated</td>
        <td><%= _totalImage %></td>
        </tr>
        <tr>
        <td>Export Data</td><td><asp:Button ID="btnExport" runat="server" Text="Export" CssClass="btn btn-small" onclick="btnExport_Click" /></td>
        </tr>
         <tr>
        <td>Import Data</td>
        <td>
<asp:FileUpload ID="fleImport" runat="server" />
<asp:Button ID="btnImport" runat="server" Text="Import" 
                CssClass="btn btn-small" onclick="btnImport_Click" OnClientClick="return sure('Are you sure...?')" />
        </td>
        </tr>
        <tr>
        <td colspan="2">
        <asp:Label ID="lblMessage" runat="server" CssClass="small_success"></asp:Label>
                </td>
        </tr>
        </tbody>
        </table>
                </td>
        </tr>
        <tr>
        <!--Image Name--->
        <td>
        <div style="width:100%">
            <asp:GridView ID="gridViewImages" runat="server" CellPadding="0" 
                GridLines="None" Width="100%" AutoGenerateColumns="False" 
                ShowHeaderWhenEmpty="True" CssClass="table table-bordered table-striped" 
                onrowdatabound="gridViewImages_RowDataBound" Font-Size="14px">
                <Columns>
                    <asp:TemplateField HeaderText="Sl.">
                    <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="GUID" HeaderText="GUID" />
                    <asp:BoundField DataField="ImageName" HeaderText="ImageName" />
                    <asp:BoundField DataField="ImageAlt" HeaderText="Alt" />
                    <asp:BoundField DataField="Angle" HeaderText="Angle" />
                    <asp:TemplateField HeaderText="Path">
                        <ItemTemplate>
                            <asp:TextBox ID="txtPath" runat="server" Width="250px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="View">
                    <ItemTemplate>
                        <asp:Image ID="imgView" runat="server" Width="50px" Height="50px" />
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <a href="javascript:void(0)"><img src="/assets/themes/admin/images/icon/save_16.png" alt="Edit" /></a> &nbsp;
                            <a href="javascript:void(0)"><img src="/assets/themes/admin/images/icon/delete_16.png" alt="Delete" /></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
        </td>
        </tr>
        </tbody>
        </table>
</form>
<script type="text/javascript">
    $(document).ready(function () {
        $("img.lazy").lazyload({ effect: "fadeIn" });
    });
</script>
</body>
</html>