<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCity.aspx.cs" Inherits="EJewel.AdminView.Master.Location.ManageCity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> City </title>

    <style type="text/css">
        body { font: 12px/1.7em "Open Sans", "trebuchet ms", arial, sans-serif; color: #444; }
    </style>
    <!--CSS-->
     <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/form.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/message.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/table.css" type="text/css" />


     <script src="/assets/themes/admin/javascripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="/assets/themes/admin/javascripts/globalscript.js" type="text/javascript"></script>
    <script src="/assets/webcontrols/fileupload/ajaxupload.3.5.js" type="text/javascript"></script>


</head>
<body>
    <form id="form1" runat="server">
    <div>
    

    <table class="table table-bordered table-striped" style="width:100%">
<thead>
 <tr><th colspan="5">
             City</th></tr>
         </thead>         
         <tbody>
         <tr><td>Country</td><td><asp:DropDownList ID="ddlCountry" runat="server" 
                 CssClass="common_width" AutoPostBack="True" 
                 onselectedindexchanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList></td></tr>
         <tr><td></td><td></td></tr>
<tr><td>State</td><td><asp:DropDownList ID="ddlState" runat="server" CssClass="common_width"></asp:DropDownList></td></tr>
<tr><td></td><td></td></tr>
<tr><td>City Name</td><td><asp:TextBox ID="txtCityName" runat="server" CssClass="common_width"></asp:TextBox></td></tr>
<tr><td></td><td></td></tr>
<tr><td>City Code</td><td><asp:TextBox ID="txtCityCode" runat="server" CssClass="common_width"></asp:TextBox></td></tr>
<tr><td></td><td></td></tr>
<tr><td>Status</td><td><asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal">
<asp:ListItem Text="Active" Value="True" Selected="True"></asp:ListItem>
<asp:ListItem Text="InActive" Value="False"></asp:ListItem>
</asp:RadioButtonList></td></tr>
<tr><td></td><td></td></tr>
<tr><td></td><td><input type="button" id="btnSubmit" value="Save" class="btn btn-small" onclick="btnSubmit_onclick()" />&nbsp;<span id="spnMessage"></span>		</td></tr>
</tbody>
</table>
<asp:HiddenField ID="hdnID" runat="server" Value="0" />
<script type="text/javascript">

    function validate() {
        $("#spnMessage").css("color", "red");
        if (document.getElementById("<%=ddlCountry.ClientID %>").selectedIndex == 0) {
            $("#spnMessage").html('Please select Country .');
            return false;
        }
        else if (document.getElementById("<%=ddlState.ClientID %>").selectedIndex == 0) {
            $("#spnMessage").html('Please select State .');
            return false;
        }
        else if (document.getElementById("<%=txtCityName.ClientID %>").value == "") {
            $("#spnMessage").html('Please enter City Name.');
            return false;
        }

        else if (document.getElementById("<%=txtCityCode.ClientID %>").value == "") {
            $("#spnMessage").html('Please enter City Code.');
            return false;
        }

       
        else {
            return true;
        }

    }




    function btnSubmit_onclick() {
        if (validate()) {
            if (confirm("Do you Save...?")) {

                try {

                    var id = parseInt($("#<%=hdnID.ClientID %>").val());

                    var CountryID = ($("#<%=ddlCountry.ClientID %>").val());

                    var StateID = ($("#<%=ddlState.ClientID %>").val());

                    var CityName = ($("#<%=txtCityName.ClientID %>").val());
                    var CityCode = ($("#<%=txtCityCode.ClientID %>").val());
                    var CreatedBy = "1";
                    var status = ($('#<%=rblStatus.ClientID %> input[type=radio]:checked').val());
                    var today = new Date();
                    var dd = today.getDate();
                    var mm = today.getMonth() + 1;
                    var yyyy = today.getFullYear();
                    if (dd < 10) { dd = '0' + dd } if (mm < 10) { mm = '0' + mm } today = mm + '/' + dd + '/' + yyyy;



                    var model = { CityId: id, CountryId: CountryID, StateId: StateID, CityName: CityName, CityCode: CityCode, CreatedDate: today, CreatedBy: CreatedBy, Status: status };
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/SaveUpdateCity",
                        data: JSON.stringify({ model: model }),
                        dataType: "json",
                        success: function (data) {
                            $("#spnMessage").html(data.d);
                            $("#spnMessage").css("color", "green");
                            if (id == 0) 
                            {
                                $("#spnmsg").html(data.d);
                                document.getElementById('<%=txtCityName.ClientID %>').value = "";
                                document.getElementById('<%=txtCityCode.ClientID %>').value = "";
                                document.getElementById('<%=rblStatus.ClientID %>').value = "True";
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
</script>


    </div>
    </form>
</body>
</html>
