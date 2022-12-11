var flyingWin, typWin, scrollWindow;
var interval;
var factor = 1.0;

var xPos = 0;
var yPos = 0;
var movingDistance = 20;

function flyingWindow() {
    if (flyingWin === undefined) {
        flyingWin = window.open("flyingWindow.html", "", "height=150, width=150");
        flyingWin.moveTo(xPos, yPos);
        flyingWin.focus();
        startMoving();
    }
}

function startMoving() {
    interval = setInterval(() => {

        if ((yPos + movingDistance) > (screen.availHeight - 150) || (yPos + movingDistance) < 0)
            movingDistance = -movingDistance;

        xPos += movingDistance;
        yPos += movingDistance;

        flyingWin.moveTo(xPos, yPos);


        /*
        console.log(win.screenY + 150 + " " + screen.availHeight);
        if ((win.screenY == 0))
           factor = 1;
        else if ((win.screenY + 150) > (screen.availHeight - 100))
            factor = -1;
        win.moveBy(25 * factor,25 * factor);
        */

    }, 100);
}

function stopMoving() {
    clearInterval(interval);
    flyingWin.focus();
}


var text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Will close after 3 seconds";
var i = 0;



function typeWriter() {
    if (i < text.length) {
        typWin.document.write(text.charAt(i))
        i++;
        setTimeout(typeWriter, 25);
    }
    else {
        setTimeout(() => {
            typWin.close();
        }, 3000);
    }
}

function typingWindow() {

    typWin = open("typingWindow.html", "", "height=300, width=600");
    typWin.focus();

    typeWriter();

}

function scrollingWindow() {

    scrollWindow = open("slidingWindow.html", "", "height=300, width=600");
    scrollWindow.focus();


    setInterval(() => {
        scrollWindow.scrollBy
            (0, 10);
    }, 50);

}


