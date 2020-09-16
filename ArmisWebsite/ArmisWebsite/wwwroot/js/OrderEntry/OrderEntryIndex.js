//Globals for the selected customer
var _shipToModels;
var _partModels;

//Datalists do not have a good way of checking which option was selected.  Datalist will load the input with the value of the selected option.  Throughout this script section, string comparisons will need to be done in order to figure out which option was selected.  This seems to be the best way to do it according to everything I have seen oneline. ~Joe
function updateCustomerSelection(inputCustomer) {
    var customerName = inputCustomer.value;

    var dataListOptions = document.getElementById("datalistCustomers").getElementsByTagName("option");
    var theSelectedOption = undefined;
    for (var i = 0; i < dataListOptions.length; i++) {
        if (dataListOptions[i].value == customerName) {
            theSelectedOption = dataListOptions[i];
        }
    }

    if (theSelectedOption != undefined) {
        var custId = theSelectedOption.dataset.custId;
        document.getElementById("hdnCustomerId").value = custId;
        loadBillTo(custId);
        loadContacts(custId);
        document.getElementById("datalistShipTo").innerHTML = ""; //The ShipTo datalist needs to be cleared out before adding a new set of options to it
        loadShipTos(custId);
        loadParts(custId);
        document.getElementById("btnOpenCreatePartModal").disabled = false;
    }
    else {
        clearData();
    }
}

function clearData() {
    document.getElementById("textareaBillTo").value = "";
    document.getElementById("inputContact").value = "";
    document.getElementById("datalistContact").innerHTML = "";
    document.getElementById("inputShipTo").value = "";
    document.getElementById("datalistShipTo").innerHTML = "";
    document.getElementById("textareaShipTo").value = "";
    document.getElementById("btnOpenCreatePartModal").disabled = true;
    _shipToModels = undefined;
    _partModels = undefined;
}

function loadBillTo(aCustId) {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', apiAddress + 'api/BillTo/GetBillToByCustId/' + aCustId, true);
    xhr.send();

    xhr.onload = function () {
        if (xhr.status == 200) {
            var billTo = JSON.parse(xhr.responseText);
            var textAreaBillTo = document.getElementById("textareaBillTo");
            textAreaBillTo.value = "";

            //Formatting the bill to text area text
            var billToText = billTo.Address1 + "\r\n";
            if (billTo.Address2 != "") { billToText += billTo.Address2 + "\r\n"; }
            if (billTo.Address3 != "") { billToText += billTo.Address3 + "\r\n"; }
            billToText += billTo.City + ", " + billTo.State + " " + billTo.Zip + " " + billTo.Country;
            if (billTo.PhoneNum != "") { billToText += "\r\nPhone: " + billTo.PhoneNum; }
            if (billTo.FaxNum != "") { billToText += "\r\nFax: " + billTo.FaxNum; }

            textAreaBillTo.value = billToText;
            textAreaBillTo.style.height = textAreaBillTo.scrollHeight + 3 + "px";
        }
    }
}

function loadContacts(aCustId) {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', apiAddress + 'api/Contact/GetAllHydratedContactsByCust/' + aCustId, true);
    xhr.send();

    xhr.onload = function () {
        if (xhr.status == 200) {
            var contacts = JSON.parse(xhr.responseText);

            var datalistContacts = document.getElementById("datalistContact");
            if (contacts != null) {
                for (var i = 0; i < contacts.length; i++) {
                    var optionContact = document.createElement("option");
                    optionContact.innerHTML = contacts[i].PhoneNum;
                    optionContact.value = contacts[i].LastName + ", " + contacts[i].FirstName;
                    datalistContacts.appendChild(optionContact);
                }
            }
        }
    }
}

function loadShipTos(aCustId) {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', apiAddress + 'api/ShipTo/GetShipTosByCust/' + aCustId, true);
    xhr.send();

    xhr.onload = function () {
        if (xhr.status == 200) {
            var shipTos = JSON.parse(xhr.responseText);
            _shipToModels = shipTos;

            var datalistShipTo = document.getElementById("datalistShipTo");
            if (shipTos != null) {
                for (var i = 0; i < shipTos.length; i++) {
                    var optionShipTo = document.createElement("option");
                    optionShipTo.value = shipTos[i].ShipToId + ". " + shipTos[i].Address1;
                    optionShipTo.innerHTML = shipTos[i].City + ", " + shipTos[i].State + " " + shipTos[i].Zip;
                    datalistShipTo.appendChild(optionShipTo);
                }
            }
            else {
                var blankOption = document.createElement("option");
                blankOption.value = "No Ship Tos";
                datalistShipTo.append(blankOption);
            }
        }
    }
}

