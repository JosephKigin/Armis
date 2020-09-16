function searchProcessList() {
    var searchTerm = document.getElementById("searchProcesses").value.toUpperCase();
    var processList = document.getElementById("processList");
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

function togglePrintButton() {
    document.getElementById("btnPrint").disabled = false;
}

function openPdfInNewTab() {
    var pdfPath = document.getElementById("pdfPath").innerHTML;
    window.open(pdfPath);
}