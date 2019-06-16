<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="StoneSpecificationManagement.aspx.cs" Inherits="EJewel.AdminView.Master.Stone.StoneSpecificationManagement" %>
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
    <script language="javascript" type="text/javascript">

        function validate() {
            $("#spnMessage").css("color","red");
        if (document.getElementById("<%=ddlStoneCategory.ClientID %>").selectedIndex == 0) {
            $("#spnMessage").text('Please select stone category.');
            return false;
        }
        else if (document.getElementById("<%=txtName.ClientID %>").value.trim() == "") {
            $("#spnMessage").text('Please enter name.');
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
                        var name = get_control_value("<%= txtName.ClientID  %>").trim();
                        var status = parseInt(get_control_value("<%= ddlStatus.ClientID  %>")) == 1 ? true : false;
                        var shortdescription = get_control_value("<%=txtShortDescription.ClientID  %>");
                        //create model
                        //do the save opeartion
                        var stone_model = { AutoID: id, StoneCategoryId: stone_category_id, Name: name, Status: status, ShortDescription: shortdescription};
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "/Services/AdminServices.asmx/SaveUpdateStoneSpecification",
                            data: JSON.stringify({ model: stone_model, view: "<%= _viewName %>" }),
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
			<td>Stone Category<span class="small_error">&nbsp;*</span></td>
			<td>
                <asp:HiddenField ID="hdnID" runat="server" Value="0" />
                <asp:DropDownList ID="ddlStoneCategory" runat="server" CssClass="common_width">
                </asp:DropDownList>
            </td>
		</tr>
         <tr>
		<td>Name<span class="small_error">&nbsp;*</span></td>
		<td>	
		<asp:TextBox ID="txtName" runat="server" CssClass="common_width"></asp:TextBox>
		</td>
        </tr>	
          <tr>
		<td>Short Description<span class="small_error"></span></td>
		<td>	
		<asp:TextBox ID="txtShortDescription" runat="server" CssClass="common_width" TextMode="MultiLine" Height="80px"></asp:TextBox>
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
