
var input = prompt("Enter your string: ", "");
var c = prompt("Enter character to search for: ");
var caseSense = prompt("Case Sensetive?");

caseSense = (caseSense.toLowerCase() == "y") ? '' : 'i';
var regex = new RegExp(c, 'g' + caseSense);

alert(input.match(regex).length);



var input = prompt("Enter your string: ", "");
var caseSense = prompt("Case Sensetive?");

var result;
if (caseSense.toLowerCase() != "y") {
    input = input.toLowerCase();
}
result = (input == input.split('').reverse().join(''));

alert(result);



function largestSubString(str) {
    var Arr = str.split(" ");

    var index = 0;
    var maxLength = 0;

    for (var i = 0; i < Arr.length; i++) {
        if (Arr[i].length > maxLength) {
            index = i;
            maxLength = Arr[i].length;
        }
    }

    return Arr[index];
}

var input = prompt("Enter your string: ", "");

alert(largestSubString(input));



var name, phoneNumber, mobileNumber, email, color;
do {
    name = prompt("Enter your name: ", "");
    var regex = /^[a-z]$/gi;
} while (!regex.test(name));


do {
    phoneNumber = prompt("Enter your Phone Number: ", "");
    var regex = /^[0-9]{8}$/gi;
} while (!regex.test(phoneNumber));

do {
    mobileNumber = prompt("Enter your Mobile Number: ", "");
    var regex = /^01[1-2][0-9]{8}$/;
} while (!regex.test(mobileNumber));

do {
    email = prompt("Enter your Email: ", "");
    var regex = /[a-zA-Z0-9]*@[a-zA-Z0-9]*\.[a-zA-Z0-9]*/;
} while (!regex.test(email));

do {
    color = prompt("Enter you Color:", "blue");
    color = color.toLowerCase();
} while (!(color == "red" || color == "blue" || color == "green"));

document.write("<h3>Entering user info</h3> <hr/>");
document.write("<p><span style='color:" + color + "'>Welcome dear guest </span>" + name + "</p>");
document.write("<p><span style='color:" + color + "'>Your telephone number is </span>" + phoneNumber + "</p>");
document.write("<p><span style='color:" + color + "'>Your mobile number is </span>" + mobileNumber + "</p>");
document.write("<p><span style='color:" + color + "'>Your email is </span>" + email + "</p>");




function sumArr(Arr) {
    var result = 0;

    for (var i = 0; i < 3; i++)
        result += Arr[i];

    return result;
}

function multiArr(Arr) {
    var result = 1;

    for (var i = 0; i < 3; i++)
        result *= Arr[i];

    return result;
}

function divArr(Arr) {
    var result = Arr[0];

    for (var i = 1; i < 3; i++)
        result /= Arr[i];

    return result;
}

var Arr = [];
for (var i = 0; i < 3; i++) {
    Arr[i] = parseInt(prompt("Enter Value #" + (i + 1), ""));
}

var sum = sumArr(Arr);
var multi = multiArr(Arr);
var div = divArr(Arr);

document.write("<h3>+ -- * -- /</h3> <hr/>");
document.write("<p><span style='color:red'>Sum of the 3 values </span>" + Arr[0] + ' + ' + Arr[1] + ' + ' + Arr[2] + ' = ' + sum + "</p>");
document.write("<p><span style='color:red'>multiplication of the 3 values </span>" + Arr[0] + ' * ' + Arr[1] + ' * ' + Arr[2] + ' = ' + multi + "</p>");
document.write("<p><span style='color:red'>division of the 3 values </span>" + Arr[0] + ' / ' + Arr[1] + ' / ' + Arr[2] + ' = ' + div.toFixed(2) + "</p>");




function printArr(Arr) {
    for (var i = 0; i < Arr.length; i++)
        document.write(Arr[i] + " , ");
}

var Arr = [];
for (var i = 0; i < 5; i++) {
    Arr[i] = parseInt(prompt("Enter Value #" + (i + 1), ""));
}

document.write("<h3>Sorting /</h3> <hr/>");
document.write("<p><span style='color:red'>All values </span>");
printArr(Arr);
document.write("</p>");
document.write("<p><span style='color:red'>ASC </span>");
Arr.sort((a, b) => { return a - b });
printArr(Arr);
document.write("</p>");
document.write("<p><span style='color:red'>DESC </span>");
Arr.sort((a, b) => { return b - a });
printArr(Arr);
document.write("</p>");



var radius = parseFloat(prompt("Enter Radius: ", "0.0"));
var area = Math.PI * Math.pow(radius, 2);
alert("Total Area = " + area);

var sq = parseInt(prompt("Enter Square root: ", "0"));
var number = Math.sqrt(sq);
alert("Square root of " + sq + " is " + number);

var angle = parseFloat(prompt("Enter Angle: ", "0"));
var rad = angle * Math.PI / 180;
document.write("<p>cos " + angle + " is " + Math.round(Math.cos(rad)).toFixed(2) + "</p>");
