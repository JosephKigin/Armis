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
    newDiv.innerHTML = '<div class="col-lg-1"><a id="ancInsertLine' + currentLevel + '" data-level="' + currentLevel + '" onclick="AddLevel(this.dataset.level)"><i class="fa fa-sm fa-plus-circle" style="color:green"></i></a></div> <div class="col-lg-4"> <input name="inputNumOfPartsFrom' + currentLevel + '" type="number" class="form-control" /> </div> <div class="col-lg-1">-</div> <div class="col-lg-4"> <input name="inputNumOfPartsTo' + currentLevel + '" type="number" data-level="' + currentLevel + '" class="form-control" onblur="updateNextFrom(this)" /> </div><div class="col-lg-1"><a id="ancRemoveLine' + currentLevel + '" data-level="' + currentLevel + '" onclick="DeleteLevel(this.dataset.level)"><i class="fa fa-sm fa-minus-circle ml-2" style="color:red"></i></a></div>';
    sectionNumOfParts.appendChild(newDiv);

    //!This starts at 1, not 0!  This was done to keep consistant with the amount of tests, which is not 0 based.
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
    updateNextFrom($('input[name = "inputNumOfPartsTo' + levelNum + '"]')[0]);
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

            //Delete Anchor
            var deleteAnchor = document.getElementById("ancRemoveLine" + i);
            deleteAnchor.id = "ancRemoveLine" + (i - 1);
            deleteAnchor.dataset.level = (i - 1);

            //From Input
            var fromInput = document.getElementsByName("inputNumOfPartsFrom" + i); //This will return as an array, but all names on this page are unique so it will always return only 1;
            fromInput[0].name = "inputNumOfPartsFrom" + (i - 1);

            //To Input
            var toInput = document.getElementsByName("inputNumOfPartsTo" + i); //This will return as an array, but all names on this page are unique so it will always return only 1;
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

    if (nextFrom != undefined) {
        var temp = parseInt(toInput.value) + 1;
        nextFrom.val(temp);
    }
}

//Using a little bit more jQuery here just to get a little more familiar with it.
function validateForm() {
    var isValid = true;
    var allInputs = document.getElementsByTagName("input");

    //Make sure no input is empty.
    for (var i = 0; i < allInputs.length; i++) {
        if (allInputs[i].value == "") {
            allInputs[i].classList.add("border-danger");
            isValid = false;
        }
        else {
            allInputs[i].classList.remove("border-danger");
        }
    }

    var amntOfLevels = $("#hdnNumOfLevels").val();
    var amntOfTests = $("#hdnNumOfTests").val();

    //Iterating through all the tests to validate that test types are all unique.
    var selectNames = []; //TODO: The remove classes are overwriting the add classes when something errors out. This needs to be fixed so that if something isnt valid at first but is valid in a different category, it should still show up as invalid.
    for (var i = 1; i <= amntOfTest; i++) {
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
    for (var i = 1; i <= amntOfLevels; i++) {
        var fromInput = $("[name='inputNumOfPartsFrom" + i + "']");
        var toInput = $("[name='inputNumOfPartsTo" + i + "']");

        //Validates that FromValue is less than or equal to ToValue
        if (fromInput.val() > toInput.val()) {
            isValid = false;
            fromInput.addClass("border-danger");
            toInput.addClass("border-danger");
        }
        else {
            fromInput.removeClass("border-warning");
            toInput.removeClass("border-warning");
        }

        //Iterate through each test
        for (var j = 1; j <= amntOfTests; j++) {
            var sampleInput = $("[name = 'inputSampleNum" + j + "-" + i + "']");
            var rejectInput = $("[name = 'inputRejectNum" + j + "-" + i + "']");

            //Validate that sampleInput is greater than rejectInput
            if (sampleInput.val() < rejectInput.val()) {
                isValid = false;
                sampleInput.addClass("border-danger");
                rejectInput.addClass("border-danger");
            }
            else {
                sampleInput.removeClass("border-danger");
                rejectInput.removeClass("border-danger");
            }

            //Validate sampleInput is less than or equal to fromInput
            if (sampleInput.val() > toInput.val()) {
                isValid = false;
                sampleInput.addClass("border-danger");
                toInput.addClass("border-danger");
            }
            else {
                sampleInput.removeClass("border-danger");
                fromInput.removeClass("border-danger");
            }
        }

    }
    return false;
    //return isValid;
}