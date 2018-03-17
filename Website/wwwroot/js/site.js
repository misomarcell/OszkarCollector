$(function () {
    $.get("api/v1/rides", function (data) {
        displayRides(data);
    });

    $(".next").on("click", function () {
        var nextPage = parseInt($("#page").val()) + 1;


        $("#page").val(nextPage);
        $(".rides-catalog").empty();

        $.get("api/v1/rides?page=" + nextPage, function (data) {
        displayRides(data);
        });
    });

    $(".prev").on("click", function () {
        var prevPage = parseInt($("#page").val()) - 1;
        if (prevPage < 0)
            return;

        $("#page").val(prevPage);
        $(".rides-catalog").empty();

        $.get("api/v1/rides?page=" + prevPage, function (data) {
            displayRides(data);
        });
    });
});

function displayRides(rides)
{
    $.each(rides, function () {
        $(".rides-catalog").append("<li><a target='_blank' href='" + this.pageUri + "'>" + this.vehicle.brand + " " + this.vehicle.model + " " + this.vehicle.year + "</a></li>");
    });

    $("#count").text(rides.length + " találat");
}