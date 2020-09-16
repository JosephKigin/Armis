//Validation
$.validator.addMethod('containerQty', function (value, element, params) {
    console.log(value + " || " + element + " || " + params);

    return false;
});

//$.validator.unobtrusive.adapters.add('containerQty', [''])