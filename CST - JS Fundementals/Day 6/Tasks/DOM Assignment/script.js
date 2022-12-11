document.getElementById("header").style.textAlign = "right";

var footer = document.createElement("div");
var newImg = copyImg(document.getElementById("header").firstElementChild);
footer.append(newImg);
document.body.append(footer);

document.getElementById("nav").style.listStyleType = "circle";

function copyImg(originalImg)
{
    var newImg = document.createElement("img");
    newImg.src = originalImg.src;
    newImg.alt = originalImg.alt;
    return newImg;
}