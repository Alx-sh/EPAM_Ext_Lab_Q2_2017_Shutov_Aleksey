$(function () {
    $.ajaxSetup({ cache: false });

    $('.editOrder').click(function (e) {
        e.preventDefault();
        $.get(this.href, function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });

    $('.createOrder').click(function (e) {
        e.preventDefault();
        $.get('/Orders/CreateOrder', function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });

    $('.deleteOrder').click(function (e) {
        e.preventDefault();
        var arr = $('input:checkbox:checked').map(function () { return this.name; }).get();
        var mes = "\n";

        if (arr.length === 0) {
            alert("Не выбрано ни одного заказа!");
            return;
        }

        for (var i = 0; i < arr.length; i++) {
            mes += arr[i] + "\n";
        }

        if (confirm("Вы уверены, что хотите удалить следующие заказы?\n" + mes)) {
            $.post('/Orders/DeleteSelected', { mas: arr }, function () {
                location.href = "/Orders/DeleteSelected";
            }); 
        }
    });

    $('.back').click(function (e) {
        location.href = "/Orders/Index";
    });

    $('.editProducts').click(function (e) {
        e.preventDefault();
        var OrderID = $.getUrlVar('orderID');
        $.get('/Orders/EditProducts', { orderID: OrderID }, function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });

    $.extend({
        getUrlVars: function () {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }
            return vars;
        },
        getUrlVar: function (name) {
            return $.getUrlVars()[name];
        }
    });
})