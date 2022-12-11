var n;
var sum = 0;

function takeInput() {
    do {
        var number = prompt("Enter number: ", 0);
        if (isFinite(number))
            return parseInt(number);
        else
            alert("Input is not a number try again");
    } while (isNaN(number));
}

do {
    var number = takeInput();

    sum += number;
} while (number != 0 && sum < 100);

alert(sum);