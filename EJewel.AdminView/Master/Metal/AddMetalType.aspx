<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="AddMetalType.aspx.cs" Inherits="EJewel.AdminView.Master.Metal.AddMetalType" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title>Single Field Management</title>
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
    <script src="/assets/webcontrols/fileupload/ajaxupload.3.5.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
       
                <input type="hidden" id="hdnFile" value="" />
       
<table class="table table-bordered table-striped" style="width:100%">
<tr><td colspan="2"><span id="spnMessage"></span></td></tr>
<tr><td>Metal Weight<span class="small_error">&nbsp;*</span></td><td>
    <asp:HiddenField ID="hdnID" runat="server" Value="0" />
    <asp:DropDownList ID="ddlMetalWeight" runat="server" CssClass="common_width">
    </asp:DropDownList>
    </td></tr>
<tr><td>Metal Name<span class="small_error">&nbsp;*</span></td><td>
    <asp:DropDownList ID="ddlMetalName" runat="server" CssClass="common_width">
    </asp:DropDownList>
    </td></tr>
<tr><td>Price per g.m.<span class="small_error">&nbsp;*</span></td><td>
    <asp:TextBox ID="txtPrice" runat="server" CssClass="common_width"></asp:TextBox>
    </td></tr>
<tr><td>Status</td><td>
    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="common_width">
    </asp:DropDownList>
    </td></tr>
<tr>
<td colspan="2">
			<input id="btnSave" type="button" value="Save" onclick="btnSave_onclick()" class="btn btn-smalll" />
           
            </td>
</tr>
</table>
  <div class="pagination" id="pagination" style="float:right"></div>
<script type="text/javascript">
<!--
    function validate() {
        $("#spnMessage").css("color", "red");

        if (document.getElementById("<%=ddlMetalWeight.ClientID %>").selectedIndex ==0) {
            $("#spnMessage").html('Please select metal weight.');
            return false;
        }
        else if (document.getElementById("<%=ddlMetalName.ClientID %>").selectedIndex == 0) {
            $("#spnMessage").html('Please select metal name.');
            return false;
        }

        else if (document.getElementById("<%=txtPrice.ClientID %>").value== "") {
            $("#spnMessage").html('Please enter price.');
            return false;
        }
        else if (isNaN(document.getElementById("<%=txtPrice.ClientID %>").value)) {
            $("#spnMessage").html('Please enter price in numeric format.');
            return false;
        }      
        else {
            return true;
        }

    }

    function btnSave_onclick() {
        if (validate()) {
        if (confirm("Do you Save...?")) {            
                try {
                    //details
                    var id = parseInt($("#<%=hdnID.ClientID %>").val());
                    var metal_weight_id = parseInt($("#<%=ddlMetalWeight.ClientID %>").val());
                    var metal_name_id = parseInt($("#<%=ddlMetalName.ClientID %>").val());
                    var price = parseFloat($("#<%=txtPrice.ClientID %>").val());
                    var status = parseInt($("#<%=ddlStatus.ClientID %>").val()) == 1 ? true : false;
                    //validation checking
                    var model = { MetalTypeId: id, MetalNameId: metal_name_id, MetalWeightId: metal_weight_id, Price: price, Status: status };
                    //save the category details
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/SaveUpdateMetalType",
                        data: "{model:" + JSON.stringify(model) + "}",
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

                }
                catch (e) {
                    alert(e);
                }
            }
        }
    }     


    // -->
</script>
</form>
</body>
</html>
