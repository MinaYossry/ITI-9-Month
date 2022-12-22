var interval;

$(function () {
    $("#left").text($("#car").css("left"));
    $("#start").click(function () {
        $("#car").animate({
            left: "1000"
        }, 1500, "easeInCirc").hide("explode", 1000);
        $("#left").text($("#car").css("left"));
        interval = setInterval(startMoving, 0);
    })
})

function startMoving() {
    $("#left").text($("#car").css("left"));
    if ($("#car").css("left") === "1000px") {
        clearInterval(interval);
    }
}
