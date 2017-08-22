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
            $.post('/Orders/DeleteSelected', { mas: arr }, function (data) {
                location.href = "/Orders/DeleteSelected";
            }); 
        }
    });

    $('.editProducts').click(function (e) {
        e.preventDefault();
        $.get('/Orders/EditProducts', { orderID : OrderID}, function (data) {
            $('#dialogContent2').html(data);
            $('#modDialog2').modal('show');
        });
    });
})