function OnPageLoad() {
    var xmlHttp = new XMLHttpRequest();
    var url = "https://localhost:44316/api/stepvartemplates/GetAllStepVarTemplates";

    xmlHttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            SetVarTemplateSelectElement(response);
        }
    };
    xmlHttp.open("GET", url, true);
    xmlHttp.send();
}

function SetVarTemplateSelectElement(data) {
    var selectElement = document.getElementById("VarTemplateSelect");
    var i;

    for (i = 0; i < data.length; i++) {
        var option = document.createElement("option");

        option.text = data[i]
        selectElement.add(option);
    }
}