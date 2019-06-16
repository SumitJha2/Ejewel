String.prototype.trim = function () {
    return this.replace(/^\s+|\s+$/g, "");
};
//
function popupwindow(url, w, h, title) {

    var left = (screen.width / 2) - (w / 2);
    var top = (screen.height / 2) - (h / 2);
    var window_name = "";
    if (typeof title == "undefined") {
        window_name = "new_window";
    }
    else {
        window_name = title;
    }
    return window.open(url, window_name, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
}
/*
Partha Ranjan Nayak
@ 17-12-12
*/
function hide_seek(id, whatToDo) {
    if (whatToDo) {
        $("#" + id).css("visibility", "visible");
    }
    else {
        $("#" + id).css("visibility", "hidden");
    }
    function enable_disable(id, whatToDo) {
        if (whatToDo) {
            $("#" + id).css("visibility", "visible");
        }
        else {
            $("#" + id).css("visibility", "hidden");
        }
    }
}
/*
Partha Ranjan Nayak
@ 17-12-12
*/
function displayMsg(type,msg) {
    $("#msgPopup").css("display", "block");
    switch (type) {
        case 'S':
            {
                $("#msgPopup").addClass("alert_success");
                $("#msgPopup").html(msg);

            } break;
        case 'E':
            {
                $("#msgPopup").addClass("alert_error");
                $("#msgPopup").html(msg);

            } break;
        case 'W':
            {
                $("#msgPopup").addClass("alert_warning");
                $("#msgPopup").html(msg);

            } break;
    }
}
/*
Partha Ranjan Nayak
@ 17-12-12
*/
function fillDropDown(id, value, text) {
$("#" + id).append("<option value=\"" + value + "\">" + text + "</option>");
}
/*
Partha Ranjan Nayak
@ 18-12-12
*/
function pageScroll(id) {
    $("html, body").animate({ scrollTop: $('#' + id) }, 'slow');
}
/*
Partha Ranjan Nayak
@ 18-12-12
*/
function querystring(key) {
    var re = new RegExp('(?:\\?|&)' + key + '=(.*?)(?=&|$)', 'gi');
    var r = [], m;
    while ((m = re.exec(document.location.search)) != null) r.push(m[1]);
    return r;
}
              /*
              Partha Ranjan
              @ 06-02-12
              This function prompt
              */
              function sure(str) {
                  if (confirm(str)) {
                      return true;
                  }
                  return false;
              }
              /*
              Author: Partha Ranjan Nayak
              @ 21-01-13
              This function will not check the radio button in a table
              */
              function checkRadioChangeInGrid(table_id, radio_id) {
                  var tbl = document.getElementById(table_id);
                  var inputs = tbl.getElementsByTagName("input");
                  for (var i = 1; i < inputs.length; i++) {
                      if (inputs[i].type == "radio") {
                          inputs[i].checked = inputs[i].id == radio_id ? true : false;
                      } //end of if
                  } //end of for
              } //end of function
              //get control value
              function get_control_value(control_id) {
                  return document.getElementById(control_id).value
              }

              function allow_only_number(event) {
                  // Allow: backspace, delete, tab, escape, and enter
                  if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
                  // Allow: Ctrl+A
            (event.keyCode == 65 && event.ctrlKey === true) ||
                  // Allow: home, end, left, right
            (event.keyCode >= 35 && event.keyCode <= 39)) {
                      // let it happen, don't do anything
                      return;
                  }
                  else {
                      // Ensure that it is a number and stop the keypress
                      if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                          event.preventDefault();
                      }
                  }
              }