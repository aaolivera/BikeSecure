$(document).ready(function () {
    $(".boton-logActividad").click(function () {
        var link = $(this).attr("href");

        $.get(link, function (data) {
            $(".modal-body").html(data);
        });
        $('#dialogo').modal('show');
        return false;
    });
});