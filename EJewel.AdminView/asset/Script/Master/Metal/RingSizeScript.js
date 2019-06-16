//load data of the page
$(document).ready(function () {
    // Function code here.
    //load stone category
    EJewel.AdminView.Services.AdminServices.GetProductCategoryModel(
    function (result) {
        $("#ddlCategory").empty();
        $.each(result, function (key, value) {
            fillDropDown('ddlCategory', value.CategoryID, value.CategoryName);
        });
    },
     OnServiceError);
    //code to bind metalType
    EJewel.AdminView.Services.AdminServices.GetMetalType(0,
    function (success) {
        $("#ddlMetal").empty();
        $.each(success, function (key, value) {
            fillDropDown('ddlMetal', value.MetalTypeId, value.MetalTypeName);
        });
    },
    OnServiceError);

    try {
        //function used in edit mode to bind corrosponding field
        var qs_name = '';
        var ringsizeid = querystring('EID');
        if (ringsizeid.length > 0) {
            qs_name = ringsizeid[0];
            EJewel.AdminView.Services.AdminServices.GetRingSize(qs_name, OnSuccess, OnServiceError);
        }
    }
    catch (e) {
        alert(e);
    }


});
function OnServiceError(result) {
}
//for save
function saveUpdateRing() {
    //get the page control value
    try {
        hide_seek('loader', true);
        var category = parseInt($("#ddlCategory").val());
        var metal = parseInt($("#ddlMetal").val());
        var size = $("#txtSize").val();
        var price = $("#txtPrice").val();
        var status = parseInt($("#ddlStatus").val()) == 1 ? true : false;
        if (RequiredValidate(size, price)) {
            if (Numericvalidate(size, price)) {
                var isdefault = parseInt($("#ddldefault").val()) == 1 ? true : false;
                var ringsize = new RingSizeModel(category, metal, size, price, status, isdefault);
                EJewel.AdminView.Services.AdminServices.SaveUpdateRingSize(ringsize,
         function (result) {
             hide_seek('loader', false);
             displayMsg('S', "Ring Size Added Successfully");
             $("#btnReset").click();
             window.location.href = "/Master/Metal/ListRingSize.aspx";

         },
         OnServiceError);
            }
            else {
                displayMsg('W', "Enter in numeric format.");
                hide_seek('loader', false);
            }
        }
        else {
            displayMsg('W', "Required field can not be blank.");
            hide_seek('loader', false);
        }

    }
    catch (e) {
        hide_seek('loader', false);
        displayMsg('E', e.message);
    }
}

//create stone model
function RingSizeModel(category, metal, size, price, status, isdefault) {
    this.CategoryID = category;
    this.MetalTypeID = metal;
    this.Size = size;
    this.Price = price;
    this.Status = status;
    this.RingDefault = isdefault;
    var ringsizeid = querystring('EID');
    if (ringsizeid.length > 0) {
        this.RingSizeID = ringsizeid[0];
    }

}
function RequiredValidate(size, price) {
    if (name == "" || price == "") { return false; }
    else { return true; }
}

function Numericvalidate(size, price) {
    if (isNaN(size)) {
        return false;
    }
    else if (isNaN(price)) {
        return false;
    }
    else {
        return true;
    }
}
function OnSuccess(result) {
    $.each(result, function (key, value) {
        $("#ddlCategory").val(value.CategoryID);
        $("#ddlMetal").val(value.MetalTypeID);
        $("#txtSize").val(value.Size);
        $("#txtPrice").val(value.Price);
        if (value.RingDefault == true)
        { $("#ddldefault").val(1); }
        else {
            $("#ddldefault").val(0);
        }
        $("#ddldefault").val(value.RingDefault);
        $("#ddlStatus").val(value.Status);
    });
}
