
//***********************************************
//Contact
//***********************************************
function InitContactPage() {
    InitFields();
    BuildModels();
    BuildDealers();
}

function InitFields()
{
    $("#ContactTerms").prop("checked", false);
    $("#cmdSaveContact").prop('disabled', true);
    $("#ContactName").val('');
    $("#ContactName").attr("placeholder", "Name");
    $("#ContactEmail").val('');
    $("#Contactmessage").attr("placeholder", "Email");
    $("#ContactName").val('');
    $("#ContactModel").prop('selectedIndex', -1)
    $("#ContactDealer").prop('selectedIndex', -1)
}

function BuildModels() {
    AjaxCall("../AppicoModel/List",
        "GET",
        "",
        function (data) {
            $.parseJSON(data).forEach(element =>
                $("#ContactModel").append("<option value=" + element.guid + ">" + element.Model + "</option>")
            );
            $("#ContactModel").prop('selectedIndex', -1)
        },
        function (error) { ShowMessage(error); },
        "");
}

function BuildDealers() {
    AjaxCall("../AppicoDealer/List",
        "GET",
        "",
        function (data) {
            $.parseJSON(data).forEach(element =>
                $("#ContactDealer").append("<option     value=" + element.guid + ">" + element.Name + "</option>")
            );
            $("#ContactDealer").prop('selectedIndex', -1)
        },
        function (error) { ShowMessage(error); });
}

function EnabledSaveButton() {
    $("#cmdSaveContact").prop("disabled", !$("#ContactTerms")[0].checked);
}

function SaveContact() {
    if (RequiredFieldsAreFull() === true) {
        AjaxCall("../AppicoContact/save",
            "POST",
            GetContactDataFromForm(),
            function () {
                ShowMessage("Contact saved OK.");
                InitFields();
            },
            function (error) { ShowMessage(error.message); }
        );
    }
    return false;
}

function RequiredFieldsAreFull() {
    var FieldsFull = true;
    if ($("#ContactName").val() === '') {
        $("#ContactName").attr("placeholder", "This field is required");
        $("#ContactName").addClass("invalidField");
        FieldsFull = false;
    }
    else {
        $("#ContactName").attr("placeholder", "");
        $("#ContactName").removeClass("invalidField");
    }

    if ($("#ContactEmail").val() === '') {
        $("#ContactEmail").attr("placeholder", "This field is required");
        $("#ContactEmail").addClass("invalidField");
        FieldsFull = false;
    }
    else {
        $("#ContactEmail").attr("placeholder", "");
        $("#ContactEmail").removeClass("invalidField");
    }

    if ($("#ContactDealer").val() === null) {
        $("#ContactDealer").attr("placeholder", "This field is required");
        $("#ContactDealer").addClass("invalidField");
        FieldsFull = false;
    }
    else {
        $("#ContactDealer").attr("placeholder", "");
        $("#ContactDealer").removeClass("invalidField");
    }
    console.log(FieldsFull);    
    if ($("#ContactModel").val() === null) {
        $("#ContactModel").attr("placeholder", "This field is required");
        $("#ContactModel").addClass("invalidField");
        FieldsFull = false;
    }
    else {
        $("#ContactModel").attr("placeholder", "");
        $("#ContactModel").removeClass("invalidField");
    }
    return FieldsFull;
}

function GetContactDataFromForm() {

    var ContactDto = {
        name: $("#ContactName").val(),
        email: $("#ContactEmail").val(),
        dealerId: $("#ContactDealer").val(),
        modelId: $("#ContactModel").val(),
        message: $("#Contactmessage").val()
    }
    return JSON.stringify(ContactDto);

}

//***********************************************
//Inventory
//***********************************************
function InitInventoryPage() {
    AjaxCall("../AppicoInventory/List",
        "GET",
        "",
        function (data) {
            $.parseJSON(data).forEach(element => {
                var rowData = "<tr>"
                    + "<td> " + element.VIN + "</td> "
                    + "<td>" + element.DealerName + "</td>"
                    + "<td>" + element.ModelMake + "</td>"
                    + "<td>" + element.ModelName + "</td>"
                    + "<td>" + element.ModelType + "</td>"
                    + "</tr>";
                $("#InventoryList").append(rowData);
            });
        },
        function (error) { ShowMessage(error); },
        "");
}

//***********************************************
//Inventory
//***********************************************
function InitSubmissionPage() {
    AjaxCall("../AppicoContact/List",
        "GET",
        "",
        function (data) {
            $.parseJSON(data).forEach(element => {
                var rowData = "<tr>"
                    + "<td> " + element.Name + "</td> "
                    + "<td> " + element.EMail + "</td> "
                    + "<td> " + element.DealerName + "</td> "
                    + "<td> " + element.ModelMake + "</td> "
                    + "<td> " + element.ModelName + "</td> "
                    + "<td> " + element.ModelType + "</td> "
                    + "<td> " + element.Message + "</td> "
                    + "<td> " + element.CreatedDate + "</td> "
                    + "</tr>";
                $("#InventoryList").append(rowData);
            });
        },
        function (error) { ShowMessage(error); },
        "");
}

//***********************************************
//Main
//***********************************************
function AjaxCall(url, type, data, sucess, error) {
    $.ajax({
        url: url,
        type: type,
        data: data,
        contentType: 'application/json',
        success: sucess,
        error: error
    });
}

function ButtonSpinner(Disabled, Button, ButtonText) {
    ButtonText = typeof ButtonText !== 'undefined' ? ButtonText : '';

    $("#" + Button).prop("disabled", Disabled);
    if (Disabled == true) {
        $("#" + Button).html(
            '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Loading...'
        );
    }
    else {
        $("#" + Button).html(ButtonText);
    }
}

function ShowMessage(Message) {
    $("#ModalText").text(Message);
    $('#myModal').modal('show');
}
