

$(document).ready(function () {

    var user = sessionStorage.getItem('userDetails');

    if (!user) {
        window.location.href = 'login.html';
    }

    $('#login').on('click', function () {
        window.location.href = 'login.html';
    });

    $('#signup').on('click', function () {
        window.location.href = 'signup.html';
    });
});