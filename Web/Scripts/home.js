$(document).ready(function () {
    $('body').on("click",".boton-logActividad",function () {
        var link = $(this).attr("href");

        $.get(link, function (data) {
            $(".modal-body").html(data);
        });
        $('#dialogo').modal('show');
        return false;
    });
    Actualidar();
});

function Actualidar() {
    setInterval(refresco, 200);
}

function refresco(){
    $.get($('#estacionamientos').data().refrescar, function (data) {
        $('#estacionamientos').html(data);
    });
}