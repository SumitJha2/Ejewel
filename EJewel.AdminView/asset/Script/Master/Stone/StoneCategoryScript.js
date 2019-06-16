function saveStoneCategory() {
    try {
        //access the value of the controls
        hide_seek('loader', true);
        $("#loader").css("visibility", "visible");
        //$("#btnProcess")
        var name = $("#txtStoneCategoryName").val();      
        var Status = parseInt($("#ddlStatus").val()) == 1 ? true : false;
        //apply the validation rule
        // type casting
        var entityObject = new StoneCategoryEntity(name,Status);
        //send the request to services
        EJewel.AdminView.Services.AdminServices.SaveUpdateStoneCategory(entityObject, OnStoneCategorySuccess, OnStoneCategoryError);
    }
    catch (e) {
        hide_seek('loader', false);
        displayMsg('S', e.Message);
    }
    function OnStoneCategorySuccess(result) {
        hide_seek('loader', false);
        displayMsg('S', "Stone Category Added Successfully");

    }
    function OnStoneCategoryError(result) {
        hide_seek('loader', false);
        displayMsg('E', result._message);
    }
}
//create CurrencyEntity class
function StoneCategoryEntity(name, status) {
    this.StoneCategoryName = name;   
    this.Status = status;
}