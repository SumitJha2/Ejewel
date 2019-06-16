
$(document).ready(function () {

    //function used in edit mode to bind corrosponding field
    var qs_name = '';
    var metaltypeid = querystring('eid');
    if (metaltypeid.length > 0) {
        qs_name = metaltypeid[0];
        EJewel.AdminView.Services.AdminServices.GetChainStyle(qs_name, OnSuccess, OnServiceError);
    }
});

function SaveUpdateChainStyle() {
    try {
        // hide_Seek('Loader', true);
        var chainstyle = $("#txtName").val();       
        var status = parseInt($("#ddlStatus").val()) == 1 ? true : false;
        var model = new ChainStyleModel(chainstyle,status);

        EJewel.AdminView.Services.AdminServices.SaveUpdateChainStyle(model, function (result) {
            //hide_Seek('loader', false);
            displayMsg('S', 'Chain Style Added Successfully');
            $("#btnreset").click();
            window.location.href = "/Master/Metal/ListChainStyle.aspx";
        },
             OnServiceError);
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

function ChainStyleModel(chainstyle,status) {
    this.ChainStyle = chainstyle; 
    this.Status = status;
    var chainstyleid= querystring('eid');
    if (chainstyleid.length > 0) {
        this.ChainStyleID = chainstyleid[0];
    }

}
function OnSuccess(result) {
    $.each(result, function (key, value) {
        $("#txtName").val(value.ChainStyle);   
        $("#ddlStatus").val(value.Status);
    });
}