function AddChoiceInput(cardNumber) {
    var count = document.getElementById("choiceCount" + cardNumber).value;
    var areAllPreviousInputsFilled = true;
    var theBlankInputToFocus = null;
    for (var i = 0; i < count; i++) {
        var inputToCheckForBlank = document.getElementById('inputChoice' + cardNumber + '-' + (i));
        if (inputToCheckForBlank.value == "") {
            areAllPreviousInputsFilled = false;
            theBlankInputToFocus = inputToCheckForBlank;
        }
    }


    //lastInputAdded.value won't get checked if the lastInpuitAdded is undefined.
    if (areAllPreviousInputsFilled) {
        var newDiv = document.createElement("div");
        newDiv.className = "form-inline";
        newDiv.id = "divChoiceNameGroup" + cardNumber + "-" + count;

        var newCheckBox = '<input id="chkDefaultChoice' + cardNumber + '-' + count + '" title="Default" type="checkbox" class="mx-1" name="chkBoxGroupDefaultChoice' + cardNumber + '" tabindex="-1"  value="' + (count * 1 + 1) + '" onclick="ToggleCheckBoxes(this, ' + cardNumber + ')" disabled/>';
        newDiv.innerHTML += newCheckBox;

        var newChoiceInput = '<input id="inputChoice' + cardNumber + '-' + count + '" data-choice-number=' + count + ' type="text" name="ChoiceNames' + cardNumber + '[' + count + ']" class="form-control col-lg-10" onkeyup="ToggleCheckBoxDisabled(this,' + cardNumber + ')" onkeydown="return event.key != `Enter`;"  maxlength="50"/>';
        newDiv.innerHTML += newChoiceInput;

        var newDeleteAnchor = '<a id="iconChoiceDelete' + cardNumber + '-' + count + '" data-card-number="' + cardNumber + '" data-choice="' + count + '" onclick="DeleteChoiceInput(this.dataset.cardNumber, this.dataset.choice)"> <i class="fa fa-trash-alt ml-1"></i> </a>';
        newDiv.innerHTML += newDeleteAnchor;

        document.getElementById("choiceInputPlaceholder" + cardNumber).appendChild(newDiv);
        document.getElementById('inputChoice' + cardNumber + '-' + (count)).focus();

        document.getElementById("choiceCount" + cardNumber).value++;
    }
    else {
        theBlankInputToFocus.focus();
    }

}

function ToggleCheckBoxes(chkBox, cardNumber) {
    var checkBoxes = document.getElementsByName(chkBox.name);

    for (var i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i] != chkBox) {
            checkBoxes[i].checked = false;
        }
    }

    //When a checkbox is checked, a hidden input field is updated with the value of that checkbox so the back end model can access that information more easily.
    if (chkBox.checked) {
        document.getElementById("defaultChoice" + cardNumber).value = chkBox.value;
        document.getElementById("spanDefaultText" + cardNumber).innerHTML = "(" + document.getElementById("inputChoice" + cardNumber + "-" + (chkBox.value - 1)).value + " is default)";
    }
    else {
        document.getElementById("defaultChoice" + cardNumber).value = '';
        document.getElementById("spanDefaultText" + cardNumber).innerHTML = "(No default selected)";
    }
}

function ToggleCheckBoxDisabled(anInput, aCardNumber) {
    var theCheckBox = document.getElementById("chkDefaultChoice" + aCardNumber + "-" + anInput.dataset.choiceNumber);
    if (anInput.value.trim() == "") {
        if (theCheckBox.checked) {
            document.getElementById("spanDefaultText" + aCardNumber).innerHTML = "(No default selected)";
        }
        theCheckBox.checked = false;
        theCheckBox.disabled = true;

    }
    else {
        theCheckBox.disabled = false;
    }

    if (theCheckBox.checked) {
        document.getElementById("spanDefaultText" + aCardNumber).innerHTML = "(" + anInput.value + " is default)";
    }
}

function ApplyRevUpStatus() { //This sets the rev-up status to true and activates all input fields and buttons and unhides all anchors.
    document.getElementById("chkRevUpSelected").checked = true;

    var allInputElements = document.getElementsByTagName("input");
    for (var i = 0; i < allInputElements.length; i++) {
        allInputElements[i].disabled = false;
        if (allInputElements[i].id == "inputBtnRevUp" || allInputElements[i].id == "inputSpecCode") //Rev-up button and Spec Code get/stay disabled when rev-up is clicked.
        { allInputElements[i].readOnly = true; }
    }

    var allAnchorElements = document.getElementsByTagName("a");
    for (var i = 0; i < allAnchorElements.length; i++) {
        allAnchorElements[i].hidden = false;
    }

    var allButtonElements = document.getElementsByTagName("button");
    for (var i = 0; i < allButtonElements.length; i++) {
        allButtonElements[i].disabled = false;
        allButtonElements[i].hidden = false;
    }
}

