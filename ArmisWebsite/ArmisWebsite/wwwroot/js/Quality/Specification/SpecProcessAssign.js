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
    var theInput = document.getElementById("input" + inputCategory);
    theInput.value = theSelected.value;
    theInput.dataset.id = theSelected.dataset.id;

    document.getElementById("hdn" + inputCategory + "Id").value = theSelected.dataset.id; //Updating the hidden field that is bound to a property on the server-side.
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
    var theInput = document.getElementById("input" + inputCategory);
    theInput.value = "";
    theInput.dataset.id = "";
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