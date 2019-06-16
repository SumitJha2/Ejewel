<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageStoneShape.aspx.cs" Inherits="EJewel.AdminView.Master.Stone.ManageStoneShape" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <script language="javascript" type="text/javascript">

      
        function validate() {
            $("#spnMessage").css("color", "red");
            if (document.getElementById("<%=ddlShape.ClientID %>").selectedIndex == 0) {
                $("#spnMessage").text('Please select shape.');
                return false;
            }
            else if (document.getElementById("<%=ddlStoneCategory.ClientID %>").selectedIndex == 0) {
                $("#spnMessage").text('Please select category.'); 
                return false;
            }
            else {
                return true;
            }
        }
        function btnSave_onclick() {
            try {
                if (sure('Do you want to save...?')) {
                    if (validate()) {
                    
                        //access the controls 
                        var id = parseInt(get_control_value("<%= hdnID.ClientID  %>"));
                        var stone_category_id = parseInt(get_control_value("<%= ddlStoneCategory.ClientID  %>"));
                        var shape_id = get_control_value("<%= ddlShape.ClientID  %>");
                        var status = parseInt(get_control_value("<%= ddlStatus.ClientID  %>")) == 1 ? true : false;
                        var visiable = parseInt(get_control_value("<%= ddlVisiable.ClientID  %>"));
                        var visiable_centerstonestone = null;
                        var visiable_sidestone = null;
                        if (visiable == 0) {
                            visiable_centerstonestone = true;
                            visiable_sidestone = true;
                        }
                        else if (visiable == 1) {
                            visiable_centerstonestone = true;
                            visiable_sidestone = false;
                        }
                        else {
                            visiable_centerstonestone = false;
                            visiable_sidestone = true;
                        }



                        //create model
                        //do the save opeartion
                        var shape_model = { StoneShapeId: id, StoneCategoryId: stone_category_id, ShapeId: shape_id, Status: status, CenterStoneVisible: visiable_centerstonestone, SideStoneVisible: visiable_sidestone};
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "/Services/AdminServices.asmx/SaveUpdateStoneShape",
                            data: JSON.stringify({ model:shape_model }),
                            dataType: "json",
                            success: function (successResult) {
                                $("#spnMessage").html(successResult.d);
                                $("#spnMessage").css("color", "green");
                                if (id == 0) {
                                    document.getElementById("form1").reset();
                                }
                            },
                            error: function (errorResult) {
                            }
                        });
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
        <tr><th colspan="3">
            <asp:Literal ID="ltrlHeading" runat="server"></asp:Literal></th></tr>
        </thead>
        <tbody>
        <tr><td colspan="2"> <span id="spnMessage"></span></td></tr>
        <tr>
			<td>Shape<span class="small_error">&nbsp;*</span></td>
			<td>              
                <asp:DropDownList ID="ddlShape" runat="server" CssClass="common_width">
                </asp:DropDownList>
            </td>
		</tr>
		<tr>
			<td>Stone Category<span class="small_error">&nbsp;*</span></td>
			<td>
                <asp:HiddenField ID="hdnID" runat="server" Value="0" />
                <asp:DropDownList ID="ddlStoneCategory" runat="server" CssClass="common_width">
                </asp:DropDownList>
            </td>
		</tr>
        <tr>
        <td>Visiable<span class="small_error">&nbsp;*</span></td>
			<td>              
                <asp:DropDownList ID="ddlVisiable" runat="server" CssClass="common_width">
                <asp:ListItem Text="Both" Value="0"></asp:ListItem>
                <asp:ListItem Text="CenterStone" Value="1"></asp:ListItem>
                <asp:ListItem Text="SideStone" Value="2"></asp:ListItem>
                </asp:DropDownList>
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
			<input type="button" name="btnSave" id="btnSave" value="Save" class="btn btn-small"  onclick="btnSave_onclick()" />&nbsp;
           
            </td>
		</tr>
    </tbody>
	</table>
    </form>
</body>
</html>
