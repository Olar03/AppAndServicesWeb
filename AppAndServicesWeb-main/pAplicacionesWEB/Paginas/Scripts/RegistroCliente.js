//Código para garantizar que se ejecute el código cuando termine de cargar la página
$(document).ready(function () {
    //Defino la funcionalidad de la página
    //Funcionalidad del botón "Registrar"
    $("#btnRegistrar").click(function () {
        var Documento = $("#txtDocumento").val();
        var Nombre = $("#txtNombre").val();
        var PrimerApellido = $("#txtPrimerApellido").val();
        var SegundoApellido = $("#txtSegundoApellido").val();
        var FechaNacimiento = $("#txtFechaNacimiento").val();
        var Email = $("#txtEmail").val();
        var Direccion = $("#txtDireccion").val();
        var Telefono = $("#txtTelefono").val();
        
        var DatosCliente = {
            Documento: Documento,
            Nombre: Nombre,
            PrimerApellido: PrimerApellido,
            SegundoApellido: SegundoApellido,
            Email: Email,
            FechaNacimiento: FechaNacimiento,
            Telefono: Telefono,
            Direccion: Direccion
        }
        $.ajax({
            //Función Ajax
            type: "POST",
            url: "../Controladores/ControladorCliente.ashx",
            contentType: "json",
            data: JSON.stringify(DatosCliente),
            success: function (RespuestaCliente) {
                //Hay que procesar la respuesta para identificar si hay un error
                $("#dvMensaje").addClass("alert alert-success");
                $("#dvMensaje").html(RespuestaCliente);
            },
            error: function (RespuestaError) {
                $("#dvMensaje").addClass("alert alert-danger");
                $("#dvMensaje").html(RespuestaError);
            }
        });
    });
});
