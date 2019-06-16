<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListMetalType.aspx.cs" Inherits="EJewel.AdminView.Master.Metal.ListMetalType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="contentHeader">
    <h1>Metal Type</h1>
</div>
<div class="container">
        <div class="grid-24">
        <div style="float:right">
            <a href="javascript:void(0)" onclick = "popupwindow('/Master/Metal/AddMetalType.aspx', 800,500)"  title="" class="thickbox btn btn-small">Create New</a>
        </div>
        <br />
        <br />
        <table class="table table-bordered table-striped" style="width:100%">
        <thead>
        <tr>
            <th>Sl.</th>
            <th>Metal Weight</th>
            <th>Metal Name</th>
            <th>Price</th>
       
            <th>Status</th>
            <th>Edit</th>
            <th>Delete</th>
        </tr>
        </thead>
        <tbody id="tblMetalType">
        </tbody>
        </table>
        </div>
        </div>
        <!--Load data-->
        <script type="text/javascript">
            $(document).ready(function () {
                load_data();
            });
            function load_data() {
                $("#tblMetalType").empty();
                //load the data
                try {
                    $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/GetMetalTypeList",
                        data: "",
                        dataType: "json",
                        success: function (successData) {
                            var counter = 0;
                            $.each(successData.d, function (key, value) {
                                counter++;
                                //create tr
                                var row = create_row();
                                create_cell(row, counter, [['align', 'center']]);
                                create_cell(row, value.MetalWeight);
                                create_cell(row, value.MetalName);
                                create_cell(row, value.MetalPrice);
                               
                                create_cell(row, value.Status ? 'Enabled' : 'Disabled');
                                create_cell(row, '<a href="javascript:void(0)" onclick="popupwindow(\'/Master/Metal/AddMetalType.aspx?id=' + value.MetalTypeId + '\',800,500)"><img src="/assets/themes/admin/images/icon/edit_16.png" /></a>', [['align', 'center']]);
                                create_cell(row, "<a href='javascript:void(0)' onclick='DeleteMetalType(" + value.MetalTypeId + ")'><img src='/assets/themes/admin/images/icon/delete_16.png' /></a>", [['align', 'center']]);
                                add_row('tblMetalType', row);
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
            }
            function TB_close() {
                load_data();
            }
          


            function DeleteMetalType(metaltyupeid) {
                if (confirm('Are you sure you want to delete this record')) {
                    $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/DeleteMetalType",
                        data: JSON.stringify({ metalTypeId: metaltyupeid }),
                        dataType: "json",
                        success: function (successData) {
                            TB_close();
                        },
                        error: function (errorData) {
                            alert('Unable to delete record ,Please try again later.');
                        }
                    });
                }

            }
        </script>
</asp:Content>
