var CENTER_STONE_OBJECT = [];
var CENTER_STONE_COMPARE_OBJECT = [];
/*
Partha @ 08-0-513
Parameter Details
1. ContentID :) Content When Loose Diamond will bind data
2. ShapeID :) Shape of the Diamond you want to display by default(pass 0 as all)
3. MinPriceRange :) For Min price Ranage
4. MaxPriceRange :) For Max price Ranage
5. MinCaratRange :) For Min Carat Range
6. MaxCaratRange :) For Max Carat Ranage
7. MinColorRange :) For Min Color Ranage
8. MaxColorRange :) For Max Color Ranage
9. MinCutRange :) For Min Cut Ranage
10. MaxCutRange :) For Max Cut Ranage
11. MinClarityRange :) For Min Clarity Ranage
12. MaxClarityRange :) For Max Clarity Ranage
*/
function load_center_stone(ContentID, shapes, cuts, colors, clarity, MinPriceRange, MaxPriceRange, MinCaratRange, MaxCaratRange, currentPage, perPage) {
    try {
        //clear object
        $.ajax({
            type: "POST",
            async: true,
            cache: false,
            contentType: "application/json; charset=utf-8",
            url: "/Services/Service.asmx/LooseDiamondFilter",
            data: "{shapes:" + JSON.stringify(shapes) + ",cuts:" + JSON.stringify(cuts) + ",colors:" + JSON.stringify(colors) + ",clarity:" + JSON.stringify(clarity) + ",MinPriceRange:" + MinPriceRange + ",MaxPriceRange:" + MaxPriceRange + ",MinCaratRange:" + MinCaratRange + ",MaxCaratRange:" + MaxCaratRange + ",currentPage:" + currentPage + ",perPage:" + perPage + "}",
            dataType: "json",
            success: function (successData) {
                CENTER_STONE_OBJECT = [];
                $("#" + ContentID).empty();
                var total_item = successData.d.length;
                var TOTAL_RECORD = 0;
                if (total_item > 0)
                 {
                    TOTAL_RECORD = successData.d[0].TotalRecord;
                    $("#resultTab").html("Total Diamond (" + TOTAL_RECORD + ")");
                    for (var i = 0; i < total_item; i++) {
                        //create_center_stone_table_str(ContentID, successData.d[i], i, 1);
                        create_center_stone_table_str_loose_diamond(ContentID, successData.d[i]);
                        CENTER_STONE_OBJECT.push(successData.d[i]);
                    }
                    //create pagination
                    if (FIRST_TIME_LOAD == true) {
                        $("#Pagination").pagination(TOTAL_RECORD, getPagingOption());
                        FIRST_TIME_LOAD = false;
                    }
                }
                else {
                    $("#Pagination").empty();
                    var row = create_row();
                    var cell_no = create_cell(row, 'No Item Found', [['align', 'center'], ['colspan', '9']]);
                    add_row(ContentID, row);
                    $("#resultTab").html("No Diamond Found");
                }
            },
            error: function (errorData) {
                
            }
        });
    }
    catch (e) {
        
    }
}
//show center
function show_center_stone_details(ContentID, model) {
    $("#" + ContentID).empty();
    //row SKU
    var row = create_row();
    var cell_l = create_cell(row, '<span class="item_head"></span> SKU #');
    var cell_r = create_cell(row, model.SKU, [['align', 'right']]);
    add_row(ContentID, row);
    //row shape
    var row = create_row();
    var cell_l = create_cell(row, '<span class="item_head"></span> Shape');
    var cell_r = create_cell(row, model.StoneShape, [['align', 'right']]);
    add_row(ContentID, row);
    //weight
    row = create_row();
    cell_l = create_cell(row, '<span class="item_head"></span>Weight');
    cell_r = create_cell(row, model.StoneCarate, [['align', 'right']]);
    add_row(ContentID, row);
    //StoneClarity
    row = create_row();
    cell_l = create_cell(row, '<span class="item_head"></span>Clarity');
    cell_r = create_cell(row, model.StoneClarity, [['align', 'right']]);
    add_row(ContentID, row);
    //StoneColor
    row = create_row();
    cell_l = create_cell(row, '<span class="item_head"></span>Color');
    cell_r = create_cell(row, model.StoneColor, [['align', 'right']]);
    add_row(ContentID, row);
    //StoneCut
    row = create_row();
    cell_l = create_cell(row, '<span class="item_head"></span>Cut');
    cell_r = create_cell(row, model.StoneCut, [['align', 'right']]);
    add_row(ContentID, row);
    //Stone price
    row = create_row();
    cell_l = create_cell(row, '<span class="item_head"></span>Price');
    cell_r = create_cell(row, '$' + model.StonePrice, [['align', 'right']]);
    add_row(ContentID, row);
    //Stone Certification
    row = create_row();
    cell_l = create_cell(row, '<span class="item_head"></span>Certification');
    cell_r = create_cell(row, model.CertificateCertificationLab, [['align', 'right']]);
    add_row(ContentID, row);
}

