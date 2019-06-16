<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListNews.aspx.cs" Inherits="EJewel.AdminView.Extras.ListNews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    function go_to_next_page() {      
        window.location.href = "/Extras/ManageNews.aspx";
    }
    function go_to_news_page(id) {
        window.location.href = "/Extras/ManageNews.aspx?id=" + id;
    }

</script>



<div id="contentHeader">
    <h1>News & Event</h1>
</div>
<div class="container">
        <div class="grid-24">
        <div style="float:right">  
            <a href="javascript:void(0)" onclick = "go_to_next_page()"  title="" class="thickbox btn btn-small">Create New</a>
        </div>
        <br />
        <br />
        <table class="table table-bordered table-striped" style="width:100%">
        <thead>
        <tr>
            <th>Sl.</th>
            <th>Category</th>
            <th>Heading</th>
            <th>Description</th>
            <th>Date</th>
            <th>Image</th>
            <th>Status</th>
            <th>Edit</th>
            <th>Delete</th>
        </tr>
        </thead>
        <tbody id="tblNews">
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
                $("#tblNews").empty();
                //load the data
                try {
                    $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/GetNewsDetails",
                        data: JSON.stringify({ newsId: 0 }),
                        dataType: "json",
                        success: function (successData) {
                            var counter = 0;
                            $.each(successData.d, function (key, value) {
                                counter++;
                                //create tr
                                var row = create_row();
                                create_cell(row, counter, [['align', 'center']]);
                                create_cell(row, value.NewsCategoryName);
                                create_cell(row, "<div style='overflow:auto;height:100px;width:150px;'>" + value.NewsHeading+"</div>");
                                create_cell(row, "<div style='overflow:auto;height:100px;width:400px;'>"+value.NewsDescription+"</div>");
                              //  var news_date = value.Publisd_Date.split(' ');

                                create_cell(row, value.Publisd_Date);
                                create_cell(row, '<img src="/upload/images/news/' + value.NewsId + value.ImagePath + '" style="width:34px;height:34px;" alt="News" />');
                                create_cell(row, value.Status ? 'Enabled' : 'Disabled');
                                //                                create_cell(row, '<a href="javascript:void(0)" onclick="popupwindow(\'/Extras/ManageNews.aspx?id=' + value.NewsId + '\',800,500)"><img src="/assets/themes/admin/images/icon/edit_16.png" /></a>', [['align', 'center']]);


                                create_cell(row, "<a href='javascript:void(0)' onclick='go_to_news_page(" + value.NewsId + ")'><img src='/assets/themes/admin/images/icon/edit_16.png' /></a>", [['align', 'center']]);
                                create_cell(row, "<a href='javascript:void(0)' onclick='DeleteNews(" + value.NewsId + ")'><img src='/assets/themes/admin/images/icon/delete_16.png' /></a>", [['align', 'center']]);
                                add_row('tblNews', row);
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
          
            function DeleteNews(newsid) {
                if (confirm('Are you sure you want to delete this record')) {
                    $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/DeleteNews",
                        data: JSON.stringify({ newsId: newsid }),
                        dataType: "json",
                        success: function (successData) {
                            load_data();
                        },
                        error: function (errorData) {
                            alert('Unable to delete record ,Please try again later.');
                        }
                    });
                }

            }
        </script>
</asp:Content>
