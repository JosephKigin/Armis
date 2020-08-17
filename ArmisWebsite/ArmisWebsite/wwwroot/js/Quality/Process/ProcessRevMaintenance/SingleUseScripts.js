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