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
function Consultar() {
    event.preventDefault();
    let Documento = $("#txtDocumento").val();
    DatosCliente = {
        Documento: Documento,
        Nombre: "",
        PrimerApellido: "",
        SegundoApellido: "",
        Telefono: "",
        Direccion: "",
        Email: "",
        FechaNacimiento: "1900/01/01",
        Usuario: "",
        Clave: "",
        Comando: "Consultar"
    }
    //Invocar el controlador vía ajax
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorCliente.ashx",
        contentType: "json",
        data: JSON.stringify(DatosCliente),
        success: function (rptaCliente) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html("Consulta exitosa");
            //Procesar la respuesta del controlador, como un objeto json y pasar los datos a la interfaz
            Cliente = JSON.parse(rptaCliente);
            $("#txtNombre").val(Cliente.Nombre);
            $("#txtPrimerApellido").val(Cliente.PrimerApellido);
            $("#txtSegundoApellido").val(Cliente.SegundoApellido);
            $("#txtTelefono").val(Cliente.Telefono);
            $("#txtDireccion").val(Cliente.Direccion);
            $("#txtEmail").val(Cliente.Email);
            Fecha = Cliente.FechaNacimiento;
            $("#txtFechaNacimiento").val(Fecha.split('T')[0]);
            $("#txtUsuario").val(Cliente.Usuario);
            $("#txtClave").val(Cliente.Clave);
            $("#txtConfirmaClave").val(Cliente.Clave);
        },
        error: function (errCliente) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errCliente);
        }
    });
}
function EjecutarComando(Comando) {
    event.preventDefault();
    //Captura de datos del cliente
    let Documento = $("#txtDocumento").val();
    let Nombre = $("#txtNombre").val();
    let PrimerApellido = $("#txtPrimerApellido").val();
    let SegundoApellido = $("#txtSegundoApellido").val();
    let Telefono = $("#txtTelefono").val();
    let Direccion = $("#txtDireccion").val();
    let Email = $("#txtEmail").val();
    let FechaNacimiento = $("#txtFechaNacimiento").val();
    let Usuario = $("#txtUsuario").val();
    let Clave = $("#txtClave").val();
    let ConfirmaClave = $("#txtConfirmaClave").val();

    if (Comando != "Eliminar") {
        //Se remueve la clase del error
        $("#dvMensaje").removeClass("alert alert-danger");
        //Validaciones de clave y confirma clave (Iguales)
        if (Clave != ConfirmaClave) {
            //Genere un mensaje de error
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html("Las claves no coinciden, por favor valide la información ingresada");
            return;
        }
        //Fecha nacimiento no esté null
        if (FechaNacimiento == null || FechaNacimiento == 'undefined' || FechaNacimiento == '') {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html("Se debe definir la fecha de nacimiento del cliente");
            return;
        }
    }
    else {
        FechaNacimiento = "1900/01/01";
    }

    //Crear estructura json con los datos del cliente
    DatosCliente = {
        Documento: Documento,
        Nombre: Nombre,
        PrimerApellido: PrimerApellido,
        SegundoApellido: SegundoApellido,
        Telefono: Telefono,
        Direccion: Direccion,
        Email: Email,
        FechaNacimiento: FechaNacimiento,
        Usuario: Usuario,
        Clave: Clave,
        Comando: Comando
    }
    //Invocar el controlador vía ajax
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorCliente.ashx",
        contentType: "json",
        data: JSON.stringify(DatosCliente),
        success: function (rptaCliente) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(rptaCliente);
        },
        error: function (errCliente) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errCliente);
        }
    });
}