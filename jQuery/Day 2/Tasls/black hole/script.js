$(function () {
    $("#rabbit").draggable();
    $("#blackHole").droppable({
        drop: function () {
            $("#rabbit").hide("explode", 2000);
        }
    })
})