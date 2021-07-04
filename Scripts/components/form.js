const populateFormErrors = (errors) => {
    // clear all form error fields
    $('.field-validation-error')
        .addClass('field-validation-valid')
        .removeClass('field-validation-error')
        .text('');
    // update errors with server response
    Object.keys(errors).forEach((val, i) => {
        var errorField = $(`[data-valmsg-for="${val}"]`);

        if (errorField) {
            errorField
                .removeClass('field-validation-valid')
                .addClass('field-validation-error')
                .text(errors[val]);
        }
    })
}

const initMaskedInput = (formSelector, inputSelector) => {
    $(formSelector).find(inputSelector).mask('# ##0,00', { reverse: true });
}

const clearMaskBeforeSubmit = (formSelector, inputSelector) => {
    let value = $(formSelector).find(inputSelector).val();
    $(formSelector).find(inputSelector).val(value.replaceAll(' ', ''));
}

const initDatePicker = (formSelector, dateDieldSelector) => {
    // init bootstrap datetimepicker
    $(formSelector).find(dateDieldSelector).datetimepicker({
        locale: 'ru',
        format: "DD.MM.YYYY",
        minDate: '1980-01-01',
        // replace glyphicons with font-awesome
        icons: {
            previous: 'fa fa-chevron-left',
            next: 'fa fa-chevron-right',
            today: 'fa fa-screenshot',
            clear: 'fa fa-trash',
            close: 'fa fa-remove',
            time: "fa fa-clock-o",
            date: "fa fa-calendar",
            up: "fa fa-arrow-up",
            down: "fa fa-arrow-down"
        }
    });
}
