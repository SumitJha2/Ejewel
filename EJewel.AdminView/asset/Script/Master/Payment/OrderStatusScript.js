
$(document).ready(function () {
    var qs_name = '';
    var orderstatusid = querystring('EID');
    if (orderstatusid.length > 0) {
        qs_name = orderstatusid[0];
        EJewel.AdminView.Services.AdminServices.GetOrderStatus(qs_name, OnSuccess, Onservererror);
    }
});

function saveUpdateOrderStatus() {
try
{
    var name = $("#txtOrder").val();
    var status = parseInt($("#ddlStatus").val()) == 1 ? true : false;
    if (validate(name)) {
        var paymentmodel = new paymentstatus(name, status);
        EJewel.AdminView.Services.AdminServices.SaveUpdateOrderStatus(paymentmodel, function () {
            hide_seek('loader', false);
            displayMsg('S', "Order Status Added Successfully");
            $("#btnReset").click();
            window.location.href = "/Master/Payment/ListOrderStatus.aspx";
        },
   OnServiceError);
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
function validate(name)
{
if(name=="")
{
return false;
}
else
{
return true;
}
}
function paymentstatus(name, status) {
    this.OrderStatusName = name;
    this.Status = status;
     var orderstatusid = querystring('EID');
     if (orderstatusid.length > 0) {
         this.OrderStatusID = orderstatusid[0];
      }
}
function OnServiceError() {
}
function OnSuccess(result) {
    $.each(result, function (key, value) {
        $("#txtOrder").val(value.OrderStatusName);
        $("#ddlStatus").val(value.Status);
    });
}
function Onservererror() {
}
