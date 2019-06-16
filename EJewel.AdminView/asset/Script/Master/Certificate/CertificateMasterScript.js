$(document).ready(function () {
    var editid = querystring('edit_id'); 
    var view = querystring('view');
    if (editid.length > 0) {        
        loadCertificateMaster(view[0], editid[0]);       
      }
});

/*
Partha Ranjan
@ 26-12-12
*/
//------------------- For all Certificate master-----------------
//--------------FOR GRIDLE-----------------------
function SaveUpdateGridle() {
    var values = getFormValue();
    if (validForm(values)) {
        EJewel.AdminView.Services.AdminServices.SaveUpdateGridle(getModelValue(values),
    function (result) {
        hide_seek('loader', false);
        displayMsg('S', 'Gridle Details Save Successfully');
        pageScroll('loader');
    },
    OnServiceError);
    }
}
//------------ FOR Symmetry-----
function saveUpdateSymmetry() {
    var values = getFormValue();
    if (validForm(values)) {
        EJewel.AdminView.Services.AdminServices.SaveUpdateSymmetry(getModelValue(values),
    function (result) {
        hide_seek('loader', false);
        displayMsg('S', 'Symmetry Details Save Successfully');
        pageScroll('loader');
    },
    OnServiceError);
    }
}
//------------ FOR Culet-----
function saveUpdateCulet() {
    var values = getFormValue();
    if (validForm(values)) {
        EJewel.AdminView.Services.AdminServices.SaveUpdateCulet(getModelValue(values),
    function (result) {
        hide_seek('loader', false);
        displayMsg('S', 'Culet Details Save Successfully');
        pageScroll('loader');
    },
    OnServiceError);
    }
}
//------------ FOR Polish-----
function saveUpdatePolish() {
    var values = getFormValue();
    if (validForm(values)) {
        EJewel.AdminView.Services.AdminServices.SaveUpdatePolish(getModelValue(values),
    function (result) {
        hide_seek('loader', false);
        displayMsg('S', 'Polish Details Save Successfully');
        pageScroll('loader');
    },
    OnServiceError);
    }
}
//------------ FOR Flouresence-----
function saveUpdateFlouresence() {
    var values = getFormValue();
    if (validForm(values)) {
        EJewel.AdminView.Services.AdminServices.SaveUpdateFlouresence(getModelValue(values),
    function (result) {
        hide_seek('loader', false);
        displayMsg('S', 'Flouresence Details Save Successfully');
        pageScroll('loader');
    },
    OnServiceError);
    }
}
//------------ FOR Lab-----
function saveUpdateLab() {
    var values = getFormValue();
    if (validForm(values)) {
        EJewel.AdminView.Services.AdminServices.SaveUpdateLab(getModelValue(values),
    function (result) {
        hide_seek('loader', false);
        displayMsg('S', 'Lab Details Save Successfully');
        pageScroll('loader');
    },
    OnServiceError);
    }
}
//error message
function OnServiceError(result) {
    hide_seek('loader', false);
    displayMsg('E', result._message);
    pageScroll('loader');
}
//----- creating global save for all the cerificate model---
function getModelValue(value) {
    return new CertificateMasterModel(value[0], value[1], value[2]);
}
/*
Partha Ranjan
@ 27-12-12
*/
function getFormValue() {
    hide_seek('loader', true);
    var editid = querystring('edit_id');
    var id;
    if (editid.length > 0){
    id=parseInt($("#txtID").val(editid[0]));
       }
    else
    {
     id=parseInt($("#txtID").val());
    }

    
    var name = $("#txtName").val();
    var status = parseInt($("#ddlStatus").val()) == 1 ? true : false;
    //
    return new Array(id, name, status);
}
/*
Partha Ranjan
@ 27-12-12
*/
function validForm(value) {
    //valid
    if (value[1] == '') {
        //
        hide_seek('loader', false);
        displayMsg('W', 'Required Field can not left blank');
        pageScroll('loader');
        return false;
    }
    return true;
}
//---create certificate master model
function CertificateMasterModel(id, name, status) {
    this.ID = id;
    this.Name = name;
    this.Status = status;
}
function onerror()
{
}

function loadCertificateMaster(view,editid) {
    switch (view) {
        case 'gridle':
            {
                loadGridle(editid);

            } break;
        case 'symmetry':
            {
                loadSymmetry(editid);
            } break;
        case 'culet':
            {

                loadCulet(editid);
            } break;
        case 'polish':
            {
                loadPolish(editid);
            } break;
        case 'flouresence':
            {
                loadFlouresence(editid);
            } break;
        case 'lab':
            {
                loadLab(editid);

            } break;
    }
}
function loadGridle(editid) {
    EJewel.AdminView.Services.AdminServices.GetCertificateGridle(editid,
             function (result) {
//                 $.each(result, function (key, value) {
//                     $("#txtName").val(value.Name);
//                     if (value.Status == true) {
//                         $("#ddlStatus").val(1);
//                     }
//                     else {
//                         $("#ddlStatus").val(0);
//                     }
//                 });
             }, onServiceError);
    }

