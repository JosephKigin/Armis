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
        newDiv.className = "row py-1 mb-1";
        newDiv.id = "divChoiceNameGroup" + cardNumber + "-" + count;

        var divFirstColumn = document.createElement("div");
        divFirstColumn.classList = "form-inline col-lg-4";

        var newCheckBox = document.createElement("input");
        newCheckBox.id = "chkDefaultChoice" + cardNumber + '-' + count;
        newCheckBox.title = "Default";
        newCheckBox.type = "checkbox";
        newCheckBox.classList = "mx-1";
        newCheckBox.name = "chkBoxGroupDefaultChoice" + cardNumber;
        newCheckBox.tabIndex = "-1";
        newCheckBox.value = (count * 1 + 1); //??
        newCheckBox.setAttribute("onclick", "ToggleCheckBoxes(this," + cardNumber + ")");
        newCheckBox.disabled = true;
        divFirstColumn.appendChild(newCheckBox);

        var newChoiceInput = document.createElement("input");
        newChoiceInput.id = "inputChoice" + cardNumber + "-" + count;
        newChoiceInput.dataset.choiceNumber = count;
        newChoiceInput.type = "text";
        newChoiceInput.name = "ChoiceList" + cardNumber + "[" + count + "].Description";
        newChoiceInput.classList = "form-control";
        newChoiceInput.style = "width: 90%;";
        newChoiceInput.setAttribute("onchange", "ToggleCheckBoxDisabled(this," + cardNumber + ")");
        newChoiceInput.setAttribute("onkeydown", "return event.key != 'Enter'");
        newChoiceInput.maxLength = "50";
        divFirstColumn.appendChild(newChoiceInput);
        newDiv.appendChild(divFirstColumn);

        var deleteIcon = document.createElement("i");
        deleteIcon.classList = "fa fa-trash-alt ml-1";

        var newDeleteAnchor = document.createElement("a");
        newDeleteAnchor.id = "iconChoiceDelete" + cardNumber + "-" + count;
        newDeleteAnchor.classList = "col-lg-1";
        newDeleteAnchor.dataset.cardNumber = cardNumber;
        newDeleteAnchor.dataset.choice = count;
        newDeleteAnchor.setAttribute("onclick", "DeleteChoiceInput(this.dataset.cardNumber, this.dataset.choice)");
        newDeleteAnchor.appendChild(deleteIcon);

        var stepDiv = document.createElement("div");
        stepDiv.classList = "form-inline col-lg-4";

        var stepButton = document.createElement("button");
        stepButton.type = "button";
        stepButton.classList = "btn btn-primary mr-1";
        stepButton.setAttribute("onclick", "OpenStepModal( " + cardNumber + ", " + count + ")");
        stepButton.innerHTML = "Step";
        stepDiv.appendChild(stepButton);

        var stepInput = document.createElement("input");
        stepInput.id = "inputStepOutput" + cardNumber + "-" + count;
        stepInput.classList = "form-control w-75";
        stepInput.disabled = true;
        stepDiv.appendChild(stepInput);

        var hdnStepIdInput = document.createElement("input");
        hdnStepIdInput.id = "hdnStepId" + cardNumber + "-" + count;
        hdnStepIdInput.type = "hidden";
        hdnStepIdInput.name = "ChoiceList" + cardNumber + "[" + count + "].ReferenceStepId";
        stepDiv.appendChild(hdnStepIdInput);

        newDiv.appendChild(stepDiv);

        var dependentDiv = document.createElement("div");
        dependentDiv.classList = "form-inline col-lg-4";

        var dependentButton = document.createElement("button");
        dependentButton.type = "button";
        dependentButton.classList = "btn btn-primary mx-1";
        dependentButton.setAttribute("onclick", "BuildDependentModal(" + cardNumber + ", " + count + ")");
        dependentButton.innerHTML = "Dependent";
        dependentDiv.appendChild(dependentButton);

        var dependentInput = document.createElement("input");
        dependentInput.id = "inputDependentOutput" + cardNumber + "-" + count;
        dependentInput.classList = "form-control";
        dependentInput.style = "width: 65%";
        dependentInput.disabled = true;
        dependentDiv.appendChild(dependentInput);

        dependentDiv.appendChild(newDeleteAnchor);

        var hdnDependentSublevelInput = document.createElement("input");
        hdnDependentSublevelInput.type = "hidden";
        hdnDependentSublevelInput.id = "hdnDependentSublevel" + cardNumber + "-" + count;
        hdnDependentSublevelInput.name = "ChoiceList" + cardNumber + "[" + count + "].DependentSubLevelId";
        dependentDiv.appendChild(hdnDependentSublevelInput);

        var hdnDependentChoiceInput = document.createElement("input");
        hdnDependentChoiceInput.type = "hidden";
        hdnDependentChoiceInput.id = "hdnDependentChoice" + cardNumber + "-" + count;
        hdnDependentChoiceInput.name = "ChoiceList" + cardNumber + "[" + count + "].OnlyValidForChoiceId"
        dependentDiv.appendChild(hdnDependentChoiceInput);

        newDiv.appendChild(dependentDiv);

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
        if (allInputElements[i].id == "inputBtnRevUp" || allInputElements[i].id == "inputSpecCode" || allInputElements[i].id == inputSamplePlanName || allInputElements[i].id.startsWith("inputStepOutput")
            || allInputElements[i].id.startsWith("inputDependentOutput")) //Rev-up button, Spec Code, sample plan name, step name, and dependency name get/stay readonly when rev-up is clicked.
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

    var allSelectElements = document.body.getElementsByTagName("select");
    for (var i = 0; i < allSelectElements.length; i++) {
        allSelectElements[i].disabled = false;
    }
}

