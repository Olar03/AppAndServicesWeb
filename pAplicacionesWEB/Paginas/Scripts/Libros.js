$(document).ready(function () {

    $("#btnGuardar").click(function () {
        ProcesarComando("Insertar");
    });

    LlenarComboLibros();
    LlenarGridLibros();

});

function LlenarGridLibros() {
    LlenarGridControlador("../Comunes/ControladorGrids.ashx", "Libros", null, "#tblLibros");
}
function ProcesarComando(Comando) {

    var CodigoEstudiante = $("#cboEstudiante").val();
    var Nombre = $("#txtNombreLibro").val();
    var FechaPrestamo;
    if ($(" #txtFechaPrestamo").val() == "") {
        FechaPrestamo = "1900-01-01";
    }
    var FechaDevolucion;
    if ($(" #txtFechaDevolucion").val() == "") {
        FechaDevolucion = "1900-01-01";
    }
    if (Comando == "Insertar") { Codigo = 0; }

    var DatosLibros = {
        CodigoEstudiante: CodigoEstudiante,
        Nombre: Nombre,
        FechaPrestamo: FechaPrestamo,
        FechaDevolucion: FechaDevolucion,
        Comando: Comando
    }
    $.ajax({

        type: "POST",
        url: "../Controladores/ControladorLibros.ashx",
        contentType: "json",
        data: JSON.stringify(DatosLibros),
        success: function (RespuestaLibros) {
            $("#dvMensajeLibros").addClass("alert alert-success");
            $("#dvMensajeLibros").html(RespuestaLibros);

            LlenarGridLibros();

        },
        error: function (RespuestaError) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(RespuestaError);
        }
    });
}
function LlenarComboLibros() {
    LlenarComboControlador("../Comunes/ControladorCombos.ashx", "Libros", null, "#cboEstudiante");


}
