<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListSideStone.aspx.cs" Inherits="EJewel.AdminView.Master.Stone.ListSideStone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<style type="text/css">
   
    .samewidth
    {
        width:200px;
    }
    
</style>

    <div id="contentHeader">
    <h1><asp:Literal ID="ltrlHeading" runat="server">Side Stone</asp:Literal></h1>
</div>
<div class="container">
        <div class="grid-24">
           <br />
        <div align="center">
        <table class="table table-bordered table-striped" align="center" style="width:100%;">
        <tr>
        <td>Stone Category</td>
        <td>:</td>
        <td colspan="7" align="left"><asp:DropDownList ID="ddlStoneCategory" CssClass="samewidth" runat="server">
        <asp:ListItem Text="Please Select" Value="0"></asp:ListItem>
        <asp:ListItem Text="Diamond" Value="1"></asp:ListItem>
        <asp:ListItem Text="Gemstone" Value="2"></asp:ListItem>
        </asp:DropDownList></td>     
        </tr>
        <tr>
        <td>Shape</td>
        <td>:</td>
        <td>
        <asp:DropDownList ID="ddlShape" runat="server" CssClass="samewidth"></asp:DropDownList>    
        </td>
       <td>Cut</td>
        <td >:</td>
        <td>
          <asp:DropDownList ID="ddlCut" runat="server" CssClass="samewidth"></asp:DropDownList>
        </td>
        <td><b>Color</b></td>
        <td>:</td>
        <td>     
        <asp:DropDownList ID="ddlColor" runat="server" CssClass="samewidth"></asp:DropDownList>
        </td>
            </tr>
        <tr>
        <td>Clarity</td>
        <td>:</td>
        <td>
           <asp:DropDownList ID="ddlClarity" runat="server" CssClass="samewidth"></asp:DropDownList>
        </td>
         <td>Type</td>
        <td>:</td>
        <td>
           <asp:DropDownList ID="ddlType" runat="server" CssClass="samewidth"></asp:DropDownList>
        </td>
       <td>Carat</td>
        <td >:</td>
        <td>
        <asp:TextBox ID="txtCarat" runat="server" placeholder="Carat" CssClass="samewidth" onkeypress="return clickButton(event,'btnSearch')"></asp:TextBox>      
        </td>
            </tr>
        <tr>
        <td align="center" colspan="9"> <input type="button" id="btnSearch" onclick="btnSearch_Click()" class="btn btn-small" value="Search" />
        <input type="button" id="btnShowAll" onclick="btnShowAll_Click()" class="btn btn-small" value="Show All" />
        <input type="button" onclick="popupwindow('/Master/Stone/ManageSideStone.aspx',800,500)" class="btn btn-small" value="Create New" />
            </td>
            </tr>
        </table>
        </div>
        <br />




        <br /> 
        <br />
        <table class="table table-bordered table-striped" style="width:100%">
        <thead>
        <tr>
            <th>Sl.</th>           
            <th>Category</th>
            <th>Color</th>
            <th>Shape</th>
            <th>Clarity</th>
            <th>Cut</th>
            <th>Type</th>
            <th>Carate</th>         
            <th>Price</th>  
            <th>Edit</th>
            <th>Delete</th>
        </tr>
        </thead>
        <tbody id="tblStone">
        </tbody>
        </table>
        <!--Pagination-->
     <%--   <div class="pagination" id="pagination" style="float:right"></div>--%>
        <div id="Pagination" style="float:right;" class="pagination"></div>
        </div>
        </div>

          <!--Load data-->
        <script type="text/javascript">
            var total_record=<%= _totalRecord %>;
            var per_page_value =30;
            var current_page_index = 0;
            var stonecategoryId=0;
            var shapeId=0;
            var colorId=0;
            var cutId=0;
            var clarityId=0;
            var typeId=0;
            var carat=0;

          var FIRST_TIME_LOAD = true;
             
            $(document).ready(function () { 
            load_all_Default();
            $("#<%=ddlStoneCategory.ClientID%>").change(function(){
            // Load StoneSpecification
            load_stonespecification();
            });                      
                load_data(current_page_index);
            });
            //load data
            function load_data(arg_current_page_index) {
                show_message_popup('Please wait...', 'message_loading');
                //clear rows
                $("#tblStone").empty();    
                try {                
                    $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/GetSideStoneList",                     
                       data: "{sidestoneid:0,currentPageIndex:" + arg_current_page_index + ",pagesize:" + per_page_value + ",stonecategoryId:"+stonecategoryId+",shapeId:"+shapeId+",colorId:"+colorId+",cutId:"+cutId+",clarityId:"+clarityId+",typeId:"+typeId+",carat:"+carat+"}",                                       
                        dataType: "json",
                        success: function (successData) {
                            //for serial no
                            var counter = (arg_current_page_index*per_page_value);            
                            $.each(successData.d, function (key, value) {                          
                                counter++;
                                //create tr                                	
                                var row = create_row();
                                create_cell(row, counter, [['align', 'center']]);                              
                                create_cell(row, value.StoneCategory);
                                create_cell(row, value.StoneColor);
                                create_cell(row, value.StoneShape);
                                create_cell(row, value.StoneClarity);
                                create_cell(row, value.StoneCut);
                                create_cell(row, value.StoneType);
                                create_cell(row, value.StoneCarate);   
                                create_cell(row, value.StonePrice);                                       
                                create_cell(row, '<a href="javascript:void(0)" onclick="popupwindow(\'/Master/Stone/ManageSideStone.aspx?id='+ value.SideStoneId + '\',800,400)"><img src="/assets/themes/admin/images/icon/edit_16.png" /></a>', [['align', 'center']]);
                                create_cell(row, "<a href='javascript:void(0)' onclick='DeleteSideStone("+value.SideStoneId+")'><img src='/assets/themes/admin/images/icon/delete_16.png' /></a>", [['align', 'center']]);
                                add_row('tblStone', row);
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
                                create_cell(row, '<span class="small_error">No record found.</span>',[['colspan','13'],['align','center']]);
                                add_row('tblStone', row);
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
         
            function DeleteSideStone(sidestoneid)
            {
            if(confirm('Are you sure you want to delete this record.')){
             $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/DeleteSideStone",                     
                       data:JSON.stringify({sidestoneid:sidestoneid}),                                       
                        dataType: "json",
                        success: function (successData) {
                        alert('Side Stone deleted successfully.');
                        TB_close();
                        },
                       error: function (errorData) {   
                       }
                       });  
                       }    

            }
            function  load_stonespecification()
            {
              stonecategoryId= $("#<%=ddlStoneCategory.ClientID%>").val();
              load_shape(stonecategoryId);
              load_cut(stonecategoryId);
              load_color(stonecategoryId);
              load_clarity(stonecategoryId);
              load_type(stonecategoryId);            
          
            }

            //
            function load_shape(stonecategoryId)
            {
            var pageName="shape";
            $("#<%=ddlShape.ClientID %>").empty();
            $("#<%=ddlShape.ClientID %>").append("<option value='0'>--Shape--</option>");           
             $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/GetStoneSpecificationListFromCategory",                     
                         data:JSON.stringify({categoryID:stonecategoryId,pageName:pageName}),                                                  
                        dataType: "json",
                        success: function (successData) {
                       // console.log(successData);
                        $.each(successData.d,function(key,value){
                        $("#<%=ddlShape.ClientID %>").append("<option value='"+value.AutoID+"'>"+value.Name+"</option>");
                        });                     
                    
                        },
                       error: function (errorData) {   
                       }
                       });  
            }

            function  load_cut(stonecategoryId)
            {
            var pageName="cut";
             $("#<%=ddlCut.ClientID %>").empty();
            $("#<%=ddlCut.ClientID %>").append("<option value='0'>--Cut--</option>");           
             $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/GetStoneSpecificationListFromCategory",                     
                       data:JSON.stringify({categoryID:stonecategoryId,pageName:pageName}),                                       
                        dataType: "json",
                        success: function (successData) {
                        $.each(successData.d,function(key,value){
                        $("#<%=ddlCut.ClientID %>").append("<option value='"+value.AutoID+"'>"+value.Name+"</option>");
                        });                       
                     
                        },
                       error: function (errorData) {   
                       }
                       });  
                       
            }
          function  load_color(stonecategoryId)
            {
            var pagename="color";
             $("#<%=ddlColor.ClientID %>").empty();
            $("#<%=ddlColor.ClientID %>").append("<option value='0'>--Color--</option>");           
             $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/GetStoneSpecificationListFromCategory",                     
                       data:JSON.stringify({categoryID:stonecategoryId,pageName:pagename}),                                       
                        dataType: "json",
                        success: function (successData) {
                        $.each(successData.d,function(key,value){
                        $("#<%=ddlColor.ClientID %>").append("<option value='"+value.AutoID+"'>"+value.Name+"</option>");
                        });                       
                  
                        },
                       error: function (errorData) {   
                       }
                       });  
                       
            }

           function  load_clarity(stonecategoryId)
            {
            var pagename="clarity";
             $("#<%=ddlClarity.ClientID %>").empty();
            $("#<%=ddlClarity.ClientID %>").append("<option value='0'>--Clarity--</option>");           
             $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/GetStoneSpecificationListFromCategory",                     
                       data:JSON.stringify({categoryID:stonecategoryId,pageName:pagename}),                                       
                        dataType: "json",
                        success: function (successData) {
                        $.each(successData.d,function(key,value){
                        $("#<%=ddlClarity.ClientID %>").append("<option value='"+value.AutoID+"'>"+value.Name+"</option>");
                        });                       
                   
                        },
                       error: function (errorData) {   
                       }
                       });  
                       
            }
           function  load_type(stonecategoryId)
            {
            var pagename="type";
             $("#<%=ddlType.ClientID %>").empty();
            $("#<%=ddlType.ClientID %>").append("<option value='0'>--Type--</option>");           
             $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/GetStoneSpecificationListFromCategory",                     
                       data:JSON.stringify({categoryID:stonecategoryId,pageName:pagename}),                                       
                        dataType: "json",
                        success: function (successData) {
                        $.each(successData.d,function(key,value){
                        $("#<%=ddlType.ClientID %>").append("<option value='"+value.AutoID+"'>"+value.Name+"</option>");
                        });    
                        },
                       error: function (errorData) {   
                       }
                       });  
                       
            }
          function  load_all_Default() {
                $("#<%=ddlShape.ClientID %>").append("<option value='0'>--Shape--</option>");
                 $("#<%=ddlCut.ClientID %>").append("<option value='0'>--Cut--</option>");
                  $("#<%=ddlColor.ClientID %>").append("<option value='0'>--Color--</option>");
                   $("#<%=ddlClarity.ClientID %>").append("<option value='0'>--Clarity--</option>");
                   $("#<%=ddlType.ClientID %>").append("<option value='0'>--Type--</option>");           
            }
             function btnSearch_Click(){              
               stonecategoryId=parseInt($("#<%=ddlStoneCategory.ClientID %>").val());
               shapeId=parseInt($("#<%=ddlShape.ClientID %>").val());
               colorId=parseInt($("#<%=ddlColor.ClientID %>").val());
               cutId=parseInt($("#<%=ddlCut.ClientID %>").val());
               clarityId=parseInt($("#<%=ddlClarity.ClientID %>").val());
               typeId=parseInt($("#<%=ddlType.ClientID %>").val());
               
               if(validate_Carat()){
               carat=parseFloat($("#<%=txtCarat.ClientID %>").val());
                FIRST_TIME_LOAD=true;
               load_data(0);
               }
            }
          function  btnShowAll_Click()
            {
            FIRST_TIME_LOAD=true;
               stonecategoryId=0;
               shapeId=0;
               colorId=0;
               cutId=0;
               clarityId=0;
               typeId=0;
               carat=0;
               load_data(0);
            }

           function validate_Carat()
           {
             if(document.getElementById("<%=txtCarat.ClientID %>").value.trim()!="")
               {
               if(isNaN(document.getElementById("<%=txtCarat.ClientID %>").value))
               {
               alert('Please enter carat in correct format');
               return false;
               }
              }           
              return true;
           
           }

            function clickButton(e, buttonid) {           
                 var evt = e ? e : window.event;                  
                 var bt = document.getElementById(buttonid);
                 if (bt) {
                
                     if (evt.keyCode == 13) {
                         bt.click();
                         return false;
                     }
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
