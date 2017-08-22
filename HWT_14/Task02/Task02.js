while (true) {
    var str = prompt("Введите выражение (конец выражения знак '=')\n Например: 3.5 +4*10-5.3 /5 =");
    if (str[str.length - 1] == "=") {
        alert("Выражение:\n" + str + Result(str));
    }
    else {
        alert("Последний символ должен быть '='!\nПовторите ввод.");
    }
}

//Функция для подсчёта результата выражения.
function Result(str) {
    var operators = ['+', '-', '*', '/', '='];
    var numbers = [];
    var operations = [];
    var firstIndex = 0;

    str = str.replace(' ', '');

    // Разбиваем входную строку на числа и операции.
    str.split('').forEach(function (sym, i) {
        if (operators.indexOf(sym) != -1) {
            numbers.push(parseFloat(str.substr(firstIndex, i - firstIndex)));
            operations.push(str.substr(i, 1));
            firstIndex = i + 1;
        }
    });

    var result = numbers[0];

    for (var i = 0; i < operations.length; i++) {
        switch (operations[i]) {
            case operators[4]: {
                break;
            }
            case operators[0]: {
                result += numbers[i + 1];
                break;
            }
            case operators[1]: {
                result -= numbers[i + 1];
                break;
            }
            case operators[2]: {
                result *= numbers[i + 1];
                break;
            }
            case operators[3]: {
                result /= numbers[i + 1];
                break;
            }
            default: {
                break;
            }

        }
    }
    return result.toFixed(2);
}