<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SfmList.aspx.cs" Inherits="EJewel.AdminView.Common.Sfm.SfmList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="contentHeader">
    <h1><asp:Literal ID="ltrlHeading" runat="server"></asp:Literal></h1>
</div>
<div class="container">
        <div class="grid-24">
        <div style="float:right">
        <a href="javascript:void(0)" onclick = "popupwindow('/Common/Sfm/Sfm.aspx?view=<%= _view %>', 500,300)"  title="" class="btn btn-small">Create New</a>&nbsp;
        </div>
        <br /> 
        <br />
        <table class="table table-bordered table-striped" style="width:100%">
        <thead>
        <tr>
            <th>Sl.</th>
            <th>Name</th>
            <th>Status</th>
            <th>Edit</th>
            <th>Delete</th>
        </tr>
        </thead>
        <tbody id="tblSfm">
        </tbody>
        </table>
        <!--Pagination-->
       <%-- <div class="pagination" id="pagination" style="float:right"></div>--%>
          <div id="Pagination" style="float:right;" class="pagination"></div>
        </div>
        </div>
        <!--Load data-->
        <script type="text/javascript">
            var total_record=<%= _totalRecord %>;
            var per_page_value =10;
            var current_page_index = 0;
               var FIRST_TIME_LOAD = true;
            $(document).ready(function () {
                load_data(current_page_index);
            });
            //load data
            function load_data(arg_current_page_index) {
                show_message_popup('Please wait...', 'message_loading');
                //clear rows
                $("#tblSfm").empty();
                //load the data
                try {
                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/GetSfmList",
                        data: "{view_name:" + JSON.stringify("<%= _view %>") + ",currentPageIndex:" + arg_current_page_index + ",perPageSize:" + per_page_value + "}",
                        dataType: "json",
                        success: function (successData) {
                            //for serial no
                            var counter = (arg_current_page_index*per_page_value);
                            $.each(successData.d, function (key, value) {
                                counter++;
                                //create tr
                                var row = create_row();
                                create_cell(row, counter, [['align', 'center']]);
                                create_cell(row, value.Name);
                                create_cell(row, value.Status ? 'Enabled' : 'Disabled');
                               create_cell(row, '<a href="javascript:void(0)" onclick="popupwindow(\'/Common/Sfm/Sfm.aspx?view=<%= _view %>&id=' + value.AutoID + '\',500,300)"><img src="/assets/themes/admin/images/icon/edit_16.png" /></a>', [['align', 'center']]);
                               create_cell(row, "<a href='javascript:void(0)' onclick='DeleteSingleField("+value.AutoID+")'><img src='/assets/themes/admin/images/icon/delete_16.png' /></a>", [['align', 'center']]);
                                add_row('tblSfm', row);
                            });
                            hide_message_popup();
                            if(counter>0)
                            {
//                                 //increate current page index
//                                 current_page_index=arg_current_page_index;
//                                //show pagination
//                                create_pagination('pagination',total_record,arg_current_page_index,per_page_value,5,load_data);
                                if (FIRST_TIME_LOAD == true) {
                                    $("#Pagination").pagination(total_record, getPagingOption());
                                    FIRST_TIME_LOAD = false;
                                }
                            }
                            else{
                                var row = create_row();
                                create_cell(row, '<span class="small_error">No record found.</span>',[['colspan','5'],['align','center']]);
                                add_row('tblSfm', row);
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
            function DeleteSingleField(sfmid)
            {
            if(confirm('Are you sure you want to delete this record.'))
            {
             $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/DeleteSfm",                     
                        data:JSON.stringify({id:sfmid,view:"<%=_view%>"}),                                       
                        dataType: "json",
                        success: function (successData)
                         {
                        alert('Field deleted successfully.');
                        load_data(current_page_index);
                        },
                       error: function (errorData) 
                       {   
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
        FIRST_TIME_LOAD=false;
        load_data(page_index);
    }



         </script>
</asp:Content>
