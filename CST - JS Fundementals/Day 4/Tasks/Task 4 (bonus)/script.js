var matrix = [
    [null, null, null, null],
    [null, null, null, null],
    [null, null, null, null]
];

function getRandomInt(max) {
    return Math.floor(Math.random() * max);
}

function randomize() {
    for (var i = 1; i <= 6; i++) {
        var count = 0;
        while (count < 2) {
            var location = getRandomInt(12);
            var row = Math.floor(location / 4);
            var col = location % 4;
            if (matrix[row][col] === null) {
                matrix[row][col] = i;
                count++;
            }
        }
    }
}

var openCount = 0;
var prevRow = -1;
var prevCol = -1;
var images;
var moon = "img/Moon.gif";

onload = function () {
    images = document.getElementsByTagName("img");
    for (var i = 0; i < images.length; i++)
    {
        images[i].onclick = openImg;
    }
    randomize();
};

function openImg(imgObj) {
    if (imgObj.target.src.match(moon) && openCount !== 2) {
        var index = imgObj.target.id - 1;
        var row = Math.floor(index / 4);
        var col = index % 4;

        imgObj.target.src = "img/" + matrix[row][col] + ".gif";
        openCount++;

        if (openCount === 1) {
            prevRow = row;
            prevCol = col;
        }
        else if (openCount === 2) {
            if (matrix[row][col] !== matrix[prevRow][prevCol]) {
                setTimeout(() => {
                    openCount = 0;
                    images[row * 4 + col].src = moon;
                    images[prevRow * 4 + prevCol].src = moon;
                }, 500);
            }
            else {
                openCount = 0;
                images[row * 4 + col].alt = "true";
                images[prevRow * 4 + prevCol].alt = "true";

                if (isFinished())
                    setTimeout(() => {
                        var reset = confirm("Bravo!! Do you want to play again?");
                        if (reset) {
                            location.reload();
                        }
                    }, 250);
            }
        }

    }

    function isFinished() {
        var solved = true;

        for (var i = 0; i < images.length && solved; i++) {
            if (images[i].alt == "false")
                solved = false;
        }

        return solved;
    }
}