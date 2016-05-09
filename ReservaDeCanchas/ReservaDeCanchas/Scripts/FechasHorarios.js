
function cambiarFecha() {
    $("#BuscaEventosForm").submit();
}

function fechaAnterior() {
    //var fechain = $("#FechaInicio").val();
    var fechaF = new Date($("#FechaInicio").val());
    var hoy = new Date.now();
    fechaF.setDay(fechaF.getDay - 1);

    if (hoy.getDate() >= fechaF.getDate()) {
        $("#FechaInicio").val(fechaF);
        cambiarFecha();
    }

}

$(function () {
    $("#FechaInicio").change(cambiarFecha);
    $("#BtnAnterior").click(fechaAnterior);

});