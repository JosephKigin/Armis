//These are scripts that are on the page once, and only once.
function searchProcessList(searchTerm) {
    var processes = document.getElementById("selectAllProcesses").getElementsByTagName("option");
    for (var i = 0; i < processes.length; i++) {
        if (processes[i] != undefined) {
            if (processes[i].dataset.processName.toLowerCase().includes(searchTerm.toLowerCase())) {
                processes[i].style.display = "block";
            }
            else {
                processes[i].style.display = "none";
            }
        }
    }
}

function searchStepList(searchTerm) {
    var steps = document.getElementById("sortableAllSteps").getElementsByTagName("li");

    for (var i = 0; i < steps.length; i++) {
        if (steps[i] != undefined) {
            if (!steps[i].dataset.stepName.toLowerCase().includes(searchTerm.toLowerCase())) {
                steps[i].hidden = true;
            }
            else {
                steps[i].hidden = false;
            }
        }

    }
}

//Assigns a seq number to all the steps.  This is called when a step is moved, deleted, or added.  This method checks what order the steps are in and then assigns the "name"(asp-for) attribute to CurrentStepIds, which is a list.  The list is submitted when "lock" or "save" are clicked.
function assignStepSeqNumbers() {
    var currentStepListItems = document.getElementById("sortableCurrentSteps").getElementsByTagName("li");
    var doAllStepsHaveOper = true;

    if (currentStepListItems.length == 0) { //Checks if there aren't any steps.
        submitButtonsValidationResponse(false, "Cannot Lock or Save without any steps");
    }
    else {
        submitButtonsValidationResponse(true, "");

        for (var i = 0; i < currentStepListItems.length; i++) { //Iterates through steps. If a step doesn't have an operation, doAllStepsHaveOper is set to false.
            currentStepListItems[i].id = currentStepListItems[i].id.substring(0, (currentStepListItems[i].id.indexOf("-") + 1)) + i;

            var currentStepIdInput = currentStepListItems[i].getElementsByTagName("input")[0];
            currentStepIdInput.id = currentStepIdInput.id.substring(0, currentStepIdInput.id.indexOf("-") + 1) + i;
            currentStepIdInput.name = "CurrentStepIds[" + i + "]";

            var currentStepOperInput = currentStepListItems[i].getElementsByTagName("input")[1];
            currentStepOperInput.id = currentStepOperInput.id.substring(0, currentStepOperInput.id.indexOf("-") + 1) + i;
            currentStepOperInput.name = "CurrentOperationIds[" + i + "]";
            if (currentStepOperInput.value == "") { doAllStepsHaveOper = false; }

            var currentStepSeqInput = currentStepListItems[i].getElementsByTagName("input")[2];
            currentStepSeqInput.id = currentStepSeqInput.id.substring(0, currentStepSeqInput.id.indexOf("-") + 1) + i;
            currentStepSeqInput.value = i;

            //Collapse Anchor, Operation Anchor, collapsable div
            var theAnchors = currentStepListItems[i].getElementsByTagName("a");

            //This just finds the "-" and replaces the number after it, which is the the seq number
            theAnchors[0].dataset.target = theAnchors[0].dataset.target.substring(0, (theAnchors[0].dataset.target.indexOf("-") + 1)) + i; //Update anchor collapse data target
            theAnchors[0].id = theAnchors[0].id.substring(0, (theAnchors[0].id.indexOf("-") + 1)) + i;
            theAnchors[1].id = theAnchors[1].id.substring(0, (theAnchors[1].id.indexOf("-") + 1)) + i;
            //Finds the collapsable details div on the step and replaces to seq number
            for (var j = 0; j < currentStepListItems[i].childNodes.length; j++) {
                if (currentStepListItems[i].childNodes[j].id != undefined) {
                    if (currentStepListItems[i].childNodes[j].id.startsWith("currentStepDetails_")) {
                        var detailsDivId = currentStepListItems[i].childNodes[j].id;
                        currentStepListItems[i].childNodes[j].id = detailsDivId.substring(0, (detailsDivId.indexOf("-") + 1)) + i;
                    }
                }
            }
        }

        if (doAllStepsHaveOper) {
            submitButtonsValidationResponse(true, "");
        }
        else {
            submitButtonsValidationResponse(false, "Every step needs to have an operation to lock or save.");
        }
    }
}

//Sets the Lock and Save buttons to enabled/disabled if the page is/isn't valid. The page is invalid if there aren't any steps in Current Steps or if not all steps have an operation.
function submitButtonsValidationResponse(isValid, aMessage) {
    if (isValid) {
        var btnSave = document.getElementById("btnSave");
        btnSave.disabled = false;
        btnSave.classList.remove('btn-ouline-primary');
        btnSave.classList.add('btn-primary');

        var btnLock = document.getElementById("btnLock");
        btnLock.disabled = false;
        btnLock.classList.remove('btn-outline-primary');
        btnLock.classList.add('btn-primary');

        document.getElementById("btnMessage").innerHTML = "";
    }
    else {
        var btnSave = document.getElementById("btnSave");
        btnSave.disabled = true;
        btnSave.classList.remove('btn-primary');
        btnSave.classList.add('btn-outline-primary');

        var btnLock = document.getElementById("btnLock");
        btnLock.disabled = true;
        btnLock.classList.remove('btn-primary');
        btnLock.classList.add('btn-outline-primary');

        document.getElementById("btnMessage").innerHTML = aMessage;
    }
}

