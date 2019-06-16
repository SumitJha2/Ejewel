<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageSideStone.aspx.cs" Inherits="EJewel.AdminView.Master.Stone.ManageSideStone" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Stone</title>
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
    </script>
</head>
<body>
    <form id="form1" runat="server">    
        <table class="table table-bordered table-striped" style="width:100%">
        <thead>
         <tr><th colspan="5">
             Manage Side Stone</th></tr>
         </thead>         
         <tbody>
         <tr>
         <td colspan="5">
          &nbsp;<span id="spnMessage"></span>
         </td>
         </tr>


         <tr>
			<td>Stone Category<span class="small_error">&nbsp;*</span></td>
			<td>
                <asp:HiddenField ID="hdnID" runat="server" Value="0" />
         <asp:DropDownList ID="ddlStoneCategory" runat="server" CssClass="common_width"></asp:DropDownList>                  
            </td>


			<td>&nbsp;</td>
			<td>Cut<span class="small_error">&nbsp;*</span></td>
			<td><asp:DropDownList ID="ddlCut" runat="server" CssClass="common_width"></asp:DropDownList>            
             </td>
		</tr>	
        <tr>
			<td>Color<span class="small_error">&nbsp;*</span></td>
			<td>           
             <asp:DropDownList ID="ddlColor" runat="server" CssClass="common_width"></asp:DropDownList>             
            </td>
			<td>           
                &nbsp;</td>
			<td>           
                Clarity<span class="small_error">&nbsp;*</span></td>
			<td>           
             <asp:DropDownList ID="ddlClarity" runat="server" CssClass="common_width"></asp:DropDownList>             
            </td>
		</tr>
        <tr>
			<td>Shape<span class="small_error">&nbsp;*</span></td>
			<td>
            <asp:DropDownList ID="ddlShape" runat="server" CssClass="common_width"></asp:DropDownList>            
            </td>
			<td>
                &nbsp;</td>
			<td>
                Type</td>
			<td>
            <asp:DropDownList ID="ddlType" runat="server" CssClass="common_width"></asp:DropDownList>            
            </td>
		</tr>
        <tr>
			<td>Carate<span class="small_error">&nbsp;*</span></td>
			<td>
            <asp:TextBox ID="txtCarate" runat="server" CssClass="common_width"></asp:TextBox>            
            </td>
			<td>
                &nbsp;</td>
			<td>
                Price<span class="small_error">&nbsp;*</span></td>
			<td>
            <asp:TextBox ID="txtPrice" runat="server" CssClass="common_width"></asp:TextBox>           
            </td>
		</tr>
        <tr>
			<td> Status</td>
			<td>
           <asp:DropDownList ID="ddlStatus" runat="server"  CssClass="common_width">  
              </asp:DropDownList> 
            </td>
		
		</tr>            
        <tr>
			<td colspan="5">
