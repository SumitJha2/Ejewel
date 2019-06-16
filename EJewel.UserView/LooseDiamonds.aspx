<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LooseDiamonds.aspx.cs" Inherits="EJewel.UserView.LooseDiamonds" %>

<%@ Register src="controls/LooseDiamondContent.ascx" tagname="LooseDiamondContent" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <link href="/assets/themes/css/extra/loose_diamond.css" rel="stylesheet" type="text/css" />
    <script src="/assets/controls/centerstone_fillter.js" type="text/javascript"></script>

    <script src="/assets/themes/js/tabcontent.js" type="text/javascript"></script>
    <link href="/assets/themes/tabs/tabcontent.css" rel="stylesheet" type="text/css" />

     <link href="/assets/controls/jquery_ui/css/smoothness/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
    <!---- PLUGIN for JQUERY Range Slider -->
    <script src="/assets/controls/jquery_ui/js/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
   
   <style type="text/css">
        .table {width: 100%; font-size:8pt; box-sizing:border-box; border-collapse:collapse; color:Black;}
        .table thead tr{ background-color:#ddd; }
        .table th{padding:8px;}

        .table th, .table td{ 
            text-align:center;          
            vertical-align: middle;                        
        }
        .table tr{}
        .table td{ padding:1px; border-top:1px solid #ddd; }
        .table .btn-fd{padding:3px 5px; margin:5px 0;}
        .table input[type="checkbox"]{border:1px solid #000; visibility:visible;}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        var FIRST_TIME_LOAD = true;
        var PER_PAGE=10;
        var CURRENT_PAGE=0;
        var minCarat=<%= _MINCARAT %>;var maxCarat=<%= _MAXCARAT %>;
        var minPrice=<%= _MINPRICE %>;var maxPrice=<%= _MAXPRICE %>;

        $(document).ready(function () {
        //for carat slider
            $("#carat-slider").slider({
                range: true,
                min: <%= _MINCARAT %>,
                max: <%= _MAXCARAT %>,
                values: [<%= _MINCARAT %>, <%= _MAXCARAT %>],
                step:0.01,
                stop: function (event, ui) {
                    minCarat=parseFloat(ui.values[0]);
                    maxCarat=parseFloat(ui.values[1]);
                    do_fillter(true);
                },
                slide:function(event,ui){
                    $("#carat-range-1").text(ui.values[0]);
                    $("#carat-range-2").text(ui.values[1]);
                }

            });

            //Price slider
            $("#price-slider").slider({
                range: true,
                min: <%= _MINPRICE %>,
                max: <%= _MAXPRICE %>,
                values: [<%= _MINPRICE %>, <%= _MAXPRICE %>],
                step:1,
                slide: function (event, ui) {
                    $("#price-range-1").text("$" + ui.values[0]);
                    $("#price-range-2").text("$" + ui.values[1]);
                },
                stop:function (event, ui) {
                    minPrice=parseFloat(ui.values[0]);
                    maxPrice=parseFloat(ui.values[1]);
                    do_fillter(true);
                }
            });

       //fire after active & in active event
            $("i").on('active', function () {
                do_fillter(true);
            });

             $("i").on('inactive', function () {
                do_fillter(true);
            });

            //for page size
            $("#ddlPerpage").change(function()
            {
                PER_PAGE=parseInt($(this).val());
                do_fillter(true);
            });
            //load the init data
            do_fillter(true);
    });
        //should be define
        function getPagingOption() {
    var opt = { callback: pagingCallback };
    opt['items_per_page'] = PER_PAGE;
    opt['num_display_entries'] = 5;
    opt['num_edge_entries'] = 2;
    return opt;
    }
        //paging call back
        function pagingCallback(page_index, jq) {
        // Get number of elements per pagionation page from form
        CURRENT_PAGE = page_index;
        do_fillter(false);
    }

        //custom function
        function get_selected_element(formated_id, data_id_attribute) {
            var content_object = $("#" + formated_id + " i.selected");
            var selected_data = [];
            $.each(content_object, function (index, value) {
                selected_data.push(value.getAttribute(data_id_attribute));
            });
            return selected_data;
        }
        //for fillter
        function do_fillter(status) {
            //paging varibales
            FIRST_TIME_LOAD=status;
            //get cut
            var cuts = get_selected_element("cut-wrap", "data-id");
            var color = get_selected_element("color-wrap", "data-id");
            var clarity = get_selected_element("clarity-wrap", "data-id");
            var shape = get_selected_element("shape-wrap", "data-id");
            load_center_stone("tblLooseDiamondData", shape.join(','), cuts.join(','), color.join(','), clarity.join(','), minPrice, maxPrice, minCarat, maxCarat,CURRENT_PAGE,PER_PAGE);
        }

</script>

    <script type="text/javascript">
    //for hover
    $(function () {
        $("#ResultsTable tbody tr").each(function () {
            var currentrow = $(this);
            var scrollTop = $(window).scrollTop();
            var rowTop = currentrow.offset().top;
            var rowLeft = currentrow.offset().left;
            var rowWidth = currentrow.width();

            var popup = $("<div class='popover right'> <div class='arrow'/> <div class='popover-content'> ").clone().appendTo(currentrow);

            var hideDelay = 100;
            var hideDelayTimer = null;

            //Initialize CONTENT of popup
            //var str = "<p> Stock No. :" + currentrow.data('stockno');
            //str += "<p> Gridle :" + currentrow.data('gridle');
            $('.popover-content', popup).html("hi...");

            //Initialize POSITION of popup
            var pTop, pLeft, offset = 10;
            pLeft = rowWidth + offset * 2.5;
            pWidth = 240;
            pHeight = 400;
            pTop = rowTop - scrollTop - pHeight / 2;

            popup = $('.popover', this).css({
                position: 'absolute',
                left: pLeft + offset,
                width: pWidth,
                height: pHeight,
                top: pTop
            });

            var arrow = $('.arrow', popup).css({ position: 'absolute', display: 'block' });

            $(currentrow, popup[0]).mouseover(function () {
                if (hideDelayTimer) clearTimeout(hideDelayTimer);
                popup.css({ display: 'block' });
                arrow.offset({ top: rowTop + 5 });

                if (pTop < scrollTop) {
                    pTop = rowTop - (offset * 4);
                }
                else
                    if ((pTop > scrollTop) && (pTop < (scrollTop + pHeight))) {
                        pTop = rowTop - (pHeight - (offset * 4));
                        if (pTop < scrollTop)
                            pTop = +(offset * 2);
                    }

                popup.offset({ top: pTop });
            })
                .mouseout(function () {
                    if (hideDelayTimer) clearTimeout(hideDelayTimer);
                    hideDelayTimer = setTimeout(function () {
                        hideDelayTimer = null;
                        popup.css({ display: 'none' });
                    }, hideDelay);
                });
        });
    });

    function on_center_stone_row_mouse_hover(SKU, row) {

    }
    function on_center_stone_compare_row_mouse_hover(SKU, row) {

    }
    </script>

    <div class="container push-below-header">


        <%--<img src="/assets/themes/media/2.jpg" width="1200px" />--%>


    <div id="search-panel">
         <h4>Search Diamond</h4>
         <div class="row-fluid">
          <div id="centerStone-wrap">
          <div class="row-fluid">
          <table>
          <tr>
          <td><b>Shape</b></td>
          <td rowspan="6" width="50">&nbsp;</td>
          <td><b>Cut</b></td>
          <td rowspan="6">
          <div id="static-popover" style="width:300px;" class="popover right  pull-right">
                                <div class="arrow"></div>
                                <div class="popover-content"> </div>
                            </div>
          </td>
          </tr>

          <tr>
          <td>
          <div id="shape-wrap">
                                <%
                                var lstStoneShape = GetStoneShapeList();
                                if (lstStoneShape != null)
                                {
                                    string css = "";
                                    int total_item = lstStoneShape.Count;
                                    for (int i = 0; i < total_item; i++)
                                    {
                                        css = _DEFSHAPE == lstStoneShape[i].Shape.ToLower() ? "selected" : "";
                                    %>
                                    <i class="icon-shape-large-<%= lstStoneShape[i].Shape.ToLower() %> <%=css %>" data-toggle="popover" data-title="<%= lstStoneShape[i].Shape  %>" data-content="" data-id="<%= lstStoneShape[i].StoneShapeId %>"><%= lstStoneShape[i].Shape %></i>
                                    <%
}
                                }
                                 %>
                                </div>
          </td>
          <td>
          <div id="cut-wrap" style="color:Black;">    
                                <%                                               
                                var lstSpecification = GetStoneSpecificationList(EJewel.Model.Admin.Master.Stone.StoneSpecificationModel.PageName.Cut);
                                if (lstSpecification != null)
                                {
                                    int total_item = lstSpecification.Count;
                                    for (int i = 0; i < total_item; i++)
                                    {
                                    %>
                                    <i class="" data-toggle="popover" data-title="" data-id="<%= lstSpecification[i].AutoID %>"><%= lstSpecification[i].Name%></i>
                                    <%
}
                                }
                                 %>
                                </div>
          </td>
          </tr>

          <tr>
          <td><b>Color</b></td>
          <td><b>Clarity</b></td>
          </tr>
          <tr>
          <td>
          <div id="color-wrap" style="color:Black;">                                                   
                                        <%
                                lstSpecification = GetStoneSpecificationList(EJewel.Model.Admin.Master.Stone.StoneSpecificationModel.PageName.Color);
                                if (lstSpecification != null)
                                {
                                    int total_item = lstSpecification.Count;
                                    for (int i = 0; i < total_item; i++)
                                    {
                                    %>
                                    <i class=""  data-toggle="popover" data-title="" data-id="<%= lstSpecification[i].AutoID %>"><%= lstSpecification[i].Name%></i>
                                    <%
}
                                }
                                 %>
                                </div>
          </td>
          <td>
          <div id="clarity-wrap" style="color:Black;">                                                   
                                        <%
                                lstSpecification = GetStoneSpecificationList(EJewel.Model.Admin.Master.Stone.StoneSpecificationModel.PageName.Clarity);
                                if (lstSpecification != null)
                                {
                                    int total_item = lstSpecification.Count;
                                    for (int i = 0; i < total_item; i++)
                                    {
                                    %>
                                    <i class=""  data-toggle="popover" data-title="" data-id="<%= lstSpecification[i].AutoID %>"><%= lstSpecification[i].Name%></i>
                                    <%
}
                                }
                                 %>
                                </div>
          </td>
          </tr>

          <tr>
          <td><b>Carat</b></td>
          <td><b>Price</b></td>
          </tr>

          <tr>
          <td>
          <div id="carat-wrap">       
                                    <div id="carat-slider"></div>                                            
                                        <div class="row-fluid">
                                            <div class="span12 range-wrap">
                                                <span class="range pull-left" id="carat-range-1"><%= _MINCARAT %></span>
                                                <span class="range pull-right" id="carat-range-2"><%= _MAXCARAT %></span>
                                            </div>
                                        </div>                                        
                                </div>
          </td>
          <td>
          <div id="price-wrap">       
                                    <div id="price-slider"></div>                                            
                                        <div class="row-fluid">
                                            <div class="span12 range-wrap">
                                                <span class="range pull-left" id="price-range-1">$<%= _MINPRICE %></span>
                                                <span class="range pull-right" id="price-range-2">$<%= _MAXPRICE %></span>
                                            </div>
                                        </div>                                        
                                </div>
          </td>
          </tr>

          </table>
          </div>
                </div>
             <uc1:LooseDiamondContent ID="LooseDiamondContent1" runat="server" />

    </div>
    </div>
    </div>

    <script type="text/javascript">
        $(function () {
            /*****************display tooltip & popover for searh-panel***************/
           // $('body a').tooltip({ placement: 'top' });
            $("a[data-toggle=popover]").mouseover(function () {
                var title = $(this).data('title') ? $(this).data('title') : '';
                var content = $(this).data('content') ? $(this).data('content') : '';
                $('#static-popover >.popover-content')
                    .html('<h3>' + title + '</h3>' + '<p>' + content + '</p>')
                    .stop().fadeOut(100).fadeIn('fast');
            });
            
        });

       

    </script>
    
    <script src="/assets/themes/js/extra/loose_diamond.js" type="text/javascript"></script>

    
     
</asp:Content>
