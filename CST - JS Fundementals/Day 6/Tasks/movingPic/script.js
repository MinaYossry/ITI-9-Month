var icon1Text;
var icon2Text;
var TopText;

var icon1Img;
var icon2Img;
var topImg;

var startStop;
var reset;

var icon1Dx = 10;
var icon2Dx = -10;
var topDy = -10;
var interval;

onload = function () {
    icon1Text = document.getElementById("icon1Left");
    icon2Text = document.getElementById("icon2Left");
    TopText = document.getElementById("TopT");

    icon1Img = document.getElementById("icon1");
    icon2Img = document.getElementById("icon2");
    topImg = document.getElementById("top");

    startStop = document.getElementById("startStop");
    startStop.addEventListener("click", startStopHandler);
    
    reset = document.getElementById("reset");
    reset.addEventListener("click", resetHandler);

    displayText();
}


function startStopHandler()
{
    if (startStop.innerHTML == "Start")
    {
        startStop.innerHTML = "Stop";
        interval = setInterval(startMoving , 50);
    }
    else
    {
        startStop.innerHTML = "Start";
        clearInterval(interval);
    }
}

function resetHandler()
{
    clearInterval(interval);
    icon1Img.style.left = "10px";
    icon2Img.style.left = "450px"
    topImg.style.top = "350px";
    interval = setInterval(startMoving , 50);
}

function displayText()
{
    icon1Text.innerHTML = getComputedStyle(icon1Img).left;
    icon2Text.innerHTML = getComputedStyle(icon2Img).left;
    TopText.innerHTML = getComputedStyle(topImg).top;
}

function startMoving()
{
    var icon1Left = parseInt(getComputedStyle(icon1Img).left);
    var icon2Left = parseInt(getComputedStyle(icon2Img).left);
    var topTop = parseInt(getComputedStyle(topImg).top);

    if (icon1Left >= 450 || icon1Left <= 8)
        icon1Dx = -icon1Dx;
    
    if (icon2Left >= 460 || icon2Left <= 10)
        icon2Dx = -icon2Dx;

    if (topTop >= 360 || topTop <= 10)
        topDy = -topDy;

    icon1Img.style.left = (icon1Left + icon1Dx) + "px";
    icon2Img.style.left = (icon2Left + icon2Dx) + "px";
    topImg.style.top = (topTop + topDy) + "px";

    displayText();

}