<input id="btnSave" type="button" value="Save" onclick="btnSave_onclick()" class="btn btn-small" />
            
               </td>
		</tr>
        <tr>
        <td colspan="5" style="vertical-align:top;"> </td>
        </tr>
    </tbody>
        </table>
    </form>
    <script type="text/javascript">
        function loadStoneDetails(value) {
            //load cut
            fill_dropdown_data(value, 'cut', "<%= ddlCut.ClientID %>");
            //load color
            fill_dropdown_data(value, 'color', "<%= ddlColor.ClientID %>");
            //load clarity
            fill_dropdown_data(value, 'clarity', "<%= ddlClarity.ClientID %>");
            //load shape
            fill_dropdown_data(value, 'shape', "<%= ddlShape.ClientID %>");
            //load type
            fill_dropdown_data(value, 'type', "<%= ddlType.ClientID %>");
        }
        function fill_dropdown_data(catgeory_id, view_name, drop_down_id) {
            //
            try {
                $("#" + drop_down_id).empty();
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/Services/AdminServices.asmx/GetStoneSpecificationListFromCategory",
                    data: JSON.stringify({ categoryID: catgeory_id, pageName: view_name }),
                    dataType: "json",
                    success: function (successResult) {
                        $("#" + drop_down_id).append('<option value="">--Select--</option>');
                        $.each(successResult.d, function (key, val) {
                            fillDropDown(drop_down_id, val.AutoID, val.Name);
                        });
                    },
                    error: function (data) {
                    }
                });
            }
            catch (e) {
                alert(e);
            }
        }
        // function for validation
        function validate() {
            $("#spnMessage").css("color", "red");           
            if (document.getElementById("<%=ddlStoneCategory.ClientID %>").selectedIndex == 0) {
                $("#spnMessage").html('Please select category.');
                return false;
            }
            else if (document.getElementById("<%=ddlCut.ClientID %>").selectedIndex == 0) {
                $("#spnMessage").html('Please select cut.');
                return false;
            }
            else if (document.getElementById("<%=ddlColor.ClientID %>").selectedIndex == 0) {
                $("#spnMessage").html('Please select color.');
                return false;
            }
            else if (document.getElementById("<%=ddlClarity.ClientID %>").selectedIndex == 0) {
                $("#spnMessage").html('Please select clarity.');
                return false;
            }
            else if (document.getElementById("<%=ddlShape.ClientID %>").selectedIndex == 0) {
                $("#spnMessage").html('Please select shape.');
                return false;
            }
            else if (document.getElementById("<%=txtCarate.ClientID %>").value.trim() == "") {
                $("#spnMessage").html('Please enter carate.');
                return false;
            }
            else if (isNaN(document.getElementById("<%=txtCarate.ClientID %>").value)) {
                $("#spnMessage").html('Enter carate in correct format.');
                return false;
            }
            else if (document.getElementById("<%=txtPrice.ClientID %>").value.trim() == "") {
                $("#spnMessage").html('Please enter price.');
                return false;
            }
            else if (isNaN(document.getElementById("<%=txtPrice.ClientID %>").value)) {
                $("#spnMessage").html('Enter price in correct format.');
                return false;
            }
            else {
                return true;
            }
        }

        //save the details of the save
        function btnSave_onclick() {
            try {
                if (sure("Do you want to save...?")) {
                    if (validate()) {
                        var id = parseInt($("#<%= hdnID.ClientID %>").val());                    
                        var stoneCategoryId = parseInt($("#<%= ddlStoneCategory.ClientID %>").val());                    
                        var cut = parseInt($("#<%= ddlCut.ClientID %>").val());
                        var color = parseInt($("#<%= ddlColor.ClientID %>").val());
                        var clarity = parseInt($("#<%= ddlClarity.ClientID %>").val());
                        var shape = parseInt($("#<%= ddlShape.ClientID %>").val());
                        var type = parseInt($("#<%= ddlType.ClientID %>").val());
                        type = isNaN(type) ? 0 : type;
                        var carate = parseFloat($("#<%= txtCarate.ClientID %>").val());
                        var price = parseFloat($("#<%= txtPrice.ClientID %>").val());
                        var status = parseInt($("#<%= ddlStatus.ClientID %>").val()) == 1 ? true : false;
                        var model = { SideStoneId: id, StoneCategoryId: stoneCategoryId, StoneCutId: cut, StoneColorId: color, StoneClarityId: clarity, StoneShapeId: shape, StoneTypeId: type, StoneCarate: carate, StonePrice: price, Status: status };
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "/Services/AdminServices.asmx/SaveUpdateStone",
                            data: JSON.stringify({ model: model }),
                            dataType: "json",
                            success: function (data) {
                                $("#spnMessage").html(data.d);
                                $("#spnMessage").css("color", "green");
                                if (id == 0) {
                                    $("#spnmsg").html(data.d);
                                    document.getElementById('<%=txtCarate.ClientID %>').value = "";
                                    document.getElementById('<%=txtPrice.ClientID %>').value = "";
                                }

                            },
                            error: function (result) {
                                var error = JSON.parse(result.responseText);
                                $("#spnMessage").css("color", "red");
                                $("#spnMessage").html(error.Message);
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
</body>
</html>