function DeleteChoiceInput(aCardNumber, aGroupChoiceNum) {
    var divChoiceGroupToRemove = document.getElementById("divChoiceNameGroup" + aCardNumber + "-" + aGroupChoiceNum);

    if (document.getElementById("chkDefaultChoice" + aCardNumber + "-" + aGroupChoiceNum).checked == true) {
        document.getElementById("spanDefaultText" + aCardNumber).innerHTML = "(No default selected)";
    }

    divChoiceGroupToRemove.parentNode.removeChild(divChoiceGroupToRemove);
    document.getElementById("choiceCount" + aCardNumber).value--;

    var remainingChoiceDivGroups = document.getElementById("choiceInputPlaceholder" + aCardNumber).children;
    for (var i = 0; i < remainingChoiceDivGroups.length; i++) {
        remainingChoiceDivGroups[i].id = "divChoiceNameGroup" + aCardNumber + "-" + i;

        var divChoiceItems = remainingChoiceDivGroups[i].children;
        for (var j = 0; j < divChoiceItems.length; j++) {
            if (divChoiceItems[j].nodeName == "INPUT") {
                if (divChoiceItems[j].type == "text") {
                    divChoiceItems[j].id = "inputChoice" + aCardNumber + "-" + i;
                    divChoiceItems[j].name = "ChoiceNames" + aCardNumber + "[" + i + "]";
                    divChoiceItems[j].dataset.choiceNumber = i;
                }
                else {
                    divChoiceItems[j].id = "chkDefaultChoice" + aCardNumber + "-" + i;
                    divChoiceItems[j].value = i;
                }
            }
            else {
                divChoiceItems[j].id = "iconChoiceDelete" + aCardNumber + "-" + i;
                divChoiceItems[j].dataset.choice = i;
            }
        }

    }
}

function validateMainPage() {
    var isValid = true;
    var theSpecCodeInput = document.getElementById("inputSpecCode");
    var theSpecRev = document.getElementById("inputNewExternalRev");
    var theSpecDescription = document.getElementById("textAreaSpecDescription");

    if (theSpecCodeInput.value == "") {
        theSpecCodeInput.classList = "form-control border-danger border-right-0";
        document.getElementById("iconInvalidSpecCode").hidden = false;
        isValid = false;
    }
    else {
        theSpecCodeInput.classList = "form-control";
        document.getElementById("iconInvalidSpecCode").hidden = true;
    }

    if (theSpecRev.value == "") {
        theSpecRev.classList = "form-control border-danger border-right-0";
        document.getElementById("iconInvalidSpecRev").hidden = false;
        isValid = false;
    }
    else {
        theSpecRev.classList = "form-control";
        document.getElementById("iconInvalidSpecRev").hidden = true;
    }

    if (theSpecDescription.value == "") {
        theSpecDescription.classList = "form-control border-danger border-right-0";
        document.getElementById("iconInvalidSpecDesc").hidden = false;
        isValid = false;
    }
    else {
        theSpecDescription.classList = "form-control";
        document.getElementById("iconInvalidSpecDesc").hidden = true;
    }

    if (!validatChoiceCard(document.getElementById("cardChoice1"))) { isValid = false; }
    if (!validatChoiceCard(document.getElementById("cardChoice2"))) { isValid = false; }
    if (!validatChoiceCard(document.getElementById("cardChoice3"))) { isValid = false; }
    if (!validatChoiceCard(document.getElementById("cardChoice4"))) { isValid = false; }
    if (!validatChoiceCard(document.getElementById("cardChoice5"))) { isValid = false; }
    if (!validatChoiceCard(document.getElementById("cardChoice6"))) { isValid = false; }
    if (isValid) {
        $("#modalSamplePlan").modal("show");
    }
}

function validatChoiceCard(aChoiceCard) {
    var cardInputs = aChoiceCard.getElementsByTagName("input"); //All the inputs from card
    var isSubLevelNameFilled = false; //If sublevel name is filled in, this will be true.
    var isChoiceFilled = false; //If at lease 1 choice name is filled in, this will be true TODO: If any choice is blank, this is should be false.
    var areAllChoicesFilled = true;

    //Iterating through the inputs
    for (var i = 0; i < cardInputs.length; i++) {
        //Finds the sublevel name input
        if (cardInputs[i].id.startsWith("SubLevelName")) {
            if (cardInputs[i].value != undefined && cardInputs[i].value.trim() != "") { isSubLevelNameFilled = true; }
            else { isSubLevelNameFilled = false; }
        }

        //Finds the choice name inputs only if a choice name that has been filled has not been found yet.

        if (cardInputs[i].id.startsWith("inputChoice")) {
            if (!isChoiceFilled) {
                if (cardInputs[i].value != undefined && cardInputs[i].value.trim() != "") { isChoiceFilled = true; }
                else { isChoiceFilled = false; }
            }

            if (cardInputs[i].value == undefined || cardInputs[i].value.trim() == "") {
                areAllChoicesFilled = false;
            }
        }
    }

    if ((isSubLevelNameFilled == isChoiceFilled) && areAllChoicesFilled) {
        aChoiceCard.classList = "card p-3";
        aChoiceCard.getElementsByClassName("fa fa-times-circle")[0].hidden = true;
        return true;
    }
    else {
        aChoiceCard.classList = "card p-3 border-danger";
        aChoiceCard.getElementsByClassName("fa fa-times-circle")[0].hidden = false;
        return false;
    }
}

function searchSpecList(searchInput) {
    var searchTerm = searchInput.value.toUpperCase();
    var processList = document.getElementById("specList");
    var processListItems = processList.getElementsByTagName("option");

    for (var i = 0; i < processListItems.length; i++) {
        if (!processListItems[i].textContent.toUpperCase().includes(searchTerm)) {
            processListItems[i].style.display = "none";
        }
        else {
            processListItems[i].style.display = "block";
        }
    }
}