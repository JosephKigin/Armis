//This will add a level to the bottom and then push all the values down starting after the prevLevel parameter passed in.  This will make it appear as if a level was inserted.
function AddLevel(levelNum) { //levelNum will be the level before the one being "inserted"
    var sectionNumOfParts = document.getElementById("sectionNumOfParts");
    var currentAmntOfLevels = document.getElementById("hdnNumOfLevels"); //This value will change, so the entire element needs to be pulled.  The value will be saved in currentLevel to be used later.
    var currentAmntOfTests = document.getElementById("hdnNumOfTests").value; //This value won't change at all here, so the value is pulled right away.

    currentAmntOfLevels.value = parseInt(currentAmntOfLevels.value) + 1;
    var currentLevel = currentAmntOfLevels.value;

    var newDiv = document.createElement("div");
    newDiv.id = "numPartsLevel" + currentLevel;
    newDiv.classList = "row mt-1";
    newDiv.innerHTML = '<div class="col-lg-1"><a id="ancInsertLine' + currentLevel + '" data-level="' + currentLevel + '" onclick="AddLevel(this.dataset.level)"><i class="fa fa-sm fa-plus-circle" style="color:green"></i></a></div> <div class="col-lg-4"> <input name="inputNumOfPartsFrom' + currentLevel + '" type="number" class="form-control" tabindex="-1" readonly/> </div> <div class="col-lg-1">-</div> <div class="col-lg-4"> <input name="inputNumOfPartsTo' + currentLevel + '" type="number" data-level="' + currentLevel + '" class="form-control" onblur="updateNextFrom(this)" /> </div><div class="col-lg-1"><a id="ancRemoveLine' + currentLevel + '" data-level="' + currentLevel + '" onclick="DeleteLevel(this.dataset.level)"><i class="fa fa-sm fa-minus-circle ml-2" style="color:red"></i></a></div>';
    sectionNumOfParts.appendChild(newDiv);

    //!This starts at 1, not 0!  This was done to keep consistant with the amount of tests, which is not 0 based.
    //Adds a new level to each test.
    for (var i = 1; i <= currentAmntOfTests; i++) {
        var sectionTestType = document.getElementById("testType" + i);
        var newDiv = document.createElement("div");
        newDiv.id = "numSampleReject" + i + "-" + currentLevel;
        newDiv.classList = "row mt-1";
        newDiv.innerHTML = '<input name="inputSampleNum' + i + '-' + currentLevel + '" type="number" class="form-control col-lg-5 mr-3" placeholder="Sample" /> <input name="inputRejectNum' + i + '-' + currentLevel + '" type="number" class="form-control col-lg-5" placeholder="Reject" />';
        sectionTestType.appendChild(newDiv);
    }

    //This will iterate through the inputs starting at the bottom and stopping at the input number after levelNum sent in.  It will iterate backwards because the bottom inputs will be empty so it won't overwrite any values.
    for (var i = currentAmntOfLevels.value; i > (levelNum); i--) {

        document.getElementsByName("inputNumOfPartsFrom" + i)[0].value = document.getElementsByName("inputNumOfPartsFrom" + (i - 1))[0].value;
        document.getElementsByName("inputNumOfPartsTo" + i)[0].value = document.getElementsByName("inputNumOfPartsTo" + (i - 1))[0].value;

        if (i == parseInt(levelNum) + 1) {
            document.getElementsByName("inputNumOfPartsFrom" + i)[0].value = "";
            document.getElementsByName("inputNumOfPartsTo" + i)[0].value = "";
        }
    }

    //Updating the from value of the newly inserted level
    if ($('input[name = "inputNumOfPartsTo' + levelNum + '"]')[0] == undefined) { console.log("YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY") }
    updateNextFrom($('input[name = "inputNumOfPartsTo' + levelNum + '"]')[0]);

    //Undo any of the disables or placeholder changes that the next couple lines after this does.
    $("input[name ^= 'inputNumOfPartsTo']").prop("disabled", false);
    $("input[name ^= 'inputNumOfPartsTo']").prop("placeholder", "");

    //Make the last to value disabled and give it the placeholder "Over" to indicate that it is the last level and the last value is anything over what was specified.
    $("input[name = 'inputNumOfPartsTo" + currentLevel + "']").prop("disabled", true);
    $("input[name = 'inputNumOfPartsTo" + currentLevel + "']").prop("placeholder", "OVER");

    //Unhide all anchors.
    $("a").prop("hidden", false);

    //Hide the delete anchor on the last element.
    $("a[id = 'ancRemoveLine" + currentLevel + "']").prop("hidden", true);
}

