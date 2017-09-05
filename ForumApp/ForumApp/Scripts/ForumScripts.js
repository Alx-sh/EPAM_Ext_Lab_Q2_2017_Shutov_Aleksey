$(function () {
    $.ajaxSetup({ cache: false });

    $('.Login').click(function (e) {
        e.preventDefault();
        $.get('/Account/LogIn', function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });

    $('.Registration').click(function (e) {
        e.preventDefault();
        $.get('/Account/Registration', function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });

    $('.Logout').click(function (e) {
        e.preventDefault();
        $.get('/Account/LogOut', function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });

    $('.CreateTopic').click(function (e) {
        e.preventDefault();
        $.get('/Home/CreateTopic', function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });

    $('.EditMessage').click(function (e) {
        e.preventDefault();
        $.get('/Home/EditMessage', function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });

    $('.DeleteMessage').click(function (e) {
        e.preventDefault();
        $.post('/Home/DeleteMessage', function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });
     
    $('.back').click(function (e) {
        location.href = "/Home/Index";
    });
})