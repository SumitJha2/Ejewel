$(document).ready(function () {
    var qs_name = '';
    var paymentstatusid = querystring('EID');
    if (paymentstatusid.length > 0) {
        qs_name = paymentstatusid[0];
        EJewel.AdminView.Services.AdminServices.GetPaymentStatus(qs_name, OnSuccess, Onservererror);
    }

});


function saveUpdatePaymentStatus() {
    try {
        var name = $("#txtPayment").val();
        var status = parseInt($("#ddlStatus").val()) == 1 ? true : false;
        if (validate(name)) {
            var objmodel = new paymentmodel(name, status);
            EJewel.AdminView.Services.AdminServices.SaveUpdatePaymentStaus(objmodel, function (result) {
                hide_seek('loader', false);
                displayMsg('S', "Payment Added Successfully");
                $("#btnReset").click();
                window.location.href = "/Master/Payment/ListPaymentStatus.aspx";

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
function paymentmodel(name, status) {
    this.PaymentStatus = name;
    this.Status = status;
    var paymentstatusid = querystring('EID');
    if (paymentstatusid.length > 0) {
       this.PaymentStatusID = paymentstatusid[0];
    }
}
function OnServiceError(result) {
}
function validate(name) {
    if (name == "")
    { return false; }
    else
        return true;
}
function OnSuccess(result) {
    $.each(result, function (key, value) {
        $("#txtPayment").val(value.PaymentStatus);
        $("#dd1Status").val(value.Status);
    });
}
function Onservererror() {
}
