
function openPreBakeModal() {
    $("#modalPreBakeSelect").modal("show");
}

function updatePreBakeInput() {
    var selectAllPreBake = document.getElementById("selectAllPreBakes");
    var selectedPreBake = selectAllPreBake.options[selectAllPreBake.selectedIndex];
    var inputPreBake = document.getElementById("inputPreBake");
    inputPreBake.value = selectedPreBake.value;
    inputPreBake.dataset.preBakeId = selectedPreBake.dataset.preBakeId;

}

function openPostBakeModal() {
    $("#modalPostBakeSelect").modal("show");
}

function updatePostBakeInput() {
    var selectAllPostBakes = document.getElementById("selectAllPostBakes");
    var selectedPostBake = selectAllPostBakes.options[selectAllPostBakes.selectedIndex];
    var inputHardness = document.getElementById("inputPostBake");
    inputHardness.value = selectedPostBake.value;
    inputHardness.dataset.hardnessId = selectedHardness.dataset.hardnessId;
}

function openMaskModal() {
    $("#modalMaskSelect").modal("show");
}

function updateMaskInput() {
    var selectAllHardnesses = document.getElementById("selectAllHardnesses");
    var selectedHardness = selectAllHardnesses.options[selectAllHardnesses.selectedIndex];
    var inputHardness = document.getElementById("inputHardness");
    inputHardness.value = selectedHardness.value;
    inputHardness.dataset.hardnessId = selectedHardness.dataset.hardnessId;
}

function openHardnessModal() {
    $("#modalHardnessSelect").modal("show");
}

function updateHardnessInput() {
    var selectAllHardnesses = document.getElementById("selectAllHardnesses");
    var selectedHardness = selectAllHardnesses.options[selectAllHardnesses.selectedIndex];
    var inputHardness = document.getElementById("inputHardness");
    inputHardness.value = selectedHardness.value;
    inputHardness.dataset.hardnessId = selectedHardness.dataset.hardnessId;
}