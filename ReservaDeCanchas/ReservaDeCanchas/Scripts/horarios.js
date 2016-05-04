function selecionaHorario(eventData) {
    var fechaAlquiler =$(eventData.target).attr("fecha-Alquiler");
    $("#ifechaAlquiler").val(fechaAlquiler);
    var horaAlquiler = $(eventData.target).attr("hora");
    $("#iHora").val(horaAlquiler+":00");
    var idCampo = $(eventData.target).attr("idCampo");
    $("#iIdCampo").val(idCampo);
    
}


$(function () {

    $("#tablaHorarios").on("click", ".horarioLibre", selecionaHorario);
    
});


