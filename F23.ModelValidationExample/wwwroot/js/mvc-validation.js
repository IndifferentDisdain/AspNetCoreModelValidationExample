(function () {
    'use strict';

    window.addEventListener('load', function () {
        updateValidationFields();

        // Hijack form submit
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                validateAll();
                var isValid = checkFormIsValid();

                if (isValid == false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
            }, false);
        });

        // On Blur validation
        var foo = Array.prototype.filter.call(formControls, function (formControl) {
            formControl.addEventListener('blur', validateOnBlur, false);
        });

    }, false);
})();

const invalidClassName = 'is-invalid';
var forms;
var formControls;
var validationMessageSpans;

function updateValidationFields() {
    forms = document.getElementsByClassName('needs-validation');
    formControls = document.getElementsByClassName('form-control');
    validationMessageSpans = document.getElementsByClassName('field-validation-valid');
}

function checkFormIsValid() {
    var isValid = true;

    for (var i = 0; i < formControls.length; i++) {
        var classList = formControls[i].classList;

        if (classList.contains(invalidClassName)) {
            return false;
        }
    }

    if (isValid) {
        var invalidItems = $('.is-invalid');

        isValid = invalidItems.length < 1;
    }

    return isValid;
}

function validateAll() {
    var valid = document.getElementsByClassName('field-validation-valid');
    var inValid = document.getElementsByClassName('field-validation-error');
    validationMessageSpans = Array.prototype.concat.apply(new Array(), valid);
    validationMessageSpans = Array.prototype.concat.apply(validationMessageSpans, inValid);

    for (var i = 0; i < formControls.length; i++) {
        validate(formControls[i]);
    }
}

function validateOnBlur(e) {
    var formControl = e.currentTarget;
    validate(formControl);
}

function validate(formcontrol) {
    var ds = formcontrol.dataset;
    var element = formcontrol;

    if (!ds.val) {
        return;
    }

    // Get helper text span
    var valMsgSpan = Array.prototype.filter.call(validationMessageSpans, function (val) {
        return val.dataset.valmsgFor === element.name;
    });

    // Check for required
    if (!!ds.valRequired && !element.value) {
        invalidateControl(element, valMsgSpan, ds.valRequired);
        return;
    }

    // Valid Date
    if (ds.valDate != null) {
        var expression = new RegExp(ds.valDateRegex);
        var date = formatDate(element.value);

        if (!expression.test(date) || !isValidDate(date)) {
            invalidateControl(element, valMsgSpan, ds.valDate);
            return;
        }
    }

    // min and max length
    if ((!!ds.valLengthMax && element.value.length > ds.valLengthMax) || (!!ds.valLengthMin && element.value.length < ds.valLengthMin)) {
        invalidateControl(element, valMsgSpan, ds.valLength);
        return;
    }

    // Regex
    if (ds.valRegex) {
        var expression = new RegExp(ds.valRegexPattern);
        if (!expression.test(element.value)) {
            invalidateControl(element, valMsgSpan, ds.valRegex);
            return;
        }
    }

    // If everything passes, then we're good
    valMsgSpan.forEach(function (msg) {
        msg.innerText = '';
        element.classList.remove(invalidClassName);
    });
}

function invalidateControl(formControl, valMsgSpans, helperText) {
    valMsgSpans.forEach(function (msg) {
        msg.innerText = helperText;
        formControl.classList.add(invalidClassName);
    });
}