//create center stone table str
function create_center_stone_table_str_loose_diamond(content_id,model_data)
{
    var row = create_row([['onmouseover', 'on_center_stone_row_mouse_hover(\'' + model_data.SKU + '\',this)'], ['class', 'loose_diamond_pop_over']]);
    var checked_status = is_sku_in_comapre_list(model_data.SKU);
    checked_status = checked_status ? 'checked="checked"' : '';
    //
    create_cell(row, '<input type="checkbox" ' + checked_status + ' id="chkCompare_' + model_data.SKU + '" onclick="add_to_compare(\'' + model_data.SKU + '\')" />', [['align', 'center']]);
    //create shape
    create_cell(row, model_data.StoneShape, [['align', 'center']]);
    //create carat
    create_cell(row, model_data.StoneCarate, [['align', 'center']]);
    //create cut
    create_cell(row, model_data.StoneCut, [['align', 'center']]);
    //create color
    create_cell(row, model_data.StoneColor, [['align', 'center']]);
    //create clarit
    create_cell(row, model_data.StoneClarity, [['align', 'center']]);
    //create price
    create_cell(row, "$"+model_data.StonePrice, [['align', 'center']]);
    //create view
    create_cell(row, '<input type="button" class="btn-fd" value="View" />', [['align', 'center']]);
    //
    add_row(content_id, row);
}

function create_center_stone_compare_table_loose_diamond(content_id, model_data) {
    var row = create_row([['onmouseover', 'on_center_stone_compare_row_mouse_hover(\'' + model_data.SKU + '\',this)'], ['class', 'loose_diamond_pop_over']]);
    create_cell(row, '<input type="checkbox" checked="checked" id="chkRemove_' + model_data.SKU + '" onclick="create_compare_table(\'' + model_data.SKU + '\')" />', [['align', 'center']]);
    //create shape
    create_cell(row, model_data.StoneShape, [['align', 'center']]);
    //create carat
    create_cell(row, model_data.StoneCarate, [['align', 'center']]);
    //create cut
    create_cell(row, model_data.StoneCut, [['align', 'center']]);
    //create color
    create_cell(row, model_data.StoneColor, [['align', 'center']]);
    //create clarit
    create_cell(row, model_data.StoneClarity, [['align', 'center']]);
    //create price
    create_cell(row, "$" + model_data.StonePrice, [['align', 'center']]);
    //create view
    create_cell(row, '<input type="button" class="btn btn-mini" value="View" />', [['align', 'center']]);
    //append in tbale
    add_row(content_id, row);
}
//add to compare

function add_to_compare(SKU) {
    var total_sku = CENTER_STONE_OBJECT.length;
    var total_compare_sku = CENTER_STONE_COMPARE_OBJECT.length;
    //get the sku from the center stone
    var selected_sku_model = get_sku_from_list(CENTER_STONE_OBJECT, SKU);
    if(selected_sku_model!=false) {
        //check that the sku is in compare list or not
        var compare_sku_model = get_sku_from_list(CENTER_STONE_COMPARE_OBJECT, SKU);
        var comapre_sku="";
        if(compare_sku_model!=false)
        {
            //add the item in the compare table
            comapre_sku=SKU;
        }
        CENTER_STONE_COMPARE_OBJECT.push(selected_sku_model);
        create_compare_table(comapre_sku);
    }

}

function create_compare_table(comapre_sku)
{
    var temp_comapre_sku = CENTER_STONE_COMPARE_OBJECT;
    //reset the comapre sku
    CENTER_STONE_COMPARE_OBJECT=[];
    var total = temp_comapre_sku.length;
    $("#tblLooseDiamondCompareData").empty();
    for(var i=0;i<total;i++)
    {
        if(temp_comapre_sku[i].SKU!=comapre_sku)
        {
            //add the comapre table
            create_center_stone_compare_table_loose_diamond("tblLooseDiamondCompareData", temp_comapre_sku[i]);
            //add to the comapre arra
            CENTER_STONE_COMPARE_OBJECT.push(temp_comapre_sku[i]);
        }
        else
        {
            //uncheck the comapre
            var comapre_checkbox = document.getElementById("chkCompare_" + comapre_sku);
            if(comapre_checkbox!=null)
            {
                comapre_checkbox.checked = false;
            }
        }
    }
    //set total comapre
    $("#compareTab").html("Compare ("+CENTER_STONE_COMPARE_OBJECT.length+")");
}

function get_sku_from_list(json_array_list, SKU) {
    var total = json_array_list.length;
    if (total > 0) {
        for (var i = 0; i < total; i++) {
            //get object
            if (json_array_list[i].SKU == SKU) {
                return json_array_list[i];
            }
        }
    }
    return false;
}

function is_sku_in_comapre_list(sku) {
    var total = CENTER_STONE_COMPARE_OBJECT.length;
    for (var i = 0; i < total; i++) {
        if (CENTER_STONE_COMPARE_OBJECT[i].SKU == sku) {
            return true;
        }
    }
    return false;
}