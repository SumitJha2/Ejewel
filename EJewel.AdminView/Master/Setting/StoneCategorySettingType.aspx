<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="StoneCategorySettingType.aspx.cs" Inherits="EJewel.AdminView.Master.Setting.CategorySettingType" %>
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

    <script src="/assets/themes/admin/javascripts/globalscript.js" type="text/javascript"></script>
    <script src="/assets/themes/admin/javascripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function validate() {
            $("#spnMessage").css("color", "red");
            if (document.getElementById("<%=ddlStoneCategoryType.ClientID%>").selectedIndex == 0) {
                $("#spnMessage").text("Please select stone category type.");
                return false;
            }
            else if (document.getElementById("<%=ddlSettingType.ClientID%>").selectedIndex == 0) {
                $("#spnMessage").text("Please select setting type.");
                return false;
            }
            else if ($("#<%=txtPrice.ClientID %>").val().trim() == "") {
                $("#spnMessage").text("Please enter price.");
                return false;
            }
            else if (isNaN($("#<%=txtPrice.ClientID %>").val())) {
                $("#spnMessage").text("Please enter price in correct format.");
                return false;
            }
            else {
                return true;

            }
        }


        function btnSave_onclick() {
            if (validate()) {
                if (sure("Do you want to save...?")) {
                    try {
                        //access the control of the page 
                        var id = parseInt($("#<%= hdnID.ClientID  %>").val());
                        var stoneCategoryTypeID = parseInt($("#<%= ddlStoneCategoryType.ClientID  %>").val());
                        var settinTypeID = parseInt($("#<%= ddlSettingType.ClientID  %>").val());
                        var Price = parseFloat($("#<%= txtPrice.ClientID  %>").val());
                        var status = parseInt($("#<%= ddlStatus.ClientID  %>").val()) == 1 ? true : false;
                        //create model  
                        var model = { StoneCategorySettingTypeId: id, StoneCategoryTypeId: stoneCategoryTypeID, SettingTypeId: settinTypeID, Price: Price, Status: status };

                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "/Services/AdminServices.asmx/SaveUpdateStoneCategorySettingType",
                            data: "{model:" + JSON.stringify(model) + "}",
                            dataType: "json",
                            success: function (successData) {
                                $("#spnMessage").css("color", "green");
                                $("#spnMessage").html(successData.d);
                                if (id == 0) {
                                    document.getElementById("form1").reset();
                                }
                            },
                            error: function (result) {
                                var msg = JSON.parse(result.responseText);
                                $("#spnMessage").text(msg.Message);
                            }
                        });
                    }
                    catch (e) {
                        alert(e);
                    }
                }
            } //for validation block
        }                
    </script>
    
</head>
<body>
<form id="form1" runat="server">
         <table class="table table-bordered table-striped" style="width:100%">
         <thead>
         <tr><th colspan="2">Stone Category Setting</th></tr>
         </thead>
         <tbody>
         <tr><td colspan="2"><span class="small_success" id="spnMessage"></span></td></tr>

         <tr>
         <td>Category Type<span class="small_error">&nbsp;*</span></td>
         <td>
         <input type="hidden" id="txtID" value="0" />
             <asp:DropDownList ID="ddlStoneCategoryType" runat="server" CssClass="common_width">
             </asp:DropDownList>
             <asp:HiddenField ID="hdnID" Value="0" runat="server" />
         </td>
         </tr>
         <tr>
         <td>Setting Type<span class="small_error">&nbsp;*</span></td>
         <td>
             <asp:DropDownList ID="ddlSettingType" runat="server" CssClass="common_width">
             </asp:DropDownList>
         </td>
         </tr>
          <tr>
         <td>Price (per stone)<span class="small_error">&nbsp;*</span></td>
         <td>
           <asp:TextBox ID="txtPrice" runat="server" CssClass="common_width"></asp:TextBox>
         </td>
         </tr>
         <tr>
         <td>Status</td>
         <td>
         <asp:DropDownList ID="ddlStatus" runat="server" CssClass="common_width">
         </asp:DropDownList>         
         </td>
         </tr>
          <tr>
			<td colspan="2">
                <input id="btnSave" type="button" value="Save" onclick="return btnSave_onclick()" class="btn btn-small" /> </td>
		</tr>
        </tbody>
         </table>
         </form>
         </body>
         </html>
             
