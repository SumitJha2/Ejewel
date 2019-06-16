<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="Sfm.aspx.cs" Inherits="EJewel.AdminView.Common.Sfm.Sfm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
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
    <script src="/assets/themes/admin/javascripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="/assets/themes/admin/javascripts/globalscript.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        //for save mode
        function btnSave_Click() {
            try {
                if (sure("Are you sure...?")) {
                        var id = parseInt(get_control_value("<%=hdnID.ClientID %>"));
                        var name =get_control_value("<%=txtName.ClientID %>").trim();
                        var status = parseInt(get_control_value("<%=ddlstatus.ClientID %>")) == 1 ? true : false;
                        if (name != '') {
                            //create model
                            var model = { AutoID: id, Name: name, Status: status };
                            //calling service method
                            $.ajax({
                                type: "POST",
                                async: true,
                                contentType: "application/json; charset=utf-8",
                                url: "/Services/AdminServices.asmx/SaveUpdateSfm",
                                data: "{model:" + JSON.stringify(model) + ",pagename:" + JSON.stringify("<%= _view %>") + "}",
                                dataType: "json",
                                success: function (successData) {
                                    $("#spnMessage").html(successData.d);
                                    $("#spnMessage").css("color", "green");
                                    if (id == 0) {
                                        document.getElementById("form1").reset();
                                    }
                                },
                                error: function (result) {
                                    var error = JSON.parse(result.responseText);
                                    $("#spnMessage").css("color", "red");
                                    $("#spnMessage").html(error.Message);
                                }
                            });
                            //end of calling service method-->
                        }
                        else {
                            $("#spnMessage").css("color", "red");
                            $("#spnMessage").html('Required field can not left blank');
                        }
                }
            }
            catch (e) {
                alert(e);
            }
        }

         </script>
</head>
<body>
<form id="form1" runat="server" autocomplete="off">
    <table class="table table-bordered table-striped" style="width:100%">
         <thead>
         <tr><th colspan="2">
             <asp:Literal ID="ltrlHeading" runat="server"></asp:Literal></th></tr>
         </thead>
         <tbody>
         <tr><td colspan="2"> &nbsp;<span id="spnMessage"></span>   </td></tr>

         <tr>
         <td>Name<span class="small_error">&nbsp;*</span></td>
         <td>
         <asp:TextBox ID="txtName" runat="server" CssClass="common_width"></asp:TextBox>
             <asp:HiddenField ID="hdnID" runat="server" Value="0" />
         </td>
         </tr>
         <tr>
         <td>Status</td>
         <td>
            <asp:DropDownList ID="ddlstatus" runat="server"  CssClass="common_width"></asp:DropDownList>         
         </td>
         </tr>
          <tr>
			<td colspan="2">
                <input type="button" id="btnSave" class="btn btn-small" value="Save" onclick="btnSave_Click()"/>&nbsp;
                <input type="button" id="btnClose" class="btn btn-small" value="Close" onclick="refresh_parent()"/>
                
            </td>
		</tr>
        </tbody>
         </table>
         </form>
         <script type="text/javascript">
             function refresh_parent() {
                 window.opener.load_data(0);
                 window.close();
             }
         </script>
</body>
</html>
