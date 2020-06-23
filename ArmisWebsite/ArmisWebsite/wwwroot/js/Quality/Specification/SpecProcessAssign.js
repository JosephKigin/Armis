﻿function searchSelectList(searchTerm, category) {
    var searchTermLower = searchTerm.toLowerCase();
    var selectList = document.getElementById("select" + category + "List");
    var selectListItems = selectList.getElementsByTagName("option");

    for (var i = 0; i < selectListItems.length; i++) {
        if (!selectListItems[i].textContent.toLowerCase().includes(searchTermLower)) {
            selectListItems[i].style.display = "none";
        }
        else {
            selectListItems[i].style.display = "block";
        }
    }
}

function updateInputFromSelectModal(inputCategory) {
    var theSelect = document.getElementById("select" + inputCategory + "List");
    theSelected = theSelect.options[theSelect.selectedIndex];
    //var theInput = document.getElementById("input" + inputCategory);
    //theInput.value = theSelected.value;
    //theInput.dataset.id = theSelected.dataset.id;

    document.getElementById("hdn" + inputCategory + "Id").value = theSelected.dataset.id; //Updating the hidden field that is bound to a property on the server-side.

    document.getElementById("label" + inputCategory).innerHTML = theSelected.value;
}

function udpateSpecIdOnAnchor(newId) {
    document.getElementById("ancSpecChoiceCommit").href = "/Quality/Specification/SpecProcessAssign/" + newId;
}

function openModalSteps() {
    var selectProcess = document.getElementById("selectProcessList");
    var selectedProcessId = selectProcess.options[selectProcess.selectedIndex].dataset.processId;
    $("#modalStepList-" + selectedProcessId).modal("show");
}

function clearInput(inputCategory) {
    var theLabel = document.getElementById("label" + inputCategory);
    theLabel.innerHTML = "";
    //theLabel.dataset.id = "";
    document.getElementById("hdn" + inputCategory + "Id").value = "";
}

function updateProcessRevIdInput(revId) {
    document.getElementById("hdnProcessRevId").value = revId;
}

function updateChoiceIdInput(sublevelNum, chkBox) {
    var checkBoxes = document.getElementsByName(chkBox.name);

    for (var i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i] != chkBox) {
            checkBoxes[i].checked = false;
        }
    }

    if (chkBox.checked) { document.getElementById("hdnChoiceId" + sublevelNum).value = chkBox.value; }
    else { document.getElementById("hdnChoiceId" + sublevelNum).value = ""; }
}

function searchCurrentSpaList(searchTerm) {
    var SPAs = document.getElementById("spaList").getElementsByTagName("li");
    for (var i = 0; i < SPAs.length; i++) {
        if (SPAs[i] != undefined) {
            if (SPAs[i].dataset.process.toLowerCase().includes(searchTerm.toLowerCase())) {
                SPAs[i].style.display = "block";
            }
            else {
                SPAs[i].style.display = "none";
            }
        }
    }
}

function validate() {
    var isValid = true;

    //Process Select validation
    var processSelect = document.getElementById("selectProcessList");
    var processSection = document.getElementById("selectProcessSection");

    if (processSelect.selectedIndex == -1) {
        processSection.classList.remove("border-dark");
        processSection.classList.add("border-danger");
        document.getElementById("processValidateAlert").hidden = false;
        isValid = false;
    }
    else {
        processSection.classList.remove("border-danger");
        processSection.classList.add("border-dark");
    }

    return isValid;
}