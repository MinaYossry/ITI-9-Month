const fs = require("fs");
const exp = require("express");
const app = exp();
const path = require("path");

let PORT = process.env.PORT || 7008;
const bodyParser = require("body-parser");
const welcomePage = fs.readFileSync("../Client/Welcome.html").toString();
const jsonArray = fs.readFileSync("../Client/Clients.json").toString();
var myArrOfObjects = [];
if (jsonArray != "") {
  myArrOfObjects = JSON.parse(jsonArray);
}
var ObjectToBePushed = {};
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));
var name = "";
var mobile = "";
var email = "";
var address = "";

//#region  present Home Page
app.get("/", (req, res) => {
  res.sendFile(path.join(__dirname, "../Client/home.html"));
});
app.get("/bootstrap.min.css", (req, res) => {
  res.sendFile(path.join(__dirname, "../Client/bootstrap.min.css"));
});
app.get("/bootstrap.min.js", (req, res) => {
  res.sendFile(path.join(__dirname, "../Client/bootstrap.min.js"));
});
app.get("/script.js", (req, res) => {
  res.sendFile(path.join(__dirname, "../Client/script.js"));
});
app.get("/home.html", (req, res) => {
  res.sendFile(path.join(__dirname, "../Client/home.html"));
});
app.get("/home.html/bootstrap.min.css", (req, res) => {
  res.sendFile(path.join(__dirname, "../Client/bootstrap.min.css"));
});
app.get("/home.html/bootstrap.min.js", (req, res) => {
  res.sendFile(path.join(__dirname, "../Client/bootstrap.min.js"));
});
app.get("/home.html/script.js", (req, res) => {
  res.sendFile(path.join(__dirname, "../Client/script.js"));
});
//#endregion

//#region Post Method

app.post("/welcome.html", (req, res) => {
  console.log(req.body);
  ({ name, mobile, email, address } = req.body);
  //   name = req.body.name;
  //   mobile = req.body.mobile;
  //   email = req.body.email;
  //   address = req.body.address;

  console.log(`${name},${mobile},${email},${address}`);
  myArrOfObjects.push(req.body);
  fs.writeFileSync("../Client/Clients.json", JSON.stringify(myArrOfObjects));
  res.send(
    welcomePage
      .replaceAll("{name}", req.body.name)
      .replaceAll("{MobileNumber}", req.body.mobile)
      .replaceAll("{Email}", req.body.email)
      .replaceAll("{Address}", req.body.address)
  );
});
//#endregion

//#region GetJson
app.get("/GetJson", (req, res) => {
  res.sendFile(path.join(__dirname, "../Client/Clients.json"));
});
//#endregion

app.listen(PORT, () => {
  console.log("http://www.localhost:" + PORT);
});
