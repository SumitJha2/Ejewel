
$(document).ready(function () {

    //function used in edit mode to bind corrosponding field
    var qs_name = '';
    var lengthid = querystring('eid');
    if (lengthid.length > 0) {
        qs_name = lengthid[0];
        EJewel.AdminView.Services.AdminServices.GetChainLength(qs_name, OnSuccess, OnServiceError);
    }
});

function SaveUpdateChainLength() {
    try {
        // hide_Seek('Loader', true);
        var chainLength = $("#txtLength").val();
        var status = parseInt($("#ddlStatus").val()) == 1 ? true : false;
        var model = new ChainLengthModel(chainLength, status);
        if (validate(chainLength)) {
            if (!isNaN(chainLength)) {
                EJewel.AdminView.Services.AdminServices.SaveUpdaChainLength(model, function (result) {
                    //hide_Seek('loader', false);
                    displayMsg('S', 'Chain Length Added Successfully');
                    $("#btnreset").click();
                    window.location.href = "/Master/Metal/ListChainLength.aspx";
                },
             OnServiceError);
            }
            else {
                displayMsg('W', 'Enter Only Numeric Character');
            }
        }

        else {
            displayMsg('W', 'Required Field Can not be blank');
        }
    }
    catch (e) {
        //hide_Seek('loader',false);
        displaymsg('S', e.Message);
        pageScroll('loader');

    }
}
function OnServiceError(result) {
    hide_seek('loader', false);
    displayMsg('E', result._message);
    pageScroll('loader');
}

function ChainLengthModel(chainLength, status) {
    this.ChainLength = chainLength;
    this.Status = status;
    var chainlengthid = querystring('eid');
    if (chainlengthid.length > 0) {
        this.ChainLengthID = chainlengthid[0];
    }

}
function OnSuccess(result) {
    $.each(result, function (key, value) {
        $("#txtLength").val(value.ChainLength);
        $("#ddlStatus").val(value.Status);
    });
}
function validate(chainLength) {
    if (chainLength == "") { return false; }
    else { return true; }
}