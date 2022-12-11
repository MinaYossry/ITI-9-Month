var currentNumber = "";
var numbers = [];
var box;

onload = function () {
    box = document.getElementById("Answer");
}

function EnterNumber(value) {
    if ((value == '.' && currentNumber.indexOf('.') == -1) || isFinite(value))
    {
        box.value += value;
        currentNumber += value;
    }
}

function EnterClear() {
    box.value = "";
    numbers = [];
    currentNumber = "";
}

function EnterOperator(value) {
    box.value += value;

    var finalNumber = parseFloat(currentNumber);
    if (isFinite(finalNumber))
        numbers.push(finalNumber);

    currentNumber = "";

    if (value == "-") {
        currentNumber += '-';
        value = "+";
    }
    numbers.push(value);

    console.log(numbers);

}

function EnterEqual() {
    var finalNumber = parseFloat(currentNumber);
    if (isFinite(finalNumber))
        numbers.push(finalNumber);

    var result = solveArray();
    numbers = [];
    box.value = result;
    currentNumber = result;
}

function solveArray() {

    var regex = /[\*\/]/g;
    var currentIndex = numbers.findIndex(op => (op == '*' || op == '/'));
    while (currentIndex != -1) {
        var multiplication = (numbers[currentIndex] === '*');

        var leftOperand = numbers[currentIndex - 1] ? numbers[currentIndex - 1] : 1;
        var rightOperand = numbers[currentIndex + 1] ? numbers[currentIndex + 1] : 1;
        if (multiplication)
            numbers[currentIndex + 1] = leftOperand * rightOperand;
        else
            numbers[currentIndex + 1] = leftOperand / rightOperand;
        numbers[currentIndex - 1] = numbers[currentIndex] = null;
        currentIndex = numbers.findIndex(op => (op == '*' || op == '/'));
        console.log(numbers);
    }

    /*
    var currentIndex = numbers.indexOf('*');
    while (currentIndex != -1) {
        var leftOperand = numbers[currentIndex - 1] ? numbers[currentIndex - 1] : 1;
        var rightOperand = numbers[currentIndex + 1] ? numbers[currentIndex + 1] : 1;
        numbers[currentIndex + 1] = leftOperand * rightOperand;
        numbers[currentIndex - 1] = numbers[currentIndex] = null;
        currentIndex = numbers.indexOf('*', currentIndex);
        console.log(numbers);
    }

    var currentIndex = numbers.indexOf('/');
    while (currentIndex != -1) {
        var leftOperand = numbers[currentIndex - 1] ? numbers[currentIndex - 1] : 1;
        var rightOperand = numbers[currentIndex + 1] ? numbers[currentIndex + 1] : 1;
        numbers[currentIndex + 1] = leftOperand / rightOperand;
        numbers[currentIndex - 1] = numbers[currentIndex] = null;
        currentIndex = numbers.indexOf('/', currentIndex);
        console.log(numbers);
    }
    */

    var result = 0;
    for (var i = 0; i < numbers.length; i++) {
        result += (isFinite(numbers[i])) ? numbers[i] : 0;
    }

    return result;


}