//Opens the step modal and updates the hidden fields for what sublevel and choice should be updated from the step modal.
function OpenStepModal(aCardNumber, aChoiceNum) {
    var filterCategory = document.getElementById("slctStepCategory" + aCardNumber).value;

    if (filterCategory == "") {
        document.getElementById("spanStepCategoryWarning" + aCardNumber).hidden = false;
    }
    else {
        document.getElementById("spanStepCategoryWarning" + aCardNumber).hidden = true;

        document.getElementById("hdnModalStepSublevelToUpdate").value = aCardNumber;
        document.getElementById("hdnModalStepChoiceToUpdate").value = aChoiceNum;

        var stepList = document.getElementById("slctAllSteps");
        var stepListItems = stepList.getElementsByTagName("option");

        for (var i = 0; i < stepListItems.length; i++) {
            if (stepListItems[i].dataset.category == filterCategory) {
                stepListItems[i].style.display = "block";
            }
            else {
                stepListItems[i].style.display = "none";
            }
        }


        $("#modalSteps").modal("show");
    }
}

//Updates sublevel choices with step selected from step modal
function UpdateChoiceStep() {
    var sublevel = document.getElementById("hdnModalStepSublevelToUpdate").value;
    var choice = document.getElementById("hdnModalStepChoiceToUpdate").value;

    var slctAllSteps = document.getElementById("slctAllSteps");
    var option = slctAllSteps.options[slctAllSteps.selectedIndex];

    document.getElementById("hdnStepId" + sublevel + "-" + choice).value = option.value;
    document.getElementById("inputStepOutput" + sublevel + "-" + choice).value = option.dataset.stepName;

    $("#modalSteps").modal("hide");
}

