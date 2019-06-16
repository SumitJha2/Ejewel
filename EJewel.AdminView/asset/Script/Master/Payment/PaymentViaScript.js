$(document).ready(function () {
    var qs_name = '';
    var paymentviaid = querystring('EID');
    if (paymentviaid.length > 0) {
        qs_name = paymentviaid[0];
        EJewel.AdminView.Services.AdminServices.GetPaymentVia(qs_name, OnSuccess, Onservererror);
    }

});
function saveUpdatePaymentVia() {
try
{
    var name = $("#txtPaymentVia").val();
    var status = parseInt($("#ddlStatus").val()) == 1 ? true : false;  
    if(validate(name))
    {
    var paymentmodel = new paymentviamodel(name, status);
    EJewel.AdminView.Services.AdminServices.SaveUpdatePaymentVia(paymentmodel,function(){
     hide_seek('loader', false);
                displayMsg('S', "Payment Option Successfully");
                $("#btnReset").click();
                window.location.href="/Master/Payment/ListPaymentVia.aspx";
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
function paymentviamodel(name, status) {
    this.PaymentOption = name;
    this.Status = status;
   var paymentviaid = querystring('EID');
    if (paymentviaid.length > 0) {
        this.PaymentID = paymentviaid[0];
        }
}
function validate(name) {
    if (name == "") {
        return false;
    }
    else {
        return true;
    }
}
function OnServiceError(result) {
}
function OnSuccess(result)
{
$.each(result,function(key,value){
$("#txtPaymentVia").val(value.PaymentOption);
$("#ddlStatus").val(value.Status);
});
}
function Onservererror()
{
}