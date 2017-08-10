var str = prompt("Введите строку:");
alert("Исходная строка:\n" + str + "\n\nНовая строка:\n" + NewString(str));

//Возвращает новую строку в которой будут удалены все символы, повторяющиеся хоть в одном из слов более одного раза.
function NewString(str) {
    str = str.toLowerCase();
    var separators = [' ', '?', '!', ':', ';', ',', '.'];
    var words = [];
    var letters = [];
    var firstIndex = 0;
    
    // Разбиваем входную строку по разделителям и помещаем в words.
    str.split('').forEach(function (letter, i) {
        if (separators.indexOf(letter) != -1) {
            words.push(str.substr(firstIndex, i - firstIndex));
            firstIndex = i + 1;
        }
    });
    words.push(str.substr(firstIndex));

    // Находим и добавляем повторяющиеся буквы в letters.
    words.forEach(function (word) {
        word.split('').forEach(function (letter, i) {
            if (!letters[letter] && word.indexOf(letter, i + 1) != -1) {
                letters[letter] = 1;
            }
        });
    });

    // Удаляем повторяющиеся буквы.
    str = str.split('').filter(function (i) {
        return !letters[i];
    });

    return str.join('');
}