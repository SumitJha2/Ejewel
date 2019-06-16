function load_loose_diamond_image_link(model, content_id, image_content_id) {
    $("#" + content_id).empty();
    try {
        //access the diamond shape details
        $.ajax({
            type: "POST",
            async: false,
            cache: false,
            contentType: "application/json; charset=utf-8",
            url: "/Services/Service.asmx/GetLooseDiamondShape",
            data: "{shapeId:" + model.StoneShapeId + "}",
            dataType: "json",
            success: function (successData) {
                var total_length = successData.d.length;
                if (total_length > 0) {
                    var link_data = "";
                    //add screech 1
                    link_data = '<a href="javascript:void(0)" onclick="draw_screech(\''+image_content_id+'\',\'' + model.SKU + '\',1)" class="image_style_screech"><img src="/' + successData.d[0].ShapeScreechImage1Small + '" style="height:30px;width:30px;" alt="" /></a>';
                    //add screech 2
                    link_data += '<a href="javascript:void(0)" onclick="draw_screech(\'' + image_content_id + '\',\'' + model.SKU + '\',2)" class="image_style_screech"><img src="/' + successData.d[0].ShapeScreechImage2Small + '" style="height:30px;width:30px;" alt="" /></a>';
                    //add orginal shape 

                    //add video

                    $("#" + content_id).append(link_data);
                }
            },
            error: function (errorData) {
                alert(errorData);
            }
        });
    }
    catch (e) {

    }
}

function draw_screech(content_id,SKU,type)
{
    //access the image from the handler
    $("#" + content_id).empty();
    //get image
    var image = '<img src="/Handler/LooseDiamondDrawing.ashx?SKU=' + SKU + '&type=' + type + '" style="width:370px;height:230px;" alt="Image" />';
    //
    $("#" + content_id).append(image);
}