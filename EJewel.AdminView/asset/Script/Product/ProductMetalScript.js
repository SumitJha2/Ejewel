/*
Partha Ranjan
@ 19-01-2013
This script manage the product metal details
*/
function get_product_metal() {
    EJewel.AdminView.Services.AdminServices.GetProductMetalList(
             function (result) {
                 var counter = 0;
                 //add default items
                 fillDropDown('ddlDefMetal', '0', '--Select--');
                 $.each(result, function (key, value) {
                     try {
                         counter++;
                         //add item in default metal drop down
                         fillDropDown('ddlDefMetal', value.MetalID, value.MetalName);
                         //add check box for metal
                         var control_name = "chkMetal" + counter;
                         var checkbox = document.createElement('input');
                         checkbox.type = "checkbox";
                         checkbox.name = control_name;
                         checkbox.value = value.MetalID;
                         checkbox.id = control_name;
                         //add label
                         var label = document.createElement('label')
                         label.htmlFor = control_name;
                         label.appendChild(document.createTextNode(value.MetalName));
                         //add control
                         //var container=;
                         $("#avialableMetal").append(checkbox);
                         $("#avialableMetal").append(label);
                         $("#avialableMetal").append("<br><br>");
                         //
                     }
                     catch (e) {
                         alert(e);
                     }
                 });
             }, onServiceError);
}
/*
Partha Ranjan
@ 19-01-2013
Through the server error
*/
function onServiceError(result) {
    hide_seek('loader', false);
    displayMsg('E', result._message);
    pageScroll('loader');
}
/*
Partha ranjan
@ 21-01-13
This function save the details of the product metal
*/
