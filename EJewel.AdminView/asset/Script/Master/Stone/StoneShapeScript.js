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

    //function used in edit mode to bind corrosponding field
    var qs_name = '';
    var stoneshapeid = querystring('EID');
    if (stoneshapeid.length > 0) {
        qs_name = stoneshapeid[0];
        EJewel.AdminView.Services.AdminServices.GetStoneShape(qs_name, OnSuccess, OnServiceError);
    }
    
});
function OnServiceError(result) {
}
//for save & update
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
             window.location.href = "/Master/Stone/ListStoneShape.aspx";
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
    //assign  id in edit mode
    
    var stoneshapeid = querystring('EID');
    if (stoneshapeid.length > 0) {
        this.StoneShapeID = stoneshapeid[0];
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
//bind data in edit mode
function OnSuccess(result) {
    $.each(result, function (key, value) {
        $("#txtName").val(value.StoneShapeName);
        $("#ddlCategory").val(value.StoneCategoryID);
        $("#ddlStatus").val(value.Status);
    });
}

