$(function () {
    $(".container>div").hide();
    switchTo(".show");

    $("#about").click(function () {
        switchTo(".show");
    })

    $("#gallary").click(function () {
        switchTo(".gallary");
    })

    $("#services").click(function () {
        switchTo(".dropdown")
    })

    $("#complain").click(function () {
        switchTo(".form");
    })

    $("#submit").click(function () {
        name = $("#name")[0].value;
        email = $("#email")[0].value;
        phone = $("#phone")[0].value;
        cp = $("#cp")[0].value;
        switchTo(".complain");
        $("#cpText").html(cp);
        $("#nameText").html(name);
        $("#emailText").html(email);
        $("#phoneText").html(phone);

    })

    $("#back").click(function () {
        switchTo(".form");
    })



    $("#left").click(function () {
        var index = parseInt($(".currentImg").attr("id"));
        index = (index === 1) ? 8 : (index - 1);
        $(".currentImg").attr("src", "imgs/" + index + ".jpg")
        $(".currentImg").attr("id", index);
    })

    $("#right").click(function () {
        var index = parseInt($(".currentImg").attr("id"));
        index = (index === 8) ? 1 : (index + 1);
        $(".currentImg").attr("src", "imgs/" + index + ".jpg")
        $(".currentImg").attr("id", index);
    })
})

function switchTo(section) {
    $(".current").hide().removeClass("current");
    $(section).show().addClass("current");
}

var name;
var email;
var phone;
var cp;