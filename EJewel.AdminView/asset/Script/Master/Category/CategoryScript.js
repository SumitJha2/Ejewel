var parentcategory = [];

function validateCqategory() {
    var name = $("#<%=txtCategoryName.ClientID %>").val();

    if (name == "") {       
        displayMsg('W', "Enter Category Name.");
        return false;
    }

    else {
        return true;
    }
}




// $(document).ready(function () {
//     EJewel.AdminView.Services.AdminServices.GetProductCategoryModel(
//    function (result) {
//        $("#dd1ParentCategory").empty();
//        $("#dd1ParentCategory").append("<option value='0'>Please Select</option>");
//        $.each(result, function (key, value) {
//            fillDropDown('dd1ParentCategory', value.CategoryID, value.CategoryName);
//            parentcategory.push(value.CategoryID); //store into arry
//        });
//    },
//    OnServerError);
//     var qs_name = '';
//     var categoryid = querystring('EID');
//     if (categoryid.length > 0) {
//         qs_name = parseInt(categoryid[0]);
//         EJewel.AdminView.Services.AdminServices.GetCategory(qs_name, OnSuccess, Onservererror);
//         alert('sumit');
//     }
// });

function saveUpdateCategory() {
    try {
        var name = $("#txtCategoryName").val();
        var categoryOrder = parseInt($("#txtOrder").val());
        var desc = $("#txtDescription").val();
        var status = parseInt($("#ddlStatus").val()) == 1 ? true : false;
        var parentcategory = parseInt($("#dd1ParentCategory").val());
        var pagettl = $("#txtPageTitle").val();
        var metadesc = $("#txtMetaDescription").val();
        var metakeywds = $("#txtMetaKeywords").val();
        var shwtp = $("#chkTop");
        if (shwtp.is(':checked')) { shwtp = true; } else { shwtp = false; }
        if (validate(name, categoryOrder, desc, pagettl, metadesc, metakeywds)) {
            hide_seek('loader', false);
            if (!isNaN(categoryOrder)) {
                var categorymodel = new categoryentitymodel(name, categoryOrder, desc, pagettl, metadesc, metakeywds, shwtp, parentcategory, status)
                EJewel.AdminView.Services.AdminServices.SaveUpdateCategory(categorymodel, function () {
                     hide_seek('loader', false);
                    displayMsg('S', "Category  Added Successfully");
                    $("#btnReset").click();
                },
    OnServerError);
            }
            else {
                hide_seek('loader', false);
                displayMsg('W', 'Enter Category Order in Numeric Format.');

            }
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
function categoryentitymodel(name, categoryOrder, desc, pagettl, metadesc, metakeywds, shwtp, parentcategory, status) {
    this.CategoryName = name;
    this.CategoryOrder = categoryOrder;
    this.Description = desc;
    this.PageTitle = pagettl;
    this.MetaDescription = metadesc;
    this.MetaKeywords = metakeywds;
    this.ShowOnTop = shwtp;
    this.ParentCategoryID = parentcategory;
    this.Status = status;
     var categoryid = querystring('EID');
     if (categoryid.length > 0) {
        this.CategoryID= categoryid[0];
     }


}
    function OnServerError(result) {

    }

    function validate(name, categoryOrder, desc, pagettl, metadesc, metakeywds) {
        if (name == "") { return false; }
        else if (categoryOrder == "") { return false; }
        else if (desc == "") { return false; }
        else if (pagettl == "") { return false; }
        else if (metadesc == "") { return false; }
        else if (metakeywds == "") { return false; }
        else { return true; }
    }
    //function used to bind corrosponding field in edit mode
    function OnSuccess(result) {
             
        $.each(result, function (key, value) {
            $("#txtCategoryName").val(value.CategoryName);
            $("#txtOrder").val(value.CategoryOrder);
            $("#txtDescription").val(value.Description);
            $("#txtPageTitle").val(value.PageTitle);
            $("#txtMetaDescription").val(value.MetaDescription);
            $("#txtMetaKeywords").val(value.MetaKeywords);
            alert(value.CategoryParentID);
            $("#dd1ParentCategory option[value='" + value.CategoryParentID + "']").attr("selected", "selected");
            $("#ddlStatus").val(value.Status);
        });
    }
    function Onservererror() {
    }
        



   