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
        if (validate(name))
         {
            var stonemodel = new StoneClarityModel(name, categoryid, status);
            EJewel.AdminView.Services.AdminServices.SaveUpdateStoneClarity(stonemodel,
         function (result) {
             hide_seek('loader', false);
             $("#btnReset").click();
             displayMsg('S', "Stone Clarity Added Successfully");
         },
         OnServiceError);
        }
     else {
         hide_seek('loader', false);
         displayMsg('W','Required field can not be blank.');
        }
    }
    catch (e) {
        hide_seek('loader', false);
        displayMsg('E', e.message);
    }
}

//create stone model
function StoneClarityModel(name,categoryid,status) {
    this.StoneClarityName = name;
    this.StoneCategoryID = categoryid;
    this.Status = status;
}

function validate(name) 
{
    if (name == "") {
        return false;
    }
    else
     {
        return true;
    }  
   
  
}