function loadParts(aCustId) {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', apiAddress + 'api/Part/GetPartsForCustId/' + aCustId, true);
    xhr.send();

    xhr.onload = function () {
        if (xhr.status == 200) {
            var parts = JSON.parse(xhr.responseText);
            var datalistPartMaster = document.getElementById("datalistParts");
            if (parts != null) {
                datalistPartMaster.innerHTML = "";
                for (var i = 0; i < parts.length; i++) {
                    var option = document.createElement("option");
                    option.value = parts[i].PartName;
                    option.innerHTML = parts[i].Description;
                    option.dataset.partId = parts[i].PartId;
                    datalistPartMaster.appendChild(option);
                }
            }
            else {
                datalistPartMaster.innerHTML = "";
            }

            //All datalists for part need to be updated
            var datalistsPart = document.getElementsByClassName("datalist-part");
            for (var i = 0; i < datalistsPart.length; i++) {
                datalistsPart[i].innerHTML = datalistPartMaster.innerHTML;
            }

            //All part inputs need to be cleared
            var inputParts = document.getElementsByClassName("input-part");
            for (var i = 0; i < inputParts.length; i++) {
                inputParts[i].value = "";
            }
        }
    }
}

//ToDo: Clean up inputs and send them into the model! Almost there...
function postPart() {
    if (!validatePartPost()) {
        return; //validation failed
    }

    var name = document.getElementById("inputCreatePart-Name");
    var rev = document.getElementById("inputCreatePart-Rev");
    var description = document.getElementById("inputCreatePart-Description");
    var dimensions = document.getElementById("inputCreatePart-Dimensions");
    var rack = document.getElementById("selectCreatePart-Rack");
    var surfaceArea = document.getElementById("inputCreatePart-SurfaceArea");
    var uom = document.getElementById("selectCreatePart-UoM");
    var pieceWeight = document.getElementById("inputCreatePart-PieceWeight");
    var standardDept = document.getElementById("selectCreatePart-StandardDept");
    var bake = document.getElementById("inputCreatePart-Bake");
    var basePrice = document.getElementById("inputCreatePart-BasePrices");
    var minLotCharge = document.getElementById("inputCreatePart-MinLotCharge");
    var partsPerLoad = document.getElementById("inputCreatePart-PartsPerLoad");
    var maskPiecesPerHour = document.getElementById("inputCreatePart-MaskPiecesPerHour");
    var notifyWhenMasking = document.getElementById("inputCreatePart-NotifyWhenMasking");
    var alloy = document.getElementById("selectCreatePart-Alloy");
    var series = document.getElementById("selectCreatePart-Series");

    var partToPost =
    {
        PartId: 0,
        PartName: name.value,
        Inactive: false,
        ExternalRev: rev.value,
        Description: (description.value != "") ? description.value : null,
        Dimensions: (dimensions.value != "") ? dimensions.value : null,
        RackId: parseInt(rack.value),
        SurfaceArea: parseFloat(surfaceArea.value),
        SurfaceAreaUoMId: parseInt(uom.value),
        PieceWeight: parseFloat(pieceWeight.value),
        StandardDeptId: parseInt(standardDept.value),
        Bake: (bake.value != "") ? bake.value : null,
        BasePrice: parseFloat(basePrice.value),
        MinLotCharge: parseFloat(minLotCharge.value),
        PartsPerLoad: parseInt(partsPerLoad.value),
        MaskPcsPerHour: parseFloat(maskPiecesPerHour.value),
        NotifyWhenMasking: notifyWhenMasking.checked,
        MaterialAlloyId: parseInt(alloy.value),
        MaterialSeriesId: parseInt(series.value),
        CreatedByEmpId: 991,
        DateCreated: null,
        TimeCreated: null,
        Rack: null,
        SurfaceAreaUnitOfMeasure: null,
        Alloy: null,
        CreatedByEmp: null,
        Series: null,
        StandardDept: null
    };

    var partJson = JSON.stringify(partToPost);
    console.log(partJson);
    var customerId = document.getElementById("hdnCustomerId").value;
    var xhr = new XMLHttpRequest();
    xhr.open('POST', apiAddress + 'api/Part/CreatePartWithCustomerPart/' + customerId, true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify(partToPost));
    xhr.onload = function () {
        if (xhr.status == 200) {
            loadParts(customerId);
        }
        else {
            console.log(xhr.responseText);
        }
    }

    //Clearing out the modal inputs
    name.value = "";
    rev.value = "";
    description.value = "";
    dimensions.value = "";
    rack.value = "";
    surfaceArea.value = "";
    uom.value = "";
    pieceWeight.value = "";
    standardDept.value = "";
    bake.value = "";
    basePrice.value = "";
    minLotCharge.value = "";
    partsPerLoad.value = "";
    maskPiecesPerHour.value = "";
    notifyWhenMasking.value = "";
    alloy.value = "";
    series.value = "";

    $('#modalPartCreation').modal('hide');
}

