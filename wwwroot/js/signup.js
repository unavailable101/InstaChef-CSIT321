// $(document).ready(function () {
//     $('#signup-form').submit(function (e) {
//         e.preventDefault();

//         var formData = new FormData(this);

//         $.ajax({
//             url: 'http://localhost:7208/login',
//             type: 'POST',
//             contentType: false,
//             processData: false,
//             data: formData,
//             success: function (response) {
//                 if (response !== null) {
//                     window.location.href = 'login.html';
//                 } else {
//                     $('#signup-error').html(response);
//                 }
//             },
//             error: function (response) {
//                 $('#signup-error').html(response);
//             }
//         });
//     });
// });