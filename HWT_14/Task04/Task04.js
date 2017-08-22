$(function () {//todo pn почему на следующую не могу перейти? И почему с 1й на последнюю не могу перейти?
    var count = i = 5;
    var numPage = location.href.substr((location.href.length-6), 1);
    var countPages = 4;
    var timerId = setInterval(Timer, 10);

    $("#btn1").click(function () {
        if (numPage > 1) {
            numPage--;
            location.href = numPage.toString() + '.html';
        }
    });

    $("#btn2").click(function () {
        Refresh();
    });

    function Refresh() {
        clearInterval(timerId);
        i = count;
        timerId = setInterval(Timer, 10);
    }

    function Timer() {
        $("#Time").text(i.toFixed(2));
        if (i.toFixed(2) == 0.00) {
            if (numPage < countPages) {
                numPage++;
                location.href = numPage.toString() + '.html';
            }
            else {
                if (confirm('Начать сначала?')) {
                    numPage = 1;
                    location.href = numPage.toString() + '.html';
                }
                else {
                    close();
                }
            }
            clearInterval(timerId);
        }
        i-=0.01;
    }
});