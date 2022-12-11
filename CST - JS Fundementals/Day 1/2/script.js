function printHeadings() {
    for (var i = 1; i <= 6; i++) {
        var message = prompt("Enter your message Number " + i + ": ", "Number " + i);
        document.write("<h" + i + ">" + message + "</h" + i + ">");
    }
}

document.write("<h2>Heading</h2> <hr/>");
printHeadings();