function AddTest() {
    var sectionTestTypes = document.getElementById("testTypePlaceholder");
    var currentAmntOfTests = document.getElementById("hdnNumOfTests");  //This value will change, so the entire element needs to be pulled.
    var currentAmntOfLevels = document.getElementById("hdnNumOfLevels").value;  //This value won't change at all here, so the value is pulled right away.
    if (currentAmntOfTests.value < 6) {
        currentAmntOfTests.value = parseInt(currentAmntOfTests.value) + 1;
        var currentTestAmnt = currentAmntOfTests.value;

        var newTestType = document.createElement("div");
        newTestType.id = "testType" + currentTestAmnt;
        newTestType.classList = "col-lg mr-3";
        newTestType.innerHTML = '<div class="row"> <select name="selectTestType' + currentTestAmnt + '" class="form-control col-lg-11" >' + document.getElementById("selectTestTypePlaceholder").innerHTML + '</select> </div> <div class="row"> <div class="col-lg-5">Spl</div > <div class="col-lg-5">Rej</div> </div >';

        sectionTestTypes.appendChild(newTestType);

        var sectionCurrentTest = document.getElementById("testType" + currentTestAmnt);  //Grabs the test section that was just added

        //!This starts at 1, not 0!  This was done to keep consistant with the amount of tests, which is not 0 based.
        for (var i = 1; i <= currentAmntOfLevels; i++) {
            var newTestLevel = document.createElement("div");
            newTestLevel.id = "numSampleReject" + currentTestAmnt + "-" + i;
            newTestLevel.classList = "row mt-1";
            newTestLevel.innerHTML = '<input name="inputSampleNum' + currentTestAmnt + '-' + i + '" type="number" class="form-control col-lg-5 mr-3" placeholder="Sample" /> <input name="inputRejectNum' + currentTestAmnt + '-' + i + '" type="number" class="form-control col-lg-5" placeholder="Reject" />';
            sectionCurrentTest.appendChild(newTestLevel);
        }
    }
}

function RemoveTest() {
    var hdnAmountOfTests = document.getElementById("hdnNumOfTests");
    var amntOfTests = hdnAmountOfTests.value;

    var testSectionToRemove = document.getElementById("testType" + amntOfTests);
    testSectionToRemove.parentElement.removeChild(testSectionToRemove);

    hdnAmountOfTests.value = (amntOfTests - 1);
}

function DeleteLevel(levelNum) {
    var numPartSectionToDelete = document.getElementById("numPartsLevel" + levelNum);
    numPartSectionToDelete.parentElement.removeChild(numPartSectionToDelete); //Deleting the numOfParts inputs

    var currentAmntOfTests = document.getElementById("hdnNumOfTests");
    var amntOfTests = currentAmntOfTests.value;

    for (var i = 1; i <= amntOfTests; i++) { //Deleting each of the test inputs
        var testInputSectionToDelete = document.getElementById("numSampleReject" + i + "-" + levelNum);
        testInputSectionToDelete.parentNode.removeChild(testInputSectionToDelete);
    }

    var hdnNumOfLevels = document.getElementById("hdnNumOfLevels");
    var levelsAmnt = hdnNumOfLevels.value;
    var nextLevel = parseInt(levelNum) + 1; //This is used to check for any inputs after the one deleted so their IDs can be decremented to fit.

    for (var i = nextLevel; i <= levelsAmnt; i++) {
        var numOfPartsInputsDiv = document.getElementById("numPartsLevel" + i);

        if (numOfPartsInputsDiv != undefined) {
            //Reassigning new ids to make sure they stay sequencial.
            numOfPartsInputsDiv.id = "numPartsLevel" + (i - 1); //The div

            //Insert Anchor
            var insertAnchor = document.getElementById("ancInsertLine" + i);
            insertAnchor.dataset.level = (i - 1);
            insertAnchor.id = "ancInsertLine" + (i - 1);

            //Delete Anchor
            var deleteAnchor = document.getElementById("ancRemoveLine" + i);
            deleteAnchor.dataset.level = (i - 1);
            deleteAnchor.id = "ancRemoveLine" + (i - 1);

            //From Input
            var fromInput = document.getElementsByName("inputNumOfPartsFrom" + i); //This will return as an array, but all names on this page are unique so it will always return only 1;
            fromInput[0].name = "inputNumOfPartsFrom" + (i - 1);

            //To Input
            var toInput = document.getElementsByName("inputNumOfPartsTo" + i); //This will return as an array, but all names on this page are unique so it will always return only 1;
            toInput[0].dataset.level = (i - 1);
            toInput[0].name = "inputNumOfPartsTo" + (i - 1);

            //Test Type inputs
            for (var j = 1; j <= amntOfTests; j++) {
                document.getElementById("numSampleReject" + j + "-" + i).id = "numSampleReject" + j + "-" + (i - 1);

                //Sample Input
                document.getElementsByName("inputSampleNum" + j + "-" + i)[0].name = "inputSampleNum" + j + "-" + (i - 1);

                //Reject Input
                document.getElementsByName("inputRejectNum" + j + "-" + i)[0].name = "inputRejectNum" + j + "-" + (i - 1);
            }

        }
        else {
            console.log("UNDEFINED: Number Of Parts Div" + i);
        }
    }

    hdnNumOfLevels.value = parseInt(hdnNumOfLevels.value) - 1;
}

