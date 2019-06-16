<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListStoneShape.aspx.cs" Inherits="EJewel.AdminView.Master.Stone.ListStoneShape" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="contentHeader">
    <h1><asp:Literal ID="ltrlHeading" runat="server">Stone Shape</asp:Literal></h1>
</div>
<div class="container">
        <div class="grid-24">
        <div style="float:right">
        <a href="javascript:void(0)" onclick = "popupwindow('/Master/Stone/ManageStoneShape.aspx', 800,500)"  title="" class="btn btn-small">Create New</a>
        </div>
        <br /> 
        <br />
        <table class="table table-bordered table-striped" style="width:100%">
        <thead>
        <tr>
            <th>Sl.</th>
            <th>Shape</th>
            <th>Stone Category</th>
            <th>Center Stone Visiable</th> 
             <th>Side Stone Visiable</th>
            <th>Status</th>
            <th>Edit</th>
            <th>Delete</th>
        </tr>
        </thead>
        <tbody id="tblStoneShape">
        </tbody>
        </table>
        <!--Pagination-->
     <%--   <div class="pagination" id="pagination" style="float:right"></div>--%>
        <div id="Pagination" style="float:right;" class="pagination"></div>
        </div>
        </div>
        <!--Load data-->
        <script type="text/javascript">          
            var per_page_value =30;
            var current_page_index = 0;
            var total_record = "<%=TotalRecord %>";
            var FIRST_TIME_LOAD = true;
            $(document).ready(function () {
                load_data(current_page_index);
            });
            //load data
            function load_data(arg_current_page_index) {
                show_message_popup('Please wait...', 'message_loading');
                //clear rows
                $("#tblStoneShape").empty();
                //load the data
                try {
                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/GetStoneShapeList",
                        data: JSON.stringify({stoneShapeId: 0,currentPageIndex: arg_current_page_index, perPageSize: per_page_value }),
                        dataType: "json",
                        success: function (successData) {
                            //for serial no
                            var counter = (arg_current_page_index*per_page_value);
                            $.each(successData.d, function (key, value) {
                                counter++;
                                //create tr                
                                var row = create_row();
                                create_cell(row, counter, [['align', 'center']]);
                                create_cell(row, value.Shape);
                                create_cell(row, value.StoneCategoryName);
                                var cs = value.CenterStoneVisible == true ? "Yes" : "No";
                                var ss = value.SideStoneVisible == true ? "Yes" : "No";
                              
                             
                                create_cell(row, cs);
                                create_cell(row, ss);
                                create_cell(row, value.Status ? 'Enabled' : 'Disabled');
                              



                                create_cell(row, '<a href="javascript:void(0)" onclick="popupwindow(\'/Master/Stone/ManageStoneShape.aspx?id=' + value.StoneShapeId + '\',800,500)"><img src="/assets/themes/admin/images/icon/edit_16.png" /></a>', [['align', 'center']]);
                                create_cell(row, "<a href='javascript:void(0)' onclick='DeleteStoneShape(" + value.StoneShapeId + ")'><img src='/assets/themes/admin/images/icon/delete_16.png' /></a>", [['align', 'center']]);
                                add_row('tblStoneShape', row);
                            });
                            hide_message_popup();
                            if(counter>0)
                            {
                                if (FIRST_TIME_LOAD == true) {
                                    $("#Pagination").pagination(total_record, getPagingOption());
                                    FIRST_TIME_LOAD = false;
                                }
                            }
                            else{
                                var row = create_row();
                                create_cell(row, '<span class="small_error">No record found.</span>',[['colspan','8'],['align','center']]);
                                add_row('tblStoneShape', row);
                            }
                           
                        },
                        error: function (errorData) {
                            var result = JSON.parse(errorData.responseText);
                            show_message_popup(result.Message, 'message_error');
                        }
                    });
                }
                catch (e) {
                    alert(e);
                }
            }
            //fire when thick box close vent fire
            function TB_close() {
                load_data(current_page_index);
            }
             function DeleteStoneShape(stoneshapeid) {
                if (confirm('Are you sure you want to delete this record')) {
                    $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/DeleteStoneShape",
                        data: JSON.stringify({stoneShapeId:stoneshapeid}),
                        dataType: "json",
                        success: function (successData) {
                            alert('Shape deleted successfully.');
                            TB_close();
                        },
                        error: function (errorData) {
                        }
                    });
                }

            }

            //should be define
            function getPagingOption() {
                var opt = { callback: pagingCallback };
                opt['items_per_page'] = per_page_value;
                opt['num_display_entries'] = 5;
                opt['num_edge_entries'] = 2;
                return opt;
            }
            //paging call back
            function pagingCallback(page_index, jq) {
                // Get number of elements per pagionation page from form
                FIRST_TIME_LOAD = false;
                load_data(page_index);
            }



         </script>
</asp:Content>
