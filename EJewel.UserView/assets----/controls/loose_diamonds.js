               var RANGE_VALUE_MIN = 0.0;
               var RANGE_VALUE_MAX = 0.0;
               //price
               var Price_VALUE_MIN = 0;
               var Price_VALUE_MAX = 0;
               //depath
               var Depth_VALUE_MIN = 0.0;
               var Depth_VALUE_MAX = 0.0;
               //carat
               var Carat_VALUE_MIN = 0.0;
               var Carat_VALUE_MAX = 0.0;
               //color
               var Color_VALUE_MIN = 0;
               var Color_VALUE_MAX = 0;
               //cut
               var Cut_VALUE_MIN = 0;
               var Cut_VALUE_MAX = 0;
               //clarity
               var Clarity_VALUE_MIN = 0;
               var Clarity_VALUE_MAX = 0;
               //table
               var Table_VALUE_MIN = 0.0;
               var Table_VALUE_MAX = 0.0;
               //get range values
               //load all slider
               $(function () {
                   $.ajax({
                       type: "POST",
                       async: false,
                       contentType: "application/json; charset=utf-8",
                       url: "/Services/Service.asmx/GetCenterStoneMinMaxRangeList",
                       data: "{}",
                       dataType: "json",
                       success: function (data) {
                           Table_VALUE_MIN = parseFloat(data.d.MinTableRange);
                           Table_VALUE_MAX = parseFloat(data.d.MaxTableRange);
                           //price range
                           Price_VALUE_MIN = parseFloat(data.d.MinPriceRange);
                           Price_VALUE_MAX = parseFloat(data.d.MaxPriceRange);
                           //depath
                           Depth_VALUE_MIN = parseFloat(data.d.MinDepthRange);
                           Depth_VALUE_MAX = parseFloat(data.d.MaxDepthRange);
                           //carate range
                           Carat_VALUE_MIN = parseFloat(data.d.MinCaratRange);
                           Carat_VALUE_MAX = parseFloat(data.d.MaxCaratRange);
                           //cut
                           create_shape_slider();
                           //price slider
                           create_price_slider();
                           //Carat Slider
                           create_carat_slider();
                           //Color Slider
                           create_color_slider();
                           //clarity slider
                           create_clarity_slider();
                           //cut
                           create_cut_slider();
                       },
                       error: function (result) {
                           alert(result.message);
                       }
                   });
               });

               function create_shape_slider() {
                   $.ajax({
                       type: "POST",
                       async: false,
                       contentType: "application/json; charset=utf-8",
                       url: "/Services/Service.asmx/GetDiamondShapes",
                       data: "{}",
                       dataType: "json",
                       success: function (data) {
                           var chk_area = document.getElementById("shape_button");
                           for (var i = 0; i < data.d.length; i++) {
                               var chk_box = create_object('input', [['type', 'checkbox'], ['id', 'chk_shape_' + i], ['value', data.d[i].AutoID]]);
                               var chk_lbl = create_object('label', [['for', 'chk_shape_' + i]]);
                               chk_lbl.innerText = data.d[i].Name;
                               chk_area.appendChild(chk_box);
                               chk_area.appendChild(chk_lbl);
                           }
                       },
                       error: function (result) {
                           alert(result.message);
                       }

                   });
               }

               function create_price_slider() {
                   $("#price_slider").slider({
                       range: true,
                       min: Price_VALUE_MIN,
                       max: Price_VALUE_MAX,
                       step: 1,
                       values: [Price_VALUE_MIN, Price_VALUE_MAX],
                       slide: function (event, ui) {
                           $("#spanPriceRange").html("$" + ui.values[0] + " - $" + ui.values[1]);
                       },
                       stop: function (event, ui) {
                           $("#spanPriceRange").html("$" + ui.values[0] + " - $" + ui.values[1]);
                           $("#hdnMinPrice").val(ui.values[0]);
                           $("#hdnMaxPrice").val(ui.values[1]);
                           show_loose_diamond();
                       }
                   });
                   $("#spanPriceRange").html("$" + Price_VALUE_MIN + " - " + "$" + Price_VALUE_MAX);
                   $("#hdnMinPrice").val(Price_VALUE_MIN);
                   $("#hdnMaxPrice").val(Price_VALUE_MAX);
               }

               function create_carat_slider() {
                   $("#carat_slider").slider({
                       range: true,
                       step: 0.001,
                       min: Carat_VALUE_MIN,
                       max: Carat_VALUE_MAX,
                       values: [Carat_VALUE_MIN, Carat_VALUE_MAX],
                       slide: function (event, ui) {
                           $("#spanCaratRange").html(ui.values[0] + " - " + ui.values[1]);
                       },
                       stop: function (event, ui) {
                           //set the span range model
                           //set the carat
                           $("#hdnMinCarat").val(ui.values[0]);
                           $("#hdnMaxCarat").val(ui.values[1]);
                           show_loose_diamond();
                       }
                   });
                   $("#spanCaratRange").html(Carat_VALUE_MIN + " - " + Carat_VALUE_MAX);
                   $("#hdnMinCarat").val(Carat_VALUE_MIN);
                   $("#hdnMaxCarat").val(Carat_VALUE_MAX);
               }

               function create_color_slider() {
                   //define color details
                   var color_id = new Array();
                   var color_wordName = new Array();
                   //get color details
                   $.ajax({
                       type: "POST",
                       async: false,
                       contentType: "application/json; charset=utf-8",
                       url: "/Services/Service.asmx/GetColorStoneSpecificationListFromCategory",
                       data: "{}",
                       dataType: "json",
                       success: function (data) {
                           for (var i = 0; i < data.d.length; i++) {
                               color_id[i] = data.d[i].AutoID;
                               color_wordName[i] = data.d[i].Name;
                           }
                       },
                       error: function (result) {
                           alert(result.message);
                       }
                   });
                   //get the min and max values
                   Color_VALUE_MIN = Math.min.apply(null, color_id);
                   Color_VALUE_MAX = Math.max.apply(null, color_id);
                   //now draw the lable
                   var total_item = color_id.length;
                   var color_text = document.getElementById("spancolorText");
                   var total_width = 200;
                   var per_item_width = Math.floor((total_width / total_item));
                   //create str
                   for (var i = 0; i < total_item; i++) {
                       //colorText
                       var width = i == 0 ? 0 : per_item_width;
                       var span = create_object('span', [['class', 'slide_text'], ['style', 'padding-left:' + width + 'px;']]);
                       span.innerHTML = color_wordName[i];
                       color_text.appendChild(span);
                   }
                   $("#color_slider").slider({
                       range: true,
                       min: Color_VALUE_MIN,
                       max: Color_VALUE_MAX,
                       step: 1,
                       values: [Color_VALUE_MIN, Color_VALUE_MAX],
                       stop: function (event, ui) {
                           //get min and max color
                           var mincolor = color_id[parseInt(ui.values[0])];
                           var maxcolor = color_id[parseInt(ui.values[1])];
                           //assign the color values
                           $("#hdnMinColor").val(ui.values[0]);
                           $("#hdnMaxColor").val(ui.values[1]);
                           //
                           show_loose_diamond();
                       }
                   });
                   $("#hdnMinColor").val(Color_VALUE_MIN);
                   $("#hdnMaxColor").val(Color_VALUE_MAX);
               }

               function create_clarity_slider(){
                   var Clarity_ID = new Array();
                   var Clarity_Name = new Array();


                   $.ajax({
                       type: "POST",
                       async: false,
                       contentType: "application/json; charset=utf-8",
                       url: "/Services/Service.asmx/GetClarityStoneSpecificationListFromCategory",
                       data: "{}",
                       dataType: "json",
                       success: function (data) {
                           for (var i = 0; i < data.d.length; i++) {
                               Clarity_ID[i] = data.d[i].AutoID;
                               Clarity_Name[i] = data.d[i].Name;
                           }
                       },
                       error: function (result) {
                           alert(result.message);
                       }

                   });
                   Clarity_VALUE_MIN = Math.min.apply(null, Clarity_ID);
                   Clarity_VALUE_MAX = Math.max.apply(null, Clarity_ID);

                   //var color_word = ['D', 'E', 'F', 'G', 'H', 'I']
                   var total_item = Clarity_ID.length;
                   var Clarity_text = document.getElementById("spanClarityText");
                   var total_width = 160;
                   var per_item_width = Math.floor((total_width / total_item));
                   //
                   per_item_width = 10;
                   for (var i = 0; i < total_item; i++) {
                       //colorText

                       var width = i == 0 ? 0 : per_item_width;
                       var span = create_object('span', [['class', 'slide_text'], ['style', 'padding-left:' + width + 'px;']]);
                       span.innerHTML = Clarity_Name[i];

                       Clarity_text.appendChild(span);
                   }
                   $("#clarity_slider").slider({

                       range: true,
                       min: Clarity_VALUE_MIN,
                       max: Clarity_VALUE_MAX,
                       step: 1,
                       values: [Clarity_VALUE_MIN, Clarity_VALUE_MAX],

                       stop: function (event, ui) {
                           var minClarity = Clarity_ID[parseInt(ui.values[0])];
                           var maxClarity = Clarity_ID[parseInt(ui.values[1])];
                           $("#hdnMinClarity").val(ui.values[0]);
                           $("#hdnMaxClarity").val(ui.values[1]);
                           show_loose_diamond();
                       }
                   });
                   $("#hdnMinClarity").val(Clarity_VALUE_MIN);
                   $("#hdnMaxClarity").val(Clarity_VALUE_MAX);
               }

               function create_cut_slider() {
                   var Cut_ID = new Array();
                   var Cut_Name = new Array();


                   $.ajax({
                       type: "POST",
                       async: false,
                       contentType: "application/json; charset=utf-8",
                       url: "/Services/Service.asmx/GetCutStoneSpecificationListFromCategory",
                       data: "{}",
                       dataType: "json",
                       success: function (data) {
                           for (var i = 0; i < data.d.length; i++) {
                               Cut_ID[i] = data.d[i].AutoID;
                               Cut_Name[i] = data.d[i].Name;
                           }
                       },
                       error: function (result) {
                           alert(result.message);
                       }

                   });
                   Cut_VALUE_MIN = Math.min.apply(null, Cut_ID);
                   Cut_VALUE_MAX = Math.max.apply(null, Cut_ID);

                   //var color_word = ['D', 'E', 'F', 'G', 'H', 'I'] class=""
                   var total_item = Cut_ID.length;
                   var cut_text = document.getElementById("spanCutText");
                   var total_width = 400;
                   var per_item_width = Math.floor((total_width / total_item));
                   //
                   per_item_width = 10;
                   for (var i = 0; i < total_item; i++) {
                       //colorText
                       var width = i == 0 ? 0 : per_item_width;
                       var span = create_object('span', [['class', 'slide_text'], ['style', 'padding-left:' + width + 'px;']]);
                       span.innerHTML = Cut_Name[i];
                       cut_text.appendChild(span);
                   }
                   $("#cut_slider").slider({
                       range: true,
                       min: Cut_VALUE_MIN,
                       max: Cut_VALUE_MAX,
                       step: 1,
                       values: [Cut_VALUE_MIN, Cut_VALUE_MAX],
                       stop: function (event, ui) {
                           var minCut = Cut_ID[parseInt(ui.values[0])];
                           var maxCut = Cut_ID[parseInt(ui.values[1])];
                           $("#hdnMinCut").val(ui.values[0]);
                           $("#hdnMaxCut").val(ui.values[1]);
                           show_loose_diamond();
                       }
                   });
                   $("#hdnMinCut").val(Cut_VALUE_MIN);
                   $("#hdnMaxCut").val(Cut_VALUE_MAX);
                }
               //cut
                function show_loose_diamond() {
                    //access the controls
                    var min_price = get_range_value("hdnMinPrice", 0);
                    var mix_price = get_range_value("hdnMaxPrice", 0);
                    //
                    var min_carat = get_range_value("hdnMinCarat", 0);
                    var max_carat = get_range_value("hdnMaxCarat", 0);
                    //
                    var min_color = get_range_value("hdnMinColor", 0);
                    var max_color = get_range_value("hdnMaxColor", 0);
                    //
                    var min_cut = get_range_value("hdnMinCut", 0);
                    var max_cut = get_range_value("hdnMaxCut", 0);
                    //
                    var min_clarity = get_range_value("hdnMinClarity", 0);
                    var max_clarity = get_range_value("hdnMaxClarity", 0);
                    load_center_stone("tblCenterStone", DEFAULT_CENTER_STONE_SHAPE_ID, min_price, mix_price, min_carat, max_carat, min_color, max_color, min_cut, max_cut, min_clarity, max_clarity);
                }

               function get_range_value(cont_id, def_value) {
                   var hdn_value = document.getElementById(cont_id).value;
                   if (hdn_value != "") {
                       return hdn_value;
                   }
                   return def_value;
               }
               