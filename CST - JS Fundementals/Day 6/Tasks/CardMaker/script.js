document.getElementById("generate").addEventListener("click", function () {

    var selectedCard = document.querySelector('input[name="card"]:checked').value;
    var userText = document.getElementById("message").value;
    var newWindow = window.open("", "", "width=900, height=900");
    

    var img = newWindow.document.createElement("img");
    img.src = "http://127.0.0.1:5500/"+selectedCard+".jpg";
    img.style.width = "625px";
    img.style.height = "625px";

    var par = newWindow.document.createElement("p");
    par.innerText = userText;

    var button = newWindow.document.createElement("button");
    button.innerText = "Close window";
    button.onclick = function () {
        newWindow.close();
    }

    var div = newWindow.document.createElement("div");
    div.style.textAlign = "center";
    div.append(img);
    div.append(par);
    div.append(button);

    newWindow.document.body.append(div);
})