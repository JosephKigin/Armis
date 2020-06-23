function searchSpecProcessAssignList(searchTerm) {
    var assigns = document.getElementById("allAssignsList").getElementsByTagName("li");
    for (var i = 0; i < assigns.length; i++) {
        if (assigns[i] != undefined) {
            if (assigns[i].dataset.spec.toLowerCase().includes(searchTerm.toLowerCase())) {
                console.log(assigns[i].dataset.spec.toLowerCase() + " : " + searchTerm);
                assigns[i].style.display = "block";
            }
            else {
                assigns[i].style.display = "none";
            }
        }
    }
}

function toggleKeepBtn(chkBox) {
    if (chkBox.checked) {
        document.getElementById("btnKeep").disabled = true;
    }
    else {
        document.getElementById("btnKeep").disabled = false;
    }
}