var images = ["img/1.jpg","img/2.jpg","img/3.jpg","img/4.jpg","img/5.jpg","img/6.jpg"];

var index = 0;
var show;

function nextPic()
{
    var img = document.getElementById('image');
    index = ((index + 1) == images.length) ? index : ++index;
    img.src = images[index]
}

function prevPic()
{
    var img = document.getElementById('image');
    index = ((index - 1) == -1) ? 0 : --index;
    img.src = images[index];
}

function startShow()
{
    var img = document.getElementById('image');
    show = setInterval(() => {
        index = ++index % images.length;
        img.src = images[index];
    }, 1000);
}

function stopShow()
{
    clearInterval(show);
}