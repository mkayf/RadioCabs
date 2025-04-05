// Company listing form amount toggler:

$('#paymentType').change(function () {
    const paymentType = $(this).val();
    const amountDisplay = $('#amountDisplay');
    const amountSpan = $('#amount');

    if (paymentType === 'monthly') {
        amountSpan.text('15');
        amountDisplay.show();
    } else if (paymentType === 'quarterly') {
        amountSpan.text('40');
        amountDisplay.show();
    } else {
        amountDisplay.hide();
    }
});