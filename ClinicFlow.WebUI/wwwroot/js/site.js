$(document).ready(function () {

    // Allow jQuery Validation to validate hidden Select2 fields
    $.validator.setDefaults({
        ignore: []
    });

    $('.select2').select2({
        width: '100%',
        language: {
            noResults: function () {
                return window.select2Localization.noResults;
            },
            searching: function () {
                return window.select2Localization.searching;
            },
            inputTooShort: function () {
                return window.select2Localization.inputTooShort;
            }
        }
    });

});