<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListZipCode.aspx.cs" Inherits="EJewel.AdminView.Master.Location.ListZipCode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="contentHeader">
    <h1>Zip Code</h1>
</div>
<div class="container">
        <div class="grid-24">
        <div style="float:right">
         <a href="javascript:void(0)" onclick = "popupwindow('/Master/Location/ManageZipCode.aspx', 900,500)"  title="" class="thickbox btn btn-small">Create New</a>
        </div>
        <br />
        <br />
        <table class="table table-bordered table-striped" style="width:100%">
        <thead>
        <tr>
            <th>Sl.</th>
            <th>Country</th>
            <th>ZipCode </th>
            <th>ZipCodeToolTip</th>
             <th>ZipCodeRegularExp</th>
          
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
                        url: "/Services/AdminServices.asmx/GetZipCodeList",
                        data: "{ringSizeId:0}",
                        dataType: "json",
                        success: function (successData) {
                            var counter = 0;
                            $.each(successData.d, function (key, value) {
                                counter++;
                                //create tr
                                var row = create_row();
                                create_cell(row, counter, [['align', 'center']]);
                                create_cell(row, value.CountryName);
                                create_cell(row, value.ZipCode);
                                create_cell(row, value.ZipCodeToolTip);
                                create_cell(row, value.ZipCodeRegularExp);



                                create_cell(row, value.Status ? 'Enabled' : 'Disabled');

                                create_cell(row, '<a href="javascript:void(0)" onclick="popupwindow(\'/Master/Location/ManageZipCode.aspx?ZipCodeID=' + value.ZipCodeID + '\',800,500)"><img src="/assets/themes/admin/images/icon/edit_16.png" /></a>', [['align', 'center']]);

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
