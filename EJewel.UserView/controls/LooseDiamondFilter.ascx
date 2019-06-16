<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LooseDiamondFilter.ascx.cs" Inherits="EJewel.UserView.controls.LooseDiamondFilter" %>
<script type="text/javascript">
        var FIRST_TIME_LOAD = true;
        var PER_PAGE=20;
        var CURRENT_PAGE=0;
        var minCarat=<%= _MINCARAT %>;var maxCarat=<%= _MAXCARAT %>;
        var minPrice=<%= _MINPRICE %>;var maxPrice=<%= _MAXPRICE %>;

        $(document).ready(function () {
        //for carat slider
        $('#carat-slider').noUiSlider({
            range: [<%= _MINCARAT %>,<%= _MAXCARAT %>],
            start: [<%= _MINCARAT %>,<%= _MAXCARAT %>],
            step: 0.01,
            connect: 'lower',
            slide: function () {
                var vals = $(this).val();
                $('#carat-val1').text(vals[0]);
                $('#carat-val2').text(vals[1]);
                //set values
                minCarat=parseFloat(vals[0]);
                maxCarat=parseFloat(vals[1]);
                //dofillter
                do_fillter(true);
            }
        });
        //for price slider
        $('#price-slider').noUiSlider({
            range: [<%= _MINPRICE %>,<%= _MAXPRICE %> ],
            start: [<%= _MINPRICE %>,<%= _MAXPRICE %> ],
            step: 1,
            connect: 'lower',
            slide: function () {
                var vals = $(this).val();
                $('#price-val1').text("$"+vals[0]);
                $('#price-val2').text("$"+vals[1]);
                //set values
                minPrice=parseFloat(vals[0]);
                maxPrice=parseFloat(vals[1]);
                //
                do_fillter(true);
            }
        });

       //fire after active & in active event
       $(".btn").on('active', function () {
                do_fillter(true);
            });

       $(".btn").on('inactive', function () {
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
            var content_object = $("#" + formated_id + " a.active");
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
            var cuts = get_selected_element("cut-btn-group", "data-id");
            var color = get_selected_element("color-btn-group", "data-id");
            var clarity = get_selected_element("clarity-btn-group", "data-id");
            var shape = get_selected_element("shape-btn-group", "data-id");
            load_center_stone("tblLooseDiamondData", shape.join(','), cuts.join(','), color.join(','), clarity.join(','), minPrice, maxPrice, minCarat, maxCarat,CURRENT_PAGE,PER_PAGE);
        }

</script>

 <div id="search-panel">
         <h4>Search Diamond</h4>
         <div class="row-fluid">
            <div id="col-left" class="span4">

                <div id="shape" class="row-fluid ">
                    <div class="span2">
                        <span class="lbl-tbar">Shape :</span></div>
                    <div class="span10">
                        <div class="btn-toolbar">
                            <div id="shape-btn-group" class="btn-group" data-toggle="buttons-checkbox">
                            <%
                                var lstStoneShape = GetStoneShapeList();
                                if (lstStoneShape != null)
                                {
                                    string css = "";
                                    int total_item = lstStoneShape.Count;
                                    for (int i = 0; i < total_item; i++)
                                    {
                                        css = _DEFSHAPE == lstStoneShape[i].Shape.ToLower() ? "active" : "";
                                    %>
                                    <a class="btn <%=css %>" href="javascript:void(0)" data-toggle="popover" data-title="<%= lstStoneShape[i].Shape  %>" data-content="" data-id="<%= lstStoneShape[i].StoneShapeId %>">
                                    <i class="icon-shape-<%= lstStoneShape[i].Shape.ToLower() %>"></i></a>
                                    <%
}
                                }
                                 %>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="color" class="row-fluid ">
                    <div class="span2">
                        <span class="lbl-tbar">Color :</span></div>
                    <div class="span10">
                        <div class="btn-toolbar">
                            <div id="color-btn-group" class="btn-group" data-toggle="buttons-checkbox">
                           <%
                                var lstSpecification = GetStoneSpecificationList(EJewel.Model.Admin.Master.Stone.StoneSpecificationModel.PageName.Color);
                                if (lstSpecification != null)
                                {
                                    int total_item = lstSpecification.Count;
                                    for (int i = 0; i < total_item; i++)
                                    {
                                    %>
                                    <a class="btn" href="javascript:void(0)" data-toggle="popover" data-title="" data-id="<%= lstSpecification[i].AutoID %>"><%= lstSpecification[i].Name%></a>
                                    <%
}
                                }
                                 %>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="clarity" class="row-fluid ">
                    <div class="span2">
                        <span class="lbl-tbar">Clarity :</span></div>
                    <div class="span10">
                        <div class="btn-toolbar">
                            <div id="clarity-btn-group" class="btn-group" data-toggle="buttons-checkbox">
                            <%
                                lstSpecification = GetStoneSpecificationList(EJewel.Model.Admin.Master.Stone.StoneSpecificationModel.PageName.Clarity);
                                if (lstSpecification != null)
                                {
                                    int total_item = lstSpecification.Count;
                                    for (int i = 0; i < total_item; i++)
                                    {
                                    %>
                                    <a class="btn" href="javascript:void(0)" data-toggle="popover" data-title="" data-id="<%= lstSpecification[i].AutoID %>"><%= lstSpecification[i].Name%></a>
                                    <%
}
                                }
                                 %>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <div id="col-center" class="span4">
                <div id="cut" class="row-fluid ">
                    <div class="span2">
                        <span class="lbl-tbar">Cut :</span></div>
                    <div class="span10">
                        <div class="btn-toolbar">
                            <div id="cut-btn-group" class="btn-group" data-toggle="buttons-checkbox">
                                <%
                                lstSpecification = GetStoneSpecificationList(EJewel.Model.Admin.Master.Stone.StoneSpecificationModel.PageName.Cut);
                                if (lstSpecification != null)
                                {
                                    int total_item = lstSpecification.Count;
                                    for (int i = 0; i < total_item; i++)
                                    {
                                    %>
                                    <a class="btn" href="javascript:void(0)" data-toggle="popover" data-title="" data-id="<%= lstSpecification[i].AutoID %>"><%= lstSpecification[i].Name%></a>
                                    <%
}
                                }
                                 %>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="carat" class="row-fluid">
                    <span class="span2">Carat:</span>
                    <div class="span10">
                        <div id="carat-slider" class="noUiSlider horizontal">
                        </div>
                        <div class="span12">
                            <div class="row-fluid">
                                <span id="carat-val1" class="range-lbl pull-left "><%= _MINCARAT %></span>
                                <span id="carat-val2" class="range-lbl pull-right"><%= _MAXCARAT %></span>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="price" class="row-fluid">
                    <span class="span2">Price:</span>
                    <div class="span10">
                        <div id="price-slider" class="noUiSlider horizontal">
                        </div>
                        <div class="span12">
                            <div class="">
                                <span id="price-val1" class="range-lbl pull-left">$<%= _MINPRICE %></span>
                                <span id="price-val2" class="range-lbl pull-right">$<%= _MAXPRICE %></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="col-right" class="span4">
                <div id="static-popover" class="popover right">
                    <div class="arrow">
                    </div>
                    <div class="popover-content">
                    </div>
                </div>
            </div>
        </div>

         <div class="row-fluid well-small">
            <div class="span8">
                <div class="span9">
                    <strong>Your Selection: </strong><span>rounded F color diamond</span>
                </div>
                <div class="span3 text-right">
                    <a href="javascript:void()" >Reset<i class="icon-retweet" style="margin: -1px 4px;"></i></a>
                </div>
            </div>
            <div class="span4 text-center">
                <a href="#">KNOW More About Diamonds</a>
            </div>
        </div>
    </div>