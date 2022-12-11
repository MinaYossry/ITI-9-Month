
function detectBrowser(agent) {
    switch (true) {
        case agent.indexOf("edge") > -1: return "MS Edge";
        case agent.indexOf("edg/") > -1: return "Edge ( chromium based)";
        case agent.indexOf("opr") > -1 && !!window.opr: return "Opera";
        case agent.indexOf("chrome") > -1 && !!window.chrome: return "Chrome";
        case agent.indexOf("trident") > -1: return "MS IE";
        case agent.indexOf("firefox") > -1: return "Mozilla Firefox";
        case agent.indexOf("safari") > -1: return "Safari";
        default: return "other";
    }
}

var browserName = detectBrowser(window.navigator.userAgent.toLowerCase());


var queryString = location.search.slice(1).split('&');

for (var i = 0; i < queryString.length; i++) {
    queryString[i] = queryString[i].split('=');
}

document.write("Welcome " + decodeURIComponent(queryString[0][1].replace(/\+/g, " ")) + "<br/><br/>");
for (var i = 1; i < queryString.length; i++) {
    if (queryString[i][0] != "password")
        document.write(queryString[i][0] + ": " + decodeURIComponent(queryString[i][1].replace(/\+/g, " ")) + "<br/>");
}

/*
        var queryString = new URLSearchParams(location.search);
        var params = Object.fromEntries(queryString.entries());
        console.log(params);

        document.write("Welcome: " + params.Name + "<br/><br/>");
        for (i in params) {
            if (i != "password" && i != "Name")
                document.write(i + ": " + params[i] + "<br/>");
        }
*/
if (browserName != "Chrome") {
    document.write("<p style='color:red'>You aren't using Chrome</p>")
}