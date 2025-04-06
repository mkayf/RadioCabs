// Company listing form amount toggler:

if (window.location.pathname.includes('/Home/Listings')) {
    $('#paymentType').change(function () {
        const paymentType = $(this).val();
        const amountDisplay = $('#amountDisplay');
        const amountSpan = $('#amount');

        if (paymentType === 'Monthly') {
            amountSpan.text('15');
            amountDisplay.show();
        } else if (paymentType === 'Quarterly') {
            amountSpan.text('40');
            amountDisplay.show();
        } else {
            amountDisplay.hide();
        }
    });
}


// Drivers listing form amount toggler:

if (window.location.pathname.includes('/Home/Drivers')) {
    $('#paymentType').change(function () {
        const paymentType = $(this).val();
        const amountDisplay = $('#amountDisplay');
        const amountSpan = $('#amount');

        if (paymentType === 'Monthly') {
            amountSpan.text('10');
            amountDisplay.show();
        } else if (paymentType === 'Quarterly') {
            amountSpan.text('25');
            amountDisplay.show();
        } else {
            amountDisplay.hide();
        }
    });
}