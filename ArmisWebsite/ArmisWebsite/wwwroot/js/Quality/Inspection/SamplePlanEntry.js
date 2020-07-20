//This will add a level to the bottom and then push all the values down starting after the prevLevel parameter passed in.  This will make it appear as if a level was inserted.
function AddLevel(levelNum) { //levelNum will be the level before the one being "inserted"
    var sectionNumOfParts = document.getElementById("sectionNumOfParts");
    var currentAmntOfLevels = document.getElementById("hdnNumOfLevels"); //This value will change, so the entire element needs to be pulled.  The value will be saved in currentLevel to be used later.
    var currentAmntOfTests = document.getElementById("hdnNumOfTests").value; //This value won't change at all here, so the value is pulled right away.

    currentAmntOfLevels.value = parseInt(currentAmntOfLevels.value) + 1;
    var currentLevelAmnt = currentAmntOfLevels.value;

    //Creating each element to be added into the "# of Parts" section
    //First column
    var iconAddLevel = document.createElement("i");
    iconAddLevel.classList = "fa fa-sm fa-plus-circle";
    iconAddLevel.style.color = "green";

    var ancAddLevel = document.createElement("a");
    ancAddLevel.id = "ancInsertLine" + currentLevelAmnt;
    ancAddLevel.dataset.level = currentLevelAmnt;
    ancAddLevel.setAttribute("onclick", "AddLevel(this.dataset.level)");
    ancAddLevel.appendChild(iconAddLevel);

    var divFirstCol = document.createElement("div");
    divFirstCol.classList = "col-lg-1";
    divFirstCol.appendChild(document.createElement("br"));
    divFirstCol.appendChild(ancAddLevel)

    //Second column
    var inputFrom = document.createElement("input");
    inputFrom.name = "inputNumOfPartsFrom" + currentLevelAmnt;
    inputFrom.type = "number";
    inputFrom.classList = "form-control";
    inputFrom.tabIndex = "-1";
    inputFrom.readOnly = true;

    var divSecondCol = document.createElement("div");
    divSecondCol.classList = "col-lg-4";
    divSecondCol.appendChild(inputFrom);

    //Third column
    var divThirdCol = document.createElement("div");
    divThirdCol.classList = "col-lg-1";
    divThirdCol.innerHTML = "-";

    //Fourth column
    var inputTo = document.createElement("input");
    inputTo.name = "inputNumOfPartsTo" + currentLevelAmnt;
    inputTo.type = "number";
    inputTo.dataset.level = currentLevelAmnt;
    inputTo.classList = "form-control";
    inputTo.setAttribute("onblur", "updateNextFrom(this)");


    var divFourthCol = document.createElement("div");
    divFourthCol.classList = "col-lg-4";
    divFourthCol.appendChild(inputTo);

    //Fifth column
    var iconDelete = document.createElement("i");
    iconDelete.classList = "fa fa-sm fa-minus-circle ml-2";
    iconDelete.style.color = "red";

    var ancDelete = document.createElement("a");
    ancDelete.id = "ancRemoveLine" + currentLevelAmnt;
    ancDelete.dataset.level = currentLevelAmnt;
    ancDelete.setAttribute("onclick", "DeleteLevel(this.dataset.level)");
    ancDelete.appendChild(iconDelete);

    var divFifthCol = document.createElement("div");
    divFifthCol.classList = "col-lg-1";
    divFifthCol.appendChild(ancDelete);

    //Put all of the columns into a row div
    var divRow = document.createElement("div");
    divRow.id = "numPartsLevel" + currentLevelAmnt;
    divRow.classList = "row mt-1";
    divRow.appendChild(divFirstCol);
    divRow.appendChild(divSecondCol);
    divRow.appendChild(divThirdCol);
    divRow.appendChild(divFourthCol);
    divRow.appendChild(divFifthCol);

    //Add the row to the section on the page
    sectionNumOfParts.appendChild(divRow);

    //!This starts at 1, not 0!  This was done to keep consistant with the amount of tests, which is not 0 based.
    //Adds a new level to each test.
    for (var i = 1; i <= currentAmntOfTests; i++) {
        var sectionTestType = document.getElementById("testType" + i);

        //Create inputs to insert into divTestRow
        var inputSampleNum = document.createElement("input");
        inputSampleNum.name = "inputSampleNum" + i + "-" + currentLevelAmnt;
        inputSampleNum.type = "number";
        inputSampleNum.classList = "form-control col-lg-5 mr-3";
        inputSampleNum.placeholder = "Sample";

        var inputRejectNum = document.createElement("input");
        inputRejectNum.name = "inputRejectNum" + i + "-" + currentLevelAmnt;
        inputRejectNum.type = "number";
        inputRejectNum.classList = "form-control col-lg-5";
        inputRejectNum.placeholder = "Reject";


        var divTestRow = document.createElement("div");
        divTestRow.id = "numSampleReject" + i + "-" + currentLevelAmnt;
        divTestRow.classList = "row mt-1";
        divTestRow.style.height = '48px';
        divTestRow.clientHeight = divRow.clientHeight;
        divTestRow.appendChild(inputSampleNum);
        divTestRow.appendChild(inputRejectNum);

        //Add divTestRow to the test section
        sectionTestType.appendChild(divTestRow);
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
    $("input[name = 'inputNumOfPartsTo" + currentLevelAmnt + "']").prop("disabled", true);
    $("input[name = 'inputNumOfPartsTo" + currentLevelAmnt + "']").prop("placeholder", "OVER");

    //Unhide all anchors.
    $("a").prop("hidden", false);

    //Hide the delete anchor on the last element.
    $("a[id = 'ancRemoveLine" + currentLevelAmnt + "']").prop("hidden", true);
}

function AddTest() {
    var sectionTestTypes = document.getElementById("testTypePlaceholder");
    var currentAmntOfTests = document.getElementById("hdnNumOfTests");  //This value will change, so the entire element needs to be pulled.
    var currentAmntOfLevels = document.getElementById("hdnNumOfLevels").value;  //This value won't change at all here, so the value is pulled right away.
    if (currentAmntOfTests.value < 6) {
        currentAmntOfTests.value = parseInt(currentAmntOfTests.value) + 1;
        var currentTestAmnt = currentAmntOfTests.value;

        //Create select, inputs, and divs to go into divTestType - the new test section being added
        var selectTestType = document.createElement("select");
        selectTestType.name = "selectTestType" + currentTestAmnt;
        selectTestType.classList = "form-control col-lg-11";
        selectTestType.innerHTML = document.getElementById("selectTestTypePlaceholder").innerHTML; //Adds the static options from a hidden select on the page

        var divSelectRow = document.createElement("div");
        divSelectRow.classList = "row"
        divSelectRow.appendChild(selectTestType);

        var divSplLabel = document.createElement("div");
        divSplLabel.classList = "col-lg-5 p-0";
        divSplLabel.innerHTML = "Spl";

        var divRejLabel = document.createElement("div");
        divRejLabel.classList = "col-lg-5";
        divRejLabel.innerHTML = "Rej";

        var divLabelRow = document.createElement("div");
        divLabelRow.classList = "row";
        divLabelRow.appendChild(divSplLabel);
        divLabelRow.appendChild(divRejLabel);

        var divTestType = document.createElement("div");
        divTestType.id = "testType" + currentTestAmnt;
        divTestType.classList = "col-lg mr-3";
        divTestType.appendChild(divSelectRow);
        divTestType.appendChild(divLabelRow);

        sectionTestTypes.appendChild(divTestType);

        var sectionCurrentTest = document.getElementById("testType" + currentTestAmnt);  //Grabs the test section that was just added

        //!This starts at 1, not 0!  This was done to keep consistant with the amount of tests, which is not 0 based.
        for (var i = 1; i <= currentAmntOfLevels; i++) {
            var inputSampleNum = document.createElement("input");
            inputSampleNum.name = "inputSampleNum" + currentTestAmnt + "-" + i;
            inputSampleNum.type = "number";
            inputSampleNum.classList = "form-control col-lg-5 mr-3";
            inputSampleNum.placeholder = "Sample";

            var inputRejectNum = document.createElement("input");
            inputRejectNum.name = "inputRejectNum" + currentTestAmnt + "-" + i;
            inputRejectNum.type = "number";
            inputRejectNum.classList = "form-control col-lg-5";
            inputRejectNum.placeholder = "Reject";

            var newTestLevel = document.createElement("div");
            newTestLevel.id = "numSampleReject" + currentTestAmnt + "-" + i;
            newTestLevel.classList = "row mt-1";
            newTestLevel.style.height = "48px";
            newTestLevel.appendChild(inputSampleNum);
            newTestLevel.appendChild(inputRejectNum);

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