<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="RingSizeManagement.aspx.cs" Inherits="EJewel.AdminView.Master.Setting.RingSizeManagement" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1"  runat="server">
    <title>Single Field Management</title>
    <style type="text/css">
        @import url(http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,600);
        body { font: 12px/1.7em "Open Sans", "trebuchet ms", arial, sans-serif; color: #444; }
    </style>
    <!--CSS-->
     <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/form.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/message.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/table.css" type="text/css" />
    <!--Script-->

    <script src="/assets/themes/admin/javascripts/globalscript.js" type="text/javascript"></script>
    <script src="/assets/themes/admin/javascripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
<!--

        function btnSave_onclick() {
            if (sure("Do You want to save...?")) {
                try {
                    var hdnID = parseInt($("#<%= hdnID.ClientID  %>").val());
                    var categoryID = parseInt($("#<%= ddlSubCategory.ClientID %>").val());
                    var size = parseFloat($("#<%= txtSize.ClientID %>").val());
                    var status = parseInt($("#<%= ddlStatus.ClientID  %>").val()) == 1 ? true : false;
                    //
                    //create model
                    var model = { RingSizeId: hdnID, SubCategoryId: categoryID,RingSize:size,Status: status };
                    //calling service method
                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/SaveUpdateRingSize",
                        data: "{model:" + JSON.stringify(model) + "}",
                        dataType: "json",
                        success: function (successData) {
                            $("#spnMessage").html(successData.d);
                            $("#spnMessage").css("color", "green");
                            if (hdnID == 0) {
                                document.getElementById("form1").reset();
                            }
                        },
                        error: function (result) {
                            var error = JSON.parse(result.responseText);
                            $("#spnMessage").css("color", "red");
                            $("#spnMessage").html(error.Message);
                        }
                    });
                }
                catch (e) {
                    alert(e);
                }
            }
        }

    // -->
    </script>
    
</head>
<body>
<form id="form1" runat="server">
         <table class="table table-bordered table-striped" style="width:100%">
         <thead>
         <tr><th colspan="2">Ring Size</th></tr>
         </thead>
         <tbody>
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
         <td>Ring Size</td>
         <td>
             <asp:TextBox ID="txtSize" runat="server"></asp:TextBox>
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
			<td colspan="2">
            <input id="btnSave" type="button" value="Save" onclick="btnSave_onclick()" class="btn btn-small" />
            &nbsp; <span id="spnMessage"></span>
            </td>
		</tr>
        </tbody>
         </table>
    
</form>
</body>
</html>