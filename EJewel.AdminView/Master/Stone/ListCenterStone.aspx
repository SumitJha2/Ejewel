<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListCenterStone.aspx.cs" Inherits="EJewel.AdminView.Master.Stone.ListCenterStone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
    .ui-menu-item
    {
        list-style:none;
    }
    .samewidth
    {
        width:200px;
    }
    
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="contentHeader">
    <h1><asp:Literal ID="ltrlHeading" runat="server" Text="Center Stone (FD)"></asp:Literal>
    <span style="padding-left:10px;">Total # Diamonds : <i style="color:Red;"><%= _totalRecord %></i></span>
    </h1>
</div>
<div class="container">
        <div class="grid-24">
        <br />
        <div align="center">
        <table class="table table-bordered table-striped" align="center" style="width:100%;">
        <tr>
        <td>Shape</td>
        <td></td>
        <td>
        <asp:DropDownList ID="ddlShape" runat="server" CssClass="samewidth"></asp:DropDownList>    
        </td>
       <td>Cut</td>
        <td >:</td>
        <td>
          <asp:DropDownList ID="ddlCut" runat="server"  CssClass="samewidth"></asp:DropDownList>
        </td>
        <td><b>Color</b></td>
        <td>:</td>
        <td>     
        <asp:DropDownList ID="ddlColor" runat="server"  CssClass="samewidth"></asp:DropDownList>
        </td>
            </tr>
        <tr>
        <td>Clarity</td>
        <td>:</td>
        <td>
           <asp:DropDownList ID="ddlClarity" runat="server" CssClass="samewidth"></asp:DropDownList>
        </td>
       <td>Carat</td>
        <td >:</td>
        <td>
        <asp:TextBox ID="txtCarat" runat="server" CssClass="samewidth" placeholder="Carat" onkeypress="return clickButton(event,'btnSearch')"></asp:TextBox>      
        </td>
            <td>
                SKU</td>
            <td>
                :</td>
            <td>
            <asp:TextBox ID="txtSKU" runat="server" CssClass="samewidth" onkeypress="return clickButton(event,'btnSearch')"  placeholder="SKU"></asp:TextBox>
            </td>
            </tr>
        <tr>
        <td align="center" colspan="9"> <input type="button" id="btnSearch" onclick="btnSearch_Click()" class="btn btn-small" value="Search" />
        <input type="button" id="btnShowAll" onclick="btnShowAll_Click()" class="btn btn-small" value="Show All" />
        <asp:HyperLink ID="lnkCreate" NavigateUrl="/Master/Stone/ManageCenterStone.aspx" runat="server" CssClass="btn btn-small">Create New</asp:HyperLink>
            </td>
            </tr>
        </table>
        </div>
        <br />
        <table class="table table-bordered table-striped" style="width:100%">
        <thead>
        <tr>
            <th>Sl.</th>
            <th>SKU</th>
            <th>Shape</th>
            <th>Clarity</th>
            <th>Color</th>
            <th>Carate</th>
            <th>Cut</th>
            <th>Price</th>
            <th>View</th>
            <th>Edit</th>
            <th>Delete</th>
        </tr>
        </thead>
        <tbody id="tblStone">
        </tbody>
        </table>
        <!--Pagination-->
       <%-- <div class="pagination" id="pagination" style="float:right"></div>--%>
          <div id="Pagination" style="float:right;" class="pagination"></div>
        </div>
        </div>
        <!--Load data-->
        <script type="text/javascript">
        var provider=<%= _provider %>;
            var total_record=<%= _totalRecord %>;
            var per_page_value =20;
            var current_page_index = 0;
            var shapeId=0;
             var cutId=0;
             var colorId=0;
             var clarityId=0;
             var carat=0;          
             var sku=null;
             
               var FIRST_TIME_LOAD = true;
                
            $(document).ready(function () {           
                load_data(current_page_index);
            });
            //load data
            function load_data(arg_current_page_index) {
                show_message_popup('Please wait...', 'message_loading');
                //clear rows
                $("#tblStone").empty();                         
                //load the data
                try {                
                    $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/GetCenterStoneList",
                       data: "{provider:"+provider+",pageIndex:" + arg_current_page_index + ",perPage:" + per_page_value + ",shapeId:"+shapeId+",cutId:"+cutId+",colorId:"+colorId+",clarityId:"+clarityId+",carat:"+carat+",sku:"+JSON.stringify(sku)+"}",
                        dataType: "json",
                        success: function (successData) {
                            //for serial no
                            var counter = (arg_current_page_index*per_page_value);                           
                            $.each(successData.d, function (key, value) {                          
                                counter++;
                                //create tr                                	
                                var row = create_row();
                                create_cell(row, counter, [['align', 'center']]);
                                create_cell(row, value.SKU);
                                create_cell(row, value.StoneShape);
                                 create_cell(row, value.StoneClarity);
                                create_cell(row, value.StoneColor);
                                create_cell(row, value.StoneCarate);
                                create_cell(row, value.StoneCut);
                                create_cell(row, "$"+value.StonePrice);
                                
                                create_cell(row, '<a href="javascript:void(0)" onclick="show_centerstone_dialog(\''+ value.SKU +'\')"><img src="/assets/themes/admin/images/icon/product/detail_16.png" /></a>', [['align', 'center']]);
                                if(provider==1)
                                {
                                create_cell(row, '<a href="/Master/Stone/ManageCenterStone.aspx?id='+ value.StoneId + '"><img src="/assets/themes/admin/images/icon/edit_16.png" /></a>', [['align', 'center']]);
                                create_cell(row, "<a href='javascript:void(0)' onclick='DeleteStone("+value.StoneId+")'><img src='/assets/themes/admin/images/icon/delete_16.png' /></a>", [['align', 'center']]);
                                }
                                else if(provider==2)
                                {
                                    create_cell(row, '-', [['align', 'center']]);
                                    create_cell(row, '-', [['align', 'center']]);
                                }
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
                                create_cell(row, '<span class="small_error">No record found.</span>',[['colspan','12'],['align','center']]);
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
              
            function TB_close() {
                load_data(current_page_index);
            }
            function DeleteStone(stoneid)
            {
            if(confirm('Are you sure you want to delete this record')){
             $.ajax({
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/DeleteStone",                     
                       data:JSON.stringify({stoneId:stoneid}),                                       
                        dataType: "json",
                        success: function (successData) {
                        alert('Stone deleted successfully.');
                        TB_close();
                        },
                       error: function (errorData) {   
                       }
                       });  
                       }    

            }

             function show_centerstone_dialog(SKU)
            {
                try
                {
                    $('<div title="Center Stone Details"></div>').load("/Master/Stone/CenterStoneOverView.aspx?SKU="+SKU).dialog({bgiframe: true,width:800,modal:true});
                }
                catch(e)
                {
                    alert(e);
                }
            }

            $("#<%=txtSKU.ClientID %>").autocomplete({
                    source: function (request, response) {
                    sku=null;
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                           url: "/Services/AdminServices.asmx/GetSKUSuggestion",
                            data: "{'provider':'"+provider+"','SKU': '" + request.term + "'}",                        
                            dataType: "json",
                            success: function (data) {  
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item
                                       // val: item.AutoID
                                    }
                                }))
                            },
                            error: function (response) {
                                alert(response.responseText);
                            },
                            failure: function (response) {
                                alert(response.responseText);
                            }
                        });
                    },
                    select: function (e, i) {
                        sku = i.item;
                    },
                    minLength: 1
                });