function validatePartPost() {
    var isValid = true;
    var inputName = document.getElementById("inputCreatePart-Name");
    var inputRev = document.getElementById("inputCreatePart-Rev");

    if (inputName.value == "") {
        isValid = false;
        inputName.classList += " is-invalid";
    }

    if (inputRev.value == "") {
        isValid = false;
        inputRev.classList += " is-invalid";
    }

    return isValid;
}

function udpateShipToTextArea(shipToInput) {
    var shipToText = "";  //If the ship to in the input matches an option, this variable will be populated by the appropriate text.
    if (_shipToModels != undefined) {
        for (var i = 0; i < _shipToModels.length; i++) {
            if ((_shipToModels[i].ShipToId + ". " + _shipToModels[i].Address1) == shipToInput.value) {
                shipToText = _shipToModels[i].Address1 + "\r\n";
                if (_shipToModels[i].Address2 != "" && _shipToModels[i].Address2 != null) { shipToText += _shipToModels[i].Address2 + "\r\n"; }
                if (_shipToModels[i].Address3 != "" && _shipToModels[i].Address3 != null) { shipToText += _shipToModels[i].Address3 + "\r\n"; }
                shipToText += _shipToModels[i].City + ", " + _shipToModels[i].State + _shipToModels[i].Zip + _shipToModels[i].Country;
                if (_shipToModels[i].EmailAddress != "" && _shipToModels[i].EmailAddress != null) { shipToText += "\r\nEmail: " + _shipToModels[i].EmailAddress; }
                if (_shipToModels[i].PhoneNum != "" && shipToModels[i].PhoneNum != null) { shipToText += "\r\nPhone: " + _shipToModels[i].PhoneNum; }
                if (_shipToModels[i].FaxNum != "" && _shipToModels[i].FaxNum != null) { shipToText += "\r\nFax: " + _shipToModels[i].FaxNum; }
            }
        }

        var textareaShipTo = document.getElementById("textareaShipTo");
        textareaShipTo.value = shipToText;
        textareaShipTo.style.height = textareaShipTo.scrollHeight + 3 + "px";
    }
}

function addLineItem() { //ToDo: The inputs need to be sequenced and bound to a property somehow.

    var hdnLineItemCount = document.getElementById("hdnLineItemsCount");
    hdnLineItemCount.stepUp();
    var lineCount = hdnLineItemCount.value;

    //Line Number
    var lineTh = document.createElement("th");
    lineTh.scope = "row";
    lineTh.innerHTML = lineCount;

    //Qty
    var qtyInput = document.createElement("input");
    qtyInput.id = "inputLineItemQty" + lineCount;
    qtyInput.type = "number";
    qtyInput.step = 1;
    qtyInput.style = "box-sizing: border-box; width:100%;";

    var qtyTd = document.createElement("td");
    qtyTd.appendChild(qtyInput);

    //Part #
    var partNumInput = document.createElement("input");
    partNumInput.id = "inputLineItemPartNum" + lineCount;
    partNumInput.style = "box-sizing: border-box; width:100%;";
    partNumInput.setAttribute("list", "datalistPart" + lineCount);
    partNumInput.classList = "input-part";

    var createPartButton = document.createElement("button");
    createPartButton.type = "button";
    createPartButton.setAttribute('data-toggle', 'modal');
    createPartButton.setAttribute('href', '#modalPartCreation');
    createPartButton.classList = "btn btn-primary";
    createPartButton.innerHTML = "Create Part";

    var datalistPart = document.getElementById("datalistParts").cloneNode(true);
    datalistPart.classList = "datalist-part";
    datalistPart.id = "datalistPart" + lineCount;

    var partNumTd = document.createElement("td");
    partNumTd.appendChild(partNumInput);
    partNumTd.appendChild(datalistPart);

    //Description
    var descriptionInput = document.createElement("input");
    descriptionInput.id = "inputLineItemDescription" + lineCount;
    descriptionInput.type = "text";
    descriptionInput.style = "box-sizing: border-box; width:100%;";

    var descriptionTd = document.createElement("td");
    descriptionTd.appendChild(descriptionInput);

    //Unit Price
    var unitPriceInput = document.createElement("input");
    unitPriceInput.id = "inputLineItemPoPrice" + lineCount;
    unitPriceInput.type = "number";
    unitPriceInput.step = .01;
    unitPriceInput.style = "box-sizing: border-box; width:100%;";

    var unitPriceTd = document.createElement("td");
    unitPriceTd.appendChild(unitPriceInput);

    //The row
    var row = document.createElement("tr");
    row.appendChild(lineTh);
    row.appendChild(qtyTd);
    row.appendChild(partNumTd);
    row.appendChild(descriptionTd);
    row.appendChild(unitPriceTd);

    document.getElementById("tbodyLineItems").appendChild(row);
}