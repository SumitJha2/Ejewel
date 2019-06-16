<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListCategory.aspx.cs" Inherits="EJewel.AdminView.Master.Category.ListCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="contentHeader">
    <h1>Sub Category</h1>
</div>
<div class="container">
        <div class="grid-24">
        <div style="float:right">
            <a href="javascript:void(0)"  onclick = "popupwindow('/Master/Category/AddCategory.aspx', 800,500)" title="" class="thickbox btn btn-small">Create New</a>
        </div>
        <br /> 
        <br />
            
        <table class="table table-bordered table-striped" style="width:100%">
        <thead>
        <tr>
            <th>Sl.</th>
            <th>Sub Category</th>
            <th>Category</th>
            <th>Status</th>            
            <th>Edit</th>
            <th>Delete</th>
        </tr>
        </thead>
        <tbody id="tblCategory">
        </tbody>
        </table>
        <!--Pagination-->
        <div class="pagination" id="pagination" style="float:right"></div>
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
                $("#tblCategory").empty();                         
                //load the data
                try {                
                    $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/GetSubCategoryList",                     
                       data: "{subCategoryId:0,currentPageIndex:" + arg_current_page_index + ",pagesize:" + per_page_value + "}",                                       
                        dataType: "json",
                        success: function (successData) {
                            //for serial no
                            var counter = (arg_current_page_index*per_page_value);                           
                            $.each(successData.d, function (key, value) {                          
                                counter++;
                                //create tr     Status                            	
                                var row = create_row();
                                create_cell(row, counter, [['align', 'center']]);
                                create_cell(row, value.SubCategoryName);
                                create_cell(row, value.CategoryName);
                                //status
                                var status=value.Status==true?"Enabled":"Disabled";
                                create_cell(row,status);
                                //edit
                                create_cell(row, '<a href="javascript:void(0)" onclick="popupwindow(\'/Master/Category/AddCategory.aspx?id='+ value.SubCategoryId +'\',800,500)"><img src="/assets/themes/admin/images/icon/edit_16.png" /></a>', [['align', 'center']]);
                                create_cell(row, "<a href='javascript:void(0)' onclick='DeleteCategory("+value.SubCategoryId+")'><img src='/assets/themes/admin/images/icon/delete_16.png' /></a>", [['align', 'center']]);
                                add_row('tblCategory', row);
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
                                create_cell(row, '<span class="small_error">No record found.</span>',[['colspan','6'],['align','center']]);
                                add_row('tblCategory', row);
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
              
            function TB_close() {
                load_data(current_page_index);
            }
            function DeleteCategory(subCategoryId)
            {
            if(confirm('Are you sure you want to delete this record')){
             $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/DeleteCategory",                     
                       data:JSON.stringify({subCategoryId:subCategoryId}),                                       
                        dataType: "json",
                        success: function (successData) {
                        alert('Category deleted successfully.');
                        TB_close();
                        },
                       error: function (errorData) {   
                       }
                       });  
                       }    

            }
        </script>
</asp:Content>
