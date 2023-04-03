
const fs = require("fs");

const http = require("http");
http.createServer((req, res) => {
    //logic
    if (req.url != "/favicon.ico") {
        var result = Solve(req.url);

        fs.appendFile("ResultFile.txt", `\n${result}`, () => { })


        res.writeHead(200, "ok", { "content-type": "text/plain" })
        res.write("<h1>Hello World at Server</h1>")
        res.end();
    }
}).listen(7000)

function Solve(url) {
    var Params = url.split("/");
    Params.shift();

    var Method = Params.shift().toLowerCase();

    switch (Method) {
        case "add":
            return add(Params);
        case "sub":
            return sub(Params);
        case "multi":
            return multi(Params);
        case "div":
            return div(Params);
        default:
            return "Invalid Operation";
    }

    return Method;
}

function add(arr) {
    var result = parseInt(arr.shift());
    for (const num of arr) {
        result += parseInt(num);
    }
    return result;
}

function sub(arr) {
    var result = parseInt(arr.shift());
    for (const num of arr) {
        result -= parseInt(num);
    }
    return result;
}

function multi(arr) {
    var result = parseInt(arr.shift());
    for (const num of arr) {
        result *= parseInt(num);
    }
    return result;
}

function div(arr) {
    var result = parseInt(arr.shift());
    for (const num of arr) {
        result /= parseInt(num);
    }
    return result;
}