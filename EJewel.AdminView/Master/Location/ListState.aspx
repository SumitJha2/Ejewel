<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListState.aspx.cs" Inherits="EJewel.AdminView.Master.Location.ListState" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="contentHeader">
    <h1>State</h1>
</div>
<div class="container">
        <div class="grid-24">
        <div style="float:right">
         <a href="javascript:void(0)" onclick = "popupwindow('/Master/Location/ManageState.aspx', 800,500)"  title="" class="thickbox btn btn-small">Create New</a>
        </div>
        <br />
        <br />
        <table class="table table-bordered table-striped" style="width:100%">
        <thead>
        <tr>
            <th>Sl.</th>
            <th>Country</th>
            <th>State </th>
            <th>State Code</th>
            
            <th>Status</th>
            <th>Edit</th>
            <th>Delete</th>
        </tr>
        </thead>

        <tbody id="tblRingSize">
        </tbody>
        </table>
        </div>
        </div>
         <!--Load data-->


        <script type="text/javascript">
            $(document).ready(function () {
                //load the data
                try {
                    $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/GetStateList",
                        data: "{StateID:0}",
                        dataType: "json",
                        success: function (successData) {
                            var counter = 0;
                            $.each(successData.d, function (key, value) {
                                counter++;
                                //create tr
                                var row = create_row();
                                create_cell(row, counter, [['align', 'center']]);
                                create_cell(row, value.CountryName);
                                create_cell(row, value.StateName);
                                create_cell(row, value.StateCode);

                                create_cell(row, value.Status ? 'Enabled' : 'Disabled');

                                create_cell(row, '<a href="javascript:void(0)" onclick="popupwindow(\'/Master/Location/ManageState.aspx?StateID=' + value.StateId + '\',800,500)"><img src="/assets/themes/admin/images/icon/edit_16.png" /></a>', [['align', 'center']]);

                                create_cell(row, '<a href="#"><img src="/assets/themes/admin/images/icon/delete_16.png" /></a>', [['align', 'center']]);
                                add_row('tblRingSize', row);
                            });
                        },
                        error: function (errorData) {
                            var result = JSON.parse(errorData.responseText);
                            alert(result.Message);
                        }
                    });
                }
                catch (e) {
                    alert(e);
                }
            });
        </script>
</asp:Content>
