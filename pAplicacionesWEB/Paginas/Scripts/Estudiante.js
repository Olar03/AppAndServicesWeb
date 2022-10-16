//Código para garantizar que se ejecute el código cuando termine de cargar la página
$(document).ready(function () {

    $("#btnRegistrar").click(function () {
        ProcesarComando("Insertar");
    });

    LlenarGridEstudiantes();

});

function LlenarGridEstudiantes() {
    LlenarGridControlador("../Comunes/ControladorGrids.ashx", "Estudiantes", null, "#tblEstudiantes");
}


function ProcesarComando(Comando) {

    var Documento = $("#txtDocumento").val();
    var Nombre = $("#txtNombre").val();
    var Apellidos = $("#txtApellidos").val();
    var Email = $("#txtEmail").val();
    var Telefono = $("#txtTelefono").val();
    if (Comando == "Insertar") { Codigo = 0; }



    var DatosEstudiante = {
        Documento: Documento,
        Nombre: Nombre,
        Apellidos: Apellidos,
        Email: Email,
        Telefono: Telefono,
        CodigoLibro: Libro,
        FechaPrestamo: FechaPrestamo,
        FechaDevolucion: FechaDevolucion,
        Comando: Comando
    }
    $.ajax({
        //Función Ajax
        type: "POST",
        url: "../Controladores/ControladorEstudiantes.ashx",
        contentType: "json",
        data: JSON.stringify(DatosEstudiante),
        success: function (RespuestaEstudiante) {

            //Hay que procesar la respuesta para identificar si hay un error
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(RespuestaEstudiante);

            LlenarComboLibros();
            LlenarGridEstudiantes();


        },
        error: function (RespuestaError) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(RespuestaError);
        }
    });
}