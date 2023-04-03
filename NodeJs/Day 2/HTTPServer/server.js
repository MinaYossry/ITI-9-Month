const http = require("http");
const fs = require("fs");

let indexHTML = fs.readFileSync("./Client/index.html").toString();
let welcomeHTML = fs.readFileSync("./Client/welcome.html").toString();
let allClientsHTML = fs.readFileSync("./Client/allClients.html").toString();
let regInfoObj = {}

http.createServer((req, res) => {
    if (req.method == "GET") {
        switch (req.url) {
            case "/":
            case "/Client/index.html":
                res.write(indexHTML);
                break;
            case "/Client/allClients.html":
                res.write(allClientsHTML);
                break;
            default:
                try {
                    let file = fs.readFileSync(`./Client${req.url}`);
                    res.write(file);
                } catch (e) {
                    console.log(e);
                }
        }
        res.end();
    }
    else if (req.method == "POST") {
        req.on("data", (data) => {
            let regInfo = data.toString().split("&");

            regInfo.forEach(element => {
                element = element.split("=");

                regInfoObj[element[0]] = decodeURIComponent(element[1].replace(/\+/g, " "));
            });

            var clients = JSON.parse(fs.readFileSync("./Client/clients.json"));
            clients.push(regInfoObj);
            fs.writeFileSync("./Client/clients.json", JSON.stringify(clients), () => { })
        })

        req.on("end", () => {
            let output = welcomeHTML;

            output = output.replace("{Name}", regInfoObj.Name)
            output = output.replace("{Email}", regInfoObj.Email)
            output = output.replace("{Phone}", regInfoObj.Phone)
            output = output.replace("{Address}", regInfoObj.Address)

            res.write(output);
            res.end();
        })
    }
}).listen(7000, () => {
    console.log("Listening of port 7000");
})