function openOperationModal(aStepDetails, aStepName) {
    $("#modalOperationSelect").modal("show");
    var theStepId = aStepDetails.id.substring((aStepDetails.id.indexOf("_") + 1), (aStepDetails.id.indexOf("-")));
    var theStepSeq = aStepDetails.id.substring(aStepDetails.id.indexOf("-") + 1);

    document.getElementById("operationModalStepTitle").innerHTML = aStepName;
    document.getElementById("opModalStepIdPlaceholder").value = theStepId;
    document.getElementById("opModalStepSeqPlaceholder").value = theStepSeq;
}

function addToCurrentOperations() {
    var theStepId = document.getElementById("opModalStepIdPlaceholder").value;
    var theStepSeq = document.getElementById("opModalStepSeqPlaceholder").value;
    var theOperationSelect = document.getElementById("selectAllOperations");
    var theSelectedOperation = theOperationSelect.options[theOperationSelect.selectedIndex];

    document.getElementById("currentOperationId_" + theStepId + "-" + theStepSeq).value = theSelectedOperation.id;
    document.getElementById("operationAnchor_" + theStepId + "-" + theStepSeq).innerHTML = "[" + theSelectedOperation.dataset.operCode + "]" + "<i class='far fa-object-group'></i>";

    assignStepSeqNumbers();
}

function addToCurrentSteps(aStepId) {
    var allStepListItemClone = document.getElementById("allStep_" + aStepId + "-0").cloneNode(true); //All step list item ids all end with -0 as a placeholder for current steps to update the sequence.
    console.log(allStepListItemClone);
    allStepListItemClone.id = allStepListItemClone.id.replace("all", "current");
    var allStepListItemChildren = allStepListItemClone.childNodes;
    for (var i = 0; i < allStepListItemChildren.length; i++) {
        //if the child element has an id, if not then it doesn't need to be changed at all.
        if (allStepListItemChildren[i].id != undefined) {
            //if the step comes from the AllStepList, the <a> tag will have an id of "allStepDetails-(stepId)"
            if (allStepListItemChildren[i].id.startsWith("allStepHeader")) {
                allStepListItemChildren[i].id = allStepListItemChildren[i].id.replace("all", "current");
                var theAnchors = allStepListItemChildren[i].getElementsByTagName("a");
                theAnchors[0].id = theAnchors[0].id.replace("all", "current");
                theAnchors[0].dataset.target = theAnchors[0].dataset.target.replace("all", "current");//The collapse trigger anchor
                theAnchors[1].id = theAnchors[1].id.replace("all", ""); //The operation anchor
                theAnchors[1].innerHTML += "<i class='far fa-object-group'></i>";
            }
            //if the step comes from the AllStepList, the collapsable section will have an id of allStepDetails-(stepId)
            if (allStepListItemChildren[i].id.startsWith("allStepDetails")) {
                allStepListItemChildren[i].id = allStepListItemChildren[i].id.replace("all", "current");
            }
        }
    }

    //Renaming the input placeholders
    var inputs = allStepListItemClone.getElementsByTagName("input");
    for (var i = 0; i < inputs.length; i++) {
        inputs[i].id = inputs[i].id.replace("all", "current");
    }

    var newHandle = document.createElement("i");
    newHandle.classList = "fa fa-arrows-alt handle";
    newHandle.style = "color:goldenrod";

    //Finds the only h5 element inside the list item, finds the only button inside of that h5, and replaces that button with an icon that will act as a handle in the current steps sortable list
    var h5ParentOfReplacedButton = allStepListItemClone.getElementsByTagName("h5")[0];
    h5ParentOfReplacedButton.replaceChild(newHandle, h5ParentOfReplacedButton.getElementsByTagName("button")[0])

    document.getElementById("sortableCurrentSteps").appendChild(allStepListItemClone);

    assignStepSeqNumbers();

    activateRotate();
}

$(document).ready(function () { activateRotate() }); //Turns the rotate on as soon as the document is loaded.

//This needs to be in a seperate function so that "function addToCurrentSteps(aStepId)" can call it after adding a new element, otherwise that element won't have the rotation activated for it.
function activateRotate() {
    //Little script to flip the arrow icon when collapsing/uncollapsing
    $(".collapse").on('show.bs.collapse', function () {
        var iconElement = this.parentNode.getElementsByClassName("fa-chevron-down")[0]; //There is only one icon that is a chevron per li.
        $(iconElement).toggleClass('down');
    });
    $(".collapse").on('hide.bs.collapse', function () {
        var iconElement = this.parentNode.getElementsByClassName("fa-chevron-down")[0]; //There is only one icon that is a chevron per li.
        $(iconElement).toggleClass('down');
    });
}