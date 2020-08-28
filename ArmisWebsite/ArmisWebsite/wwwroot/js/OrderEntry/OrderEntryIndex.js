function addLineItem() { //ToDo: The inputs need to be sequenced and bound to a property somehow.
    var hdnLineItemCount = document.getElementById("hdnLineItemsCount");
    hdnLineItemCount.stepUp();
    var lineCount = hdnLineItemCount.value;

    //Line Number
    var lineTh = document.createElement("th");
    lineTh.scope = "row";
    lineTh.innerHTML = lineCount;

    //Qty
    var qtyInput = document.createElement("input");
    qtyInput.id = "inputLineItemQty" + lineCount;
    qtyInput.type = "number";
    qtyInput.step = 1;
    qtyInput.style = "box-sizing: border-box; width:100%;";

    var qtyTd = document.createElement("td");
    qtyTd.appendChild(qtyInput);

    //Part #
    var partNumInput = document.createElement("input");
    partNumInput.id = "inputLineItemPartNum" + lineCount;
    partNumInput.type = "text";
    partNumInput.style = "box-sizing: border-box; width:100%;";

    var partNumTd = document.createElement("td");
    partNumTd.appendChild(partNumInput);

    //Rev
    var revInput = document.createElement("input");
    revInput.id = "inputLineItemRev" + lineCount;
    revInput.type = "text";
    revInput.style = "box-sizing: border-box; width:100%;";

    var revTd = document.createElement("td");
    revTd.appendChild(revInput);

    //Description
    var descriptionInput = document.createElement("input");
    descriptionInput.id = "inputLineItemDescription" + lineCount;
    descriptionInput.type = "text";
    descriptionInput.style = "box-sizing: border-box; width:100%;";

    var descriptionTd = document.createElement("td");
    descriptionTd.appendChild(descriptionInput);

    //PO Price
    var poPriceInput = document.createElement("input");
    poPriceInput.id = "inputLineItemPoPrice" + lineCount;
    poPriceInput.type = "number";
    poPriceInput.step = .01;
    poPriceInput.style = "box-sizing: border-box; width:100%;";

    var poPricesTd = document.createElement("td");
    poPricesTd.appendChild(poPriceInput);

    //U/M
    var uomSelect = document.getElementById("selectUoMsTOCOPY").cloneNode(true);
    uomSelect.id = "selectLineItemUoMs" + lineCount;

    var uomTd = document.createElement("td");
    uomTd.appendChild(uomSelect);

    //Piece Weight
    var pieceWeightInput = document.createElement("input");
    pieceWeightInput.id = "inputLineItemPieceWeight" + lineCount;
    pieceWeightInput.type = "number";
    pieceWeightInput.step = .01;
    pieceWeightInput.style = "box-sizing: border-box; width:100%;";

    var pieceWeightTd = document.createElement("td");
    pieceWeightTd.appendChild(pieceWeightInput);

    //Total
    var totalInput = document.createElement("input");
    totalInput.id = "inputLineItemTotal" + lineCount;
    totalInput.type = "number";
    totalInput.step = .01;
    totalInput.style = "box-sizing: border-box; width:100%;";

    var totalTd = document.createElement("td");
    totalTd.appendChild(totalInput);

    //Part Comment
    var partCommentInput = document.createElement("textarea");
    partCommentInput.id = "textareaLineItemPartComment" + lineCount;
    partCommentInput.type = "text";
    partCommentInput.style = "box-sizing: border-box; width:100%;";

    var partCommentTd = document.createElement("td");
    partCommentTd.appendChild(partCommentInput);

    //The row
    var row = document.createElement("tr");
    row.appendChild(lineTh);
    row.appendChild(qtyTd);
    row.appendChild(partNumTd);
    row.appendChild(revTd);
    row.appendChild(descriptionTd);
    row.appendChild(poPricesTd);
    row.appendChild(uomTd);
    row.appendChild(pieceWeightTd);
    row.appendChild(totalTd);
    row.appendChild(partCommentTd);

    document.getElementById("tbodyLineItems").appendChild(row);
}