$(function () {//todo pn посмотри, что будет, если добавить ещё один такой же контрол. Работать будет только первый.
    var firstMiltiple = "#id1";
    var secondMiltiple = "#id2";

    $("#btn1").click(function () {
        var array = $(firstMiltiple);
        $(secondMiltiple).append(array.innerHTML);
        for (var i = 0; i < array.length; i++) {
            $(secondMiltiple).append(array[i].innerHTML);
            array.empty(array[i].innerHTML);
        }
    });

    $("#btn2").click(function () {
        var array = $(firstMiltiple + " option:selected");
        if (!array.length) {
            alert("Выберите опцию (ctrl или shift для нескольких пунктов)!");
        }
        else {
            $(secondMiltiple).append(array.outerHTML);
            for (var i = 0; i < array.length; i++) {
                $(secondMiltiple).append(array[i].outerHTML);
                array.remove();
            }
        }
    });

    $("#btn3").click(function () {
        var array = $(secondMiltiple + " option:selected");
        if (!array.length) {
            alert("Выберите опцию (ctrl или shift для нескольких пунктов)!");
        }
        else {
            $(firstMiltiple).append(array.outerHTML);
            for (var i = 0; i < array.length; i++) {
                $(firstMiltiple).append(array[i].outerHTML);
                array.remove();
            }
        }
    });

    $("#btn4").click(function () {
        var array = $(secondMiltiple);
        for (var i = 0; i < array.length; i++) {
            $(firstMiltiple).append(array[i].innerHTML);
            array.empty(array[i].innerHTML);
        }
    });
});