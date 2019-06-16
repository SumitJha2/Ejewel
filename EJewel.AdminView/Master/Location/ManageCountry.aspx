<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCountry.aspx.cs" Inherits="EJewel.AdminView.Master.Location.ManageCountry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Country </title>

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
             Country</th></tr>
         </thead>         
         <tbody>
<tr><td >Name</td><td><asp:TextBox ID="txtCountryName" runat="server" CssClass="common_width"></asp:TextBox></td></tr>
<tr><td></td><td></td></tr>
<tr><td>Code</td><td><asp:TextBox ID="txtCountryCode" runat="server" CssClass="common_width"></asp:TextBox></td></tr>
<tr><td></td><td></td></tr>
<tr><td>State Display Name</td><td><asp:TextBox ID="txtStateDisplayName" runat="server" CssClass="common_width"></asp:TextBox></td></tr>
<tr><td></td><td></td></tr>
<tr><td>Multiple State</td><td><asp:RadioButtonList ID="rblMultipleState" runat="server" RepeatDirection="Horizontal" CssClass="common_width">
<asp:ListItem Text="Yes" Value="True"></asp:ListItem>
<asp:ListItem Text="No" Value="False" Selected="True"></asp:ListItem>
</asp:RadioButtonList></td></tr>
<tr><td></td><td></td></tr>

<tr><td>Postal Code Name</td><td><asp:TextBox ID="txtPostalCodeName" runat="server" CssClass="common_width"></asp:TextBox></td></tr>
<tr><td></td><td></td></tr>

<tr><td>Postal Code Required</td><td><asp:RadioButtonList ID="rblPostalCodeRequired" runat="server" RepeatDirection="Horizontal" CssClass="common_width">
<asp:ListItem Text="Yes" Value="True"></asp:ListItem>
<asp:ListItem Text="No" Value="False" Selected="True"></asp:ListItem>
</asp:RadioButtonList></td></tr>
<tr><td></td><td></td></tr>

<tr><td>StateUs</td><td><asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal" CssClass="common_width">
<asp:ListItem Text="Active" Value="True" Selected="True"></asp:ListItem>
<asp:ListItem Text="InActive" Value="False"></asp:ListItem>
</asp:RadioButtonList></td></tr>
<tr><td></td><td><input type="button" id="btnSubmit" value="Save" class="btn btn-small"   onclick="btnSubmit_onclick()" />&nbsp;<span id="spnMessage"></span>		</td></tr>
 </tbody>
</table>
<asp:HiddenField ID="hdnID" runat="server" Value="0" />
<script type="text/javascript">

    function validate()
     {
        $("#spnMessage").css("color", "red");
       
        if (document.getElementById("<%=txtCountryName.ClientID %>").value == "")
         {
            $("#spnMessage").html('Please enter Country Name.');
            return false;
        }
     
        else if (document.getElementById("<%=txtStateDisplayName.ClientID %>").value == "") {
            $("#spnMessage").html('Please enter State Display Name.');
            return false;
        }

        else if (document.getElementById("<%=txtPostalCodeName.ClientID %>").value == "") {
            $("#spnMessage").html('Please enter Postalcode Name.');
            return false;
        }
        else 
        {
            return true;
        }

    }
    function btnSubmit_onclick() {

        if (validate())
         {
             if (confirm("Do you Save...?")) 
            {

                try {


                    var id = parseInt($("#<%=hdnID.ClientID %>").val());
                    var CountryCode = ($("#<%=txtCountryCode.ClientID %>").val());
                    var CountryName = ($("#<%=txtCountryName.ClientID %>").val());
                    var PostalCodeName = ($("#<%=txtPostalCodeName.ClientID %>").val());
                    var StateDisplayName = ($("#<%=txtStateDisplayName.ClientID %>").val());
                    var MultipleState = ($('#<%=rblMultipleState.ClientID %> input[type=radio]:checked').val());
                    var PostalCodeRequired = ($('#<%=rblPostalCodeRequired.ClientID %> input[type=radio]:checked').val());
                    var CreatedBy = "1";
                    var status = ($('#<%=rblStatus.ClientID %> input[type=radio]:checked').val());
                    var today = new Date();
                    var dd = today.getDate();
                    var mm = today.getMonth() + 1;

                    var yyyy = today.getFullYear();
                    if (dd < 10) { dd = '0' + dd } if (mm < 10) { mm = '0' + mm } today = mm + '/' + dd + '/' + yyyy;



                    var model = { CountryID: id, CountryCode: CountryCode, CountryName: CountryName, PostalCodeDisplayName: PostalCodeName, StateDisplayName: StateDisplayName, HasMultipleState: MultipleState, IsPostalCodeRequired: PostalCodeRequired, CreatedDate: today, CreatedBy: CreatedBy, Status: status };
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/SaveUpdateCountry",
                        data: JSON.stringify({ model: model }),
                        dataType: "json",
                        success: function (data) {
                            $("#spnMessage").html(data.d);
                            $("#spnMessage").css("color", "green");
                            if (id == 0)
                             {
                                $("#spnmsg").html(data.d);
                                document.getElementById('<%=txtCountryCode.ClientID %>').value = "";
                                document.getElementById('<%=txtCountryName.ClientID %>').value = "";
                                document.getElementById('<%=txtPostalCodeName.ClientID %>').value = "";
                                document.getElementById('<%=txtStateDisplayName.ClientID %>').value = "";
                                document.getElementById('<%=rblMultipleState.ClientID %>').value = "True";
                                document.getElementById('<%=rblPostalCodeRequired.ClientID %>').value = "True";
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
                catch (e) 
                {
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
