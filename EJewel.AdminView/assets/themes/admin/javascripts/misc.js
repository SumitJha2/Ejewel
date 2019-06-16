/*
Partha Ranjan Nayak
@ 14-03-13
This js used for more design and colorful in application
*/
function show_message_popup(mText, cssClass) {
    $("#message_popup").show();
    $("#message_popup").addClass(cssClass);
    $("#message_popup").html('<span style="background-color:#fff">' + mText + '</span>');
}
function hide_message_popup() {
    $("#message_popup").hide();
}
/*
Partha Ranjan
@ 14-03-13
This is for creating the paging
*/
function create_pagination(pagination_id, arg_total_record, arg_current_page, arg_per_page_value, display_total_link, load_data) {
    try {
        //clear the pagination content
        $("#" + pagination_id).empty();
        //check that the total record is greater than thn the per page value
        if (arg_total_record > arg_per_page_value) {
            //check that the
            var loop_start_point = arg_current_page >= display_total_link ? (arg_current_page - display_total_link) : 0;
            var per_page_counter = 0;
            var link_counter = 0;
            for (var i = loop_start_point; i < arg_total_record; i++) {
                //create link
                //create previous link
                if (i == 0) {
                    $("#pagination").append('<a href="javascript:void(0)" class="prev disabled">« Previous</a>');
                }
                //create link
                if (i == arg_current_page) {
                    //no link for current
                    $("#pagination").append('<a href="javascript:void(0)" class="selected">' + (i + 1) + '</a>');
                }
                else {
                    //create next link
                    $("#pagination").append('<a href="javascript:void(0)" onclick="load_data(' + i + ')">' + (i + 1) + '</a>');
                }
                //increatment per page counter as per per page
                per_page_counter += arg_per_page_value;
                link_counter++;
                if (per_page_counter >= arg_total_record) {
                    break;
                }
                if (link_counter >= display_total_link) {
                    break;
                }
            }
            //create next (cosider latter)
            $("#pagination").append('<a href="javascript:void(0)" onclick="load_data(' + i + ')">Next »</a>');
        }
    }
    catch (e) {
        alert(e);
    }
}