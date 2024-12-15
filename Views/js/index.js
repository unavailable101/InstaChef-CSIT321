

$(document).ready(function () {

    var user = sessionStorage.getItem('userDetails');

    if (!user) {
        window.location.href = 'login.html';
    }

    $('#get-started').on('click', function () {
        window.location.href = 'loginsignup.html';
    });

    
});