//Creates a modal, wipes out the dependency modal placeholder div, adds newly created modal into that div, and then opens the modal
function BuildDependentModal(aCardNumber, aChoiceNum) { //Parameters are the sublevel and choice to update with what is selected.
    var divCardInBody = document.createElement("div");
    divCardInBody.classList = "card p-3";

    var hdnDependentSublevel = document.createElement("input"); ///Hidden inputs to hold the values of the sublevel and choice the dependency is being applied to
    hdnDependentSublevel.id = "hdnDependencyModalSublevel"; //The sublevel to update
    hdnDependentSublevel.type = "hidden";
    hdnDependentSublevel.value = aCardNumber;
    divCardInBody.appendChild(hdnDependentSublevel);
    var hdnDependentChoice = document.createElement("input");
    hdnDependentChoice.id = "hdnDependencyModalChoice"; //The choice to update.
    hdnDependentChoice.type = "hidden";
    hdnDependentChoice.value = aChoiceNum;
    divCardInBody.appendChild(hdnDependentChoice);

    var amntOfSublevel = aCardNumber - 1; //The amount of sublevels above the one sent in.  EX: Sublevel 3 can be dependent on 2 & 1.

    for (var i = 1; i <= amntOfSublevel; i++) { //Sublevels start at 1
        var divSublevelSection = document.createElement("div");
        var hSublevelTitle = document.createElement("h6");

        hSublevelTitle.innerHTML = document.getElementById("inputSublevelName" + i).value;
        divSublevelSection.appendChild(hSublevelTitle);

        var ulChoices = document.createElement("ul");

        var choiceCount = document.getElementById("choiceCount" + i).value;
        for (var j = 0; j < choiceCount; j++) {//Choices start at 0 to keep indexing correct for model binding
            if (document.getElementById("inputChoice" + i + "-" + j).value != "") { //If the choice doesn't have text, then it cannot be selected.
                var liChoice = document.createElement("li");

                liChoice.innerHTML = document.getElementById("inputChoice" + i + "-" + j).value;

                var chkboxChoice = document.createElement("input");
                chkboxChoice.type = "checkbox";
                chkboxChoice.id = "chkboxDependentModalChoice" + i + "-" + j;
                chkboxChoice.classList = "ml-1"
                chkboxChoice.dataset.sublevelNumber = i;
                chkboxChoice.dataset.sublevelName = hSublevelTitle.innerHTML;
                chkboxChoice.dataset.choiceNumber = (j + 1); //This is the value that will make it to the model where the choices start at 1; j starts at 0.
                chkboxChoice.dataset.choiceName = liChoice.innerHTML;
                chkboxChoice.setAttribute("onclick", "ToggleDependencyModalCheckBoxes(this)");
                liChoice.appendChild(chkboxChoice);

                ulChoices.appendChild(liChoice);
            }

        }

        divSublevelSection.appendChild(ulChoices);

        divCardInBody.appendChild(divSublevelSection);
    }

    var divModalBody = document.createElement("div"); //Body of the modal
    divModalBody.classList = "modal-body";
    divModalBody.appendChild(divCardInBody);

    var submitButton = document.createElement("button");
    submitButton.id = "btnSubmitDependencyModal";
    submitButton.type = "button";
    submitButton.innerHTML = "Ok";
    submitButton.classList = "btn btn-primary float-right mt-1 mr-3";
    submitButton.setAttribute("onclick", "UpdateDependencyFromModal()");
    submitButton.disabled = true;
    divModalBody.appendChild(submitButton);

    var divModalHeader = document.createElement("div");  //Header and title of modal
    divModalHeader.classList = "modal-header";
    var hMainTitle = document.createElement("h5");
    hMainTitle.classList = "modal-title";
    hMainTitle.innerHTML = "Choose a Dependency";
    divModalHeader.appendChild(hMainTitle);

    var divModalContent = document.createElement("div"); //Content of the modal, a.k.a. the body and header sections
    divModalContent.classList = "modal-content";
    divModalContent.appendChild(divModalHeader);
    divModalContent.appendChild(divModalBody);

    var divModalContainer = document.createElement("div"); //The container and most of the styling for inside of the modal
    divModalContainer.classList = "modal-dialog";
    divModalContainer.appendChild(divModalContent);

    var divModal = document.createElement("div");
    divModal.classList = "modal fade";
    divModal.id = "dependencyModal"; //It won't need a more unique ID than this because this method will be the only place where to modal is opened.
    divModal.appendChild(divModalContainer);

    var divPlaceHolder = document.getElementById("dependencyModalPlaceHolder");
    divPlaceHolder.innerHTML = "";
    divPlaceHolder.appendChild(divModal);

    $("#dependencyModal").modal("show");
}

function ToggleDependencyModalCheckBoxes(aCheckBox) {
    var allCheckBoxes = document.getElementById("dependencyModal").getElementsByTagName("input");

    for (var i = 0; i < allCheckBoxes.length; i++) {
        if (allCheckBoxes[i] != aCheckBox) {
            allCheckBoxes[i].checked = false;
        }
        else {
            if (aCheckBox.checked) {
                document.getElementById("btnSubmitDependencyModal").disabled = false;
            }
            else {
                document.getElementById("btnSubmitDependencyModal").disabled = true;
            }
        }
    }
}

