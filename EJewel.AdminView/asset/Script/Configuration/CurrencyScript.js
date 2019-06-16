
$(document).ready(function () {
    var qs_name = '';
    var currencyid = querystring('eid');
    if (currencyid.length > 0) {
        qs_name = currencyid[0];       
        EJewel.AdminView.Services.AdminServices.GetCurrency(qs_name, OnSuccess, OnServiceError);
    }
});

function saveNewCurrency() {
    try {
        //access the value of the controls
        hide_seek('loader', true);
        $("#loader").css("visibility", "visible");
        //$("#btnProcess")
        var Title = $("#txtTitle").val();
        var Code = $("#txtCode").val();
        var Symbol = $("#txtSymbol").val();
        var Decimal = $("#txtDecimal").val();
        var Value = $("#txtValue").val();
        var Default = parseInt($("#ddlDefault").val()) == 1 ? true : false;
        var Status = parseInt($("#ddlStatus").val()) == 1 ? true : false;
        if (validate(Title, Code, Symbol, Decimal,Value)) {
         if (!isNaN(Decimal) && !isNaN(Value)) {

                //apply the validation rule
                // type casting

                var entityObject = new CurrencyEntity(Title, Code, Symbol, Decimal, Value, Default, Status);
                //send the request to services
                EJewel.AdminView.Services.AdminServices.SaveUpdateCurrency(entityObject, OnCurrencySuccess, OnCurrencyError);

                //end of validate
           }
           else {
               displayMsg('W', "Enter Only Numeric Character for Decimal Places and Value ");
           }
        }
        else {
            displayMsg('W', "Required Field Can not be Blank.");
        }
    }
    catch (e) {
        hide_seek('loader', false);
        displayMsg('S', e.Message);
    }
    function OnCurrencySuccess(result) {
        hide_seek('loader', false);
        displayMsg('S', "Currency Details Added Successfully");
        window.location.href = "/Configuration/Currency/ListCurrency.aspx";

    }
    function OnCurrencyError(result) {
        hide_seek('loader', false);
        displayMsg('E', result._message);
    }
}
//create CurrencyEntity class
function CurrencyEntity(title, code, symbol, decimalplaces, value, def, status) {
    this.Title = title;
    this.Code = code;
    this.Symbol = symbol;
    this.DecimalPlaces = decimalplaces;
    this.Value = value;
    this.DefaultCurrency = def;
    this.Status = status;   
    var currencyid = querystring('eid');
    if (currencyid.length > 0) {
        qs_name = currencyid[0];
        this.CurrencyID = currencyid[0];
    }    
}
// load data
function OnSuccess(result) {
    $.each(result, function (key, value) {
        $("#txtTitle").val(value.Title);
        $("#txtCode").val(value.Code);
        $("#txtSymbol").val(value.Symbol);
        $("#txtDecimal").val(value.DecimalPlaces);
        $("#txtValue").val(value.Value);
        $("#ddlDefault").val(value.DefaultCurrency);
        if (value.DefaultCurrency == true) {
            $("#ddlDefault option[value='" + 1 + "']").attr("selected", "selected");
        }
        else {
            $("#ddlDefault option[value='" + 0 + "']").attr("selected", "selected");
        }
        if (value.DefaultCurrency == true) {
            $("#ddlStatus option[value='" + 1 + "']").attr("selected", "selected");         
        }
        else {
            $("#ddlStatus option[value='" + 0 + "']").attr("selected", "selected");    
        }


    });

}
function OnServiceError() {
}
function validate(Title, Code, Symbol, Decimal, Value) {
    if (Title == "") { return false; }
    else if (Code == "") { return false; }
    else if (Symbol == "") { return false; }
    else if (Decimal == "") { return false; }
    else if (Value == "") { return false; }
    else
    { return true; }
}