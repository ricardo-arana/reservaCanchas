function selecionaHorario(eventData) {
    var fechaAlquiler =$(eventData.target).attr("fecha-Alquiler");

    $(".modal-body").prepend(
        'Fecha de Alquiler: ' + fechaAlquiler
        );
}


$(function () {

    $("#tablaHorarios").on("click", ".horarioLibre", selecionaHorario);
});


