$(document).ready(function () {
    var qs_id = querystring('EID');
    if (qs_id.length > 0) {
        var id = qs_id[0];
        EJewel.AdminView.Services.AdminServices.GetTax(id, OnSuccess, OnError);
    }

});
function saveUpdateTax() {
try
{
    var txtTax = $("#txtTax").val();
    var txtPercent = $("#txtPercent").val();
    var status = parseInt($("#ddlStatus").val()) == 1 ? true : false;
    if (validate(txtTax, txtPercent, status)) {
        if (!isNaN(txtPercent)) {
            var taxmodel = new taxclassmodel(txtTax, txtPercent, status);
            hide_seek('loader', true);
            EJewel.AdminView.Services.AdminServices.SaveUpdateTaxModel(taxmodel, function () {
                hide_seek('loader', false);
                $("#btnReset").click();
                displayMsg('S', "Tax Added Successfully"); window.location.href = "/Master/Payment/ListTax.aspx";
                
            },
           OnServiceError);
        }
        else {
            displayMsg('W', 'Please Enter Only Numeric Character.');
        }
    }
    else {
        hide_seek('loader', false);
        displayMsg('W', 'Required field can not be blank.');
    }
    }
    catch (e) {
        hide_seek('loader', false);
        displayMsg('E', e.message);
    }


}
function taxclassmodel(txtTax, txtPercent, status) {
    this.TaxClass = txtTax;
    this.TaxPercent = txtPercent;
    this.Status = status;
    var qs_id = querystring('EID');
    if (qs_id.length > 0) {
        this.TaxID = qs_id[0];
    }
}
function validate(txtTax,txtPercent,status){
    if (txtTax == "") { return false; }
    else if (txtPercent == "") { return false; }
    else
        return true;
}
function OnServiceError() {
}
function OnSuccess(result) {
    $.each(result, function (key, value) {
        $("#txtTax").val(value.TaxClass);
        $("#txtPercent").val(value.TaxPercent);
        $("#ddlStatus").val(value.Status);
    });
}
function OnError() {
}