function updateNextFrom(toInput) {
    var nextLevel = (parseInt(toInput.dataset.level) + 1);

    var nextFrom = $('input[name = "inputNumOfPartsFrom' + nextLevel + '"]');

    if (nextFrom != undefined && toInput.value != "") {
        var temp = parseInt(toInput.value) + 1;
        nextFrom.val(temp);
    }
}

//Using a little bit more jQuery here just to get a little more familiar with it.
function validateForm() {
    var isValid = true;

    var nameInput = $("#inputName");
    var descInput = $("#inputDescription");

    if (nameInput.val() == "") {
        isValid = false;
        nameInput.addClass("border-danger");
    }
    else { nameInput.removeClass("border-danger"); }

    if (descInput.val() == "") {
        isValid = false;
        descInput.addClass("border-danger");
    }

    var amntOfLevels = $("#hdnNumOfLevels").val();
    var amntOfTests = $("#hdnNumOfTests").val();

    //Iterating through all the tests to validate that test types are all unique.
    var selectNames = [];
    for (var i = 1; i <= amntOfTests; i++) {
        var testTypeSelect = $("[name='selectTestType" + i + "']");
        for (var j = 0; j < selectNames.length; j++) {
            if (selectNames[j] == testTypeSelect.val()) {
                isValid = false;
                testTypeSelect.addClass("border-danger");
            }
        }
        selectNames[selectNames.length] = testTypeSelect.val();
    }

    //Iterating through all the levels
    /*Validation:  1) No empty inputs
                   2) From amount < To amount
                   3) Sample amount < To amount
                   4) Reject amount < Sample amount*/
    for (var i = 1; i <= amntOfLevels; i++) {
        var fromInput = $("[name='inputNumOfPartsFrom" + i + "']");
        var toInput = $("[name='inputNumOfPartsTo" + i + "']");

        var isFromValid = true;
        var isToValid = true;

        var isLastLevel = false;
        if (i == amntOfLevels) { isLastLevel = true; } //Some validation is different at the last level because the last To value is "OVER" which is technically blank.

        //1
        if (fromInput.val() == "") {
            isFromValid = false;
        }

        //1
        if (!isLastLevel) {
            if (toInput.val() == "") {
                isToValid = false;
            }
        }


        //2
        if (!isLastLevel) {
            if (parseInt(fromInput.val()) > parseInt(toInput.val())) {
                isFromValid = false;
                isToValid = false;
            }
        }


        //Iterate through each test
        for (var j = 1; j <= amntOfTests; j++) {
            var sampleInput = $("[name = 'inputSampleNum" + j + "-" + i + "']");
            var rejectInput = $("[name = 'inputRejectNum" + j + "-" + i + "']");

            var isSampleValid = true;
            var isRejectValid = true;

            //1
            if (sampleInput.val() == "") {
                isSampleValid = false;
            }

            //1
            if (rejectInput.val() == "") {
                isRejectValid = false;
            }

            //3
            if (!isLastLevel) {
                if (parseInt(sampleInput.val()) > parseInt(toInput.val())) {
                    isSampleValid = false;
                    isToValid = false;
                }
            }

            //4
            if (parseInt(sampleInput.val()) < parseInt(rejectInput.val())) {
                isSampleValid = false;
                isRejectValid = false;
            }

            if (!isSampleValid) {
                isValid = false;
                sampleInput.addClass("border-danger");
            }
            else { sampleInput.removeClass("border-danger"); }

            if (!isRejectValid) {
                isValid = false;
                rejectInput.addClass("border-danger");
            }
            else { rejectInput.removeClass("border-danger"); }

        }

        if (!isFromValid) {
            isValid = false;
            fromInput.addClass("border-danger");
        }
        else { fromInput.removeClass("border-danger"); }

        if (!isToValid) {
            isValid = false
            toInput.addClass("border-danger");
        }
        else { toInput.removeClass("border-danger"); }

    }

    return isValid;
}

//Prevents user from pressing "Enter" to submit the form.
$(document).ready(function () {
    $(window).keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });
});