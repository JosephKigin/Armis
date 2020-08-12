function searchSelectList(searchTerm, category) {
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
    document.getElementById("hdn" + inputCategory + "Id").value = "";
}

function updateProcessRevIdInput(revId) {
    document.getElementById("hdnProcessRevId").value = revId;
}

function updateChoiceIdInput(chkBox) {
    //Resetting the hasBeenSet dataset on the hidden input fields
    var hdnInputs = document.getElementsByClassName("hiddenChoiceInput");
    for (var i = 0; i < hdnInputs.length; i++) {
        hdnInputs[i].dataset.hasBeenSet = 0;
    }
    

    //Unchecking every other checkbox in the same section as the one passed in
    var checkBoxesInSection = document.getElementsByName(chkBox.name);

    for (var i = 0; i < checkBoxesInSection.length; i++) {
        if (checkBoxesInSection[i] != chkBox) {
            checkBoxesInSection[i].checked = false;
        }
    }

    //Getting all the checkboxes in a list
    var allInputs = document.getElementById("divSublevelSection").getElementsByTagName("input");
    var checkBoxes = [];
    for (var i = 0; i < allInputs.length; i++) {
        if (allInputs[i].type == "checkbox") {
            checkBoxes.push(allInputs[i]);
        }
    }

    //Going through all the checkboxes to see if the checkbox is allowed to be enabled/checked depending on dependencies
    for (var i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i].dataset.dependentSublevel != "" && checkBoxes[i].dataset.dependentChoice != "") {
            var dependedSublevel = checkBoxes[i].dataset.dependentSublevel;
            var dependedChoice = checkBoxes[i].dataset.dependentChoice;
            var dependedCheckBox = document.getElementById("chkbox_" + dependedSublevel + "-" + dependedChoice);

            if (dependedCheckBox.checked && dependedCheckBox.disabled == false) {
                checkBoxes[i].disabled = false;
                document.getElementById("spanDependencyText_" + checkBoxes[i].dataset.sublevel + "-" + checkBoxes[i].dataset.choice).classList = "text-success";
            }
            else {
                checkBoxes[i].checked = false;
                checkBoxes[i].disabled = true;
                document.getElementById("spanDependencyText_" + checkBoxes[i].dataset.sublevel + "-" + checkBoxes[i].dataset.choice).classList = "text-danger";
            }
        }

        //Updating hidden input fields
        var hdnSublevelInput = document.getElementById("hdnChoiceId" + checkBoxes[i].dataset.sublevel);
        if (hdnSublevelInput.dataset.hasBeenSet == 0) { //If the field has been updated with a value, then it should not be evaluated anymore for that sublevel
            if (checkBoxes[i].checked) {
                hdnSublevelInput.value = checkBoxes[i].value;
                hdnSublevelInput.dataset.hasBeenSet = 1;
            }
            else {
                hdnSublevelInput.value = "";
            }
        }
    }

    //for (var i = 0; i < checkBoxes.length; i++) {
    //    if (checkBoxes[i] != chkBox) {
    //        if (checkBoxes[i].checked) {
    //            if (checkBoxes[i].dataset.dependedSublevel != "" && checkBoxes[i].dataset.dependedChoice != "") {
    //                var dependentSublevelIds = checkBoxes[i].dataset.dependedSublevel.split(",");
    //                var dependentChoiceIds = checkBoxes[i].dataset.dependedChoice.split(",");

    //                for (var j = 0; j < dependentSublevelIds.length; j++) {
    //                    if (dependentSublevelIds[j] != "") {
    //                        var dependentCheckBox = document.getElementById("chkbox_" + dependentSublevelIds[j] + "-" + dependentChoiceIds[j]);
    //                        dependentCheckBox.disabled = true;
    //                        dependentCheckBox.checked = false;

    //                    }
    //                }
    //            }
    //        }
    //        checkBoxes[i].checked = false;
    //    }
    //}

    //if (chkBox.checked) {
    //    document.getElementById("hdnChoiceId" + sublevelNum).value = chkBox.value;

    //    if (chkBox.dataset.dependedSublevel != "" && chkBox.dataset.dependedChoice != "") {
    //        var dependentSublevelIds = chkBox.dataset.dependedSublevel.split(",");
    //        var dependentChoiceIds = chkBox.dataset.dependedChoice.split(",");

    //        for (var i = 0; i < dependentSublevelIds.length; i++) {
    //            if (dependentSublevelIds[i] != "") {
    //                document.getElementById("chkbox_" + dependentSublevelIds[i] + "-" + dependentChoiceIds[i]).disabled = false;
    //            }
    //        }
    //    }
    //}
    //else {
    //    document.getElementById("hdnChoiceId" + sublevelNum).value = "";

    //    if (chkBox.dataset.dependedSublevel != "" && chkBox.dataset.dependedChoice != "") {
    //        var dependentSublevelIds = chkBox.dataset.dependedSublevel.split(",");
    //        var dependentChoiceIds = chkBox.dataset.dependedChoice.split(",");

    //        for (var i = 0; i < dependentSublevelIds.length; i++) {
    //            if (dependentSublevelIds[i] != "") {
    //                document.getElementById("chkbox_" + dependentSublevelIds[i] + "-" + dependentChoiceIds[i]).disabled = true;
    //            }
    //        }
    //    }
    //}
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

function searchProcessList(searchTerm) {
    var searchTerm = searchTerm.toUpperCase();
    var processList = document.getElementById("selectProcessList");
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

function loadModalDescriptionCard(modalName, description) {
    var cardToFill = document.getElementById(modalName + "DescriptionModal");
    cardToFill.innerHTML = ""; //Clear out the card before loading more stuff into it

    var elementToAdd = document.createElement("p");
    elementToAdd.appendChild(document.createTextNode(description));

    cardToFill.appendChild(elementToAdd);
}

//If a choice has a dependency, that choices checkbox will be disabled until the depended choice is checked.
function CreateDependency() {

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