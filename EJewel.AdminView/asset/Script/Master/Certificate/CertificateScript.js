/*
Partha Ranjan Nayak
@ 18-12-13
*/
//-----------------------------LOAD CERTIFICATE DETAILS-------------------
$(document).ready(function () {
    //load Gridle
    EJewel.AdminView.Services.AdminServices.GetCertificateGridle(0,
    function (result) {
        $("#ddlGridle").empty();
        $.each(result, function (key, value) {
            fillDropDown('ddlGridle', value.ID, value.Name);
        });
    },
     OnServiceError);
    //load Symmetry
    EJewel.AdminView.Services.AdminServices.GetCertificateSymmetry(0,
    function (result) {
        $("#ddlSymmetry").empty();
        $.each(result, function (key, value) {
            fillDropDown('ddlSymmetry', value.ID, value.Name);
        });
    },
     OnServiceError);
    //load culet
    EJewel.AdminView.Services.AdminServices.GetCertificateCulet(0,
    function (result) {
        $("#ddlCulet").empty();
        $.each(result, function (key, value) {
            fillDropDown('ddlCulet', value.ID, value.Name);
        });
    },
     OnServiceError);
    //load Polish
    EJewel.AdminView.Services.AdminServices.GetCertificatePolish(0,
    function (result) {
        $("#ddlPolish").empty();
        $.each(result, function (key, value) {
            fillDropDown('ddlPolish', value.ID, value.Name);
        });
    },
     OnServiceError);
    //load Flouresence
    EJewel.AdminView.Services.AdminServices.GetCertificateFlouresence(0,
    function (result) {
        $("#ddlFlouresence").empty();
        $.each(result, function (key, value) {
            fillDropDown('ddlFlouresence', value.ID, value.Name);
        });
    },
     OnServiceError);
    //load lab
    EJewel.AdminView.Services.AdminServices.GetCertificateLab(0,
    function (result) {
        $("#ddlLab").empty();
        $.each(result, function (key, value) {
            fillDropDown('ddlLab', value.ID, value.Name);
        });
    },
     OnServiceError);
    //load default stone details
});
function OnServiceError(result) {
    hide_seek('loader', false);
    displayMsg('E', result._message);
    pageScroll('loader');
}
//save the store details

function saveStoneCertificate() {
    try {
        hide_seek('loader', true);
        var model = createCertificateModel(0);
        //now save the stone details
        EJewel.AdminView.Services.AdminServices.SaveStone(model,
        function (result) {
            hide_seek('loader', false);
            displayMsg('S', 'Certificate Details Save Successfully');
            pageScroll('loader');
        },
        OnServiceError);
    }
    catch (e) {
        alert(e);
        hide_seek('loader', false);
        displayMsg('E', e.Message);
        pageScroll('loader');
    }
}

function createCertificateModel(certificateID) {
    //access the page values
    var StoneID=parseInt($("#hdnStoneID").val());
    var Depth=parseFloat($("#txtDepth").val());
    var Table=parseFloat($("#txtTable").val());
    var Gridle=parseInt($("#ddlGridle").val());
    var Symmetry=parseInt($("#ddlSymmetry").val());
    var Culet=parseInt($("#ddlCulet").val());
    var Polish=parseInt($("#ddlPolish").val());
    var Flouresence=parseInt($("#ddlFlouresence").val());
    var Measurement=$("#txtMeasurement").val();
    var Crown = parseFloat($("#txtCrown").val());
    var CrownAngle=parseFloat($("#txtCrownAngle").val());
    var Pavillion=parseFloat($("#txtPavillion").val());
    var PavillionAngle=parseFloat($("#txtPavillionAngle").val());
    var Certification=$("#txtCertification").val();
    var Lab = parseInt($("#ddlLab").val());
    //create model
    var model = new CertificateModel(certificateID, StoneID, Depth, Table, Gridle, Symmetry, Polish, Culet, Flouresence, Measurement, Crown, CrownAngle, Pavillion, Certification, Lab, '', true);
    return model;
}

//create certificate model
function CertificateModel(certificateId, stoneId, depth, table, gridleId, symmetryId, polishId, culetId, flouresenceId, measurement, crown, crownAngle, pavillion, pavillionAngle, certification, labId, file, status) {
    this.CertificateId = certificateId;
    this.StoneId = stoneId;
    this.Depth = depth;
    this.Table = table;
    this.GridleId = gridleId;
    this.SymmetryId = symmetryId;
    this.PolishId = polishId;
    this.CuletId = culetId;
    this.FlouresenceId = flouresenceId;
    this.Measurement = measurement;
    this.Crown = crown;
    this.CrownAngle = crownAngle;
    this.Pavillion = pavillion;
    this.PavillionAngle = pavillionAngle;
    this.Certification = certification;
    this.LabId = labId;
    this.File = file;
    this.Status = status;
}