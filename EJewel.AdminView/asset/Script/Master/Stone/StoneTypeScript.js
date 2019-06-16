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
    //this function used for bind data in editmode.
    var qs_name = '';
    var stonecolorid = querystring('EID');
    if (stonecolorid.length > 0) {
        qs_name = stonecolorid[0];
        EJewel.AdminView.Services.AdminServices.GetStoneType(qs_name, OnSuccess, OnServiceError);
    }
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
        var stonemodel = new StoneTypeModel(name, categoryid, status);
        if(validate(name))
        {
            EJewel.AdminView.Services.AdminServices.SaveStoneType(stonemodel,
         function (result) {
             hide_seek('loader', false);
             displayMsg('S', "Stone Type Added Successfully");
             $("#btnReset").click();
             window.location.href = "/Master/Stone/ListStoneType.aspx";
         },
         OnServiceError);
         }
       else       
        {
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
function StoneTypeModel(name, categoryid, status) {
    this.StoneTypeName = name;
    this.StoneCategoryID = categoryid;
    this.Status = status;
    var stonetypeid = querystring('EID');
    if (stonetypeid.length > 0) {
        this.StoneTypeID = stonetypeid[0];
    }
}
function validate(name) {
    if (name == "")
     {
        return false;
    }
    else
    {
        return true;
    }
}
function OnSuccess(result) {
    $.each(result, function (key, value) {
        $("#txtName").val(value.StoneTypeName);
        $("#ddlCategory").val(value.StoneCategoryID);
        $("#ddlStatus").val(value.Status);
    });
}

