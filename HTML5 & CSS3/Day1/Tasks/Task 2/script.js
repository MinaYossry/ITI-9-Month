onload = function () {
    var targetP = document.getElementById("target");
    var redColor = document.getElementById("red").value;
    var greenColor = document.getElementById("green").value;
    var blueColor = document.getElementById("blue").value;

    document.getElementById("red").addEventListener("input", function () {
        redColor = this.value;
        targetP.style.color = `rgb(${redColor}, ${greenColor}, ${blueColor})`;
    })

    document.getElementById("green").addEventListener("input", function () {
        greenColor = this.value;
        targetP.style.color = `rgb(${redColor}, ${greenColor}, ${blueColor})`;
    })

    document.getElementById("blue").addEventListener("input", function () {
        blueColor = this.value;
        targetP.style.color = `rgb(${redColor}, ${greenColor}, ${blueColor})`;
    })
}
