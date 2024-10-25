


function displayLoader() {
    $('#Loader').show();
}

function hideLoader()
{
    $('#Loader').hide();
}
$('#Loader').hide();

$(document).on('submit', 'form', function () {

    displayLoader();
});

$(window).on('beforeunload', function () {
    displayLoader();
}); 

$(function () {
    if ($('div.alert.msg').length) {

        setTimeout(() => {
            $('div.alert.msg').fadeOut();
        }, 2000);

    }
});