function UpdateDependencyFromModal() {
    var choiceToUpdate = document.getElementById("hdnDependencyModalChoice").value;
    var sublevelToUpdate = document.getElementById("hdnDependencyModalSublevel").value;

    var theSelectedDependency;
    //Find selected checkbox
    var allDependencyModalCheckBoxes = document.getElementById("dependencyModal").getElementsByTagName("input");
    console.log(allDependencyModalCheckBoxes);
    for (var i = 0; i < allDependencyModalCheckBoxes.length; i++) {
        if (allDependencyModalCheckBoxes[i].checked) {
            theSelectedDependency = allDependencyModalCheckBoxes[i];
        }
    }

    document.getElementById("hdnDependentSublevel" + sublevelToUpdate + "-" + choiceToUpdate).value = theSelectedDependency.dataset.sublevelNumber;
    document.getElementById("hdnDependentChoice" + sublevelToUpdate + "-" + choiceToUpdate).value = theSelectedDependency.dataset.choiceNumber;

    document.getElementById("inputDependentOutput" + sublevelToUpdate + "-" + choiceToUpdate).value = "'" + theSelectedDependency.dataset.sublevelName + "'" + " - " + "'" + theSelectedDependency.dataset.choiceName + "'";
    $("#dependencyModal").modal("hide");
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

        var divChoiceCols = remainingChoiceDivGroups[i].children; //There will be 3 cols: check box + name, step button and step, and dependent + dependent name

        var divChoiceName = divChoiceCols[0]; //Check box and choice name input need to be updated
        var divStep = divChoiceCols[1]; //Steps button, step name input, and hidden step id input need to be updated
        var divDependent = divChoiceCols[2]; //Dependent button, dependent name button, hidden dependent sublevel id, hidden dependent choice id, and the delete choice anchor at the end of the line

        var divChoiceInputs = divChoiceName.getElementsByTagName("input");
        //0. checkbox
        divChoiceInputs[0].id = "chkDefaultChoice" + aCardNumber + "-" + i;
        //1. choice name input
        divChoiceInputs[1].id = "inputChoice" + aCardNumber + "-" + i;
        divChoiceInputs[1].name = "ChoiceList" + aCardNumber + "[" + i + "].Description";

        var divStepElements = divStep.children;
        //0. Button
        divStepElements[0].data.choiceNumber = i;
        //1. Step name input
        divStepElements[1].id = "inputStepOutput" + aCardNumber + "-" + i;
        //2. Hidden step id input
        divStepElements[2].id = "hdnStepId" + aCardNumber + "-" + i;
        divStepElements[2].name = "ChoiceList" + aCardNumber + "[" + i + "].ReferenceStepId";

        var divDependentElements = divDependent.children;
        //0. Dependent button
        divDependentElements[0].dataset.choiceNumber = i;
        //1. Dependent display input
        divDependentElements[1].id = "inputDependentOutput" + aCardNumber + "-" + i;
        //2. Dependent sublevel id hidden input
        divDependentElements[2].id = "hdnDependentSublevel" + aCardNumber + "-" + i;
        divDependentElements[2].name = "ChoiceList" + aCardNumber + "[" + i + "].DependentSubLevelId";
        //3. Dependent choice id hidden input
        divDependentElements[3].id = "hdnDependentChoice" + aCardNumber + "-" + i;
        divDependentElements[3].name = "ChoiceList" + aCardNumber + "[" + i + "].OnlyValidForChoiceId";
        //4. Delete anchor 
        divDependentElements[4].id = "iconChoiceDelete" + aCardNumber + "-" + i;
        divDependentElements[4].dataset.choice = i;


        //for (var j = 0; j < divChoiceItems.length; j++) {
        //    if (divChoiceItems[j].nodeName == "INPUT") { //This is checking for the main choice name.
        //        if (divChoiceItems[j].type == "text") {
        //            divChoiceItems[j].id = "inputChoice" + aCardNumber + "-" + i;
        //            divChoiceItems[j].name = "ChoiceNames" + aCardNumber + "[" + i + "]";
        //            divChoiceItems[j].dataset.choiceNumber = i;
        //        }
        //        else if (divChoiceItems[j].type == "checkbox") { //The default checkbox
        //            divChoiceItems[j].id = "chkDefaultChoice" + aCardNumber + "-" + i;
        //            divChoiceItems[j].value = i;
        //        }
        //    }
        //    else {
        //        divChoiceItems[j].id = "iconChoiceDelete" + aCardNumber + "-" + i;
        //        divChoiceItems[j].dataset.choice = i;
        //    }
        //}

    }
}

function validateMainPage() {
    var isValid = true;
    //Top section
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

    if (!validateChoiceCard(document.getElementById("cardChoice1"))) { isValid = false; }
    if (!validateChoiceCard(document.getElementById("cardChoice2"))) { isValid = false; }
    if (!validateChoiceCard(document.getElementById("cardChoice3"))) { isValid = false; }
    if (!validateChoiceCard(document.getElementById("cardChoice4"))) { isValid = false; }
    if (!validateChoiceCard(document.getElementById("cardChoice5"))) { isValid = false; }
    if (!validateChoiceCard(document.getElementById("cardChoice6"))) { isValid = false; }

    return isValid;
}

