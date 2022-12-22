var data;
$(function () {
    var xhr = $.ajax({
        method: "GET",
        url: "rockbands.json",
        data: [],
        success: function (res) {
            data = res;
            var bands = Object.keys(data);
            for (var i = 0; i < bands.length; i++) {
                var child = $("<option>").attr("value", bands[i]).text(bands[i]);
                $("#band").append(child);
            }
        },
        error: function () {
        }
    })

    $("#band").on("change", function () {
        var currentBand = $("#band").get(0).value;
        console.log(data[currentBand]);
        for (var i = 0; i < data[currentBand].length; i++) {
            var child = $("<option>").attr("value", data[currentBand][i].value).text(data[currentBand][i].name);
            $("#artist").append(child);
        }
    })

    $("#artist").on("change", function () {
        location.replace($("#artist")[0].value)
    })


})