//          used for filter
           function btnSearch_Click()
           {  
             if(Validate_Carat()){ 
            
             shapeId=parseInt($("#<%=ddlShape.ClientID %>").val());
             cutId=parseInt($("#<%=ddlCut.ClientID %>").val());  
             colorId=parseInt($("#<%=ddlColor.ClientID %>").val());    
             clarityId=parseInt($("#<%=ddlClarity.ClientID %>").val());

           if(document.getElementById("<%=txtCarat.ClientID %>").value=="")
           {           
             carat=0;               
           }          
           else {
             carat=parseFloat(document.getElementById("<%=txtCarat.ClientID %>").value);                 // carat=0;        
           }         
            sku=document.getElementById("<%=txtSKU.ClientID %>").value==""?null:document.getElementById("<%=txtSKU.ClientID %>").value; 
                FIRST_TIME_LOAD=true;            
            load_data(0); 
            }           
           }
           // function used for show all details 
           function btnShowAll_Click()
           {
           FIRST_TIME_LOAD=true;
           shapeId=0;
           cutId=0;
           colorId=0;
           clarityId=0;
           carat=0;
           sku=null;
           load_data(0);
           }

           function Validate_Carat(){
           if(document.getElementById("<%=txtCarat.ClientID %>").value.trim()!=""){
           if(isNaN(document.getElementById("<%=txtCarat.ClientID %>").value.trim())){
           alert('Please enter carat in correct format.');
           return false;
           }
           else{
           return true;
           }           
         }
         else{
         return true;
         }

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