function validateChoiceCard(aChoiceCard) {
    var cardInputs = aChoiceCard.getElementsByTagName("input"); //All the inputs from card
    var isSubLevelNameFilled = false; //If sublevel name is filled in, this will be true.
    var isChoiceFilled = false; //If at lease 1 choice name is filled in, this will be true TODO: If any choice is blank, this is should be false.
    var areAllChoicesFilled = true;

    //Iterating through the inputs
    for (var i = 0; i < cardInputs.length; i++) {
        //Finds the sublevel name input
        if (cardInputs[i].id.startsWith("inputSublevelName")) {
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

    console.log();
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

function searchSamplePlanList(searchTerm) {
    var samplePlans = document.getElementById("listAllSamplePlans").getElementsByTagName("li");

    for (var i = 0; i < samplePlans.length; i++) {
        if (samplePlans[i] != undefined) {
            if (!samplePlans[i].dataset.samplePlanName.toLowerCase().includes(searchTerm.toLowerCase())) {
                samplePlans[i].hidden = true;
            }
            else {
                samplePlans[i].hidden = false;
            }
        }

    }
}

function updateSamplePlanInputs() {
    var theRadios = document.getElementsByName("samplePlanRadios");

    for (var i = 0; i < theRadios.length; i++) {
        if (theRadios[i].checked) {
            document.getElementById("hdnSamplePlanId").value = theRadios[i].value;
            document.getElementById("inputSamplePlanName").value = theRadios[i].dataset.planName;
        }
    }
}

//Next two functions are for setting up the page.
function UpdateDefaultChoiceSpanOnPageLoad() {
    for (var i = 0; i < 6; i++) { //Go through each of the 6 cards
        var divChoiceSectionItems = document.getElementById("choiceInputPlaceholder" + (i + 1)).children;

        for (var s = 0; s < divChoiceSectionItems.length; s++) { //Go through each row of choice name divs that contains the choice name input, isDault checkbox, and the icon to delete
            var divChoiceRowItems = divChoiceSectionItems[s].children;

            for (var r = 0; r < divChoiceRowItems.length; r++) {
                if (divChoiceRowItems[r].type == "text") {
                    ToggleCheckBoxDisabled(divChoiceRowItems[r], (i + 1));
                }
            }
        }

    }
}

function DisablePage() {
    var allInputElements = document.body.getElementsByTagName("input");
    for (var i = 0; i < allInputElements.length; i++) {
        //Ignore the Rev-Up button (which is actually an input of type button) getting disabled.
        //Also ignore Find Spec button, and spec search input.
        if (allInputElements[i].id != "inputBtnRevUp" && allInputElements[i].id != "btnFindSpec" && allInputElements[i].id != "hdnCurrentSpecId" && allInputElements[i].id != "inputSpecSearch") { allInputElements[i].disabled = true; }
    }

    var allAnchorElements = document.body.getElementsByTagName("a");
    for (var i = 0; i < allAnchorElements.length; i++) {
        //Ignore all anchors that have either "navbar-brand" or "nav-link text-dark" as class names. These classes are only used in the layout navigation bar in the header.
        //Also ignore the clear button on the bottom of the page
        if (!allAnchorElements[i].className.includes("nav-link") && !allAnchorElements[i].className.includes("navbar-brand") && !allAnchorElements[i].className.includes("dropdown-item") && !allAnchorElements[i].className.includes("dropdown-toggle") && allAnchorElements[i].id != "btnClearPage") { allAnchorElements[i].hidden = true; }
    }

    var allButtonElements = document.body.getElementsByTagName("button");
    for (var i = 0; i < allButtonElements.length; i++) {
        //Ignore the select button in the modal for finding a spec
        if (allButtonElements[i].id != "btnSelectSpec") {
            if (allButtonElements[i].id.startsWith("btnAddChoice")) {
                allButtonElements[i].hidden = true;
            }
            else {
                allButtonElements[i].disabled = true;
            }
        }
    }

    var allSelectElements = document.body.getElementsByTagName("select");
    for (var i = 0; i < allSelectElements.length; i++) {
        if (allSelectElements[i].id.startsWith("slctStepCategory")) {
            allSelectElements[i].disabled = true;
        }
    }
}

function UpdateStepCategorySelect(aCardNumber, aCategoryId) {
    var categoryOptions = document.getElementById("slctStepCategory" + aCardNumber).getElementsByTagName("option");

    for (var i = 0; i < categoryOptions.length; i++) {
        if (categoryOptions[i].value == aCategoryId) {
            categoryOptions[i].selected = true;
        }
    }
}