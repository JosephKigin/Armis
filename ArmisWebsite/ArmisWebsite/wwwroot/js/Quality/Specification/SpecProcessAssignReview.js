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

$(document).ready(function () { activateRotate() }); //Turns the rotate on as soon as the document is loaded.

//This needs to be in a seperate function so that "function addToCurrentSteps(aStepId)" can call it after adding a new element, otherwise that element won't have the rotation activated for it.
function activateRotate() {
    //Little script to flip the arrow icon when collapsing/uncollapsing
    $(".collapse").on('show.bs.collapse', function (e) {
        console.log("Show: " + this.id);
        e.stopPropagation();
        var iconElement = this.parentNode.getElementsByClassName("fa-chevron-down")[0]; //There is only one icon that is a chevron per li.
        $(iconElement).toggleClass('down');
    });
    $(".collapse").on('hide.bs.collapse', function (e) {
        console.log("Hide: " + this.id);
        e.stopPropagation();
        var iconElement = this.parentNode.getElementsByClassName("fa-chevron-down")[0]; //There is only one icon that is a chevron per li.
        $(iconElement).toggleClass('down');
    });
}