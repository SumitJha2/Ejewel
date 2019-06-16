//load data of the page
$(document).ready(function () {
    // Function code here.
    //load stone category
    EJewel.AdminView.Services.AdminServices.GetStoneCategory(0,
    function (result) {
        $("#ddlCategory").empty();
        $.each(result, function (key, value) {
            fillDropDown('ddlCategory', value.StoneCategoryID, value.StoneCategoryName);
        });
    },
     OnServiceError);
});
function OnServiceError(result) {
}
//for save
function saveUpdateStone() {
    //get the page control value
    try {
        hide_seek('loader', true);
        var name = $("#txtName").val();
        var categoryid = parseInt($("#ddlCategory").val());
        var status = parseInt($("#ddlStatus").val()) == 1 ? true : false;
        var stonemodel = new StoneShapeModel(name, categoryid, status);
        if (validate(name)) {
            EJewel.AdminView.Services.AdminServices.SaveUpdateStoneShape(stonemodel,
         function (result) {
             hide_seek('loader', false);
             displayMsg('S', "Stone Shape Added Successfully");
             $("#btnReset").click();
         },
         OnServiceError);
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

//create stone model
function StoneShapeModel(name, categoryid, status) {

    this.StoneShapeName = name;
    this.StoneCategoryID = categoryid;
    this.Status = status;
}
function validate(name) {
    if (name == "") {
        return false;
    }
    else {
        return true;
    }


}

