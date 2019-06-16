$(document).ready(function () {
    var qs_name = '';
    var orderstatusid = querystring('EID');
    if (orderstatusid.length > 0) {
        qs_name = orderstatusid[0];
        EJewel.AdminView.Services.AdminServices.GetShipmentMethod(qs_name, OnSuccess, Onservererror);
    }
});



function saveUpdateShipmentMethod() {
try
{
    var name = $("#txtName").val();
    var price = $("#txtPrice").val();
    var status = parseInt($("#ddlStatus").val()) == 1 ? true : false;
    if (validate(name, price)) {
    //for number format only
        if (!isNaN(price)) {
            hide_seek('loader', true);
            var shipmentmodel = new shipment(name, price, status);
            EJewel.AdminView.Services.AdminServices.SaveUpdateShipmentModel(shipmentmodel, function () {
                hide_seek('loader', false);
                displayMsg('S', "Shipping Method Added Successfully");
                $("#btnReset").click();
                window.location.href="/Master/Payment/ListShipmentMethod.aspx";
            },
   OnServiceError);
        }
        else {
            hide_seek('loader', false);
            displayMsg("W", "Enter Price in number formet only.");
        }
    }
    else {
        hide_seek('loader', false);
        displayMsg("W", "Required field can not be blank.");
    }
    }
    catch (e) {
        hide_seek('loader', false);
        displayMsg('E', e.message);
    }


}
function shipment(name, price, status) {
    this.ShipmentName = name;
    this.Price = price;
    this.Status = status;
     var shipmentid = querystring('EID');
     if (shipmentid.length > 0) {
         this.ShipmentID = shipmentid[0];
              }

}
function validate(name, price) {
    if (name == "")
    { return false; }
    else if (price == "")
    { return false; }
   else {
        return true;
    }
}
function OnServiceError() {
}
function OnSuccess(result){
$.each(result,function(key,value){
$("#txtName").val(value.ShipmentName);
$("#txtPrice").val(value.Price);
$("#ddlStatus").val(value.Status);
});
}
function Onservererror()
{
}