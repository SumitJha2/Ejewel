/*
Partha Ranjan nayak
@ Fascinating Diamonds (c) 2013
29-03-2013
Script is used for doing any type of dom data
*/
function create_object(tag_name,arr_2d) {
    var obj = document.createElement(tag_name);
    if (typeof arr_2d != "undefined") {
        var total_length = arr_2d.length;
        if (total_length > 0) {
            for (var i = 0; i < total_length; i++) {
                obj.setAttribute(arr_2d[i][0], arr_2d[i][1]);
            }
        }
    }
    return obj;
}