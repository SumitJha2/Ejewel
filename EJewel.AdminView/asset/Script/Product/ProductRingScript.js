/*
partha ranjan
@ 21-01-2013
this script manage the details of the ring size
*/
function load_ring_size() {
    EJewel.AdminView.Services.AdminServices.GetProductRingSize(
             function (result) {
                 var counter = 0;
                 //add default items
                 fillDropDown('ddlRingSize', '0', '--Select--');
                 $.each(result, function (key, value) {
                     try {
                         counter++;
                         //add item in default metal drop down
                         fillDropDown('ddlRingSize', value.RingSizeID, value.MetalName);
                         //add check box for metal
                         var control_name = "chkRing" + counter;
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
                         $("#avialableRing").append(checkbox);
                         $("#avialableRing").append(label);
                         $("#avialableRing").append("<br><br>");
                         //
                     }
                     catch (e) {
                         alert(e);
                     }
                 });
             }, onServiceError);
}