/*
Partha Ranjan nayak
@ Fascinating Diamonds (c) 2013
29-03-2013
This script used to create product table str
***************************************
Dependancy script dom.js
*/
//create row
function create_item(productId,product_sku, product_name, price, image_path,primary_category_name,sub_category_name) {
    try {
        //get product shape
        var productSideStoneShape = get_product_center_stone_shape(productId);
        //create item row
        var item_row = create_object('div', [['class', 'span3 product']]);
        var shape_row = create_object('div', [['class', 'product_shape']]);
        var blank_row = create_object('div', [['class', 'product-overflow-keeper']]);
        var details_row = create_object('div', [['class', 'product-info']]);
        //create image
        var img = create_object('img', [['class', 'product-image'], ['src', image_path]]);
        //create price
        var span_price = create_object('span', [['class', 'product-price']]);
        span_price.innerText = "$ " + price;
        //create link (text)
        var link = create_object('a', [['class', 'product-name'], ['href', '/product/' + primary_category_name + '/' + sub_category_name + '/' + get_well_formated_title(product_name) + '/' + product_sku]]);
        link.innerText = product_name;
        //now bind the data
        //append price
        details_row.appendChild(span_price);
        //append link
        details_row.appendChild(link);
        //append the image
        blank_row.appendChild(img);
        //append the details into the blank row
        //blank_row.appendChild(details_row);
        //create over div
        var hover_div = create_object('div', [['class', 'product-hover']]);
        //link hover compare
        var hover_compare_link = create_object('a');
        hover_compare_link.innerText = "+ Compare";
        //link wishlist
        var hover_wishlist_link = create_object('a');
        hover_wishlist_link.innerText = "+ Wishlist";
        //link customize 
        var hover_customize_link = create_object('a', [['href', '/product/' + primary_category_name + '/' + sub_category_name + '/' + get_well_formated_title(product_name) + '/' + product_sku], ['class', 'add-shortcut']]);
        hover_customize_link.innerText = "+";
        //add shape in shape item
        //shape_row
        var total_shape = productSideStoneShape.length;
        if (total_shape > 0) {
            for (var i = 0; i < total_shape; i++) {
                var li_shape = create_object("li");
                li_shape.innerText = productSideStoneShape[i].Shape;
                //shape_row.appendChild(li_shape);
            }
            item_row.appendChild(shape_row);
        }
        //add to comapre div
        hover_div.appendChild(hover_compare_link);
        hover_div.appendChild(hover_wishlist_link);
        hover_div.appendChild(hover_customize_link);
        blank_row.appendChild(hover_div);
        //append the data into the row
        item_row.appendChild(blank_row)
        return item_row;
    }
    catch (e) {
        alert(e);
    }
}

function create_main_row() {
return create_object('div', [['class', 'row']]);
}

//get product center srone shape
function get_product_center_stone_shape(product_id) {
    var shape = [];
    try {
        $.ajax({
            type: "POST",
            async: false,
            cache: false,
            contentType: "application/json; charset=utf-8",
            url: "/Services/Service.asmx/GetProductCenterStoneStoneShapeList",
            data: "{productId:" + product_id + "}",
            dataType: "json",
            success: function (successData) {
                //get total item
                var total = successData.d.length;
                for (var i = 0; i < total; i++) {
                    shape.push(successData.d[i]);
                }
            },
            error: function (errorData) {
            }
        });
    }
    catch (e) {

    }
    return shape;
}
//get well formated mane
function get_well_formated_title(title) {
    //setp 1 upper case
    title = title.toLowerCase();
    //remove all the white space and put the space
    title=title.replace(new RegExp(' ', 'g'), '-');
    //remove single quote to normal
    title = title.replace(new RegExp("'", 'g'), '');
    //remove & to and
    title = title.replace(new RegExp("&", 'g'), 'and');
    return title;
}