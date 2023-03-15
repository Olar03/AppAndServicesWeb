$(document).ready(function () {
    //Registrar el evento click de los botones
    $("#bntInsertar").click(function () {
        EjecutarComando("Insertar");
    });
    $("#btnActualizar").click(function () {
        EjecutarComando("Actualizar");
    });
    $("#btnEliminar").click(function () {
        EjecutarComando("Eliminar");
    });
    $("#btnConsultar").click(function () {
        Consultar();
    });
});
function EjecutarComando(Comando) {
    event.preventDefault();
    //Captura de datos del cliente
    let Documento = $("#txtDocumento").val();
    let Nombre = $("#txtNombre").val();
    let Cantidad = $("#txtCantidadCursos").val();

    //Crear estructura json con los datos del curso
    DatosCurso = {
        Documento: Documento,
        NombreDocente: Nombre,
        CantidadCursos: Cantidad,
        Comando: Comando
    }
    //Invocar el controlador vía ajax
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorCursos.ashx",
        contentType: "json",
        data: JSON.stringify(DatosCurso),
        success: function (Rpta) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(Rpta);
        },
        error: function (err) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(err);
        }
    });
}
function Consultar() {
    event.preventDefault();
    let Documento = $("#txtDocumento").val();
    DatosCurso = {
        Documento: Documento,
        NombreDocente: "",
        CantidadCursos: 1,
        Comando: "Consultar"
    }
    //Invocar el controlador vía ajax
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorCursos.ashx",
        contentType: "json",
        data: JSON.stringify(DatosCurso),
        success: function (Rpta) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html("Consulta exitosa");
            //Procesar la respuesta del controlador, como un objeto json y pasar los datos a la interfaz
            Curso = JSON.parse(Rpta);
            $("#txtNombre").val(Curso.NombreDocente);
            $("#txtCantidadCursos").val(Curso.CantidadCursos);
            $("#txtPorcentajeDescuento").val(Curso.PorcentajeDescuento);
            $("#txtValorDescuento").val(Curso.ValorDescuento);
            $("#txtTotalAntes").val(Curso.ValorPagoAntesDcto);
            $("#txtTotalPago").val(Curso.TotalPagar);
        },
        error: function (errCliente) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errCliente);
        }
    });
}