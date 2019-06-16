function fillCurrencyList() {
    try {
        EJewel.AdminView.Services.AdminServices.GetCurrency(0, OnServiceSuccess, OnServiceError);
    }
    catch (e) {
        displayMsg('E', e.message);
    }
}
function OnServiceSuccess(result) {
    $("#ddlCurrency").empty();
    $.each(result, function (key, value) {
        fillDropDown('ddlCurrency', value.CurrencyID, value.Title);
    });
}
function OnServiceError(result) {
    hide_seek('loader', false);
    displayMsg('E', result._message);
}
//store the Multi store details
function saveStore() {
    try {
        hide_seek('loader', true);
        //get the contrl values
        var name = $("#txtName").val();
        var url = $("#txtURL").val();
        var currency =parseFloat($("#ddlCurrency").val());
        var status = parseInt($("#ddlStatus").val()) == 1 ? true : false;
        //validation
        //casting
        //create object
        var model = new StoreModel(name, url, currency, status);
        //send request
        EJewel.AdminView.Services.AdminServices.SaveUpdateMultiStore(model, OnStoreSuccess, OnServiceError);
    }
    catch (e) {
        hide_seek('loader', false);
        displayMsg('E', e.message);
    }
}
function OnStoreSuccess(result) {
    hide_seek('loader', false);
    displayMsg('S', 'New Store Added Successfully.');
}

function StoreModel(name, url, currency, status) {
    this.StoreName=name;
    this.StoreUrl = url;
    this.DefaultCurrency =currency;
    this.Status = status;
}