/*
Partha Ranjan Nayak
@ 17-12-12
*/
//load data of the page
$(document).ready(function () {

    $("#ddlCut").append("<option value='0'>Please Select</option>");
    $("#ddlColor").append("<option value='0'>Please Select</option>");
    $("#ddlShape").append("<option value='0'>Please Select</option>");
    $("#ddlClarity").append("<option value='0'>Please Select</option>");
    $("#ddlType").append("<option value='0'>Please Select</option>");
    // Function code here.
    //load stone category
    EJewel.AdminView.Services.AdminServices.GetStoneCategory(0,
    function (result) {
        $("#ddlCategory").empty();
        $("#ddlCategory").append("<option value='0'>Please Select</option>");
        $.each(result, function (key, value) {
            fillDropDown('ddlCategory', value.StoneCategoryID, value.StoneCategoryName);
        });
    },
     OnServiceError);
    //get stone category type
    EJewel.AdminView.Services.AdminServices.GetStoneCategoryType(
    function (result) {
        $("#ddlCategoryType").empty();
        $("#ddlCategoryType").append("<option value='0'>Please Select</option>");
        $.each(result, function (key, value) {
            fillDropDown('ddlCategoryType', value.StoneCategoryTypeID, value.StoneCategoryTypeName);
        });
    },
     OnServiceError);
    //load default stone details
    // loadStoneDetails(1);
    //function used in edit mode to bind corrosponding field
    var qs_name = '';
    var stoneid = querystring('EID');
    if (stoneid.length > 0) {
        qs_name = stoneid[0];
        
        EJewel.AdminView.Services.AdminServices.GetStoneModel(qs_name, OnSuccess, OnServiceError);

        alert('sucees');
    }

});
/*
Partha Ranjan Nayak
@ 17-12-12
*/
function loadStoneDetails(category) {
    //load stone cut
    loadStoneCut(category);
    //load stone shape
    loadStoneShape(category);
    //load stone color
    loadStoneColor(category);
    //load stone clarity
    loadStoneClarity(category);
    //load stone type
    loadStoneType(category);
}
//error result
function OnServiceError(result) {
    hide_seek('loader', false);
    displayMsg('E', result._message);
    pageScroll('loader');
}
//-----------------------Load Stone Details-----------------------------------
/*
Partha Ranjan Nayak
@ 17-12-12
*/
//load stone cut
function loadStoneCut(category) {
    EJewel.AdminView.Services.AdminServices.GetCutStone(category, 0,
    function (result) {
        $("#ddlCut").empty();
        $("#ddlCut").append("<option value='0'>Please Select</option>");
        alert('cut');
        $.each(result, function (key, value) {
            fillDropDown('ddlCut', value.StoneCutID, value.StoneCutName);
        });
    },
     OnServiceError);
}
/*
Partha Ranjan Nayak
@ 17-12-12
*/
//load stone shape
function loadStoneShape(category) {
    EJewel.AdminView.Services.AdminServices.GetShapeStone(category, 0,
    function (result) {
        $("#ddlShape").empty();
        $("#ddlShape").append("<option value='0'>Please Select</option>");
        $.each(result, function (key, value) {
            fillDropDown('ddlShape', value.StoneShapeID, value.StoneShapeName);
        });
    },
     OnServiceError);
}
/*
Partha Ranjan Nayak
@ 17-12-12
*/
//load stone color
function loadStoneColor(category) {
    EJewel.AdminView.Services.AdminServices.GetColorStone(category, 0,
    function (result) {
        $("#ddlColor").empty();
        $("#ddlColor").append("<option value='0'>Please Select</option>");
        $.each(result, function (key, value) {
            fillDropDown('ddlColor', value.StoneColorID, value.StoneColorName);
        });
    },
     OnServiceError);
}
/*
Partha Ranjan Nayak
@ 17-12-12
*/
//load stone Clarity
function loadStoneClarity(category) {
    EJewel.AdminView.Services.AdminServices.GetStoneClarity(category, 0,
    function (result) {
        $("#ddlClarity").empty();
        $("#ddlClarity").append("<option value='0'>Please Select</option>");
        $.each(result, function (key, value) {
            fillDropDown('ddlClarity', value.StoneClarityID, value.StoneClarityName);
        });
    },
     OnServiceError);
}
/*
Partha Ranjan Nayak
@ 18-12-12
*/
//load stone type
function loadStoneType(category) {
    EJewel.AdminView.Services.AdminServices.GetTypeStone(category, 0,
    function (result) {
        $("#ddlType").empty();
      $("#ddlType").append("<option value='0'>Please Select</option>");
        $.each(result, function (key, value) {
            fillDropDown('ddlType', value.StoneTypeID, value.StoneTypeName);
        });
    },
     OnServiceError);
}
//---------------------------------------------------------------------------
/*
Partha Ranjan Nayak
@ 18-12-12
*/
//for save
function saveUpdateStone() {
    //get the page control value
    try {
        hide_seek('loader', true);
        var category = parseInt($("#ddlCategory").val());
        var categorytype = parseInt($("#ddlCategoryType").val());
        var sku = $("#txtSKU").val();
        var cut = parseInt($("#ddlCut").val());
        var color = parseInt($("#ddlColor").val());
        var clarity = parseInt($("#ddlClarity").val());
        var shape = parseInt($("#ddlShape").val());
        var type = parseInt($("#ddlType").val());
        type = isNaN(type) ? 0 : type;
        var carate = parseFloat($("#txtCarate").val());
        var price = parseFloat($("#txtPrice").val());
        var cerificate = parseInt($("#ddlCertificate").val()) == 1 ? true : false;
        var status = parseInt($("#ddlStatus").val()) == 1 ? true : false;
        //validation and casting
        var model=new StoneModel(category,categorytype,sku,cut, color, clarity, shape,type, carate, price, cerificate, status);
        EJewel.AdminView.Services.AdminServices.SaveUpdateStone(model,
        function (result) 
        {
            hide_seek('loader', false);
            displayMsg('S', 'New Stone Details Successfully');
            pageScroll('loader');
        },
        OnServiceError);

    }
    catch (e) {
        hide_seek('loader', false);
        displayMsg('E', e.message);
        pageScroll('loader');
    }
}
/*
Partha Ranjan Nayak
@ 17-12-12
*/
//create stone model
function StoneModel(category, categorytype, sku, cut, color, clarity, shape, type, carate, price, cerificate, status) {
    this.CategoryID = category;
    this.CategoryTypeID = categorytype;
    this.SKU = sku;
    this.CutID = cut;
    this.ColorID = color;
    this.ClarityID = clarity;
    this.ShapeID = shape;
    this.TypeID = type;
    this.Carte = carate;
    this.Price = price;
    this.Certificate = cerificate;
    this.Status = status;
  var stoneid = querystring('EID');
  if (stoneid.length > 0) {
      this.StoneID = stoneid[0];
  }
}
function OnSuccess(data) {

    try {
        data = data[0];
        //
        loadStoneDetails(data.CategoryID);
        //
    $("#ddlCategory").val(data.CategoryID);
    $("#ddlCategoryType").val(data.CategoryTypeID)
    $("#txtSKU").val(data.SKU);
    alert(data.CutID);
   $("#ddlCut").val(data.CutID);
   $("#ddlColor").val(data.ColorID);
    $("#ddlClarity").val(data.ClarityID);
    $("#ddlShape").val(data.ShapeID);
    $("#ddlType").val(data.TypeID);
    $("#txtCarate").val(data.Carte);
    $("#txtPrice").val(data.Price);
    $("#ddlCertificate").val(data.Certificate);
    $("#ddlStatus").val(data.Status);
}
catch (e) {
}
}