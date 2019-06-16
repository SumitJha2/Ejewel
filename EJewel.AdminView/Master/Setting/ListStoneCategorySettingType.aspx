<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListStoneCategorySettingType.aspx.cs" Inherits="EJewel.AdminView.Master.Setting.ListCategorySettingType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="contentHeader">
    <h1>Stone Category Setting</h1>
</div>
<div class="container">
        <div class="grid-24">
        <div style="float:right">
            <a href="javascript:void(0)" onclick = "popupwindow('/Master/Setting/StoneCategorySettingType.aspx', 800,500)"  title="" class="thickbox btn btn-small">Create New</a>
        </div>
        <br />
        <br />
        <table class="table table-bordered table-striped" style="width:100%">
        <thead>
        <tr>
            <th>Sl.</th>
            <th>Stone Category</th>
            <th>Setting Type</th>
            <th>Price</th>
            <th>Status</th>
            <th>Edit</th>
            <th>Delete</th>
        </tr>
        </thead>
        <tbody id="tblStoneCategory">
        </tbody>
        </table>
        </div>
        </div>
         <!--Load data-->

        <script type="text/javascript">
            var total_record=<%= _totalRecord %>;
            var per_page_value =10;
            var current_page_index = 0;
            $(document).ready(function () {
                load_data(current_page_index);
            });
            //load data
            function load_data(arg_current_page_index) {
                show_message_popup('Please wait...', 'message_loading');
                //clear rows
                $("#tblStoneCategory").empty();
                //load the data
                try {
                    $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/StoneSettingTypeList",
                        data: "{stoneCategorySettingTypeId:0}",
                        dataType: "json",
                        success: function (successData) {
                            //for serial no
                            var counter = (arg_current_page_index*per_page_value);
                            $.each(successData.d, function (key, value) {
                                counter++;
                                //create tr
                                var row = create_row();
                                create_cell(row, counter, [['align', 'center']]);
                                create_cell(row, value.StoneCategoryTypeName);
                                create_cell(row, value.SettingTypeName);
                                create_cell(row, value.Price);
                                create_cell(row, value.Status ? 'Enabled' : 'Disabled');
                               create_cell(row, '<a href="javascript:void(0)" onclick="popupwindow(\'/Master/Setting/StoneCategorySettingType.aspx?id=' + value.StoneCategorySettingTypeId + '\',800,500)"><img src="/assets/themes/admin/images/icon/edit_16.png" /></a>', [['align', 'center']]);
                                create_cell(row, "<a href='javascript:void(0)' onclick='DeleteCategorySettingType("+value.StoneCategorySettingTypeId+")'><img src='/assets/themes/admin/images/icon/delete_16.png' /></a>", [['align', 'center']]);
                                add_row('tblStoneCategory', row);
                            });
                            hide_message_popup();
                            if(counter>0)
                            {
                                 //increate current page index
                                 current_page_index=arg_current_page_index;
                                //show pagination
                                create_pagination('pagination',total_record,arg_current_page_index,per_page_value,5,load_data);
                            }
                            else{
                                var row = create_row();
                                create_cell(row, '<span class="small_error">No record found.</span>',[['colspan','7'],['align','center']]);
                                add_row('tblStoneCategory', row);
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
            //delete
           function DeleteCategorySettingType(categorysettingtypeid)
            {
            if(confirm('Are you sure you want to delete this record')){
             $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/DeleteStoneSettingType",                     
                       data:JSON.stringify({stonecategorysettingtypeid:categorysettingtypeid}),                                       
                        dataType: "json",
                        success: function (successData) {
                        alert('setting type deleted successfully.');
                        TB_close();
                        },
                       error: function (errorData) {   
                       }
                       });  
                       }    

            }
         </script>
</asp:Content>
