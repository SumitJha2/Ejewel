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
Partha
@ 28-01-13
this function specila for puructs
*/
function go_to_matching_band(page_name,ref) {
    var qs_data = querystring("id");
    if (qs_data.length > 0) {
        location.href = "/Product/" + page_name + ".aspx?id=" + qs_data[0] + "&ref=" + ref+"&view=matching_band";
    }
}

function go_to_next_product(page_name,ref)
{
   var qs_data = querystring("id");
   if (qs_data.length > 0) {
                      location.href = "/Product/"+page_name+".aspx?id=" + qs_data[0] + "&ref="+ref;
                  }
              }
              /*
              Partha Ranjan
              @ 29-01-13
              */
              function openWindow(pageURL, w, h) {
                  try {
                      var left = (screen.width / 2) - (w / 2);
                      var top = (screen.height / 2) - (h / 2);
                      var targetWin = window.open(pageURL, "new_window", 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,,width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
                  }
                  catch (e) {
                      alert(e);
                  }
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