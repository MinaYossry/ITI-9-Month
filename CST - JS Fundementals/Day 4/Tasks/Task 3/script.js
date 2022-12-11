var images;
var current = 0;
var show;

onload = function() {
    images = document.getElementsByTagName("img");  
    startShow();
}

function startShow()
{
    show = setInterval(() => {
        images[current].src = "marbels/marble1.jpg";
        current = ++current % images.length;
        images[current].src = "marbels/marble3.jpg";
    }, 500);
}

function stopShow()
{
    clearInterval(show);
}