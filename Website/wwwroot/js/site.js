$(function () {
    $.get("api/v1/vehicles", function (data) {
        displayRideStats(data);
    });

    $(".next").on("click", function () {
        var nextPage = parseInt($("#page").val()) + 1;


        $("#page").val(nextPage);
        $(".rides-catalog").empty();

        $.get("api/v1/rides?page=" + nextPage, function (data) {
            displayRideStats(data);
        });
    });

    $(".prev").on("click", function () {
        var prevPage = parseInt($("#page").val()) - 1;
        if (prevPage < 0)
            return;

        $("#page").val(prevPage);
        $(".rides-catalog").empty();

        $.get("api/v1/rides?page=" + prevPage, function (data) {
            displayRideStats(data);
        });
    });
});

function displayRideStats(rides)
{
    $.each(rides, function (key, value) {
        $(".rides-catalog").append("<li>" + key + "<a href='" + getRideUri(key) + "'><span class='vehicle-count'>" + value + "</span></a></li>");
    });

    $("#count").text(Object.keys(rides).length + " találat");
}

function getRideUri(vehicle)
{
    vehicle = vehicle + "";
    return "./catalog/ride?Brand=" + vehicle.split(" ")[1] + "&Model=" + vehicle.split(" ")[2] + "&Year=" + vehicle.split(" ")[0];
}